function courseView() {
    layui.use('table', function () {
        var table = layui.table
            , form = layui.form;

        table.render({
            elem: '#context'
            , parseData: function (res) { //将原始数据解析成 table 组件所规定的数据
                console.log(res);
                //res.d=decode(res)
                return {
                    "code": res.code, //解析接口状态
                    "msg": res.msg, //解析提示文本
                    "count": res.count, //解析数据长度
                    "data": res.data //解析数据列表
                };
            }
            , method: 'POST'
            , url: '/tool/admin/course/GetCourse.ashx'
            , toolbar: '#alltoolbarDemo' //开启头部工具栏，并为其绑定左侧模板
            , defaultToolbar: ['filter', 'exports', 'print', { //自定义头部工具栏右侧图标。如无需自定义，去除该参数即可
                title: '提示'
                , layEvent: 'LAYTABLE_TIPS'
                , icon: 'layui-icon-tips'
            }]
            , title: '课程表'
            , id: 'courseTable'
            , cols: [[
                { type: 'checkbox', fixed: 'left', width: 60 }
                , { field: 'CourseID', title: 'ID', fixed: 'left', unresize: true, sort: true }
                , { field: 'CourseName', title: '课程名称', edit: 'text' }
                , { field: 'Period', title: '学时', edit: 'text' }
                , { field: 'Credit', title: '学分', edit: 'text' }
                , { field: 'DepName', title: '院系名称', edit: 'text' }
                , { fixed: 'right', title: '操作', toolbar: '#barDemo', width: 165, align: 'center' }
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
                    var AddCourse = document.getElementById('submitCourse').innerHTML;
                    layer.open({
                        type: 1,
                        content: AddCourse,
                        area: ['400px', '450px'],
                        title: '添加课程',
                        success: function (layero, index) {
                            console.log(index);
                            bindDepartment("#depGridding5");
                            layui.use('form', function () {
                                var form = layui.form;

                                //监听提交
                                form.on('submit(submitCourseForm)', function (data) {
                                    //layer.msg(JSON.stringify(data.field));
                                    myPost("/tool/admin/course/AddCourse.ashx",
                                        { val: JSON.stringify(data.field) },
                                        function (val, data) {
                                            console.log(data.msg);
                                            layer.msg(data.msg);
                                            if (data.code == 200)
                                                layer.close(index);
                                            renderForm();
                                            table.reload('courseTable');
                                        });
                                    return false;
                                });
                            });
                        }
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
                    console.log(data.CourseID)
                    myPost("/tool/admin/course/DelCourse.ashx",
                        { val: data.CourseID },
                        function (val, adata) {
                            console.log(adata.msg);
                            if (adata.code == 200)
                                layer.msg("删除成功！");
                        });
                    obj.del();

                    layer.close(index);
                });
            } else if (obj.event === 'edit') {
                var sdata = obj.data;
                var AddCourse = document.getElementById('submitCourse').innerHTML;
                layer.open({
                    type: 1,
                    content: AddCourse,
                    area: ['400px', '400px'],
                    title: '修改班级',
                    success: function (layero, index) {
                        console.log(sdata.elem);
                        //修改属性
                        $("input[name='CourseID']").val(sdata.CourseID);
                        $("input[name='CourseName']").val(sdata.CourseName);
                        $("input[name='Period']").val(sdata.Period);
                        $("input[name='Credit']").val(sdata.Credit);
                        bindDepartment("#depGridding5", true, true, sdata.DepName);
                        form.render();
                        layui.use('form', function () {
                            var form = layui.form;

                            //监听提交
                            form.on('submit(submitCourseForm)', function (data) {
                                //layer.msg(JSON.stringify(data.field));
                                myPost("/tool/admin/course/UpdCourse.ashx",
                                    { val: JSON.stringify(data.field) },
                                    function (val, data) {
                                        console.log(data.msg);
                                        layer.msg(data.msg);
                                        if (data.code == 200)
                                            layer.close(index);
                                        renderForm();
                                        table.reload('courseTable');
                                    });
                                return false;
                            });
                        });
                    }
                });
            }
        });
        var $ = layui.$, active = {
            reload: function () {
                var coursename = $("input[name='CourseName']");
                //执行重载
                table.reload('courseTable', {
                    page: {
                        curr: 1 //重新从第 1 页开始
                    }
                    , where: {
                        courseName: coursename.val(),
                    }
                }, 'data');
            }
        };

        $('#course_search').on('click', function () {
            var type = $(this).data('type');
            active[type] ? active[type].call(this) : '';
        });
    });
}