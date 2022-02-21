<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="TheMaze.aspx.cs" Inherits="JoesWebsite.TheMaze" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <style>

        #mz-border{
            height: 750px;
            border: solid black;
        }

        #mz-player{
            height: 50px;
            width: 50px;
            background-color: deepskyblue;
            border: solid black;
            position: relative;
            left: 50px;
            top: 50px;
        }

        #mz-enemy1{
            height: 50px;
            width: 50px;
            background-color: red;
            border: solid black;
            position: relative;
            left: 150px;
            top: 150px;
        }

    </style>


</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <input type="text" onkeydown="keyPress(event)">

    <div class="row mt-3">
        <div class="col-md-12">
            <h3>Welcome to The Maze</h3>
        </div>
    </div>

    <div id="mz-border" class="death-zone" tabindex="0">

        <div id="mz-player">

        </div>

        <div id="mz-enemy1">

        </div>


    </div>

    <canvas width="200" height="200" style="position: absolute; left: 0px; top: 0px;"></canvas>

    <script type="text/javascript">


        setInterval(movePlane, 20);
        var keys = {}

        $(document).keydown(function (e) {
            keys[e.keyCode] = true;
        });

        $(document).keyup(function (e) {
            delete keys[e.keyCode];
        });

        //var rect = $('#mz-enemy1').getBoundingClientRect();
        //console.log(rect.top, rect.right, rect.bottom, rect.left);

        

        //var enemy1pos = {
        //    x: $('#mz-enemy1').
        //}
        //console.log();



        function movePlane() {

            //var x = $('#mz-enemy1').position();
            //alert("Top position: " + x.top + " Left position: " + x.left);

            var playerPos = { x: 5, y: 5, width: 50, height: 50 }
            var enemy1Pos = { x: 50, y: 50, width: 10, height: 10 }

            if (playerPos.x < enemy1Pos.x + enemy1Pos.width &&
                playerPos.x + playerPos.width > enemy1Pos.x &&
                playerPos.y < enemy1Pos.y + enemy1Pos.height &&
                playerPos.y + playerPos.height > enemy1Pos.y) {
                // collision detected!
            }

            else {
                for (var direction in keys) {
                    if (!keys.hasOwnProperty(direction)) continue;
                    if (direction == 37 || direction == 65) {
                        $('#mz-player').animate({ left: "-=5" }, 0);
                    }
                    if (direction == 38 || direction == 87) {
                        $('#mz-player').animate({ top: "-=5" }, 0);
                    }
                    if (direction == 39 || direction == 68) {
                        $('#mz-player').animate({ left: "+=5" }, 0);
                    }
                    if (direction == 40 || direction == 83) {
                        $('#mz-player').animate({ top: "+=5" }, 0);
                    }
                }
            }    
        }


       

    </script>

</asp:Content>
