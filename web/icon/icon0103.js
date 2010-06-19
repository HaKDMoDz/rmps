// JScript 文件
function chooseImage()
{
    var rbn = document.getElementsByName('rb_IconHash');
    var v = $X('hd_IconHash').value;
    if(!rbn.length)
    {
        v = rbn.value;
    }
    else
    {
        var i = 0;
        while(i < rbn.length)
        {
            if (rbn[i].checked)
            {
                v = rbn[i].value;
                break;
            }
            i += 1;
        }
    }
    
    var fun=parent.saveIcon;
    if(fun)
    {
        fun('/icon/res/',v,$X('ck_Append').checked ? '3':'2');
    }
}
function returnHome()
{
    $W().location.href='/icon/icon0100.aspx';
}
var last = 'tr1';
function showTR(idx)
{
    $X(last).style.display = 'none';
    last = 'tr' + idx;
    $X(last).style.display = '';
}