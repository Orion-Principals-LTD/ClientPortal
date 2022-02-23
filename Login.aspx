<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <title>Orion Principals </title>
    <link rel="shortcut icon" href="image/favorite.png" />
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script type="text/javascript">
        //redirectHttpToHttps();
        function redirectHttpToHttps() {
            if (window.location.protocol == "http:") {
                var httpURL = window.location.hostname + window.location.pathname + window.location.search;
                var httpsURL = "https://" + httpURL;
                window.location = httpsURL;
            }
        }
        function EmpORClient() {

            if (document.getElementById("rbEmployee").checked = true) {
                document.getElementById("rbClient").checked = false;
            }
            if (document.getElementById("rbClient").checked = true) {
                document.getElementById("rbEmployee").checked = false;
            }
        }
    </script>
    <%--< meta http-equiv="Refresh" content="0" URL="https://www.yourdomainname.com" />--%>
    <%--<meta http-equiv="" content="0" URL="https://orionprincipalscat.azurewebsites.net/login" />--%>
    <!--===============================================================================================-->
    <link rel="icon" type="image/png" href="images/icons/favicon.ico" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Content/bootstrap.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="fonts/font-awesome.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="css/material-design-iconic-font.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="css/animate.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="css/hamburgers.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="css/animsition.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="css/select2.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="css/daterangepicker.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="css/util.css">
    <link rel="stylesheet" type="text/css" href="css/main.css">
    <!--===============================================================================================-->
</head>
<body>

    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100">
                <form class="login100-form validate-form" runat="server">
                    <span class="login100-form-title p-b-26">
                        <img src="image/Company_logo.png" alt="AVATAR">
                    </span>
                    <span class="login100-form-title p-b-26">Orion Principals</span>
                    <span class="login100-form-title p-b-48">
                        <i class="zmdi zmdi-font"></i>
                          <div id="ErrorMessage" style="text-align: center; font-size: large;color: firebrick" class="error" runat="server">
                    </div>
                    </span>
                   

                    <div class="wrap-input100 validate-input">
                        <input class="input100" type="text" name="username" runat="server" id="LoginName">
                        <span class="focus-input100" data-placeholder="E-mail ID"></span>
                    </div>

                    <div class="wrap-input100 validate-input" data-validate="Enter password">
                        <span class="btn-show-pass">
                            <i class="zmdi zmdi-eye"></i>
                        </span>
                        <input class="input100" type="password" name="pass" runat="server" id="txtpassword">
                        <span class="focus-input100" data-placeholder="Password"></span>
                    </div>

                    <div class="container-login100-form-btn">


                        <%--	<button class="btn btn-primary btn-lg" runat="server" onclick="btnLogin_Click"  >
								Login
							</button>--%>

                        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login"
                            class="btn btn-primary btn-lg" />



                    </div>
                   

                    <div class="text-center p-t-115">
                        <span class="txt1"></span>

                        <a class="txt2" href="PasswordReset.aspx">Forgot Password / Sign Up
                        </a>
                    </div>
                </form>
            </div>
        </div>
    </div>


    <div id="dropDownSelect1"></div>

    <!--===============================================================================================-->
    <script src="css/jquery-3.2.1.min.js"></script>
    <!--===============================================================================================-->
    <script src="css/animsition.min.js"></script>
    <!--===============================================================================================-->
    <script src="css/popper.js"></script>
    <script src="css/bootstrap.min.js"></script>
    <!--===============================================================================================-->
    <script src="css/select2.min.js"></script>
    <!--===============================================================================================-->
    <script src="css/moment.min.js"></script>
    <script src="css/daterangepicker.js"></script>
    <!--===============================================================================================-->
    <script src="css/countdowntime.js"></script>
    <!--===============================================================================================-->
    <script src="css/main.js"></script>

</body>
</html>
