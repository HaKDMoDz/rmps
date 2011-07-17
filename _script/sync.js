if(!net_amonsoft_load)
{
    var net_amonsoft_load=new(
        function()
        {
            /**对象自身*/
            var THIS=this;
            var _DOC=document;

            /**
             * 功能：加载指定的文件
             * 参数：u 需要被加载的文件
             *       t 回去文档类型，为NULL表示自动检测
             *       l 加载完成后的回调函数
             *       f 加载抵账后的回调函数
             * 返回：被调用函数的返回结果
             */
            THIS.Load=function(u,t,l,f)
            {
                if(!u)
                {
                    return false;
                }
                // 成功回调函数
                if(l)
                {
                    THIS.LoadedCallback=l;
                }
                // 失败回调函数
                if(f)
                {
                    THIS.FailedCallback=f;
                }

                // 判断该文件是否已经加载了
                if (THIS.IsLoaded(u))
                {
                    return THIS.LoadedCallback();
                }

                // 文件类型
                if(!t||t=='')
                {
                    t=THIS.GetType(u);
                }

                // 如果没有加载，动态创建
                var res={'js':['text/javascript','javascript'],'vbs':['text/vbscript','vbscript'],'css':['text/css','stylesheet']};
                var obj;
                if(t=='js'||t=='vbs')
                {
                    obj=_DOC.createElement('script');
                    obj.src=u;
                    obj.type=res[t][0];
                    obj.language=res[t][1];
                }
                else if(t=='css')
                {
                    obj=document.createElement('link');
                    obj.href=u;
                    obj.type=res[t][0];
                    obj.rel=res[t][1];
                }
                else
                {
                    THIS.FailedCallback();
                    return false;
                }

                // 将创建的对象插入到HEAD节点
                _DOC.getElementsByTagName('head')[0].appendChild(obj);
                if(obj.readyState)
                {
                    // IE
                    obj.onreadystatechange=function()
                    {
                        if (obj.readyState=='loaded')
                        {
                            obj.onreadystatechange=null;
                            THIS.LoadedCallback();
                        }
                    };
                }
                else
                {
                    // Others(Firefox, Safari, Chrome, Opera, and so on)
                    obj.onload=function()
                    {
                        THIS.LoadedCallback();
                    };
                }
                // 文件异步加载错误处理
                obj.onerror=function()
                {
                    _DOC.getElementsByTagName('head')[0].removeChild(obj);
                    THIS.FailedCallback();
                };
            };

            /**
             * 功能：判断是否已经加载了某文件
             * 参数：u 需要被检查的文件
             * 返回：返回是否已经加载了该文件
             */
            THIS.IsLoaded=function(u)
            {
                // 假设没有加载
                var l=false;
                // 得到文件的类型
                var t=THIS.GetType(u);
                if (t=='js'||t=='vbs')
                {
                    // 得到所有script对象集合
                    t=_DOC.getElementsByTagName('script');
                    // 依次判断每个script对象
                    for (var i=0;i<t.length;i+=1)
                    {
                        if (t[i].src&&t[i].src.indexOf(u)!=-1)
                        {
                            if (t[i].readyState=='loaded'||t[i].readyState=='complete')
                            {
                                l=true;
                                break;
                            }
                        }
                    }
                }
                else if (t=='css')
                {
                    // 得到所有link对象集合
                    t=_DOC.getElementsByTagName('link');
                    // 依次判断每个link对象
                    for(var i=0;i<t.length;i+=1)
                    {
                        if(t[i].href&&t[i].href.indexOf(u)!=-1)
                        {
                            if(t[i].readyState=='loaded'||t[i].readyState=='complete'||t[i].readyState=='interactive')
                            {
                                l=true;
                                break;
                            }
                        }
                    }
                }
                return l;
            };

            /**
             * 功能：得到文件的类型（即扩展名）
             * 参数：u 文件名
             * 返回：返回文件的类型
             */
            THIS.GetType=function(u)
            {
                var t='';
                var i=u.lastIndexOf('.');
                if(i!=-1)
                {
                    t=u.substr(i+1).toLowerCase();
                }
                return t;
            };

            /**
             * 功能：文件加载失败时执行的回调函数
             * 返回：（无）
             */
            THIS.FailedCallback=function()
            {
            };

            /**
             * 功能：文件加载完成时执行的回调函数
             * 返回：（无）
             */
            THIS.LoadedCallback=function()
            {
            };
        }
    )();
    document.write('<div id="Net_Amonsoft_NetHelper"></div>');
}