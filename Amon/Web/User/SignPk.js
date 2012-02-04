// JScript 文件
function checkNull()
{
    var reg;
    var txt;

    // 现有口令检测
    txt = $('TbOldPass').value;
    if(txt==null || txt=='')
    {
        $('LbErrMsg').innerHTML = '请输入【现有口令】！';
        $('TrErrMsg').style.display = '';
        $('TbOldPass').focus();
        return false;
    }
    if(txt.length < 4)
    {
        $('LbErrMsg').innerHTML = '【现有口令】字符串长度不能小于 4 位！';
        $('TrErrMsg').style.display = '';
        $('TbOldPass').value='';
        $('TbOldPass').focus();
        return false;
    }
    
    // 新登录口令检测
    txt = $('TbPass1').value;
    if(txt==null || txt=='')
    {
        $('LbErrMsg').innerHTML = '请输入【新登录口令】！';
        $('TrErrMsg').style.display = '';
        $('TbNewPass1').focus();
        return false;
    }
    if(txt.length < 4)
    {
        $('LbErrMsg').innerHTML = '【新登录口令】字符串长度不能小于 4 位！';
        $('TrErrMsg').style.display = '';
        $('TbNewPass1').value = '';
        $('TbNewPass1').focus();
        return false;
    }
    
    if(txt != $('TbPass2').value)
    {
        $('LbErrMsg').innerHTML = '您两次输入的口令不一致，请重新输入！';
        $('TrErrMsg').style.display = '';
        $('TbNewPass1').value='';
        $('TbNewPass1').focus();
        $('TbNewPass2').value='';
        return false;
    }
}