// JScript 文件
function checkNull()
{
    if($E('ta_IdeaText').value == '')
    {
        alert('请输入您的留言内容！');
        $E('ta_IdeaText').focus();
        return false;
    }
    return true;
}
