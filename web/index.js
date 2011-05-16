$(document).ready(function(){
    $(".jRating").jRating({
     rateMax:5,
     type:'big',
     phpPath:'misc/misc0002.ashx',
     smallStarsPath:'_jquery/images/small.png',
     bigStarsPath:'_jquery/images/stars.png',
     onSuccess : function(){
	    jSuccess('Success : your rate has been saved :)',{
		  HorizontalPosition:'center',
		  VerticalPosition:'top'
		});
	  },
	  onError : function(){
	    jError('Error : please retry');
	  }
   });
});
function ShareThis(web)
{
    var title=encodeURI('阿木e居');
    var url=encodeURIComponent(window.location.href);
    var shareUrl;
    if('weibo'==web)
    {
        shareUrl='http://v.t.sina.com.cn/share/share.php?title='+title+'&url='+url+'&rcontent=';
    }
    else if('t.qq'==web)
    {
        shareUrl='http://v.t.qq.com/share/share.php?title='+title+'&url='+url;
    }
    else if('t.163'==web)
    {
        shareUrl='http://t.163.com/article/user/checkLogin.do?link=http://blog.163.com/&source='+ encodeURIComponent('网易博客')+ '&info='+title+' '+url;
    }
    else if('t.sohu'==web)
    {
        shareUrl="http://bai.sohu.com/share/blank/addbutton.do?from=tudou&link="+url+"&title="+title;
    }
    else if('douban'==web)
    {
        shareUrl="http://www.douban.com/recommend/?url="+url+"&title="+title;
    }
    else if('renren'==web)
    {
        shareUrl="http://share.xiaonei.com/share/buttonshare.do?link="+url+"&title="+title;
    }
    else if('kaixin'==web)
    {
        shareUrl="http://www.kaixin001.com/repaste/share.php?rtitle="+title+"&rurl="+url+"&rcontent="+encodeURIComponent(tt);
    }
    if(shareUrl)
    {
        if(!window.open(shareUrl))
        {
            location.href=shareUrl
        }
    }
}