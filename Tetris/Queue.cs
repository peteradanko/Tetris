using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /*Only two blocks at the moment*/
    public class Queue
    {
        private readonly Block[] blocks = new Block[]
        {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock()

        };

    private readonly Random random = new Random();

    public Block NextBlock { get; private set; }

    
    private Block RandomBlock()
        {
            return blocks[random.Next(blocks.Length)];
        }
        /*Day 2 Error Handling (Block Null): Edit to lower position as was set as lone method not initialization*/
        public Queue()
        {
            NextBlock = RandomBlock();
        }

        public Block GetAndUpdate()
        {
            Block block = NextBlock;

            do
            {
                NextBlock = RandomBlock();
            } while (block.Id == NextBlock.Id);

            return block;
        }
    }

    
}
