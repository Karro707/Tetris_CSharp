using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public abstract class Block
    {
        protected abstract Position[][] Tiles { get; } //tiles positions in 4 rotation states (so length is 4)
        //Tiles 0 -> 0degrees
        //Tiles 1 -> 90degrees
        //Tiles 2 -> 180degrees
        //Tiles 3 -> 270degrees
        protected abstract Position StartOffset { get; } //where the block starts in the grid
        public abstract int ID { get; }

        private int rotationState; 
        private Position offset;

        public Block ()
        {
            offset = new Position (StartOffset.Row, StartOffset.Col);
        }

        public IEnumerable<Position> TilePosition()
        {
            foreach (Position p in Tiles[rotationState])
            {
                yield return new Position(p.Row + offset.Row, p.Col + offset.Col);
            }
        }

        public void RotateCW() //rotates the block 90degrees clockwise
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }

        public void RotateCounterCW() //rotates like method above, just counter clock wise
        {
            if(rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }

        public void Move(int rows, int columns) //moves the block by certain number of rows and columns
        {
            offset.Row += rows;
            offset.Col += columns;  
        }

        public void Reset() //resets the rotation&position
        {
            rotationState = 0;
            offset.Row = StartOffset.Row;
            offset.Col = StartOffset.Col;
        }

        public IEnumerable<Position> TilePositions()
        {
            foreach (Position p in Tiles[rotationState])
            {
                yield return new Position (p.Row + offset.Row, p.Col + offset.Col);
            }
        }
    }
}
