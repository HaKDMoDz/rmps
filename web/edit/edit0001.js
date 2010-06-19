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
function wrapText()
{
    $E('ta_UserData').wrap=$E('ck_LineWrap').checked?'on':'off';
}
function do_js_beautify()
{
    var bt=$E('bt_Beautify');
    var ta=$E('ta_UserData');
    bt.disabled=true;
    var js_source=ta.value.replace(/^\s+/, '');
    var indent_size = $E('cb_TabsSize').value;
    var indent_char = ' ';
    var preserve_newlines=$E('ck_PreBreak').checked;

    if (indent_size == 1)
    {
        indent_char = '\t';
    }

    if (js_source && js_source[0] === '<' && js_source.substring(0, 4) !== '<!--')
    {
        ta.value=style_html(js_source, indent_size, indent_char, 80);
    }
    else
    {
        ta.value=js_beautify(unpacker_filter(js_source), {indent_size: indent_size, indent_char: indent_char, preserve_newlines:preserve_newlines});
    }

    bt.disabled = false;
    return false;
}
function starts_with(str, what)
{
    return str.substr(0, what.length) === what;
}
function trim_leading_comments(str)
{
    str = str.replace(/^(\s*\/\/[^\n]*\n)+/, '');
    str = str.replace(/^\s+/, '');
    return str;
}
function unpacker_filter(source)
{
    if ($E('ck_PrePackr').checked)
    {
        stripped_source = trim_leading_comments(source);
        if (starts_with(stripped_source.toLowerCase().replace(/ +/g, ''), 'eval(function(p,a,c,k')) {
            try
            {
                eval('var unpacked_source = ' + stripped_source.substring(4) + ';');
                return unpacker_filter(unpacked_source);
            }
            catch (error)
            {
                source = '// jsbeautifier: unpacking failed\n' + source;
            }
        }
    }
    return source;
}