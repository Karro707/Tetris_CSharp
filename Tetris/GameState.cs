using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class GameState
    {
        private Block currentBlock;

        public Block CurrentBlock //takes current block and updates it (position and rotation)
        {
            get => currentBlock;
            private set
            {
                currentBlock = value;
                currentBlock.Reset();

                for(int i=0; i < 2;i++) //moves the spawned block 2 tiles if nothing is in the way
                {
                    currentBlock.Move(1, 0);

                    if(!BlockFits())
                    {
                        currentBlock.Move(-1, 0);
                    }
                }

            }
        }

        public GameGrid GameGrid { get; private set; }
        public BlockQueue BlockQueue { get; }
        public bool GameOver { get; private set; } //checks if the player lost

        public GameState()
        {
            GameGrid = new GameGrid(22, 10); //game screen 22x10
            BlockQueue = new BlockQueue();
            CurrentBlock = BlockQueue.GetAndUpdate();
        }

        private bool BlockFits() //checks if the block is in illegal position
        {
            foreach (Position p in CurrentBlock.TilePosition())
            {
                if (!GameGrid.IsEmpty(p.Row, p.Col)) //checks if its in grid (IsInside) and if any block is on it (IsEmpty)
                {
                    return false;
                }
            }
            return true;
        }

        public void RotateBlockCW() //rotates CW but only if it's possible (might be in the middle of blocks for example)
        {
            CurrentBlock.RotateCW();

            if(!BlockFits())
            {
                CurrentBlock.RotateCounterCW();
            }
            //rotates and it it fits it stays, if not, goes back 
        }

        public void RotateBlockCounterCW() //rotates CCW like the upper method
        {
            CurrentBlock.RotateCounterCW();

            if (!BlockFits())
            {
                CurrentBlock.RotateCW();
            }
        }

        public void MoveBlockLeft()
        {
            CurrentBlock.Move(0, -1);

            if(!BlockFits())
            {
                CurrentBlock.Move(0,1);
            }
        }

        public void MoveBlockRight()
        {
            CurrentBlock.Move(0, 1);

            if (!BlockFits())
            {
                CurrentBlock.Move(0, -1);
            }
        }

        private bool IsGameOver()
        {
            return (!(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1)) && (GameOver == false)); //if either of the hidden rows are not empty (there is a block), game ends
        }

        private void PlaceBlock() //Sets the block in GameGrid
        {
            foreach(Position p in CurrentBlock.TilePosition())
            {
                GameGrid[p.Row, p.Col] = CurrentBlock.ID;
            }

            GameGrid.ClearFullRows(); //checks if a row is full after putting a block

            if(IsGameOver()) //check if the block finished the game
            {
                GameOver = true;
            }
            else
            {
                CurrentBlock = BlockQueue.GetAndUpdate(); 
            }
        }

        public void MoveBlockDown() //blocks in tetris going down
        {
            CurrentBlock.Move(1, 0);

            if (!BlockFits())
            {
                CurrentBlock.Move(-1, 0);
                PlaceBlock(); //in case the block can't be moved down, place it 
            }
        }
    }
}
