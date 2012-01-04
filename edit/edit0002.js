// JScript 文件
KE.show({
            id : 'content1',
            imageUploadJson : 'upload_json.ashx',
            fileManagerJson : 'file_manager_json.ashx',
            allowFileManager : true,
		    afterCreate : function(id) {
			    KE.event.ctrl(document, 13, function() {
				    KE.util.setData(id);
				    document.forms['form1'].submit();
			    });
			    KE.event.ctrl(KE.g[id].iframeDoc, 13, function() {
				    KE.util.setData(id);
				    document.forms['form1'].submit();
			    });
		    }
        });

var errMsg = $E('hd_ErrMsg').value;
if(errMsg!=null && errMsg!='')
{
    alert(errMsg);
    $E('hd_ErrMsg').value='';
}

function editSubmit()
{
    editor.data();
    
    var obj = $E('ck_OverRide');
    if(obj && obj.checked)
    {
        return $W().confirm('此操作将会覆盖服务器上的现有文件，并且不可恢复，确认要执行此操作么？');
    }
    return true;
}
function editPrompt()
{
    var url = $E('tf_FilePath').value;
    if(url == null)
    {
        alert('请输入一个合法的链接地址，如：“http://www.amonsoft.cn/”。');
        $E('tf_FilePath').focus();
        return false;
    }
    url = url.trim();
    if (url == '' || url == 'http://')
    {
        alert('请输入一个合法的链接地址，如：“http://www.amonsoft.cn/”。');
        $E('tf_FilePath').focus();
        return false;
    }
    return true;
}