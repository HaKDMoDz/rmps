/******************************************************************************
 * Javascript Document
 * iFormObj v2.0
 * http://www.amonsoft.cn/code/iFormObj/
 * Copyright (c) 2008 Amonsoft.cn
 ******************************************************************************/
if(!iFormObj)
{
    var iFormObj = new (function()
    {
        var THIS = this;
        var _DOC = document;
        var _WIN = window;
        var NAME = "iFormObj";

        /*上传页面参数*/
        var pup;
        /*页面回调函数*/
        var cbk;
        /*打开窗口引用*/
        var win;
        /*是否首次打开*/
        var opn;

        /**
         * 打开页面，并传递参数
         * u：要打开的页面地址
         * w：打开的页面宽度
         * h：打开的页面高度
         * p：向打开页面传递的参数
         * f：页面回调函数
         */
        THIS.open = function(u, w, h, p, f, o)
        {
            // 传入参数引用
            pup = p;
            cbk = f;

            if(_E(NAME + '_FORM') == null)
            {
                var div = _DOC.createElement('div');
                div.innerHTML = '<div id="' + NAME + '_FORM" onmouseup="iFormObj.focus();return false;" style="position:absolute;z-index:10000;top:0;left:0;width:1px;height:1px;background-color:#666666;-moz-opacity:0.7;filter:alpha(opacity=70);"></div>';
                _DOC.body.appendChild(div.firstChild);
            }

            var left = (screen.availWidth - w) / 2;
            var top = (screen.availHeight - h) / 2;
            if(win != null)
            {
                win.close();
            }
            win = window.open(u, NAME, 'menubar=0,location=0,status=yes,dialog=yes,modal=yes,scrollbars=1,resizable=1,width=' + w + ',height=' + h + ',left=' + left + ',top=' + top);
            win.focus();

            max();
            
            opn = true;
            win.window.onunload = winExit;
        };

        THIS.exit = function(adp, bOk)
        {
            min();
            if(win != null)
            {
                win.close();
                win = null;
            }
            if(bOk)
            {
                cbk(adp);
            }
        };

        THIS.param = function()
        {
            return pup;
        };

        THIS.focus = function(evt)
        {
            if(win == null || win.closed != false)
            {
                min();
                return;
            }
            if (navigator.appName.indexOf('icrosoft') < 0)
            {
                win.open().close();
            }
            win.focus();
        };
        
        function winExit(evt)
        {
            if(opn)
            {
                opn = false;
                return;
            }

            _WIN.iFormObj.exit('kkkkk',false);
            _WIN.focus();
        }

        /**
         * 后台DIV区域最小化
         */
        function min()
        {
            var df = _E(NAME + '_FORM');
            if(df != null)
            {
                df.style.width = "1px";
                df.style.height = "1px";
            }
        }
        
        /**
         * 后台DIV区域最大化
         */
        function max()
        {
            var df = _E(NAME + '_FORM');
            if(df != null)
            {
                var w = _DOC.body.scrollWidth;
                if(w < win.innerWidth)
                {
                    w = win.innerWidth + 20;
                }

                var h = _DOC.body.scrollHeight;
                if(h < win.innerHeight)
                {
                    h = win.innerHeight + 20;
                }

                df.style.width = w + 'px';
                df.style.height = h + 'px';
            }
        }
        
        function _E(id)
        {
            return _DOC.getElementById(id);
        }
    })();
}