using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace JoesWebsite
{
    public partial class NoughtsAndCrosses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static GameResponse NoughtsAndCrossesAI(List<BoardData> board, int difficulty)
        {

            //joesWS.JoesWebService ws = new joesWS.JoesWebService();
            //var getwr = ws.GetResponseWS();

            // Magic Square Method
            //foreach (var item in board)
            //{
            //    pos.Add(item.Position);

            //    if (item.Value == "X")
            //    {
            //        x += item.Position;
            //        if (x == 15)
            //        {
            //            response.ID = 1;
            //        }
            //    }
            //    if (item.Value == "O")
            //    {
            //        o += item.Position;
            //        if (o == 15)
            //        {
            //            response.ID = 2;
            //        }
            //    }
            //}

            JavaScriptSerializer js = new JavaScriptSerializer();

            GameResponse res = new GameResponse
            {
                ID = 0,
                Message = "Game in Progress...",
                Position = 0,
                Value = "O"
            };

            if (isWinner(board))
            {
                res.ID = 1;
                res.Message = "You Won";
                res.Position = null;

                //if (difficulty == 1)
                //{
                //    res.Message = "Well Done. You won on easy..";
                //}
                //else if (difficulty == 2)
                //{
                //    res.Message = "Impressive.";
                //}
                
                res.PlayerScore++;
            }
            else
            {
                // Set next AI position
                List<int> poslist = new List<int>();

                foreach (BoardData item in board)
                {
                    if (item.Value != "")
                    {
                        poslist.Add(item.Position);
                    }
                }

                if (poslist.Count < 8)
                {
                    if (difficulty == 1)
                    {
                        res.Position = SetRandomPosition(board, poslist);
                    }

                    if (difficulty == 2)
                    {
                        res.Position = SetWinningPosition(board);
                        if (res.Position == -1)
                        {
                            res.Position = SetRandomPosition(board, poslist);
                        }
                    }

                    if (!res.Position.Equals(null))
                    {
                        int pos = res.Position.GetValueOrDefault();
                        board[pos].Value = "O";
                    }

                    if (isWinner(board))
                    {
                        res.ID = 2;
                        res.AIScore++;
                        res.Message = "You lost";

                        //if (difficulty == 1)
                        //{
                        //    res.Message = "You lost";
                        //}
                        //else if (difficulty == 2)
                        //{
                        //    res.Message = "At least you tried..";
                        //}

                    }
                }
                else
                {
                    res.ID = 3;
                    res.Message = "Draw";
                    res.Position = null;
                }                
            }

            js.Serialize(res);

            Thread.Sleep(1000);

            return res;
        }

        public static bool isWinner(List<BoardData> board)
        {
            // Row check
            if (board[0].Value == board[1].Value
                && board[1].Value == board[2].Value
                && board[0].Value != "")
            {
                return true;
            }
            else if (board[3].Value == board[4].Value
                && board[4].Value == board[5].Value
                && board[3].Value != "")
            {
                return true;
            }
            else if (board[6].Value == board[7].Value
                && board[7].Value == board[8].Value
                && board[6].Value != "")
            {
                return true;
            }

            // Column check
            else if (board[0].Value == board[3].Value
                && board[3].Value == board[6].Value
                && board[0].Value != "")
            {
                return true;
            }
            else if (board[1].Value == board[4].Value
                && board[4].Value == board[7].Value
                && board[1].Value != "")
            {
                return true;
            }
            else if (board[2].Value == board[5].Value
                && board[5].Value == board[8].Value
                && board[2].Value != "")
            {
                return true;
            }

            // Diagonal check
            else if (board[0].Value == board[4].Value
                && board[4].Value == board[8].Value
                && board[0].Value != "")
            {
                return true;
            }
            else if (board[2].Value == board[4].Value
                && board[4].Value == board[6].Value
                && board[2].Value != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int SetRandomPosition(List<BoardData> board, List<int> poslist)
        {
            //GameResponse res = new GameResponse();

            int pos;
            if (poslist.Count < 8)
            {
                Random random = new Random();
                pos = 0;

                while (poslist.Contains(pos))
                {
                    pos = random.Next(0, 8);
                }
            }
            else
            {
                pos = -1;
            }

            return pos;
        }

        public static int SetWinningPosition(List<BoardData> board)
        {
            int newPos = -1;

            // Is there a winning move?
            for (int i = 0; i < board.Count; i++)
            {
                // Row check - Column 1 & 2 then fill Column 0
                if (i < 8)
                {
                     if (board[i].Value == "X" && board[i + 1].Value == "X")
                    {
                        switch (i)
                        {
                            case 0:
                                newPos = 2;
                                break;
                            case 1:
                                newPos = 0;
                                break;
                            case 3:
                                newPos = 5;
                                break;
                            case 4:
                                newPos = 3;
                                break;
                            case 6:
                                newPos = 8;
                                break;
                            case 7:
                                newPos = 6;
                                break;
                            default:
                                newPos = 0;
                                break;
                        }
                        if (newPos != -1)
                        {
                            if (board[newPos].Value == "")
                            {
                                return newPos;
                            }
                            else
                            {
                                newPos = -1;
                            }
                        }
                    }            
                }
                if (i < 7)
                {
                    // Row check - Column 1 & 3 then fill Column 2
                    if (board[i].Value == "X" && board[i + 2].Value == "X")
                    {
                        switch (i)
                        {
                            case 0:
                                newPos = 1;
                                break;
                            case 3:
                                newPos = 4;
                                break;
                            case 6:
                                newPos = 7;
                                break;
                            default:
                                newPos = 0;
                                break;
                        }
                        if (newPos != -1)
                        {
                            if (board[newPos].Value == "")
                            {
                                return newPos;
                            }
                            else
                            {
                                newPos = -1;
                            }
                        }
                    }                 
                }
                // Column check - Row 1 & 2 then fill Row 3
                if (i < 6 && board[i].Value == "X" && board[i + 3].Value == "X")
                {
                    switch (i)
                    {
                        case 0:
                            newPos = 6;
                            break;
                        case 1:
                            newPos = 7;
                            break;
                        case 2:
                            newPos = 8;
                            break;
                        case 3:
                            newPos = 6;
                            break;
                        case 4:
                            newPos = 1;
                            break;
                        case 5:
                            newPos = 2;
                            break;
                        default:
                            newPos = 0;
                            break;
                    }
                    if (newPos != -1)
                    {
                        if (board[newPos].Value == "")
                        {
                            return newPos;
                        }
                        else
                        {
                            newPos = -1;
                        }
                    }
                }
                // Column check - Row 1 & 3 then fill Row 2
                if (i < 3 && board[i].Value == "X" && board[i + 6].Value == "X")
                {
                    switch (i)
                    {
                        case 0:
                            newPos = 3;
                            break;
                        case 1:
                            newPos = 4;
                            break;
                        case 2:
                            newPos = 5;
                            break;
                        default:
                            newPos = 0;
                            break;
                    }
                    if (newPos != -1)
                    {
                        if (board[newPos].Value == "")
                        {
                            return newPos;
                        }
                        else
                        {
                            newPos = -1;
                        }
                    }
                }

                if (i == 0 && board[i].Value == "X" && board[i + 8].Value == "X" && board[4].Value == "")
                {
                    return 4;
                }
                // Diagonal check - Row 1 & 2 then fill Row 3
                if (i < 4 && board[i].Value == "X" && board[i + 4].Value == "X")
                {
                    switch (i)
                    {
                        case 0:
                            newPos = 8;
                            break;
                        case 2:
                            newPos = 4;
                            break;
                        case 4:
                            if (board[0].Value == "")
                            {
                                newPos = 0;
                            }
                            break;

                        default:
                            newPos = 0;
                            break;
                    }
                    if (newPos != -1)
                    {
                        if (board[newPos].Value == "")
                        {
                            return newPos;
                        }
                        else
                        {
                            newPos = -1;
                        }
                    }                  
                }

                if (i < 6 && board[i].Value == "X" && board[i + 2].Value == "X")
                {
                    switch (i)
                    {
                        case 2:
                            newPos = 6;
                            break;
                        case 4:
                            if (board[2].Value == "")
                            {
                                newPos = 2;
                            }
                            break;
                        default:
                            newPos = 0;
                            break;
                    }
                    if (newPos != -1)
                    {
                        if (board[newPos].Value == "")
                        {
                            return newPos;
                        }
                        else
                        {
                            newPos = -1;
                        }
                    }
                }

                if (i > 4 && board[i].Value == "X" && board[i - 4].Value == "X")
                {
                    switch (i)
                    {
                        case 8:
                            newPos = 0;
                            break;
                        case 4:
                            if (board[8].Value == "")
                            {
                                newPos = 8;
                            }
                            break;
                        default:
                            newPos = 0;
                            break;
                    }
                    if (newPos != -1)
                    {
                        if (board[newPos].Value == "")
                        {
                            return newPos;
                        }
                        else
                        {
                            newPos = -1;
                        }
                    }
                }

                if (i > 2 && board[i].Value == "X" && board[i - 2].Value == "X")
                {
                    switch (i)
                    {
                        case 6:
                            newPos = 2;
                            break;
                        case 4:
                            if (board[6].Value == "")
                            {
                                newPos = 6;
                            }
                            break;
                        default:
                            newPos = 0;
                            break;
                    }
                    if (newPos != -1)
                    {
                        if (board[newPos].Value == "")
                        {
                            return newPos;
                        }
                        else
                        {
                            newPos = -1;
                        }
                    }
                }
            }

            if (newPos == -1)
            {
                // set to corner position
                int[] newPosArr = new int[] { 0, 2, 6, 8 };

                foreach (int i in newPosArr)
                {
                    newPos = i;

                    //newPos = random.Next(newPosArr.);
                    if (board[newPos].Value == "")
                    {
                        break;
                    }
                    else
                    {
                        newPos = -1;
                    }
                }
            }
            return newPos;
        }
    }


    public class GameResponse : AI
    {
        public int ID { get; set; }
        public string Message { get; set; }
        public int AIScore { get; set; }
        public int PlayerScore { get; set; }
    }
    public class AI
    {
        public int? Position { get; set; }
        public string Value { get; set; }
    }

    public class Board
    {
        public List<BoardData> Turns { get; set; }
    }
    public class BoardData
    {
        public int Position { get; set; }
        public string Value { get; set; }

    }

}