using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class IBlock : Block
    {
        /*I-Block States:
         State0 = (1,0) (1,1) (1,2) (1,3)
        State1 = (0,2) (1,2) (2,2) (3,2)
        State2 = (2,0) (2,1) (2,2) (2,3)
        State3 = (0,1) (1,1) (2,1) (3,1)*/

        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] {new(1,0), new(1,1), new(1,2), new(1,3)},
            new Position[] {new(0,2), new(1,2), new(2,2), new(3,2)},
            new Position[] {new(2,0), new(2,1), new(2,2), new(2,3)},
            new Position[] {new(0,1), new(1,1), new(2,1), new(3,1)}
        };

        /*Set Id to 1*/
        public override int Id => 1;
        /*Start the block off to the middle of the top row*/
        public override Position StartOffset => new Position(-1,3);
        /*Return the tiles arrary above*/
        public override Position[][] Tiles => tiles;
    }
}
