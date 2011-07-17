// JScript File
function checkNull()
{
    var obj=$E('cb_UserRank');
    var val=obj.value.trim();
    if(val!=$E('hd_UserRank').value)
    {
        if(!confirm('确认要修改用户使用权限吗？'))
        {
            return false;
        }
    }
    obj=$E('tf_UserPwds');
    val=obj.value;
    if(val&&val!='')
    {
        if(!confirm('确认要修改用户登录口令吗？'))
        {
            return false;
        }
    }
    return true;
}