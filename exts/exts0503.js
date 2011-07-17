// JScript 文件
function checkNull()
{
    var c = $E('cb_P301F103');
    var t = c.value;
    if (t == null || t == '')
    {
        alert('“语言选项”不能为空！');
        c.focus();
        return false;
    }
    t = t.replace(/(^\s*)|(\s*$)/g, "");
    /*if (t == '' || t == '0')
    {
        alert('“语言选项”不能为空！');
        c.value = t;
        c.focus();
        return false;
    }*/
    
    c = $E('tf_P301F104');
    t = c.value;
    if (t == null || t == '')
    {
        alert('“MIMI名称”不能为空！');
        c.focus();
        return false;
    }
    t = t.replace(/(^\s*)|(\s*$)/g, "");
    if (t == '' || t == '0')
    {
        alert('“MIMI名称”不能为空！');
        c.value = t;
        c.focus();
        return false;
    }
    
    return true;
}
function viewLink()
{
    $A($E('tf_P3010107').value);
}