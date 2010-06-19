// JScript 文件
var lastView;
function viewType(obj)
{
    if(lastView)
    {
        lastView.style.display = 'none';
    }
    
    if(obj.value == '')
    {
        $X('ta_Code').value = '';
        lastView = null;
        return false;
    }

    lastView = $X('tr_' + obj.value);
    lastView.style.display = '';

    viewCode();
    return false;
}
function viewCode()
{
    var p='\''+$X('tf_Pane').value+'\', ';
    switch($X('cb_Type').value)
    {
        case 'help':
            p += '\'help\'';
            p += ', \'' + $X('cb_MenuView').value + '\'';
            p += ', \'' + $X('tf_MenuT').value + '\'';
            p += ', \'' + $X('tf_MenuU').value + '\'';
            p += ', \'' + $X('ta_MenuD').value + '\'';
            p += ', \'' + $X('tf_MenuC').value + '\'';
            break;
        
        case 'link':
            p += '\'link\'';
            p += ', \'' + $E('cb_LinkType').value.substring(13) + '\'';
            p += ', \'' + $X('cb_LinkView').value + '\'';
            p += ', ' + $X('tf_LinkRows').value;
            p += ', ' + $X('tf_LinkCols').value;
            p += ', \'' + $X('tf_LinkT').value + '\'';
            p += ', \'' + $X('tf_LinkU').value + '\'';
            p += ', \'' + $X('ta_LinkD').value + '\'';
            break;
        
        case 'list':
            p += '\'list\'';
            p += ', \'' + $E('cb_ListType').value.substring(13) + '\'';
            p += ', ' + $X('tf_ListSize').value;
            p += ', \'' + $X('tf_ListT').value + '\'';
            p += ', \'' + $X('tf_ListU').value + '\'';
            p += ', \'' + $X('ta_ListD').value + '\'';
            break;
            
        case 'pbse':
            p += '\'pbse\'';
            p += ', ' + $X('tf_PbseS').value;
            break;
        
        case 'date':
            p += '\'date\'';
            p += ', \'' + $X('cb_DateType').value + '\'';
            p += ', \'' + $X('tf_DateF').value + '\'';
            p += ', ' + $X('tf_DateW').value;
            p += ', ' + $X('tf_DateH').value;
            p += ', \'' + $X('tf_DateD').value + '\'';
            p += ', \'' + $X('tf_DateS').value + '\'';
            break;
        
        case 'time':
            p += '\'time\'';
            p += ', \'' + $X('tf_TimeF').value + '\'';
            p += ', \'' + $X('tf_TimeD').value + '\'';
            break;
        
        case 'form':
            p += '\'form\'';
            p += ', \'' + $X('tf_Form1').value + '\'';
            p += ', ' + $X('tf_Form2').value;
            p += ', ' + $X('tf_Form3').value;
            p += ', ' + $X('tf_Form4').value;
            p += ', ' + $X('tf_Form5').value;
            p += ', \'' + $X('cb_Form6').value + '\'';
            p += ', \'' + $X('cb_Form7').value + '\'';
            p += ', ' + $X('ck_Form8').checked;
            p += ', ' + $X('ck_Form9').checked;
            break;
        
        default:
            $X('ta_Code').value = '';
            return;
    }

    var str = '<script type="text/javascript">\nfunction net_amonsoft_user()\n{\niNetHelper.init('+p+');\n}\n</script>\n';
    str += '<script type="text/javascript" src="http://amonsoft.net/inet/inet0002.ashx?sid='+$E('hd_UserCode').value+'"></script>';
//    var str = '<script type="text/javascript">\n';
//    str += 'document.write(unescape(\'%3Cscript type="text/javascript" src="http://amonsoft.net/inet/inet0001.ashx?sid=';
//    str += $E('hd_UserCode').value + '" charset="utf-8" %3E%3C/script%3E\'));\n';
//    str += '</script>\n';
//    str += '<script type="text/javascript">\n';
//    str += 'iNetHelper.init(' + p + ');\n';
//    str += '</script>';

    $X('ta_Code').value = str;
}
function viewText(obj, def, num)
{
    var txt = obj.value;
    if(txt==null || txt.trim()=='')
    {
        obj.value = def;
    }
    else if(num)
    {
        if(!/^\d+$/.test(txt))
        {
            alert('请输入一个整数值！');
            obj.focus();
            return;
        }
    }
    viewCode();
}
function preview()
{
    var fun=$X('ta_Code').value;
    if(fun.trim()=='')
    {
        alert('请选择您需要的功能！');
        $X('cb_Type').focus();
        return;
    }
    var win = $W().open('', 'amonsoft');
    win.document.write('<html xmlns="http://www.w3.org/1999/xhtml"><head><meta http-equiv="Content-Type" content="text/html; charset=utf-8" /><title>功能预览</title><style type="text/css">BODY,A{font-family: "宋体", simsun, Arial, "Times New Roman";font-size: 9pt;}</style></head><body><div>如果您没有查看到运行效果，请尝试刷新一次本页面！<div><br /><br /></body></html>'+fun);
}