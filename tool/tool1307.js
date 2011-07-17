// JScript File
function initView()
{
	// 为链接类别复选框添加事件
    var objs=$D().getElementsByTagName("input");
    for(var i=0;i<objs.length;i++)
    {
        var obj=objs[i];
        if(obj.type=='checkbox'&&obj.id.indexOf(_PRE+'tv_P3070A05')==0)
        {
            obj.onclick=function(){doCheck(this);};
        }
    }

	// LOGO修改组件的可见性
    var b=$E('ck_P3070104').checked;
    var c=b?'none':'';
    $E('im_P3070109').style.display=c;
    $E('fu_P3070106').style.display=c;
    $E('bt_P3070106').style.display=c;
    return b;
}
function checkNull()
{
    var arr=$D().getElementsByTagName('INPUT');
    var cnt=0;
    for(var i=0;i<arr.length;i+=1)
    {
        if((arr[i].id.indexOf(_PRE+'tv_P3070A05')==0)&&arr[i].checked)
        {
            cnt+=1;
			break;
        }
    }
    if(cnt==0)
    {
        alert('请选择链接类别！');
        return false;
    }

    var obj=$E('cb_P3070104');
    var val=obj.value.trim();
    if(val=='')
    {
        alert('请选择从属门户！');
        obj.focus();
        return false;
    }
    
    obj=$E('tf_P3070107');
    if(obj.value.trim()=='')
    {
        alert('请输入有效的链接名称！');
        obj.focus();
        return false;
    }

    obj=$E('tf_P3070109');
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
    return true;
}
/**
 * 自动搜寻LOGO事件
 */
function checkLink()
{
    var obj=$E('tf_P3070109');
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
/**
 * 显示隐藏类别选择菜单
 */
var inited=false;
function checkType()
{
    var obj=$X('dv_P3070104');
    obj.style.display=(obj.style.display==''?'none':'');
    if(!inited)
    {
        iNetHelper.blur('dv_P3070104',true);
        inited=true;
    }
    return false;
}
/**
 * 用户选择类别事件
 */
function doCheck(obj)
{
    var idx;
    var val='';
    var objs=$D().getElementsByTagName("input");
    for(var i=0;i<objs.length;i++)
    {
        tmp=objs[i];
        if(tmp.type=='checkbox'&&tmp.id.indexOf(_PRE+'tv_P3070A05')==0&&tmp.checked)
        {
            tmp=tmp.id;
            idx=tmp.indexOf('CheckBox');
            tmp='tv_P3070A05t'+tmp.substring(tmp.indexOf('tv_P3070A05')+12,idx);
            val+=$E(tmp).innerHTML+';';
        }
    }
    if(val=='')
    {
        val='--请选择--';
    }
    $E('tf_P3070A05').value=val;
}
function histBack()
{
    window.close();
}
/**
 * 门户网站匹配查找
 */
var lastIndx=-1;
var lastWord='';
function checkPort()
{
    var obj=$X('tf_P3070104');
    var val=obj.value.trim();
    if(val=='')
    {
        alert('请输入您要查找的一个或多个字符！');
        obj.focus();
        return false;
    }
    if(lastWord!=val)
    {
        lastWord=val;
        lastIndx=-1;
    }

    lastIndx+=1;
    obj=$E('cb_P3070104').options;
    while(lastIndx<obj.length)
    {
        if(obj[lastIndx].text.indexOf(val)>=0)
        {
            obj[lastIndx].selected=true;
            if($E('ck_P3070104').checked)
            {
                $E('im_P3070106').src='/data/link/'+(obj[lastIndx].value.split(',')[1]||'0')+'.png';
            }
            break;
        }
        lastIndx+=1;
    }
    if(lastIndx>=obj.length)
    {
        alert('不存在与您输入字符相匹配的选项！');
        lastIndx=-1;
    }
    return false;
}
/**
 * 网站首页选择事件
 */
function changeIcon()
{
    // 选择值信息
    var v=$E('cb_P3070104').value;

    if(v=='0,0')
    {
        $E('ck_P3070104').checked=false;
        var c='';
        $E('im_P3070109').style.display=c;
        $E('fu_P3070106').style.display=c;
        $E('bt_P3070106').style.display=c;
    }

    if($E('ck_P3070104').checked)
    {
        $E('im_P3070106').src='/data/link/'+(v.split(',')[1]||'0')+'.png';
    }
    return false;
}
function changeView()
{
    if(initView())
    {
        $E('im_P3070106').src='/data/link/'+($E('cb_P3070104').value.split(',')[1]||'0')+'.png';
    }
    else
    {
        $E('im_P3070106').src='/data/link/'+($E('hd_P3070106').value||'0')+'.png';
    }
}
initView();