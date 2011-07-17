// JScript File
function checkInput()
{
    var text = $E('cb_P3010005');
    if (text.value == '')
    {
        alert('请选择公司信息！');
        text.focus();
        return false;
    }
}