<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="wch.admin" %>

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
            <img id="photo" src="http://t.cn/RCzsdCq" class="layui-nav-img">
            <div id="nickname"></div>
          </a>
          <dl class="layui-nav-child">
            <dd><a href="">基本资料</a></dd>
            <dd><a href="">安全设置</a></dd>
          </dl>
        </li>
        <li class="layui-nav-item">
            <a href="./Login.aspx">退出</a>
            
        </li>
      </ul>
    </div>

    <div class="layui-side layui-bg-black">
      <div class="layui-side-scroll">
        <!-- 左侧导航区域（可配合layui已有的垂直导航） -->
        <ul class="layui-nav layui-nav-tree" lay-filter="test">
          <li class="layui-nav-item layui-nav-itemed">
            <a class="" href="javascript:;">学生管理</a>
            <dl class="layui-nav-child">
              <dd><a href="javascript:;" id="StudentView">学生维护</a></dd>
              <dd><a href="javascript:;" id="ClassView">班级维护</a></dd>
              <!--<dd><a href="javascript:;" id="CourseSelect">学生选课信息查看</a></dd>-->
            </dl>
          </li>
          <li class="layui-nav-item layui-nav-itemed">
            <a class="" href="javascript:;">教师管理</a>
            <dl class="layui-nav-child">
              <dd><a href="javascript:;" id="Teacherview">查看所有教师</a></dd>
            </dl>
          </li>
          <li class="layui-nav-item">
            <a href="javascript:;">校级管理</a>
            <dl class="layui-nav-child">
              <dd><a href="javascript:;" id="Department">院系维护</a></dd>
              <dd><a href="javascript:;" id="TermView">学期维护</a></dd>
              <dd><a href="javascript:;" id="CourseView">课程维护</a></dd>
              <dd><a href="javascript:;" id="wch_TimeTable">排课</a></dd>
            </dl>
          </li>
          <li class="layui-nav-item"><a href="javascript:;" id="userManage">用户管理</a></li>
          <li class="layui-nav-item"><a href="javascript:;">其他</a></li>
        </ul>
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

<script src="lib/jquery-3.4.1/dist/jquery.js"></script>
<script src="./lib/layui/layui.js" charset="utf-8"></script>
<script src="./lib/js/wch-tool.js"></script>

<!-- 注意：如果你直接复制所有代码到本地，上述js路径需要改成你本地的 -->

<!-- ajax调用 -->
<script>



</script>
<!-- 查询学生工具栏-->
<script type="text/html" id="studentViewTool">
<!-- 放置工具栏 -->
<!-- 放置表单 -->


<div class="layui-collapse">
  <div class="layui-colla-item">


    <h2 class="layui-colla-title">查询条件</h2>
    <div class="layui-colla-content layui-show">
      <!-- 放置工具栏 -->
      <div class="stu-table">
        姓名:
        <div class="layui-input-inline">
          <input type="text" name="stuname" placeholder="请输入姓名" autocomplete="off" class="layui-input">
        </div>
        学号:
        <div class="layui-input-inline">
          <input type="text" name="stuid" placeholder="请输入学号" autocomplete="off" class="layui-input">
        </div>
        班级:
        <div class="layui-input-inline">
          <input type="text" name="classname" placeholder="请输入班级" autocomplete="off" class="layui-input">
        </div>
        <button class="layui-btn layui-btn-md" id="stu_search" data-type="reload">查询</button>
      </div>
    </div>

  </div>
</div>
<table id="context" lay-filter="context" class="layui-hide"></table>

</script>

<!-- 排课工具栏-->
<script type="text/html" id="timeTableViewTool">
  <!-- 放置工具栏 -->
  <!-- 放置表单 -->
  
  
  <div class="layui-collapse">
    <div class="layui-colla-item">
  
  
      <h2 class="layui-colla-title">查询条件</h2>
      <div class="layui-colla-content layui-show">
        <!-- 放置工具栏 -->
        <div class="time-table">
          课程名:
          <div class="layui-input-inline">
            <input type="text" name="CourseName" placeholder="请输入课程名" autocomplete="off" class="layui-input">
          </div>
          院系名:
          <div class="layui-input-inline">
            <input type="text" name="DepName" placeholder="请输入院系名" autocomplete="off" class="layui-input">
          </div>
          教师:
          <div class="layui-input-inline">
            <input type="text" name="TeaName" placeholder="请输入教师名" autocomplete="off" class="layui-input">
          </div>
          学期:
          <div class="layui-input-inline">
            <input type="text" name="TermName" placeholder="请输入学期" autocomplete="off" class="layui-input">
          </div>
          教室:
          <div class="layui-input-inline">
            <input type="text" name="Site" placeholder="请输入教室" autocomplete="off" class="layui-input">
          </div>
          <button class="layui-btn layui-btn-md" id="time_table_search" data-type="reload">查询</button>
        </div>
      </div>
  
    </div>
  </div>
  <table id="context" lay-filter="context" class="layui-hide"></table>
  
</script>


<script type="text/html" id="teacherViewTool">
  <div class="layui-collapse">
  <div class="layui-colla-item">
<h2 class="layui-colla-title">查询条件</h2>
<div class="layui-colla-content layui-show">
  <!-- 放置工具栏 -->
      <div class="stu-table">
          姓名:
          <div class="layui-input-inline">
              <input type="text" name="teaname" placeholder="请输入姓名" autocomplete="off" class="layui-input">
          </div>
          工号:
          <div class="layui-input-inline">
              <input type="text" name="teaid" placeholder="请输入工号" autocomplete="off" class="layui-input">
          </div>
          院系:
          <div class="layui-input-inline">
              <input type="text" name="depname" placeholder="请输入所在院系" autocomplete="off" class="layui-input">
          </div>
          <button class="layui-btn layui-btn-md" id="tea_search" data-type="reload">查询</button>
      </div>
</div>
</div>
</div>
<table id="context" lay-filter="context" class="layui-hide"></table>


</script>

<script type="text/html" id="submitTimeTable">
  <form class="layui-form" style="margin-top: 20px">
    <input type="hidden" name="TimeID" value="0" id="TimeID">

    <div class="layui-form-item">
      <label class="layui-form-label">课程名</label>
      <div class="layui-input-inline">
        <select name="CourseID" lay-verify="required" lay-search="" id="CourseGridding">
          <option value="">直接选择或搜索选择</option>
        </select>
      </div>
    </div>

    <div class="layui-form-item">
      <label class="layui-form-label">授课老师</label>
      <div class="layui-input-inline">
        <select name="TeaID" lay-verify="" lay-search="" id="TeaGridding">
          <option value="">直接选择或搜索选择</option>
        </select>
      </div>
    </div>
    
    
    <div class="layui-form-item">
      <label class="layui-form-label">容量</label>
      <div class="layui-input-inline">
        <input type="text" name="Capacity" lay-verify="required" lay-reqtext="必填项" placeholder="请输入"
          autocomplete="off" class="layui-input">
      </div>
    </div>
    
    <div class="layui-form-item">
      <label class="layui-form-label">允许选课</label>
      <div class="layui-input-block">
        <input type="radio" name="AllowView" value="true" title="是">
        <input type="radio" name="AllowView" value="false" title="否">
      </div>
    </div>
    
    <div class="layui-form-item">
      <label class="layui-form-label">星期</label>
      <div class="layui-input-inline">
        <select name="Day" lay-verify="required" lay-search="" id="selectDay">
          <option value="1">周一</option>
          <option value="2">周二</option>
          <option value="3">周三</option>
          <option value="4">周四</option>
          <option value="5">周五</option>
          <option value="6">周六</option>
          <option value="7">周日</option>
        </select>
      </div>
    </div>
    
    <div class="layui-form-item">
      <label class="layui-form-label">上课时间</label>
      <div class="layui-input-inline">
        <select name="ScheduleID" lay-verify="required" lay-search="" id="ScheduleGridding">
          <option value="">直接选择或搜索选择</option>
        </select>
      </div>
    </div>
    
    <div class="layui-form-item">
      <label class="layui-form-label">教室</label>
      <div class="layui-input-inline">
        <select name="TheatreID" lay-verify="required" lay-search="" id="TheatreGridding">
          <option value="">直接选择或搜索选择</option>
        </select>
      </div>
    </div>

    <div class="layui-form-item">
      <label class="layui-form-label">学期</label>
      <div class="layui-input-inline">
        <select name="TermID" lay-verify="required" lay-search="" id="TermGridding">
          <option value="">直接选择或搜索选择</option>
        </select>
      </div>
    </div>
    
    <div class="layui-form-item">
        <div class="layui-input-block">
          <button class="layui-btn" lay-submit lay-filter="submitTimeForm">立即提交</button>
          <button type="reset" class="layui-btn layui-btn-primary">重置</button>
        </div>
      </div>
    </form>
</script>

<script type="text/html" id="courseSelViewTool">
  <div class="layui-collapse">
  <div class="layui-colla-item">
<h2 class="layui-colla-title">查询条件</h2>
<div class="layui-colla-content layui-show">
  <!-- 放置工具栏 -->
      <div class="stu-table">
          学号:
          <div class="layui-input-inline">
              <input type="text" name="teaname" placeholder="请输入学号" autocomplete="off" class="layui-input">
          </div>
          姓名:
          <div class="layui-input-inline">
              <input type="text" name="teaid" placeholder="请输入姓名" autocomplete="off" class="layui-input">
          </div>
          学期:
          <div class="layui-input-inline">
              <input type="text" name="depname" placeholder="请输入学期" autocomplete="off" class="layui-input">
          </div>
          课程:
          <div class="layui-input-inline">
              <input type="text" name="depname" placeholder="请输入课程" autocomplete="off" class="layui-input">
          </div>
          教师:
          <div class="layui-input-inline">
              <input type="text" name="depname" placeholder="请输入教师" autocomplete="off" class="layui-input">
          </div>
          <button class="layui-btn layui-btn-md" id="cos_search" data-type="reload">查询</button>
      </div>
</div>
</div>
</div>
<table id="context" lay-filter="context" class="layui-hide"></table>


</script>

<script type="text/html" id="userViewTool">
<div class="layui-collapse">
<div class="layui-colla-item">
<h2 class="layui-colla-title">查询条件</h2>
<div class="layui-colla-content layui-show">
  <!-- 放置工具栏 -->
      <div class="stu-table">
          账号:
          <div class="layui-input-inline">
              <input type="text" name="UserID" placeholder="请输入账号" autocomplete="off" class="layui-input">
          </div>
          昵称:
          <div class="layui-input-inline">
              <input type="text" name="Nickname" placeholder="请输入昵称" autocomplete="off" class="layui-input">
          </div>
          <button class="layui-btn layui-btn-md" id="user_search" data-type="reload">查询</button>
      </div>
</div>
</div>
</div>
<table id="context" lay-filter="context" class="layui-hide"></table>


</script>


<script type="text/html" id="classViewTool">
<div class="layui-collapse">
<div class="layui-colla-item">
<h2 class="layui-colla-title">查询条件</h2>
<div class="layui-colla-content layui-show">
  <!-- 放置工具栏 -->
      <div class="class-table">
          班级名称:
          <div class="layui-input-inline">
              <input type="text" name="ClassName" placeholder="请输入班级名称" autocomplete="off" class="layui-input">
          </div>
          <button class="layui-btn layui-btn-md" id="class_search" data-type="reload">查询</button>
      </div>
</div>
</div>
</div>
<table id="context" lay-filter="context" class="layui-hide"></table>


</script>

<script type="text/html" id="courseViewTool">
<div class="layui-collapse">
<div class="layui-colla-item">
<h2 class="layui-colla-title">查询条件</h2>
<div class="layui-colla-content layui-show">
  <!-- 放置工具栏 -->
    <div class="course-table">
          课程名:
          <div class="layui-input-inline">
              <input type="text" name="CourseName" placeholder="请输入课程名" autocomplete="off" class="layui-input">
          </div>
          <button class="layui-btn layui-btn-md" id="course_search" data-type="reload">查询</button>
      </div>
</div>
</div>
</div>
<table id="context" lay-filter="context" class="layui-hide"></table>


</script>

<script type="text/html" id="departmentViewTool">
<div class="layui-collapse">
<div class="layui-colla-item">
<h2 class="layui-colla-title">查询条件</h2>
<div class="layui-colla-content layui-show">
  <!-- 放置工具栏 -->
    <div class="department-table">
          院系名:
          <div class="layui-input-inline">
              <input type="text" name="DepartmentName" placeholder="请输入院系名" autocomplete="off" class="layui-input">
          </div>
          <button class="layui-btn layui-btn-md" id="department_search" data-type="reload">查询</button>
      </div>
</div>
</div>
</div>
<table id="context" lay-filter="context" class="layui-hide"></table>


</script>

<script type="text/html" id="termViewTool">
<div class="layui-collapse">
<div class="layui-colla-item">
<h2 class="layui-colla-title">查询条件</h2>
<div class="layui-colla-content layui-show">
  <!-- 放置工具栏 -->
    <div class="department-table">
          学期:
          <div class="layui-input-inline">
              <input type="text" name="TermName" placeholder="请输入学期" autocomplete="off" class="layui-input">
          </div>
          <button class="layui-btn layui-btn-md" id="term_search" data-type="reload">查询</button>
      </div>
</div>
</div>
</div>
<table id="context" lay-filter="context" class="layui-hide"></table>


</script>


<!-- 表单工具栏 -->
<!-- 查询学生工具栏-->
<script type="text/html" id="toolbarStudentView">
<div class="layui-btn-container">
  <button class="layui-btn layui-btn-sm" lay-event="getCheckData">获取选中行数据</button>
  <button class="layui-btn layui-btn-sm" lay-event="getCheckLength">获取选中数目</button>
  <button class="layui-btn layui-btn-sm" lay-event="isAll">验证是否全选</button>
  <button class="layui-btn layui-btn-sm" lay-event="add">增加学生</button>
</div>
</script>

<script type="text/html" id="toolbarUserView">
  <div class="layui-btn-container">
    <button class="layui-btn layui-btn-sm" lay-event="getCheckData">获取选中行数据</button>
    <button class="layui-btn layui-btn-sm" lay-event="getCheckLength">获取选中数目</button>
    <button class="layui-btn layui-btn-sm" lay-event="isAll">验证是否全选</button>
    <button class="layui-btn layui-btn-sm" lay-event="add">导入新用户</button>
  </div>
  </script>

<!-- 表单工具栏 -->
<script type="text/html" id="toolbarTimeTableView">
  <div class="layui-btn-container">
    <button class="layui-btn layui-btn-sm" lay-event="getCheckData">获取选中行数据</button>
    <button class="layui-btn layui-btn-sm" lay-event="getCheckLength">获取选中数目</button>
    <button class="layui-btn layui-btn-sm" lay-event="isAll">验证是否全选</button>
    <button class="layui-btn layui-btn-sm" lay-event="add">排课</button>
  </div>
  </script>
<script type="text/html" id="deptoolbarDemo">
<div class="layui-btn-container">
  <button class="layui-btn layui-btn-sm" lay-event="getCheckData">获取选中行数据</button>
  <button class="layui-btn layui-btn-sm" lay-event="getCheckLength">获取选中数目</button>
  <button class="layui-btn layui-btn-sm" lay-event="isAll">验证是否全选</button>
  <button class="layui-btn layui-btn-sm" lay-event="add">增加</button>
</div>
</script>
<script type="text/html" id="alltoolbarDemo">
<div class="layui-btn-container">
  <button class="layui-btn layui-btn-sm" lay-event="getCheckData">获取选中行数据</button>
  <button class="layui-btn layui-btn-sm" lay-event="getCheckLength">获取选中数目</button>
  <button class="layui-btn layui-btn-sm" lay-event="isAll">验证是否全选</button>
  <button class="layui-btn layui-btn-sm" lay-event="add">增加</button>
</div>
</script>

<script type="text/html" id="toolbarDemo">
<div class="layui-btn-container">
<button class="layui-btn layui-btn-sm" lay-event="getCheckData">获取选中行数据</button>
<button class="layui-btn layui-btn-sm" lay-event="getCheckLength">获取选中数目</button>
<button class="layui-btn layui-btn-sm" lay-event="isAll">验证是否全选</button>
<button class="layui-btn layui-btn-sm" lay-event="add">添加教师</button>
</div>

</script>
<script type="text/html" id="barDemo">
<a class="layui-btn layui-btn-xs" lay-event="edit">修改</a>
<a class="layui-btn layui-btn-danger layui-btn-xs" lay-event="del">删除</a>
</script>


<script type="text/html" id="submitStu">

<form class="layui-form" style="margin-top: 20px">

<div class="layui-form-item">
  <label class="layui-form-label">请输入学号</label>
  <div class="layui-input-inline">
    <input type="text" name="StuID" lay-verify="required" lay-reqtext="必填项" placeholder="请输入学号"
      autocomplete="off" class="layui-input">
  </div>
</div>

<div class="layui-form-item">
  <label class="layui-form-label">请输入姓名</label>
  <div class="layui-input-inline">
    <input type="text" name="StuName" lay-verify="required" lay-reqtext="必填项" placeholder="请输入姓名"
      autocomplete="off" class="layui-input">
  </div>
</div>

<div class="layui-form-item">
  <label class="layui-form-label">性别</label>
  <div class="layui-input-block">
    <input type="radio" name="Gender" value="true" title="男" checked="">
    <input type="radio" name="Gender" value="false" title="女">
  </div>
</div>

<div class="layui-form-item">
    <label class="layui-form-label">请输入年龄</label>
    <div class="layui-input-inline">
      <input type="text" name="StuAge" lay-verify="required" lay-reqtext="必填项" placeholder="请输入年龄"
        autocomplete="off" class="layui-input">
    </div>
  </div>

<div class="layui-form-item">
  <label class="layui-form-label">院系</label>
  <div class="layui-input-inline">
    <select name="DepID" lay-verify="required" lay-search="" id="depGridding">
      <option value="">直接选择或搜索选择</option>
    </select>
  </div>
</div>

<div class="layui-form-item">
  <label class="layui-form-label">班级</label>
  <div class="layui-input-inline">
    <select name="ClassID" lay-verify="required" lay-search="" id="classGridding">
      <option value="">直接选择或搜索选择</option>
    </select>
  </div>
</div>

<div class="layui-form-item">
  <div class="layui-inline">
    <label class="layui-form-label">手机</label>
    <div class="layui-input-inline">
      <input type="text" name="Tel" lay-verify="phone" autocomplete="off" class="layui-input">
    </div>
  </div>
</div>

<div class="layui-form-item">
  <div class="layui-inline">
    <label class="layui-form-label">入学时间</label>
    <div class="layui-input-block">
      <input type="text" name="Grade" lay-verify="required|date" id="date" autocomplete="off" class="layui-input">
    </div>
  </div>
</div>

<div class="layui-form-item layui-form-text">
    <div class="layui-block" style="width: 500px">
  <label class="layui-form-label">地址</label>
  <div class="layui-input-block">
    <textarea name="Address" placeholder="请输入内容" class="layui-textarea"></textarea>
  </div>
  </div>
</div>

<div class="layui-form-item">
    <div class="layui-input-block">
      <button class="layui-btn" lay-submit lay-filter="submitStuForm">立即提交</button>
      <button type="reset" class="layui-btn layui-btn-primary">重置</button>
    </div>
  </div>
</form>
</script>



<script type="text/html" id="submitDep">
  <form class="layui-form" style="margin-top:30px;">
 
<input type="hidden" name="DepID" id="depID" value="0">
      <div class="layui-form-item">
          <label class="layui-form-label" >院系名称</label>
      <div class="layui-input-inline" >
          <input type="text" name="DepName" lay-verify="required" lay-reqtext="院名是必填项，岂能为空？" placeholder="请输入" autocomplete="off" class="layui-input">
      </div>
      </div>
      <div class="layui-form-item">
  <div class="layui-input-block">
    <button type="submit" class="layui-btn" lay-submit="" lay-filter="submitDepForm">立即提交</button>
    <button type="reset" class="layui-btn layui-btn-primary">重置</button>
  </div>
</div>
  </form>
</script>

<script type="text/html" id="submitCla">
  <form class="layui-form" style="margin-top:30px;">
 
<input type="hidden" name="Classid" id="ClaID" value="0">
      <div class="layui-form-item">
            <div class="layui-inline">
          <label class="layui-form-label" >班级名称</label>
      <div class="layui-input-inline" >
          <input type="text" name="className" lay-verify="required" lay-reqtext="班级名称是必填项，岂能为空？" placeholder="请输入" autocomplete="off" class="layui-input">
      </div>
      </div>
          </div>
<div class="layui-form-item">
  <label class="layui-form-label">院系</label>
  <div class="layui-input-inline">
    <select name="DepID" lay-verify="required" lay-search="" id="depGridding4">
      <option value="">直接选择或搜索选择</option>
    </select>
  </div>
</div>
      <div class="layui-form-item">
            <div class="layui-inline">
          <label class="layui-form-label" >学生人数</label>
      <div class="layui-input-inline" >
          <input type="text" name="StuNum" lay-verify="required" lay-reqtext="学生人数是必填项，岂能为空？" placeholder="请输入" autocomplete="off" class="layui-input">
      </div>
      </div>
          </div>
      <div class="layui-form-item">
  <div class="layui-input-block">
    <button type="submit" class="layui-btn" lay-submit="" lay-filter="submitClaForm">立即提交</button>
    <button type="reset" class="layui-btn layui-btn-primary">重置</button>
  </div>
</div>
  </form>
</script>

<script type="text/html" id="submitCourse">
  <form class="layui-form" style="margin-top:30px;">
 
<input type="hidden" name="CourseID" id="CourseID" value="0">
      <div class="layui-form-item">
          <label class="layui-form-label" >课程名称</label>
      <div class="layui-input-inline" >
          <input type="text" name="CourseName" lay-verify="required" lay-reqtext="课程名称是必填项，岂能为空？" placeholder="请输入" autocomplete="off" class="layui-input">
      </div>
      </div>
    <div class="layui-form-item">
          <label class="layui-form-label" >学时</label>
      <div class="layui-input-inline" >
          <input type="text" name="Period" lay-verify="required" lay-reqtext="学时是必填项，岂能为空？" placeholder="请输入" autocomplete="off" class="layui-input">
      </div>
      </div>
        <div class="layui-form-item">
          <label class="layui-form-label" >学分</label>
      <div class="layui-input-inline" >
          <input type="text" name="Credit" lay-verify="required" lay-reqtext="学分是必填项，岂能为空？" placeholder="请输入" autocomplete="off" class="layui-input">
      </div>
      </div>
<div class="layui-form-item">
  <label class="layui-form-label">院系</label>
  <div class="layui-input-inline">
    <select name="DepID" lay-verify="required" lay-search="" id="depGridding5">
      <option value="">直接选择或搜索选择</option>
    </select>
  </div>
</div>
      <div class="layui-form-item">
  <div class="layui-input-block">
    <button type="submit" class="layui-btn" lay-submit="" lay-filter="submitCourseForm">立即提交</button>
    <button type="reset" class="layui-btn layui-btn-primary">重置</button>
  </div>
</div>
  </form>
</script>

<script type="text/html" id="submitUser">
    <form class="layui-form" style="margin-top:30px;">
        <div class="layui-form-item">
          <label class="layui-form-label" >用户ID</label>
      <div class="layui-input-inline" >
          <input type="text" name="userID" lay-verify="required" lay-reqtext="用户ID是必填项，岂能为空？" placeholder="请输入" autocomplete="off" class="layui-input">
      </div>
      </div>
        <div class="layui-form-item">
          <label class="layui-form-label" >密码</label>
      <div class="layui-input-inline" >
          <input type="text" name="Passwd" lay-verify="required" lay-reqtext="密码是必填项，岂能为空？" placeholder="请输入" autocomplete="off" class="layui-input">
      </div>
      </div>
        <div class="layui-form-item">
          <label class="layui-form-label" >标识</label>
      <div class="layui-input-inline" >
          <input type="text" name="Identity" lay-verify="required" lay-reqtext="标识是必填项，岂能为空？" placeholder="请输入" autocomplete="off" class="layui-input">
      </div>
      </div>
        <div class="layui-form-item">
          <label class="layui-form-label" >用户名</label>
      <div class="layui-input-inline" >
          <input type="text" name="nickname" lay-verify="required" lay-reqtext="用户名是必填项，岂能为空？" placeholder="请输入" autocomplete="off" class="layui-input">
      </div>
      </div>
        <div class="layui-form-item">
          <label class="layui-form-label" >AllowLogin</label>
      <div class="layui-input-inline" >
          <input type="text" name="AllowLogin" lay-verify="required" lay-reqtext="AllowLogin是必填项，岂能为空？" placeholder="请输入" autocomplete="off" class="layui-input">
      </div>
      </div>
              <div class="layui-form-item">
  <div class="layui-input-block">
    <button type="submit" class="layui-btn" lay-submit="" lay-filter="submitUserForm">立即提交</button>
    <button type="reset" class="layui-btn layui-btn-primary">重置</button>
  </div>
</div>
    </form>
</script>

<script type="text/html" id="submitTerm">
  <form class="layui-form" style="margin-top:30px;">
 
<input type="hidden" name="TermID" id="TermID" value="0">
      <div class="layui-form-item">
          <label class="layui-form-label" >学期</label>
      <div class="layui-input-inline" >
          <input type="text" name="TermName" lay-verify="required" lay-reqtext="学期是必填项，岂能为空？" placeholder="请输入" autocomplete="off" class="layui-input">
      </div>
      </div>
<div class="layui-form-item">
  <div class="layui-inline">
    <label class="layui-form-label">学期开始</label>
    <div class="layui-input-block">
      <input type="text" name="StartTime" lay-verify="required|date" id="date1" autocomplete="off" class="layui-input test-item">
    </div>
  </div>
</div>
      <div class="layui-form-item">
  <div class="layui-inline">
    <label class="layui-form-label">学期结束</label>
    <div class="layui-input-block">
      <input type="text" name="EndTime" lay-verify="required|date" id="date2" autocomplete="off" class="layui-input test-item">
    </div>
  </div>
</div>
      <div class="layui-form-item">
  <div class="layui-inline">
    <label class="layui-form-label">选课开始</label>
    <div class="layui-input-block">
      <input type="text" name="StartChoice" lay-verify="required|date" id="date3" autocomplete="off" class="layui-input test-item">
    </div>
  </div>
</div>
      <div class="layui-form-item">
  <div class="layui-inline">
    <label class="layui-form-label">选课结束</label>
    <div class="layui-input-block">
      <input type="text" name="EndChoice" lay-verify="required|date" id="date4" autocomplete="off" class="layui-input test-item">
    </div>
  </div>
</div>

      <div class="layui-form-item">
  <div class="layui-input-block">
    <button type="submit" class="layui-btn" lay-submit="" lay-filter="submitTermForm">立即提交</button>
    <button type="reset" class="layui-btn layui-btn-primary">重置</button>
  </div>
</div>
  </form>
</script>

<script type="text/html" id="submitTea">
  <form class="layui-form" style="margin-top:20px;">
      <div class="layui-form-item">
          <label class="layui-form-label">请输入工号</label>
      <div class="layui-input-inline" >
          <input type="text" name="TeaID" lay-verify="required" lay-reqtext="工号是必填项，岂能为空？" placeholder="请输入" autocomplete="off" class="layui-input">
      </div>
      </div>
      <div class="layui-form-item">
          <label class="layui-form-label">请输入姓名</label>
      <div class="layui-input-inline" >
          <input type="text" name="TeaName" lay-verify="required" lay-reqtext="姓名是必填项，岂能为空？" placeholder="请输入" autocomplete="off" class="layui-input">
      </div>
      </div>
        <div class="layui-form-item">
  <label class="layui-form-label">单选框</label>
  <div class="layui-input-block">
    <input type="radio" name="Gender" value="true" title="男" checked="">
    <input type="radio" name="Gender" value="false" title="女">
  </div>
</div>
      <div class="layui-form-item">
          <div class="layui-inline">
    <label class="layui-form-label">选择院系</label>
    <div class="layui-input-inline">
      <select name="DepID" lay-verify="required" lay-search="" lay-filter="select" id="depGridding2">
    <option value="">直接选择或搜索选择</option>
  </select>
    </div>
   </div>
  </div>
      <div class="layui-form-item">
          <label class="layui-form-label">请输入年龄</label>
      <div class="layui-input-inline" >
          <input type="text" name="TeaAge" lay-verify="required" lay-reqtext="年龄是必填项，岂能为空？" placeholder="请输入" autocomplete="off" class="layui-input">
      </div>
      </div>
      <div class="layui-form-item">
<div class="layui-inline">
  <label class="layui-form-label">手机</label>
  <div class="layui-input-inline">
    <input type="text" name="Tel" lay-verify="phone" placeholder="请输入" autocomplete="off" class="layui-input">
  </div>
</div>
</div>
      <div class="layui-form-item layui-form-text">
  <div class="layui-block" style="width: 500px">
<label class="layui-form-label">地址</label>
<div class="layui-input-block">
  <textarea name="Address" placeholder="请输入内容" class="layui-textarea"></textarea>
</div>
</div>
</div>

      <div class="layui-form-item">
  <div class="layui-input-block">
    <button type="submit" id="tea-postbtn" class="layui-btn" lay-submit="" lay-filter="submitTeaForm">立即提交</button>
    <button type="reset" id="tea-rebtn" class="layui-btn layui-btn-primary">重置</button>
  </div>
</div>
  </form>

</script>




<script src="./lib/js/studentView.js"></script>
<script src="./lib/js/teacherView.js"></script>
<script src="./lib/js/courseSelect.js"></script>
<script src="./lib/js/department.js"></script>
<script src="./lib/js/addStudent.js"></script>
<script src="./lib/js/timeTableView.js"></script>
<script src="./lib/js/userView.js"></script>
<script src="lib/js/classView.js"></script>
<script src="lib/js/courseView.js"></script>
<script src="lib/js/termView.js"></script>

<script>

  renderForm();

  $("#StudentView").click(function () {
    var StudentToolbar = document.getElementById('studentViewTool').innerHTML;

    $('#form-content').html("");
    $('#table-main').html(StudentToolbar);
    studentView();
    layui.element.init();

  });
  $("#Teacherview").click(function () {
    var TeacherToolbar = document.getElementById('teacherViewTool').innerHTML;
    $('#form-content').html("");
    $('#table-main').html(TeacherToolbar);
    teacherView();
    layui.element.init();
  });
  $("#CourseSelect").click(function () {
    var CourseSelToolbar = document.getElementById('courseSelViewTool').innerHTML;
    $('#form-content').html("");
    $('#table-main').html(CourseSelToolbar);
    courseSelect();
    layui.element.init();
});
$("#Department").click(function () {
    var DepartmentToolBar = document.getElementById('departmentViewTool').innerHTML;
  $('#form-content').html("");
    $('#table-main').html(DepartmentToolBar);
  department();
  layui.element.init();
});

    $("#ClassView").click(function () {
        var ClassToolbar = document.getElementById('classViewTool').innerHTML;
        $('#form-content').html("");
        $('#table-main').html(ClassToolbar);
        classView();
        layui.element.init();
    });
    $("#TermView").click(function () {
        var TermToolbar = document.getElementById('termViewTool').innerHTML;
        $('#form-content').html("");
        $('#table-main').html(TermToolbar);
        termView();
        layui.element.init();
    });
    $("#CourseView").click(function () {
        var CourseToolbar = document.getElementById('courseViewTool').innerHTML;
        $('#form-content').html("");
        $('#table-main').html(CourseToolbar);
        courseView();
        layui.element.init();
    });
  //排课
  $("#wch_TimeTable").click(function(){
    var timeTableViewTool = document.getElementById('timeTableViewTool').innerHTML;
    $('#form-content').html("");
    $('#table-main').html(timeTableViewTool);
    timeTableView();
    layui.element.init();
  });

  $("#userManage").click(function(){
    var timeTableViewTool = document.getElementById('userViewTool').innerHTML;
    $('#form-content').html("");
    $('#table-main').html(timeTableViewTool);
    userView();
    layui.element.init();
  });
  setInterval(function () {
      myPost("/tool/universe/GetTime.ashx", {}, function (val, data) {
          //console.log(data.data);
          $("#TimeView").html(data.data);
      });
  }, 1000);
</script>
<script>
  //$(document).ready(function(){
  //  var str = "";
  //  var name = decodeURIComponent(getcookies("user"));
  //  var id = decodeURIComponent(getcookies("Identity"));
  //  console.log(name);
  //  console.log(id);
  //  if(id == "1" && name != null){
  //    myPost("/tool/user/GetUser.ashx", {
  //      userID : name,
  //      page: 1,
  //      limit: 1
  //    }, function (val, data) {
  //      console.log(data);
  //      if(data.data.Nickname != null && data.data.Nickname != ""){
  //        //nickname
  //        $("#nickname").html(data.data.Nickname)
  //      }
  //      if(data.data.PhotoPath != null && data.data.PhotoPath != ""){
  //        $("#photo").attr("src", data.data.PhotoPath);
  //      }
  //        console.log(data.data.Nickname);
  //        console.log(data.data.PhotoPath);
  //        $("#TimeView").html(data.data);
  //    });
  //  }
  //  else{
  //    //window.location.href = "login.aspx";
  //  }
  //});

</script>

</html>