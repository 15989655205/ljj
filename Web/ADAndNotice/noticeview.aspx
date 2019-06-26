<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="noticeview.aspx.cs" Inherits="Maticsoft.Web.ADAndNotice.noticeview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=dt.Rows[0]["title"].ToString()%></title>
     <style type="text/css">
        .div_css{width:80%;margin-left: auto;margin-right: auto;}
    </style>
    <script type="text/javascript" src="../ueditor/ueditor.parse.js"></script>
    <script type="text/javascript">
        setTimeout(
            function () {
                uParse(
                    'div'
                    , {
                        'highlightJsUrl': '../ueditor/third-party/SyntaxHighlighter/shCore.js'
                        , 'highlightCssUrl': '../ueditor/third-party/SyntaxHighlighter/shCoreDefault.css'
                    }
                )
            }
            , 300
        )
   </script>
</head>
<body>
    <table style="width:1000px; margin:0 auto; font-size:14px;">
        <tr>
            <td><h1 style="text-align:center;"><%=dt.Rows[0]["title"].ToString()%></h1></td>	        
        </tr>
        <tr><td style="font-size:12px;float:right;"><%=time%></td></tr>
	    <tr style="line-height:24px; padding-top:20px; font-size:16px">
            <td>
                <p style="border-bottom:1px #000 solid; width:1000px;">概要:</p>
    	        <font style="font-size:12px;"><%=dt.Rows[0]["summary"].ToString()%></font>
            </td>
        </tr>
	    <tr style="line-height:24px; padding-top:20px; font-size:16px">
            <td>
                <p style="border-bottom:1px #000 solid; width:1000px;">简介:</p>
    	        <font style="font-size:12px;"><%=dt.Rows[0]["intro"].ToString()%></font>
            </td>
        </tr>	
        <tr id="notice_content" style="line-height:24px; padding-top:20px; font-size:16px">
            <td>
                <p style="border-bottom:1px #000 solid; width:1000px;">正文:</p>
    	        <div><%=dt.Rows[0]["notice_content"].ToString()%></div>
            </td>
        </tr>
    </table>
</body>
</html>
