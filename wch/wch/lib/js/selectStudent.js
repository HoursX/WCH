function selectStudent() {
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
            , url: '/tool/admin/select/GetPastCourse.ashx'
            , toolbar: '#coursetoolbarDemo' //开启头部工具栏，并为其绑定左侧模板
            , defaultToolbar: ['filter', 'exports', 'print', { //自定义头部工具栏右侧图标。如无需自定义，去除该参数即可
                title: '提示'
                , layEvent: 'LAYTABLE_TIPS'
                , icon: 'layui-icon-tips'
            }]
            , title: '课程表'
            , id: 'courseTable'
            , cols: [[
                { type: 'checkbox', fixed: 'left', width: 60 }
                , { field: 'StuID', title: '学号', fixed: 'left', unresize: true, sort: true }
                , { field: 'StuName', title: '姓名', edit: 'text' }
                , { field: 'TimeID', title: '排课编号', edit: 'text' }
                , { field: 'TermName', title: '学期', edit: 'text' }
                , { field: 'CourseName', title: '课程名', edit: 'text' }
                , { field: 'TeaName', title: '教师', edit: 'text' }
                , { field: 'Period', title: '学时', edit: 'text' }
                , { field: 'Credit', title: '学分', edit: 'text' }
                , { field: 'DepName', title: '院系', edit: 'text' }
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
                
                //自定义头工具栏右侧图标 - 提示
                case 'LAYTABLE_TIPS':
                    layer.alert('这是工具栏右侧自定义的一个图标按钮');
                    break;
            };
        });
        
    });
}