// JScript File
function initView()
{
    // 设置默认选择项
    var val=$E('hd_W2039104').value;
    if(val!='')
    {
        val+=',';
        objs=$E('cb_W2039104').options;
        for(var i=0;i<objs.length;i+=1)
        {
            var obj=objs[i];
            if(obj.value.indexOf(val)==0)
            {
                obj.selected=true;
                break;
            }
        }
    }

	// LOGO修改组件的可见性
    var b=$E('ck_W2039104').checked;
    var c=b?'none':'';
    $E('im_W203910A').style.display=c;
    $E('fu_W2039106').style.display=c;
    $E('bt_W2039106').style.display=c;
    return b;
}
function checkNull()
{
    var obj=$E('cb_W2039104');
    var val=obj.value.trim();
    if(val=='')
    {
        alert('请选择从属网站！');
        obj.focus();
        return false;
    }
    
    obj=$E('cb_W2039105');
    var val=obj.value.trim();
    if(val=='')
    {
        alert('请选择所属类别！');
        obj.focus();
        return false;
    }

    obj=$E('tf_W203910A');
    val=obj.value.trim();
    if(val=='')
    {
        val='http://amonsoft.cn/';
        obj.value=val;
    }
    if(val.indexOf('://')<1)
    {
        alert('链接地址输入格式不正确！');
        obj.focus();
        return false;
    }
    
    obj=$E('tf_W2039107');
    if(obj.value.trim()=='')
    {
        alert('请输入显示名称！');
        obj.focus();
        return false;
    }
    
    obj=$E('tf_W2039108');
    if(obj.value.trim()=='')
    {
        alert('请输入功能名称！');
        obj.focus();
        return false;
    }
    return true;
}
/**
 * 自动搜寻LOGO事件
 */
function checkLink()
{
    var obj=$E('tf_W203910A');
    var url=obj.value;
    if(url=='')
    {
        alert('请输入链接路径信息！');
        obj.focus();
        return false;
    }
    if(url.indexOf('http://')!=0)
    {
        alert('此功能仅限于查找http网站的favicon.ico文件。');
        return false;
    }
    return true;
}
function changeIcon()
{
    // 选择值信息
    var v=$E('cb_W2039104').value;

    if(v=='0,0')
    {
        $E('ck_W2039104').checked=false;
        var c='';
        $E('im_W203910A').style.display=c;
        $E('fu_W2039106').style.display=c;
        $E('bt_W2039106').style.display=c;
    }

    if($E('ck_W2039104').checked)
    {
        $E('im_W2039106').src='/data/srch/'+(v.split(',')[1]||'0')+'.png';
    }
    return false;
}
function changeView()
{
    if(initView())
    {
        $E('im_W2039106').src='/data/srch/'+($E('cb_W2039104').value.split(',')[1]||'0')+'.png';
    }
    else
    {
        $E('im_W2039106').src='/data/srch/'+($E('hd_W2039106').value||'0')+'.png';
    }
}
initView();