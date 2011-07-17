// JScript File
function checkInput()
{
    var text = $E('cb_P3010007');
    if (text.value == '')
    {
        alert('请选择文件信息！');
        text.focus();
        return false;
    }
}
var inited=false;
function chooseImg()
{
    var d = $E('hd_P3010304').value;
    if (d == null)
    {
        d = '0';
    }
    
    if(!inited)
    {
        iNetHelper.init('','mDlg','own');
        inited=true;
    }

    iNetHelper.mDlgOpen('/icon/icon0100.aspx?dir=file&sid=' + d, 540, 360, handleImg);

    return false;
}

function handleImg(data)
{
    if (data == null)
    {
        return;
    }

    var sid = data['sid'];
    if (sid == null || sid == '')
    {
        sid = '0';
    }
    var dir = data['dir'];
    if (dir == null || dir == '')
    {
        dir = '/data/file/';
        sid = '0';
    }

    $E('ib_P3010304').src = dir + sid + '0030.png';
    $E('hd_UpdtIcon').value = data['opt'];
    $E('hd_IconHash').value = sid;
    $E('hd_IconPath').value = dir;
    $W().focus();
}