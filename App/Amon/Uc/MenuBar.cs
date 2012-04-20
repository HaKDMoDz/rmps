using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Pwd.E;
using Me.Amon.Util;

namespace Me.Amon.Uc
{
    public class MenuBar
    {
        private string _Error;
        private XmlDocument _Document;
        private Dictionary<string, Assembly> _Assemblys;
        private Dictionary<string, ToolStripItem> _Items;
        private Dictionary<string, ItemGroup> _Groups;
        private Dictionary<string, IAction> _Actions;
        private List<KeyStroke> _Strokes;

        #region 构造函数
        public MenuBar()
        {
            _Items = new Dictionary<string, ToolStripItem>();
            _Groups = new Dictionary<string, ItemGroup>();
            _Actions = new Dictionary<string, IAction>();
            _Strokes = new List<KeyStroke>();
        }
        #endregion

        #region 数据加载
        public bool Load(string path)
        {
            _Error = null;
            _Strokes.Clear();

            _Document = new XmlDocument();
            if (string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            StreamReader reader = new StreamReader(path);
            _Document.Load(reader);
            reader.Close();

            return Load();
        }

        public bool Load(TextReader reader)
        {
            _Error = null;
            _Strokes.Clear();

            _Document.Load(reader);
            return Load();
        }

        private bool Load()
        {
            _Assemblys = new Dictionary<string, Assembly>();
            _Assemblys[""] = Assembly.GetExecutingAssembly();

            #region 类库
            XmlNodeList list = _Document.SelectNodes("/Amon/Libs/Lib");
            if (list == null || list.Count < 1)
            {
                return true;
            }

            try
            {
                string path = Application.StartupPath;
                foreach (XmlNode node in list)
                {
                    string file = Attribute(node, "Path", "");
                    if (!CharUtil.IsValidate(file))
                    {
                        continue;
                    }
                    if (!Path.IsPathRooted(file))
                    {
                        file = Path.Combine(path, file);
                    }
                    if (!File.Exists(file))
                    {
                        _Error = string.Format("找不到类库 {0}", file);
                        return false;
                    }
                    //动态加载程序集
                    Assembly assembly = Assembly.LoadFrom(file);
                    string id = Attribute(node, "Id", null);
                    if (CharUtil.IsValidate(id))
                    {
                        _Assemblys[id] = assembly;
                    }
                }
            }
            catch (Exception exp)
            {
                _Error = exp.Message;
                return false;
            }
            #endregion

            #region 事件
            list = _Document.SelectNodes("/Amon/Actions/Action");
            if (list == null || list.Count < 1)
            {
                return true;
            }
            foreach (XmlNode node in list)
            {
                string id = Attribute(node, "Id", "");
                if (string.IsNullOrWhiteSpace(id))
                {
                    _Error = "Action的Id不能为空！";
                    return false;
                }
                string type = Attribute(node, "Class", null);
                if (string.IsNullOrWhiteSpace(type))
                {
                    _Error = "Action的Class不能为空！";
                    return false;
                }

                string libId = Attribute(node, "LibId", "");
                if (!_Assemblys.ContainsKey(libId))
                {
                    libId = "";
                }
                Assembly assembly = _Assemblys[libId];

                try
                {
                    IAction action = assembly.CreateInstance(type) as IAction;
                    if (action == null)
                    {
                        return false;
                    }
                    if (!string.IsNullOrWhiteSpace(id))
                    {
                        _Actions[id] = action;
                    }
                }
                catch (Exception ex)
                {
                    _Error = ex.Message;
                    return false;
                }
            }
            #endregion

            return true;
        }
        #endregion

        #region 公共函数
        public string Error
        {
            get
            {
                return _Error;
            }
        }

        public List<KeyStroke> KeyStrokes { get { return _Strokes; } }

        public ToolStripItem GetButton(string id)
        {
            return _Items[id];
        }

        public IAction GetAction(string id)
        {
            return _Actions[id];
        }

        public ItemGroup GetGroup(string id)
        {
            return _Groups[id];
        }
        #endregion

        #region 组件初始化
        public bool GetMenuBar(string menuId, MenuStrip menuBar)
        {
            if (!CharUtil.IsValidate(menuId) || _Document == null)
            {
                return false;
            }
            XmlNode root = _Document.SelectSingleNode(string.Format("/Amon/Menubar[@Id='{0}']", menuId));
            if (root == null || root.ChildNodes.Count < 1)
            {
                return false;
            }

            menuBar.Name = menuId;

            foreach (XmlNode node in root.ChildNodes)
            {
                ToolStripDropDownItem menu = createMenu(node, null);
                if (menu == null)
                {
                    continue;
                }
                menuBar.Items.Add(menu);
            }

            //string KEY_SKIN = "skin";
            //if (buttons.containsKey(KEY_SKIN))
            //{
            //    javax.swing.JMenu skin = (javax.swing.JMenu) buttons.get(KEY_SKIN);
            //    if (skin == null)
            //    {
            //        skin = new javax.swing.JMenu();
            //        menuBar.add(skin);
            //    }
            //    loadSkin(skin);
            //}
            return true;
        }

        public bool GetToolBar(string toolId, ToolStrip toolBar)
        {
            if (_Document == null || !CharUtil.IsValidate(toolId))
            {
                return false;
            }

            XmlNode root = _Document.SelectSingleNode(string.Format("/Amon/Toolbar[@Id='{0}']", toolId));
            if (root == null || root.ChildNodes.Count < 1)
            {
                return false;
            }

            toolBar.Name = toolId;
            foreach (XmlNode node in root.ChildNodes)
            {
                if ("Item" == node.Name)
                {
                    toolBar.Items.Add(createButton(node));
                    continue;
                }
                if ("Line" == node.Name)
                {
                    toolBar.Items.Add(new ToolStripSeparator());
                    continue;
                }
            }
            return true;
        }

        public bool GetPopMenu(string menuId, ContextMenuStrip menuPop)
        {
            if (!CharUtil.IsValidate(menuId) || _Document == null)
            {
                return false;
            }
            XmlNode root = _Document.SelectSingleNode(string.Format("/Amon/Popmenu[@Id='{0}']", menuId));
            if (root == null || root.ChildNodes.Count < 1)
            {
                return false;
            }

            menuPop.Name = menuId;

            foreach (XmlNode node in root.ChildNodes)
            {
                if ("menu" == node.Name)
                {
                    menuPop.Items.Add(createMenu(node, null));
                    continue;
                }
                if ("item" == node.Name)
                {
                    menuPop.Items.Add(createItem(node, null));
                    continue;
                }
                if ("seperator" == node.Name)
                {
                    menuPop.Items.Add(new ToolStripSeparator());
                    continue;
                }
            }
            return true;
        }

        public bool GetSubMenu(string partId, ToolStrip menu, IAction action)
        {
            if (_Document == null || !CharUtil.IsValidate(partId))
            {
                return false;
            }

            XmlNode root = _Document.SelectSingleNode(string.Format("/Amon/Submenu[@Id='{0}']", partId));
            if (root == null || root.ChildNodes.Count < 1)
            {
                return false;
            }

            foreach (XmlNode node in root.ChildNodes)
            {
                if ("menu" == node.Name)
                {
                    menu.Items.Add(createMenu(node, action));
                    continue;
                }
                if ("item" == node.Name)
                {
                    menu.Items.Add(createItem(node, action));
                    continue;
                }
                if ("seperator" == node.Name)
                {
                    menu.Items.Add(new ToolStripSeparator());
                    continue;
                }
            }
            return true;
        }

        public bool GetSubMenu(string partId, ToolStripDropDownItem menu, IAction action)
        {
            if (_Document == null || !CharUtil.IsValidate(partId))
            {
                return false;
            }

            XmlNode root = _Document.SelectSingleNode(string.Format("/Amon/Submenu[@Id='{0}']", partId));
            if (root == null || root.ChildNodes.Count < 1)
            {
                return false;
            }

            foreach (XmlNode node in root.ChildNodes)
            {
                if ("menu" == node.Name)
                {
                    menu.DropDownItems.Add(createMenu(node, action));
                    continue;
                }
                if ("item" == node.Name)
                {
                    menu.DropDownItems.Add(createItem(node, action));
                    continue;
                }
                if ("seperator" == node.Name)
                {
                    menu.DropDownItems.Add(new ToolStripSeparator());
                    continue;
                }
            }
            return true;
        }

        public bool GetStrokes(string strokesId)
        {
            if (_Document == null || !CharUtil.IsValidate(strokesId))
            {
                return false;
            }

            XmlNodeList list = _Document.SelectNodes(string.Format("/Amon/Strokes[@Id='{0}']/Stroke", strokesId));
            if (list == null || list.Count < 1)
            {
                return false;
            }
            foreach (XmlNode node in list)
            {
                processStrokes(node);
            }
            return true;
        }
        #endregion

        #region 对象初始化
        private ToolStripDropDownItem createMenu(XmlNode parent, IAction action)
        {
            ToolStripDropDownItem menu = new ToolStripMenuItem();
            string id = Attribute(parent, "Id", null);
            if (CharUtil.IsValidate(id))
            {
                _Items[id] = menu;
            }

            processText(parent, menu);
            processTips(parent, menu);
            processIcon(parent, menu);

            foreach (XmlNode node in parent.ChildNodes)
            {
                if ("Menu" == node.Name)
                {
                    menu.DropDownItems.Add(createMenu(node, action));
                    continue;
                }
                if ("Item" == node.Name)
                {
                    menu.DropDownItems.Add(createItem(node, action));
                    continue;
                }
                if ("Line" == node.Name)
                {
                    menu.DropDownItems.Add(new ToolStripSeparator());
                    continue;
                }
            }
            return menu;
        }

        private ToolStripItem createItem(XmlNode node, IAction action)
        {
            ToolStripItem item = processType(node);
            string id = Attribute(node, "Id", null);
            if (CharUtil.IsValidate(id))
            {
                _Items[id] = item;
            }

            processText(node, item);
            processTips(node, item);
            processIcon(node, item);
            processEnabled(node, item);
            processVisible(node, item);
            if (action == null)
            {
                processAction(node, item);
            }
            else
            {
                //item.addActionListener(action);
                //if (action is IAction)
                //{
                //    ((IAction) action).reInit(item, element.attributeValue("init"));
                //}
            }
            processCommand(node, item);
            processGroup(node, item);
            return item;
        }

        private ToolStripItem createButton(XmlNode node)
        {
            ToolStripButton button = new ToolStripButton();
            string id = Attribute(node, "Id", null);
            if (CharUtil.IsValidate(id))
            {
                _Items[id] = button;
            }

            processText(node, button);
            processTips(node, button);
            processIcon(node, button);
            processEnabled(node, button);
            processVisible(node, button);
            processGroup(node, button);
            processAction(node, button);
            processCommand(node, button);
            return button;
        }

        private IAction CreateAction(XmlNode node)
        {
            string id = Attribute(node, "Id", null);

            bool validate = CharUtil.IsValidate(id);
            IAction action = null;
            if (validate && _Actions.ContainsKey(id))
            {
                action = _Actions[id];
            }

            if (action == null)
            {
                string type = Attribute(node, "Class", null);
                if (string.IsNullOrWhiteSpace(type))
                {
                    return null;
                }

                string libId = Attribute(node, "LibId", "");
                if (!_Assemblys.ContainsKey(libId))
                {
                    libId = "";
                }
                Assembly assembly = _Assemblys[libId];

                try
                {
                    action = assembly.CreateInstance(type) as IAction;
                    if (action == null)
                    {
                        return null;
                    }
                    if (!string.IsNullOrWhiteSpace(id))
                    {
                        _Actions[id] = action;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            return action;
        }
        #endregion

        #region 皮肤初始化
        //    public void loadSkin(javax.swing.JMenu skinMenu)
        //    {
        //        java.io.File skinFile = new java.io.File(ConsEnv.DIR_SKIN);
        //        if (!skinFile.exists() || !skinFile.isDirectory() || !skinFile.canRead())
        //        {
        //            return;
        //        }

        //        loadLook(skinMenu);
        //        loadTheme(skinMenu);
        //        loadFeel(skinMenu);

        //        java.io.File[] files = skinFile.listFiles(new AmonFF("[^\\s]+[.ams]$", true));
        //        if (files != null && files.length > 0)
        //        {
        //            skinMenu.addSeparator();

        //            // 动态扩展风格
        //            java.util.Properties prop = new java.util.Properties();
        //            javax.swing.JCheckBoxMenuItem item;
        //            ButtonGroup group = new ButtonGroup();
        //            for (java.io.File ams : files)
        //            {
        //                try
        //                {
        //                    prop.load(new java.io.InputStreamReader(new java.io.FileInputStream(ams), ConsEnv.FILE_ENCODING));
        //                    item = new javax.swing.JCheckBoxMenuItem();
        //                    Bean.setText(item, getLang(prop, "text"));
        //                    Bean.setTips(item, getLang(prop, "tips"));
        //                    item.setSelected(userMdl.getSkin().equals(prop.getProperty("name")));
        //                    skinMenu.add(item);
        //                    group.add(item);
        //                    prop.clear();
        //                }
        //                catch (Exception exp)
        //                {
        //                    Logs.exception(exp);
        //                }
        //            }
        //        }

        //        skinMenu.addSeparator();

        //        javax.swing.JMenuItem moreSkin = new javax.swing.JMenuItem();
        //        Bean.setText(moreSkin, Lang.getLang(MproRes.P30F7642, "更多皮肤"));
        ////        Bean.setTips(moreSkin, Lang.getLang("", "tips"));
        //        moreSkin.setActionCommand(ConsEnv.HOMEPAGE + "mpwd/mpwd0100.aspx?sid=" + ConsEnv.VERSIONS);
        //        moreSkin.addActionListener(new MoreAction());
        //        skinMenu.add(moreSkin);
        //    }

        //    private void loadLook(javax.swing.JMenu skinMenu)
        //    {
        //        javax.swing.JMenu lookMenu = new javax.swing.JMenu();
        //        Bean.setText(lookMenu, Lang.getLang(MproRes.P30F763B, "外观"));
        //        skinMenu.add(lookMenu);

        //        java.io.File lookFile = new java.io.File(ConsEnv.DIR_SKIN, ConsEnv.DIR_LOOK);
        //        if (!lookFile.exists() || !lookFile.isDirectory() || !lookFile.canRead())
        //        {
        //            return;
        //        }

        //        javax.swing.JCheckBoxMenuItem item;
        //        string lookName = userMdl.getLook();
        //        LookAction action = new LookAction();
        //        action.setMproPtn((MproPtn) trayPtn.getMpwdPtn(AppView.mpro));
        //        ButtonGroup group = new ButtonGroup();

        //        // Java默认风格
        //        java.io.File defaultSkin = new java.io.File(lookFile, ConsEnv.SKIN_LOOK_DEF_DIR + '/' + ConsEnv.SKIN_LOOK_FILE);
        //        if (defaultSkin.exists() && defaultSkin.isFile() && defaultSkin.canRead())
        //        {
        //            item = new javax.swing.JCheckBoxMenuItem();
        //            item.addActionListener(action);
        //            Bean.setText(item, Lang.getLang(MproRes.P30F7632, "默认界面"));
        //            Bean.setTips(item, "");
        //            item.setActionCommand(ConsCfg.DEF_SKIN_LOOK_DEF + ".Default");
        //            item.setSelected(lookName.equals(ConsCfg.DEF_SKIN_LOOK_DEF));
        //            lookMenu.add(item);
        //            group.add(item.getActionCommand(), item);
        //        }

        //        // 系统默认风格
        //        java.io.File sytemSkin = new java.io.File(lookFile, ConsEnv.SKIN_LOOK_SYS_DIR + '/' + ConsEnv.SKIN_LOOK_FILE);
        //        if (sytemSkin.exists() && sytemSkin.isFile() && sytemSkin.canRead())
        //        {
        //            item = new javax.swing.JCheckBoxMenuItem();
        //            item.addActionListener(action);
        //            Bean.setText(item, Lang.getLang(MproRes.P30F7633, "系统界面"));
        //            Bean.setTips(item, "");
        //            item.setActionCommand(ConsCfg.DEF_SKIN_LOOK_SYS + ".System");
        //            item.setSelected(lookName.equals(ConsCfg.DEF_SKIN_LOOK_SYS));
        //            lookMenu.add(item);
        //            group.add(item.getActionCommand(), item);
        //        }

        //        java.io.File dirs[] = lookFile.listFiles(new AmonFF(true, ConsEnv.SKIN_LOOK_DEF_DIR, ConsEnv.SKIN_LOOK_SYS_DIR));
        //        if (dirs != null && dirs.length > 0)
        //        {
        //            lookMenu.addSeparator();
        //            string os = Util.isWindows() ? "win" : (Util.isMac() ? "mac" : "lin");

        //            for (java.io.File dir : dirs)
        //            {
        //                java.io.File aml = new java.io.File(dir, ConsEnv.SKIN_LOOK_FILE);
        //                if (!aml.exists() || !aml.isFile() || !aml.canRead())
        //                {
        //                    continue;
        //                }
        //                try
        //                {
        //                    Document doc = new SAXReader().read(new java.io.FileInputStream(aml));
        //                    if (doc == null)
        //                    {
        //                        continue;
        //                    }
        //                    XmlNode root = doc.getRootElement();
        //                    if (root == null)
        //                    {
        //                        continue;
        //                    }
        //                    XmlNode look = root.element("look");
        //                    if (look == null)
        //                    {
        //                        continue;
        //                    }
        //                    java.util.List<?> items = look.elements("item");
        //                    if (items == null || items.size() < 1)
        //                    {
        //                        continue;
        //                    }
        //                    if (items.size() == 1)
        //                    {
        //                        XmlNode element = look.element("item");

        //                        item = new javax.swing.JCheckBoxMenuItem();
        //                        item.addActionListener(action);
        //                        Bean.setText(item, getLang(element.attributeValue("text")));
        //                        Bean.setTips(item, getLang(element.attributeValue("tips")));
        //                        string id = dir.getName() + '.' + element.attributeValue("Id");
        //                        item.setSelected(lookName.equals(id));
        //                        item.setActionCommand(id);
        //                        lookMenu.add(item);
        //                        group.add(item.getActionCommand(), item);
        //                    }
        //                    else
        //                    {
        //                        string grpText = getLang(look.attributeValue("group"));
        //                        if (!com.magicpwd._util.CharUtil.IsValidate(grpText))
        //                        {
        //                            grpText = dir.getName();
        //                        }
        //                        javax.swing.JMenu subMenu = new javax.swing.JMenu();
        //                        Bean.setText(subMenu, grpText);
        //                        lookMenu.add(subMenu);

        //                        for (Object object : items)
        //                        {
        //                            if (!(object instanceof XmlNode))
        //                            {
        //                                continue;
        //                            }
        //                            XmlNode element = (XmlNode) object;
        //                            string platform = element.attributeValue("platform");
        //                            if (CharUtil.IsValidate(platform) && platform.toLowerCase().indexOf(os) < 0)
        //                            {
        //                                continue;
        //                            }

        //                            item = new javax.swing.JCheckBoxMenuItem();
        //                            item.addActionListener(action);
        //                            Bean.setText(item, getLang(element.attributeValue("text")));
        //                            Bean.setTips(item, getLang(element.attributeValue("tips")));
        //                            string id = dir.getName() + '.' + element.attributeValue("Id");
        //                            item.setSelected(lookName.equals(id));
        //                            item.setActionCommand(id);
        //                            subMenu.add(item);
        //                            group.add(item.getActionCommand(), item);
        //                        }
        //                    }
        //                }
        //                catch (Exception exp)
        //                {
        //                    Logs.exception(exp);
        //                }
        //            }
        //        }

        //        lookMenu.addSeparator();

        //        javax.swing.JMenuItem moreLook = new javax.swing.JMenuItem();
        //        Bean.setText(moreLook, Lang.getLang(MproRes.P30F763C, "更多外观"));
        ////        Bean.setTips(moreSkin, Lang.getLang("", "tips"));
        //        moreLook.setActionCommand(ConsEnv.HOMEPAGE + "mpwd/mpwd0101.aspx?sid=" + ConsEnv.VERSIONS);
        //        moreLook.addActionListener(new MoreAction());
        //        lookMenu.add(moreLook);
        //    }

        //    private void loadTheme(javax.swing.JMenu skinMenu)
        //    {
        //        javax.swing.JMenu themeMenu = new javax.swing.JMenu();
        //        Bean.setText(themeMenu, Lang.getLang(MproRes.P30F763D, "主题"));
        //        skinMenu.add(themeMenu);

        //        javax.swing.JCheckBoxMenuItem item;
        //        ThemeAction action = new ThemeAction();
        //        ButtonGroup group = new ButtonGroup();

        //        // Java默认风格
        ////        java.io.File defaultSkin = new java.io.File(lookFile, ConsEnv.SKIN_LOOK_DEFAULT + '/' + ConsEnv.SKIN_LOOK_FILE);
        ////        if (defaultSkin.exists() && defaultSkin.isFile() && defaultSkin.canRead())
        ////        {
        //        item = new javax.swing.JCheckBoxMenuItem();
        //        item.addActionListener(action);
        //        Bean.setText(item, Lang.getLang(MproRes.P30F7641, "默认主题"));
        //        Bean.setTips(item, "");
        //        item.setActionCommand(ConsCfg.DEF_SKIN_LOOK_DEF);
        //        item.setSelected(true);
        //        themeMenu.add(item);
        //        group.add(item.getActionCommand(), item);
        ////        }

        //        themeMenu.addSeparator();

        //        javax.swing.JMenuItem moreTheme = new javax.swing.JMenuItem();
        //        Bean.setText(moreTheme, Lang.getLang(MproRes.P30F763E, "更多主题"));
        ////        Bean.setTips(moreSkin, Lang.getLang("", "tips"));
        //        moreTheme.setActionCommand(ConsEnv.HOMEPAGE + "mpwd/mpwd0102.aspx?sid=" + ConsEnv.VERSIONS);
        //        moreTheme.addActionListener(new MoreAction());
        //        themeMenu.add(moreTheme);
        //    }

        //    private void loadFeel(javax.swing.JMenu skinMenu)
        //    {
        //        javax.swing.JMenu feelMenu = new javax.swing.JMenu();
        //        Bean.setText(feelMenu, Lang.getLang(MproRes.P30F763F, "图标"));
        //        skinMenu.add(feelMenu);

        //        java.io.File feelFile = new java.io.File(ConsEnv.DIR_SKIN, ConsEnv.DIR_FEEL);
        //        if (!feelFile.exists() || !feelFile.isDirectory() || !feelFile.canRead())
        //        {
        //            return;
        //        }

        //        java.io.File dirs[] = feelFile.listFiles(new AmonFF(true));
        //        if (dirs != null && dirs.length > 0)
        //        {
        //            feelMenu.addSeparator();

        //            javax.swing.JCheckBoxMenuItem item;
        //            string feelName = userMdl.getFeel();
        //            FeelAction action = new FeelAction();
        //            action.setMproPtn((MproPtn) trayPtn.getMpwdPtn(AppView.mpro));
        //            ButtonGroup group = new ButtonGroup();

        //            java.util.Properties prop = new java.util.Properties();
        //            java.io.InputStreamReader reader = null;
        //            for (java.io.File dir : dirs)
        //            {
        //                java.io.File amf = new java.io.File(dir, ConsEnv.SKIN_FEEL_FORM);
        //                if (!amf.exists() || !amf.isFile() || !amf.canRead())
        //                {
        //                    continue;
        //                }
        //                try
        //                {
        //                    reader = new java.io.InputStreamReader(new java.io.FileInputStream(amf), ConsEnv.FILE_ENCODING);
        //                    prop.load(reader);

        //                    item = new javax.swing.JCheckBoxMenuItem();
        //                    item.addActionListener(action);
        //                    Bean.setText(item, getLang(prop, "text"));
        //                    Bean.setTips(item, getLang(prop, "tips"));
        //                    string name = dir.getName();
        //                    item.setSelected(feelName.equals(name));
        //                    item.setActionCommand(name);
        //                    feelMenu.add(item);
        //                    group.add(name, item);

        //                    prop.clear();
        //                }
        //                catch (Exception exp)
        //                {
        //                    Logs.exception(exp);
        //                }
        //                finally
        //                {
        //                    Bean.closeReader(reader);
        //                }
        //            }
        //        }

        //        feelMenu.addSeparator();

        //        javax.swing.JMenuItem morefeel = new javax.swing.JMenuItem();
        //        Bean.setText(morefeel, Lang.getLang(MproRes.P30F7640, "更多风格"));
        ////        Bean.setTips(moreSkin, Lang.getLang("", "tips"));
        //        morefeel.setActionCommand(ConsEnv.HOMEPAGE + "mpwd/mpwd0103.aspx?sid=" + ConsEnv.VERSIONS);
        //        morefeel.addActionListener(new MoreAction());
        //        feelMenu.add(morefeel);
        //    }
        #endregion

        #region 数据初始化
        private ToolStripItem processType(XmlNode node)
        {
            string type = Attribute(node, "Type", "normal");
            if (type == "checkbox")
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.CheckOnClick = true;
                return item;
            }

            return new ToolStripMenuItem();
        }

        private ToolStripItem processText(XmlNode node, ToolStripItem button)
        {
            string text = Attribute(node, "Text", "");
            button.Text = string.IsNullOrEmpty(text) ? "..." : text;
            return button;
        }

        private ToolStripItem processTips(XmlNode node, ToolStripItem button)
        {
            string tips = Attribute(node, "Tips", "");
            button.ToolTipText = string.IsNullOrEmpty(tips) ? null : tips;
            return button;
        }

        private ToolStripItem processIcon(XmlNode node, ToolStripItem button)
        {
            string icon = Attribute(node, "Icon", "");
            //button.Image = null;
            return button;
        }

        private ToolStripItem processGroup(XmlNode node, ToolStripItem button)
        {
            string group = Attribute(node, "Group", "");
            if (!string.IsNullOrWhiteSpace(group))
            {
                ItemGroup bg;
                if (!_Groups.ContainsKey(group))
                {
                    bg = new ItemGroup();
                    _Groups[group] = bg;
                }
                else
                {
                    bg = _Groups[group];
                }
                bg.Add(button.Tag, button);
            }
            return button;
        }

        private ToolStripItem processEnabled(XmlNode node, ToolStripItem button)
        {
            string text = Attribute(node, "Enabled", "true");
            button.Enabled = "true" == text;
            return button;
        }

        private ToolStripItem processVisible(XmlNode node, ToolStripItem button)
        {
            string text = Attribute(node, "Visible", "true");
            button.Visible = "true" == text;
            return button;
        }

        private static ToolStripItem processCommand(XmlNode node, ToolStripItem button)
        {
            button.Tag = Attribute(node, "Command", null);
            return button;
        }

        private KeyStroke processStrokes(XmlNode node)
        {
            string key = Attribute(node, "Key", null);
            if (!CharUtil.IsValidate(key))
            {
                return null;
            }

            key = key.Replace("^", "Control").Replace("~", "Shift").Replace("#", "Alt").Replace("!", "Meta");
            key = Regex.Replace(key, "Ctrl", "Control", RegexOptions.IgnoreCase);
            KeyStroke stroke = new KeyStroke();
            if (!stroke.Decode(key))
            {
                return null;
            }
            stroke.Memo = Attribute(node, "Memo", "");
            _Strokes.Add(stroke);
            return stroke;
        }

        private ToolStripItem processAction(XmlNode parent, ToolStripItem button)
        {
            IAction action = null;

            string actionId = Attribute(parent, "ActionId", null);
            if (!string.IsNullOrWhiteSpace(actionId))
            {
                if (_Actions.ContainsKey(actionId))
                {
                    action = _Actions[actionId];
                    if (action != null)
                    {
                        button.Click += new EventHandler(action.EventHandler);
                    }
                }
                return button;
            }

            XmlNodeList list = parent.ChildNodes;
            if (list == null || list.Count < 1)
            {
                return button;
            }

            foreach (XmlNode node in list)
            {
                if (node.Name == "Action")
                {
                    action = CreateAction(node);
                    if (action != null)
                    {
                        button.Click += new EventHandler(action.EventHandler);
                    }
                    continue;
                }

                if (node.Name == "Stroke")
                {
                    KeyStroke stroke = processStrokes(node);
                    if (stroke != null)
                    {
                        stroke.Action = action;
                    }
                }
            }
            return button;
        }
        #endregion

        public bool isEnabled(string id)
        {
            return true;
        }

        public bool isVisible(string id)
        {
            return true;
        }

        private static string Attribute(XmlNode node, string name, string defValue)
        {
            XmlAttribute attr = node.Attributes[name];
            return attr != null ? attr.InnerText : defValue;
        }
    }
}