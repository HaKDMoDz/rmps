// JScript 文件
function showTips()
{
    switch($X('cb_TypeList').value)
    {
        case '0':
            $X('dv_TypeInfo').innerHTML = '清除现有图标数据，此操作不可恢复！';
            $X('tr_Inner').style.display='none';
            break;
        case '1':
            $X('dv_TypeInfo').innerHTML = '目前仅支持PNG、JPG、GIF等格式图像，可以连续上传多张图像！';
            $X('tr_Inner').style.display='none';
            break;
        case '2':
            $X('dv_TypeInfo').innerHTML = 'SVG矢量图像文件上传！';
            $X('tr_Inner').style.display='none';
            break;
        case '3':
            $X('dv_TypeInfo').innerHTML = '支持从 ico、icl、dll、exe、ocx、cpl、src 等资源文件中提取图像信息！';
            $X('tr_Inner').style.display='none';
            break;
        case '4':
            $X('dv_TypeInfo').innerHTML = '选择系统已有图标数据，您需要指定目标路径！';
            $X('tr_Inner').style.display='';
            break;
        default:
            $X('dv_TypeInfo').innerHTML = '&nbsp;';
            $X('tr_Inner').style.display='none';
            break;
    }
}
function checkNull()
{
    var t = $X('cb_TypeList');
    var p = t.value;
    if (p == '')
    {
        alert('请选择您要进行的操作类型！');
        t.focus();
        return false;
    }
    if (p == '0')
    {
        if($W().confirm('确认要删除现有图标么？'))
        {
            var arr = new Array();
            arr['sid'] = '0';
            var fun=$W().parent.saveIcon;
            if(fun)
            {
                fun('','','-1');
            }
        }
        return false;
    }
    if(p == '4')
    {
        if($X('ck_Load').checked)
        {
            if($X('rb_Img').checked)
            {
                $X('hd_IconPath').value='img';
            }
            if($X('rb_Res').checked)
            {
                $X('hd_IconPath').value='res';
            }
        }
    }
    return true;
}
function changeStat(obj)
{
    $X('rb_Img').disabled=!obj.checked;
    $X('rb_Res').disabled=!obj.checked;
}