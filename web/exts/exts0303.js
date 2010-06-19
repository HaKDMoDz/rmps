function initView()
{
    var b = !$E('ck_C1110100').checked;

    $E('cb_C1110100').disabled = b;
    $E('cb_P3010100').disabled = b;
    $E('cb_P3010303').disabled = b;
}
function checkNull()
{
    var c = $E('tf_P3010306');
    var t = c.value;
    if (t == null || t == '')
    {
        alert('“数值签名”不能为空！');
        c.focus();
        return false;
    }
    t = t.trim();
    if (t == '')
    {
        alert('“数值签名”不能为空！');
        c.value = t;
        c.focus();
        return false;
    }
    c=$E('tf_P3010307');
    t=/^\d+$/;
    if(!t.test(c.value))
    {
        alert('偏移位置请输入一个有效的非负整数！');
        c.focus();
        return false;
    }
    
    if ($E('ck_C1110100').checked)
    {
        c = $E('cb_P3010303');
        t = c.value;
        if (t == null || t == '')
        {
            alert('请选择新的软件信息！');
            c.focus();
            return false;
        }
    }
    return true;
}

initView();