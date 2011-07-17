// JScript File
swfobject.embedSWF("/data/date/"+$X('hd_FlashObj').value,"dv_FlashObj","","","7","/data/expressInstall.swf");
$D().oncontextmenu=function(evt)
{
	if(!evt)
	{
		evt=$W().event;
	}
	evt.cancelBubble=true;
	evt.returnValue=false;
	return false;
}