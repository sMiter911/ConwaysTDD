using ConwaysTDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConwayTDD.Test
{
    [TestClass]
    public class ConwayTests
    {
        // The rules of conway are as follows:
        // Any live cell with fewer than two live neighbours dies
        // Any live cell with two or three live neighbours lives
        // Any live cell with more than three live neighbours dies
        // Any dead cell with exactly three live neighbours becomes a live cell


        [TestMethod]
        public void CellsWithLessThanTwoLiveNeighb()
        {
            // Any live cell with fewer than two live neighbours dies 
            StateOfCell CurrentCellState = StateOfCell.Alive;
            int NumOfLiveNeighbors = 1;

            StateOfCell output = Conway.GetNewCellState(CurrentCellState, NumOfLiveNeighbors);

            Assert.AreEqual(StateOfCell.Dead, output);
        }

        [TestMethod]
        public void CellsWithTwoOrThreeliveNeighbors()
        {
            // Any live cell with two or three live neighbours lives
            StateOfCell CurrentCellState = StateOfCell.Alive;
            int NumOfLiveNeighbors = 3;

            StateOfCell output = Conway.GetNewCellState(CurrentCellState, NumOfLiveNeighbors);

            Assert.AreEqual(StateOfCell.Alive, output);
        }

        [TestMethod]
        public void CellsWithMoreThanThreeLiveNeighbors()
        {
            // Any live cell with more than three live neighbours dies
            StateOfCell CurrentCellState = StateOfCell.Alive;
            int NumOfLiveNeighbors = 4;

            StateOfCell output = Conway.GetNewCellState(CurrentCellState, NumOfLiveNeighbors);

            Assert.AreEqual(StateOfCell.Dead, output);
        }

        [TestMethod]
        public void DeadCellsWithExaltyThreeLiveNeighbors()
        {
            // Any dead cell with exactly three live neighbours becomes a live cell
          
            StateOfCell CurrentCellState = StateOfCell.Dead;
            int NumOfLiveNeighbors = 3;

            StateOfCell output = Conway.GetNewCellState(CurrentCellState, NumOfLiveNeighbors);

            Assert.AreEqual(StateOfCell.Alive, output);
        }
    }
}
