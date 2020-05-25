using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Board
    {
        private Space[] spaces;

        public Board(int size)
        {
            Size = size;

            spaces = new Space[size];
            spaces[0] = new Go();
            for (int i = 1; i < size; i++)
            {
                if (i % 5 == 0)
                {
                    spaces[i] = new Railroad("F" + (i / 5).ToString());
                }
                else
                {
                    spaces[i] = new Property("P" + i.ToString());
                }
            }
        }

        public int Size { get; }

        public Space GetSpaceAt(int index)
        {
            return spaces[index];
        }
    }
}
