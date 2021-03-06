//ajax post
function myPost(url, data, func) {
    $.ajax({
        type: "post", //post方式 
        data: data,
        url: url,//"Demo.aspx/SayHello",//方法所在页面和方法名
        dataType: "json",
        success: function (data) {
            func(1, data);
        },
        error: function (err) {
            func(-1, err);
        }
    });
}

layui.use('element', function () {
    var element = layui.element;
});


function renderForm() {
    layui.use('form', function () {
        var form = layui.form;
        form.render();
    });
}
//获取班级并绑定下拉框
//id: 下拉框id
function bindClass(id, isDefault = false, isView = false, val = "") {
    myPost("/tool/universe/getClass.ashx",
        {},
        function (value, data) {
            console.log(data);
            $(id).empty();
            $(id).append(new Option("请选择班级", ""));
            if(isDefault){
                $.each(data.data, function (index, item) {
                    if(isView){
                        if(val == item.ClassName){
                            $(id).append(new Option(item.ClassName, item.ClassID, true, true));
                        }else{
                            $(id).append(new Option(item.ClassName, item.ClassID));
                        }
                    }else{
                        if(val == item.ClassID){
                            $(id).append(new Option(item.ClassName, item.ClassID, true, true));
                        }else{
                            $(id).append(new Option(item.ClassName, item.ClassID));
                        }
                    }
                    
                });
            }else{
                $.each(data.data, function (index, item) {
                    $(id).append(new Option(item.ClassName, item.ClassID));
                });
            }
            
            layui.form.render();
        });
}
//获取院系并绑定下拉框
//id: 下拉框id
//isView: 是否按照显示值绑定
//val:显示值
function bindDepartment(id, isDefault = false, isView = false, val = ""){
    myPost("/tool/universe/getDepartment.ashx",
        {},
        function (value, data) {
            console.log(data);
            $(id).empty();
            $(id).append(new Option("请选择院系", ""));
            if(isDefault){
                $.each(data.data, function (index, item) {
                    if(isView){
                        if(val == item.DepName){
                            $(id).append(new Option(item.DepName, item.DepID, true, true));
                        }else{
                            $(id).append(new Option(item.DepName, item.DepID));
                        }
                    }else{
                        if(val == item.DepID){
                            $(id).append(new Option(item.DepName, item.DepID, true, true));
                        }else{
                            $(id).append(new Option(item.DepName, item.DepID));
                        }
                    }
                    
                });
            }else{
                $.each(data.data, function (index, item) {
                    $(id).append(new Option(item.DepName, item.DepID));
                });
            }
            layui.form.render();
        });
}

//获取课程并绑定下拉框
//id: 下拉框id
//isView: 是否按照显示值绑定
//val:显示值
function bindCourse(id, isDefault = false, isView = false, val = ""){
    myPost("/tool/universe/GetCourse.ashx",
        {},
        function (value, data) {
            console.log(data);
            $(id).empty();
            $(id).append(new Option("请选择课程", ""));
            if(isDefault){
                $.each(data.data, function (index, item) {
                    if(isView){
                        if(val == item.CourseName){
                            $(id).append(new Option(item.CourseName, item.CourseID, true, true));
                        }else{
                            $(id).append(new Option(item.CourseName, item.CourseID));
                        }
                    }else{
                        if(val == item.CourseID){
                            $(id).append(new Option(item.CourseName, item.CourseID, true, true));
                        }else{
                            $(id).append(new Option(item.CourseName, item.CourseID));
                        }
                    }
                    
                });
            }else{
                $.each(data.data, function (index, item) {
                    $(id).append(new Option(item.CourseName, item.CourseID));
                });
            }
            layui.form.render();
        });
}

//获取上课时间并绑定下拉框
//id: 下拉框id
//isView: 是否按照显示值绑定
//val:显示值
function bindSchedule(id, isDefault = false, isView = false, val = ""){
    myPost("/tool/universe/GetSchedule.ashx",
        {},
        function (value, data) {
            console.log(data);
            $(id).empty();
            $(id).append(new Option("请选择上课时间", ""));
            if(isDefault){
                $.each(data.data, function (index, item) {
                    if(isView){
                        if(val == item.TimeSpan){
                            $(id).append(new Option(item.TimeSpan, item.TheatreID, true, true));
                        }else{
                            $(id).append(new Option(item.TimeSpan, item.TheatreID));
                        }
                    }else{
                        if(val == item.TheatreID){
                            $(id).append(new Option(item.TimeSpan, item.TheatreID, true, true));
                        }else{
                            $(id).append(new Option(item.TimeSpan, item.TheatreID));
                        }
                    }
                    
                });
            }else{
                $.each(data.data, function (index, item) {
                    $(id).append(new Option(item.TimeSpan, item.TheatreID));
                });
            }
            layui.form.render();
        });
}


//获取教师时间并绑定下拉框
//id: 下拉框id
//isView: 是否按照显示值绑定
//val:显示值
function bindTeacher(id, isDefault = false, isView = false, val = ""){
    myPost("/tool/universe/GetTeacher.ashx",
        {},
        function (value, data) {
            console.log(data);
            $(id).empty();
            $(id).append(new Option("请选择教师", ""));
            if(isDefault){
                $.each(data.data, function (index, item) {
                    if(isView){
                        if(val == item.TeaName){
                            $(id).append(new Option(item.TeaName, item.TeaID, true, true));
                        }else{
                            $(id).append(new Option(item.TeaName, item.TeaID));
                        }
                    }else{
                        if(val == item.TeaID){
                            $(id).append(new Option(item.TeaName, item.TeaID, true, true));
                        }else{
                            $(id).append(new Option(item.TeaName, item.TeaID));
                        }
                    }
                    
                });
            }else{
                $.each(data.data, function (index, item) {
                    $(id).append(new Option(item.TeaName, item.TeaID));
                });
            }
            layui.form.render();
        });
}

//获取教室时间并绑定下拉框
//id: 下拉框id
//isView: 是否按照显示值绑定
//val:显示值
function bindTheatre(id, isDefault = false, isView = false, val = ""){
    myPost("/tool/universe/GetTheatre.ashx",
        {},
        function (value, data) {
            console.log(data);
            $(id).empty();
            $(id).append(new Option("请选择上课教室", ""));
            if(isDefault){
                $.each(data.data, function (index, item) {
                    if(isView){
                        if(val == item.Site){
                            $(id).append(new Option(item.Site, item.TheatreID, true, true));
                        }else{
                            $(id).append(new Option(item.Site, item.TheatreID));
                        }
                    }else{
                        if(val == item.TheatreID){
                            $(id).append(new Option(item.Site, item.TheatreID, true, true));
                        }else{
                            $(id).append(new Option(item.Site, item.TheatreID));
                        }
                    }
                    
                });
            }else{
                $.each(data.data, function (index, item) {
                    $(id).append(new Option(item.Site, item.TheatreID));
                });
            }
            layui.form.render();
        });
}

//获取学期并绑定下拉框
//id: 下拉框id
//isView: 是否按照显示值绑定
//val:显示值
function bindTerm(id, isDefault = false, isView = false, val = ""){
    myPost("/tool/universe/GetTerm.ashx",
        {},
        function (value, data) {
            console.log(data);
            $(id).empty();
            $(id).append(new Option("请选择学期", ""));
            if(isDefault){
                $.each(data.data, function (index, item) {
                    if(isView){
                        if(val == item.TermName){
                            $(id).append(new Option(item.TermName, item.TermID, true, true));
                        }else{
                            $(id).append(new Option(item.TermName, item.TermID));
                        }
                    }else{
                        if(val == item.TermID){
                            $(id).append(new Option(item.TermName, item.TermID, true, true));
                        }else{
                            $(id).append(new Option(item.TermName, item.TermID));
                        }
                    }
                    
                });
            }else{
                $.each(data.data, function (index, item) {
                    $(id).append(new Option(item.TermName, item.TermID));
                });
            }
            layui.form.render();
        });
}

//获取院系并绑定下拉框
//id: 下拉框id
//isView: 是否按照显示值绑定
//val:显示值
function bindDay(id, set = false,val = ""){
    $(id).empty();
    $(id).append(new Option("请选择上课周", ""));
    if(set){
        switch(val){
            case 1:
                $(id).append(new Option("周一", "1", true, true));
                $(id).append(new Option("周二", "2"));
                $(id).append(new Option("周三", "3"));
                $(id).append(new Option("周四", "4"));
                $(id).append(new Option("周五", "5"));
                $(id).append(new Option("周六", "6"));
                $(id).append(new Option("周日", "7"));
                break;
            case 2:
                $(id).append(new Option("周一", "1"));
                $(id).append(new Option("周二", "2", true, true));
                $(id).append(new Option("周三", "3"));
                $(id).append(new Option("周四", "4"));
                $(id).append(new Option("周五", "5"));
                $(id).append(new Option("周六", "6"));
                $(id).append(new Option("周日", "7"));
                break;
            case 3:
                $(id).append(new Option("周一", "1"));
                $(id).append(new Option("周二", "2"));
                $(id).append(new Option("周三", "3", true, true));
                $(id).append(new Option("周四", "4"));
                $(id).append(new Option("周五", "5"));
                $(id).append(new Option("周六", "6"));
                $(id).append(new Option("周日", "7"));
                break;
            case 4:
                $(id).append(new Option("周一", "1"));
                $(id).append(new Option("周二", "2"));
                $(id).append(new Option("周三", "3"));
                $(id).append(new Option("周四", "4", true, true));
                $(id).append(new Option("周五", "5"));
                $(id).append(new Option("周六", "6"));
                $(id).append(new Option("周日", "7"));
                break;
            case 5:
                $(id).append(new Option("周一", "1"));
                $(id).append(new Option("周二", "2"));
                $(id).append(new Option("周三", "3"));
                $(id).append(new Option("周四", "4"));
                $(id).append(new Option("周五", "5", true, true));
                $(id).append(new Option("周六", "6"));
                $(id).append(new Option("周日", "7"));
                break;
            case 6:
                $(id).append(new Option("周一", "1"));
                $(id).append(new Option("周二", "2"));
                $(id).append(new Option("周三", "3"));
                $(id).append(new Option("周四", "4"));
                $(id).append(new Option("周五", "5"));
                $(id).append(new Option("周六", "6", true, true));
                $(id).append(new Option("周日", "7"));
                break;
            case 7:
                $(id).append(new Option("周一", "1"));
                $(id).append(new Option("周二", "2"));
                $(id).append(new Option("周三", "3"));
                $(id).append(new Option("周四", "4"));
                $(id).append(new Option("周五", "5"));
                $(id).append(new Option("周六", "6"));
                $(id).append(new Option("周日", "7", true, true));
                break;

        }
    } else {
        $(id).append(new Option("周一", "1"));
        $(id).append(new Option("周二", "2"));
        $(id).append(new Option("周三", "3"));
        $(id).append(new Option("周四", "4"));
        $(id).append(new Option("周五", "5"));
        $(id).append(new Option("周六", "6"));
        $(id).append(new Option("周日", "7"));
    }
    layui.form.render();
}



//获取其他信息并绑定下拉框
//url:后端数据接口
//id: 下拉框id
//tip: 首行提示信息
//view: 数据显示字段
//val: 数据值字段
function bindUniverse(url, id, tip, view, val){
    myPost(url,
        {},
        function (value, data) {
            console.log(data);
            $(id).empty();
            $(id).append(new Option(tip, ""));
            $.each(data.data, function (index, item) {
                $(id).append(new Option(item[view], item[val]));
            });
            layui.form.init();
        });
}



function getcookies(name){
    var arr = document.cookie.match(new RegExp("(^| )" + name + "=([^;]*)(;|$)"));
    console.log(arr[2]);
    if(arr != null) return arr[2];
    
    return null;
  }

  function delcookies(name){
    var exp = new Date();
    exp.setTime(exp.getTime() - 1);
    var val = decodeURIComponent(getcookies(name));
    if(val != null){
      document.cookie = name + "=" + val + ";expires=" + exp.toGMTString() + ";path=/";
    }
  }



