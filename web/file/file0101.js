function chooseFile()
{
    var fun=parent.saveFile;
    if(fun)
    {
        fun('/temp/view/',$X('hd_FileHash').value,'.png');
    }
}
function returnHome()
{
    $W().location.href='/icon/icon0200.aspx';
}
function lastFile()
{
    var l=$X('hd_FileList').value;
    var i=$X('hd_FileIndx').value;
    var a=l.split(',');
    if(!a||!a.length)
    {
        return false;
    }
    if(!i)
    {
        i=0;
    }
    i-=1;
    if(i<0)
    {
        i=a.length-1;
    }
    $X('hd_FileIndx').value=i;
    $X('im_ViewFile').src=_URI+'/temp/view/'+a[i]+'.png'
    $X('hd_FileHash').value=a[i];
    return false;
}
function nextFile()
{
    var l=$X('hd_FileList').value;
    var i=$X('hd_FileIndx').value;
    var a=l.split(',');
    if(!a||!a.length)
    {
        return false;
    }
    if(!i)
    {
        i=0;
    }
    i+=1;
    if(i>=a.length)
    {
        i=0;
    }
    $X('hd_FileIndx').value=i;
    $X('im_ViewFile').src=_URI+'/temp/view/'+a[i]+'.png'
    $X('hd_FileHash').value=a[i];
    return false;
}