// JScript File
function checkInput()
{
    var text = $E('cb_P301000C');
    if (text.value == '')
    {
        alert('请选择所属类别！');
        text.focus();
        return false;
    }
}