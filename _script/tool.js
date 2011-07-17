// JScript File
$D().oncontextmenu = function(evt)
{
	if(!evt)
	{
		evt = $W().event;
	}
	evt.cancelBubble = true;
	evt.returnValue = false;
	return false;
};
$W().onload=$W().onresize=function(evt)
{
    var obj=$X('ToolView');
    obj.style.height=($P()[1]-90)+'px';
    obj.style.display='';
    $X('LoadView').style.display='none';
};