function userView() {


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
            , url: '/tool/user/GetUser.ashx'
            , toolbar: '#toolbarUserView' //开启头部工具栏，并为其绑定左侧模板
            , defaultToolbar: ['filter', 'exports', 'print', { //自定义头部工具栏右侧图标。如无需自定义，去除该参数即可
                title: '提示'
                , layEvent: 'LAYTABLE_TIPS'
                , icon: 'layui-icon-tips'
            }]
            , title: '用户信息表'
            , id: 'contentTable'
            , cols: [[
                { type: 'checkbox', fixed: 'left', width: 60 }
                , { field: 'UserID', title: '用户ID', fixed: 'left', sort: true }
                , { field: 'Passwd', title: '密码' }
                , { field: 'Identity', title: '标识' }
                , { field: 'Nickname', title: '用户名' }
                , { field: 'AllowLogin', title: 'AllowLogin' }
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
                   
                    myPost("/tool/user/LoadUser.ashx",
                    {  },
                    function (val, data) {
                        console.log(data.msg);
                        
                            layer.msg(data.msg);
                        
                        renderForm();
                        table.reload('contentTable');
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
                    console.log(data.UserID);

                    myPost("/tool/user/DelUser.ashx",
                        { UserID: data.UserID },
                        function (val, adata) {
                            console.log(adata.msg);
                            layer.msg(adata.msg);
                        });

                    obj.del();
                    layer.close(index);


                });
            } else if (obj.event === 'edit') {
                var sdata = obj.data;
                var AddUser = document.getElementById('submitUser').innerHTML;
                layer.open({
                    type: 1,
                    content: AddUser, //这里content是一个普通的String
                    area: ['570px', '710px'],
                    title: '修改用户信息',
                    success: function (layero, index) {
                        console.log(index);
                        //addStudent();
                        //添加属性
                        $("input[name='userID']").val(sdata.UserID);
                        $("input[name='Passwd']").val(sdata.Passwd);
                        $("input[name='Identity']").val(sdata.Identity);
                        $("input[name='nickname']").val(sdata.Nickname);
                        $("input[name='AllowLogin']").val(sdata.AllowLogin);

                        form.render();
                        layui.use('form', function () {
                            var form = layui.form;

                            //监听提交
                            form.on('submit(submitUserForm)', function (data) {
                                //layer.msg(JSON.stringify(data.field));
                                myPost("/tool/user/UpdUser.ashx",
                                    { val: JSON.stringify(data.field) },
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
                var userid = $("input[name='UserID']");
                var nickname = $("input[name='Nickname']");


                //执行重载
                table.reload('contentTable', {
                    page: {
                        curr: 1 //重新从第 1 页开始
                    }
                    , where: {
                        userID: userid.val(),
                        nickName: nickname.val(),
                        
                    }
                }, 'data');
            }
        };

        $('#user_search').on('click', function () {
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
