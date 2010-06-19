// JScript File
function checkInput()
{
    var text = $E('cb_P301000F');
    if (text.value == '')
    {
        alert('请选择人员信息！');
        text.focus();
        return false;
    }
}