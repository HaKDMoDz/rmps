// JScript 文件
function checkNull()
{
    var reg;
    var txt;
    
    // 登录用户检测
    txt = $('TbName').value;
    if(txt==null || txt=='')
    {
        $('LbErrMsg').innerHTML = '请输入【登录用户】！';
        $('TrErrMsg').style.display = '';
        $('TbName').focus();
        return false;
    }
    reg = /^\w+[\w\d\.]*$/
    if(!reg.test(txt))
    {
        $('LbErrMsg').value = '您输入的【登录用户】不合法：登录用户仅能为大小写字母、下划线及英文点号！';
        $('TrErrMsg').style.display = '';
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
    
    // 登录口令检测
    txt = $('TbPass').value;
    if(txt==null || txt=='')
    {
        $('LbErrMsg').innerHTML = '请输入【登录口令】！';
        $('TrErrMsg').style.display = '';
        $('TbPass').focus();
        return false;
    }
    if(txt.length < 4)
    {
        $('LbErrMsg').innerHTML = '【登录口令】字符串长度不能小于 4 位！';
        $('TrErrMsg').style.display = '';
        $('TbPass').value='';
        $('TbPass').focus();
        return false;
    }
    
    if(txt != $('TbPass2').value)
    {
        $('LbErrMsg').innerHTML = '您两次输入的口令不一致，请重新输入！';
        $('TrErrMsg').style.display = '';
        $('TbPass').value='';
        $('TbPass').focus();
        $('TbPass2').value='';
        return false;
    }
    
    // 电子邮件检测
    txt = $('tf_UserMail').value;
    if(txt==null || txt.trim()=='')
    {
        $('LbErrMsg').innerHTML = '请输入【电子邮件】！';
        $('TrErrMsg').style.display = '';
        $('tf_UserMail').focus();
        return false;
    }
    reg = /^\w+[\w\.]*@\w+(\.[\w\.]+)+$/;
    if(!reg.test(txt))
    {
        $('LbErrMsg').innerHTML = '您输入的【电子邮件】格式不正确，正确格式为：someone@hostname.com！';
        $('TrErrMsg').style.display = '';
        $('tf_UserMail').focus();
        return false;
    }

    return true;
}