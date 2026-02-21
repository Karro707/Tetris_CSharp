using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class GameGrid
    {
        private readonly int[,] grid; //row, column 
        public int Rows { get; }
        public int Cols { get; }

        public int this[int r, int c] 
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }

        public GameGrid(int rows, int columns) //konstruktor
        {
            Rows = rows;
            Cols = columns;
            grid = new int[Rows, Cols];
        }

        public bool IsInside(int r, int c) //checks if its inside grid or not
        {
            return (r >= 0 && r < Rows && c >= 0 && c < Cols); 
        }

        public bool IsEmpty(int r, int c) //checks if the cell is empty or not
        {
            return (grid[r,c] == 0 && IsInside(r,c));
        }

        public bool IsRowFull(int r, int c) //checks if the row is full
        {
            for (int i = 0; i < Cols; i++)
            {
                if (grid[r, i] == 0) return false;
            }
            return true;
        }

        public bool IsRowEmpty(int r, int c) //checks if the row is empty
        {
            for (int i = 0; i < Cols; i++)
            {
                if (grid[r, i] != 0) return false;
            }
            return true;
        }

        private void ClearRow(int r)
        {
            for (int i = 0; i < Cols; i++)
            {
                grid[r, i] = 0;
            }
        }

        private void MoveDown(int r, int numRows) //numRows -> number of rows to move down
        {
            for(int i = 0;i < Cols;i++)
            {
                grid[r + numRows, i] = grid[r,i]; //moves to the new place
                grid[r, i] = 0; //clears the previous one
            }
        }

        public int ClearFullRows(int r, int c) //clears rows and moves everything down
        {
            int Cleared = 0;
            int i = 0;
            while (IsRowEmpty(i,c))
            {
                if (IsRowFull(i, c))
                {
                    ClearRow(i);
                    Cleared++;
                }
                else if (Cleared != 0)
                {
                    MoveDown(i,Cleared);
                }
                
                i++;
            }

            return Cleared;
        }
    }
}
