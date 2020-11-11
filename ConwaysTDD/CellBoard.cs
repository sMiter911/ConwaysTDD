using System;
using System.Collections.Generic;
using System.Text;

namespace ConwaysTDD
{
    public class CellBoard
    {
        int boardHeight;
        int boardWidth;

        public StateOfCell[,] CurrentCellState;
        public StateOfCell[,] NextCellState;

        public CellBoard(int height, int width)
        {
            boardHeight = height;
            boardWidth = width;

            CurrentCellState = new StateOfCell[boardHeight, boardWidth];
            NextCellState = new StateOfCell[boardHeight, boardWidth];

            for (int i = 0; i < boardHeight; i++)
            {
                for (int j = 0; j < boardWidth; j++)
                {
                    CurrentCellState[i, j] = StateOfCell.Dead;
                }
            }
        }

        public void UpdateState()
        {
            for (int i = 0; i < boardHeight; i++)
            {
                for (int j = 0; j < boardWidth; j++)
                {
                    var numOfLiveNeighbors = GetLiveNeighbors(i, j);
                    NextCellState[i, j] = Conway.GetNewCellState(CurrentCellState[i, j], numOfLiveNeighbors);
                }
            }
            CurrentCellState = NextCellState;
            NextCellState = new StateOfCell[boardHeight, boardWidth];
        }

        private int GetLiveNeighbors(int XPosition, int YPosition)
        {
            int numOfLiveNeighbors = 0;

            for(int i = -1; i <= 1; i++)
            {
                for(int j = -1; j <= 1; j++)
                {
                    if (i ==0 && j == 0)
                    {
                        continue;
                    }
                    int neighborX = XPosition + i;
                    int neighborY = YPosition + j;

                    if (neighborX >= 0 && neighborX < 5 &&
                        neighborY >= 0 && neighborY < 5)
                    {
                        if (CurrentCellState[neighborX, neighborY] == StateOfCell.Alive)
                        {
                            numOfLiveNeighbors++;
                        }
                    }
                }
            }
            return numOfLiveNeighbors;
        }

        public void Randomize()
        {
            Random random = new Random();

            for(int i = 0; i < boardHeight; i++)
            {
                for (int j = 0; j < boardWidth; j++)
                {
                    var next = random.Next(2);
                    var newState = next < 1 ? StateOfCell.Dead : StateOfCell.Alive;
                    CurrentCellState[i, j] = newState;
                }
            }
        }
    }
}
