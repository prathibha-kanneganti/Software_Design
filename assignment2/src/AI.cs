using System.Collections.Generic;
using System;

namespace Tic_Tac_Toe_2
{
    class AI
    {
        
        public static Space GetBestMove(GameBoard gb, Player p, int iLength, int iWidth)
        {
            Space? bestSpace = null;
            List<Space> openSpaces = gb.OpenSquares(iLength, iWidth);
            GameBoard newBoard;
            for (int i = 0; i < openSpaces.Count; i++)
            {
                newBoard = gb.Clone(iLength, iWidth);
                Space newSpace = openSpaces[i];

                newBoard[newSpace.X, newSpace.Y] = p;

                if (newBoard.Winner(iLength, iWidth) == Player.Open && newBoard.OpenSquares(iLength, iWidth).Count > 0)
                {
                   
                    Space tempMove = GetBestMove(newBoard, ((Player)(-(int)p)), iLength, iWidth);  
                    newSpace.Rank = tempMove.Rank;
                }
                else
                {
                    if (newBoard.Winner(iLength, iWidth) == Player.Open)
                        newSpace.Rank = 0;
                    else if (newBoard.Winner(iLength, iWidth) == Player.X)
                        newSpace.Rank = -1;
                    else if (newBoard.Winner(iLength, iWidth) == Player.O)
                        newSpace.Rank = 1;
                }

               
                if (bestSpace == null ||
                   (p == Player.X && newSpace.Rank < ((Space)bestSpace).Rank) ||
                   (p == Player.O && newSpace.Rank > ((Space)bestSpace).Rank))
                {
                    bestSpace = newSpace;
                }
            }

            return (Space)bestSpace;
        }
    }
}