<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Imgd.aspx.cs" Inherits="Me.Amon.Imgd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<link rel="stylesheet" type="text/css" href="MooFlow.css" />
	<script src="//ajax.googleapis.com/ajax/libs/mootools/1.4.5/mootools-yui-compressed.js"></script>
	<script type="text/javascript" src="MooFlow.js"></script>
<script type="text/javascript">
/* <![CDATA[ */

	var myMooFlowPage = {
	
		start: function(){
			
			var div = new Element('div').inject($('content'), 'top');
			var mf = new MooFlow(div, {
				startIndex: 3,
				offsetY: 40,
				useCaption: true,
				useMouseWheel: true,
				useKeyInput: true,
				useViewer: true,
				onEmptyinit: function(){
					this.loadJSON('skyset.json');
				},
				onClickView: function(obj){
					var a = new Element('a',{
						'class':'remooz-element',
						'href':obj.href,
						'title':obj.title + ' - '+ obj.alt,
						'styles':{'border':'none'}
					});
					var img = new Element('img',{
						'src':obj.src,
						'title':obj.title,
						'alt':obj.alt,
						'styles':obj.coords
					}).setStyles({
						'position':'absolute',
						'border':'none'
					}).inject(a);
					a.inject(document.body);
					var remooz = new ReMooz(a, {
						centered: true,
						resizeFactor: 0.8,
						origin: img,
						onCloseEnd: function(){
							a.destroy();
							delete remooz;
						}
					}).open();
				}
			});
			
		}
		
	};
	
	window.addEvent('domready', myMooFlowPage.start);
	
/* ]]> */
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="content">
    </div>
    </form>
</body>
</html>
