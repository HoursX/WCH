<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="wch.Login" %>

<!DOCTYPE html>
<html lang="zh-cn">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link rel="stylesheet" href="./lib/css/login.css">
    <title>wch学生选课系统-登录</title>
</head>

<body>
    <div class="container">
        <img src="./lib/img/bc.jpg" alt="">
        <div class="panel">

            <div class="content login">

                <div class="switch">
                    <span id='login' class='active'>请登录</span>
                </div>
                <form runat="server" id="formlogin">
                    <div class="input" placeholder='请输入学号或工号'>
                        <asp:TextBox ID="tb_user" runat="server"></asp:TextBox>
                        <div class="input" placeholder='请输入密码'>
                            <asp:TextBox ID="tb_pwd" runat="server" TextMode="Password"></asp:TextBox>
                        </div>

                        <div>
                            <span>
                                <asp:CheckBox ID="chk_login" runat="server" style="width:10%; display:inline-block"/>七天免登陆
                            </span>
                        </div>
                        <asp:Button ID="submit" runat="server" Text="登录" OnClick="submit_Click" />
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>

<script src="./lib/jquery-3.4.1/dist/jquery.js"></script>
<script>
    $('#login').click(function () {
        $('.switch span').removeClass('active');
        $(this).addClass('active');

        $(this).parents('.content').removeClass('signup');
        $(this).parents('.content').addClass('login');

        $('form button').text('LOGIN')

    })

    $('#signup').click(function () {
        $('.switch span').removeClass('active');
        $(this).addClass('active');

        $(this).parents('.content').removeClass('login');
        $(this).parents('.content').addClass('signup');

        $('form button').text('SIGNUP');
    })

    $('.input input').on('focus', function () {
        $(this).parent().addClass('focus');
    })

    $('.input input').on('blur', function () {
        if ($(this).val() === '')
            $(this).parent().removeClass('focus');
    })
</script>

</html>