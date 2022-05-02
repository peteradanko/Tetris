﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class OBlock : Block    
    {
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] {new (0,0), new (0,1), new (1,0), new (1,1) }
        };

        public override int Id => 4;
        public override Position StartOffset => new Position(0, 4);
        public override Position[][] Tiles => tiles;

    }
}
