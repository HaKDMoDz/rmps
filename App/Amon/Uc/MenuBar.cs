using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Util;

namespace Me.Amon.Uc
{
    public interface IEventHandler
    {
        void EventHandler(object sender, EventArgs e);
    }

    public class ButtonGroup
    {
        public void Add(object obj, ToolStripItem item)
        {
        }
    }

    public class MenuBar
    {
        private XmlDocument document;
        private Dictionary<string, ToolStripItem> buttons;
        private Dictionary<string, IEventHandler> actions;
        private Dictionary<string, ButtonGroup> groups;

        public MenuBar()
        {
            buttons = new Dictionary<string, ToolStripItem>();
            actions = new Dictionary<string, IEventHandler>();
            groups = new Dictionary<string, ButtonGroup>();
        }

        public bool Load(string path)
        {
            StreamReader reader = new StreamReader(path);
            bool isOk = Load(reader);
            reader.Close();

            return isOk;
        }

        public bool Load(TextReader reader)
        {
            document = new XmlDocument();
            document.Load(reader);
            return document != null;
        }

        public ToolStripItem GetButton(string id)
        {
            return buttons[id];
        }

        public IEventHandler GetAction(string id)
        {
            return actions[id];
        }

        public ButtonGroup GetGroup(string id)
        {
            return groups[id];
        }

        #region 组件初始化
        public bool GetMenuBar(string menuId, MenuStrip menuBar)
        {
            if (!CharUtil.IsValidate(menuId) || document == null)
            {
                return false;
            }
            XmlNode root = document.SelectSingleNode(string.Format("/Amon/Menubar[@id='{0}']", menuId));
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
            if (document == null || !CharUtil.IsValidate(toolId))
            {
                return false;
            }

            XmlNode root = document.SelectSingleNode(string.Format("/Amon/Toolbar[@id='{0}']", toolId));
            if (root == null || root.ChildNodes.Count < 1)
            {
                return false;
            }

            toolBar.Name = toolId;
            foreach (XmlNode node in root.ChildNodes)
            {
                if ("item" == node.Name)
                {
                    toolBar.Items.Add(createButton(node));
                    continue;
                }
                if ("seperator" == node.Name)
                {
                    toolBar.Items.Add(new ToolStripSeparator());
                    continue;
                }
            }
            return true;
        }

        public bool GetPopMenu(string menuId, ContextMenuStrip menuPop)
        {
            if (!CharUtil.IsValidate(menuId) || document == null)
            {
                return false;
            }
            XmlNode root = document.SelectSingleNode(string.Format("/Amon/Popmenu[@id='{0}']", menuId));
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

        public bool GetSubMenu(string partId, ToolStrip menu, IEventHandler action)
        {
            if (document == null || !CharUtil.IsValidate(partId))
            {
                return false;
            }

            XmlNode root = document.SelectSingleNode(string.Format("/Amon/Submenu[@id='{0}']", partId));
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

        public bool GetSubMenu(string partId, ToolStripDropDownItem menu, IEventHandler action)
        {
            if (!CharUtil.IsValidate(partId) || document == null)
            {
                return false;
            }

            XmlNode root = document.SelectSingleNode(string.Format("/Amon/Submenu[@id='{0}']", partId));
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
            if (!CharUtil.IsValidate(strokesId) || document == null)
            {
                return false;
            }

            XmlNode root = document.SelectSingleNode(string.Format("/Amon/Strokes[@id='{0}']", strokesId));
            if (root == null || root.ChildNodes.Count < 1)
            {
                return false;
            }
            processAction(root, null);
            return true;
        }
        #endregion

        #region 对象初始化
        private ToolStripDropDownItem createMenu(XmlNode parent, IEventHandler action)
        {
            ToolStripDropDownItem menu = new ToolStripMenuItem();
            string id = parent.Attributes["id"].Value;
            if (CharUtil.IsValidate(id))
            {
                buttons[id] = menu;
            }

            processText(parent, menu);
            processTips(parent, menu);
            processIcon(parent, menu);

            foreach (XmlNode node in parent.ChildNodes)
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
            return menu;
        }

        private ToolStripItem createItem(XmlNode node, IEventHandler action)
        {
            ToolStripItem item = processType(node);
            string id = node.Attributes["id"].Value;
            if (CharUtil.IsValidate(id))
            {
                buttons[id] = item;
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

            string id = node.Attributes["id"].InnerText;
            if (CharUtil.IsValidate(id))
            {
                buttons[id] = button;
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
        //                        string id = dir.getName() + '.' + element.attributeValue("id");
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
        //                            string id = dir.getName() + '.' + element.attributeValue("id");
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
            string type = node.Attributes["type"].InnerText;
            if (type == "normal")
            {
                return new ToolStripMenuItem();
            }

            return null;
        }

        private ToolStripItem processText(XmlNode node, ToolStripItem button)
        {
            string vText = node.Attributes["text"].Value;
            string dText = node.Attributes["text-def"].InnerText;
            if (dText == null)
            {
                dText = vText;
            }
            if (vText != null)
            {
                button.Text = vText.Length > 0 ? vText : "...";
            }
            return button;
        }

        private ToolStripItem processTips(XmlNode node, ToolStripItem button)
        {
            string vTips = node.Attributes["tips"].InnerText;
            string dTips = node.Attributes["tips-def"].InnerText;
            if (dTips == null)
            {
                dTips = vTips;
            }
            button.Text = string.IsNullOrEmpty(vTips) ? null : vTips;
            return button;
        }

        private ToolStripItem processIcon(XmlNode node, ToolStripItem button)
        {
            string image = node.Attributes["image"].InnerText;
            if (CharUtil.IsValidate(image))
            {
                //button.Image = createIcon(temp);
            }
            return button;
        }

        private ToolStripItem processGroup(XmlNode node, ToolStripItem button)
        {
            string group = node.Attributes["group"].InnerText;
            if (CharUtil.IsValidate(group))
            {
                ButtonGroup bg;
                if (!groups.ContainsKey(group))
                {
                    bg = new ButtonGroup();
                    groups[group] = bg;
                }
                else
                {
                    bg = groups[group];
                }
                bg.Add(button.Tag, button);
            }
            return button;
        }

        private ToolStripItem processEnabled(XmlNode node, ToolStripItem button)
        {
            string text = node.Attributes["enabled"].InnerText;
            if (CharUtil.IsValidate(text))
            {
                button.Enabled = "true" == text;
            }
            return button;
        }

        private ToolStripItem processVisible(XmlNode node, ToolStripItem button)
        {
            string text = node.Attributes["visible"].InnerText;
            if (CharUtil.IsValidate(text))
            {
                button.Visible = "true" == text;
            }
            return button;
        }

        private static ToolStripItem processCommand(XmlNode node, ToolStripItem button)
        {
            string command = node.Attributes["command"].InnerText;
            if (CharUtil.IsValidate(command))
            {
                button.Tag = command;
            }
            return button;
        }

        //private static ToolStripMenuItem processStrokes(XmlNode element, ToolStripMenuItem button, IMenuEventHandler action, javax.swing.JComponent component)
        //{
        //    java.util.List list = element.elements("stroke");
        //    if (list == null || list.size() < 1)
        //    {
        //        return button;
        //    }


        //    for (int i = 0, j = list.size(); i < j; i += 1)
        //    {
        //        string temp = ((XmlNode) list.get(i)).attributeValue("key");
        //        if (CharUtil.IsValidate(temp))
        //        {
        //            temp = temp.toUpperCase().replaceAll("~|SHIFT", "shift").replaceAll("\\^|CONTROL|CTRL", "control").replaceAll("#|ALT", "alt").replaceAll("!|META", "meta").replaceAll("[^-=`;',./\\[\\]a-zA-Z0-9]+", " ").trim();
        //            javax.swing.KeyStroke stroke = javax.swing.KeyStroke.getKeyStroke(temp);
        //            if (component != null)
        //            {
        //                Bean.registerKeyStrokeAction(component, stroke, action, temp, javax.swing.JComponent.WHEN_IN_FOCUSED_WINDOW);
        //            }
        //            if (button != null && i == 0 && (button instanceof javax.swing.JMenuItem))
        //            {
        //                ((javax.swing.JMenuItem) button).setAccelerator(stroke);
        //            }
        //        }
        //    }
        //    return button;
        //}

        private ToolStripItem processAction(XmlNode parent, ToolStripItem button)
        {
            XmlNodeList list = parent.SelectNodes("action");
            if (list == null || list.Count < 1)
            {
                return button;
            }
            string btnInit = parent.Attributes["init"].InnerText;

            foreach (XmlNode node in list)
            {
                string name = parent.Attributes["id"].InnerText;
                bool validate = CharUtil.IsValidate(name);
                IEventHandler action = validate ? actions[name] : null;
                if (action == null)
                {
                    string type = parent.Attributes["class"].InnerText;
                    if (CharUtil.IsValidate(type))
                    {
                        try
                        {
                        }
                        catch (Exception ex)
                        {
                            Main.ShowError(ex);
                        }
                    }
                }
                if (button != null)
                {
                    button.Click += new EventHandler(action.EventHandler);
                }
                //action.reInit(button, btnInit);
                //processStrokes(element, button, action, component);
                processReference(parent, button, action);
            }
            return button;
        }

        private ToolStripItem processReference(XmlNode element, ToolStripItem button, IEventHandler action)
        {
            if (button == null)
            {
                return button;
            }
            XmlNodeList list = element.SelectNodes("property");
            if (list == null || list.Count < 1)
            {
                return button;
            }

            string name;
            string refId;
            foreach (XmlNode node in list)
            {
                // 处理属性
                name = node.Attributes["name"].InnerText;
                if (!CharUtil.IsValidate(name))
                {
                    continue;
                }

                // 处理引用
                refId = node.Attributes["ref-id"].InnerText;
                if (!CharUtil.IsValidate(refId))
                {
                    continue;
                }

                // 引用对象
                action = actions[refId];
                if (action == null)
                {
                    continue;
                }

                try
                {
                    //java.lang.reflect.Method method = button.getAction().getClass().getDeclaredMethod("set" + Char.lUpper(name), java.net.URL.class);
                    //if (method != null)
                    //{
                    //    method.invoke(button.getAction(), action);
                    //}
                }
                catch (Exception exp)
                {
                    Main.LogInfo(exp.Message);
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
    }
}
