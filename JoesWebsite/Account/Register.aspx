<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="JoesWebsite.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row mt-4">
        <div class="col-md-4">
            <div class="form-group">

                <label for="txtSetUsername">Username</label>
                <input id="txtSetUsername" class="form-control" />

                <label for="txtSetPassword">Password</label>
                <input id="txtSetPassword" type="password" class="form-control" />

                <label for="txtConfirmSetPassword">Confirm Password</label>
                <input id="txtConfirmSetPassword" type="password" class="form-control" />
                <label id="lblRegisterUserError" class="lbl-error d-none"></label>
                <br />

                <button id="btnRegister" type="button" class="btn btn-primary mt-2">Register</button>
            </div>
        </div>
    </div>


    <script type="text/javascript">
        $(function () {

            var $elem = {
                txtSetUsername: $('#txtSetUsername'),
                txtSetPassword: $('#txtSetPassword'),
                txtConfirmSetPassword: $('#txtConfirmSetPassword'),
                btnRegister: $('#btnRegister'),
                lblRegisterUserError: $('#lblRegisterUserError')
            }
            
            $elem.btnRegister.on('click', function () {

                var userDetails = {
                    username: $elem.txtSetUsername.val(),
                    password: $elem.txtSetPassword.val(),
                    confirmpassword: $elem.txtConfirmSetPassword.val()
                }
                CreateNewUser(userDetails);
            });

            function CreateNewUser(userDetails) {
                $.ajax({
                    type: 'POST',
                    url: 'Register.aspx/CreateNewUser',
                    data: "{ UserDetails: " + JSON.stringify(userDetails) + " }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (result) {
                        console.log('ajax success: ', result);

                        if (result.d != null) {
                            if (result.d.ResponseID === 0) {
                                Swal.fire(
                                    'Success!',
                                    result.d.ResponseMessage,
                                    'success'
                                ).then((result) => {
                                    window.location.href = window.location.href;
                                });
                            }
                            else if (result.d.ResponseID === -1) {
                                //$elem.lblRegisterUserError.text(result.d.ResponseMessage).removeClass('d-none');
                                Swal.fire(
                                    'Please review errors and try again',
                                    result.d.ResponseMessage,
                                    'error'
                                );
                            }
                        }
                        else {
                            //$elem.lblRegisterUserError.text('An unexpected error has occured. Please contact support.').removeClass('d-none');
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

        


        //function j() {
        //    //is-invalid = error

        //    // Check Username does not exist// Check Username is valid
        //    var username = $elem.txtSetUsername.val();
        //    $.ajax({
        //        type: 'POST',
        //        url: 'Register.aspx/CheckUsernameValid',
        //        data: "{ username: " + JSON.stringify(username) + " }",
        //        contentType: "application/json; charset=utf-8",
        //        dataType: "json",
        //        success: function (result) {
        //            console.log('ajax success: ', result);

        //            if (result.d != null) {
        //                if (result.d.Error === 0) {
        //                    $elem.lblUsernameError.text(result.d.ErrorMessage).addClass('d-none');
        //                }
        //                else if (result.d.Error === -1) {
        //                    $elem.lblUsernameError.text(result.d.ErrorMessage).removeClass('d-none');
        //                }
        //            }
        //            else {
        //                $elem.lblUsernameError.text('An unexpeted error has occurred. Please Try Again.').addClass('d-none');
        //            }
        //        }
        //    });

        //    var password = $elem.txtSetPassword.val();
        //    var confirmpassword = $elem.txtConfirmSetPassword.val();
        //    $.ajax({
        //        type: 'POST',
        //        url: 'Register.aspx/CheckPasswordValid',
        //        data: "{ password: " + JSON.stringify(password) + ", confirmPassword: " + JSON.stringify(confirmpassword) + " }",
        //        contentType: "application/json; charset=utf-8",
        //        dataType: "json",
        //        success: function (result) {
        //            console.log('ajax success: ', result);

        //            if (result.d != null) {
        //                if (result.d.Error === 0) {
        //                    $elem.lblPasswordError.text(result.d.ErrorMessage).addClass('d-none');
        //                }
        //                else if (result.d.Error === -1) {
        //                    $elem.lblPasswordError.text(result.d.ErrorMessage).removeClass('d-none');
        //                }
        //            }
        //            else {
        //                $elem.lblPasswordError.text('An unexpeted error has occurred. Please Try Again.').addClass('d-none');
        //            }
        //        }
        //    });
        //}


    </script>


</asp:Content>
