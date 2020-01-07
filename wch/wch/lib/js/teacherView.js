function teacherView() {
    layui.use('table', function () {
        var table = layui.table;

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
          , url: '/tool/admin/teacher/GetTeacher.ashx'
          , toolbar: '#toolbarDemo' //开启头部工具栏，并为其绑定左侧模板
          , defaultToolbar: ['filter', 'exports', 'print', { //自定义头部工具栏右侧图标。如无需自定义，去除该参数即可
              title: '提示'
            , layEvent: 'LAYTABLE_TIPS'
            , icon: 'layui-icon-tips'
          }]
          , title: '用户数据表'
             , id: 'teacherTable'
          , cols: [[
            { type: 'checkbox', fixed: 'left' }
            , { field: 'TeaID', title: 'ID', width: 150, fixed: 'left', unresize: true, sort: true }
            , { field: 'TeaName', title: '教师姓名', width: 120, edit: 'text' }
            , {
                field: 'Gender', title: '性别', width: 100, edit: 'text', templet: function (res) {
                    return res.Gender == 1 ? '男' : '女';
                }
            }
            , { field: 'DepName', title: '所在院系', width: 150, edit: 'text' }
            , { field: 'TeaAge', title: '年龄', width: 100, sort: true }
            , { field: 'Tel', title: '电话', width: 100 }
            , { field: 'Address', title: '家庭地址', width: 150 }
            , { fixed: 'right', title: '操作', toolbar: '#barDemo', width: 150 }
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
                    var data = obj.data;
                    for (i in data) {
                        data
                    }

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
                    console.log(data.TeaID)
                    myPost("/tool/admin/teacher/DelTea.ashx",
                        { teaID: data.TeaID },
                        function (val, adata) {
                            console.log(adata.msg);
                        });
                    obj.del();

                    layer.close(index);
                });
            } else if (obj.event === 'edit') {
                layer.prompt({
                    formType: 2
                  , value: data.email
                }, function (value, index) {
                    obj.update({
                        email: value
                    });
                    layer.close(index);
                });
            }
        });
        var $ = layui.$, active = {
            reload: function () {
                var teaname = $("input[name='teaname']");
                var teaid = $("input[name='teaid']");
                var depname = $("input[name='depname']");
                //执行重载
                table.reload('teacherTable', {
                    page: {
                        curr: 1 //重新从第 1 页开始
                    }
                    , where: {
                        teaName: teaname.val(),
                        teaID: teaid.val(),
                        depName: depname.val(),
                    }
                }, 'data');
            }
        };

        $('#tea_search').on('click', function () {
            var type = $(this).data('type');
            active[type] ? active[type].call(this) : '';
        });
    });
}