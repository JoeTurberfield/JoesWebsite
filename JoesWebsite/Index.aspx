<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="JoesWebsite.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .status-username{
            font-weight: bold;
        }
        .status-remove{
            cursor:pointer;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row mt-4">
        <div class="col-md-8">
            <div class="form-row">
                <div class="col-md-10">
                    <input id="txtAddStatus" class="form-control" placeholder="Enter a status" />
                </div>
                <div class="col-md-2">
                    <button type="button" id="btnSaveStatus" class="btn btn-primary">Post</button>
                </div>
            </div>
        </div>
    </div>
    <div id="dvStatusPost" runat="server">
        <div class="row mt-4 d-none">
            <div class="col-md-8">
                <label class="status-username">Joe Turberfield</label>
                <br />
                <label class="status-message">This is a template post</label>
                <br />
                <label>Posted on: </label><label class="pl-2 status-date">28/10/1993</label>
                <label class="status-remove">Remove</label>
            </div>
        </div>
        <hr />
    </div>



    <%--<div class="row mt-2">
            <div class="col-lg-4">
                This is a col-lg-4
            </div>
            <div class="col-lg-4">
                This is a col-lg-4
            </div>
            <div class="col-lg-4">
                This is a col-lg-4

                <!-- ImageHandler.ashx?width=10&height=10 -->
                <img src="ImageHandler.ashx?"/>
            </div>
        </div>--%>


    <script type="text/javascript">

        (function () {

            var $elem = {
                txtStatus: $('#txtAddStatus'),
                btnStatusSave: $('#btnSaveStatus'),
                removeStatus: $('.status-remove')
            }

            $elem.btnStatusSave.on('click', function () {

                $.ajax({
                    type: 'POST',
                    url: 'Index.aspx/SaveStatus',
                    data: "{status:" + JSON.stringify($elem.txtStatus.val()) + "}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (result) {
                        alert(result.d.ResponseMessage);
                        $('#txtAddStatus').val('');
                        location.reload();
                    }
                });
            });

            $elem.removeStatus.on('click', function (e) {

                console.log(e.target.closest('.status-container'));

                var statusId = $(e.target.closest('.status-container')).data('statusid');
                console.log(statusId);


                $.ajax({
                    type: 'POST',
                    url: 'Index.aspx/DeleteStatus',
                    data: "{statusID:" + JSON.stringify(statusId) + "}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (result) {
                        alert(result.d.ResponseMessage);
                        $('#txtAddStatus').val('');
                        location.reload();
                    }
                });
            });


        })();








    </script>



</asp:Content>
