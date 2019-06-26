<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Company_IDE.ascx.cs" Inherits="Maticsoft.Web.Controls.BaseInfo.Company_IDE" %>
<div style="margin-left:10px;">
<div class="oaTopDiv" style="width:98%; background-color:White;">
<div style="height:10px"></div>
    <div class="section-header">
        <div class="title">
           <img src="/Images/8.png" alt="" />
        </div>
        <div class="options">
            <input type="button" id="btnSaveButton" value="保存" class="adminButtonBlue" onclick="save();" <%if(!isSave) {%> disabled="disabled"<%} %> />
        </div>
    </div>
</div>
<div style="height:50px;"></div>
<div style="width: 98% ">
<form id="ff" method="post" action="" >
    <input type="hidden" id="sid" name="sid" value="<%=sid %>" />
    <table class="oa_Flow_Tab">
        <tr>
            <td class="titleTD">公司编号</td>
            <td class="inputTD">
                <input type="text" id="txtNumber" name="txtNumber" class="validate[required] oaInput" value="<%=companyModel!=null?companyModel.Number:"" %>" />
            </td>
            <td class="titleTD">负责人</td>
            <td class="inputTD">
                <input type="text" id="txtHead" name="txtHead" class="oaInput" value="<%=companyModel!=null?companyModel.Head:"" %>" />
            </td>
        </tr>
        <tr>
            <td class="titleTD">公司简称</td>
            <td class="inputTD">
                <input type="text" id="txtAbbreviation" name="txtAbbreviation" class="validate[required] oaInput" value="<%=companyModel!=null?companyModel.Abbreviation:""%>"/>
            </td>
            <td class="titleTD">公司名称</td>
            <td class="inputTD">
                <input type="text" id="txtFullName" name="txtFullName" class="validate[required] oaInput" value="<%=companyModel!=null?companyModel.FullName:"" %>" />
            </td>
        </tr>       
         <tr>
            <td class="titleTD">址址</td>
            <td class="inputTD">
                <input type="text" id="txtAddress" name="txtAddress" class="validate[required] oaInput" value="<%=companyModel!=null?companyModel.Address:"" %>" />
            </td>
            <td class="titleTD">英文地址</td>
            <td class="inputTD">
                <input type="text" id="txtEnAddress" name="txtEnAddress" class="oaInput" value="<%=companyModel!=null?companyModel.EnAddress:"" %>" />
            </td>
        </tr>
        <tr>
            <td class="titleTD">电话</td>
            <td class="inputTD">
                <input type="text" id="txtFixedPhone" name="txtFixedPhone" class="oaInput" value="<%=companyModel!=null?companyModel.FixedPhone:"" %>" />
            </td>
            <td class="titleTD">移动电话</td>
            <td class="inputTD">
                <input type="text" id="txtMobilePhone" name="txtMobilePhone" class="oaInput" value="<%=companyModel!=null?companyModel.MobilePhone:"" %>" />
            </td>
        </tr>
         <tr>
            <td class="titleTD">传真</td>
            <td class="inputTD">
                <input type="text" id="txtFax" name="txtFax" class="oaInput" value="<%=companyModel!=null?companyModel.Fax:"" %>" />
            </td>       
            <td class="titleTD">邮编</td>
            <td class="inputTD">
                <input type="text" id="txtZipCode" name="txtZipCode" class="oaInput" value="<%=companyModel!=null?companyModel.ZipCode:"" %>" />
            </td>
        </tr>
         <tr>
            <td class="titleTD">开户银行 </td>
            <td class="inputTD">
                <input type="text" id="txtOpeningBank" name="txtOpeningBank" class="validate[required] oaInput" value="<%=companyModel!=null?companyModel.OpeningBank:"" %>" />
            </td>      
            <td class="titleTD">帐号</td>
            <td class="inputTD">
                <input type="text" id="txtAccount" name="txtAccount" class="validate[required] oaInput" value="<%=companyModel!=null?companyModel.Account:"" %>" />
            </td>
        </tr>
         <tr>
            <td class="titleTD">代码</td>
            <td class="inputTD">
                <input type="text" id="txtCustomsCode" name="txtCustomsCode" class="validate[required] oaInput" value="<%=companyModel!=null?companyModel.CustomsCode:"" %>" />
            </td>        
            <td class="titleTD">法定代表人</td>
            <td class="inputTD">
                <input type="text" id="txtLegalRepresentative" name="txtLegalRepresentative" class="validate[required] oaInput" value="<%=companyModel!=null?companyModel.LegalRepresentative:"" %>" />
            </td>
        </tr>
         <tr>
            <td class="titleTD">备注</td>
            <td class="inputTD" colspan="3">
                <textarea id="txtRemark" name="txtRemark" rows="5" cols="10" class="textarea"
                    onkeyup="this.style.height = (this.scrollHeight-8<=100?100:this.scrollHeight-4) + 'px';"
                    onkeydown="this.style.height = (this.scrollHeight-8<=100?100:this.scrollHeight-4) + 'px';"
                    onpropertychange="this.style.height = (this.scrollHeight-8<=100?100:this.scrollHeight-4) + 'px';"
                    oninput="this.style.height = (this.scrollHeight-8<=100?100:this.scrollHeight-4) + 'px';"><%=companyModel != null ? companyModel.Remark : ""%></textarea>
            </td>
        </tr>
     </table>
    </form>
 
 </div>
 </div>
<script type="text/javascript">
    var type = "<%=type %>";
    var sumbitURL = "";
    var isload = false;

    $(function () {
        if (!isload) {
            //验证初始化
            jQuery("#ff").validationEngine({ showOnMouseOver: false, promptPosition: 'topLeft', autoHidePrompt: true, autoHideDelay: 2000 });
            var txtNumber = document.getElementById("txtNumber");
            var txtAbbreviation = document.getElementById("txtAbbreviation");
            var txtFullName = document.getElementById("txtFullName");
            var txtAddress = document.getElementById("txtAddress");
            var txtEnAddress = document.getElementById("txtEnAddress");
            var txtHead = document.getElementById("txtHead");
            var txtFixedPhone = document.getElementById("txtFixedPhone");
            var txtMobilePhone = document.getElementById("txtMobilePhone");
            var txtFax = document.getElementById("txtFax");
            var txtZipCode = document.getElementById("txtZipCode");
            var txtOpeningBank = document.getElementById("txtOpeningBank");
            var txtAccount = document.getElementById("txtAccount");
            var txtCustomsCode = document.getElementById("txtCustomsCode");
            var txtAbbreviation = document.getElementById("txtAbbreviation");


            switch (type) {
                case "add":
                    sumbitURL = "../Ashx/Company.ashx?action=add";
                    break;
                case "copy":
                    sumbitURL = "../Ashx/Company.ashx?action=add";
                    break;
                case "update":
                    sumbitURL = "../Ashx/Company.ashx?action=update";
                    break;
                case "view":
                    txtNumber.readOnly = true;
                    txtNumber.className = "oaInputReadonly";
                    txtNumber.parentNode.className = "";
                    txtAbbreviation.readOnly = true;
                    txtAbbreviation.className = "oaInputReadonly";
                    txtAbbreviation.parentNode.className = "";
                    txtFullName.readOnly = true;
                    txtFullName.className = "oaInputReadonly";
                    txtFullName.parentNode.className = "";
                    txtAddress.readOnly = true;
                    txtAddress.className = "oaInputReadonly";
                    txtAddress.parentNode.className = "";
                    txtEnAddress.readOnly = true;
                    txtEnAddress.className = "oaInputReadonly";
                    txtEnAddress.parentNode.className = "";
                    txtHead.readOnly = true;
                    txtHead.className = "oaInputReadonly";
                    txtHead.parentNode.className = "";
                    txtFixedPhone.readOnly = true;
                    txtFixedPhone.className = "oaInputReadonly";
                    txtFixedPhone.parentNode.className = "";
                    txtMobilePhone.readOnly = true;
                    txtMobilePhone.className = "oaInputReadonly";
                    txtMobilePhone.parentNode.className = "";
                    txtFax.readOnly = true;
                    txtFax.className = "oaInputReadonly";
                    txtFax.parentNode.className = "";
                    txtZipCode.readOnly = true;
                    txtZipCode.className = "oaInputReadonly";
                    txtZipCode.parentNode.className = "";
                    txtOpeningBank.readOnly = true;
                    txtOpeningBank.className = "oaInputReadonly";
                    txtOpeningBank.parentNode.className = "";
                    txtAccount.readOnly = true;
                    txtAccount.className = "oaInputReadonly";
                    txtAccount.parentNode.className = "";
                    txtCustomsCode.readOnly = true;
                    txtCustomsCode.className = "oaInputReadonly";
                    txtCustomsCode.parentNode.className = "";
                    txtAbbreviation.readOnly = true;
                    txtAbbreviation.className = "textareaReadonly";
                    txtAbbreviation.parentNode.className = "";
                    break;
                default:
                    break;
            }
            isload = true;
        }
    });

    function sumbitData() {
        $('#ff').form('submit', {
            url: sumbitURL,
            onSubmit: function () {
                // 做某些检查   
                // 返回 false 来阻止提交
                //                jQuery('#ff').validationEngine('validate');
                //                window.setInterval(jQuery('#ff').validationEngine('hide'), 5000); 
            },
            success: function (data) {
                //var agr1 = data.split("|")[0];
                //var agr2 = data.split("|")[1];
                //$.messager.show({ title: '', msg: agr1 });

                //if (agr1 == "success") {
                if (data == "success") {
                    //$("#btnSaveButton").attr('disabled', false);
                    //CloseLoading();
                    //$.messager.show({ title: '提示', msg: "保存成功！" });
                    var title = parent.$('#tabs').tabs("getSelected").panel('options').title;
                    parent.Tab_OC("公司基本资料", title, "BaseInfo/CompanyInformation.aspx", "",true);
                }
                else {
                    $("#btnSaveButton").attr('disabled', false);
                    CloseLoading();
                }
            }
        });
    }

    function save() {
        $("#btnSaveButton").attr('disabled', true);

        if (jQuery('#ff').validationEngine('validate')) {
            OpenLoading("Processing,please wait...");
            sumbitData();
        }
        else {
        }
        $("#btnSaveButton").attr('disabled', false);
    }   
</script>
