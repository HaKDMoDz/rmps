function v(o)
{
    return document.getElementById('h'+o).value;
}
var w=window;
var p=v('p');
if(p&&p!='')
{
    var x=v('x');
    if(x&&x!='')
    {
        p=w.open(p.replace('{0}',eval(x)(v('t'))).replace('{1}',eval(x)(v('u'))).replace('{2}',eval(x)(v('d'))),'_self');
    }
    else
    {
        p=w.open(p.replace('{0}',v('t')).replace('{1}',v('u')).replace('{2}',v('d')),'_self');
    }
}
if(p&&v('k')=='1')
{
    w.close();
}