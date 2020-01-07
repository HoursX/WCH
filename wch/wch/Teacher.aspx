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
        <li class="layui-nav-item"><a href="">商品管理</a></li>
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
          <a href="javascript:;">
            <img src="http://t.cn/RCzsdCq" class="layui-nav-img">
            Bikteen
          </a>
          <dl class="layui-nav-child">
            <dd><a href="">基本资料</a></dd>
            <dd><a href="">安全设置</a></dd>
          </dl>
        </li>
        <li class="layui-nav-item"><a href="">退出</a></li>
      </ul>
    </div>

    <div class="layui-side layui-bg-black">
      <div class="layui-side-scroll">
        <!-- 左侧导航区域（可配合layui已有的垂直导航） -->
        <ul class="layui-nav layui-nav-tree" lay-filter="test">
          <li class="layui-nav-item layui-nav-itemed">
            <a class="" href="javascript:;">我的应用</a>
            <dl class="layui-nav-child">
              <dd><a href="javascript:;" id="StudentView">查看授课信息</a></dd>
              <dd><a href="javascript:;" id="AddStudent">查看选课学生名单</a></dd>
              <dd><a href="javascript:;" id="Select">录入成绩</a></dd>
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

<script src="lib/jquery-3.4.1/dist/jquery.js"></script>
<script src="./lib/layui/layui.js" charset="utf-8"></script>
<script src="./lib/js/wch-tool.js"></script>

<!-- 注意：如果你直接复制所有代码到本地，上述js路径需要改成你本地的 -->


</html>
