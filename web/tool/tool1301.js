// JScript 文件
$D().onkeypress = function(evt)
{
    if(!evt)
    {
        evt = $W().event;
    }
    if (evt.keyCode != 13)
    {
        return evt.keyCode;
    }
    var src = $O(evt);
    if (src.id == _PRE + 'q')
    {
        $E('s').click();
    }
    return false;
};
var tabi = 0;
function showTabs(idx)
{
    if (tabi != idx)
    {
        $X('tr_Exts' + tabi).style.display = 'none';
        $X('hl_Exts' + tabi).style.color = '#000000';
        tabi = idx;
        $X('tr_Exts' + tabi).style.display = '';
        $X('hl_Exts' + tabi).style.color = '#FF0000';
    }
    return false;
}
function addFav()
{
    var conf = window.confirm('您当前的操作是将本页面添加到收藏夹，确认要继续么？');
    if (!conf)
    {
        return;
    }
    var ext = $E('hd_ExtsName').value;
    var cas = $E('hd_ExtsCase').value;

    return addFavorite('http://amonsoft.cn/tool/tool1301.aspx?exts=' + ext + '&case=' + cas, '后缀解析 - ' + ext, '');
}
var size = eval($E('hd_DataSize').value);
var last = new Array(size);
var sall = new Array(size);
var tabs = new Array(size);
var prev;
for(i = 0;i < size; i += 1)
{
    last[i] = 'DV_EXTS' + i;
    sall[i] = false;
    tabs[i] = 'TAB' + i + '0';
}
function wEnable(arg, tab, idx)
{
    sall[idx] = false;
    wDisable('none', idx);
    last[idx] = arg;
    $X(arg).style.display='';

    $X(tabs[idx]).className='TD_TAB_D';
    tabs[idx] = tab;
    $X(tabs[idx]).className='TD_TAB_S';
    prev = 'TD_TAB_S';

    return false;
}
function wDisable(dis, idx)
{
    $X('DV_EXTS' + idx).style.display=dis;
    $X('DV_DESP' + idx).style.display=dis;
    $X('DV_MIME' + idx).style.display=dis;
    $X('DV_PLAT' + idx).style.display=dis;
    $X('DV_DOCS' + idx).style.display=dis;
    $X('DV_CORP' + idx).style.display=dis;
    $X('DV_SOFT' + idx).style.display=dis;
    $X('DV_FILE' + idx).style.display=dis;
    $X('DV_ASOC' + idx).style.display=dis;
    $X('DV_IDIO' + idx).style.display=dis;
}
function wActive(wtd)
{
    prev = wtd.className;
    wtd.className='TD_TAB_E';
}
function wRemove(wtd)
{
    wtd.className=prev;
}
function checkNull()
{
    var text = $E('tf_ExtsName');
    var exts = text.value;
    if(exts == null)
    {
        alert('后缀名称不能为空！');
        text.focus();
        return false;
    }

    exts = exts.trim();
    if(exts == '')
    {
        alert('后缀名称不能为空！');
        text.value = exts;
        text.focus();
        return false;
    }
    
    exts = exts.ltrimc('\\.', '.');
    if(exts == '.')
    {
        alert('您输入的后缀不是一个合适的字符串，请重新输入！');
        text.value = exts;
        text.focus();
        return false;
    }
    
    text.value = exts;
    return true;
}