// JScript 文件
function checkNull()
{
    var reg;
    var txt;

    txt = $E('tf_UserName').value;
    if(txt==null || txt=='')
    {
        $E('lb_ErrMsg').innerHTML = '请输入【登录用户】！';
        $E('tf_UserName').focus();
        return false;
    }
    reg = /^\w+[\w\d\.]*$/
    if(!reg.test(txt))
    {
        $E('lb_ErrMsg').value = '您输入的【登录用户】不合法：登录用户仅能为大小写字母、下划线及英文点号！';
        $E('tf_UserName').focus();
        return false;
    }
    if(txt.length < 4 || txt.length > 32)
    {
        $E('lb_ErrMsg').innerHTML = '【登录用户】字符串长度应在 4 到 32 个字符之间！';
        $E('tr_ErrMsg').style.display = '';
        $E('tf_UserName').focus();
        return false;
    }
    
    txt = $X('pf_UserPwds').value;
    if(txt==null || txt=='')
    {
        $E('lb_ErrMsg').innerHTML = '请输入【登录口令】！';
        $E('pf_UserPwds').focus();
        return false;
    }
    if(txt.length < 4)
    {
        $E('lb_ErrMsg').innerHTML = '【登录口令】字符串长度不能小于 4 位！';
        $E('pf_UserPwds').value='';
        $E('pf_UserPwds').focus();
        return false;
    }
    return true;
}