// JScript File
/**
* Method 测试正则表达式函数
*/
function check()
{
	var pattern = _('r');
	var flags = c('g') + c('i') + c('m');
	var string = _('s');
	var method = _('t');

	// 利用用户输入的字符串和标志建立正则表达式
	var re = new RegExp(pattern, flags);

	// 获得并显示生成的正则表达式的字符串形式
	$('r', re.toString() + ' ');

	var ex = "new RegExp('" + pattern + "', '" + flags + "').";
	
	// 定义 返回值
	var cr;
	// 根据用户选择的方法, 进行相应的调用
	switch (method)
	{
	    // 正则表达式的 exec 方法
		case 'exec':
		cr = re.exec(string);
		ex = ex + "exec('" + string + "')";
		break;
		
		// 正则表达式的 test 方法
		case 'test':
		cr = re.test(string);
		ex = ex + "test('" + string + "')";
		break;
		
		// 字符串类的 match 方法
		case 'match':
		cr = string.match(re);
		ex = "'" + string + "'.match(" + re.toString() + ")";
		break;
		
		// 字符串类的 search 方法
		case 'search':
		cr = string.search(re);
		ex = "'" + string + "'.search(" + re.toString() + ")";
		break;
		
		// 字符串类的 replace 方法
		case 'replace':
		cr = string.replace(re, '');
		ex = "'" + string + "'.replace(" + re.toString() + ", '')";
		break;
		
		// 字符串类的 split 方法
		case 'split':
		cr = string.split(re);
		ex = "'" + string + "'.split(" + re.toString() + ")";
		break;
	}

	// 获得并显示表达式
	$('x', ex);
	
	// 获得并显示计算结果的类型
	$('t', typeof(cr));

	// 定义结果
	var result = '';
	
	if(cr != null)
	{
	    // 如果计算结果是一个数组, 则取出所有数组的值
		if (cr.length)
		{
			for ( i = 0; i < cr.length; i++ )
			{
				result += "\narray[" + i + "] = '" + cr[i] + "'";
			}
			if (result.length > 2)
			{
			    result = result.substring(2);
			}
		}
		// 如果计算结果不为null, 则取出计算结果的值
		else
		{
			result = cr;
		}
	}

	// 获得并显示结果
	$('m', result + '');
	
	// 获得并显示正则表达式的lastIndex属性
	$('i', re.lastIndex + '');
}
function _(n)
{
	return document.getElementById('_' + n).value;
}
function c(n)
{
	var o = document.getElementById('_' + n);
	return (o && o.checked) ? o.value : '';
}
function $(n, v)
{
	document.getElementById('$' + n).innerHTML = v.replace(/\&/g, "&amp;").replace(/>/g, "&gt;").replace(/</g, "&lt;").replace(/ /g, "&nbsp;").replace(/\n/g,"<br />");
}

function p()
{
    var r = $X('_r');
    switch(_('p'))
    {
        // 整数
        case 'n001':
        r.value = '^-?\\d+$';
        break;
        
        // 正整数
        case 'n002':
        r.value = '^\\+?[1-9]\\d*$';
        break;
        
        // 负整数
        case 'n003':
        r.value = '^-[1-9]\\d*$';
        break;
        
        // 非负整数
        case 'n004':
        r.value = '^\\+?\\d+$';
        break;
        
        // 非正整数
        case 'n005':
        r.value = '^-\\d+$';
        break;
        
        // 小数
        case 'n006':
        r.value = '^[+-]?\\d+\\.\\d+$';
        break;
        
        // 仅数字
        case 'n007':
        r.value = '^\\d+$';
        break;
        
        // 邮政编码
        case 'n008':
        r.value = '^\\d{6}$';
        break;
        
        // 手机号码
        case 'n009':
        r.value = '^(\\+?\\d{1,3}[- ]?)?\\d{11}$';
        break;
        
        // 大写字母
        case 'c001':
        r.value = '^[A-Z]+$';
        break;
        
        // 小写字母
        case 'c002':
        r.value = '^[a-z]+$';
        break;
        
        // 大小写字母
        case 'c003':
        r.value = '^[A-Za-z]+$';
        break;
        
        // 字母及数字
        case 'c004':
        r.value = '^[A-Za-z\\d]+$';
        break;
        
        // 字母、数字及下划线
        case 'c005':
        r.value = '^[\\w\\d]+$';
        break;
        
        case 'c006':
        r.value = '^\\w+[\\w\\d\\.]*$';
        break;
        
        case 'c007':
        r.value = '^\\w+[\\w\\.]*@\\w+(\\.[\\w\\.]+)+$';
        break;
    }
}