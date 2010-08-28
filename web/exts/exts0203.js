// JScript 文件
function initView()
{
    var b = !$E('ck_C1110100').checked;

    $E('cb_C1110100').disabled = b;
    $E('cb_P3010203').disabled = b;
    
    b = $E('hd_IsUpdate').value == '1';
    $X('tr_Asoc00').style.display = b ? '' : 'none';
    $X('tr_Asoc01').style.display = b ? '' : 'none';

    changeAsoc();
}
function changeAsoc()
{
    var b = $E('ck_P3010209').checked;
    $X('tr_Asoc02').style.display = b ? '' : 'none';
    $X('tr_Asoc03').style.display = b ? '' : 'none';
}
function editFile()
{
    $("#dv_P301020A").dialog({width:600,height:400,modal:true});
	$X('if_P301020A').src=_URI+'/icon/icon0201.aspx?sid='+d;
    return false;
}
function viewFile()
{
}
function checkNull()
{
    var c = $E('tf_P3010205');
    var t = c.value;
    if (t == null || t == '')
    {
        alert('“软件名称”不能为空！');
        c.focus();
        return false;
    }
    t = t.replace(/(^\s*)|(\s*$)/g, "");
    if (t == '')
    {
        alert('“软件名称”不能为空！');
        c.value = t;
        c.focus();
        return false;
    }
    
    if ($E('ck_C1110100').checked)
    {
        var cb = $E('cb_P3010203');
        var vl = cb.value;
        if (vl == null || vl == '')
        {
            alert('请选择新的公司！');
            cb.focus();
            return false;
        }
    }
    return true;
}

function checkAppend()
{
    var tf = $E('tf_P3010209');
    var t = tf.value;
    if (t == null || t == '')
    {
        alert('请输入您要添加的后缀名称，形如“.abc”！');
        tf.focus();
        return false;
    }
    t = t.trim();
    if (t == '')
    {
        alert('请输入一个合法的后缀名称！');
        tf.value = t;
        tf.focus();
        return false;
    }
    
    t = t.trimc('\\.');
    if (t == '.')
    {
        alert('您输入的后缀不正确，请重新输入！');
        tf.value = t;
        tf.focus();
        return false;
    }

    if (t.indexOf('.') != 0)
    {
        t = '.' + t;
    }
    tf.value = t;

    var ls = $E('ls_P3010209');
    var op = ls.options;
    for(var i=0; i<op.length; i+=1)
    {
        if(op[i].value == t)
        {
            if(confirm('已存在后缀为 ' + t + ' 的数据，确认要覆盖么？'))
			{
				return true;
			}
			ls.value = t;
            return false;
        }
    }
    return true;
}

function checkDelete()
{
    var ls = $E('ls_P3010209');
    var id = ls.selectedIndex;
    if (id == null || id < 0)
    {
        alert('请选择您要删除的后缀！');
        ls.focus();
        return false;
    }
    var op = ls.options[id];
    if (op == null || op == '')
    {
        alert('请选择您要删除的后缀！');
        ls.focus();
        return false;
    }
    return window.confirm('确认要删除此后缀吗，此操作将不可恢复？');
}

function viewLink()
{
    $A($E('tf_P3010208').value);
}

initView();