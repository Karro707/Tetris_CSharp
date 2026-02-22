using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class SBlock : Block
    {
        private readonly Position[][] tiles = new Position[][] //positions of S block
        {   
            //(y,x)
            new Position[] { new(0,2), new(0,1), new(1,1), new(1,0) }, //State 1
            new Position[] { new(0,0), new(1,0), new(1,1), new(2,1) }, //State 1
        };

        public override int ID => 6;
        protected override Position StartOffset => new Position(0, 3);
        protected override Position[][] Tiles => tiles;
    }
}

//State 0
//011
//110
//000

//State 1
//100
//110
//010