using System;

namespace ConwaysTDD
{
    public enum StateOfCell
    {
        Dead,
        Alive
    }
    public class Conway
    {
        public static StateOfCell GetNewCellState(StateOfCell CurrentCellState, int NumOfLiveNeighbors)
        {
            //if (CurrentCellState == StateOfCell.Alive && NumOfLiveNeighbors < 2)
            //{
            //    return StateOfCell.Dead;
            //}
            //if (CurrentCellState == StateOfCell.Alive && NumOfLiveNeighbors > 3)
            //{
            //    return StateOfCell.Dead;
            //}
            //if (CurrentCellState == StateOfCell.Dead && NumOfLiveNeighbors == 3)
            //{
            //    return StateOfCell.Alive;
            //}

            // A switch statement is better 
            switch (CurrentCellState)
            {
                case StateOfCell.Alive:
                    if( NumOfLiveNeighbors < 2 || NumOfLiveNeighbors > 3)
                    {
                        return StateOfCell.Dead;
                    }
                    break;
                case StateOfCell.Dead:
                    if (NumOfLiveNeighbors == 3)
                    {
                        return StateOfCell.Alive;
                    }
                    break;
            }
            return CurrentCellState;
        }
    }
}
