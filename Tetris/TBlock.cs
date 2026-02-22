using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class TBlock : Block
    {
        private readonly Position[][] tiles = new Position[][] //positions of T block
        {   
            //(y,x)
            new Position[] { new(0,1), new(1,0), new(1,1), new(1,2) }, //State 0
            new Position[] { new(1,2), new(0,1), new(1,1), new(2,1) }, //State 1
            new Position[] { new(2,1), new(1,2), new(1,1), new(1,0) }, //State 2
            new Position[] { new(1,0), new(0,1), new(1,1), new(2,1) }, //State 3
        };

        public override int ID => 5;
        protected override Position StartOffset => new Position(0, 3);
        protected override Position[][] Tiles => tiles;
    }
}

//State 0
//010
//111
//000

//State 1
//010
//011
//010

//State 2
//000
//111
//010

//State 3
//010
//110
//010