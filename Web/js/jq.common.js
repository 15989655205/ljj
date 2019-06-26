if (!Array.prototype.indexOf) {
    Array.prototype.indexOf = function (target) {
        for (var i = 0, l = this.length; i < l; i++) {
            if (this[i] === target) return i;
        }
        return -1;
    };
}

//按钮提交锁屏等待
$.Loading = {
    Init: function (msg) {
        //$("body").append("<div id='loadwin' style='display:none;'><div style='text-align:center;width:98%;padding-top:7px;'>" + msg + "<br><br><img align=\"absmiddle\" src='/Images/progressbar.gif' style='width:200px;height:15px'/></div></div>");
    },
    Open: function (msg) {
        $("body").append("<div id='loadwin' style='display:none;'><div style='text-align:center;width:98%;padding-top:7px;'>" + msg + "<br><br><img align=\"absmiddle\" src='/Images/progressbar.gif' style='width:200px;height:15px'/></div></div>");

        $('#loadwin').window({ title: '', collapsible: false, minimizable: false, maximizable: false, modal: true, closable: false, width: '200px', height: '15px'
        })
    },
    Close: function (msg) {
        if (jQuery("#loadwin").length <= 0) {
            $("body").append("<div id='loadwin' style='display:none;'><div style='text-align:center;width:98%;padding-top:7px;'>" + msg + "<br><br><img align=\"absmiddle\" src='/Images/progressbar.gif' style='width:200px;height:15px'/></div></div>");
        }
        $('#loadwin').window('close');
    }
};

function openDiv(obj) {
    //alert(obj.type);
    if (typeof mySkin == "function") {
        mySkin("/Jquery/artDialog/skins/idialog.css");
    }
    //alert(obj.value);
    //obj.value = "a3e";
    art.dialog({
        padding: "0px 0px",
        id: "0",
        content: '<textarea id="myareatext" name="" rows="1" cols="10" style="width:' + (obj.style.width) + '; overflow:hidden;" onblur="art.dialog({id: \'0\'}).close();" onkeyup="this.style.height = (this.scrollHeight-8<=18?18:this.scrollHeight-4) + \'px\'; " onkeydown="this.style.height = (this.scrollHeight-8<=18?18:this.scrollHeight-4) + \'px\';" onpropertychange="this.style.height = (this.scrollHeight-8<=18?18:this.scrollHeight-4) + \'px\';" oninput="this.style.height = (this.scrollHeight-8<=18?18:this.scrollHeight-4) + \'px\';">' + obj.value + '</textarea>',
        follow: obj,
        //width: obj.style.width - 20,
        close: function () {
            //alert($('#myareatext').val());
            obj.innerText = $('#myareatext').val();
        }

        //style: 'succeed noClose'
    });
    $('#myareatext').focus();
    $('#myareatext').focusEnd();
    //alert($('#myareatext').scrollHeight);
    //alert(document.getElementById("myareatext").scrollHeight);
    $('#myareatext').css("height", document.getElementById("myareatext").scrollHeight - 8 <= 18 ? 18 : document.getElementById("myareatext").scrollHeight - 4);

    //定义setTimeout执行方法
    var TimeFn = null;
    $('#myareatext').keydown(function (e) {
        if (e.keyCode == 13) {
            //art.dialog({ id: '0' }).close();
        }
    });

    $('#myareatext').keypress(function (e) {
        if (e.ctrlKey && e.which == 13 || e.which == 10) { // Ctrl+Enrer(回车)
            //需要执行的代码
            art.dialog({ id: '0' }).close();
            //$("#myareatext").val($("#myareatext").val().replace(/\n/g, "<br/>"));
        } else if (e.shiftKey && e.which == 13 || e.which == 10) { //Shift+Enter(回车)
            //需要执行的代码
            //$("#myareatext").val($("#myareatext").val().replace(/\n/g, "<br/>"));
            art.dialog({ id: '0' }).close();
        }
        else if (e.which == 13) {

        }
    })


    $('#myareatext').click(function () {
        // 取消上次延时未执行的方法
        //clearTimeout(TimeFn);
        //执行延时
        TimeFn = setTimeout(function () {
            //do function在此处写单击事件要执行的代码
        }, 300);
    });

    $('#myareatext').dblclick(function () {
        // 取消上次延时未执行的方法
        //clearTimeout(TimeFn);
        //双击事件的执行代码
        art.dialog({ id: '0' }).close();
    });
}

var isbind = false;
//datagrid 键盘上下键选中行
$.extend($.fn.datagrid.methods, {
    keyCtr: function (jq) {
        return jq.each(function () {
            var grid = $(this);
            if (!isbind) {
                grid.datagrid('getPanel').panel('panel').attr('tabindex', 1).bind('keydown', function (e) {
                    switch (e.keyCode) {
                        case 38: // up
                            var selected = grid.datagrid('getSelected');
                            //start 自己修改
                            grid.datagrid('clearSelections');
                            //end
                            if (selected) {
                                var index = grid.datagrid('getRowIndex', selected);
                                grid.datagrid('selectRow', index - 1);
                            } else {
                                var rows = grid.datagrid('getRows');
                                grid.datagrid('selectRow', rows.length - 1);
                            }
                            break;
                        case 40: // down
                            var selected = grid.datagrid('getSelected');
                            //start 自己修改
                            grid.datagrid('clearSelections');
                            //end
                            if (selected) {
                                var index = grid.datagrid('getRowIndex', selected);
                                grid.datagrid('selectRow', index + 1);
                            } else {
                                grid.datagrid('selectRow', 0);
                            }
                            break;
                    }
                });
                isbind = true;
            }
        });
    }
});


//datagrid 编辑单元格，调用My97DatePicker日期控件
$.extend($.fn.datagrid.defaults.editors, {
    date: {
        init: function (container, options) {
            var fmt = "";
            if (options == undefined || options == null || options.request == null || options.request == "") {
                fmt = "Wdate";
            }
            else {
                fmt = "validate[required, custom[date]]";
            }
            //var input = $('<input type="text" onclick="WdatePicker({dateFmt:\'yyyy-MM-dd\',isShowClear:false})" class="' + fmt + '">').appendTo(container);
            var input = $('<input type="text" onclick="WdatePicker({dateFmt:\'yyyy-MM-dd\'})" class="' + fmt + '">').appendTo(container);
            input.attr("disabled", options != undefined && options.disabled ? options.disabled : false);
            return input;
        },
        getValue: function (target) {
            return $(target).val();
        },
        setValue: function (target, value) {
            if (value != null) {
                value = value.replace(/-/g, "/");
                $(target).val(new Date(value).format("yyyy-MM-dd"));
            }
        },
        resize: function (target, width) {
            var input = $(target);
            if ($.boxModel == true) {
                input.width(width - (input.outerWidth() - input.width()));
            } else {
                input.width(width);
            }
        }
    },

    time: {
        init: function (container, options) {
            var input = $('<input type="text" onclick="WdatePicker({dateFmt:\'HH:mm\',isShowClear:false})" class="" />').appendTo(container);
            return input;
        },
        getValue: function (target) {
            if ($(target).val() == "") {
                return "";
            }
            else {
                return (new Date("1900/01/01 " + $(target).val()).format("hh:mm"));
            }
        },
        setValue: function (target, value) {
            if (value == "") {
                $(target).val(value);
            } else {
                $(target).val(new Date("1900/01/01 " + value).format("hh:mm"));
            }
        },
        resize: function (target, width) {
            var input = $(target);
            if ($.boxModel == true) {
                input.width(width - (input.outerWidth() - input.width()));
            } else {
                input.width(width);
            }
        }
    },

    datetime: {
        init: function (container, options) {
            var fmt = "";
            if (options == undefined || options == null || options.DateFmt == null || options.DateFmt == "") {
                fmt = ",isShowClear:false";
            }
            else {
                fmt = "," + options.DateFmt;
            }
            var input = $('<input type="text" onclick="WdatePicker({dateFmt:\'yyyy-MM-dd HH:mm\'' + fmt + '})" class="">').appendTo(container);
            return input;
        },
        getValue: function (target) {
            return $(target).val();
        },
        setValue: function (target, value) {
            $(target).val(new Date(value).format("yyyy-MM-dd hh:mm"));
        },
        resize: function (target, width) {
            var input = $(target);
            if ($.boxModel == true) {
                input.width(width - (input.outerWidth() - input.width()));
            } else {
                input.width(width);
            }
        }
    },

    textarea_autoheight: {
        init: function (container, options) {
            var input = $('<textarea rows="3" cols="10" style="" wrap="physical"  ></textarea>').appendTo(container);
            return input;
        },
        getValue: function (target) {
            return $(target).val().replace(new RegExp('\r\n', 'g'), '</br>').replace(new RegExp('\n', 'g'), '</br>');
        },
        setValue: function (target, value) {
            if (value != null) {
                $(target).val(value.replace(new RegExp('</br>', 'g'), '\r\n'));
            }
            else {
                $(target).val(value);
            }
        },
        resize: function (target, width) {
            var input = $(target);
            if ($.boxModel == true) {
                input.width(width - (input.outerWidth() - input.width()));
            } else {
                input.width(width);
            }
        }
    },

    custom_datetime: {
        init: function (container, options) {
            var fmt = "";
            if (options == "undefined" || options == null || options.DateFmt == null || options.DateFmt == "") {
                fmt = "{dateFmt:\'yyyy-MM-dd HH:mm\',isShowClear:false}";
            }
            else {
                fmt = options.DateFmt;
            }
            var input = $('<input type="text" onclick="WdatePicker(' + fmt + ')" class="">').appendTo(container);
            return input;
        },
        getValue: function (target) {
            return $(target).val();
        },
        setValue: function (target, value) {
            $(target).val(value);
        },
        resize: function (target, width) {
            var input = $(target);
            if ($.boxModel == true) {
                input.width(width - (input.outerWidth() - input.width()));
            } else {
                input.width(width);
            }
        }
    },

    custom_text: {
        init: function (container, options) {

            var tmp = "";
            var input = $('<input type="text" ' + tmp + ' class="datagrid-editable-input">').appendTo(container);
            input.attr("disabled", options != undefined && options.disabled ? options.disabled : false);
            input.change(options.onChange);
            return input;
        },
        getValue: function (target) {
            return $(target).val();
        },
        setValue: function (target, value) {
            $(target).val(value);
        },
        resize: function (target, width) {
            var input = $(target);
            if ($.boxModel == true) {
                input.width(width - (input.outerWidth() - input.width()));
            } else {
                input.width(width);
            }
        }
    },

    custom_areatext: {
        init: function (container, options) {

            var tmp = "";
            var input = $('<textarea rows="1" cols="10" style="overflow:hidden" wrap="physical"  onfocus="openDiv(this);" tooltip="abc" ></textarea>').appendTo(container);
            input.attr("disabled", options != undefined && options.disabled ? options.disabled : false);
            return input;
        },
        getValue: function (target) {
            return $(target).val();
        },
        setValue: function (target, value) {
            $(target).val(value);
        },
        resize: function (target, width) {
            var input = $(target);
            if ($.boxModel == true) {
                input.width(width - (input.outerWidth() - input.width()));
            } else {
                input.width(width);
            }
        }
    },
    custom_number: {
        init: function (container, options) {

            var tmp = "";
            var input = $('<input type="text" ' + tmp + ' onfocus="this.select()" class="validate[required,custom[number]] datagrid-editable-input">').appendTo(container);
            input.attr("disabled", options != undefined && options.disabled ? options.disabled : false);
            if (options != undefined && options.onChange != null) {
                input.keyup(options.onChange);
            }
            return input;
        },
        getValue: function (target) {
            return $(target).val();
        },
        setValue: function (target, value) {
            $(target).val(value);
        },
        resize: function (target, width) {
            var input = $(target);
            if ($.boxModel == true) {
                input.width(width - (input.outerWidth() - input.width()));
            } else {
                input.width(width);
            }
        }
    },
    custom_persent: {
        init: function (container, options) {

            var tmp = "";
            var input = $('<input type="text" ' + tmp + ' onfocus="this.select()" class="validate[required,custom[number],max[100],min[0]] datagrid-editable-input">').appendTo(container);
            input.attr("disabled", options != undefined && options.disabled ? options.disabled : false);
            if (options != undefined && options.onChange != null) {
                input.keyup(options.onChange);
            }
            return input;
        },
        getValue: function (target) {
            return $(target).val();
        },
        setValue: function (target, value) {
            $(target).val(value);
        },
        resize: function (target, width) {
            var input = $(target);
            if ($.boxModel == true) {
                input.width(width - (input.outerWidth() - input.width()));
            } else {
                input.width(width);
            }
        }
    },
    onclick_text: {
        init: function (container, options) {

            var tmp = "";
            var input = $('<input type="text" ' + tmp + ' readonly="readonly" onclick="openSelectWin();"  style="cursor:pointer;  border-width: 1px;border-color: #95B8E7; border-style: solid;" class="txtInput">').appendTo(container);
            //input.attr("disabled", options != undefined && options.disabled ? options.disabled : false);
            //input.change(options.onChange);
            return input;
        },
        getValue: function (target) {
            return $(target).val();
        },
        setValue: function (target, value) {
            $(target).val(value);
        },
        resize: function (target, width) {
            var input = $(target);
            if ($.boxModel == true) {
                input.width(width - (input.outerWidth() - input.width()));
            } else {
                input.width(width);
            }
        }
    },
    onclick_text1: {
        init: function (container, options) {

            var tmp = "";
            var input = $('<input type="text" ' + tmp + ' readonly="readonly" onclick="openSelectWin1();"  style="cursor:pointer;  border-width: 1px;border-color: #95B8E7; border-style: solid;" class="txtInput">').appendTo(container);
            //input.attr("disabled", options != undefined && options.disabled ? options.disabled : false);
            //input.change(options.onChange);
            return input;
        },
        getValue: function (target) {
            return $(target).val();
        },
        setValue: function (target, value) {
            $(target).val(value);
        },
        resize: function (target, width) {
            var input = $(target);
            if ($.boxModel == true) {
                input.width(width - (input.outerWidth() - input.width()));
            } else {
                input.width(width);
            }
        }
    },
    password: {
        init: function (container, options) {
            var tmp = "";
            var input = $('<input type="password" ' + tmp + ' class="datagrid-editable-input">').appendTo(container);
            input.attr("disabled", options != undefined && options.disabled ? options.disabled : false);
            //input.change(options.onChange);
            return input;
        },
        getValue: function (target) {
            return $(target).val();
        },
        setValue: function (target, value) {
            $(target).val(value);
        },
        resize: function (target, width) {
            var input = $(target);
            if ($.boxModel == true) {
                input.width(width - (input.outerWidth() - input.width()));
            } else {
                input.width(width);
            }
        }
    },
    diseditText: {
        init: function (container, options) {
            var tmp = "";
            var input = $('<input type="text" ' + tmp + ' class="datagrid-editable-input" disabled="disabled">').appendTo(container);
            //input.attr("disabled", options != undefined && options.disabled ? options.disabled : false);
            //input.change(options.onChange);
            return input;
        },
        getValue: function (target) {
            return $(target).val();
        },
        setValue: function (target, value) {
            $(target).val(value);
        },
        resize: function (target, width) {
            var input = $(target);
            if ($.boxModel == true) {
                input.width(width - (input.outerWidth() - input.width()));
            } else {
                input.width(width);
            }
        }
    },
    window_text: {
        init: function (container, options) {

            var tmp = "";
            var input = $('<input type="hidden" id="hid" name="hid"/><input type="text" ' + tmp + ' readonly="readonly" id="sname" onclick="SelectWindow(\'' + options.url + '\');"  style="cursor:pointer;  border-width: 1px;border-color: #95B8E7; border-style: solid;"/>').appendTo(container);
            //input.attr("disabled", options != undefined && options.disabled ? options.disabled : false);
            //input.change(options.onChange);
            return input;
        },
        getValue: function (target) {
            return $(target).val();
        },
        setValue: function (target, value) {
            $(target).val(value);
        },
        resize: function (target, width) {
            var input = $(target);
            if ($.boxModel == true) {
                input.width(width - (input.outerWidth() - input.width()));
            } else {
                input.width(width);
            }
        }
    }
});

//$.extend({}, $.fn.combobox.defaults, {
////    valueField: 'id',
////    textField: 'name',
////    mode: 'remote',    //remote or local 数据源默认使用远程模式
////    required: false,
////    width: 120,
//    keyHandler: {
//        up: function () {
//            //selectPrev(this);
//            //$.fn.combobox.defaults.keyHandler.up.call(this);
//        },
//        down: function () {
//            //selectNext(this);
//            //$.fn.combobox.defaults.keyHandler.down.call(this);
//            $(this).combobox('showPanel');
//        },
//        enter: function () {
//            //var values = $(this).combobox('getValues');
//            //$(this).combobox('setValues', values);
//            //$(this).combobox('hidePanel');
//            //$.fn.combobox.defaults.keyHandler.enter.call(this);
//        },
//        query: function (q) {
//            //doQuery(this, q);
//            //$.fn.combobox.defaults.keyHandler.query.call(this, q);
//        }
//    }
//});

//$.fn.combobox.defaults = $.extend({}, $.fn.combo.defaults, { valueField: "value", textField: "text", mode: "local", method: "post", url: null, data: null, keyHandler: { up: function () {
//    //_b(this, "prev");
//    //$.fn.combobox.defaults.keyHandler.up.call(this);
//}, down: function () {
//    //$.fn.combobox.defaults.keyHandler.down.call(this);
//    $(this).combobox('showPanel');
//}, enter: function () {
//    //_3c(this);
//    //$.fn.combobox.defaults.keyHandler.enter.call(this);
//    $(this).combobox('hidePanel');
//}, query: function (q) {
//    //$.fn.combobox.defaults.keyHandler.query.call(this, q);
//}
//}
//});

function RndNum(n) {
    var rnd = "";
    for (var i = 0; i < n; i++)
        rnd += Math.floor(Math.random() * 10);
    return rnd;
}

//光标定位到内容后面
//start
$.fn.setCursorPosition = function (position) {
    if (this.lengh == 0) return this;
    return $(this).setSelection(position, position);
}

$.fn.setSelection = function (selectionStart, selectionEnd) {
    if (this.lengh == 0) return this;
    input = this[0];

    if (input.createTextRange) {
        var range = input.createTextRange();
        range.collapse(true);
        range.moveEnd('character', selectionEnd);
        range.moveStart('character', selectionStart);
        range.select();
    } else if (input.setSelectionRange) {
        input.focus();
        input.setSelectionRange(selectionStart, selectionEnd);
    }

    return this;
}

$.fn.focusEnd = function () {
    this.setCursorPosition(this.val().length);
}
//光标定位到内容后面
//end

//datagrid 设置是否可以编辑的方法
$.extend($.fn.datagrid.methods, {
    addEditor: function (jq, param) {
        if (param instanceof Array) {
            $.each(param, function (index, item) {
                var e = $(jq).datagrid('getColumnOption', item.field);
                e.editor = item.editor;
            });
        } else {
            var e = $(jq).datagrid('getColumnOption', param.field);
            e.editor = param.editor;
        }
    },
    removeEditor: function (jq, param) {
        if (param instanceof Array) {
            $.each(param, function (index, item) {
                var e = $(jq).datagrid('getColumnOption', item);
                e.editor = {};
            });

        } else {
            var e = $(jq).datagrid('getColumnOption', param);
            e.editor = {};
        }
    }
});


$.extend($.fn.validatebox.defaults.rules, {
    CHS: {
        validator: function (value, param) {
            return /^[\u0391-\uFFE5]+$/.test(value);
        },
        message: '请输入汉字'
    },
    ZIP: {
        validator: function (value, param) {
            return /^[1-9]\d{5}$/.test(value);
        },
        message: '邮政编码不存在'
    },
    QQ: {
        validator: function (value, param) {
            return /^[1-9]\d{4,10}$/.test(value);
        },
        message: 'QQ号码不正确'
    },
    mobile: {
        validator: function (value, param) {
            return /^((\(\d{2,3}\))|(\d{3}\-))?13\d{9}$/.test(value);
        },
        message: '手机号码不正确'
    },
    loginName: {
        validator: function (value, param) {
            return /^[\u0391-\uFFE5\w]+$/.test(value);
        },
        message: '登录名称只允许汉字、英文字母、数字及下划线。'
    },
    safepass: {
        validator: function (value, param) {
            return safePassword(value);
        },
        message: '密码由字母和数字组成，至少6位'
    },
    equalTo: {
        validator: function (value, param) {
            return value == $(param[0]).val();
        },
        message: '两次输入的字符不一至'
    },
    number: {
        validator: function (value, param) {
            return /^\d+$/.test(value);
        },
        message: '请输入数字'
    },
    idcard: {
        validator: function (value, param) {
            return idCard(value);
        },
        message: '请输入正确的身份证号码'
    }
});

/* 密码由字母和数字组成，至少6位 */
var safePassword = function (value) {
    return !(/^(([A-Z]*|[a-z]*|\d*|[-_\~!@#\$%\^&\*\.\(\)\[\]\{\}<>\?\\\/\'\"]*)|.{0,5})$|\s/.test(value));
}

var idCard = function (value) {
    if (value.length == 18 && 18 != value.length) return false;
    var number = value.toLowerCase();
    var d, sum = 0, v = '10x98765432', w = [7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2], a = '11,12,13,14,15,21,22,23,31,32,33,34,35,36,37,41,42,43,44,45,46,50,51,52,53,54,61,62,63,64,65,71,81,82,91';
    var re = number.match(/^(\d{2})\d{4}(((\d{2})(\d{2})(\d{2})(\d{3}))|((\d{4})(\d{2})(\d{2})(\d{3}[x\d])))$/);
    if (re == null || a.indexOf(re[1]) < 0) return false;
    if (re[2].length == 9) {
        number = number.substr(0, 6) + '19' + number.substr(6);
        d = ['19' + re[4], re[5], re[6]].join('-');
    } else d = [re[9], re[10], re[11]].join('-');
    if (!isDateTime.call(d, 'yyyy-MM-dd')) return false;
    for (var i = 0; i < 17; i++) sum += number.charAt(i) * w[i];
    return (re[2].length == 9 || number.charAt(17) == v.charAt(sum % 11));
}

var isDateTime = function (format, reObj) {
    format = format || 'yyyy-MM-dd';
    var input = this, o = {}, d = new Date();
    var f1 = format.split(/[^a-z]+/gi), f2 = input.split(/\D+/g), f3 = format.split(/[a-z]+/gi), f4 = input.split(/\d+/g);
    var len = f1.length, len1 = f3.length;
    if (len != f2.length || len1 != f4.length) return false;
    for (var i = 0; i < len1; i++) if (f3[i] != f4[i]) return false;
    for (var i = 0; i < len; i++) o[f1[i]] = f2[i];
    o.yyyy = s(o.yyyy, o.yy, d.getFullYear(), 9999, 4);
    o.MM = s(o.MM, o.M, d.getMonth() + 1, 12);
    o.dd = s(o.dd, o.d, d.getDate(), 31);
    o.hh = s(o.hh, o.h, d.getHours(), 24);
    o.mm = s(o.mm, o.m, d.getMinutes());
    o.ss = s(o.ss, o.s, d.getSeconds());
    o.ms = s(o.ms, o.ms, d.getMilliseconds(), 999, 3);
    if (o.yyyy + o.MM + o.dd + o.hh + o.mm + o.ss + o.ms < 0) return false;
    if (o.yyyy < 100) o.yyyy += (o.yyyy > 30 ? 1900 : 2000);
    d = new Date(o.yyyy, o.MM - 1, o.dd, o.hh, o.mm, o.ss, o.ms);
    var reVal = d.getFullYear() == o.yyyy && d.getMonth() + 1 == o.MM && d.getDate() == o.dd && d.getHours() == o.hh && d.getMinutes() == o.mm && d.getSeconds() == o.ss && d.getMilliseconds() == o.ms;
    return reVal && reObj ? d : reVal;
    function s(s1, s2, s3, s4, s5) {
        s4 = s4 || 60, s5 = s5 || 2;
        var reVal = s3;
        if (s1 != undefined && s1 != '' || !isNaN(s1)) reVal = s1 * 1;
        if (s2 != undefined && s2 != '' && !isNaN(s2)) reVal = s2 * 1;
        return (reVal == s1 && s1.length != s5 || reVal > s4) ? -10000 : reVal;
    }
};


function FillMultipleCombo(cbID, data, all, sid, text, selectValues) {
    //var data1 = [{ sid: "", text: "全选"}].concat(data);
    var data1 = all.concat(data);
    var dataStr = [],
                dataStr1 = [];
    for (var i = 0; i < data1.length; i++) {
        if (i != 0) {
            dataStr.push(data1[i].sid);
        }
        dataStr1.push(data1[i].sid);
    }
    dataStr.sort(); //将值由小到大排序
    dataStr1.sort();
    var $combo = $("#" + cbID);
    $combo.combobox({
        width: 203,
        data: data1,
        multiple: true,
        valueField: sid,
        textField: text,
        formatter: function (row) {
            return '<span class="mlength" style="cursor:pointer">' + row[text] + '</span>';
        },
        onLoadSuccess: function () {
            //if (selectValues != "" && selectValues != null) {
            //    $(this).combobox('setValues', selectValues);
            //}
        },
        onSelect: function (r) {
            if (r.sid == "") {//当选的是‘所有’这个选项
                $combo.combobox("setValues", dataStr1).combobox("setText", r[text]);
            } else {
                var valArr = $combo.combobox("getValues");
                valArr.sort(); //将值由小到大排序 以保持一致
                if (valArr.join(',') == dataStr.join(',') || valArr.join(',') == dataStr1.join(',')) {
                    $combo.combobox("setValues", dataStr1).combobox("setText", "全选");
                }
            }
        }
                ,
        onUnselect: function (r) {
            if (r.sid == '') {//当取消选择的是‘所有’这个选项
                $combo.combobox("clear");
            } else {
                var valArr = $combo.combobox("getValues");
                if (valArr[0] == "") {
                    valArr.shift();
                    $combo.combobox("setValues", valArr);
                }
            }
        }
    });
}


function FillMultipleCombotree(cbID, data, selectValues) {
    var data1 = [{ "id": "", "text": "全选"}].concat(data);
    var dataStr = [],dataStr1 = [];
    for (var i = 0; i < data1.length; i++) {
        if (i != 0) {
            dataStr.push(data1[i].sid);
        }
        dataStr1.push(data1[i].sid);
    }
    dataStr.sort(); //将值由小到大排序
    dataStr1.sort();
    var $combo = $("#" + cbID);
    $combo.combotree({
        width: 250,
        data: data1,
        multiple: true,
        valueField: "id",
        textField: "text",
        formatter: function (row) {
            return '<span class="mlength" style="cursor:pointer">' + row["text"] + '</span>';
        },
        onLoadSuccess: function () {
            if (selectValues != "" && selectValues != null) {
                $(this).combotree('setValues', selectValues);
            }
        },
        onCheck: function (node, checked) {
            if (node.id == "") {
                if (checked) {
                    //$combo.combotree("tree").tree("select", "1").combotree("setText", node.text);
                    //$combo.combotree("selectAll").combotree("setText", node.text);
                    for (i = 0; i < data1.length; i++) {
                        node = $combo.combotree('tree').tree('find', data1[i]);
                        $combo.combotree('tree').tree('check', node.target);
                        $combo.combotree('tree').tree('expandAll', node.target);
                    }
                }
                else {
                    $combo.combotree("clear");
                }
            }
            else {
                if (checked) {
                    var valArr = $combo.combotree("getValues");
                    valArr.sort(); //将值由小到大排序 以保持一致
                    if (valArr.join(',') == dataStr.join(',') || valArr.join(',') == dataStr1.join(',')) {
                        $combo.combotree("setValues", dataStr1).combotree("setText", "全选");
                    }
                }
                else {
                    var valArr = $combo.combotree("getValues");
                    if (valArr[0] == "") {
                        valArr.shift();
                        $combo.combotree("setValues", valArr);
                    }
                }
            }
        }
    });
}


/**
 * EasyUI DataGrid根据字段动态合并单元格
 * @param tableID 要合并table的id
 * @param colList 要合并的列,用逗号分隔(例如："name,department,office");
 */
function mergeCellsByField(tableID,colList){
    var ColArray = colList.split(",");
    var tTable = $('#'+tableID);
    var TableRowCnts=tTable.datagrid("getRows").length;
    var tmpA;
    var tmpB;
    var PerTxt = "";
    var CurTxt = "";
    var alertStr = "";
    for (j=ColArray.length-1;j>=0 ;j-- )
    {
        PerTxt="";
        tmpA=1;
        tmpB=0;
        for (i=0;i<=TableRowCnts ;i++ )
        {
            if (i==TableRowCnts)
            {
                CurTxt="";
            }
            else
            {
                CurTxt=tTable.datagrid("getRows")[i][ColArray[j]];
            }
            if (PerTxt==CurTxt)
            {
                tmpA+=1;
            }
            else
            {
                tmpB+=tmpA;
                tTable.datagrid('mergeCells',{
                    index:i-tmpA,
                    field:ColArray[j],
                    rowspan:tmpA,
                    colspan:null
                });
                tmpA=1;
            }
            PerTxt=CurTxt;
        }
    }
}

/**
* EasyUI DataGrid根据字段动态合并单元格
* @param tableID 要合并table的id
* @param colList 要合并的列,用逗号分隔(例如："name,department,office");
*/
function mergeCellsByFieldGroup(tableID, colList) {
    var ColArray = colList.split(",");
    //var GroupArray = group.split(",");
    var tTable = $('#' + tableID);
    var TableRowCnts = tTable.datagrid("getRows").length;
    var tmpA;
    //var tmpB;
    var PerTxt = "";
    var CurTxt = "";
    var GroupTxt = "";
    var PerGroupTxt = "";
    var alertStr = "";
    for (j = ColArray.length - 1; j >= 0; j--) {
        var colArr = ColArray[j].split("|");
        PerTxt = "";
        PerGroupTxt = "";
        tmpA = 1;
        //tmpB = 0;
        for (i = 0; i <= TableRowCnts; i++) {
            if (i == TableRowCnts) {
                CurTxt = "";
                GroupTxt = "";
            }
            else {
                CurTxt = tTable.datagrid("getRows")[i][colArr[0]];
                if (CurTxt == undefined) {
                    CurTxt = "";
                }
                if (colArr.length > 1) {
                    GroupTxt = tTable.datagrid("getRows")[i][colArr[1]];
                }
                else {
                    if (j > 0) {
                        GroupTxt = tTable.datagrid("getRows")[i][ColArray[j - 1].split("|")[0]];
                    }
                }
//                CurTxt = tTable.datagrid("getRows")[i][ColArray[j]];
//                if (j > 0) {
//                    GroupTxt = tTable.datagrid("getRows")[i][ColArray[j - 1]];
//                }
                //alert(GroupTxt);
            }
            if (PerTxt == CurTxt && GroupTxt == PerGroupTxt) {
                tmpA += 1;
            }
            else {
                //tmpB += tmpA;
                tTable.datagrid('mergeCells', {
                    index: i - tmpA,
                    //field: ColArray[j],
                    field: colArr[0],
                    rowspan: tmpA,
                    colspan: null
                });
                tmpA = 1;
            }
            PerTxt = CurTxt;
            PerGroupTxt = GroupTxt;
        }
    }
}

function mergeCellsByFieldGroupCondition(tableID, colList, condition) {
    var ColArray = colList.split(",");
    var ConditionArray = condition.split(':');
    //var GroupArray = group.split(",");
    var tTable = $('#' + tableID);
    var TableRowCnts = tTable.datagrid("getRows").length;
    var tmpA;
    //var tmpB;
    var PerTxt = "";
    var CurTxt = "";
    var GroupTxt = "";
    var PerGroupTxt = "";
    var alertStr = "";
    for (j = ColArray.length - 1; j >= 0; j--) {
        var colArr = ColArray[j].split("|");
        PerTxt = "";
        PerGroupTxt = "";
        tmpA = 1;
        //tmpB = 0;
        for (i = 0; i <= TableRowCnts; i++) {
            try {
                if (i != TableRowCnts && tTable.datagrid("getRows")[i][ConditionArray[0]] == ConditionArray[1]) {
                    continue;
                }
            }
            catch (e) {
            }
            //if (i!=TableRowCnts && tTable.datagrid("getRows")[i][ConditionArray[0]] != ConditionArray[1]) {
            if (i == TableRowCnts) {
                CurTxt = "";
                GroupTxt = "";
            }
            else {
                CurTxt = tTable.datagrid("getRows")[i][colArr[0]];
                if (CurTxt == undefined) {
                    CurTxt = "";
                }
                if (colArr.length > 1) {
                    GroupTxt = tTable.datagrid("getRows")[i][colArr[1]];
                }
                else {
                    if (j > 0) {
                        GroupTxt = tTable.datagrid("getRows")[i][ColArray[j - 1].split("|")[0]];
                    }
                }
                //                CurTxt = tTable.datagrid("getRows")[i][ColArray[j]];
                //                if (j > 0) {
                //                    GroupTxt = tTable.datagrid("getRows")[i][ColArray[j - 1]];
                //                }
                //alert(GroupTxt);
            }
            if (PerTxt == CurTxt && GroupTxt == PerGroupTxt) {
                tmpA += 1;
            }
            else {
                //tmpB += tmpA;
                tTable.datagrid('mergeCells', {
                    index: i - tmpA,
                    //field: ColArray[j],
                    field: colArr[0],
                    rowspan: tmpA,
                    colspan: null
                });
                tmpA = 1;
            }
            PerTxt = CurTxt;
            PerGroupTxt = GroupTxt;
        }
    }
}

/**
* EasyUI DataGrid根据字段动态合并单元格
* @param tableID 要合并table的id
* @param colList 要合并的列,用逗号分隔(例如："name,department,office");
*/
function mergeCellsByFieldGroupOne(tableID, colList,group) {
    var ColArray = colList.split(",");
    //var GroupArray = group.split(",");
    var tTable = $('#' + tableID);
    var TableRowCnts = tTable.datagrid("getRows").length;
    var tmpA;
    //var tmpB;
    var PerTxt = "";
    var CurTxt = "";
    var GroupTxt = "";
    var PerGroupTxt = "";
    var alertStr = "";
    for (j = ColArray.length - 1; j >= 0; j--) {
        PerTxt = "";
        PerGroupTxt = "";
        tmpA = 1;
        //tmpB = 0;
        for (i = 0; i <= TableRowCnts; i++) {
            if (i == TableRowCnts) {
                CurTxt = "";
                GroupTxt = "";
            }
            else {
                CurTxt = tTable.datagrid("getRows")[i][ColArray[j]];
                GroupTxt = tTable.datagrid("getRows")[i][group];
                //alert(GroupTxt);
            }
            if (PerTxt == CurTxt &&GroupTxt==PerGroupTxt) {
                tmpA += 1;
            }
            else {
                //tmpB += tmpA;
                tTable.datagrid('mergeCells', {
                    index: i - tmpA,
                    field: ColArray[j],
                    rowspan: tmpA,
                    colspan: null
                });
                tmpA = 1;
            }
            PerTxt = CurTxt;
            PerGroupTxt = GroupTxt;
        }
    }
}

/**
* EasyUI DataGrid根据字段动态合并单元格
* @param tableID 要合并table的id
* @param colList 要合并的列,用逗号分隔(例如："name,department,office");
* @param groupList 要合并的列,用逗号分隔(例如："name,department,office|name");
*/
function mergeCellsByFieldGroupList(tableID, colList, groupList) {
    var ColArray = colList.split(",");
    var GroupArray = groupList.split("|");
    var GroupColArray = GroupArray[0].split(",");
    var tTable = $('#' + tableID);
    var TableRowCnts = tTable.datagrid("getRows").length;
    var tmpA;
    //var tmpB;
    var PerTxt = "";
    var CurTxt = "";
    var GroupTxt = "";
    var PerGroupTxt = "";
    var alertStr = "";
    for (j = GroupColArray.length - 1; j >= 0; j--) {
        PerTxt = "";
        PerGroupTxt = "";
        tmpA = 1;
        //tmpB = 0;
        for (i = 0; i <= TableRowCnts; i++) {
            if (i == TableRowCnts) {
                CurTxt = "";
                GroupTxt = "";
            }
            else {
                CurTxt = tTable.datagrid("getRows")[i][GroupColArray[j]];
                GroupTxt = tTable.datagrid("getRows")[i][GroupArray[1]];
                //alert(GroupTxt);
            }
            if (PerTxt == CurTxt && GroupTxt == PerGroupTxt) {
                tmpA += 1;
            }
            else {
                //tmpB += tmpA;
                tTable.datagrid('mergeCells', {
                    index: i - tmpA,
                    field: GroupColArray[j],
                    rowspan: tmpA,
                    colspan: null
                });
                tmpA = 1;
            }
            PerTxt = CurTxt;
            PerGroupTxt = GroupTxt;
        }
    }

    for (j = ColArray.length - 1; j >= 0; j--) {
        PerTxt = "";
        tmpA = 1;
        tmpB = 0;
        for (i = 0; i <= TableRowCnts; i++) {
            if (i == TableRowCnts) {
                CurTxt = "";
            }
            else {
                CurTxt = tTable.datagrid("getRows")[i][ColArray[j]];
            }
            if (PerTxt == CurTxt) {
                tmpA += 1;
            }
            else {
                tmpB += tmpA;
                tTable.datagrid('mergeCells', {
                    index: i - tmpA,
                    field: ColArray[j],
                    rowspan: tmpA,
                    colspan: null
                });
                tmpA = 1;
            }
            PerTxt = CurTxt;
        }
    }
}


function treegridMergeCellsByField(tableID, colList) {
    var ColArray = colList.split(",");
    var tTable = $('#' + tableID);
    var TableRowCnts = tTable.treegrid("getRows").length;
    var tmpA;
    var tmpB;
    var PerTxt = "";
    var CurTxt = "";
    var alertStr = "";
    for (j = ColArray.length - 1; j >= 0; j--) {
        PerTxt = "";
        tmpA = 1;
        tmpB = 0;
        for (i = 0; i <= TableRowCnts; i++) {
            if (i == TableRowCnts) {
                CurTxt = "";
            }
            else {
                CurTxt = tTable.treegrid("getRows")[i][ColArray[j]];
            }
            if (PerTxt == CurTxt) {
                tmpA += 1;
            }
            else {
                tmpB += tmpA;
                tTable.treegrid('mergeCells', {
                    index: i - tmpA,
                    field: ColArray[j],
                    rowspan: tmpA,
                    colspan: null
                });
                tmpA = 1;
            }
            PerTxt = CurTxt;
        }
    }
}

//datagrid 单元编辑部
$.extend($.fn.datagrid.methods, {
    editCell: function (jq, param) {
        return jq.each(function () {
            var opts = $(this).datagrid('options');
            var fields = $(this).datagrid('getColumnFields', true).concat($(this).datagrid('getColumnFields'));
            for (var i = 0; i < fields.length; i++) {
                var col = $(this).datagrid('getColumnOption', fields[i]);
                col.editor1 = col.editor;
                if (fields[i] != param.field) {
                    col.editor = null;
                }
            }
            $(this).datagrid('beginEdit', param.index);
            for (var i = 0; i < fields.length; i++) {
                var col = $(this).datagrid('getColumnOption', fields[i]);
                col.editor = col.editor1;
            }
        });
    }
});

$.extend($.fn.treegrid.methods, {
    editCell: function (jq, param) {
        return jq.each(function () {
            var opts = $(this).treegrid('options').getEditors
            //var fields = $(this).treegrid('getColumnFields', true).concat($(this).treegrid('getColumnFields'));
            //for (var i = 0; i < fields.length; i++) {
            //    var col = $(this).treegrid('getColumnOption', fields[i]);
            //    col.editor1 = col.editor;
            //    if (fields[i] != param.field) {
            //        col.editor = null;
            //    }
            //}
            for (var i = 0; i < opts.length; i++) {
                var col = opts[i];
                if (col.field != param.field) {
                    col = null;
                }
            }
            $(this).treegrid('beginEdit', param.id);
//            for (var i = 0; i < fields.length; i++) {
//                var col = $(this).treegrid('getColumnOption', fields[i]);
//                col.editor = col.editor1;
            //            }
//            for (var i = 0; i < opts.length; i++) {
//                var col = opts[i];
//                    col = null;
//            }
        });
    }
});


/** 
* 扩展树表格级联选择（点击checkbox才生效）： 
*      自定义两个属性： 
*      cascadeCheck ：普通级联（不包括未加载的子节点） 
*      deepCascadeCheck ：深度级联（包括未加载的子节点） 
*/
$.extend($.fn.treegrid.defaults, {
    onLoadSuccess: function () {
        var target = $(this);
        var opts = $.data(this, "treegrid").options;
        var panel = $(this).datagrid("getPanel");
        var gridBody = panel.find("div.datagrid-body");
        var idField = opts.idField; //这里的idField其实就是API里方法的id参数  
        gridBody.find("div.datagrid-cell-check input[type=checkbox]").unbind(".treegrid").click(function (e) {
            if (opts.singleSelect) return; //单选不管  
            if (opts.cascadeCheck || opts.deepCascadeCheck) {
                var id = $(this).parent().parent().parent().attr("node-id");
                var status = false;
                if ($(this).attr("checked")) status = true;
                //级联选择父节点  
                selectParent(target, id, idField, status);
                selectChildren(target, id, idField, opts.deepCascadeCheck, status);
                /** 
                * 级联选择父节点 
                * @param {Object} target 
                * @param {Object} id 节点ID 
                * @param {Object} status 节点状态，true:勾选，false:未勾选 
                * @return {TypeName}  
                */
                function selectParent(target, id, idField, status) {
                    var parent = target.treegrid('getParent', id);
                    if (parent) {
                        var parentId = parent[idField];
                        if (status)
                            target.treegrid('select', parentId);
                        else
                            target.treegrid('unselect', parentId);
                        selectParent(target, parentId, idField, status);
                    }
                }
                /** 
                * 级联选择子节点 
                * @param {Object} target 
                * @param {Object} id 节点ID 
                * @param {Object} deepCascade 是否深度级联 
                * @param {Object} status 节点状态，true:勾选，false:未勾选 
                * @return {TypeName}  
                */
                function selectChildren(target, id, idField, deepCascade, status) {
                    //深度级联时先展开节点  
                    if (status && deepCascade)
                        target.treegrid('expand', id);
                    //根据ID获取下层孩子节点  
                    var children = target.treegrid('getChildren', id);
                    for (var i = 0; i < children.length; i++) {
                        var childId = children[i][idField];
                        if (status)
                            target.treegrid('select', childId);
                        else
                            target.treegrid('unselect', childId);
                        selectChildren(target, childId, idField, deepCascade, status); //递归选择子节点  
                    }
                }
            }
            e.stopPropagation(); //停止事件传播  
        });
    }
});


/** 
* 扩展树表格级联勾选方法： 
* @param {Object} container 
* @param {Object} options 
* @return {TypeName}  
*/
$.extend($.fn.treegrid.methods, {
    /** 
    * 级联选择 
    * @param {Object} target 
    * @param {Object} param  
    *      param包括两个参数: 
    *          id:勾选的节点ID 
    *          deepCascade:是否深度级联 
    * @return {TypeName}  
    */
    cascadeCheck: function (target, param) {
        var opts = $.data(target[0], "treegrid").options;
        if (opts.singleSelect)
            return;
        var idField = opts.idField; //这里的idField其实就是API里方法的id参数  
        var status = false; //用来标记当前节点的状态，true:勾选，false:未勾选  
        var selectNodes = $(target).treegrid('getSelections'); //获取当前选中项  
        for (var i = 0; i < selectNodes.length; i++) {
            if (selectNodes[i][idField] == param.id)
                status = true;
        }
        //级联选择父节点  
        selectParent(target[0], param.id, idField, status);
        selectChildren(target[0], param.id, idField, param.deepCascade, status);
        /** 
        * 级联选择父节点 
        * @param {Object} target 
        * @param {Object} id 节点ID 
        * @param {Object} status 节点状态，true:勾选，false:未勾选 
        * @return {TypeName}  
        */
        function selectParent(target, id, idField, status) {
            var parent = $(target).treegrid('getParent', id);
            if (parent) {
                var parentId = parent[idField];
                if (status)
                    $(target).treegrid('select', parentId);
                else
                    $(target).treegrid('unselect', parentId);
                selectParent(target, parentId, idField, status);
            }
        }
        /** 
        * 级联选择子节点 
        * @param {Object} target 
        * @param {Object} id 节点ID 
        * @param {Object} deepCascade 是否深度级联 
        * @param {Object} status 节点状态，true:勾选，false:未勾选 
        * @return {TypeName}  
        */
        function selectChildren(target, id, idField, deepCascade, status) {
            //深度级联时先展开节点  
            if (!status && deepCascade)
                $(target).treegrid('expand', id);
            //根据ID获取下层孩子节点  
            var children = $(target).treegrid('getChildren', id);
            for (var i = 0; i < children.length; i++) {
                var childId = children[i][idField];
                if (status)
                    $(target).treegrid('select', childId);
                else
                    $(target).treegrid('unselect', childId);
                selectChildren(target, childId, idField, deepCascade, status); //递归选择子节点  
            }
        }
    }
});  

