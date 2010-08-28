function chooseFile()
{
    var fun=parent.handleImg;
    if(fun)
    {
        fun('/temp/view/',$X('hd_FileHash').value);
    }
}
function returnHome()
{
    $W().location.href='/icon/icon0200.aspx';
}