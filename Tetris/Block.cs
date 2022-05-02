using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /*Need for Abstract calsses due to passing in delcared variables. Apparently we cannot inherit classes within classes without abstract properties*/
    public abstract class Block
    {
        public abstract Position[][] Tiles { get; }
        public abstract Position StartOffset { get; }
        public abstract int Id { get; }

        private int rotatioState;

        private Position offset;

        public Block()
        {
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }
        public IEnumerable<Position> TilePositions()
        {
            foreach (Position p in Tiles[rotatioState])
            {
                /*Using yield to define an iterator removes the need for an explicit extra class (the class that holds the state for an enumeration*/
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
            }
        }

        /*Method use to rotates blow 90 degrees clockwise*/
        public void Rotate()
        {
            rotatioState = (rotatioState + 1) % Tiles.Length;
        }

        public void RotateCounterClockWise()
        {
            if (rotatioState == 0)
            {
                rotatioState = Tiles.Length - 1;
            }
            else
            {
                rotatioState--;
            }
        }

        public void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        public void Reset()
        {
            rotatioState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }

    }
}
