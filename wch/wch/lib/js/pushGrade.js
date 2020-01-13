function pushGrade() {
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
            , url: '/tool/teacher/UpdCourseView.ashx'
            , toolbar: '#coursetoolbarDemo' //开启头部工具栏，并为其绑定左侧模板
            , defaultToolbar: ['filter', 'exports', 'print', { //自定义头部工具栏右侧图标。如无需自定义，去除该参数即可
                title: '提示'
                , layEvent: 'LAYTABLE_TIPS'
                , icon: 'layui-icon-tips'
            }]
            , title: '录入成绩'
            , id: 'GradeTable'
            , cols: [[
                { type: 'checkbox', fixed: 'left', width: 60 }
                , { field: 'TimeID', title: '排课号', edit: 'text', unresize: true, sort: true }
                , { field: 'StuID', title: '学号', edit: 'text', unresize: true, sort: true }
                , { field: 'StuName', title: '学生姓名', edit: 'text' }
                , { field: 'CourseName', title: '课程名称', edit: 'text' }
                , { field: 'Period', title: '学时', edit: 'text' }
                , { field: 'Credit', title: '学分', edit: 'text' }
                , { field: 'Mark', title: '成绩', edit: 'text' }
                , { fixed: 'right', title: '操作', toolbar: '#barDemo', width: 100, align: 'center' }
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
                case 'LAYTABLE_TIPS':
                    layer.alert('这是工具栏右侧自定义的一个图标按钮');
                    break;
            };
        });
        table.on('tool(context)', function (obj) {
            var data = obj.data;
            //console.log(obj)
            if (obj.event === 'edit') {
                var sdata = obj.data;
                var EditStudent = document.getElementById('submitGrade').innerHTML;
                layer.open({
                    type: 1,
                    content: EditStudent,
                    area: ['400px', '200px'],
                    title: '录入成绩',
                    success: function (layero, index) {
                        console.log(sdata.elem);
                        //修改属性
                        $("input[name='Mark']").val(sdata.Mark);
                        $("input[name='StuID']").val(sdata.StuID);
                        $("input[name='TimeID']").val(sdata.TimeID);
                        form.render();
                        layui.use('form', function () {
                            var form = layui.form;

                            //监听提交
                            form.on('submit(submitGradeForm)', function (data) {
                                //layer.msg(JSON.stringify(data.field));
                                myPost("/tool/teacher/AddGrade.ashx",
                                    { val: JSON.stringify(data.field) },
                                    function (val, data) {
                                        console.log(data.msg);
                                        layer.msg(data.msg);
                                        if (data.code == 200)
                                            layer.close(index);
                                        renderForm();
                                        table.reload('GradeTable');
                                    });
                                return false;
                            });
                        });
                    }
                });
            }
        });
    });
}