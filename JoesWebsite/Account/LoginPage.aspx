<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="JoesWebsite.Loginv1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mt-2">
        <div class="col-md-4">
            <div class="form-group">
                <label>Username</label>
                <input id="txtUsername" class="form-control" />
                <label>Password</label>
                <input id="txtPassword" type="password" class="form-control" />
                <button id="btnLogin" class="btn btn-primary mt-2">Login</button>
            </div>
        </div>
    </div>

    <script type="text/javascript">

        $(function () {

            var $elem = {
                txtUsername: $('#txtUsername'),
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
                    url: 'Login.aspx/Login',
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
                                result.d.ResponseMessage,
                                'error'
                            );
                        }

                    }
                });
            }

        });


    </script>

</asp:Content>
