// JScript File
function checkInput()
{
    var text = $E('cb_P3010004');
    if(text.value == '')
    {
        alert('请选择国别信息！');
        text.focus();
        return false;
    }
}