// JScript File
function gOpen()
{
    var url = $X('url').value;
    var wnd = '_self';
    var arg = '';
    
    if($X('ck8').checked)
    {
        wnd = '';

        arg += $X('top').value != '' ? 'top=' + $X('top').value + ',' : '';
        arg += $X('left').value != '' ? 'left=' + $X('left').value + ',' : '';
        arg += $X('width').value != '' ? 'width=' + $X('width').value + ',' : '';
        arg += $X('height').value != '' ? 'height=' + $X('height').value + ',' : '';

        // 显示菜单栏
        arg += $X('ck1').checked ? 'menubar=yes,' : '';
        // 显示工具栏
        arg += $X('ck2').checked ? 'toolbar=yes,' : '';
        // 显示状态栏
        arg += $X('ck3').checked ? 'status=yes,' : '';
        // 显示滚动条
        arg += $X('ck4').checked ? 'scrollbars=yes,' : '';
        // 全屏显示
        arg += $X('ck5').checked ? 'fullscreen=yes,' : '';
        // 显示地址栏
        arg += $X('ck6').checked ? 'location=yes,' : '';
        // 窗口可调整
        arg += $X('ck7').checked ? 'resizable=yes,' : '';
        
        if(arg.length > 0)
        {
            arg = arg.substring(0, arg.length - 1);
        }
    }

    $X('code').value = "window.open('" + url + "','" + wnd + "','" + arg + "')";
}
function tOpen()
{
    eval($X('code').value);
}