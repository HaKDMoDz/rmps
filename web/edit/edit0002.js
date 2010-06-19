// JScript 文件
var errMsg = $E('hd_ErrMsg').value;
if(errMsg!=null && errMsg!='')
{
    alert(errMsg);
    $E('hd_ErrMsg').value='';
}

function editSubmit()
{
    editor.data();
    
    var obj = $E('ck_OverRide');
    if(obj && obj.checked)
    {
        return $W().confirm('此操作将会覆盖服务器上的现有文件，并且不可恢复，确认要执行此操作么？');
    }
    return true;
}
function editPrompt()
{
    var url = $E('tf_FilePath').value;
    if(url == null)
    {
        alert('请输入一个合法的链接地址，如：“http://www.amonsoft.cn/”。');
        $E('tf_FilePath').focus();
        return false;
    }
    url = url.trim();
    if (url == '' || url == 'http://')
    {
        alert('请输入一个合法的链接地址，如：“http://www.amonsoft.cn/”。');
        $E('tf_FilePath').focus();
        return false;
    }
    return true;
}