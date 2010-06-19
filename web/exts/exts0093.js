/**
 * MIME数据删除
 */
function initView()
{
    $("#ul_P3010704").sortable({placeholder: 'ui-state-highlight'});
}
function remove()
{
    return confirm('确认要删除此数据吗？');
}
function checkNull()
{
    var cb=$E('cb_P3010704');
    var si=cb.value;
    if (!si)
    {
        alert('请选择您要添加的软件！');
        cb.focus();
        return false;
    }

    if((','+$E('hd_P3010704').value+',').indexOf(','+si+',')>=0)
    {
        if($W().confirm('您要添加的备选软件已存在，要更新此数据吗？'))
        {
            $E('hd_IsUpdate').value='1';
            return true;
        }
        cb.focus();
        return false;
    }
    return true;
}
function saveData()
{
    var arr=$("#ul_P3010704").sortable('toArray');
    if(arr&&arr.join)
    {
        $E('hd_P3010704').value=arr.join(',');
        return true;
    }
    return false;
}
initView();