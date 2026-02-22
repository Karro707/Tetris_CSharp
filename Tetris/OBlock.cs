using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class OBlock : Block
    {
        private readonly Position[][] tiles = new Position[][] //positions of O block
        {   
            //(y,x)
            new Position[] { new(1,0), new(1,1), new(1,2), new(1,3) }, //State 0 
        };

        public override int ID => 4;
        protected override Position StartOffset => new Position(0,4);
        protected override Position[][] Tiles => tiles;
    }
}

//State 0
//0000
//0110
//0110
//0000


