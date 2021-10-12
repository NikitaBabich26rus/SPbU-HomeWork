namespace Test3
{
    /// <summary>
    /// Tic tac toe field
    /// </summary>
    public class Table
    {
        private Cell[,] field;

        /// <summary>
        /// Tic tac toe field constructor.
        /// </summary>
        public Table()
        {
            field = new Cell[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    field[i, j] = new Cell();
                }
            }
        }

        /// <summary>
        /// Changed table
        /// </summary>
        /// <param name="row">Row number</param>
        /// <param name="column">Column number</param>
        /// <param name="value">Value</param>
        public void ChangeTable(int row, int column, string value)
        {
            field[row, column].IsPushed = true;
            field[row, column].Value = value;
        }

        /// <summary>
        /// Check is game over?
        /// </summary>
        /// <returns>True or false</returns>
        public bool IsGameOver() =>
            IsEqualLine(field[0, 0], field[0, 1], field[0, 2]) || IsEqualLine(field[1, 0], field[1, 1], field[1, 2]) ||
            IsEqualLine(field[2, 0], field[2, 1], field[2, 2]) || IsEqualLine(field[0, 0], field[1, 0], field[2, 0]) ||
            IsEqualLine(field[0, 1], field[1, 1], field[2, 1]) || IsEqualLine(field[0, 2], field[1, 2], field[2, 2]) ||
            IsEqualLine(field[0, 0], field[1, 1], field[2, 2]) || IsEqualLine(field[0, 2], field[1, 1], field[2, 0]);

        /// <summary>
        /// Is line of eqaul value?
        /// </summary>
        /// <param name="cell1">Cell1</param>
        /// <param name="cell2">Cell2</param>
        /// <param name="cell3">Cell3</param>
        /// <returns>True or false</returns>
        private bool IsEqualLine(Cell cell1, Cell cell2, Cell cell3) => cell1.Value == cell2.Value && cell2.Value == cell3.Value &&
            cell1.IsPushed && cell2.IsPushed && cell3.IsPushed;
    }
}
