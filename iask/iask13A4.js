// JScript File
var wp = document.getElementsByTagName('input');
if(wp.length)
{
	for(var i=0; i<wp.length; i+=1)
	{
		if (wp[i].type.toString().toLowerCase()=='text')
		{
			$X(wp[i].id).value = eval(wp[i].id);
		}
	}
}
var mt = navigator.mimeTypes;
if(mt.length)
{
	var tr = '<table border="0" cellpadding="3" cellspacing="0" width="460" style="border-left: dashed 1px #CCCCCC; border-top: dashed 1px #CCCCCC; background-color: #FAFAFA;">';
	var tm;
	for(var i=0; i<mt.length; i+=1)
	{
		tm = mt[i];
		tr += '<tr>';
		tr += '<td align="left" colspan="2" style="border-right: dashed 1px #CCCCCC;">' + tm.type + '</td>';
		tr += '</tr>';
		tr += '<tr>';
		tr += '<td style="width: 80px;">&nbsp;</td>';
		tr += '<td align="left" style="border-right: dashed 1px #CCCCCC;">〖简介〗：' + tm.description + '</td>';
		tr += '</tr>';
		tr += '<tr>';
		tr += '<td style="width: 80px; border-bottom: dashed 1px #CCCCCC;">&nbsp;</td>';
		tr += '<td align="left" style="border-bottom: dashed 1px #CCCCCC; border-right: dashed 1px #CCCCCC;">〖后缀〗：' + tm.suffixes + '</td>';
		tr += '</tr>';
	}
	tr += '</tabls>';
	$X('mimeTypes').innerHTML = tr;
}

function hideDesp(obj)
{
    var v = obj.checked ? 'none' : '';
    var tr = document.getElementsByTagName('tr');
    if(tr.length)
    {
        for(var i=0; i<tr.length; i+=1)
        {
            if(tr[i].id.toString().indexOf('tr_')==0)
            {
                tr[i].style.display = v;
            }
        }
    }
}