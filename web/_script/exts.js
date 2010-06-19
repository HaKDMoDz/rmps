// JScript 文件
function checkExts(textObj)
{
    var exts = textObj.value;
    if(exts == null)
    {
        alert('后缀名称不能为空！');
        textObj.focus();
        return false;
    }

    exts = exts.trim();
    if(exts == '')
    {
        alert('后缀名称不能为空！');
        textObj.value = exts;
        textObj.focus();
        return false;
    }
    
    exts = exts.ltrimc('\\.', '.');
    if (exts == '.')
    {
        alert('请输入一个形如“.abc”的后缀字符串！');
        textObj.value = exts;
        textObj.focus();
        return false;
    }
    
    if(exts.charAt(0) != '.')
    {
        exts = '.' + exts;
    }
    textObj.value = exts;
    return true;
}