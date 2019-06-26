<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="Folder_IDE.aspx.cs" Inherits="Maticsoft.Web.File.Folder_IDE" %>
<%@ Register Src="~/Controls/File/folder_IDE.ascx" TagName="Folder" TagPrefix="Folder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    var isload = true;
    var folder_val;
    var dept_val;
    var urlAction = "<%=action %>";
    var urlFolder_id = "<%=folder_id %>";
    var up_users = true;
    var dowm_users = true;
    var up_users_id="<%=up_permission%>";
    var dowm_users_id = "<%=dowm_permission %>";
    var ups_load_rows = [];
    var down_load_rows = [];
    var arrstr_load_ups = '';
    var arrstr_load_downs = '';
    $(function () {
        if (isload) {
            $("#parent_ct").combotree({
                url: '../Ashx/Folder.ashx?action=get_comboxtree',
                onChange: function (data) {
                    if (urlAction == 'add') {
                        getDowmUsers();
                        getUpUsers();
                        //                        alert(
                        //                        getDowmDept($("#up_dept_per").tree("getSelected"));
                        var row = $("#up_dept_per").tree("getSelected");
                        if (row != null) {
                            getDept(row);
                        }

                    }
                },
                onLoadSuccess: function (row, data) {
                    $("#parent_ct").combotree('tree').tree('collapseAll');
                    dept_users_load('dowm_dept_users', 'dowm_dept_users');
                    dept_users_load('dept_users', 'dept_users')
                    if (urlAction == "edit") {
                        LoadData(urlFolder_id);
                        //                        getDowmUsers();
                        //                        getUpUsers();
                    }
                    isload = false;
                }
            });
            $("#up_user_per").datagrid({
                // url: '../Ashx/Folder.ashx', //请求数据的页面
                //            queryParams: { "action": "up_user", "key": "" },
                sortName: 'UserName',
                sortOrder: 'desc',
                idField: 'UserID',
                toolbar: "#tab_toolbar",
                striped: true, //True 奇偶行使用不同背景色
                //pagination: true,
                rownumbers: true,
                //            fitColumns: true,
                singleSelect: false,
                height: 200,
                //            autoRowHeight:true,
                frozenColumns: [[
	                { field: 'ckb', checkbox: true },
                    { field: 'WorkID', title: '工号', width: 50, sortable: true },
                    { field: 'Name', title: '用户姓名', width: 50, sortable: true },
                    { field: 'UserID', title: '', width: 50 }
				]],
                columns: [[
                    { field: 'DeptName', title: '所属部门', width: 100, sortable: true },
					{ field: 'RoleName', title: '职位', width: 50, sortable: true,
					    formatter: function (value, rowData, rowIndex) {
					        return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
					    }
					},
					{ field: 'Caption', title: '性别', width: 50, sortable: true }

				]],
                onLoadSuccess: function (data) {
                    var rows1 = $('#dept_users').datagrid('getRows');
                    var rows2 = data.rows;
                    var indexs = '';
                    //alert(rows1.length);
                    for (var b = 0; b < rows1.length; b++) {
                    for (var a = rows2.length - 1; a >= 0; a--) {
                            if (rows1[b].UserID == rows2[a].UserID) {
                                indexs = $('#up_user_per').datagrid('getRowIndex', rows2[a]);
                                $('#up_user_per').datagrid('deleteRow', indexs);
                            }
                        }
                    }
                    //                    if (indexs.length > 0) {
                    //                        indexs = indexs.substr(0, indexs.length - 1);
                    //                        var index = indexs.split(',');
                    //                        for (var i = 0; i < index.length; i++) {
                    //                            $('#up_user_per').datagrid('deleteRow', index[i]);
                    //                        }
                    //                    }


                }

            });

            $("#up_dept_per").tree({
                url: '../Ashx/Folder.ashx?action=get_up_per_gt&ActionType=Query1&key=',
                multiple: false,
                method: "post",
                onSelect: function (node) {
                    getDept(node);
                    getDowmDept(node);
                },
                onLoadSuccess: function (row, data) {
                    $("#up_dept_per").tree("collapseAll");
                }
            });


            $("#dowm_user_per").datagrid({
                // url: '../Ashx/Folder.ashx', //请求数据的页面
                //            queryParams: { "action": "", "folder_id": "" },
                sortName: 'UserName',
                sortOrder: 'desc',
                idField: 'UserID',
                toolbar: "#tab_toolbar",
                striped: true, //True 奇偶行使用不同背景色
                //pagination: true,
                rownumbers: true,
                //                fitColumns: true,
                singleSelect: false,
                height: 200,
                frozenColumns: [[
	                { field: 'ckb', checkbox: true },
                    { field: 'WorkID', title: '工号', width: 50, sortable: true },
                    { field: 'Name', title: '用户姓名', width: 50, sortable: true }
				]],
                columns: [[
                    { field: 'DeptName', title: '所属部门', width: 100, sortable: true },
					{ field: 'RoleName', title: '职位', width: 50, sortable: true,
					    formatter: function (value, rowData, rowIndex) {
					        return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
					    }
					},
					{ field: 'Caption', title: '性别', width: 50, sortable: true }

				]],
                onLoadSuccess: function (data) {
                    var rows1 = $('#dowm_dept_users').datagrid('getRows');
                    var rows2 = data.rows;
                    var indexs = '';
                    for (var b = 0; b < rows1.length; b++) {
                    for (var a = rows2.length - 1; a >= 0; a--) {
                        
                            if (rows1[b].UserID == rows2[a].UserID) {
                                indexs = $('#dowm_user_per').datagrid('getRowIndex', rows2[a]);
                                $('#dowm_user_per').datagrid('deleteRow', indexs);
                            }
                        }
                    }
                    //                    if (indexs.length > 0) {
                    //                        indexs = indexs.substr(0, indexs.length - 1);
                    //                        var index = indexs.split(',');
                    //                        for (var i = 0; i < index.length; i++) {
                    //                            $('#dowm_user_per').datagrid('deleteRow', index[i])
                    //                        }
                    //                    }


                }
            });

            $("#dowm_dept_per").tree({
                url: '../Ashx/Folder.ashx?action=get_dowm_per_gt&key=',
                multiple: false,
                method: "post",
                onSelect: function (node) {
                    getDowmDept(node);
                }

            });


        }

    });
    function dept_users_load(id, action) {
        $('#' + id).datagrid({
            url: '../Ashx/Folder.ashx', //请求数据的页面
            queryParams: { "action": action, "folder_id": urlFolder_id },
            sortName: 'UserName',
            sortOrder: 'desc',
            idField: 'UserID',
            //                toolbar: "#tab_toolbar",
            striped: true, //True 奇偶行使用不同背景色
            rownumbers: true,
            //                fitColumns: true,
            singleSelect: false,
            height: 200,
            frozenColumns: [[
	                { field: 'ckb', checkbox: true },
                    { field: 'WorkID', title: '工号', width: 50, sortable: true,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { field: 'Name', title: '用户姓名', width: 50, sortable: true,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { field: 'UserID', title: '', width: 50 }
				]],
            columns: [[
                    { field: 'DeptName', title: '所属部门', width: 100, sortable: true,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
					{ field: 'RoleName', title: '职位', width: 50, sortable: true,
					    formatter: function (value, rowData, rowIndex) {
					        value = typeof (value) == "undefined" ? "" : value;
					        return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
					    }
					},
					{ field: 'Caption', title: '性别', width: 50, sortable: true,
					    formatter: function (value, rowData, rowIndex) {
					        return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
					    }
					}

				]],
            onLoadSuccess: function (data) {
                //                    getDowmUsers();
                if (id == 'dowm_dept_users') {
                    arrstr_load_downs = '';
                    for (var a = 0; a < data.total; a++) {
                        arrstr_load_downs = arrstr_load_downs + data.rows[a].UserID + ','
                    }
                    down_load_rows = $('#dowm_dept_users').datagrid('getRows');
                }
                else if (id == 'dept_users') {
                    arrstr_load_ups = '';
                    for (var a = 0; a < data.total; a++) {
                        arrstr_load_ups = arrstr_load_ups + data.rows[a].UserID + ','
                    }
                    ups_load_rows = $('#dept_users').datagrid('getRows');
                }

            }

        });
    }
    function LoadData(folder_id) {
        $("#parent_ct").combotree("setValue", "<%=level_id %>");
        $("#txtRemark").val("<%=remark %>");
        $("#parent_ct").combotree("disable");
        $("#txtName").val("<%=folder_name %>");

    };


    function getDept(node) {
//        alert(node.id);
         $("#parent_ct").combotree('getValue');
        $("#up_user_per").datagrid("options").url = '../Ashx/Folder.ashx';
        $('#up_user_per').datagrid('options').queryParams = { "action": "up_user", "key": node.id, "folder_id": folder_val };
        $('#up_user_per').datagrid('reload');
    };
    function getDowmDept(node) {
         $("#parent_ct").combotree('getValue');
        $("#dowm_user_per").datagrid("options").url = '../Ashx/Folder.ashx';
        $('#dowm_user_per').datagrid('options').queryParams = { "action": "dowm_user", "key": node.id, "folder_id": folder_val };
        $('#dowm_user_per').datagrid('reload');
    };
    function getUpUsers() {
        $("#dept_users").datagrid('options').url = '../Ashx/Folder.ashx';
        if (urlAction=="edit") {
            $('#dept_users').datagrid('options').queryParams = { 'action': 'dept_users', 'folder_id': urlFolder_id };
        }
        else {
            $('#dept_users').datagrid('options').queryParams = { 'action': 'dept_users', 'folder_id': $('#parent_ct').combotree('getValue') };
        }
        $('#dept_users').datagrid('reload');
    };
    function getDowmUsers() {
        $("#dowm_dept_users").datagrid('options').url = '../Ashx/Folder.ashx';
        if (urlAction == "edit") {
            $('#dowm_dept_users').datagrid('options').queryParams = { 'action': 'dowm_dept_users', 'folder_id': urlFolder_id };
        }
        else {
            $('#dowm_dept_users').datagrid('options').queryParams = { 'action': 'dowm_dept_users', 'folder_id': $('#parent_ct').combotree('getValue') };
        }
        $('#dowm_dept_users').datagrid('reload');

    };
    function btn_up_user() {
        var row = [];
        var row1 = [];
        var b = true;
        var index=[];
        row = $("#up_user_per").datagrid("getSelections");
        row1 = $("#dept_users").datagrid("getRows");
        if (row1.length == 0) {
            for (var i = 0; i < row.length; i++) {
                $("#dept_users").datagrid("appendRow", row[i]);
            }
        }
        else {
            for (var i = 0; i < row.length; i++) {
                for (var j = 0; j < row1.length; j++) {
                    if (row[i].UserID == row1[j].UserID)
                        b = false;
                }
                if (b) {
                    $("#dept_users").datagrid("appendRow", row[i]);
                    
                }
                b = true;
            }
        }
        for (var a = row.length-1; a >=0; a--) {
            index = $('#up_user_per').datagrid('getRowIndex', row[a]);
            $('#up_user_per').datagrid('deleteRow', index);
        }
        $("#up_user_per").datagrid("unselectAll");
    }
    function btn_all_up_user() {
        var row = [];
        var row1 = [];
        var b = true;
        row = $("#up_user_per").datagrid("getRows");
        row1 = $("#dept_users").datagrid("getRows");
        if (row1.length == 0) {
            for (var i = 0; i < row.length; i++) {
                $("#dept_users").datagrid("appendRow", row[i]);
            }
        }
        else {
            for (var i = 0; i < row.length; i++) {
                for (var j = 0; j < row1.length; j++) {
                    if (row[i].UserID == row1[j].UserID)
                        b = false;
                }
                if (b)
                    $("#dept_users").datagrid("appendRow", row[i]);
                b = true;
            }
        }
        for (var a = row.length - 1; a >= 0; a--) {
            index = $('#up_user_per').datagrid('getRowIndex', row[a]);
            $('#up_user_per').datagrid('deleteRow', index);
        }
        $("#up_user_per").datagrid("unselectAll");
    };

    function btn_del_up_user() {
        var row = [];
        var b = true;
        var index;
        row = $("#dept_users").datagrid("getSelections");
        var getvalue;
        getvalue = $('#up_dept_per').tree('getSelected');
        for (var i = row.length - 1; i >= 0; i--) {
            index = $("#dept_users").datagrid("getRowIndex", row[i]);
            if (getvalue == null) {
                $('#up_user_per').datagrid('appendRow', row[i]);
            }
            $("#dept_users").datagrid("deleteRow", index);
        }
        if (getvalue != null) {
            $('#up_dept_per').tree('select', getvalue.target);
        }
        $("#dept_users").datagrid("unselectAll");
    };
    function btn_del_up_all() {
        var row = [];
        var b = true;
        var index;
        var getvalue;
        getvalue = $('#up_dept_per').tree('getSelected');
        row = $("#dept_users").datagrid("getRows");
        for (var i = row.length - 1; i >= 0; i--) {
            index = $("#dept_users").datagrid("getRowIndex", row[i]);
            if (getvalue == null) {
                $('#up_user_per').datagrid('appendRow', row[i]);
            }
            $("#dept_users").datagrid("deleteRow", index);
        }
        if (getvalue != null) {
            $('#up_dept_per').tree('select', getvalue.target);
        }

        $("#dept_users").datagrid("unselectAll");
    };


    function btn_dowm_user() {
        var row = [];
        var row1 = [];
        var b = true;
        row = $("#dowm_user_per").datagrid("getSelections");
        row1 = $("#dowm_dept_users").datagrid("getRows");
        if (row1.length == 0) {
            for (var i = 0; i < row.length; i++) {
                $("#dowm_dept_users").datagrid("appendRow", row[i]);
            }
        }
        else {
            for (var i = 0; i < row.length; i++) {
                for (var j = 0; j < row1.length; j++) {
                    if (row[i].UserID == row1[j].UserID)
                        b = false;
                }
                if (b)
                    $("#dowm_dept_users").datagrid("appendRow", row[i]);
                b = true;
            }
        }
        for (var a = row.length - 1; a >= 0; a--) {
            index = $('#dowm_user_per').datagrid('getRowIndex', row[a]);
            $('#dowm_user_per').datagrid('deleteRow', index);
        }
        $("#dowm_user_per").datagrid("unselectAll");
    }
    function btn_all_dowm_user() {
        var row = [];
        var row1 = [];
        var b = true;
        row = $("#dowm_user_per").datagrid("getRows");
        row1 = $("#dowm_dept_users").datagrid("getRows");
        if (row1.length == 0) {
            for (var i = 0; i < row.length; i++) {
                $("#dowm_dept_users").datagrid("appendRow", row[i]);
            }
        }
        else {
            for (var i = 0; i < row.length; i++) {
                for (var j = 0; j < row1.length; j++) {
                    if (row[i].UserID == row1[j].UserID)
                        b = false;
                }
                if (b)
                    $("#dowm_dept_users").datagrid("appendRow", row[i]);
                b = true;
            }
        }
        for (var a = row.length - 1; a >= 0; a--) {
            index = $('#dowm_user_per').datagrid('getRowIndex', row[a]);
            $('#dowm_user_per').datagrid('deleteRow', index);
        }
        $("#dowm_user_per").datagrid("unselectAll");
    };

    function btn_del_dowm_user() {
        var row = [];
        var b = true;
        var index;
        var getvalue;
        getvalue = $('#dowm_dept_per').tree('getSelected');
        row = $("#dowm_dept_users").datagrid("getSelections");
        for (var i = row.length - 1; i >= 0; i--) {
            index = $("#dowm_dept_users").datagrid("getRowIndex", row[i]);
            if (getvalue == null) {
                $('#dowm_user_per').datagrid('appendRow', row[i]);
            }
            $("#dowm_dept_users").datagrid("deleteRow", index);
        }
        if (getvalue != null) {
            $('#dowm_dept_per').tree('select', getvalue.target);
        }
        $("#dowm_dept_users").datagrid("unselectAll");
    };
    function btn_del_dowm_all() {
        var row = [];
        var b = true;
        var index;
        var getvalue;
        getvalue = $('#dowm_dept_per').tree('getSelected');
        row = $("#dowm_dept_users").datagrid("getRows");
        for (var i = row.length - 1; i >= 0; i--) {
            index = $("#dowm_dept_users").datagrid("getRowIndex", row[i]);
            if (getvalue == null) {
                $('#dowm_user_per').datagrid('appendRow', row[i]);
            }
            $("#dowm_dept_users").datagrid("deleteRow", index);
        }

        if (getvalue != null) {
            $('#dowm_dept_per').tree('select', getvalue.target);
        }

        $("#dowm_dept_users").datagrid("unselectAll");

    };
    function save() {
        if (urlAction == "add") {
            add_folder();
        }
        else if (urlAction == "edit") {
            update();
        }
    };
    function add_folder() {
        var txtName = $("#txtName").val();
        var parent_ct;

        if ($("#txtName").val() == "") {
            $.messager.alert("文件夹名称不能为空！");
            return false;
        }
        if (urlAction != "edit") {
            parent_ct = $("#parent_ct").combotree("getValue");
            if ($("#parent_ct").combotree("getValues") < 0) {
                $.messager.alert("父级文件夹不能为空！");
                return false;
            }
        }
        else {
            parent_ct = urlFolder_id;
        }


        var row_up = [];
        var row_down = [];
        row_up = $("#dept_users").datagrid("getRows");
        row_down = $("#dowm_dept_users").datagrid("getRows");
//        if (row_up.length <= 0) {
//            $.messager.alert("上传权限不能为空！");
//            return false;
//        }
//        if (row_down.length <= 0) {
//            $.messager.alert("下载权限不能为你空！");
//            return false;
//        }
        var ups = ',';
        var downs = ',';
        for (var i = 0; i < row_up.length; i++) {
            ups += row_up[i].UserID + ',';
        }
        for (var j = 0; j < row_down.length; j++) {
            downs += row_down[j].UserID + ',';
        }

        var remark = $("#txtRemark").val();
        var flag = true;

//        $('#uiform input').each(function () {
//            if ($(this).attr('required') || $(this).attr('validType')) {
//                if (!$(this).validatebox('isValid')) {
//                    flag = false;
//                    return;
//                }
//            }
        //        })


        //        if (ups_add!=''||ups_del!=''||downs_add!=''||downs_del!='') {

        if (!$('#ff').form('validate')) {
            $.messager.show({ title: '错误提示', msg: '验证未通过！' });
        }
        else {
            $.ajax({
                type: "POST",
                timeout: 6000,
                url: "../Ashx/Folder.ashx",
                data: {
                    'action': urlAction,
                    'folder_name': txtName,
                    'level_ID': parent_ct,
                    'up_user': ups,
                    'dowm_user': downs,
                    'remark': remark
                },
                success: function (data) {
                    if (data.split(',')[0] == "success") {
                        $.messager.show({ title: '提示', msg: "保存成功！" });
                        if (urlAction != "edit") {
                            urlAction = "edit";
                            urlFolder_id = data.split(',')[1];
                            $("#parent_ct").combotree("disable");
                            //                        $('#tabs').tabs('update', { tab: $('#tabs').tabs('getTab', '修改文件夹') });
                            //                        $("#tabs").tabs('update', { "tab": $("#tabs").tabs('getSelected').panel('options').tab, "options": { "title": "修改"} });
                        }
                        var title = parent.$('#tabs').tabs("getSelected").panel('options').title;
                        parent.Tab_OC("文件夹管理", title, "File/folder.aspx", "", true);
                        //                    var tab = parent.$('#tabs').tabs("getSelected");
                        //                    var url = "/File/Folder_IDE.aspx?action=edit&id=" + urlFolder_id;
                        //                    parent.$('#tabs').tabs('update', {
                        //                        tab: tab,
                        //                        options: {
                        //                            title: '修改夹文件',
                        //                            content: createFrame(url)
                        //                        }
                        //                    });
                        //                    $('#tabs').tabs('update', {
                        //                        tab: parent.$('#tabs').tabs('getTab', '文件夹管理'),
                        //                        options: { content: createFrame('/File/folder.aspx') }
                        //                    });
                    }
                    else {
                        $.messager.show({ title: '错误提示', msg: (data=="success"?"保存成功":data) });
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.messager.show({ title: '错误提示', msg: XMLHttpRequest.status });
                }
            })
        }
    };
    function update() {
        var txtName = $("#txtName").val();
        var parent_ct;

        if ($("#txtName").val() == "") {
            $.messager.alert("文件夹名称不能为空！");
            return false;
        }
//        if (urlAction != "edit") {
//            parent_ct = $("#parent_ct").combotree("getValue");
//            if ($("#parent_ct").combotree("getValues") < 0) {
//                $.messager.alert("父级文件夹不能为空！");
//                return false;
//            }
//        }
//        else {
//            parent_ct = urlFolder_id;
//        }

        var folder_level = $('#parent_ct').combotree('getValue');
        var row_up = [];
        var row_down = [];
        row_up = $("#dept_users").datagrid("getRows");
        row_down = $("#dowm_dept_users").datagrid("getRows");
//        if (row_up.length <= 0) {
//            $.messager.alert("上传权限不能为空！");
//            return false;
//        }
//        if (row_down.length <= 0) {
//            $.messager.alert("下载权限不能为你空！");
//            return false;
//        }
        var ups=',';
        var downs = ',';
        for (var i = 0; i < row_up.length; i++) {
            ups += row_up[i].UserID + ',';
        }
        for (var j = 0; j < row_down.length; j++) {
            downs += row_down[j].UserID + ',';
        }
        var b = true;
        var ups_add='';
        var ups_del = '';
        if (arrstr_load_ups != '') {
            arrstr_load_ups=arrstr_load_ups.substring(0, arrstr_load_ups.length - 1);
        }
        var arr_load_ups = arrstr_load_ups.split(',');
        for (var ups1 = 0; ups1 < arr_load_ups.length; ups1++) {
            for (var ups2 = 0; ups2 < row_up.length; ups2++) {
                if (arr_load_ups[ups1] == row_up[ups2].UserID) {
                    b = false;
                }
            }
            if (b) {
                ups_del = ups_del + arr_load_ups[ups1] + ',';
            }
            b = true;
        }
        for (var ups3 = 0; ups3 < row_up.length; ups3++) {
            for (var ups4 = 0; ups4 < arr_load_ups.length; ups4++) {
                if (row_up[ups3].UserID == arr_load_ups[ups4]) {
                    b = false;
                }
            }
            if (b) {
                ups_add = ups_add + row_up[ups3].UserID + ',';
            }
            b = true;
        }
        var downs_add = '';
        var downs_del = '';
        if (arrstr_load_downs != '') {
            arrstr_load_downs=arrstr_load_downs.substring(0, arrstr_load_downs.length - 1);
        }
        var array_load_downs = arrstr_load_downs.split(',')
        for (var downs1 = 0; downs1 < array_load_downs.length; downs1++) {
            for (var downs2 = 0; downs2 < row_down.length; downs2++) {
                if (array_load_downs[downs1] == row_down[downs2].UserID) {
                    b = false;
                }
            }
            if (b) {
                downs_del = downs_del + array_load_downs[downs1] + ',';
            }
            b = true;
        }
        for (var downs3 = 0; downs3 < row_down.length; downs3++) {
            for (var downs4 = 0; downs4 < array_load_downs.length; downs4++) {
                if (row_down[downs3].UserID == array_load_downs[downs4]) {
                    b = false;
                }
            }
            if (b) {
                downs_add = downs_add + row_down[downs3].UserID + ',';
            }
            b = true;
        }
//        var flag = true;

//        $('#uiform input').each(function () {
//            if ($(this).attr('required') || $(this).attr('validType')) {
//                if (!$(this).validatebox('isValid')) {
//                    flag = false;
//                    return;
//                }
//            }
//        })

        //        if (ups_add!=''||ups_del!=''||downs_add!=''||downs_del!='') {
        if (!$('#ff').form('validate')) {
            $.messager.show({ title: '错误提示', msg: '验证未通过！' });
        }
        else {
            $.messager.confirm('', '该文件的权限发生改变！该文件夹的子文件夹是否执行相应的操作？', function (r) {
                if (!r) {
                    ups_add = '';
                    ups_del = '';
                    downs_add = '';
                    downs_del = '';
                }
                var remark = $("#txtRemark").val();
                $.ajax({
                    type: "POST",
                    timeout: 6000,
                    url: "../Ashx/Folder.ashx",
                    data: {
                        'action': urlAction,
                        'folder_name': txtName,
                        'level_ID': folder_level,
                        'folder_id': urlFolder_id,
                        'up_user': ups,
                        'dowm_user': downs,
                        'remark': remark,
                        'ups_add': ups_add,
                        'ups_del': ups_del,
                        'downs_add': downs_add,
                        'downs_del': downs_del
                    },
                    success: function (data) {
                        if (data.split(',')[0] == "success") {

                            if (urlAction != "edit") {
                                urlAction = "edit";
                                urlFolder_id = data.split(',')[1];
                                $("#parent_ct").combotree("disable");
                                //                        $('#tabs').tabs('update', { tab: $('#tabs').tabs('getTab', '修改文件夹') });
                                //                        $("#tabs").tabs('update', { "tab": $("#tabs").tabs('getSelected').panel('options').tab, "options": { "title": "修改"} });
                            }
                            var title = parent.$('#tabs').tabs("getSelected").panel('options').title;
                            parent.Tab_OC("文件夹管理", title, "File/folder.aspx", "", true);
                            $.messager.show({ title: '提示', msg: "保存成功！" });
                        }
                        else {
                            $.messager.show({ title: '错误提示', msg: data });
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        $.messager.show({ title: '错误提示', msg: XMLHttpRequest.status });
                    }
                })

            });
        }
//        }
       
    };



  
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<Folder:Folder ID="folder_ide" runat="server"></Folder:Folder>
</asp:Content>
