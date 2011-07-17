// JScript 文件
function wim()
{
    if(navigator.userAgent.match(/Safari/))
    {
        s_options = "resizable=yes ,width=300 ,height=600 ,directories=no,titlebar=no,scrollbars=no,status=no,menubar=no,toolbar=no,location=no";
    }
    else
    {
        s_options = "resizable=yes ,width=300 ,height=600 ,directories=no,titlebar=no,scrollbars=no,status=no,menubar=no,toolbar=no,location=0";
    }
    window.open("http://o.aolcdn.com/aim/gromit/icq2go/gm/090204.2.1.1.en-us/WidgetMain.html","_blank", s_options);
    return false;
}