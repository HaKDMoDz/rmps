// JScript 文件
swfobject.embedSWF("/_dat/date/"+$E('hd_FlashObj').value,"dv_FlashObj","460","345","6","/_dat/expressInstall.swf");
function openFull()
{
    $W().open('date0003.aspx?sid='+$E('hd_FlashObj').value,'','resizable=yes');
    return false;
}