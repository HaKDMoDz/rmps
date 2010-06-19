// JScript File
function chooseImage()
{
    var fun=parent.saveIcon;
    if(fun)
    {
        fun('/icon/img/',$X('hd_IconHash').value,$X('ck_Append').checked?'3':'2');
    }
}
function returnHome()
{
    $W().location.href='/icon/icon0100.aspx';
}
function changeSize()
{
    var s = $X('cb_ImgScale').value;
    if(s != '0')
    {
        $X('tf_ImgWidth').value = s;
        $X('tf_ImgHight').value = s;
        $X('tf_ImgWidth').readOnly = true;
        $X('tf_ImgHight').readOnly = true;
    }
    else
    {
        $X('tf_ImgWidth').value = s;
        $X('tf_ImgHight').value = s;
        $X('tf_ImgWidth').readOnly = false;
        $X('tf_ImgHight').readOnly = false;
        $X('tf_ImgWidth').focus();
    }
}