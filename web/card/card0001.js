// JScript File
var img;
/**
 * 改变卡片
 */
function chgIcon(val)
{
    $X('tr_UserCard').style.display='none';
    if(val)
    {
        var uri='http://amonsoft.net/card/card0001.ashx?sid='+val+'&uri='+$E('hd_UserCode').value;
        //var uri='http://localhost:5606/web/card/card0001.ashx?sid='+val+'&uri='+$E('hd_UserCode').value;

        if(!img)
        {
            img=new Image();
            img.onload=function()
            {
                $X('tr_UserCard').style.display='';
                $X('im_UserCard').src=img.src;
            }
        }
        img.src=uri;
    }
    
    genHtm(uri);
    genUbb(uri);
}
/**
 * HTML代码
 */
function genHtm(val)
{
    $X('ta_HtmCode').value=val?'<a href="http://amonsoft.net/card/" title="Amon卡片"><img src="'+val+'" alt="Amon卡片" /></a>':'';
}
/**
 * UBB代码
 */
function genUbb(val)
{
    $X('ta_UbbCode').value=val?'[url=http://amonsoft.net/card/][img]'+val+'[/img][/url]':'';
}
function doEdit()
{
    $W().location.href='card0002.aspx?sid='+$E('cb_CardList').value;
    return false;
}
chgIcon($E('cb_CardList').value);