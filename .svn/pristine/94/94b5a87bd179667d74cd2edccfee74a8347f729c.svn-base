using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Tic_Tac_Toe_2
{
    class Game
    {
        static GameBoard gb;
        static int iLevel;
        static void Main(string[] args)
        {
            get_BoardSize();
        }
        
        private static void get_BoardSize()
        {
            int iLength = 0;
            int iWidth = 0;
            int iTest = 0;
            string strTemp = string.Empty;
            Console.WriteLine("******************************************");
            Console.WriteLine("----------Welcome to Tic Tac Toe----------");
            Console.WriteLine("******************************************\n");
            do
            {
                Console.WriteLine("Select a level:");
                Console.WriteLine("1.Easy \n2.Medium \n3.Hard");
                Console.WriteLine("Select an option:");
                strTemp = Console.ReadLine().Trim();
                if (int.TryParse(strTemp, out iTest))
                {
                    iLevel = Convert.ToInt16(strTemp);
                    if (!(iLevel >= 1 && iLevel <= 3))
                        Console.WriteLine("Choose any option between 1 and 3");
                }
                else
                    Console.WriteLine("Please enter only numbers");
            } while (!(int.TryParse(strTemp, out iTest) && (iLevel >= 1 && iLevel <= 3)));
            do
            {
                Console.WriteLine("Please enter the board size ex: 1X1,2X2,3X3,..NXN");
                do
                {
                    Console.WriteLine("Please enter the length of the board:");
                    strTemp = Console.ReadLine().Trim();
                    if (int.TryParse(strTemp, out iTest))
                        iLength = Convert.ToInt32(strTemp);
                    else
                        Console.WriteLine("Please enter only numbers");
                } while (!int.TryParse(strTemp, out iTest));
                do
                {
                    Console.WriteLine("Please enter the width of the board:");
                    strTemp = Console.ReadLine().Trim();
                    if (int.TryParse(strTemp, out iTest))
                        iWidth = Convert.ToInt32(strTemp);
                    else
                        Console.WriteLine("Please enter only numbers");
                } while (!int.TryParse(strTemp, out iTest));
                if (iLength != iWidth)
                {
                    Console.WriteLine("Length and width must be same for the tic tac toe board!");
                }
            } while (iLength != iWidth);
            Console.WriteLine("Player's peg is O and Computer's peg is X");
            Console.WriteLine("+----------------------------------------+");
            gb = new TicTacToeBoard(iLength, iWidth);
            LoadBoard(iLength, iWidth);
            capture_Move(iLength, iWidth);
            Console.ReadLine();
        }
        
        private static void capture_Move(int iLength, int iWidth)
        {
            int x = 0, y = 0, iTest = 0;
            string strOpt = string.Empty, strTemp, strTemp1 = string.Empty;
            Space s = new Space();
            do
            {
                Console.WriteLine("\nEnter your move...");
                do
                {
                    Console.WriteLine("\nEnter a number between 1 and " + iLength);
                    strTemp = Console.ReadLine().Trim();
                    if (int.TryParse(strTemp, out iTest))
                    {
                        x = Convert.ToInt32(strTemp) - 1;
                        if (!(x >= 0 && x < iLength))
                        {
                            Console.WriteLine("Move must be between 1 and " + iLength + " !!!");
                        }
                    }
                    else
                        Console.WriteLine("Please enter only numbers!!!");
                } while (!(int.TryParse(strTemp, out iTest) && (x >= 0 && x < iLength)));
                do
                {
                    Console.WriteLine("\nEnter a number between 1 and " + iWidth);
                    strTemp = Console.ReadLine().Trim();
                    if (int.TryParse(strTemp, out iTest))
                    {
                        y = Convert.ToInt32(strTemp) - 1;
                        if (!(y >= 0 && y < iLength))
                            Console.WriteLine("Move must be between 1 and " + iLength + " !!!");
                    }
                    else
                        Console.WriteLine("Please enter only numbers!!!");
                } while (!(int.TryParse(strTemp, out iTest) && (y >= 0 && y < iLength)));
                s.X = x;
                s.Y = y;
                if (gb.space_IsTaken(x, y))
                {
                    Console.WriteLine("\n Position already taken. Please enter a different move");
                }
            } while (gb.space_IsTaken(x, y));
            gb[s.X, s.Y] = Player.O;
            //Displays the board
            LoadBoard(iLength, iWidth);
            switch (iLevel)
            {
                case 1: computer_easyMove(iLength, iWidth);
                    break;
                case 2: computer_mediumMove(iLength, iWidth);
                    break;
                case 3: calculate_ComputerMove(iLength, iWidth);
                    break;
            }
            do
            {
                Console.WriteLine("Do you wish to continue:(y/n)");
                strOpt = Console.ReadLine().ToLower();
                if (strOpt != "y" && strOpt != "n")
                {
                    Console.WriteLine("Enter only y or n !!");
                }
                else if (strOpt == "y")
                {
                    Console.Clear();
                    get_BoardSize();
                }
                else
                {
                    Console.WriteLine("Good Bye!!");
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                }
            } while (strOpt != "y" && strOpt != "n");
        }
       
        private static void computer_mediumMove(int iLength, int iWidth)
        {
            Space s = new Space();
            if (!CheckForWinners(iLength, iWidth))
            {
                Console.WriteLine("\nComputer makes the move..");
                Thread.Sleep(777);
                Console.Write("\n");
                if (gb.OpenSquares(iLength, iWidth).Count == gb.Size(iLength, iWidth)) //if all spaces are open, randomly pick one
                {
                    Random r = new Random();
                    s = new Space(r.Next(0, iLength), r.Next(0, iWidth));
                }
                else
                {
                    s = gb.get_BestMove(iLength, iWidth);
                }
                gb[s.X, s.Y] = Player.X;
                LoadBoard(iLength, iWidth);
                if (!CheckForWinners(iLength, iWidth))
                    capture_Move(iLength, iWidth);
            }
        }

        
        private static void computer_easyMove(int iLength, int iWidth)
        {
            Space s = new Space();
            if (!CheckForWinners(iLength, iWidth))
            {
                Console.WriteLine("\nComputer makes the move..");
                Thread.Sleep(777);
                Console.Write("\n");
                if (gb.OpenSquares(iLength, iWidth).Count == gb.Size(iLength, iWidth)) //if all spaces are open, randomly pick one for excitement
                {
                    Random r = new Random();
                    s = new Space(r.Next(0, iLength), r.Next(0, iWidth));
                }
                else
                {
                    Random r = new Random();
                    do
                    {
                        s = new Space(r.Next(0, iLength), r.Next(0, iWidth));
                    } while (gb.space_IsTaken(s.X, s.Y));
                }
                gb[s.X, s.Y] = Player.X;
                LoadBoard(iLength, iWidth);
                if (!CheckForWinners(iLength, iWidth))
                    capture_Move(iLength, iWidth);
            }
        }
       
        private static void calculate_ComputerMove(int iLength, int iWidth)
        {
            Space s = new Space();
            if (!CheckForWinners(iLength, iWidth))
            {
                Console.WriteLine("\nComputer makes the move..");
                Thread.Sleep(777);
                Console.Write("\n");
                if (gb.OpenSquares(iLength, iWidth).Count == gb.Size(iLength, iWidth)) //if all spaces are open, computer randomly picks one
                {
                    Random r = new Random();
                    s = new Space(r.Next(0, iLength), r.Next(0, iWidth));
                }
                else
                {
                    s = AI.GetBestMove(gb, Player.X, iLength, iWidth);
                }
                gb[s.X, s.Y] = Player.X;
                LoadBoard(iLength, iWidth);
                if (!CheckForWinners(iLength, iWidth))
                    capture_Move(iLength, iWidth);
            }
        }
       
        public static bool CheckForWinners(int iLength, int iWidth)
        {
            Player? p = gb.Winner(iLength, iWidth);

            if (p == Player.X)
            {
                Console.WriteLine("\nComputer Wins");
                return true;
            }
            else if (p == Player.O)
            {
                Console.WriteLine("\nYou Win!");
                return true;
            }
            else if (gb.IsFull)
            {
                Console.WriteLine("\n It's a Tie");
                return true;
            }
            return false;
        }
       
        private static void LoadBoard(int iLength, int iWidth)
        {
            int counter = 0;
            for (int i = 0; i < iLength; i++)
            {
                if (counter == 0)
                {
                    Console.Write(" ");
                    for (int k = 1; k <= iLength; k++)
                        Console.Write(" " + k);
                    counter++;
                }
                Console.Write("\n" + (i + 1));
                for (int j = 0; j < iWidth; j++)
                {
                    if (gb[i, j].ToString() == "Open")
                    {
                        Console.Write("|");
                        Console.Write("_");
                    }
                    else
                    {
                        Console.Write("|" + gb[i, j].ToString());
                    }
                    if (j == iWidth - 1)
                    {
                        Console.WriteLine("|");
                    }
                }
            }
        }
    }
}
