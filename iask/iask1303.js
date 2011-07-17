// JScript File
function checkNull()
{
    var obj = $E('tf_Char');
    if(obj.value == null || obj.value == '')
    {
        alert('请输入您要查询的字符数据！');
        obj.focus();
        return false;
    }
    return true;
}
function chgStatus(obj)
{
    var v = obj.value;
    var b = (v=='1200'||v=='1201'||v=='12000'||v=='12001'||v=='65000'||v=='65001');
    if(!b)
    {
        $E('rb_Char').checked = true;
    }
    $E('rb_Numb').disabled = !b;
}