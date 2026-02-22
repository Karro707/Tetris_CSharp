using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class ZBlock : Block
    {
        private readonly Position[][] tiles = new Position[][] //positions of Z block
        {   
            //(y,x)
            new Position[] { new(0,0), new(0,1), new(1,1), new(1,2) }, //State 0
            new Position[] { new(0,2), new(1,2), new(1,1), new(2,1) }, //State 1 
        };

        public override int ID => 7;
        protected override Position StartOffset => new Position(0, 3);
        protected override Position[][] Tiles => tiles;
    }
}

//State 0
//110
//011
//000

//State 1
//001
//011
//010