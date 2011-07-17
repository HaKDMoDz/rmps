// JScript 文件
function wim()
{
    if( window.screen.height >= 768) window.open( 'http://webmessenger.live.cn/wlml/index.htm?uri=' + location.hostname, 'Messenger', 'scrollbars=no, width=302, height=100');
    else window.open( 'http://webmessenger.live.cn/wlml/index.htm?uri=' + location.hostname, 'Messenger', 'scrollbars=yes, width=302, height=100');
    return false;
}