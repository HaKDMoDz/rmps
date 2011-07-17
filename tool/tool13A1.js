// JScript File
var inited=false;
function initView()
{
    if(!inited)
    {
        iNetHelper.init('date', 'menu', 'yyyy-MM-dd', 160, 120, _PRE + 'tf_CurrDate', 'im_CurrDate');
        inited=true;
    }
}
function addFav()
{
    return addFavorite('http://amonsoft.cn/tool/tool13A1.aspx', '节目预告', '');
}