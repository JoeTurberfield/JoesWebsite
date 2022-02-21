<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecoverAccount.aspx.cs" Inherits="JoesWebsite.RecoverAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Recover Account</title>
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
                    <h2>Recover Account</h2>
                    <br />
                    <div id="dvRecoverUsername" runat="server" class="form-group" visible="false">
                        <label>First Name</label>
                        <asp:TextBox ID="txtFirstName" class="form-control" runat="server"></asp:TextBox>
                        <label>Last Name</label>
                        <asp:TextBox ID="txtLastName" class="form-control" runat="server"></asp:TextBox>
                        <label>Email</label>
                        <asp:TextBox ID="txtEmail" class="form-control" runat="server"></asp:TextBox>
                        <br />
                        <asp:Button ID="btnGetUsername" runat="server" Text="Recover Username" class="btn btn-primary" OnClick="btnGetUsername_Click" />
                    </div>

                    <div id="dvRecoverPassword" runat="server" class="form-group" visible="false">
                        <label>Existing Account Username</label>
                        <input id="txtUsername" class="form-control" />
                        <label>Set New Password</label>
                        <input id="txtNewPassword" type="password" class="form-control" />
                        <label>Confirm New Password</label>
                        <input id="txtConfirmPassword" type="password" class="form-control" />
                        <button id="btnLogin" type="button" class="btn btn-primary mt-2">Set New Password</button>
                    </div>
                    <asp:Label ID="lblError" runat="server" Text="" CssClass="text-danger" Visible="false"></asp:Label>
                    
                    <div id="dvUsernameSuccess" runat="server" visible="false">
                        User found for
                        <asp:Label ID="lblRetreivedUsername" runat="server" Text=""></asp:Label>
                        . Go back to
                        <asp:HyperLink ID="hypLnkLogin" runat="server">Login</asp:HyperLink>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
