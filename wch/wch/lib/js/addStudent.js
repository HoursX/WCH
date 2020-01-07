function addStudent() {
    bindClass("#classGridding");
    bindDepartment("#depGridding");
    layui.use(['form', 'layedit', 'laydate'], function(){
        var form = layui.form
        ,layer = layui.layer
        ,layedit = layui.layedit
        ,laydate = layui.laydate;
        
        //日期
        laydate.render({
            elem: '#date'
        });

        
    });
 
}