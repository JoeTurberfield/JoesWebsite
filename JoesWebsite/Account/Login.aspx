<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="JoesWebsite.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>

    <!-- Jquery -->
    <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.4.1.min.js"></script>

    <!-- Bootstrap -->
    <link rel="stylesheet" href="Bootstrap/css/bootstrap.min.css" />
    <script src="Bootstrap/js/bootstrap.min.js"></script>

    <!-- Sweet Alert 2 -->
    <script src="sweetalert2/sweetalert2.all.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row mt-4 justify-content-center">
                <div class="col-md-4">
                    <h2>Login</h2>
                    <br />
                    <h4>Welcome to Joe's Website</h4>
                    <div class="form-group">
                        <label>Username</label>
                        <input id="txtUsername" class="form-control" runat="server"/>
                        <label>Password</label>
                        <input id="txtPassword" type="password" class="form-control" />
                        <button id="btnLogin" type="button" class="btn btn-primary mt-2">Login</button>

                        <br />
                        <div>
                            Forgotten your
                            <a href="RecoverAccount.aspx?u=true">Username</a>
                            Or
                            <a href="RecoverAccount.aspx?p=true">Password?</a>
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <script type="text/javascript">

            $(function () {

                var $elem = {
                    txtUsername: $('[id$"txtUsername"]'),
                    txtPassword: $('#txtPassword'),
                    btnLogin: $('#btnLogin')
                }

                $elem.btnLogin.on('click', function () {

                    var userDetails = {
                        username: $elem.txtUsername.val(),
                        password: $elem.txtPassword.val()
                    }
                    LoginUser(userDetails);
                });

                function LoginUser(userDetails) {
                    $.ajax({
                        type: 'POST',
                        url: 'Login.aspx/LoginUser',
                        data: "{ UserDetails: " + JSON.stringify(userDetails) + " }",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (result) {
                            if (result.d != null) {
                                if (result.d.ResponseID === 0) {
                                    Swal.fire(
                                        'Success!',
                                        result.d.ResponseMessage,
                                        'success'
                                    ).then((result) => {
                                        window.location.href = "/Index.aspx";
                                    });
                                }
                                else if (result.d.ResponseID === -1) {
                                    Swal.fire(
                                        'Error!',
                                        result.d.ResponseMessage,
                                        'error'
                                    );
                                }
                            }
                            else {
                                Swal.fire(
                                    'Error!',
                                    'An unexpected error has occured. Please try again.',
                                    'error'
                                );
                            }

                        }
                    });
                }

            });


        </script>
    </form>
</body>
</html>
