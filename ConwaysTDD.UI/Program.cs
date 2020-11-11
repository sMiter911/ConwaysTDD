using System;
using System.Text;

namespace ConwaysTDD.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new CellBoard(10, 10);
            grid.Randomize();

            ShowGrid(grid.CurrentCellState);

            while (Console.ReadLine() != "q")
            {
                grid.UpdateState();
                ShowGrid(grid.CurrentCellState);
            }
        }

        private static void ShowGrid(StateOfCell[,] currentCellState)
        {
            Console.Clear();
            int x = 0;
            int rowLength = currentCellState.GetUpperBound(1) + 1;

            var output = new StringBuilder();

            foreach (var state in currentCellState)
            {
                output.Append(state == StateOfCell.Alive ? "O" : ".");
                x++;
                if (x >= rowLength)
                {
                    x = 0;
                    output.AppendLine();
                }
            }
            Console.Write(output.ToString());
        }
    }
}
