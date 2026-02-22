using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class BlockQueue
    {
        private readonly Block[] blocks = new Block[]
        {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new TBlock(),
            new SBlock(),
            new ZBlock()
        };

        private readonly Random random = new Random(); //randomizer for new block

        public Block NextBlock { get; private set; } //shows next block for the player

        public BlockQueue()
        {
            NextBlock = RandomBlock();
        }

        public Block RandomBlock() //returns a random block
        {
            return blocks[random.Next(blocks.Length)]; //Random.Next(int maxValue) <- returns a non-negative int that is less than the specified maximum
        }

        public Block GetAndUpdate() //returns the next block and updates the property 
        {
            Block block = NextBlock;

            do
            {
                NextBlock = RandomBlock();
            }while(block.ID == NextBlock.ID); //we want new block so it keeps picking till it's diff

            return block;
        }
    }
}
