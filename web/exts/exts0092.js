// JScript File
function initView()
{
    $("#ul_P3010603").sortable({placeholder: 'ui-state-highlight'});
	//$("#ul_P3010603").disableSelection();
}
/**
 * 添加MIME类型
 */
function append()
{
    window.location=_PRE+'/exts/exts0503.aspx?uri='+escape(_PRE+'/exts/exts0092.aspx?sid='+$E('hd_P3010602').value);
}
/**
 * MIME类型快速定位
 */
function choose()
{
    $('#dv_P3010603').dialog({resizable:false,width:300,modal:true});
    $X('tf_P3010603').focus();
    return false;
}
/**
 * 显示定位结果
 */
function locate()
{
    var tf=$X('tf_P3010603');
    var mt=tf.value;
    if(!mt)
    {
        alert('请输入您要查询的MIME类型！');
        tf.focus();
        return false;
    }

    mt=mt.trim();
    if(!mt)
    {
        alert('请输入一个合适的MIME类型！');
        tf.focus();
        return false;
    }
    
    tf=$E('cb_P3010603');
    var mv='0';
    var op=tf.options;
    for(var i=0;i<op.length;i+=1)
    {
        if(op.item(i).text==mt)
        {
            mv=op.item(i).value;
            break;
        }
    }
    
    if(mv=='0')
    {
        alert('不存在您输入的MIME类型，请确认您输入的是否正确！');
        tf.focus();
        return false;
    }

    $('#dv_P3010603').dialog('close');
    tf.value=mv;
    $E('ta_P3010604').focus();
}
/**
 * 关闭快速定位对话框
 */
function cancel()
{
    $('#dv_P3010603').dialog('close');
}
/**
 * MIME数据删除
 */
function remove()
{
    return confirm('确认要删除此数据吗？');
}
/**
 *
 */
function checkNull()
{
    var cb=$E('cb_P3010603');
    var si=cb.value;
    if (!si)
    {
        alert('请选择您要添加的MIME类型！');
        cb.focus();
        return false;
    }
    
    if((','+$E('hd_P3010603').value+',').indexOf(','+si+',')>=0)
    {
        if($W().confirm('您要添加的MIME类型已存在，确定要更新此数据么？'))
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
    var arr=$("#ul_P3010603").sortable('toArray');
    if(arr&&arr.join)
    {
        $E('hd_P3010603').value=arr.join(',');
        return true;
    }
    return false;
}
initView();