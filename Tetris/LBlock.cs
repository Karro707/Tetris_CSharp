using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class LBlock : Block
    {
        private readonly Position[][] tiles = new Position[][] //positions of L block
        {   
            //(y,x)
            new Position[] { new(0,2), new(1,2), new(1,1), new(1,0) }, //State 0
            new Position[] { new(2,2), new(2,1), new(1,1), new(0,1) }, //State 1
            new Position[] { new(2,0), new(1,2), new(1,1), new(1,0) }, //State 2
            new Position[] { new(0,0), new(0,1), new(1,1), new(2,1) }, //State 3
        };

        public override int ID => 3;
        protected override Position StartOffset => new Position(0, 3);
        protected override Position[][] Tiles => tiles;
    }
}

//State 0
//001
//111
//000

//State 1
//010
//010
//011

//State 2
//000
//111
//100

//State 3
//110
//010
//010