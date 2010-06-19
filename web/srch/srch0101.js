// JScript File
var pre=_PRE+'tv_DataList';
function doAppend()
{
    $W().location.href='srch9997.aspx';
    return false;
}
function doUpdate()
{
    var arr=$D().getElementsByTagName('input');
    if(!arr||!arr.length)
    {
        return false;
    }
    var box;
    var cnt=0;
    for(var i=0;i<arr.length;i+=1)
    {
        box=arr[i];
        if(box.type=='checkbox'&&box.id.indexOf(pre)==0)
        {
            if(box.checked)
            {
                cnt+=1;
            }
        }
    }
    if(cnt<1)
    {
        alert('请选择您要更新的数据！');
        return false;
    }
    if(cnt>1)
    {
        alert('每次仅能更新一个数据！');
        return false;
    }
    return true;
}
function initView()
{
    var arr=$D().getElementsByTagName('input');
    if(!arr||!arr.length)
    {
        return false;
    }
    for(var i=0;i<arr.length;i+=1)
    {
        box=arr[i];
        if(box.type=='checkbox'&&box.id.indexOf(pre)==0)
        {
            box.onclick=function()
            {
                doCheck(this);
            }
        }
    }
}
function doCheck(obj)
{
    if(!obj)
    {
        return;
    }
    var oid=obj.id;
    oid=oid.substring(0,oid.indexOf('CheckBox'))+'Nodes';
    var tmp=$X(oid);
    if(tmp)
    {
        oid=obj.checked;
        var arr=tmp.getElementsByTagName('input');
        if(arr&&arr.length)
        {
            for(var i=0;i<arr.length;i+=1)
            {
                obj=arr[i];
                if(obj.type=='checkbox'&&obj.id.indexOf(pre)==0)
                {
                    obj.checked=oid;
                }
            }
        }
    }
}
initView();