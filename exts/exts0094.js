// JScript 文件
function initView()
{
    $("#ul_P3010803").sortable({placeholder: 'ui-state-highlight'});
	//$("#ul_P3010803").disableSelection();
}
/**
 * MIME数据删除
 */
function remove()
{
    return confirm('确认要删除此数据吗？');
}
function checkNull()
{
    var cb=$E('cb_P3010803');
    var si=cb.value;
    if (!si)
    {
        alert('请选择您要添加的MIME类型！');
        cb.focus();
        return false;
    }
    
    if((','+$E('hd_P3010803').value+',').indexOf(','+si+',')>=0)
    {
        if($W().confirm('您要添加的操作平台已存在，要更新此数据么？'))
        {
            $E('hd_IsUpdate').value = '1';
            return true;
        }
        cb.focus();
        return false;
    }
    return true;
}
function saveData()
{
    var arr=$("#ul_P3010803").sortable('toArray');
    if(arr&&arr.join)
    {
        $E('hd_P3010803').value=arr.join(',');
        return true;
    }
    return false;
}
initView();