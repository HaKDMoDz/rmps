// JScript 文件
function checkNull()
{
    var reg;
    var txt;

    txt = $('#TbName').value;
    if(txt==null || txt=='')
    {
        $('#LbErrMsg').innerHTML = '请输入【登录用户】！';
        $('#TbName').focus();
        return false;
    }
    reg = /^\w+[\w\d\.]*$/;
    if(!reg.test(txt))
    {
        $('LbErrMsg').value = '您输入的【登录用户】不合法：登录用户仅能为大小写字母、下划线及英文点号！';
        $('TbName').focus();
        return false;
    }
    if(txt.length < 4 || txt.length > 32)
    {
        $('LbErrMsg').innerHTML = '【登录用户】字符串长度应在 4 到 32 个字符之间！';
        $('TrErrMsg').style.display = '';
        $('TbName').focus();
        return false;
    }
    
    txt = $('TbPass').value;
    if(txt==null || txt=='')
    {
        $('LbErrMsg').innerHTML = '请输入【登录口令】！';
        $('TbPass').focus();
        return false;
    }
    if(txt.length < 4)
    {
        $('LbErrMsg').innerHTML = '【登录口令】字符串长度不能小于 4 位！';
        $('TbPass').value='';
        $('TbPass').focus();
        return false;
    }
    return true;
}