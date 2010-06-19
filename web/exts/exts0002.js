// JScript 文件
function addFav()
{
    var conf = window.confirm('您当前的操作是将本页面添加到收藏夹，确认要继续么？');
    if (!conf)
    {
        return;
    }
    var ext = $E('hd_ExtsName').value;
    var cas = $E('hd_ExtsCase').value;

    return addFavorite('http://www.amonsoft.cn/exts/exts0001.aspx?exts=' + ext + '&case=' + cas, '后缀解析 - ' + ext, '')
}