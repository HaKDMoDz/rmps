// JScript 文件
function chgExts()
{
    if($E('ck_ExtsFile').checked)
    {
        $E('tf_ExtsName').style.display='none';
        $E('tf_ExtsFile').style.display='';
        $E('tf_ExtsFile').focus();
    }
    else
    {
        $E('tf_ExtsName').style.display='';
        $E('tf_ExtsFile').style.display='none';
        $E('tf_ExtsName').focus();
    }
}
function chkExts()
{
    if(!checkExts($E('tf_ExtsName')))
    {
        return false;
    }

    var caze=0;
    if($E('rb_ExtsUppr').checked)
    {
        caze=1;
    }
    else if($E('rb_ExtsLowr').checked)
    {
        caze=2;
    }
    else if($E('rb_ExtsBlur').checked)
    {
        caze=3;
    }

    window.location.href=_URI+'/exts/exts0001.aspx?exts='+$E('tf_ExtsName').value+'&case='+caze+'&ajax='+($E('ck_ExtsAjax').checked?'1':'0');
    return false;
}
function myGears()
{
    GG('exts','http://amonsoft.cn/tool/tool1301.aspx?view=1','Extparse','后缀解析，为您提供更为详细的文件扩展名信息！');
    return false;
}