var a=3,b='j';
function _c(){$X(b).value=''}
function _d(){var c=$X(b).value;if(c==null||c.trim()==''){return;}$X(b).value=eval(c.replace(/^eval/, ''))}
function _e(){var c=$X(b).value;if(c==null||c.trim()==''){return;}c = c.replace(/[\r\n]+/g, '').replace(/'/g, "\\'");var tmp = c.match(/\b(\w+)\b/g).sort();var dict = [];for(var i=0, t=''; i<tmp .length; i++){if(tmp[i] != t) dict.push(t = tmp[i]);}var l = dict.length;for(var i=0, t=''; i<l; i++){c = c.replace(new RegExp('\\b'+dict[i]+'\\b','g'), t = _j(i));if(t == dict[i]) dict[i] = '';}
$X(b).value = "eval(function(p,a,c,k,e,d){e=function(c){return(c<a?'':e(parseInt(c/a)))+((c=c%a)>35?String.fromCharCode(c+29):c.toString(36))};if(!''.replace(/^/,String)){while(c--)d[e(c)]=k[c]||e(c);k=[function(e){return d[e]}];e=function(){return'\\\\w+'};c=1};while(c--)if(k[c])p=p.replace(new RegExp('\\\\b'+e(c)+'\\\\b','g'),k[c]);return p}("+"'"+c+"',"+a+","+l+",'"+ dict.join('|')+"'.split('|'),0,{}))";}
function _j(c){return (c<a ? '':_j(parseInt(c/a)))+((c = c%a)>35?String.fromCharCode(c+29):c.toString(36))}
function _r(){var c=$X(b).value;if(c==null||c.trim()==''){return;}eval(c)}