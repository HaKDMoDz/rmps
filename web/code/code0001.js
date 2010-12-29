// JScript File
$(function pageInit()
{
    $X('tr_Res').style.display=$X('rb_EditCode').checked?'none':'';
    $X('tr_EditOpen').style.display=$X('rb_EditCode').checked?'none':'';
    $X('tr_EditText').style.display=$X('rb_EditText').checked?'':'none';
    $X('tr_EditHtml').style.display=$X('rb_EditHtml').checked?'':'none';
    $X('tr_EditCode').style.display=$X('rb_EditCode').checked?'':'none';
    $( "#mode" ).buttonset();
    KE.init({id : 'ta_UserData',imageUploadJson : 'code0003.ashx',fileManagerJson : 'code0002.ashx',allowFileManager : true});
});
function showText()
{
    KE.remove('ta_UserData');
    $X('tr_Res').style.display='';
    $X('tr_EditOpen').style.display='';
    $X('tr_EditText').style.display='';
    $X('tr_EditHtml').style.display='none';
    $X('tr_EditCode').style.display='none';
}
function showHtml()
{
	KE.create('ta_UserData');
	$X('tr_Res').style.display='';
	$X('tr_EditOpen').style.display='';
    $X('tr_EditText').style.display='none';
    $X('tr_EditHtml').style.display='';
    $X('tr_EditCode').style.display='none';
}
function showCode()
{
    KE.remove('ta_UserData');
    $X('tr_Res').style.display='none';
    $X('tr_EditOpen').style.display='none';
    $X('tr_EditText').style.display='none';
    $X('tr_EditHtml').style.display='none';
    $X('tr_EditCode').style.display='';
}
function transform()
{
    var obj=$X('cb_Language');
    var val=obj.value;
    if(!val||val.length!=16)
    {
         $X('dv_Message').innerHTML='请选择源代码语言！';
         $( "#dv_Message" ).dialog({
		     height: 140,
		     modal: true
	     });
	     return false;
    }
    $.ajax({
      url:"code0001.ashx",
      type:"POST",
      data:({
              l:$X('cb_Language').value,
              i:$X('ck_InLineStyle').checked?'1':'0',
              n:$X('ck_ShowLineNbr').checked?'1':'0',
              u:$X('ck_ShowLinkUri').checked?'1':'0',
              t:$X('cb_TagStyle').value,
              s:$X('tf_TabCount').value,
              c:$X('ta_UserData').value
           }),
      success:function(msg){
         if(typeof(msg) != 'string'){
             $X('dv_Message').innerHTML='服务器处理异常！';
             $( "#dv_Message" ).dialog({
			     height: 140,
			     modal: true
		     });
             return;
         }
         if(msg.indexOf('msg:')>=0){
             $X('dv_Message').innerHTML=msg.substring(4);
             $( "#dv_Message" ).dialog({
			     modal: true
		     });
            return;
         }
         $X('ta_UserData').value=msg;
      }
   });
   return false;
}
function editSubmit()
{
    var obj = $X('ck_OverRide');
    if(obj && obj.checked)
    {
        return $W().confirm('此操作将会覆盖服务器上的现有文件，并且不可恢复，确认要执行此操作么？');
    }
    return true;
}
function editPrompt()
{
    var url = $X('tf_FilePath').value;
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
    $X('ta_UserData').wrap=$X('ck_LineWrap').checked?'on':'off';
}
function do_js_beautify()
{
    var bt=$X('bt_Beautify');
    var ta=$X('ta_UserData');
    bt.disabled=true;
    var js_source=ta.value.replace(/^\s+/, '');
    var indent_size = $X('cb_TabsSize').value;
    var indent_char = ' ';
    var preserve_newlines=$X('ck_PreBreak').checked;

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