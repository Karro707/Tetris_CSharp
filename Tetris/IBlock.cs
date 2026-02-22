using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class IBlock : Block
    {
        private readonly Position[][] tiles = new Position[][] //positions of I block
        {   
            //(y,x)
            new Position[] { new(1,0), new(1,1), new(1,2), new(1,3) }, //State 0
            new Position[] { new(0,2), new(1,2), new(2,2), new(3,2) }, //State 1
            new Position[] { new(2,0), new(2,1), new(2,2), new(2,3) }, //State 2
            new Position[] { new(0,1), new(1,1), new(2,1), new(3,1) } //State 3  
        };

        public override int ID => 1;
        protected override Position StartOffset => new Position(-1,3);
        protected override Position[][] Tiles => tiles;
    }
}

//State 0
//0000
//1111
//0000
//0000

//State 1
//0010
//0010
//0010
//0010

//State 2
//0000
//0000
//1111
//0000

//State 3
//0100
//0100
//0100
//0100

