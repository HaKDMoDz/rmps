// JScript 文件
function viewPlat(pid)
{
	if(!pid || pid.length != 16)
	{
		return false;
	}
	window.open('plat/r_'+pid+'.png');
	return false;
}