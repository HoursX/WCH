function timeTableView() {


    layui.use(['form', 'layedit', 'laydate', 'table'], function(){
        var table = layui.table
        ,form = layui.form
        ,layer = layui.layer
        ,layedit = layui.layedit
        ,laydate = layui.laydate;

        table.render({
            elem: '#context'
            , parseData: function (res) { //将原始数据解析成 table 组件所规定的数据
                console.log(res);
                return {
                    "code": res.code, //解析接口状态
                    "msg": res.msg, //解析提示文本
                    "count": res.count, //解析数据长度
                    "data": res.data //解析数据列表
                };
            }
            , method: 'POST'
            , cellMinWidth: 80
            , height: 'full-300'
            , url: '/tool/admin/timeTable/GetTimeTable.ashx'
            , toolbar: '#toolbarTimeTableView' //开启头部工具栏，并为其绑定左侧模板
            , defaultToolbar: ['filter', 'exports', 'print', { //自定义头部工具栏右侧图标。如无需自定义，去除该参数即可
                title: '提示'
                , layEvent: 'LAYTABLE_TIPS'
                , icon: 'layui-icon-tips'
            }]
            , title: '排课表'
            , id: 'contentTable'
            , cols: [[
                { type: 'checkbox', fixed: 'left', width: 60 }
                , { field: 'TimeID', title: '排课号', fixed: 'left', sort: true }
                , { field: 'CourseName', title: '课程名' }
                , { field: 'Period', title: '学时', sort: true }
                , { field: 'Credit', title: '学分' }
                , { field: 'DepName', title: '院系' }
                , { field: 'TeaName', title: '授课教师' }
                , { field: 'Day', title: '周'}
                , { field: 'TimeSpan', title: '上课时间' }
                , { field: 'TermName', title: '学期' }
                , { field: 'StuNum', title: '选课人数', sort: true }
                , { field: 'Capacity', title: '容量', sort: true }
                , { field: 'AllowView', title: '允许选课', sort: true, templet: function (res) {
                    return res.AllowView == 1 ? '是' : '否';}
                 }
                , { field: 'Site', title: '教室' }
                , { fixed: 'right', title: '操作', toolbar: '#barDemo', width: 120, align: 'center' }
            ]]
            , page: true
            , done: function (res, curr, count) {
                //如果是异步请求数据方式，res即为你接口返回的信息。
                //如果是直接赋值的方式，res即为：{data: [], count: 99} data为当前页数据、count为数据总长度
                console.log(res);

                //得到当前页码
                console.log(curr);

                //得到数据总量
                console.log(count);
            }
        });
        //头工具栏事件
        table.on('toolbar(context)', function (obj) {
            var checkStatus = table.checkStatus(obj.config.id);
            switch (obj.event) {
                case 'getCheckData':
                    var data = checkStatus.data;
                    layer.alert(JSON.stringify(data));
                    break;
                case 'getCheckLength':
                    var data = checkStatus.data;
                    layer.msg('选中了：' + data.length + ' 个');
                    break;
                case 'isAll':
                    layer.msg(checkStatus.isAll ? '全选' : '未全选');
                    break;
                case 'add':
                    var AddTimeTable = document.getElementById('submitTimeTable').innerHTML;
                    layer.open({
                        type: 1,
                        content: AddTimeTable, //这里content是一个普通的String
                        area: ['480px', '600px'],
                        title: '排课',
                        success: function (layero, index) {
                            console.log(index);
                            //addStudent();
                            bindCourse("#CourseGridding");
                            bindTeacher("#TeaGridding");
                            bindSchedule("#ScheduleGridding");
                            bindTheatre("#TheatreGridding");
                            bindTerm("#TermGridding");
                            layui.use('form', function () {
                                var form = layui.form;
                                
                                //监听提交
                                form.on('submit(submitTimeForm)', function (sdata) {
                                    //layer.msg(JSON.stringify(data.field));
                                    myPost("/tool/admin/timeTable/AddTimeTable.ashx",
                                        { val: JSON.stringify(sdata.field) },
                                        function (val, data) {
                                            console.log(data.msg);
                                            layer.msg(data.msg);
                                            if (data.code == 200) {
                                                layer.close(index);
                                            }
                                            renderForm();
                                            table.reload('contentTable');
                                        });
                                    return false;
                                });




                            });



                        },
                    });

                    break;
                //自定义头工具栏右侧图标 - 提示
                case 'LAYTABLE_TIPS':
                    layer.alert('这是工具栏右侧自定义的一个图标按钮');
                    break;
            };
        });

        //监听行工具事件
        table.on('tool(context)', function (obj) {
            var data = obj.data;
            //console.log(obj)
            if (obj.event === 'del') {
                layer.confirm('真的删除行么', function (index) {
                    console.log(data.TimeID);

                    myPost("/tool/admin/timeTable/DelTimeTable.ashx",
                        { val: data.TimeID },
                        function (val, adata) {
                            layer.msg(adata.msg);
                            console.log(adata.msg);
                        });

                    obj.del();
                    layer.close(index);


                });
            } else if (obj.event === 'edit') {
                var sdata = obj.data;
                var AddStudent = document.getElementById('submitTimeTable').innerHTML;
                layer.open({
                    type: 1,
                    content: AddStudent, //这里content是一个普通的String
                    area: ['480px', '600px'],
                    title: '排课修改',
                    success: function (layero, index) {
                        console.log(index);
                        //addStudent();
                        //添加属性
                        form.render();
                        $("#TimeID").val(sdata.TimeID);
                        bindCourse("#CourseGridding", true, true, sdata.CourseName);
                        bindTeacher("#TeaGridding", true, true, sdata.TeaName);
                        bindSchedule("#ScheduleGridding", true, true, sdata.TimeSpan);
                        bindTheatre("#TheatreGridding", true, true, sdata.Site);
                        bindTerm("#TermGridding", true, true, sdata.TermName);
                        bindDay("#selectDay", true, sdata.Day);
                        form.render();
                        $("input[name='AllowView']").each(function () {
                            if ($(this).val() == sdata.AllowView.toString()) {
                                $(this).attr("checked", true);
                            }
                        });
                        $("input[name='Capacity']").val(sdata.Capacity);

                        form.render();
                        layui.use('form', function () {
                            var form = layui.form;

                            //监听提交
                            form.on('submit(submitTimeForm)', function (sdata) {
                                //layer.msg(JSON.stringify(data.field));
                                myPost("/tool/admin/timeTable/UpdTimeTable.ashx",
                                    { val: JSON.stringify(sdata.field) },
                                    function (val, data) {
                                        console.log(data.msg);
                                        layer.msg(data.msg);
                                        if (data.code == 200) {
                                            layer.close(index);
                                        }
                                        renderForm();
                                        table.reload('contentTable');
                                    });
                                return false;
                            });




                        });



                    },
                });
            }
        });



        var $ = layui.$, active = {
            reload: function () {
                var courseName = $("input[name='CourseName']");
                var depName = $("input[name='DepName']");
                var teaName = $("input[name='TeaName']");
                var termName = $("input[name='TermName']");
                var site = $("input[name='Site']");
                //执行重载
                table.reload('contentTable', {
                    page: {
                        curr: 1 //重新从第 1 页开始
                    }
                    , where: {
                        CourseName: courseName.val(),
                        DepName: depName.val(),
                        TeaName: teaName.val(),
                        TermName: termName.val(),
                        Site:site.val(),
                    }
                }, 'data');
            }
        };

        $('#time_table_search').on('click', function () {
            var type = $(this).data('type');
            active[type] ? active[type].call(this) : '';
        });

        layui.use(['element', 'layer'], function () {
            var element = layui.element;
            var layer = layui.layer;

            //监听折叠
            element.on('collapse(test)', function (data) {
                layer.msg('展开状态：' + data.show);
            });
        });

    });
}
