using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Tic_Tac_Toe_2
{
    public enum Player
    {
        X = 1,
        O = -1,
        Open = 0,
    }

    
    public abstract class GameBoard
    {
        
        public Player[,] squares;
        public abstract Player this[int x, int y] { get; set; }
        public abstract bool IsFull { get; }
        public abstract int Size(int iLength, int iWidth);
        public abstract List<Space> OpenSquares(int iLength, int iWidth);
        public abstract Player Winner(int iLength, int iWidth);
        public abstract GameBoard Clone(int iLength, int iWidth);
        
        public abstract bool space_IsTaken(int xPos, int yPos);
        
        public abstract Space get_BestMove(int iLength, int iWidth);
    }

    
    public struct Space
    {
        public int X;
        public int Y;
        public double Rank;

        public Space(int x, int y)
        {
            this.X = x;
            this.Y = y;
            Rank = 0;
        }
    }
}
