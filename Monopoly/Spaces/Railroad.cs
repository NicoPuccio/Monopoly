using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Railroad : Space
    {
        public Railroad(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public int Price { get; } = 150;
        public int TicketCost { get { return Owner.Railroads.Count * 50; } }
        public Player Owner { get; set; }

        public override void ReceivePlayer(Player player)
        {
            if (Owner == null)
            {
                UI.WriteLine("{0} no tiene dueño.", this);
                if (UI.ChooseBoolean("¿Desea comprarla? (s: sí, N: no)"))
                {
                    if (player.Money < Price)
                    {
                        UI.WriteLine("{0} no tiene dinero suficiente.", player);
                    }
                    else
                    {
                        player.BuyRailroad(this);
                        UI.WriteLine("{0} compró {1}.", player, this);
                    }
                }
            }
            else if (Owner == player)
            {
                UI.WriteLine("{0} es el dueño de {1}. Fin del turno.", player, this);
            }
            else
            {
                UI.WriteLine("{0} es propiedad de {1}. El costo del pasaje es ${2}.", this, Owner, TicketCost);
                if (player.Money > TicketCost)
                {
                    player.Money -= TicketCost;
                    Owner.Money += TicketCost;
                    UI.WriteLine("{0} ha pagado ${1} a {2}.", player, TicketCost, Owner);
                }
                else
                {
                    player.Lose();
                    UI.WriteLine("{0} no tiene dinero suficiente y ha quedado fuera del juego.", player);
                }
            }
        }

        public override string ToString()
        {
            return string.Format("{0} (${1})", Name, Price);
        }
    }
}
