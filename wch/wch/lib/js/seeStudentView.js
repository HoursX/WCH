function seeStudentView() {
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
            , url: '/tool/teacher/GetCourseList.ashx'
            , toolbar: '#coursetoolbarDemo' //开启头部工具栏，并为其绑定左侧模板
            , defaultToolbar: ['filter', 'exports', 'print', { //自定义头部工具栏右侧图标。如无需自定义，去除该参数即可
                title: '提示'
                , layEvent: 'LAYTABLE_TIPS'
                , icon: 'layui-icon-tips'
            }]
            , title: '选课学生名单'
            , id: 'studentTable'
            , cols: [[
                { type: 'checkbox', fixed: 'left', width: 60 }
                , { field: 'StuID', title: '学号', edit: 'text', unresize: true, sort: true }
                , { field: 'CourseName', title: '课程名称', edit: 'text' }
                , { field: 'Period', title: '学时', edit: 'text' }
                , { field: 'Credit', title: '学分', edit: 'text' }
                , { field: 'Mark', title: '成绩', edit: 'text' }
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
        var $ = layui.$, active = {
            reload: function () {
                var coursename = $("input[name='coursename']");

                //执行重载
                table.reload('studentTable', {
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