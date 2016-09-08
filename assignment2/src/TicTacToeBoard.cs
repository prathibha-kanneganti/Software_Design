using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tic_Tac_Toe_2
{
    
    class TicTacToeBoard : GameBoard
    {
        
        public TicTacToeBoard(int iLength, int iWidth)
        {
            squares = new Player[iLength, iWidth];
            for (int i = 0; i < iLength; i++)
            {
                for (int j = 0; j < iWidth; j++)
                {
                    squares[i, j] = 0;
                }
            }
        }
        
        public override int Size(int iLength, int iWidth) { return iLength * iWidth; }
        /// <summary>
        /// Instantiates Player
        /// </summary>
        public override Player this[int x, int y]
        {
            get
            {
                return squares[x, y];
            }

            set
            {
                squares[x, y] = value;
            }
        }
        /// <summary>
        /// Checks if the board is full
        /// </summary>
        public override bool IsFull
        {
            get
            {
                foreach (Player i in squares)
                    if (i == Player.Open) { return false; }
                return true;
            }
        }
        
        public override List<Space> OpenSquares(int iLength, int iWidth)
        {
            List<Space> openSquares = new List<Space>();
            for (int x = 0; x < iLength; x++)
                for (int y = 0; y < iWidth; y++)
                    if (squares[x, y] == Player.Open)
                        openSquares.Add(new Space(x, y));
            return openSquares;
        }
        
        public override bool space_IsTaken(int xPos, int yPos)
        {
            if (squares[xPos, yPos] == Player.Open)
                return false;
            else
                return true;
        }
        
        public override Space get_BestMove(int iLength, int iWidth)
        {
            int count = 0, cnt_player = 0;
            Space s = new Space();
            Random rand = new Random();
            #region Checks if it can win in the next move
            //Checks row-wise if it can win in next move
            for (int x = 0; x < iLength; x++)
            {
                count = 0;
                for (int y = 0; y < iWidth; y++)
                {
                    count += (int)squares[x, y];
                    if ((int)squares[x, y] == 0)
                    {
                        s = new Space(x, y);
                    }
                }
                if (count == iWidth - 1 || count == -iWidth + 1)
                {
                    return s;
                }
            }
            //Checks column-wise if it can win in next move
            for (int x = 0; x < iWidth; x++)
            {
                count = 0;
                for (int y = 0; y < iLength; y++)
                {
                    count += (int)squares[y, x];
                    if ((int)squares[y, x] == 0)
                    {
                        s = new Space(y, x);
                    }
                }
                if (count == iWidth - 1 || count == -iWidth + 1)
                {
                    return s;
                }
            }

            //Checks diagonal-wise from left to right if it can win in next move
            count = 0;
            for (int i = 0; i < iLength; i++)
            {
                for (int j = 0; j < iWidth; j++)
                {
                    if (i == j)
                    {
                        count += (int)squares[i, j];
                        if ((int)squares[i, j] == 0)
                        {
                            s = new Space(i, j);
                        }
                    }
                }
            }
            if (count == iWidth - 1 || count == -iWidth + 1)
            {
                return s;
            }
            //Checks diagonal-wise from right to left if it can win in next move
            count = 0;
            for (int i = 0; i < iLength; i++)
            {
                for (int j = 0; j < iWidth; j++)
                {
                    if (i + j + 1 == iWidth)
                    {
                        count += (int)squares[i, j];
                        if ((int)squares[i, j] == 0)
                        {
                            s = new Space(i, j);
                        }
                    }
                }
            }
            if (count == iWidth - 1 || count == -iWidth + 1)
            {
                return s;
            }
            #endregion
            #region Next move, tries to win in the coming up moves
            //rows
            for (int x = 0; x < iLength; x++)
            {
                count = 0;
                cnt_player = 0;
                for (int y = 0; y < iWidth; y++)
                {
                    count += (int)squares[x, y];
                    if ((int)squares[x, y] == -1)
                        cnt_player++;
                    if ((int)squares[x, y] == 0)
                    {
                        s = new Space(x, y);
                    }
                }
                if (count < iWidth && cnt_player == 0)
                {
                    return s;
                }
            }

            //columns
            for (int x = 0; x < iWidth; x++)
            {
                count = 0;
                cnt_player = 0;
                for (int y = 0; y < iLength; y++)
                {
                    count += (int)squares[y, x];
                    if ((int)squares[y, x] == -1)
                        cnt_player++;
                    if ((int)squares[y, x] == 0)
                    {
                        s = new Space(y, x);
                    }
                }
                if (count < iWidth && cnt_player == 0)
                {
                    return s;
                }
            }

            //diagnols left to right
            count = 0;
            cnt_player = 0;
            for (int i = 0; i < iLength; i++)
            {
                for (int j = 0; j < iWidth; j++)
                {
                    if (i == j)
                    {
                        count += (int)squares[i, j];
                        if ((int)squares[i, j] == -1)
                            cnt_player++;
                        if ((int)squares[i, j] == 0)
                        {
                            s = new Space(i, j);
                        }
                    }
                }
                if (count < iWidth && cnt_player == 0)
                {
                    return s;
                }
            }

            //diagnols right to left
            count = 0;
            cnt_player = 0;
            for (int i = 0; i < iLength; i++)
            {
                for (int j = 0; j < iWidth; j++)
                {
                    if (i + j + 1 == iWidth)
                    {
                        count += (int)squares[i, j];
                        if ((int)squares[i, j] == -1)
                            cnt_player++;
                        if ((int)squares[i, j] == 0)
                        {
                            s = new Space(i, j);
                        }
                    }
                }
                if (count < iWidth && cnt_player == 0)
                {
                    return s;
                }
            }
            #endregion
            do
            {
                s = new Space(rand.Next(0, iLength), rand.Next(0, iWidth));
            } while (space_IsTaken(s.X, s.Y));
            return s;
        }
        
        public override Player Winner(int iLength, int iWidth)
        {
            int count = 0;
            //columns
            for (int x = 0; x < iLength; x++)
            {
                count = 0;
                for (int y = 0; y < iLength; y++)
                    count += (int)squares[x, y];
                if (count == iLength)
                    return Player.X;
                if (count == -iWidth)
                    return Player.O;
            }

            //rows
            for (int x = 0; x < iWidth; x++)
            {
                count = 0;

                for (int y = 0; y < iWidth; y++)
                    count += (int)squares[y, x];

                if (count == iWidth)
                    return Player.X;
                if (count == -iWidth)
                    return Player.O;
            }

            //diagnols left to right
            count = 0;
            for (int i = 0; i < iLength; i++)
            {
                for (int j = 0; j < iWidth; j++)
                {
                    if (i == j)
                        count += (int)squares[i, j];
                }
            }
            if (count == iWidth)
                return Player.X;
            if (count == -iWidth)
                return Player.O;

            //diagnols right to left
            count = 0;
            for (int i = 0; i < iLength; i++)
            {
                for (int j = 0; j < iWidth; j++)
                {
                    if (i + j + 1 == iWidth)
                        count += (int)squares[i, j];
                }
            }
            if (count == iWidth)
                return Player.X;
            if (count == -iWidth)
                return Player.O;
            return Player.Open;
        }
        
        public override GameBoard Clone(int iLength, int iWidth)
        {
            GameBoard b = new TicTacToeBoard(iLength, iWidth);
            b.squares = (Player[,])this.squares.Clone();
            return b;
        }
    }
}
