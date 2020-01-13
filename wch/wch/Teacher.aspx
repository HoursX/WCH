<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teacher.aspx.cs" Inherits="wch.Teacher" %>

<!DOCTYPE html>
<html>

<head>
  <meta name="renderer" content="webkit">
  <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
  <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
  <title>WCH选课管理系统-后台管理</title>
  <link href="lib/layui/css/layui.css" rel="stylesheet" />
</head>

<body class="layui-layout-body">
  <div class="layui-layout layui-layout-admin">
    <div class="layui-header layui-bg-cyan">
      <div class="layui-logo">WCH选课管理系统</div>
      <!-- 头部区域（可配合layui已有的水平导航） -->
      <ul class="layui-nav layui-layout-left">
        <li class="layui-nav-item layadmin-flexible" lay-unselect>
          <a href="javascript:;" layadmin-event="flexible" title="@Model.Localizer[" HideShow"]">
            <i class="layui-icon layui-icon-shrink-right" id="LAY_app_flexible"></i>
          </a>
        </li>
        <li class="layui-nav-item"><a href="">面板首页</a></li>
        <li class="layui-nav-item"><a href="">用户</a></li>
        <li class="layui-nav-item">
          <a href="javascript:;">其它系统</a>
          <dl class="layui-nav-child">
            <dd><a href="">邮件管理</a></dd>
            <dd><a href="">消息管理</a></dd>
            <dd><a href="">授权管理</a></dd>
          </dl>
        </li>
      </ul>
      <ul class="layui-nav layui-layout-right">
          <li class="layui-nav-item">
              当前时间：
            </li>
        <li class="layui-nav-item" id="TimeView">
        </li>
        <li class="layui-nav-item">
          <a href="javascript:;">
            <img src="http://t.cn/RCzsdCq" class="layui-nav-img">
            Bikteen
          </a>
          <dl class="layui-nav-child">
            <dd><a href="">基本资料</a></dd>
            <dd><a href="">安全设置</a></dd>
          </dl>
        </li>
        <li class="layui-nav-item"><a href="./Login.aspx">退出</a></li>
      </ul>
    </div>

    <div class="layui-side layui-bg-black">
      <div class="layui-side-scroll">
        <!-- 左侧导航区域（可配合layui已有的垂直导航） -->
        <ul class="layui-nav layui-nav-tree" lay-filter="test">
          <li class="layui-nav-item layui-nav-itemed">
            <a class="" href="javascript:;">我的应用</a>
            <dl class="layui-nav-child">
              <dd><a href="javascript:;" id="SeeCourse">查看授课信息</a></dd>
              <dd><a href="javascript:;" id="SeeStudent">查看选课学生名单</a></dd>
              <dd><a href="javascript:;" id="PushGrade">录入成绩</a></dd>
            </dl>
          </li>
      </div>
    </div>




    <div class="layui-body">
      <!-- 内容主体区域 -->



        <!-- 放置内容请先清空其他区域 -->


        <div class="layui-main" id="main-controller">
          <!-- 放置搜索条件 -->

          <div id="form-content">
              <!-- 表单放置处 -->
    
    
          </div>

          

          

          <div id="table-main">
            
          </div>



        </div>


        

      </div>

      <div class="layui-footer">
        <!-- 底部固定区域 -->
        © 2020 <a href="./admin.aspx">wch学生管理系统</a>
      </div>

    </div>
  </div>





</body>
<script type="text/html" id="seeStudent">
<!-- 放置工具栏 -->
<!-- 放置表单 -->


<div class="layui-collapse">
  <div class="layui-colla-item">


    <h2 class="layui-colla-title">查询条件</h2>
    <div class="layui-colla-content layui-show">
      <!-- 放置工具栏 -->
      <div class="stu-table">
        课程名:
        <div class="layui-input-inline">
          <input type="text" name="coursename" placeholder="请输入课程名" autocomplete="off" class="layui-input">
        </div>
        <button class="layui-btn layui-btn-md" id="course_search" data-type="reload">查询</button>
      </div>
    </div>

  </div>
</div>
<table id="context" lay-filter="context" class="layui-hide"></table>

</script>
<script type="text/html" id="submitGrade">
  <form class="layui-form" style="margin-top:30px;">
 
<input type="hidden" name="StuID" value="0">
<input type="hidden" name="TimeID" value="0">
       <div class="layui-form-item">
          <label class="layui-form-label" >成绩</label>
      <div class="layui-input-inline" >
          <input type="text" name="Mark" lay-verify="required" lay-reqtext="成绩是必填项，岂能为空？" placeholder="请输入" autocomplete="off" class="layui-input">
      </div>
      </div>

      <div class="layui-form-item">
  <div class="layui-input-block">
    <button type="submit" class="layui-btn" lay-submit="" lay-filter="submitGradeForm">立即提交</button>
    <button type="reset" class="layui-btn layui-btn-primary">重置</button>
  </div>
</div>
  </form>
</script>

<script type="text/html" id="barDemo">
<a class="layui-btn layui-btn-xs" lay-event="edit">录入成绩</a>
</script>

<script type="text/html" id="coursetoolbarDemo">
<div class="layui-btn-container">
  <button class="layui-btn layui-btn-sm" lay-event="getCheckData">获取选中行数据</button>
  <button class="layui-btn layui-btn-sm" lay-event="getCheckLength">获取选中数目</button>
  <button class="layui-btn layui-btn-sm" lay-event="isAll">验证是否全选</button>
</div>
</script>

<script src="lib/jquery-3.4.1/dist/jquery.js"></script>
<script src="./lib/layui/layui.js" charset="utf-8"></script>
<script src="./lib/js/wch-tool.js"></script>
<script src="./lib/js/seeStudentView.js"></script>
<script src="./lib/js/seeCourseView.js"></script>
<script src="./lib/js/pushGrade.js"></script>
<!-- 注意：如果你直接复制所有代码到本地，上述js路径需要改成你本地的 -->
<script>

    renderForm();

    $("#SeeCourse").click(function () {
        var htt = "<table id='context' lay-filter='context' class='layui-hide'></table>";
        $('#form-content').html("");
        $('#table-main').html(htt);
        seeCourseView();
        layui.element.init();
    });
    $("#SeeStudent").click(function () {
        var htt = document.getElementById('seeStudent').innerHTML;
        $('#form-content').html("");
        $('#table-main').html(htt);
        seeStudentView();
        layui.element.init();
    });
    $("#PushGrade").click(function () {
        var htt = "<table id='context' lay-filter='context' class='layui-hide'></table>";
        $('#form-content').html("");
        $('#table-main').html(htt);
        pushGrade();
        layui.element.init();
    });
    setInterval(function () {
        myPost("/tool/universe/GetTime.ashx", {}, function (val, data) {
            //console.log(data.data);
            $("#TimeView").html(data.data);
        });
    }, 1000);
</script>

</html>
