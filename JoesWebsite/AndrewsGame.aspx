<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AndrewsGame.aspx.cs" Inherits="JoesWebsite.AndrewsGame" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        input.number-box {
            width: 50px;
            padding:5px;
        }

        .block {
            display: block;
            padding:5px;
        }

        .wrapper{
            text-align:center;
        }

        .col-game{
            margin-left: 20%;
            margin-top: 10%;
        }
        .container .row1 .block:first-child {
            margin-left: 20%;
        }

        .container .row2 .block:first-child {
            margin-left: 15%;
        }

        .container .row3 .block:first-child {
            margin-left: 10%;
        }

        .container .row4 .block:first-child {
            margin-left: 5%;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-lg-2">
                <asp:Button ID="btnHello" runat="server" Text="Say Hello" OnClick="btnHello_Click" />
                <label id="lblHello" runat="server"></label>
            </div>
        </div>
        <div class="row wrapper">
            <div class="col-lg-6 col-game">
                <div class="row row1">
                    <div class="block">
                        <input id="txtFirstNo" runat="server" class="form-control number-box" />
                        <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" />
                    </div>
                </div>
                <div class="row row2">
                    <div class="block">
                        <input id="txtFirstNoRow2" runat="server" class="form-control number-box" />
                    </div>
                    <div class="block">
                        <input id="txtSecondNoRow2" runat="server" class="form-control number-box" />
                    </div>
                </div>
                <div class="row row3">
                    <div class="block">
                        <input class="form-control number-box" />
                    </div>
                    <div class="block">
                        <input class="form-control number-box" />
                    </div>
                    <div class="block">
                        <input class="form-control number-box" />
                    </div>
                </div>
                <div class="row row4">
                    <div class="block">
                        <input class="form-control number-box" />
                    </div>
                    <div class="block">
                        <input class="form-control number-box" />
                    </div>
                    <div class="block">
                        <input class="form-control number-box" />
                    </div>
                    <div class="block">
                        <input class="form-control number-box" />
                    </div>
                </div>
                <div class="row">
                    <label id="lblNumbers" runat="server"></label>
                </div>
            </div>
        </div>



    </div>



</asp:Content>
