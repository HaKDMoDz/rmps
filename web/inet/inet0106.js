// JScript File
function addEngine()
{
    if(window.navigator.userAgent && window.navigator.userAgent.indexOf('Trident/4.0') > -1)
    {
        window.external.addService("/inet/inet0106.ashx");
        return;
    }
    alert('此加速器仅适用于Microsoft Internet Explorer 8 及以上浏览器！');
}