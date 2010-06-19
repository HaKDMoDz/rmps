// JScript File
/*当前操作的数据*/
var cur;
/*当前操作的容器*/
var div;
/*用户选择的属性*/
var key;
/*用户选择的图片*/
var img;
/**
 * 删除选择的文本对象
 */
function delItem()
{
    var val=fav.value;
    if(!val)
    {
        alert('请选择您要删除的数据！');
        fav.focus();
        return false;
    }
    if(!confirm('确认要删除此数据吗？'))
    {
        return false;
    }
    val=fav.selectedIndex;
    fav.options.remove(val);
    $X('cardItem'+val).style.display='none';
    usr.splice(val,1);
    return true;
}
/**
 * 创建新的文本对象
 */
function newItem()
{
    // 记录用户选择的属性
    key=$E('cb_SysList').value;

    var tmp=sys[key];
    if(!tmp)
    {
        return;
    }

    // 维护用户偏好列表
    var cnt=fav.options.length;
    fav.options.add(new Option(tmp.name,key));
    fav.selectedIndex=cnt;

    // 创建文本显示对象
    div=divItem(ctl,fav,tmp,cnt);

    // 记录用户修改信息
    cur={};
    usr.push(cur);

    // 显示默认设置
    defView(tmp);
}
/**
 * 创建新的DIV
 * top:容器对象
 * fav:配置列表
 * dat:数据对象
 * idx:对象索引
 */
function divItem(top,fav,dat,idx)
{
    var obj=$D().createElement('div');
    //设置文本显示属性
    obj.id='cardItem'+idx;
    obj.style.position='absolute';
    obj.style.zIndex=(idx+1);
    obj.style.top=dat.ypos+'px';
    obj.style.left=dat.xpos+'px';
    obj.style.fontSize=dat.size+'px';
    obj.style.color=dat.color;
    obj.style.fontFamily=dat.family;
    obj.style.fontWeight=dat.bold?'bold':'normal';
    obj.style.fontStyle=dat.itac?'italic':'normal';
    obj.style.textDecoration=dat.strk?'line-through':'none';
    obj.style.borderBottom='solid '+(dat.line?1:0)+'px '+dat.color;
    obj.onmouseover=function(evt){$O(evt||event).className='cardItem';};
    obj.onmouseout=function(evt){$O(evt||event).className='';};
    obj.onclick=function(evt){fav.selectedIndex=idx;chgItem(idx);};
    obj.innerHTML=dat.title+dat.text1;

    top.appendChild(obj);
    return obj;
}
/**
 * 显示默认信息
 */
function defView(obj)
{
    var o=parseInt(obj['count']);
    for(var i=1;i<=3;i+=1)
    {
        $X('pp_text'+i).readOnly=(i>o);
    }
    for(var t in obj)
    {
        cur[t]=obj[t];
        o=$X('pp_'+t);
        if(o)
        {
            o.value=obj[t];
        }
    }
    $E('pp_family').value=obj.family;
    $X('pp_bold').checked=obj.bold;
    $X('pp_itac').checked=obj.itac;
    $X('pp_strk').checked=obj.strk;
    $X('pp_line').checked=obj.line;
}
/**
 * 用户已有选项切换事件
 */
function chgItem(idx)
{
    cur=usr[idx];
    if(cur)
    {
        div=$X('cardItem'+idx);
        defView(cur);
    }
}
/**
 * 文本属性调整事件
 * k:用户选项键
 * v:用户选项值
 * p:CSS选项键
 * u:CSS选项单位
 */
function chgProp(k,v,p,u)
{
    if(!cur)
    {
        return;
    }

    cur[k]=v;
    div.style[p]=v+u;
}
/**
 * 标题头改变事件
 */
function chgHead(o)
{
    if(!cur)
    {
        return;
    }

    var t=o.id.substring(3);
    cur[t]=o.value;
    div.innerHTML=cur['title']+cur['text1'];
}
/**
 * 文本属性调整事件
 * k:用户选项键
 * v:用户选项值
 * p:CSS选项键
 * v1:候选值1
 * v2:候选值2
 */
function chgFont(k,v,p,v1,v2)
{
    if(!cur)
    {
        return;
    }

    cur[k]=v;
    div.style[p]=v?v1:v2;
}
/**
 * 下划线事件
 */
function chgLine(o)
{
    if(!cur)
    {
        return;
    }
    
    cur.line=o.checked;
    div.style['borderBottom']='solid '+(o.checked?1:0)+'px '+cur.color;
}
/**
 * 文本颜色属性事件
 * o:文本框对象
 */
function chgClor(o)
{
    if(!cur)
    {
        return;
    }

    var reg=/^[#]?[0-9A-Fa-f]{6}$/;
    var v=o.value;
    if(!reg.test(v))
    {
        alert('正确颜色格式为：#FFFFFF');
        o.focus();
        return;
    }
    if(v.indexOf('#')!=0)
    {
        v='#'+v;
    }
    reg=o.id.substring(3);
    cur[reg]=v;
    div.style['color']=v;
}
/**
 * 坐标步增控制
 * sid:文本对象ID
 * stp:步增量
 * prp:对象的属性
 */
function chgStep(sid,stp,prp)
{
    if(!cur)
    {
        return;
    }

    var obj=$X('pp_'+sid);
    if(!obj)
    {
        return;
    }
    var val=obj.value;
    if(!val)
    {
        return;
    }
    var reg=/^[+-]?\d+$/;
    if(!reg.test(val))
    {
        alert('请输入一个合法的整数！');
        obj.focus();
        return;
    }
    stp=parseInt(val)+stp;
    obj.value=stp;
    cur[sid]=stp;
    div.style[prp]=stp+'px';
}
/**
 * 背景图像切换
 */
function chgIcon(idx)
{
    if(!img)
    {
        img=new Image();
        img.onload=function()
        {
            if(img)
            {
                var tmp=$E('dv_FavCard');
                alert(img.width);
                tmp.style.width=img.width+'px';
                tmp.style.height=img.height+'px';
                //tmp.style.backgroundImage='data/0.png';
                tmp.style.backgroundImage='url(data/'+$E('cb_CardIcon').options[idx]+'.png)';
            }
        }
    }
    img.src='data/0.png';
    img.src='data/'+$E('cb_CardIcon').options[idx]+'.png';
    
}
/**
 * 数据保存时为空检测
 */
function checkNull()
{
    var tmp=$E('tf_CardName');
    var val=tmp.value.trim();
    if(val=='')
    {
        alert('请输入卡片名称！');
        tmp.focus();
        return false;
    }

    var txt='';
    for(var i=0;i<usr.length;i+=1)
    {
        tmp=usr[i];
        for(var j in tmp)
        {
            txt+=j+'\t'+tmp[j]+'\r';
        }
        txt+='\n';
    }
    $E('hd_CardData').value=txt;
    txt=card_card0002.saveCard(txt,val,$E('ta_CardDesp').value,$E('hd_SID').value,$E('hd_URI').value).value;
    if(txt&&txt[0]&&txt[0].length==16)
    {
        $E('hd_SID').value=txt[0];
        alert('数据保存成功！');
        return false;
    }
    return false;
}
/**
 * 图片文件上传
 */
function doUpload(img)
{
    var cnt=$E('cb_CardIcon').options.length;
    if(cnt>8&&$E('hd_URI').value!='A0000000')
    {
        alert('由于网站空间有限，每用户最多只能上传8张图片，感谢您的理解与支持！');
        return false;
    }
    var obj=$X('dv_CardIcon');
    if(obj.style.display!='none')
    {
        obj.style.display='none';
        img.title='显示文件上传功能';
    }
    else
    {
        obj.style.display='';
        img.title='隐藏文件上传功能';
    }
    return false;
}
var tmp=0;
function initView()
{
    if(tmp<usr.length)
    {
        divItem(ctl,fav,usr[tmp],tmp);
        tmp+=1;
        setTimeout('initView()',300);
    }
}
/*用户属性列表*/
var fav=$E('cb_FavList');
/*卡片展示对象*/
var ctl=$E('dv_FavCard');
setTimeout('initView()',300);