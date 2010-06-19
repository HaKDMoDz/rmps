// JScript 文件
///////////////////////////////////////////////////////////
// 全局变量
///////////////////////////////////////////////////////////
var last;
var sall;
var tabs;
var prev;

///////////////////////////////////////////////////////////
// 界面初始化
///////////////////////////////////////////////////////////
pageInit($E('hd_DataSize').value);

///////////////////////////////////////////////////////////
// 方法区域
///////////////////////////////////////////////////////////
function pageInit(size)
{
    if($E('hd_ErrMsg').value!='')
    {
        alert($E('hd_ErrMsg').value);
        $E('hd_ErrMsg').value='';
    }

    last=new Array(size);
    sall=new Array(size);
    tabs=new Array(size);
    for(i=0;i<size;i+=1)
    {
        last[i]='DV_BASE'+i;
        sall[i]=false;
        tabs[i]='TAB'+i+'0';
    }
}
$D().onkeypress=function(evt)
{
    if(!evt)
    {
        evt=$W().event;
    }
    if(evt.keyCode!=13)
    {
        return evt;
    }
    var src=$O(evt);
    if(src.id==_PRE+'tf_ExtsName')
    {
        $E('bt_ExtsName').click();
        return false;
    }
    return evt;
};
function wEnable(arg,tab,idx)
{
    sall[idx]=false;
    wDisable('none',idx);
    last[idx]=arg;
    $X(arg).style.display='';

    $X(tabs[idx]).className='TD_TAB_D';
    tabs[idx]=tab;
    $X(tabs[idx]).className='TD_TAB_S';
    prev='TD_TAB_S';

    return false;
}
function wEnableAll(idx)
{
    wDisable(sall[idx]==false ? '':'none',idx);
    sall[idx]=!sall[idx];
    if(sall[idx]==false)
    {
        $X(last[idx]).style.display='';
    }
    return false;
}
function wDisable(dis,idx)
{
    $X('DV_BASE'+idx).style.display=dis;
    $X('DV_DESP'+idx).style.display=dis;
    $X('DV_MIME'+idx).style.display=dis;
    $X('DV_PLAT'+idx).style.display=dis;
    $X('DV_DOCS'+idx).style.display=dis;
    $X('DV_CORP'+idx).style.display=dis;
    $X('DV_SOFT'+idx).style.display=dis;
    $X('DV_FILE'+idx).style.display=dis;
    $X('DV_ASOC'+idx).style.display=dis;
    $X('DV_IDIO'+idx).style.display=dis;
}
function wActive(wtd)
{
    prev=wtd.className;
    wtd.className='TD_TAB_E';
}
function wRemove(wtd)
{
    wtd.className=prev;
}
function doUpdate(sid)
{
    var num=window.prompt("请输入步增量（默认步增量为10）：","10");
    if(num==null)
    {
        return false;
    }
    if(num=='')
    {
        num='10';
    }
    $E('hd_StepSize').value=num;
    $E('hd_SoftHash').value=sid;
    return true;
}
function doDelete(sid)
{
    if(!$W().confirm('确认要删除此数据吗，此操作将不可恢复？'))
    {
        return false;
    }

    $E('hd_SoftHash').value=sid;
    return true;
}
function addShortFav()
{
}
function addFav()
{
    var conf=window.confirm('您当前的操作是将本页面添加到收藏夹，确认要继续么？');
    if(!conf)
    {
        return;
    }
    var ext=$E('tf_ExtsName').value;
    var cas=0;
    if($E('rb_ExtsUppr').checked)
    {
        cas=1;
    }
    else if($E('rb_ExtsLowr').checked)
    {
        cas=2;
    }
    else if($E('rb_ExtsBlur').checked)
    {
        cas=3;
    }

    return addFavorite('http://amonsoft.cn/exts/exts0001.aspx?exts='+ext+'&case='+cas,'后缀解析 - '+ext,'');
}
function chgExts()
{
    if($E('ck_ExtsFile').checked)
    {
        $E('tf_ExtsName').style.display='none';
        $E('tf_ExtsFile').style.display='';
        $E('tf_ExtsFile').focus();
    }
    else
    {
        $E('tf_ExtsName').style.display='';
        $E('tf_ExtsFile').style.display='none';
        $E('tf_ExtsName').focus();
    }
}
function chkExts()
{
    if(!checkExts($E('tf_ExtsName')))
    {
        return false;
    }

    var caze=0;
    for(var i=0;i<4;i+=1)
    {
        if($E('rb_ExtsCase_'+i).checked)
        {
            caze=i;
            break;
        }
    }

    if($E('ck_ExtsAjax').checked)
    {
        return true;
    }
    window.location.href=_URI+'/exts/exts0001.aspx?exts='+$E('tf_ExtsName').value+'&case='+caze;
    return false;
}