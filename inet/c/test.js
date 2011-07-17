if(!syncLoad)
{
    var syncLoad=new(
        function()
        {
            /**对象自身*/
            var THIS=this;
            var _DOC=document;

            /**
             * 功能：加载指定的文件
             * 参数：u 需要被加载的文件
             * 参数：t 回去文档类型，为NULL表示自动检测
             * 参数：l 加载完成后的回调函数
             * 参数：f 加载抵账后的回调函数
             * 返回：（无）
             */
            THIS.Load=function(u,t,l,f)
            {
                if(!u)
                {
                    return false;
                }
                // 回调函数
                if(l)
                {
                    THIS.LoadedCallback=l;
                }
                if(f)
                {
                    THIS.FailedCallback=f;
                }

                //判断该文件是否已经加载了
                if (THIS.IsLoaded(u))
                {
                    return THIS.LoadedCallback();
                }

                //文件类型
                if(!t||t=='')
                {
                    t=THIS.GetSrcType(u);
                }

                //如果没有加载，动态创建
                var res={'js':['text/javascript','javascript'],'vbs':['text/vbscript','vbscript'],'css':['text/css','stylesheet']};
                //动态创建的对象
                var obj;
                if(t=="js"||t=="vbs")
                {
                    obj=_DOC.createElement("script");
                    obj.src=u;
                    obj.type=res[t][0];
                    obj.language=res[t][1];
                }
                else if(t=="css")
                {
                    obj=document.createElement("link");
                    obj.href=u;
                    obj.type=res[t][0];
                    obj.rel=res[t][1];
                }
                else
                {
                    THIS.FailedCallback();
                    return false;
                }

                //将创建的对象插入到HEAD节中
                _DOC.getElementsByTagName("head")[0].appendChild(obj);
                if(obj.readyState)
                {
                    obj.onreadystatechange=function()
                    {
                        if (obj.readyState=="loaded")//||obj.readyState=="complete")
                        {
                            obj.onreadystatechange=null;
                            THIS.LoadedCallback();
                        }
                    };
                }
                else
                {
                    // Others: Firefox, Safari, Chrome, and Opera
                    obj.onload=function()
                    {
                        THIS.LoadedCallback();
                    };
                }
                //加载过程中发生错误引发的事件
                obj.onerror=function()
                {
                    _DOC.getElementsByTagName("head")[0].removeChild(obj);
                    THIS.FailedCallback();
                };
            };

            /**
             * 功能：判断是否已经加载了某文件
             * 参数：u——需要被检查的文件
             * 返回：返回是否已经加载了该文件
             */
            THIS.IsLoaded=function(u)
            {
                //假设没有加载
                var isLoaded = false;
                //得到文件的类型
                var type = THIS.GetSrcType(u);
                //用于循环的索引
                if (type == "js" || type == "vbs")
                {
                    //得到所有的脚本对象集合
                    var scripts = document.getElementsByTagName("script");
                    //依次判断每个script对象
                    for (var i=0;i<scripts.length;i+=1)
                    {
                        if (scripts[i].src&&scripts[i].src.indexOf(u)!=-1)
                        {
                            if (scripts[i].readyState=="loaded"||scripts[i].readyState=="complete")
                            {
                                isLoaded=true;
                                break;
                            }
                        }
                    }
                }
                else if (type=="css")
                {
                    //得到所有的link对象集合
                    var links=document.getElementsByTagName("link");
                    //依次判断每个link对象
                    for(var i=0;i<links.length;i+=1)
                    {
                        if(links[i].href&&links[i].href.indexOf(u)!=-1)
                        {
                            if(links[i].readyState=="loaded"||links[i].readyState=="complete"||links[i].readyState=="interactive")
                            {
                                isLoaded = true;
                                break;
                            }
                        }
                    }
                }
                return isLoaded;
            };

            /**
             * 功能：得到文件的类型（即扩展名）
             * 参数：u——文件名
             * 返回：返回文件的类型
             */
            THIS.GetSrcType=function(u)
            {
                var type="";
                var lastIndex=u.lastIndexOf(".");
                if(lastIndex!=-1)
                {
                    type=u.substr(lastIndex + 1).toLowerCase();
                }
                return type;
            };

            /**
             * 功能：当文件加载失败时执行的回调函数
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