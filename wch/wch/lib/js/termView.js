function termView() {
    layui.use(['form', 'layedit', 'laydate', 'table'], function () {
        var table = layui.table
            , form = layui.form
            , layer = layui.layer
            , layedit = layui.layedit
            , laydate = layui.laydate;

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
            , url: '/tool/admin/term/GetTerm.ashx'
            , toolbar: '#alltoolbarDemo' //开启头部工具栏，并为其绑定左侧模板
            , defaultToolbar: ['filter', 'exports', 'print', { //自定义头部工具栏右侧图标。如无需自定义，去除该参数即可
                title: '提示'
                , layEvent: 'LAYTABLE_TIPS'
                , icon: 'layui-icon-tips'
            }]
            , title: '学期表'
            , id: 'termTable'
            , cols: [[
                { type: 'checkbox', fixed: 'left', width: 60 }
                , { field: 'TermID', title: 'ID', fixed: 'left', unresize: true, sort: true }
                , { field: 'TermName', title: '学期', edit: 'text' }
                , { field: 'StartTime', title: '学期开始时间', edit: 'text' }
                , { field: 'EndTime', title: '学期结束时间', edit: 'text' }
                , { field: 'StartChoice', title: '选课开始时间', edit: 'text' }
                , { field: 'EndChoice', title: '选课结束时间', edit: 'text' }
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
                    var AddTerm = document.getElementById('submitTerm').innerHTML;
                    layer.open({
                        type: 1,
                        content: AddTerm,
                        area: ['450px', '550px'],
                        title: '添加学期',
                        success: function (layero, index) {
                            console.log(index);
                            lay('.test-item').each(function () {
                                laydate.render({
                                    elem: this
                                });
                            });



                            layui.use('form', function () {
                                var form = layui.form;

                                //监听提交
                                form.on('submit(submitTermForm)', function (data) {
                                    //layer.msg(JSON.stringify(data.field));
                                    myPost("/tool/admin/term/AddTerm.ashx",
                                        { val: JSON.stringify(data.field) },
                                        function (val, data) {
                                            console.log(data.msg);
                                            layer.msg(data.msg);
                                            if (data.code == 200)
                                                layer.close(index);
                                            renderForm();
                                            table.reload('termTable');
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
                    console.log(data.TermID)
                    myPost("/tool/admin/term/DelTerm.ashx",
                        { val: data.TermID },
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
                var AddTerm = document.getElementById('submitTerm').innerHTML;
                layer.open({
                    type: 1,
                    content: AddTerm,
                    area: ['400px', '400px'],
                    title: '修改学期',
                    success: function (layero, index) {
                        console.log(sdata.elem);
                        //修改属性
                        $("input[name='TermID']").val(sdata.TermID);
                        $("input[name='TermName']").val(sdata.TermName);
                        laydate.render({
                            elem: '#date1'
                            , value: sdata.StartTime == null?"":sdata.StartTime.toString().substr(0, 10)
                            , isInitValue: true
                        });
                        laydate.render({
                            elem: '#date2'
                            , value: sdata.EndTime == null? "":sdata.EndTime.toString().substr(0, 10)
                            , isInitValue: true
                        });
                        laydate.render({
                            elem: '#date3'
                            , value: sdata.StartChoice == null ? "":sdata.StartChoice.toString().substr(0, 10)
                            , isInitValue: true
                        });
                        laydate.render({
                            elem: '#date4'
                            , value: sdata.EndChoice == null ? "":sdata.EndChoice.toString().substr(0, 10)
                            , isInitValue: true
                        });
                        form.render();
                        layui.use('form', function () {
                            var form = layui.form;

                            //监听提交
                            form.on('submit(submitTermForm)', function (data) {
                                //layer.msg(JSON.stringify(data.field));
                                myPost("/tool/admin/term/UpdTerm.ashx",
                                    { val: JSON.stringify(data.field) },
                                    function (val, data) {
                                        console.log(data.msg);
                                        layer.msg(data.msg);
                                        if (data.code == 200)
                                            layer.close(index);
                                        renderForm();
                                        table.reload('termTable');
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
                var TermName = $("input[name='TermName']");

                //执行重载
                table.reload('termTable', {
                    page: {
                        curr: 1 //重新从第 1 页开始
                    }
                    , where: {
                        termName: TermName.val(),
                    }
                }, 'data');
            }
        };

        $('#term_search').on('click', function () {
            var type = $(this).data('type');
            active[type] ? active[type].call(this) : '';
        });
    });
}