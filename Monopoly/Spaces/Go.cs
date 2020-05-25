using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Go : Space
    {
        public override void ReceivePlayer(Player player)
        {
            player.Money += 200;
            UI.WriteLine("Se pagaron $200 a {0}", player);
        }

        public override string ToString()
        {
            return "LARGADA";
        }
    }
}
