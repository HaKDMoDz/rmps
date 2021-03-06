using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.E;
using Me.Amon.M;

namespace Me.Amon.Uc
{
    public class XmlMenu<T>
    {
        public const string XML_MENU_MENU = "Menu";
        public const string XML_MENU_ITEM = "Item";
        public const string XML_MENU_LINE = "Line";

        private string _Error;
        private XmlDocument _Document;
        private Dictionary<string, ToolStripMenuItem> _MenuItems;
        private Dictionary<string, ToolStripButton> _ToolItems;
        private Dictionary<string, ItemGroup> _Groups;
        private Dictionary<string, IAction<T>> _Actions;
        private Dictionary<string, Assembly> _Assemblys;
        private List<Stroke<T>> _Strokes;
        private List<Hotkey<T>> _Hotkeys;
        private T _IApp;
        private IViewModel _ViewModel;

        #region 构造函数
        public XmlMenu(T iApp, IViewModel viewModel)
        {
            _IApp = iApp;
            _ViewModel = viewModel;

            _MenuItems = new Dictionary<string, ToolStripMenuItem>();
            _ToolItems = new Dictionary<string, ToolStripButton>();
            _Groups = new Dictionary<string, ItemGroup>();
            _Actions = new Dictionary<string, IAction<T>>();
            _Strokes = new List<Stroke<T>>();
            _Hotkeys = new List<Hotkey<T>>();
        }
        #endregion

        #region 数据加载
        public bool Load(string path)
        {
            _Error = null;
            _Strokes.Clear();
            _Hotkeys.Clear();

            _Document = new XmlDocument();
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
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
            _Hotkeys.Clear();

            _Document.Load(reader);
            return Load();
        }

        private bool Load()
        {
            LoadLib();
            LoadIcon();
            LoadAction();

            return true;
        }

        private bool LoadLib()
        {
            _Assemblys = new Dictionary<string, Assembly>();
            _Assemblys[""] = Assembly.GetExecutingAssembly();

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
                    if (string.IsNullOrWhiteSpace(file))
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
                    if (!string.IsNullOrWhiteSpace(id))
                    {
                        _Assemblys[id] = assembly;
                    }
                }
                return true;
            }
            catch (Exception exp)
            {
                _Error = exp.Message;
                return false;
            }
        }

        private bool LoadIcon()
        {
            var list = _Document.SelectNodes("/Amon/Icons/Icon");
            if (list == null || list.Count < 1)
            {
                return true;
            }

            foreach (XmlNode node in list)
            {
                string id = Attribute(node, "Id", "");
                string path = Attribute(node, "Path", "");
                _ViewModel.GetImage(id, path);
            }

            return true;
        }

        private bool LoadAction()
        {
            var list = _Document.SelectNodes("/Amon/Actions/Action");
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
                    IAction<T> action = assembly.CreateInstance(type) as IAction<T>;
                    if (action != null)
                    {
                        action.IApp = _IApp;
                        if (!string.IsNullOrWhiteSpace(id))
                        {
                            _Actions[id] = action;
                        }
                    }
                }
                catch (Exception ex)
                {
                    _Error = ex.Message;
                    return false;
                }
            }
            return false;
        }
        #endregion

        #region 公共函数
        /// <summary>
        /// 处理异常
        /// </summary>
        public string Error
        {
            get
            {
                return _Error;
            }
        }

        public List<Hotkey<T>> Hotkeys { get { return _Hotkeys; } }

        public List<Stroke<T>> Strokes { get { return _Strokes; } }

        public ToolStripMenuItem GetMenuItem(string id)
        {
            return _MenuItems.ContainsKey(id) ? _MenuItems[id] : null;
        }

        public ToolStripButton GetToolItem(string id)
        {
            return _ToolItems.ContainsKey(id) ? _ToolItems[id] : null;
        }

        public IAction<T> GetAction(string id)
        {
            return _Actions.ContainsKey(id) ? _Actions[id] : null;
        }

        public ItemGroup GetGroup(string id)
        {
            return _Groups.ContainsKey(id) ? _Groups[id] : null;
        }

        public void SetGroupEnabled(string id, bool enabled)
        {
            if (_Groups.ContainsKey(id))
            {
                _Groups[id].Enabled(enabled);
            }
        }

        public void SetGroupVisible(string id, bool visible)
        {
            if (_Groups.ContainsKey(id))
            {
                _Groups[id].Visible(visible);
            }
        }

        public void SetButtonEnabled(string id, bool enabled)
        {
            if (_ToolItems.ContainsKey(id))
            {
                _ToolItems[id].Enabled = enabled;
            }
        }

        public void SetButtonVisible(string id, bool visible)
        {
            if (_ToolItems.ContainsKey(id))
            {
                _ToolItems[id].Visible = visible;
            }
        }

        public void SetItemEnabled(string id, bool enabled)
        {
            if (_MenuItems.ContainsKey(id))
            {
                _MenuItems[id].Enabled = enabled;
            }
        }

        public void SetItemVisible(string id, bool visible)
        {
            if (_MenuItems.ContainsKey(id))
            {
                _MenuItems[id].Visible = visible;
            }
        }
        #endregion

        #region 组件初始化
        public bool GetMenuBar(string menuId, MenuStrip menuBar)
        {
            if (string.IsNullOrWhiteSpace(menuId) || _Document == null)
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
            if (_Document == null || string.IsNullOrWhiteSpace(toolId))
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
                if (XML_MENU_ITEM == node.Name)
                {
                    toolBar.Items.Add(createButton(node));
                    continue;
                }
                if (XML_MENU_LINE == node.Name)
                {
                    toolBar.Items.Add(createLine(node));
                    continue;
                }
            }
            return true;
        }

        public bool GetPopMenu(string menuId, ContextMenuStrip menuPop)
        {
            if (string.IsNullOrWhiteSpace(menuId) || _Document == null)
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
                if (XML_MENU_MENU == node.Name)
                {
                    menuPop.Items.Add(createMenu(node, null));
                    continue;
                }
                if (XML_MENU_ITEM == node.Name)
                {
                    menuPop.Items.Add(createItem(node, null));
                    continue;
                }
                if (XML_MENU_LINE == node.Name)
                {
                    menuPop.Items.Add(createLine(node));
                    continue;
                }
            }
            return true;
        }

        public bool GetSubMenu(string partId, ToolStrip menu, IAction<T> action)
        {
            if (_Document == null || string.IsNullOrWhiteSpace(partId))
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
                if (XML_MENU_MENU == node.Name)
                {
                    menu.Items.Add(createMenu(node, action));
                    continue;
                }
                if (XML_MENU_ITEM == node.Name)
                {
                    menu.Items.Add(createItem(node, action));
                    continue;
                }
                if (XML_MENU_LINE == node.Name)
                {
                    menu.Items.Add(createLine(node));
                    continue;
                }
            }
            return true;
        }

        public bool GetSubMenu(string partId, ToolStripDropDownItem menu, IAction<T> action)
        {
            if (_Document == null || string.IsNullOrWhiteSpace(partId))
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
                if (XML_MENU_MENU == node.Name)
                {
                    menu.DropDownItems.Add(createMenu(node, action));
                    continue;
                }
                if (XML_MENU_ITEM == node.Name)
                {
                    menu.DropDownItems.Add(createItem(node, action));
                    continue;
                }
                if (XML_MENU_LINE == node.Name)
                {
                    menu.DropDownItems.Add(createLine(node));
                    continue;
                }
            }
            return true;
        }

        public bool GetStrokes(string strokesId, Form form)
        {
            if (_Document == null || string.IsNullOrWhiteSpace(strokesId))
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
                Stroke<T> stroke = processStrokes(node);
                if (stroke == null)
                {
                    continue;
                }
                string actionId = Attribute(node, "ActionId", null);
                if (!string.IsNullOrWhiteSpace(actionId) && _Actions.ContainsKey(actionId))
                {
                    stroke.Action = _Actions[actionId];
                }
            }

            if (form != null)
            {
                form.KeyPreview = true;
                form.KeyDown += new KeyEventHandler(FormKeyDown);
            }
            return true;
        }

        public bool GetHotkeys(string hotkeysId, Form form)
        {
            if (_Document == null || string.IsNullOrWhiteSpace(hotkeysId))
            {
                return false;
            }

            XmlNodeList list = _Document.SelectNodes(string.Format("/Amon/Hotkeys[@Id='{0}']/Hotkey", hotkeysId));
            if (list == null || list.Count < 1)
            {
                return false;
            }

            int handle = form.Handle.ToInt32();
            foreach (XmlNode node in list)
            {
                Hotkey<T> hotkey = processHotkeys(node);
                if (hotkey == null)
                {
                    continue;
                }
                hotkey.Id = ++handle;
                string actionId = Attribute(node, "ActionId", null);
                if (!string.IsNullOrWhiteSpace(actionId) && _Actions.ContainsKey(actionId))
                {
                    hotkey.Action = _Actions[actionId];
                }
            }
            return true;
        }
        #endregion

        #region 对象初始化
        private ToolStripMenuItem createMenu(XmlNode parent, IAction<T> action)
        {
            ToolStripMenuItem menu = new ToolStripMenuItem();
            string id = Attribute(parent, "Id", null);
            if (!string.IsNullOrWhiteSpace(id))
            {
                menu.Name = id;
                _MenuItems[id] = menu;
            }

            processText(parent, menu);
            processTips(parent, menu);
            processIcon(parent, menu);
            processEnabled(parent, menu);
            processVisible(parent, menu);
            processGroup(parent, menu);

            foreach (XmlNode node in parent.ChildNodes)
            {
                if (XML_MENU_MENU == node.Name)
                {
                    menu.DropDownItems.Add(createMenu(node, action));
                    continue;
                }
                if (XML_MENU_ITEM == node.Name)
                {
                    menu.DropDownItems.Add(createItem(node, action));
                    continue;
                }
                if (XML_MENU_LINE == node.Name)
                {
                    menu.DropDownItems.Add(createLine(node));
                    continue;
                }
            }
            return menu;
        }

        private ToolStripMenuItem createItem(XmlNode node, IAction<T> action)
        {
            ToolStripMenuItem item = processMenuItem(node);
            string id = Attribute(node, "Id", null);
            if (!string.IsNullOrWhiteSpace(id))
            {
                item.Name = id;
                _MenuItems[id] = item;
            }

            processText(node, item);
            processTips(node, item);
            processIcon(node, item);
            processEnabled(node, item);
            processVisible(node, item);
            processCommand(node, item);
            if (action == null)
            {
                action = processAction(node, item);
            }
            if (action != null)
            {
                action.Add(item, _ViewModel);
            }
            processGroup(node, item);

            XmlNodeList list = node.SelectNodes("Stroke");
            if (list != null && list.Count > 0)
            {
                foreach (XmlNode temp in list)
                {
                    if (temp == null)
                    {
                        continue;
                    }
                    Stroke<T> stroke = processStrokes(temp);
                    if (stroke != null)
                    {
                        stroke.Action = action;
                        item.ShortcutKeyDisplayString = stroke.ToString();
                    }
                }
            }
            return item;
        }

        private ToolStripButton createButton(XmlNode node)
        {
            ToolStripButton button = processButton(node);
            string id = Attribute(node, "Id", null);
            if (!string.IsNullOrWhiteSpace(id))
            {
                button.Name = id;
                _ToolItems[id] = button;
            }

            processText(node, button);
            processTips(node, button);
            processIcon(node, button);
            processEnabled(node, button);
            processVisible(node, button);
            processCommand(node, button);
            //processGroup(node, button);
            IAction<T> action = processAction(node, button);
            if (action != null)
            {
                action.Add(button, _ViewModel);
            }
            return button;
        }

        private ToolStripSeparator createLine(XmlNode node)
        {
            ToolStripSeparator line = new ToolStripSeparator();
            string id = Attribute(node, "Id", null);
            if (!string.IsNullOrWhiteSpace(id))
            {
                line.Name = id;
            }
            processGroup(node, line);
            return line;
        }

        private IAction<T> CreateAction(XmlNode node)
        {
            string id = Attribute(node, "Id", null);

            bool validate = !string.IsNullOrWhiteSpace(id);
            IAction<T> action = null;
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
                    action = assembly.CreateInstance(type) as IAction<T>;
                    if (action == null)
                    {
                        return null;
                    }
                    action.IApp = _IApp;
                    if (!string.IsNullOrWhiteSpace(id))
                    {
                        _Actions[id] = action;
                    }
                }
                catch (Exception)
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
        //                    java.util.List<?> items = look.elements(XML_MENU_ITEM);
        //                    if (items == null || items.size() < 1)
        //                    {
        //                        continue;
        //                    }
        //                    if (items.size() == 1)
        //                    {
        //                        XmlNode element = look.element(XML_MENU_ITEM);

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
        //                        if (!string.IsNullOrWhiteSpace(grpText))
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
        //                            if (!string.IsNullOrWhiteSpace(platform) && platform.toLowerCase().indexOf(os) < 0)
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
        private ToolStripMenuItem processMenuItem(XmlNode node)
        {
            string type = Attribute(node, "Type", "normal");
            if (type == "toggle")
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.CheckOnClick = true;
                return item;
            }

            return new ToolStripMenuItem();
        }

        private ToolStripButton processButton(XmlNode node)
        {
            ToolStripButton item;
            string type = Attribute(node, "Type", "normal");
            if (type == "toggle")
            {
                item = new ToolStripButton();
                item.DisplayStyle = ToolStripItemDisplayStyle.Image;
                item.CheckOnClick = true;
                return item;
            }

            item = new ToolStripButton();
            item.DisplayStyle = ToolStripItemDisplayStyle.Image;
            return item;
        }

        private static ToolStripItem processText(XmlNode node, ToolStripItem button)
        {
            string text = Attribute(node, "Text", "");
            text = text.Replace('@', '&');
            button.Text = string.IsNullOrEmpty(text) ? "..." : text;
            return button;
        }

        private static ToolStripItem processTips(XmlNode node, ToolStripItem button)
        {
            string tips = Attribute(node, "Tips", "");
            button.ToolTipText = string.IsNullOrEmpty(tips) ? null : tips;
            return button;
        }

        private ToolStripItem processIcon(XmlNode parent, ToolStripItem item)
        {
            XmlNode node = parent.SelectSingleNode("Icon");
            if (node == null)
            {
                return item;
            }

            string path = Attribute(node, "Path", "");
            if (!string.IsNullOrWhiteSpace(path))
            {
                if (path.ToLower().StartsWith("var:"))
                {
                    item.Image = _ViewModel.GetImage(path.Substring(4));
                }
                else
                {
                    string id = Attribute(node, "id", "");
                    item.Image = _ViewModel.GetImage(id, path);
                }
            }
            return item;
        }

        private ToolStripItem processGroup(XmlNode node, ToolStripItem item)
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
                bg.Add(item.Name, item);
            }
            return item;
        }

        private static ToolStripItem processEnabled(XmlNode node, ToolStripItem button)
        {
            string text = Attribute(node, "Enabled", "true");
            button.Enabled = "true" == text;
            return button;
        }

        private static ToolStripItem processVisible(XmlNode node, ToolStripItem button)
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

        private Hotkey<T> processHotkeys(XmlNode node)
        {
            string key = Attribute(node, "Key", null);
            if (string.IsNullOrWhiteSpace(key))
            {
                return null;
            }

            key = key.Replace("^", "Ctrl").Replace("+", "Shift").Replace("%", "Alt").Replace("!", "Meta");
            key = Regex.Replace(key, "Control", "Ctrl", RegexOptions.IgnoreCase);
            Hotkey<T> hotkeys = new Hotkey<T>();
            if (!hotkeys.Decode(key))
            {
                return null;
            }
            hotkeys.Memo = Attribute(node, "Memo", "");
            hotkeys.Command = Attribute(node, "Command", null);
            _Hotkeys.Add(hotkeys);
            return hotkeys;
        }

        private Stroke<T> processStrokes(XmlNode node)
        {
            string key = Attribute(node, "Key", null);
            if (string.IsNullOrWhiteSpace(key))
            {
                return null;
            }

            key = key.Replace("^", "Ctrl").Replace("+", "Shift").Replace("%", "Alt").Replace("!", "Meta");
            key = Regex.Replace(key, "Control", "Ctrl", RegexOptions.IgnoreCase);
            Stroke<T> stroke = new Stroke<T>();
            if (!stroke.Decode(key))
            {
                return null;
            }
            stroke.Memo = Attribute(node, "Memo", "");
            stroke.Command = Attribute(node, "Command", null);
            _Strokes.Add(stroke);
            return stroke;
        }

        private IAction<T> processAction(XmlNode parent, ToolStripItem item)
        {
            IAction<T> action = null;

            string actionId = Attribute(parent, "ActionId", null);
            if (!string.IsNullOrWhiteSpace(actionId) && _Actions.ContainsKey(actionId))
            {
                action = _Actions[actionId];
            }
            if (action == null)
            {
                XmlNode node = parent.SelectSingleNode("Action");
                if (node != null)
                {
                    action = CreateAction(node);
                }
            }
            if (action != null)
            {
                item.Click += new EventHandler(action.EventHandler);
            }
            return action;
        }
        #endregion

        #region 私有函数
        private static string Attribute(XmlNode node, string name, string defValue)
        {
            XmlAttribute attr = node.Attributes[name];
            return attr != null ? attr.InnerText : defValue;
        }

        private void FormKeyDown(object sender, KeyEventArgs e)
        {
            foreach (Stroke<T> stroke in _Strokes)
            {
                if (stroke.Action == null ||
                    e.Control ^ stroke.Control ||
                    e.Shift ^ stroke.Shift ||
                    e.Alt ^ stroke.Alt ||
                    e.KeyCode != stroke.Code)
                {
                    continue;
                }

                stroke.Action.EventHandler(stroke, null);
                e.Handled = true;
                break;
            }
        }
        #endregion
    }
}