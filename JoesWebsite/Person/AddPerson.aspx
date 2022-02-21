<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AddPerson.aspx.cs" Inherits="JoesWebsite.AddPerson" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row mt-3">
        <div class="col-md-12">
            <div class="row mt-2">
                <div class="col-md-3">
                    <label>First Name</label>
                    <input id="txtFirstName" class="form-control" />
                </div>
                <div class="col-md-3">
                    <label>Last Name</label>
                    <input id="txtLastName" class="form-control" />
                </div>
                <div class="col-md-2">
                    <label>Date of Birth</label>
                    <input id="txtDob" class="form-control" />
                </div>
            </div>
            <div class="row mt-2">
                <div class="col-md-2">
                    <label>Gender</label>
                    <input id="txtGender" class="form-control" />
                </div>
                <div class="col-md-3">
                    <label>Email</label>
                    <input id="txtEmail" class="form-control" />
                </div>
                <div class="col-md-3">
                    <label>Last Phone Number</label>
                    <input id="txtPhoneNumber" class="form-control" />
                </div>
            </div>
            <div class="row mt-2">
                <div class="col-md-8">
                    <button type="button" id="btnSavePerson" class="btn btn-primary float-right">Save</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
