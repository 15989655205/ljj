﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewTest.aspx.cs" Inherits="Maticsoft.Web.WenKu2.ViewTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
 <head>   
         <title>中勤文库-Flash版</title>           
         <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />   
         <style type="text/css" media="screen">   
             html, body    { height:100%; }  
             body { margin:0; padding:0; overflow:auto; }     
             #flashContent { display:none; }
 </style>   
           
         <script type="text/javascript" src="../WenKu2/js/swfobject/swfobject.js"></script> 
         <script type="text/javascript" src="../WenKu2/js/flexpaper_flash_debug.js"></script> 
         <script type="text/javascript" src="../WenKu2/js/jquery.js"></script> 
         <script>
             //获得参数的方法  
             var request =
         {
             QueryString: function (val) {
                 var uri = window.location.search;
                 var re = new RegExp("" + val + "=([^&?]*)", "ig");
                 return ((uri.match(re)) ? (uri.match(re)[0].substr(val.length + 1)) : null);
             }
         }  
 </script>   
         <script type="text/javascript">   
// <!-- For version detection, set to min. required Flash Player version, or 0 (or 0.0.0), for no version detection. -->   
 var swfVersionStr = "10.0.0";  
// <!-- To use express install, set to playerProductInstall.swf, otherwise the empty string. --> 
 var xiSwfUrlStr = "playerProductInstall.swf";  
 var swfFile = "Paper.swf"//emotion;//这填写文档转换成的flash文件的路径  
               
 var flashvars = {   
                   SwfFile : escape(swfFile),  
                   Scale : 0.6,   
                   ZoomTransition : "easeOut",  
                   ZoomTime : 0.5,  
                     ZoomInterval : 0.2,  
                     FitPageOnLoad : true,  
                     FitWidthOnLoad : false,  
                     PrintEnabled : true,  
                     FullScreenAsMaxWindow : false,  
                     ProgressiveLoading : true,  
                       
                     PrintToolsVisible : true,  
                     ViewModeToolsVisible : true,  
                     ZoomToolsVisible : true,  
                     FullScreenVisible : true,  
                     NavToolsVisible : true,  
                     CursorToolsVisible : true,  
                     SearchToolsVisible : true,  
                       
                     localeChain: "en_US"  
                   };  
                     
 var params = {  
                   
                 }  
             params.quality = "high";  
             params.bgcolor = "#ffffff";  
             params.allowscriptaccess = "sameDomain";  
             params.allowfullscreen = "true";  
 var attributes = {};  
             attributes.id = "FlexPaperViewer";  
             attributes.name = "FlexPaperViewer";  
             swfobject.embedSWF(
 "FlexPaperViewer.swf", "flashContent",   
 "730", "580",  
                 swfVersionStr, xiSwfUrlStr,   
                 flashvars, params, attributes);  
             swfobject.createCSS("#flashContent", "display:block;text-align:left;");  
               
 </script> 
   
           
     </head>   
     <body>
         <div align="center"> 
             <div id="flashContent">   
                 <p>   
                     To view this page ensure that Adobe Flash Player version   
                     10.0.0 or greater is installed.   
                 </p>   
                 <script type="text/javascript">
                     var pageHost = ((document.location.protocol == "https:") ? "https://" : "http://");
                     document.write("<a href='http://www.adobe.com/go/getflashplayer'><img src='"
 + pageHost + "www.adobe.com/images/shared/download_buttons/get_flash_player.gif' alt='Get Adobe Flash player' /></a>");   
                       
 </script>   
             </div> 
         </div> 
           
    </body>   
 </html> 
