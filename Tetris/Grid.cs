using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Grid
    {
        /*Two Dimensional rectangular array.*/
        private int[,] grid;

        /*Properties for the number of rows and columns. Future proof being able to add more to tables.*/
        public int row { get; }
        public int column { get; }
        
        /*Indexing for in game grid object*/
        public int this[int r, int c]
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }

        /*Initializing body with number of rows and columns. Can be used to create unconventional arrays*/
        public Grid(int rows, int columns)
        {
            row = rows;
            column = columns;
            //Ensure set row and column are within parameters of grid the grid is a non fixed variable may cause out of bounds. Ensure testing.
            grid = new int[rows, columns];
        }

        /*CHECK THIS BEFORE YOU ARE DONE COMPLETE CUSTOM BUILD*/
        /*Check if rows and columns fit within scope of grid*/
        public bool IsInside(int r, int c)
        {
            if (r >= 0 && r < row && c >= 0 && c < column)
            {
                return true;
            }
            else return false;
        }

        /*Check if cell is empty*/
        public bool IsEmpty(int r, int c)
        {
            if (IsInside(r, c) && grid[r, c] == 0)
            {
                return true;
            }
            else return false; 
        }

        /*Check if row is full. CANNOT INCLUDE SAME CHECKS WITHIN ONE METHOD*/
        public bool IsFull(int r)
        {
            for (int i = 0; i < column; i++)
            {
                if (grid[r,i] == 0)
                {
                    return false;
                }
            }
            return true;
        }
        
        /*Check if row is empty*/
        public bool IsRowEmpty (int r)
        {
            for (int i = 0; i < column; i++)
            {
                if (grid[r,i] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        /*Clear entire row*/
        private void ClearRow(int r)
        {
            for (int i = 0; i < column; i++)
            {
                grid[r, i] = 0;
            }
        }
        /*Checks new row*/
        private void MoveD(int r, int numRows)
        {
            for (int i = 0; i < column; i++)
            {
                grid[r + numRows, i] = grid[r, i];
                grid[r, i] = 0;

            }
        }
        /*Method called to check, clear, then move other rows down*/
        public int ClearRows()
        {
            int cleared = 0;

            for (int r = row -1; r >= 0; r--)
            {
                if (IsFull(r))
                {
                    ClearRow(r);
                    cleared++;
                }
                else if (cleared > 0)
                {
                    MoveD(r, cleared);
                }
            }

            return cleared;
        }
    }

    
}
