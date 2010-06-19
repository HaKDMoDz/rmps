/**
 * 在使用JavaScript做WEB键盘事件侦听捕获时，主要采用onkeypress、onkeydown、onkeyup三个事件进行出来。该三个事件的执行顺序如下：onkeydown -> onkeypress ->onkeyup。在一般情况下，采用三种键盘事件均可对键盘输入进行有效的响应。当在实际使用中，会发现这几者有些不同的差别。
 * onkeypress事件不能对系统功能键(例如：后退、删除等，其中对中文输入法不能有效响应)进行正常的响应，onkeydown和onkeyup均可以对系统功能键进行有效的拦截，但事件截获的位置不同，可以根据具体的情况选择不同的键盘事件。
 * 由于onkeypress不能对系统功能键进行捕获，导致window.event对象的keyCode属性和onkeydown，onkeyup键盘事件中获取的keyCode属性不同，主要表现在onkeypress事件的keyCode对字母的大小写敏感，而onkeydown、onkeyup事件不敏感；onkeypress事件的keyCode无法区分主键盘上的数字键和付键盘数字键的，而onkeydown、onkeyup的keyCode对主付键盘的数字键敏感。
 * 需要处理的键盘事件：
 * 1、正常输入的26个字母及10个数字
 * 2、功能键：Ctrl(全/半)、Shift(中/英)、Tab（制表）、Caps（大写锁定）、Back（退格）、Enter（回车）、PgUp/PgDn（上下翻页）
 * 3、组合键：Ctrl+=（造词）、Ctrl+-（删词）、Shift（上档）
 */
var wime=new (function()
{
    var _DOC=document;
    var _WIN=window;
    var _PRE='net_amonsoft_';
    var THIS=this;
    var NAME='wime';
    var HOME='http://amonsoft.net/';
    var PATH=HOME+'wime/';
    
    // 用户信息
    var USER='';
    // 字库信息
    var TYPE=1;

    /**browser user Agent Infomation*/
    var buai;

    /**每页显示候选字符个数*/
    var cnum=4;
    /**用户最大可输入字符长度*/
    var clen=12;
    /**候选字符分隔符*/
    var cspr=' ';

    /**Alt 键是否压下*/
    var akdn=false;
    /**Ctrl 键是否压下*/
    var ckdn=false;
    /**Shift 键是否压下*/
    var skdn=false;
    /**其它控制键是否夺下*/
    var ckey=false;

    /**用户输入键值显示DIV*/
    var dvcd;
    /**候选中文字符显示DIV*/
    var dvcr;
    /**目标TextArea或者Input*/
    var tcmp;
    /**用户当前输入键值*/
    var kmem=0;
    /**用户已输入编码缓冲*/
    var cmem='';
    /**用户已输入文本缓冲*/
    var tmem='';
    /**码表记忆索引*/
    var smem = -1;
    /**显示记忆索引*/
    var imem = 0;
    /**码表堆栈索引*/
    var cstk = new Array();
    /**编码－汉字对照表*/
    var cmap = new Array();
    /**当前显示候选字符列表*/
    var view = new Array();

    /**中文双引号*/
    var cml1 = false;
    /**中文单引号*/
    var cml2 = false;

    /**中英文状态标记*/
    var tise=['中','英'];
    /**全半角状态标记*/
    var tisf=['半','全'];
    /**半角字符*/
    var crke="1234567890abcdefghijklmnopqrstuvwxyz";
    var crkE="1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    /**全角字符*/
    var crkf="１２３４５６７８９０ａｂｃｄｅｆｇｈｉｊｋｌｍｎｏｐｑｒｓｔｕｖｗｘｙｚ";
    var crkF="！＠＃＄％＾＆＊（）ＡＢＣＤＥＦＧＨＩＪＫＬＭＮＯＰＱＲＳＴＵＶＷＸＹＺ";
    /**特殊符号*/
    var crsp=new Array();
    crsp[0]="";
    crsp[1]="。，、；：？！…—·ˉˇ¨‘’“”々～‖∶＂＇｀｜〃〔〕〈〉《》「」『』．〖〗【】（）［］｛｝︵︶︹︺︿﹀︽︾﹁﹂﹃﹄︻︼︷︸︱︳︴";
    crsp[2]="≈≡≠＝≤≥＜＞≮≯∷±＋－×÷／∫∮∝∞∧∨∑∏∪∩∈∵∴⊥∥∠⌒⊙≌∽√≒≦≧⊿";
    crsp[3]="ⅰⅱⅲⅳⅴⅵⅶⅷⅸⅹⅠⅡⅢⅣⅤⅥⅦⅧⅨⅩⅪⅫ⒈⒉⒊⒋⒌⒍⒎⒏⒐⒑⒒⒓⒔⒕⒖⒗⒘⒙⒚⒛⑴⑵⑶⑷⑸⑹⑺⑻⑼⑽⑾⑿⒀⒁⒂⒃⒄⒅⒆⒇①②③④⑤⑥⑦⑧⑨⑩㈠㈡㈢㈣㈤㈥㈦㈧㈨㈩";
    crsp[4]="￥￠￡℅℉㎡℃♂♀°′″¤‰§№☆★○●◎◇◆□■△▲▼▽◢◣◤◥※→←↑↓↖↗↘↙〓＿￣―☉⊕〒";
    crsp[5]="─━│┃┄┅┆┇┈┉┊┋┌┍┎┏┐┑┒┓└┕┖┗┘┙┚┛├┝┞┟┠┡┢┣┤┥┦┧┨┩┪┫┬┭┮┯┰┱┲┳┴┵┶┷┸┹┺┻┼┽┾┿╀╁╂╃╄╅╆╇╈╉╊╋═║╒╓╔╕╖╗╘╙╚╛╜╝╞╟╠╡╢╣╤╥╦╧╨╩╪╫╬╭╮╯╰╱╲╳▁▂▃▄▅▆▇█▉▊▋▌▍▎▏▓▔▕";
    crsp[6]="ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩαβγδεζηθικλμνξοπρστυφχψω";
    crsp[7]="АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
    crsp[8]="āáǎàēéěèīíǐìōóǒòūúǔùǖǘǚǜü";
    crsp[9]="ㄅㄆㄇㄈㄉㄊㄋㄌㄍㄎㄏㄐㄑㄒㄓㄔㄕㄖㄗㄘㄙㄚㄛㄜㄝㄞㄟㄠㄡㄢㄣㄤㄥㄦㄧㄨㄩ˙ˊˇˋ";
    crsp[10]="ぁあぃいぅうぇえぉおかがきぎくぐけげこごさざしじすずせぜそぞただちぢっつづてでとどなにぬねのはばぱひびぴふぶぷへべぺほぼぽまみむめもゃやゅゆょよらりるれろゎわゐゑをん";
    crsp[11]="ァアィイゥウェエォオカガキギクグケゲコゴサザシジスズセゼソゾタダチヂッツヅテデトドナニヌネノハバパヒビピフブプヘベペホボポマミムメモャヤュユョヨラリルレロヮワヰヱヲンヴヵヶ";

    /**ajax数据调用*/
    var http;
    /**数据调用等待中*/
    var busy;

    /**
     * 输入法初始化
     */
    THIS.init=function(f,p)
    {
        // 输入文本框初始化
	    tcmp=document.getElementById(f);
	    if(tcmp)
	    {
            $E(tcmp,'keypress',keyp);
            $E(tcmp,'keydown',keyd);
            $E(tcmp,'keyup',keyu);
	        tcmp.focus();
	    }

    	// 浏览器信息
    	_B();
        _A();

    	// 引入样式，判断是否已经存在样式信息，若不存在则引入
        f=_PRE+NAME;
	    if(!$(f))
	    {
            var lnk=_DOC.createElement("link");
            lnk.rel="stylesheet";
            lnk.type="text/css";
            lnk.href=PATH+'c/'+NAME+'.css';
            lnk.media="all";
            _DOC.lastChild.firstChild.appendChild(lnk);
            _DOC.write('<input type="hidden" id="'+f+'"/>');
        }
    	
    	// 显示窗体
        if(!p)p='left: 5px;bottom: 5px;';
    	var sdiv='<div id="'+f+'_main" style="'+p+'">';
    	sdiv+='<table width="100%" border="0" cellspacing="0" cellpadding="0">';
    	sdiv+='<tr><td align="left" style="width: 120px;"><div id="'+f+'_code">&nbsp;</div></td><td align="center">';
    	sdiv+='<input type="submit" id="'+f+'_prev" value="◄" class="'+f+'_butn" onclick="return wime.prev();" disabled="true" /><input type="submit" id="'+f+'_next" value="►" class="'+f+'_butn" onclick="return wime.next();" disabled="true" /><input type="submit" id="'+f+'_bise" value="中" class="'+f+'_butn" onclick="return wime.hise();" /><input type="submit" id="'+f+'_bisf" value="半" class="'+f+'_butn" onclick="return wime.hisf();" /><input type="hidden" id="'+f+'_hise" value="0" />';
    	sdiv+='<input type="hidden" id="'+f+'_hisf" value="0" /></td></tr>';
    	sdiv+='<tr><td id="'+f+'_line" colspan="2" align="left"><div id="'+f+'_char">&nbsp;</div></td></tr>';
    	sdiv+='</table></div>';
    	_DOC.write(sdiv);

        //iI();
    };

    /**
     * 显示提示信息
     */
    function wait(msg)
    {
        if(msg)
        {
            $('char').innerHTML=msg;
        }

	    $('prev').disabled=true;
	    $('next').disabled=true;

		busy=true;
    }
    
    /**
     * 加载完毕
     */
    function done(msg)
    {
        if(msg)
        {
            $('char').innerHTML=msg;
        }

	    $('prev').disabled=false;
	    $('next').disabled=false;

		busy=false;
    }
    
    /**
     * 显示上一页候选字符
     */
    THIS.prev=function()
    {
        cPrv();
        if(tcmp)tcmp.focus();
        return false;
    };
    
    /**
     * 显示下一页候选字符
     */
    THIS.next=function()
    {
        cNxt();
        if(tcmp)tcmp.focus();
        return false;
    };
    
    /**
     * 改变中英文状态
     */
    THIS.hise=function()
    {
        cise();
        if(tcmp)tcmp.focus();
        return false;
    };
    
    /**
     * 切换全半解状态
     */
    THIS.hisf=function()
    {
        cisf();
        if(tcmp)tcmp.focus();
        return false;
    };
    
    /**
     * 更改码表
     */
    THIS.type=function(sid)
    {
        TYPE=sid;
        return false;
    };

    /**
     * 向输入法添加码表字典
     * d:码表数据
     * s:数据插入偏移量
     */
    function dict(d,s)
    {
        var m,o,i;
	    // 初始化码表
	    while (o=regp.exec(d))
	    {
	        m=o[0];
	        i=m.search(regc);
		    cmap.splice(s++,0,[m.substr(0,i),m.substr(i)]);
	    }
	    return s;
    }
    
    /**
     * txt：待查询的编码
     */
    function ajax()
    {
		try
		{
			if(http.readyState==4&&http.status==200)
			{
			    // 数据调用结束
				done();

				var t=http.responseText.trim();
				if(t=='')
				{
					smem=-1;
					return;
				}

				smem+=1;
				if(dict(t,smem)>=smem)
				{
					cstk.push([smem,0]);
					// 显示匹配的候选字符
					word(smem, 0, cmem);
				}
			}
		}
		catch(exception)
		{
			done('服务器响应处理异常！');
			smem=-1;
		}
    }

    /**
     * 用二分法在码表字典中查找匹配的编码信息：
     * 若找到对应的编码，则返回编码在数组中的索引；
     * 若没找到，则进行网络查询。
     * 此查询结果会修改全局变量smem的值。
     * key：待查询的编码
     * l：二分法查找起始变量
     * h：二分法查找结束变量
     */
    function hash(key,l,h)
    {
		// 二分法查找中间变量
	    var m;
	    // 编码临时指示变量
	    var t;
	    // 指示是否找到对应的编码
	    var f=false;
	    // 用户编码长度
	    var len=key.length;
	    smem=-1;
	    
	    // 二分法查找
	    while (l<=h)
	    {
		    // 二分法查找
		    m=Math.floor((l+h)/2);
		    t=cmap[m][0];
		    if (t==key)
		    {
			    smem=m;
			    f=true;
			    h=m-1;
			    continue;
		    }
		    if (t>key)
		    {
			    h=m-1;
			    continue;
		    }
		    l=m+1;
	    }
	    return f;
    }

    /**
     * 显示候选汉字列表
     * sdx:当前码表中的匹配索引，从下标0开始
     * cdx:起始显示索引，从下标0开始
     * str:用户已经输入的编码信息
     */
    function word(sdx, cdx, str)
    {
	    var len=str.length;
	    var cnt=0;
	    // 相同编码的字符序列
	    var w;
	    // 临时变量，指向一个字符
	    var t;
	    // 临时变量，显示后继不同的编码
	    var c;
	    var htm='';
	    while (cnt<cnum)
	    {
	        c=cmap[sdx];
	        // 取同一编码的多个字符（串）
		    w=c[1].split(cspr);

		    // 取编码信息
		    c=c[0];
		    c=c.length!=len?c.substr(len):'';

		    // 显示后继字符（串）
		    t=w[cdx++];
		    if(t.substr(0,1)=='!')
		    {
		        t=t.substr(1);
		        view[cnt++]=t;
		        htm+='<span class="'+_PRE+NAME+'_note">'+cnt+'.'+t+c+'</span> ';
		    }
		    else
		    {
		        view[cnt++]=t;
		        htm+=cnt+'.'+t+c+' ';
		    }
		    // 同一编码的字符优先处理，当相同编码的字符处理完毕后，继续查看是否还是后缀以此编码为开始的字符。
		    if (cdx>=w.length)
		    {
			    // 重置显示索引
			    cdx=0;
			    // 向后取码表
			    sdx+=1;
			    // 判断码表是否结束
			    if (sdx>=cmap.length || cmap[sdx][0].substr(0,len)!=str)
			    {
				    // 结束取码
				    sdx=-1;
				    break;
			    }
		    }
	    }

	    // 显示分页提示
	    // 下一页按钮可用
	    $('next').disabled=sdx<=0;
	    // 上一页按钮可用
	    $('prev').disabled=cstk.length<=1;

        //记忆码表索引
        smem=sdx;
	    //记忆当前显示索引
	    imem=cdx;
	    $('char').innerHTML = htm;
    }

    /**
     * 根据用户输入编码查找匹配字符
     */
    function code(str)
    {
	    // 清除已有候选字符
	    _C();
	    cstk.splice(0);

	    // 显示已输入编码
	    if (str=='')
	    {
	        $('code').innerHTML='&nbsp;';
	        $('char').innerHTML='&nbsp;';
	        return;
	    }

	    $('code').innerHTML=str;
	    if(str=='z')
	    {
	        view[0]=tmem;
	        smem=-1;
	        imem=0;
	        $('char').innerHTML='1.'+tmem;
	        return;
	    }

	    // 查找匹配编码
	    if(hash(str,0,cmap.length-1))
	    {
			cstk.push([smem,0]);
			
			// 显示匹配的候选字符
			if (smem>=0)
			{
				word(smem, 0, str);
			}
	    }
	    else
	    {
			// 没找到则进行网络查询
	        wait('码表加载中，请稍候！');
			http.open('GET', '/wime/wime0002.ashx?c='+str+'&t='+TYPE+'&u='+USER, true);
			http.send(null);
	    }
    }

	/**
	 * 键盘压下事件处理，用于捕捉辅助键及功能键事件
	 */
    function keyd(e)
    {
		if(busy)
		{
			return false;
		}

        // 校正事件源
        e=_E(e);

    	// Ctrl键事件
	    if (e.ctrlKey)
	    {
	        ckdn=true;
		    return true
	    }
	    // Shift键事件
	    if(e.shiftKey)
	    {
	        skdn=true;
	        return true;
	    }
	    // Alt键事件
	    if(e.altKey)
	    {
	        akdn=true;
	        return true;
	    }
	    
	    // 控制键以外事件
	    akdn=false;
	    ckdn=false;
	    skdn=false;

        // 校正键盘码
	    kmem=_K(e);
	    var chr=String.fromCharCode(kmem);
	    switch (kmem)
	    {
		    // Space
		    case 32:
		    {
                // 是否为输入候选状态，是则追加第一个文本
			    if (cmem!='')
			    {
				    ckey = true;

				    // 向文本追加第一个字符
				    _T(view[0]);
				    iI();

				    return false;
			    }
			    return true;
		    }
		    // Backspace
		    case 8:
		    {
                // 是否为输入候选状态，是则回退一个字符
			    if (cmem!='')
			    {
			        //有控制键夺下
				    ckey = true;

				    cmem = cmem.substr(0, cmem.length-1);
				    code(cmem);
				    return false;
			    }
			    return true;
		    }
		    // Enter
		    case 13:
		    {
                // 回车用于编码上屏
			    if (cmem!='')
			    {
				    _T(cmem);
				    iI();
				    ckey = true;
				    return false;
			    }
			    return true;
		    }
		    // PageDown
		    case 34:
		    {
			    cNxt();
			    return true;
		    }
		    // PageUp
		    case 33:
		    {
			    cPrv();
			    return true;
		    }
		    // Tab
		    case 9:
		    {
			    _T('\t');
			    ckey = true;
			    return false; 
		    }
		    // Esc
		    case 27:
		    {
			    iI();
			    ckey = true;
			    return false;
		    }
		    // Shift
		    case 16:
		    {
			    skdn=true;
			    return true;
		    }
		    // Ctrl
		    case 17:
		    {
			    ckdn=true;
			    return true;
		    }
		    case 18:
		    {
		        akdn=true;
		        return true;
		    }
	    }
    	
	    // 数字输入
	    if (/\d/ .test(chr))
	    {
		    if (e.shiftKey)
		    {
			    if (iF() || iC())
			    {
				    if (iC() && chr=='4')
				    {
					    _T('￥');
				    }
				    else
				    {
					    _T(crkF.substr(crkE.indexOf(chr),1));
				    }
				    ckey = true;
				    return false;
			    }
		    }
		    else
		    {
			    if (cmem!=''&&iC())
			    {
			        chr=parseInt(chr)-1;
				    _T(view[chr%cnum]);
				    iI();
				    ckey = true;
				    sseq(chr);
				    return false;
			    }
		    }
		    return true;
	    }
        /*
	    if (iF() || iC())
	    {
            // if ((key>=186 && key<=192) || (key>=219 && key<=222) ) {
		    if (key == 186 || (key>=188 && key<=192) || (key>=219 && key<=222) )
		    {
			    if (key == 186)
			    {
				    if (iC())
				    {
					    if (e.shiftKey) _T('：');
					    else if (cmem == "") _T('；');
					    else return true;
				    }
				    else
				    {
					    _T( e.shiftKey ? '：' : '；' );
				    }
			    }
                // else if (key == 187) _T( e.shiftKey ? '＋' : '＝' );
			    else if (key == 188) _T( e.shiftKey ? ((iC())? '《' :'＜') : '，' );
			    else if (key == 189) _T( e.shiftKey ? '＿' : '－' );
			    else if (key == 190) _T( e.shiftKey ? ((iC())? '》' :'＞') : (iC())? '。' :'．');
			    else if (key == 191) _T( e.shiftKey ? '？' : '／' );
			    else if (key == 192) _T( e.shiftKey ? '～' : '｀' );
			    else if (key == 219) _T( e.shiftKey ? '｛' : '［' );
			    else if (key == 220) _T( e.shiftKey ? '｜' : (iC())? '、' :'＼');
			    else if (key == 221) _T( e.shiftKey ? '｝' : '］' );
			    else
			    {
				    if (iC())
				    {
				        // 
					    if (e.shiftKey)
					    {
					        _T((cml1 = !cml1) ? '“' : '”');
					    }
					    else if (cmem=='')
					    {
					        _T((cml2 = !cml2) ? '‘' : '’');
					    }
					    else
					    {
					        return true;
					    }
				    }
				    else
				    {
					    _T( e.shiftKey ? '＂' : '＇' );
				    }
			    }
			    ckey = true;
			    return false;
		    }
		    if (iE() && key == 187)
		    {
			    _T( e.shiftKey ? '＋' : '＝' );
			    ckey = true;
			    return false;
		    }
	    }    
    	
	    if (buai=='NS')
	    {
		    if (iF() || iC())
		    {
			    if (key==59)
			    {
				    if (iC())
				    {
					    if (e.shiftKey) _T('：');
					    else if (cmem == "") _T('；');
					    else return true;
				    }
				    else
				    {
					    _T( e.shiftKey ? '：' : '；' );
				    }
				    ckey = true;
				    return false;
			    }
			    else if (key == 61)
			    {
				    if (iE())
				    {
					    _T(e.shiftKey ? '＋' : '＝');
					    ckey = true;
					    return false;
				    }
			    }
			    else if (key == 109)
			    {
				    _T( e.shiftKey ? '＿' : '－' );
				    ckey = true;
				    return false;
			    }
		    }
	    }
    	*/
	    return(true);
    }

    /**
     * 用于捕捉特殊功能键，如CTRL、SHIFT、ALT、META等
     */
    function keyu(e)
    {
		if(busy)
		{
			return false;
		}

//        e=_E(e);
//	    if(kmem==_K(e))
//	    {
//	        return;
//	    }

//	    // Ctrl
//	    if (key == 17 || key == 57402)
//	    {
//		    if (ckdn)
//		    {
//		        cise();
//			    iI();
//		    }
//	    }
//	    // Shift
//	    if (key==16||key==57401)
//	    {
//		    if (skdn)
//		    {
//		        cisf();
//			    iI();
//		    }
//	    }
	    return true;
    }

    /**
     * 正常字符键事件处理，包括大小写字母及';等。
     */
    function keyp(e)
    {
		if(busy)
		{
			return false;
		}
    	
    	// 浏览器快捷键，不进行处理。
	    if(e.ctrlKey||e.altKey)
	    {
	        return true;
	    }

        e=_E(e);
	    var key=_K(e);
	    var chr=String.fromCharCode(key);
	    if (buai=='NS'||buai=='OP')
	    {
		    if(ckey)
		    {
			    ckey=false;
			    return false;
		    }
	    }
    	
    	// 大写字母
	    if (uchr.test(chr))
	    {
	        // 中文输入状态
		    if(iC())
		    {
		        // 已有编码上屏
		        _T(view[0]);
		        iI();
		    }
		    
		    // 全角输入状态
			if(iF())
			{
		        // 输出全角大写字符
			    _T(crkF.substr(crkE.indexOf(chr),1));
			    return false;
		    }
	        // 输出半角大写字符
	        _T(chr);
			return false;
	    }
    	
    	// 小写字母
	    if (lchr.test(chr))
	    {
	        // 英文输入状态
		    if(iE())
		    {
		        // 全角输入状态
			    if(iF())
			    {
			        // 输出全角小写字符
				    _T(crkf.substr(crke.indexOf(chr),1));
				    return false;
			    }
			    
			    // 输出半角小写字符
			    _T(chr);
			    return false;
		    }
		    
		    // 继续码表查询
		    if(cmem.length<clen)
		    {
			    cmem+=chr;
			    code(cmem);
		    }
		    return false;
	    }
    	
	    if (buai=='NS'&&(key==47||key==63))
	    {
		    if(iC()||iF())
		    {
			    return false;
		    }
	    }

	    return false;
    }
    
    /**
     * 显示上一页候选字符
     */
    function cPrv()
    {
        if (cmem!='')
	    {
		    if(cstk.length > 1)
		    {
			    cstk.pop();
                var o=cstk[cstk.length-1];
			    word(o[0],o[1],cmem);
		    }
		    ckey = true;
		    return false;
	    }
    }
    
    /**
     * 显示下一页候选字符
     */
    function cNxt()
    {
        if (cmem!='')
	    {
		    if (smem!=-1)
		    {
			    cstk.push([smem,imem]);

			    _C();
			    word(smem, imem, cmem);
		    }
		    ckey = true;
		    return false;
	    }
    }
    
    /**
     * 切换中英文状态
     */
    function cise()
    {
	    var nise=1-$('hise').value;
	    $('hise').value=nise;
	    $('bise').value=tise[nise];
    }
    
    /**
     * 切换全半解状态
     */
    function cisf()
    {
	    var nisf=1-$('hisf').value;
	    $('hisf').value=nisf;
	    $('bisf').value=tisf[nisf];
    }

    /**
     * 显示特殊符号
     */
    function sign(selObj)
    {
    }

    /**
     * 使用频率统计
     */
    function sseq(i)
    {
        if(cstk.length<0||i<0)
        {
            return;
        }
        var p=cstk[cstk.length-1][0];
        var o=cmap[p][1].split(cspr);
        if(i<o.length)
        {
            // 首选字符优先
            var t=o[i];
            // 前面字符次之
            for(var j=0;j<i;j+=1)
            {
                t+=cspr+o[j];
            }
            // 填补后面字符
            for(var j=i+1;j<o.length;j+=1)
            {
                t+=cspr+o[j];
            }
            // 修改字符状态
            cmap[p][1]=t;
            
            // TODO:扩展，服务器可在此进行添加统计代码
        }
    }
    
    /**
     * 是否为中文输入状态
     */
    function iC()
    {
        return $('hise').value=='0';
    }
    /**
     * 是否为英文输入状态
     */
    function iE()
    {
        return $('hise').value=='1';
    }
    /**
     * 是否为全角输入状态
     */
    function iF()
    {
        return $('hisf').value=='1';
    }
    
    /**
     * 为空初始状态
     */
    function iI()
    {
        _I('&nbsp;','&nbsp;');
    }

    /**
     * 根据名称取得页面元素
     */
    function $(o)
    {
	    return document.getElementById(_PRE+NAME+'_'+o);
    }
    /**
     * 指定的控件添加相关的事件及响应
     * c:要添加事件的控件
     * e:要添加的动作类型（click,keypress等）
     * f:响应事件的函数
     */
    function $E(c,e,f)
    {
        if(c.addEventListener)
        {
            c.addEventListener(e, f, false);
            return;
        }
		if(c.attachEvent)
        {
            c.attachEvent('on'+e, f);
            return;
        }
		c['on'+e] = f;
    }

    /**
     * AJAX异步支持
     */
    function _A()
    {
        // 创建适合其他浏览器的XMLRequest
        if (window.XMLHttpRequest)
        {
            http = new XMLHttpRequest();
        }
        // 创建适合IE的 XMLHttpRequest
        if(!http)
        {
            try
            {
                http = new ActiveXObject('Msxml2.XMLHTTP');
            }
            catch(exception)
            {
                try
                {
                    http = new ActiveXObject('Microsoft.XMLHTTP');
                }
                catch(exception)
                {
                    http = null;
                }
            }
        }
        if(http)
        {
			http.onreadystatechange=ajax;
        }
    }
    /**
     * 获取浏览器信息
     */
    function _B()
    {
	    if (navigator.appName.indexOf('icrosoft')!=-1)
	    {
		    buai = 'IE';
	    }
	    else if(navigator.appName.indexOf('etscape')!=-1)
	    {
		    buai = 'NS';
	    }
	    else
	    {
	        //if (navigator.appName.indexOf('Opera') != -1) {
		    buai = 'OP';
	    }
    }
    /**
     * 清除候选字符列表
     */
    function _C()
    {
	    for (i=0;i<=cnum;i++)
	    {
		    view[i]='';
	    }
    }
    /**
     * 取得页面鼠标及键盘事件对象
     */
    function _E(e)
    {
	    return e||window.event;
    }
    
    /**
     * 获取链接输入键值信息
     */
    function _K(e)
    {
        var k=e.keyCode||e.which;
        return skey[k]?skey[k]:k;
    }
    
    /**
     * 编码信息显示初始化
     * c:用户输入编码初始值
     * t:候选字符初始值
     */
    function _I(c,t)
    {
	    // 清除已输入编码
	    cmem='';

	    // 初始化显示
	    $('code').innerHTML=c;
	    $('char').innerHTML=t;

	    $('prev').disabled=true;
	    $('next').disabled=true;
    }

    /**
     * 向文本区域追加文字
     */
    function _T(str)
    {
	    if (!str||str=='')
	    {
		    return;
	    }
	    
	    // 记忆上一次输入字符
	    tmem=str;

	    switch (buai)
	    {
		    case 'IE':
		    {
			    var r=document.selection.createRange();
			    r.text=str;
			    r.select();
			    break;
			}
		    case 'NS':
		    {
			    var s=tcmp.selectionStart;
			    var e=tcmp.selectionEnd;
			    var t=tcmp.scrollTop;
			    var h=tcmp.scrollHeight;
			    var l = tcmp.value.length;
    			
			    tcmp.value=tcmp.value.substring(0,s)+str+tcmp.value.substring(e);
			    tcmp.selectionStart=tcmp.selectionEnd=s+str.length;
			    if(tcmp.value.length==l)
			    {
				    tcmp.scrollTop=tcmp.scrollHeight;
			    }
			    else if(tcmp.scrollHeight>h)
			    {
				    tcmp.scrollTop=t+tcmp.scrollHeight-h;
			    }
			    else
			    {
				    tcmp.scrollTop=t;
			    }
			    break;
		    }
		    default:
		    {
			    tcmp.value+=str;
			}
	    }
    }
    
    var skey={
        //Shift
        57401:16,
        //Ctrl
        57402:17,
        //Alt
        57403:18,
        //Pause
        57404:19,
        //PgUp
        57383:33,
        //PgDn
        57384:34,
        //End
        57385:35,
        //Home
        57386:36,
        //Print Scrn
        57394:44,
        //Insert
        57395:45,
        //Delete
        57396:46,
        //Scroll,TODO
        145:145,
    };
    
	// 初始化码表
	var regp=/[a-z';]+[^a-z';]+/g;regp.compile("[a-z';]+[^a-z';\r\n]+", "g");
    /**匹配正则表达式*/
    var regc=/[^a-z';]/;regc.compile("[^a-z';]");
    /**大写字母*/
    var uchr=/[A-Z]/;uchr.compile("[A-Z]");
    /**小写字母*/
    var lchr=/[a-z';]/;lchr.compile("[a-z';]");
})();
String.prototype.trim=function(){return this.replace(/(^\s*)|(\s*$)/g, '');};