<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="NoughtsAndCrosses.aspx.cs" Inherits="JoesWebsite.NoughtsAndCrosses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .game-area {
            border: solid thin black;
        }

        .input-selection {
            height: 200px;
            width: 200px;
            border: solid thin grey;
            margin: 10px;
            text-align: center;
            font-family: 'Bowlby One SC', cursive;
            font-size: 150px;
            
        }

        .disablegame{
            pointer-events:none;
            background-color: gainsboro;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mt-2">
        <h2>Noughts and Crosses</h2>
    </div>
    
    <div class="row mt-4 ml-1">
        <div class="game-area col-md-8">
            <div class="row">
                <div class="col-md-4">
                    <div class="input-selection" data-pos="0">
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="input-selection" data-pos="1">
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="input-selection" data-pos="2">
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <div class="input-selection" data-pos="3">
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="input-selection" data-pos="4">
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="input-selection" data-pos="5">
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <div class="input-selection" data-pos="6">
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="input-selection" data-pos="7">
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="input-selection" data-pos="8">
                    </div>
                </div>
            </div>     
        </div>
       
        <div class="col-md-4">
            <div class="row">
                <div class="col-md-3">
                    <label id="lblPlayerScore">0</label>
                </div>
                <div class="col-md-3">
                    <label id="lblAIScore">0</label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <button id="btnRestart" class="btn btn-primary">Restart</button>
                </div>
                <div class="col-md-6">
                    <select id="ddlDifficulty">
                        <option value="1">Easy</option>
                        <option value="2">Hard</option>
                    </select>
                </div>
            </div>           
        </div>
    </div>

    <script type="text/javascript">


        $(function () {

            var $elem = {
                $inputSelection: $('.input-selection'),
                $gamearea: $('.game-area'),
                $btnRestart: $('#btnRestart'),
                $ddlDifficulty: $('#ddlDifficulty')
            }

            $elem.$inputSelection.on('click', function (e) {

                if ($(this).text() != "X" && $(this).text() != "O") {

                    $(this).text('X');

                    $elem.$gamearea.addClass('disablegame');

                    var length = $elem.$inputSelection.length;
                    var gdArr = [];

                    // Get all game data
                    for (var i = 0; i < length; i++) {

                        var $input = $($elem.$inputSelection[i]);
                        var text = '';

                        if ($input.text() == "X" || $input.text() == "O") {
                            text = $input.text();
                        }

                        var obj = {
                            Position: $input.data('pos'),
                            Value: text
                        };

                        gdArr.push(obj);
                    }

                    console.log("{data:" + JSON.stringify(gdArr) + "}");

                    $.ajax({
                        type: 'POST',
                        url: 'NoughtsAndCrosses.aspx/NoughtsAndCrossesAI',
                        data: "{board:" + JSON.stringify(gdArr) + ", difficulty:" + $elem.$ddlDifficulty.val() + "}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (result) {
                            console.log('ajax success: ', result);

                            var posAI = result.d.Position;
                            var valAI = result.d.Value;
                            $("[data-pos=" + posAI + "]").text(valAI);

                            if (result.d.ID > 0) {
                                alert(result.d.Message);

                                if (result.d.ID == 1) {
                                    $('#lblPlayerScore').val(result.d.PlayerScore);
                                }
                                else if (result.d.ID == 2) {
                                    $('#lblAIScore').val(result.d.AIScore);
                                }
                            }
                            else {
                                $elem.$gamearea.removeClass('disablegame');
                            }                           
                        }
                    });
                }
            });

            $elem.$btnRestart.on('click', function (e) {
                e.preventDefault();
                $('.input-selection').text('');
                $elem.$gamearea.removeClass('disablegame');    
            });


        });

    </script>

</asp:Content>
