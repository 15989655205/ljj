<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AD_IDE.ascx.cs" Inherits="Maticsoft.Web.Controls.ADandNotice.AD_IDE" %>
    <script type="text/javascript" src="../../js/jq.common.js"></script>
    <%--<script type="text/javascript" src="../../js/jquery.min.js"></script>--%>
<script type="text/javascript">
    $(function () {
        $('#img_win').window({
            title: '图片',
            width: 400,
            modal: true,
            shadow: true,
            closed: true,
            height: 300,
            resizable: false,
            minimizable: false,
            collapsible: false,
            maximizable: false
        });
        
    })
    function ajaxFileUpload() {
        $.ajaxFileUpload(
                   {
                       url: '../Ashx/ad.ashx?action=upload',            //需要链接到服务器地址
                       secureuri: false,
                       fileElementId: 'uploadify',                        //文件选择框的id属性
                       dataType: 'xml',                                     //服务器返回的格式，可以是json
                       success: function (data, status)            //相当于java中try语句块的用法
                       {
                           alert(data);
                           $("#Upload_info").text("图片上传成功！");
                       },
                       error: function (data, status, e)            //相当于java中catch语句块的用法
                       {

                       }
                   }

               );

    }
    function save() {
        if (!$('#ff').form('validate')) {
            $.messager.show({ title: '错误提示', msg: '验证未通过！' });

        }
        else {

            $('#ff').form('submit', {
                url: '../Ashx/ad.ashx?action=' + action,
                onSubmit: function () { /*做某些检查,返回 false 来阻止提交*/ },
                success: function (data) {
                    if (data.split("|")[1] == "OK") {
                        $('#tt').datagrid("reload");
                        $.messager.show({ title: '系统提示', msg: '保存成功。' });
                    }
                    else {
                        $.messager.show({ title: '系统提示', msg: (data=="success"?"保存成功":data) });
                    }
                }
            });

            }
        
    }

    $.extend($.fn.validatebox.defaults.rules, {
        maxLength: {
            validator: function (value, param) {
                return value.length <= param[0];
            },
            message: '输入不能大于 {0} 字符！'
        }
    }) 

</script>
<div id="img_win">
<form id="ff" method="post" enctype="multipart/form-data" action="">  
    <div>图片名称：<input type="text" id="img_name" name="img_name" class="easyui-validatebox" data-options="required:true,validType:'maxLength[5]'"/></div>
    <div>标&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;题：<input type="text" id="title" name="title" class="easyui-validatebox" data-options="required:true,validType:'maxLength[5]'" /></div>
    <div>
         上传路径：<input type="file" id="uploadify" name="uploadify"/>
        <%--<input type="button" value="上传" onclick="ajaxFileUpload()" />--%>
          <input type="text" id="img_id" name="img_id" style="display:none" /> 
          <input type="text" id="img_load" name="img_load" style="display:none" />
             </div>
          <div>是否显示：<input type="checkbox" id="ckb" name="ckb" /></div>
    <div><input type="button" id="btn_submit" value="保存" onclick="save()" /></div>
    </form>
    
</div>
