

//检测文本框是否超出最大值
function handleTextAreaElementChange(a, b, c, d) {
    textAreaTimer && clearTimeout(textAreaTimer);
    textAreaTimer = setTimeout(function () {
        return handleTextAreaElementChangeWithByteCheck(a, b, 0, c, d)
    }, 500)
}
//    onchange="handleTextAreaElementChangeWithByteCheck('acc20', 32000, 0, '剩余', '超出极限');" 
function handleTextAreaElementChangeWithByteCheck(a, b, c, d, e) {
    var f = document.getElementById(a),
            a = document.getElementById(a + "_counter"),
             g = 0; if (!f || !a) return b;
    var k = f.value.length; if (0 < k && !isIE && !isIE5) {
        var l = f.value.match(/\n/g);
        l && (g = l.length)
    } b -= k + g; 50 < b && 0 < c && (k = unescape(encodeURIComponent(f.value)).length, c -= k + g, 50 > c && (b = c));
    0 > b ? (a.parentNode.className = "textCounterMiddle over", a.innerHTML = -1 * b + " " + e) : 50 > b ? (a.parentNode.className = "textCounterMiddle warn", a.innerHTML = b + " " + d) : a.parentNode.className =
"textCounterMiddle"
}


// 限制文本框只能输入数字
function InputLimitsNumber() {
    if (((event.keyCode > 47) && (event.keyCode < 58)) ||
                     (event.keyCode == 8)) {
        return true;
    } else {
        return false;
    }
}

//  如果文本框的内容不是由数字组成，则清除掉
function ClearNotNumber() {
    if (!IsNumber(event.srcElement.value)) {
        event.srcElement.value = "";
    }
}

// 判断是否全部字符是由数字组成的
function IsNumber(str) {
    var reNumber = /^\d+$/;
    return reNumber.test(str);
}


// 限制文本框只能输入正浮点数
function InputLimitsPositiveFloat() {
    //1.数字可以输入
    if (((event.keyCode > 47) && (event.keyCode < 58)) ||
                     (event.keyCode == 8)) {
        return true;
    } else {
        //2.如果输入为.时
        if (event.keyCode == 46) {
            var newvalue = event.srcElement.value + ".";
            if (IsPositiveFloat(newvalue)) {
                event.srcElement.value = event.srcElement.value + ".";
            }
            return false;
        }
        return false;
    }
}

// 如果文本框里的不是浮点数，则清除掉
function ClearNotPositiveFloat() {
    if (!IsPositiveFloat(event.srcElement.value)) {
        event.srcElement.value = "";
    }
}


// 限制文本框只能输入正负浮点数
function InputLimitsPositiveNegativeFloatOlder() {
    //1.数字可以输入
    if (((event.keyCode > 47) && (event.keyCode < 58)) ||
                     (event.keyCode == 8) || (event.keyCode == 45)) {
        return true;
    } else {
        //2.如果输入为.时
        if (event.keyCode == 46) {
            var newvalue = event.srcElement.value + ".";
            if (IsPositiveFloat(newvalue)) {
                event.srcElement.value = event.srcElement.value + ".";
            }
            return false;
        }
        return false;
    }
}
// 如果文本框里的不是正负浮点数，则清除掉
function InputLimitsPositiveNegativeFloat(str) {
    var rePositiveFloat = /^-|\d+(\.\d*)?$/;
    return rePositiveFloat.test(str);
}
// 如果文本框里的不是浮点数，则清除掉
function ClearNotPositiveNegativeFloat() {
    if (!InputLimitsPositiveNegativeFloat(event.srcElement.value)) {
        event.srcElement.value = "";
    }
}


// 判断是否浮点数
function IsPositiveFloat(str) {
    var rePositiveFloat = /^\d+(\.\d*)?$/;
    return rePositiveFloat.test(str);
}


// 过滤Datetime,如果为1900/01/01的就返回 ''
function FilterNullDate(str) {
    if (DateIsNull(str)) {
        return "";
    }
    return str;
}

// 判断日期是不是为1900/01/01
function DateIsNull(str) {
    var dt1 = new Date(str);
    var dt2 = new Date("1900/01/01");
    if (dt1.toString() == dt2.toString()) {
        return true;
    }
    else {
        return false;
    }
}

//检测某一字符在字符串出现的次数
function getCount(str1, str2) {
//    var r = new RegExp('\\' + str2, "gi");
    //    return str1.match(r).length;
    //str1.match(/\str2/gi).length;
    return str1.match(/\str2/g).length;
}



// 获取新序号

function GetNewNumber(name) {
    var maxNumber = 0;
    var txtNumbers = $("input[name^='" + name + "']").toArray();
    for (var i = 0; i < txtNumbers.length; i++) {
        if (maxNumber < parseInt(txtNumbers[i].value, 10)) {
            maxNumber = parseInt(txtNumbers[i].value, 10);
        }
    }
    var newNumber = 0;
    newNumber = 10010 + maxNumber;
    newNumber = newNumber.toString().substring(1, 5);
    return newNumber;
}


// 检查有没有重复的序号

function NumberHasRepeated(name) {
    var numbers = "";
    var txtNumbers = $("input[name^='" + name + "']").toArray();
    if (txtNumbers.length > 0) {
        for (var i = 0; i < txtNumbers.length; i++) {
            numbers += txtNumbers[i].value + "-";
        }
        for (var i = 0; i < txtNumbers.length; i++) {
            if (numbers.replace(txtNumbers[i].value, "").indexOf(txtNumbers[i].value) > -1) {
                return true;
            }
        }
    }
    return false;
}


// 根据其中一列纵向合并table
function VMTable(tableId, byC, vmC) {
    //alert("begin");
    var table = document.getElementById(tableId);
    var vmBegin = 1;
    var vmEnd = vmBegin;
    var byCIndex = byC
    var vmCs = vmC.split(",");
    //alert(vmCs);

    //如果行数少于1
    if (table.rows.length < 1) {
        return;
    }


    //如果指定的列超出索引
    if (byCIndex >= table.rows[vmBegin].cells.length) {
        return;
    }

    for (var i = vmBegin; vmBegin < table.rows.length; i = vmBegin) {
        for (var nextIndex = i + 1; nextIndex < table.rows.length; nextIndex++) {
            var cell1 = table.rows[i].cells[byCIndex].innerHTML;
            var cell2 = table.rows[nextIndex].cells[byCIndex].innerHTML;
            if (cell1 == cell2) {
                vmEnd++;
            }
            else {
                break;
            }
        }
        if (vmBegin != vmEnd) {
            for (var cIndex = 0; cIndex < table.rows[vmBegin].cells.length; cIndex++) {
                if (ExistValue(vmCs, cIndex)) {
                    var rowSpan = vmEnd - vmBegin + 1;
                    // alert("vmEnd:" + vmEnd + " vmBegin:" + vmBegin + " rowSpan:" + rowSpan);
                    table.rows[vmBegin].cells[cIndex].rowSpan = rowSpan;
                    for (var displayIndex = vmBegin + 1; displayIndex <= vmEnd; displayIndex++) {
                        table.rows[displayIndex].cells[cIndex].style.display = 'none';
                    }
                }
            }
        }
        vmBegin = vmEnd + 1;
        vmEnd = vmBegin;
    }
}

function srVMTable(tableId, rowbegin, byC, vmC) {
    //alert("begin");
    var table = document.getElementById(tableId);
    var vmBegin = rowbegin;
    var vmEnd = vmBegin;
    var byCIndex = byC
    var vmCs = vmC.split(",");
    //alert(vmCs);

    //如果行数少于1
    if (table.rows.length < 1) {
        return;
    }


    //如果指定的列超出索引
    if (byCIndex >= table.rows[vmBegin].cells.length) {
        return;
    }

    for (var i = vmBegin; vmBegin < table.rows.length; i = vmBegin) {
        for (var nextIndex = i + 1; nextIndex < table.rows.length; nextIndex++) {
            var cell1 = table.rows[i].cells[byCIndex].innerHTML;
            var cell2 = table.rows[nextIndex].cells[byCIndex].innerHTML;
            if (cell1 == cell2) {
                vmEnd++;
            }
            else {
                break;
            }
        }
        if (vmBegin != vmEnd) {
            for (var cIndex = 0; cIndex < table.rows[vmBegin].cells.length; cIndex++) {
                if (ExistValue(vmCs, cIndex)) {
                    var rowSpan = vmEnd - vmBegin + 1;
                    // alert("vmEnd:" + vmEnd + " vmBegin:" + vmBegin + " rowSpan:" + rowSpan);
                    table.rows[vmBegin].cells[cIndex].rowSpan = rowSpan;
                    for (var displayIndex = vmBegin + 1; displayIndex <= vmEnd; displayIndex++) {
                        table.rows[displayIndex].cells[cIndex].style.display = 'none';
                    }
                }
            }
        }
        vmBegin = vmEnd + 1;
        vmEnd = vmBegin;
    }
}

function ExistValue(array, value) {
    for (var i = 0; i < array.length; i++) {
        if (array[i] == value)
            return true;
    }
    return false;
}


//根据VALUE获取TEXT
function GetTextByValue(array, value) {
    for (var i = 0; i < array.length; i++) {
        if (array[i].value == value) {
            return array[i].text;
        }
    }
}

//start 时间比较
function comptime(beginTime, endTime) {
    //var beginTime = "2009-09-21 18:08:08";
    //var endTime = "2009-09-21 8:08:06";
    var beginTimes = beginTime.replace(new RegExp('/', 'g'), '-').substring(0, 10).split('-');
    var endTimes = endTime.replace(new RegExp('/', 'g'), '-').substring(0, 10).split('-');

    beginTime = beginTimes[1] + '/' + beginTimes[2] + '/' + beginTimes[0] + beginTime.substring(10, 19);
    endTime = endTimes[1] + '/' + endTimes[2] + '/' + endTimes[0] + endTime.substring(10, 19);

    //alert(beginTime + "aaa" + endTime);
    //alert(Date.parse(endTime));
    //alert(Date.parse(beginTime));
    var a = (Date.parse(endTime) - Date.parse(beginTime)) / 3600 / 1000;
    if (a < 0) {
        //alert("endTime小!");
        return 1;
    } else if (a > 0) {
        //alert("endTime大!");
        return 2;
    } else if (a == 0) {
        //alert("时间相等!");
        return 0;
    } else {
        //return 'exception'
        return -1;
    }
}
//end 时间比较

//replaceall
String.prototype.replaceAll = function (reallyDo, replaceWith, ignoreCase) {
    if (!RegExp.prototype.isPrototypeOf(reallyDo)) {
        return this.replace(new RegExp(reallyDo, (ignoreCase ? "gi" : "g")), replaceWith);
    } else {
        return this.replace(reallyDo, replaceWith);
    }
}
//replaceall end

//<!--
// Trim() , Ltrim() , RTrim()

String.prototype.Trim = function () {
    return this.replace(/(^\s*)|(\s*$)/g, "");
}

String.prototype.LTrim = function () {
    return this.replace(/(^\s*)/g, "");
}

String.prototype.RTrim = function () {
    return this.replace(/(\s*$)/g, "");
}

String.prototype.CommaTrim = function () {
    return this.replace(/(^,*)|(,*$)/g, "");
}

String.prototype.Format = function (format) {
    if (this != null) {
        var value = this.replace(/-/g, "/");
        var date = new Date(value);
        return date.format(format);
    }
    else {
        return "";
    }
}

Date.prototype.format = function (format) //author: meizz 
{
    if (this == 'Invalid Date' || this == 'NaN') return "";

    var o = {
        "M+": this.getMonth() + 1, //month 
        "d+": this.getDate(),    //day 
        "h+": this.getHours(),   //hour 
        "m+": this.getMinutes(), //minute 
        "s+": this.getSeconds(), //second 
        "q+": Math.floor((this.getMonth() + 3) / 3),  //quarter 
        "S": this.getMilliseconds() //millisecond 
    }
    if (/(y+)/.test(format)) format = format.replace(RegExp.$1,
    (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o) if (new RegExp("(" + k + ")").test(format))
        format = format.replace(RegExp.$1,
      RegExp.$1.length == 1 ? o[k] :
        ("00" + o[k]).substr(("" + o[k]).length));
    return format;
}

//---------------------------------------------------  
// 判断闰年  
//---------------------------------------------------  
Date.prototype.isLeapYear = function()   
{   
    return (0==this.getYear()%4&&((this.getYear()%100!=0)||(this.getYear()%400==0)));   
}   
  
//---------------------------------------------------  
// 日期格式化  
// 格式 YYYY/yyyy/YY/yy 表示年份  
// MM/M 月份  
// W/w 星期  
// dd/DD/d/D 日期  
// hh/HH/h/H 时间  
// mm/m 分钟  
// ss/SS/s/S 秒  
//---------------------------------------------------  
Date.prototype.Format = function(formatStr)   
{   
    var str = formatStr;   
    var Week = ['日','一','二','三','四','五','六'];  
  
    str=str.replace(/yyyy|YYYY/,this.getFullYear());   
    str=str.replace(/yy|YY/,(this.getYear() % 100)>9?(this.getYear() % 100).toString():'0' + (this.getYear() % 100));   
  
    str=str.replace(/MM/,this.getMonth()>9?this.getMonth().toString():'0' + this.getMonth());   
    str=str.replace(/M/g,this.getMonth());   
  
    str=str.replace(/w|W/g,Week[this.getDay()]);   
  
    str=str.replace(/dd|DD/,this.getDate()>9?this.getDate().toString():'0' + this.getDate());   
    str=str.replace(/d|D/g,this.getDate());   
  
    str=str.replace(/hh|HH/,this.getHours()>9?this.getHours().toString():'0' + this.getHours());   
    str=str.replace(/h|H/g,this.getHours());   
    str=str.replace(/mm/,this.getMinutes()>9?this.getMinutes().toString():'0' + this.getMinutes());   
    str=str.replace(/m/g,this.getMinutes());   
  
    str=str.replace(/ss|SS/,this.getSeconds()>9?this.getSeconds().toString():'0' + this.getSeconds());   
    str=str.replace(/s|S/g,this.getSeconds());   
  
    return str;   
}   
  
//+---------------------------------------------------  
//| 求两个时间的天数差 日期格式为 YYYY-MM-dd   
//+---------------------------------------------------  
function daysBetween(DateOne,DateTwo)  
{   
    var OneMonth = DateOne.substring(5,DateOne.lastIndexOf ('-'));  
    var OneDay = DateOne.substring(DateOne.length,DateOne.lastIndexOf ('-')+1);  
    var OneYear = DateOne.substring(0,DateOne.indexOf ('-'));  
  
    var TwoMonth = DateTwo.substring(5,DateTwo.lastIndexOf ('-'));  
    var TwoDay = DateTwo.substring(DateTwo.length,DateTwo.lastIndexOf ('-')+1);  
    var TwoYear = DateTwo.substring(0,DateTwo.indexOf ('-'));  
  
    var cha=((Date.parse(OneMonth+'/'+OneDay+'/'+OneYear)- Date.parse(TwoMonth+'/'+TwoDay+'/'+TwoYear))/86400000);   
    return Math.abs(cha);  
}  
  
  
//+---------------------------------------------------  
//| 日期计算  
//+---------------------------------------------------  
Date.prototype.DateAdd = function(strInterval, Number) {   
    var dtTmp = this;  
    switch (strInterval) {   
        case 's' :return new Date(Date.parse(dtTmp) + (1000 * Number));  
        case 'n' :return new Date(Date.parse(dtTmp) + (60000 * Number));  
        case 'h' :return new Date(Date.parse(dtTmp) + (3600000 * Number));  
        case 'd' :return new Date(Date.parse(dtTmp) + (86400000 * Number));  
        case 'w' :return new Date(Date.parse(dtTmp) + ((86400000 * 7) * Number));  
        case 'q' :return new Date(dtTmp.getFullYear(), (dtTmp.getMonth()) + Number*3, dtTmp.getDate(), dtTmp.getHours(), dtTmp.getMinutes(), dtTmp.getSeconds());  
        case 'm' :return new Date(dtTmp.getFullYear(), (dtTmp.getMonth()) + Number, dtTmp.getDate(), dtTmp.getHours(), dtTmp.getMinutes(), dtTmp.getSeconds());  
        case 'y' :return new Date((dtTmp.getFullYear() + Number), dtTmp.getMonth(), dtTmp.getDate(), dtTmp.getHours(), dtTmp.getMinutes(), dtTmp.getSeconds());  
    }  
}  
  
//+---------------------------------------------------  
//| 比较日期差 dtEnd 格式为日期型或者有效日期格式字符串  
//+---------------------------------------------------  
Date.prototype.DateDiff = function(strInterval, dtEnd) {   
    var dtStart = this;  
    if (typeof dtEnd == 'string' )//如果是字符串转换为日期型  
    {   
        dtEnd = StringToDate(dtEnd);  
    }  
    switch (strInterval) {   
        case 's' :return parseInt((dtEnd - dtStart) / 1000);  
        case 'n' :return parseInt((dtEnd - dtStart) / 60000);  
        case 'h' :return parseInt((dtEnd - dtStart) / 3600000);  
        case 'd' :return parseInt((dtEnd - dtStart) / 86400000);  
        case 'w' :return parseInt((dtEnd - dtStart) / (86400000 * 7));  
        case 'm' :return (dtEnd.getMonth()+1)+((dtEnd.getFullYear()-dtStart.getFullYear())*12) - (dtStart.getMonth()+1);  
        case 'y' :return dtEnd.getFullYear() - dtStart.getFullYear();  
    }  
}  
  
//+---------------------------------------------------  
//| 日期输出字符串，重载了系统的toString方法  
//+---------------------------------------------------  
Date.prototype.toString = function(showWeek)  
{   
    var myDate= this;  
    var str = myDate.toLocaleDateString();  
    if (showWeek)  
    {   
        var Week = ['日','一','二','三','四','五','六'];  
        str += ' 星期' + Week[myDate.getDay()];  
    }  
    return str;  
}  
  
//+---------------------------------------------------  
//| 日期合法性验证  
//| 格式为：YYYY-MM-DD或YYYY/MM/DD  
//+---------------------------------------------------  
function IsValidDate(DateStr)   
{   
    var sDate=DateStr.replace(/(^\s+|\s+$)/g,''); //去两边空格;   
    if(sDate=='') return true;   
    //如果格式满足YYYY-(/)MM-(/)DD或YYYY-(/)M-(/)DD或YYYY-(/)M-(/)D或YYYY-(/)MM-(/)D就替换为''   
    //数据库中，合法日期可以是:YYYY-MM/DD(2003-3/21),数据库会自动转换为YYYY-MM-DD格式   
    var s = sDate.replace(/[\d]{ 4,4 }[\-/]{ 1 }[\d]{ 1,2 }[\-/]{ 1 }[\d]{ 1,2 }/g,'');   
    if (s=='') //说明格式满足YYYY-MM-DD或YYYY-M-DD或YYYY-M-D或YYYY-MM-D   
    {   
        var t=new Date(sDate.replace(/\-/g,'/'));   
        var ar = sDate.split(/[-/:]/);   
        if(ar[0] != t.getYear() || ar[1] != t.getMonth()+1 || ar[2] != t.getDate())   
        {   
            //alert('错误的日期格式！格式为：YYYY-MM-DD或YYYY/MM/DD。注意闰年。');   
            return false;   
        }   
    }   
    else   
    {   
        //alert('错误的日期格式！格式为：YYYY-MM-DD或YYYY/MM/DD。注意闰年。');   
        return false;   
    }   
    return true;   
}   
  
//+---------------------------------------------------  
//| 日期时间检查  
//| 格式为：YYYY-MM-DD HH:MM:SS  
//+---------------------------------------------------  
function CheckDateTime(str)  
{   
    var reg = /^(\d+)-(\d{ 1,2 })-(\d{ 1,2 }) (\d{ 1,2 }):(\d{ 1,2 }):(\d{ 1,2 })$/;   
    var r = str.match(reg);   
    if(r==null)return false;   
    r[2]=r[2]-1;   
    var d= new Date(r[1],r[2],r[3],r[4],r[5],r[6]);   
    if(d.getFullYear()!=r[1])return false;   
    if(d.getMonth()!=r[2])return false;   
    if(d.getDate()!=r[3])return false;   
    if(d.getHours()!=r[4])return false;   
    if(d.getMinutes()!=r[5])return false;   
    if(d.getSeconds()!=r[6])return false;   
    return true;   
}   
  
//+---------------------------------------------------  
//| 把日期分割成数组  
//+---------------------------------------------------  
Date.prototype.toArray = function()  
{   
    var myDate = this;  
    var myArray = Array();  
    myArray[0] = myDate.getFullYear();  
    myArray[1] = myDate.getMonth();  
    myArray[2] = myDate.getDate();  
    myArray[3] = myDate.getHours();  
    myArray[4] = myDate.getMinutes();  
    myArray[5] = myDate.getSeconds();  
    return myArray;  
}  
  
//+---------------------------------------------------  
//| 取得日期数据信息  
//| 参数 interval 表示数据类型  
//| y 年 m月 d日 w星期 ww周 h时 n分 s秒  
//+---------------------------------------------------  
Date.prototype.DatePart = function(interval)  
{   
    var myDate = this;  
    var partStr='';  
    var Week = ['日','一','二','三','四','五','六'];  
    switch (interval)  
    {   
        case 'y' :partStr = myDate.getFullYear();break;  
        case 'm' :partStr = myDate.getMonth()+1;break;  
        case 'd' :partStr = myDate.getDate();break;  
        case 'w' :partStr = Week[myDate.getDay()];break;  
        case 'ww' :partStr = myDate.WeekNumOfYear();break;  
        case 'h' :partStr = myDate.getHours();break;  
        case 'n' :partStr = myDate.getMinutes();break;  
        case 's' :partStr = myDate.getSeconds();break;  
    }  
    return partStr;  
}  
  
//+---------------------------------------------------  
//| 取得当前日期所在月的最大天数  
//+---------------------------------------------------  
Date.prototype.MaxDayOfDate = function()  
{   
    var myDate = this;  
    var ary = myDate.toArray();  
    var date1 = (new Date(ary[0],ary[1]+1,1));  
    var date2 = date1.dateAdd(1,'m',1);  
    var result = dateDiff(date1.Format('yyyy-MM-dd'),date2.Format('yyyy-MM-dd'));  
    return result;  
}  
  
//+---------------------------------------------------  
//| 取得当前日期所在周是一年中的第几周  
//+---------------------------------------------------  
Date.prototype.WeekNumOfYear = function()  
{   
    var myDate = this;  
    var ary = myDate.toArray();  
    var year = ary[0];  
    var month = ary[1]+1;  
    var day = ary[2];  
    document.write('< script language=VBScript\> \n');  
    document.write('myDate = Datue('+month+'-'+day+'-'+year+') \n');  
    document.write('result = DatePart("ww", myDate) \n');  
    document.write(' \n');  
    return result;  
}  
  
//+---------------------------------------------------  
//| 字符串转成日期类型   
//| 格式 MM/dd/YYYY MM-dd-YYYY YYYY/MM/dd YYYY-MM-dd  
//+---------------------------------------------------  
function StringToDate(DateStr)  
{   
  
    var converted = Date.parse(DateStr);  
    var myDate = new Date(converted);  
    if (isNaN(myDate))  
    {   
        //var delimCahar = DateStr.indexOf('/')!=-1?'/':'-';  
        var arys= DateStr.split('-');  
        myDate = new Date(arys[0],--arys[1],arys[2]);  
    }  
    return myDate;  
}  


//不允许退格
function stopBackspace() {
    if (window.event.keyCode == 8)
        window.event.keyCode = 0;
}
//-->

//按钮提交锁屏等待

//$(function () {
//    $("body").append("<div id='loadwin'><div style='text-align:center;width:98%;padding-top:7px;'>" + msg + "<br><br><img align=\"absmiddle\" src='/Jquery/13221827.gif' style='width:130px;height:15px'/></div></div>");
//});

function OpenWindowLoading(msg) {
    if (document.getElementById("loadwin") == null || document.getElementById("loadwin") == undefined) {
        $("body").append("<div id='loadwin'><div style='text-align:center;width:98%;padding-top:7px;'>" + msg + "<br><br><img align=\"absmiddle\" src='/Jquery/13221827.gif' style='width:130px;height:15px'/></div></div>");
    }
    $('#loadwin').window({ title: '', collapsible: false, minimizable: false, maximizable: false, modal: true, closable: false
    }).window('open');
}

function CloseWindowLoading() {
    if (document.getElementById("loadwin") == null || document.getElementById("loadwin") == undefined) {
        $("body").append("<div id='loadwin'></div>");
        $('#loadwin').window({});
    }
    $('#loadwin').window('close');
}


function OpenLoading(msg) {
    var msgw, msgh, bordercolor;
    msgw = 200; //提示窗口的宽度 
    msgh = 100; //提示窗口的高度 
    bordercolor = "#336699"; //提示窗口的边框颜色 
    titlecolor = "#99CCFF"; //提示窗口的标题颜色 

    var sWidth, sHeight;
    //sWidth = window.screen.availWidth;
    //sHeight = window.screen.availHeight;
    if (document.body.clientWidth >= document.documentElement.clientWidth) {
        sWidth = document.body.clientWidth;
    }
    else {
        sWidth = document.documentElement.clientWidth;
    }
    if (document.body.scrollHeight >= document.documentElement.clientHeight) {
        sHeight = document.body.scrollHeight;
    }
    else {
        sHeight = document.documentElement.scrollHeight;
    }
    //sWidth = document.documentElement.clientWidth;
    //sHeight = document.documentElement.clientHeight;

    var bgObj = document.createElement("div");

    bgObj.setAttribute('id', 'bgDiv');
    bgObj.style.zIndex = 9998;
    bgObj.style.position = "absolute";
    bgObj.style.top = "0";
    bgObj.style.background = "#777";
    bgObj.style.filter = "progid:DXImageTransform.Microsoft.Alpha(style=3,opacity=25,finishOpacity=75";
    bgObj.style.opacity = "0.6";
    bgObj.style.left = "0";
    bgObj.style.width = sWidth + "px";
    bgObj.style.height = sHeight + "px";
    document.body.appendChild(bgObj);
    var msgObj = document.createElement("div")
    msgObj.setAttribute("id", "msgDiv");
    msgObj.setAttribute("align", "center");
    msgObj.style.zIndex = 9999;
    msgObj.style.position = "absolute";
    msgObj.style.background = "white";
    msgObj.style.font = "12px/1.6em Verdana, Geneva, Arial, Helvetica, sans-serif";
    msgObj.style.border = "1px solid " + bordercolor;
    msgObj.style.width = msgw + "px";
    msgObj.style.height = msgh + "px";
    //msgObj.style.top = (document.documentElement.scrollTop + (sHeight - msgh) / 2) + "px";
    //msgObj.style.left = (sWidth - msgw) / 2 + "px";
    msgObj.style.top = (document.documentElement.scrollTop + (window.screen.availHeight - msgh) / 2) + "px";
    msgObj.style.left = (document.body.clientWidth - msgw) / 2 + "px";
    var title = document.createElement("h4");
    title.setAttribute("id", "msgTitle");
    title.setAttribute("align", "right");
    title.style.zIndex = 9999;
    title.style.margin = "0";
    title.style.padding = "3px";
    title.style.background = bordercolor;
    title.style.filter = "progid:DXImageTransform.Microsoft.Alpha(startX=20, startY=20, finishX=100, finishY=100,style=1,opacity=75,finishOpacity=100);";
    title.style.opacity = "0.75";
    title.style.border = "1px solid " + bordercolor;
    title.style.height = "18px";
    title.style.font = "12px Verdana, Geneva, Arial, Helvetica, sans-serif";
    title.style.color = "white";
    //title.style.cursor = "pointer";
    //title.innerHTML = "关闭";
    //title.onclick = closediv;
    document.body.appendChild(msgObj);
    document.getElementById("msgDiv").appendChild(title);
    var txt = document.createElement("p");
    txt.style.margin = "1em 0"
    txt.setAttribute("id", "msgTxt");
    //txt.innerHTML = msg;
    //txt.innerHTML = "<div id='loadwin'><div style='text-align:center;width:98%;padding-top:7px;'>" + msg + "<br><br><img align=\"absmiddle\" src='/Jquery/13221827.gif' style='width:130px;height:15px'/></div></div>";
    txt.innerHTML = msg + "<br><br><img align=\"absmiddle\" src='/Images/13221827.gif' style='width:130px;height:15px'/>";
    document.getElementById("msgDiv").appendChild(txt);
}

function OpenLoading_me(msg) {
    var msgw, msgh, bordercolor;
    msgw = 200; //提示窗口的宽度 
    msgh = 100; //提示窗口的高度 
    bordercolor = "#336699"; //提示窗口的边框颜色 
    titlecolor = "#99CCFF"; //提示窗口的标题颜色 

    var sWidth, sHeight;
    sWidth = window.screen.availWidth;
    sHeight = window.screen.availHeight;
//    if (document.body.clientWidth >= document.documentElement.clientWidth) {
//        sWidth = document.body.clientWidth;
//    }
//    else {
//        sWidth = document.documentElement.clientWidth;
//    }
//    if (document.body.scrollHeight >= document.documentElement.clientHeight) {
//        sHeight = document.body.scrollHeight;
//    }
//    else {
//        sHeight = document.documentElement.scrollHeight;
//    }
//    //sWidth = document.documentElement.clientWidth;
//    //sHeight = document.documentElement.clientHeight;

    var bgObj = document.createElement("div");

    bgObj.setAttribute('id', 'bgDiv');
    bgObj.style.zIndex = 9998;
    bgObj.style.position = "absolute";
    bgObj.style.top = "0";
    bgObj.style.background = "#777";
    bgObj.style.filter = "progid:DXImageTransform.Microsoft.Alpha(style=3,opacity=25,finishOpacity=75";
    bgObj.style.opacity = "0.6";
    bgObj.style.left = "0";
    bgObj.style.width = sWidth + "px";
    bgObj.style.height = sHeight + "px";
    document.body.appendChild(bgObj);
    var msgObj = document.createElement("div")
    msgObj.setAttribute("id", "msgDiv");
    msgObj.setAttribute("align", "center");
    msgObj.style.zIndex = 9999;
    msgObj.style.position = "absolute";
    msgObj.style.background = "white";
    msgObj.style.font = "12px/1.6em Verdana, Geneva, Arial, Helvetica, sans-serif";
    msgObj.style.border = "1px solid " + bordercolor;
    msgObj.style.width = msgw + "px";
    msgObj.style.height = msgh + "px";
    //msgObj.style.top = (document.documentElement.scrollTop + (sHeight - msgh) / 2) + "px";
    //msgObj.style.left = (sWidth - msgw) / 2 + "px";
    msgObj.style.top = ((document.documentElement.clientHeight - msgh) / 2) + "px";
    msgObj.style.left = (document.body.clientWidth - msgw) / 2 + "px";
    var title = document.createElement("h4");
    title.setAttribute("id", "msgTitle");
    title.setAttribute("align", "right");
    title.style.zIndex = 9999;
    title.style.margin = "0";
    title.style.padding = "3px";
    title.style.background = bordercolor;
    title.style.filter = "progid:DXImageTransform.Microsoft.Alpha(startX=20, startY=20, finishX=100, finishY=100,style=1,opacity=75,finishOpacity=100);";
    title.style.opacity = "0.75";
    title.style.border = "1px solid " + bordercolor;
    title.style.height = "18px";
    title.style.font = "12px Verdana, Geneva, Arial, Helvetica, sans-serif";
    title.style.color = "white";
    //title.style.cursor = "pointer";
    //title.innerHTML = "关闭";
    //title.onclick = closediv;
    document.body.appendChild(msgObj);
    document.getElementById("msgDiv").appendChild(title);
    var txt = document.createElement("p");
    txt.style.margin = "1em 0"
    txt.setAttribute("id", "msgTxt");
    //txt.innerHTML = msg;
    //txt.innerHTML = "<div id='loadwin'><div style='text-align:center;width:98%;padding-top:7px;'>" + msg + "<br><br><img align=\"absmiddle\" src='/Jquery/13221827.gif' style='width:130px;height:15px'/></div></div>";
    txt.innerHTML = msg + "<br><br><img align=\"absmiddle\" src='/Images/13221827.gif' style='width:130px;height:15px'/>";
    document.getElementById("msgDiv").appendChild(txt);
}

function CloseLoading() {
    document.body.removeChild(document.getElementById("bgDiv"));
    document.getElementById("msgDiv").removeChild(document.getElementById("msgTitle"));
    document.body.removeChild(document.getElementById("msgDiv"));
}
//end


//关闭等待窗口
function closediv() {
    //Close Div 
    document.body.removeChild(document.getElementById("bgDiv"));
    document.getElementById("msgDiv").removeChild(document.getElementById("msgTitle"));
    document.body.removeChild(document.getElementById("msgDiv"));
}
//显示等待窗口
function showdiv(str) {
    var msgw, msgh, bordercolor;
    msgw = 400; //提示窗口的宽度 
    msgh = 100; //提示窗口的高度 
    bordercolor = "#336699"; //提示窗口的边框颜色 
    titlecolor = "#99CCFF"; //提示窗口的标题颜色 

    var sWidth, sHeight;
    sWidth = window.screen.availWidth;
    sHeight = window.screen.availHeight;

    var bgObj = document.createElement("div");
    bgObj.setAttribute('id', 'bgDiv');
    bgObj.style.position = "absolute";
    bgObj.style.top = "0";
    bgObj.style.background = "#777";
    bgObj.style.filter = "progid:DXImageTransform.Microsoft.Alpha(style=3,opacity=25,finishOpacity=75";
    bgObj.style.opacity = "0.6";
    bgObj.style.left = "0";
    bgObj.style.width = sWidth + "px";
    bgObj.style.height = sHeight + "px";
    document.body.appendChild(bgObj);
    var msgObj = document.createElement("div")
    msgObj.setAttribute("id", "msgDiv");
    msgObj.setAttribute("align", "center");
    msgObj.style.position = "absolute";
    msgObj.style.background = "white";
    msgObj.style.font = "12px/1.6em Verdana, Geneva, Arial, Helvetica, sans-serif";
    msgObj.style.border = "1px solid " + bordercolor;
    msgObj.style.width = msgw + "px";
    msgObj.style.height = msgh + "px";
    msgObj.style.top = (document.documentElement.scrollTop + (sHeight - msgh) / 2) + "px";
    msgObj.style.left = (sWidth - msgw) / 2 + "px";

    var title = document.createElement("h4");
    title.setAttribute("id", "msgTitle");
    title.setAttribute("align", "right");
    title.style.margin = "0";
    title.style.padding = "3px";
    title.style.background = bordercolor;
    title.style.filter = "progid:DXImageTransform.Microsoft.Alpha(startX=20, startY=20, finishX=100, finishY=100,style=1,opacity=75,finishOpacity=100);";
    title.style.opacity = "0.75";
    title.style.border = "1px solid " + bordercolor;
    title.style.height = "18px";
    title.style.font = "12px Verdana, Geneva, Arial, Helvetica, sans-serif";
    title.style.color = "white";
    //title.style.cursor = "pointer";
    //title.innerHTML = "关闭";
    //title.onclick = closediv;
    document.body.appendChild(msgObj);
    document.getElementById("msgDiv").appendChild(title);
    var txt = document.createElement("p");
    txt.style.margin = "1em 0"
    txt.setAttribute("id", "msgTxt");
    txt.innerHTML = str;
    document.getElementById("msgDiv").appendChild(txt);
}
//屏蔽F5
document.onkeydown = mykeydown;
function mykeydown() {
    if (event.keyCode == 116) //屏蔽F5刷新键   
    {
        window.event.keyCode = 0;
        return false;
    }
}

function topLoading() {
    if (document.getElementById("topLoadingDiv") == null || document.getElementById("topLoadingDiv") == undefined) {
        document.write("<div id='topLoadingDiv' class='top_loading'><img border='0' src='../images/loading.gif'/></div>");
    }
    document.getElementById("topLoadingDiv").className = "top_loading";
    document.getElementById("topLoadingDiv").style.left = (document.documentElement.clientWidth - 32) / 2 + "px";
    document.getElementById("topLoadingDiv").style.top = (document.documentElement.clientHeight - 32) / 2 + "px";
}

function topLoaded() {
    if (document.getElementById("topLoadingDiv") != 'null' && document.getElementById("topLoadingDiv") != undefined) {
        document.getElementById("topLoadingDiv").className = "top_loaded";
    }
}


//easyui datagrid 列显示选择
function showColumnMenu(id, lang) {
    var tmenu = $('<div id="tmenu" style="width:150px;"></div>').appendTo('body');
    var fields = $('#' + id).datagrid('getColumnFields');
    for (var i = 0; i < fields.length; i++) {
        var field = $('#' + id).datagrid('getColumnOption', fields[i]);
        $('<div iconCls="icon-ok" id="' + field.field + '"/>').html(field.title).appendTo(tmenu);
        //                $('<div iconCls="icon-ok"/>').html(fields[i]).appendTo(tmenu);
    }
    $('<div class="menu-sep"></div>').appendTo(tmenu);
    $('<div iconCls="icon-ok" id="myfit"/>').html((lang == "cn" ? "自适应宽度" : "Fit Columns")).appendTo(tmenu);
    $('<div class="menu-sep"></div>').appendTo(tmenu);
    $('<div iconCls="icon-save" id="Close"/>').html((lang == "cn" ? "关闭" : "Close")).appendTo(tmenu);
    tmenu.menu({
        onClick: function (item) {
            if (item.iconCls == 'icon-save') {
                $('#tmenu').menu('hide');
            }
            else {
                if (item.iconCls == 'icon-ok') {
                    if (item.id != 'myfit') {
                        $('#' + id).datagrid('hideColumn', item.id);
                        tmenu.menu('setIcon', {
                            target: item.target,
                            iconCls: 'icon-empty'
                        });
                    }
                    else {
                        $('#' + id).datagrid('options').fitColumns = false;
                        //$('#tt').datagrid('reload');
                        tmenu.menu('setIcon', {
                            target: item.target,
                            iconCls: 'icon-empty'
                        });
                    }
                } else {
                    if (item.id != 'myfit') {
                        $('#' + id).datagrid('showColumn', item.id);
                        tmenu.menu('setIcon', {
                            target: item.target,
                            iconCls: 'icon-ok'
                        });
                    }
                    else {
                        $('#' + id).datagrid('options').fitColumns = true;
                        //$('#tt').datagrid('reload');
                        tmenu.menu('setIcon', {
                            target: item.target,
                            iconCls: 'icon-ok'
                        });
                    }
                }
                $('#tmenu').menu('show');
            }
        }
    });
}




//给ckeditor赋值
function ckset(ck, value) {
    var ok = false;
    while (!ok) {
        if (ck != null) {
            ck.focus();
            ck.setData(value);
            ok = true;
        }
        else {

        }
    }
}

function addNum(num1, num2) {
    var sq1, sq2, m;
    try { sq1 = num1.toString().split(".")[1].length; } catch (e) { sq1 = 0; }
    try { sq2 = num2.toString().split(".")[1].length; } catch (e) { sq2 = 0; }

    m = Math.pow(10, Math.max(sq1, sq2));
    return (num1 * m + num2 * m) / m;
}

Array.prototype.in_array = function (elem) {
    var i = this.length;
    while (i--) {
        if (this[i] === elem) {
            return i;
        }
    }
    return -1;
}


    /** 货币格式化函数 **/
	function formatCurrency(num) {
        num = num.toString().replace(/\$|\,/g,'');
        if(isNaN(num))
        num = "0";
        sign = (num == (num = Math.abs(num)));
        num = Math.floor(num*100+0.50000000001);
        cents = num%100;
        num = Math.floor(num/100).toString();
        if(cents<10)
        cents = "0" + cents;
        for (var i = 0; i < Math.floor((num.length-(1+i))/3); i++)
        num = num.substring(0,num.length-(4*i+3))+','+
        num.substring(num.length-(4*i+3));
        return (((sign)?'':'-')  + num + '.' + cents);
	}
	/** 还原货币格式化函数 **/
	function restoreFormatCurrency(num){
       	var num1=num.replace(',','').replace(/,/g,''); 
        return num1;
	}

    //将数字转为货币格式
    function toMoeny(price, chars)
    {
	    chars = chars ? chars.toString() : '￥';
	    if(price > 0)
	    {
		    var priceString = price.toString();
		    var priceInt = parseInt(price);
		    var len = priceInt.toString().length;
		    var num = len / 3;
		    var remainder = len % 3;
		    var priceStr = '';
		    for(var i = 1; i <= len; i++)
		    {
			    priceStr += priceString.charAt(i-1);
			    if(i == (remainder) && len > remainder) priceStr += ',';
			    if((i - remainder) % 3 == 0 && i < len && i > remainder) priceStr += ',';
		    }
		    if(priceString.indexOf('.') < 0)
		    {
			    priceStr = priceStr + '.00';
		    } else {
			    priceStr += priceString.substr(priceString.indexOf('.'));
			    if(priceString.length - priceString.indexOf('.') - 1  < 2)
			    {
				    priceStr = priceStr + '0';
			    }
		    }
		    return chars + priceStr;
	    }
	    else{
		    return chars + price;	
	    }
    }

    //1. [代码]获取光标位置函数     
    function getCursortPosition (ctrl) {
	    var CaretPos = 0;	// IE Support
	    if (document.selection) {
	    ctrl.focus ();
		    var Sel = document.selection.createRange ();
		    Sel.moveStart ('character', -ctrl.value.length);
		    CaretPos = Sel.text.length;
	    }
	    // Firefox support
	    else if (ctrl.selectionStart || ctrl.selectionStart == '0')
		    CaretPos = ctrl.selectionStart;
	    return (CaretPos);
    }
    //2. [代码]设置光标位置函数     跳至 [1] [2] [全屏预览]
    function setCaretPosition(ctrl, pos){
	    if(ctrl.setSelectionRange)
	    {
		    ctrl.focus();
		    ctrl.setSelectionRange(pos,pos);
	    }
	    else if (ctrl.createTextRange) {
		    var range = ctrl.createTextRange();
		    range.collapse(true);
		    range.moveEnd('character', pos);
		    range.moveStart('character', pos);
		    range.select();
	    }
    }

    /* 
 * formatMoney(s,type) 
 * 功能：金额按千位逗号分割 
 * 参数：s，需要格式化的金额数值. 
 * 参数：type,判断格式化后的金额是否需要小数位. 
 * 返回：返回格式化后的数值字符串. 
 */  
function fMoney(s, type) {  
    if (/[^0-9\.]/.test(s))  
        return "0";  
    if (s == null || s == "")  
        return "0";  
    s = s.toString().replace(/^(\d*)$/, "$1.");  
    s = (s + "00").replace(/(\d*\.\d\d)\d*/, "$1");  
    s = s.replace(".", ",");  
    var re = /(\d)(\d{3},)/;  
    while (re.test(s))  
        s = s.replace(re, "$1,$2");  
    s = s.replace(/,(\d\d)$/, ".$1");  
    if (type == 0) {// 不带小数位(默认是有小数位)  
        var a = s.split(".");  
        if (a[1] == "00") {  
            s = a[0];  
        }  
    }  
    return s;  
}  

function Convert(type){
    if(type==null)
    return "";
    switch(type){
    case "True":
        return "启动";
        break;
    case "False":
    return "停用";
    break;
    default:
    return "";
    break;
    }
}

function Convert2(type){
    if(type==null)
    return "";
    switch(type){
    case "True":
        return "是";
        break;
    case "False":
    return "否";
    break;
    default:
    return "";
    break;
    }
}
/* 
 * 通用DateAdd(interval,number,date) 功能:实现javascript的日期相加功能. 
 * 参数:interval,字符串表达式，表示要添加的时间间隔. 参数:number,数值表达式，表示要添加的时间间隔的个数. 参数:date,时间对象. 
 * 返回:新的时间对象. var now = new Date(); var newDate = DateAdd("day",5,now); 
 * author:devinhua(从○开始) update:2010-5-5 20:35 
 */  
function DateAdd(interval, number, date) {  
    if (date == null)  
        return "";  
    switch (interval) {  
    case "day":  
        date = new Date(date);  
        date = date.valueOf();  
        date += number * 24 * 60 * 60 * 1000;  
        date = new Date(date);  
        return date;  
        break;  
    default:  
        return "";  
        break;  
    }  
}

function isExitsFunction(name){
        return typeof eval('window.' + name) == 'function';
    }  
