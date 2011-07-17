// JScript 文件
function checkNull()
{
    var reg;
    var txt;

    // 现有口令检测
    txt = $E('pf_OldPwds').value;
    if(txt==null || txt=='')
    {
        $E('lb_ErrMsg').innerHTML = '请输入【现有口令】！';
        $E('tr_ErrMsg').style.display = '';
        $E('pf_OldPwds').focus();
        return false;
    }
    if(txt.length < 4)
    {
        $E('lb_ErrMsg').innerHTML = '【现有口令】字符串长度不能小于 4 位！';
        $E('tr_ErrMsg').style.display = '';
        $E('pf_OldPwds').value='';
        $E('pf_OldPwds').focus();
        return false;
    }
    
    // 新登录口令检测
    txt = $E('pf_NewPwds').value;
    if(txt==null || txt=='')
    {
        $E('lb_ErrMsg').innerHTML = '请输入【新登录口令】！';
        $E('tr_ErrMsg').style.display = '';
        $E('pf_NewPwds').focus();
        return false;
    }
    if(txt.length < 4)
    {
        $E('lb_ErrMsg').innerHTML = '【新登录口令】字符串长度不能小于 4 位！';
        $E('tr_ErrMsg').style.display = '';
        $E('pf_NewPwds').value='';
        $E('pf_NewPwds').focus();
        return false;
    }
    
    if(txt != $E('pf_FrmPwds').value)
    {
        $E('lb_ErrMsg').innerHTML = '您两次输入的口令不一致，请重新输入！';
        $E('tr_ErrMsg').style.display = '';
        $E('pf_NewPwds').value='';
        $E('pf_NewPwds').focus();
        $E('pf_FrmPwds').value='';
        return false;
    }
}