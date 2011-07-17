// JScript File
function checkInput()
{
    var obj=$X('tf_Size');
    var val=obj.value;
    var reg=/^\d{3,4}$/;
    if(!reg.test(val)||val<300)
    {
        obj.value='300';
    }
    showScript();
}
function showScript()
{
    var txt='<script type="text/javascript" charset="utf-8" src="http://amonsoft.net/srch/srch0001.ashx?sid='+$E('hd_UserCode').value+'"></script>\n';
    txt+='<script type="text/javascript">\n    iSearcher.init(\''+$X('tf_Sdiv').value+'\','+$X('tf_Size').value+');\n</script>';
    $X('ta_Code').value=txt;
}
function preview()
{
    var fun=$X('ta_Code').value;
    if(fun.trim()!='')
    {
        var win = $W().open('', 'amonsoft');
        win.document.write('<html xmlns="http://www.w3.org/1999/xhtml"><head><meta http-equiv="Content-Type" content="text/html; charset=utf-8" /><title>功能预览</title><style type="text/css">BODY,A{font-family: "宋体", simsun, Arial, "Times New Roman";font-size: 9pt;}</style></head><body><div>如果您没有查看到运行效果，请尝试刷新一次本页面！<div><br /><br /></body></html>'+fun);
    }
}
showScript();