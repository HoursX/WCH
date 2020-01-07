function teacherView() {
    layui.use(['form','table'], function () {
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
          , url: '/tool/admin/teacher/GetTeacher.ashx'
          , toolbar: '#toolbarDemo' //开启头部工具栏，并为其绑定左侧模板
          , defaultToolbar: ['filter', 'exports', 'print', { //自定义头部工具栏右侧图标。如无需自定义，去除该参数即可
              title: '提示'
            , layEvent: 'LAYTABLE_TIPS'
            , icon: 'layui-icon-tips'
          }]
          , title: '教师表'
             , id: 'teacherTable'
          , cols: [[
            { type: 'checkbox', fixed: 'left',width:60 }
            , { field: 'TeaID', title: 'ID', fixed: 'left', unresize: true, sort: true }
            , { field: 'TeaName', title: '教师姓名', edit: 'text' }
            , {
                field: 'Gender', title: '性别',  edit: 'text', templet: function (res) {
                    return res.Gender == 1 ? '男' : '女';
                }
            }
            , { field: 'DepName', title: '所在院系',  edit: 'text' }
            , { field: 'TeaAge', title: '年龄',  sort: true }
            , { field: 'Tel', title: '电话' }
            , { field: 'Address', title: '家庭地址' }
            , { fixed: 'right', title: '操作', toolbar: '#barDemo', width: 165,align:'center' }
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
                    var AddTeacher = document.getElementById('submitTea').innerHTML;
                    layer.open({
                        type: 1,
                        content: AddTeacher,
                        area: ['570px', '580px'],
                        title: '添加教师',
                        success: function (layero, index) {
                            console.log(index);
                            bindDepartment("#depGridding2");

                            layui.use('form', function () {
                                var form = layui.form;

                                //监听提交
                                form.on('submit(submitTeaForm)', function (data) {
                                    //layer.msg(JSON.stringify(data.field));
                                    myPost("/tool/admin/teacher/AddTea.ashx",
                                    { val: JSON.stringify(data.field) },
                                    function (val, data) {
                                        console.log(data.msg);
                                        layer.msg(data.msg);
                                        if (data.code == 200)
                                            layer.close(index);
                                        renderForm();
                                        table.reload('teacherTable');
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
                var sdata = obj.data;
                var AddTeacher = document.getElementById('submitTea').innerHTML;
                layer.open({
                    type: 1,
                    content: AddTeacher,
                    area: ['570px', '580px'],
                    title: '修改教师',
                    success: function (layero, index) {
                        console.log(sdata.elem);
                        bindDepartment("#depGridding2");
                        //修改属性
                        console.log(sdata.DepName.index);
                        $("input[name='TeaID']").val(sdata.TeaID);
                        $("input[name='TeaName']").val(sdata.TeaName);
                        $("input[name='Gender']").each(function () {
                            if ($(this).val() == sdata.Gender.toString())
                                $(this).attr("checked", true);
                        })
                        bindDepartment("#depGridding2", true, true, sdata.DepName);
                        $("input[name='TeaAge']").val(sdata.TeaAge);
                        $("input[name='Tel']").val(sdata.Tel);
                        $("textarea[name='Address']").val(sdata.Address);
                        form.render();
                        layui.use('form', function () {
                            var form = layui.form;

                            //监听提交
                            form.on('submit(submitTeaForm)', function (data) {
                                //layer.msg(JSON.stringify(data.field));
                                myPost("/tool/admin/teacher/UpdTea.ashx",
                                { val: JSON.stringify(data.field) },
                                function (val, data) {
                                    console.log(data.msg);
                                    layer.msg(data.msg);
                                    if (data.code == 200)
                                        layer.close(index);
                                    renderForm();
                                    table.reload('teacherTable');
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