using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Property : Space
    {
        public Property(string name)
        {
            Name = name;
            Price = Program.RNG.Next(100, 301);
        }

        public string Name { get; }
        public int Price { get; }
        public int Rent { get { return (int)Math.Ceiling(Price * 0.25); } }
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
                        player.BuyProperty(this);
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
                UI.WriteLine("{0} es propiedad de {1}. El alquiler es ${2}.", this, Owner, Rent);
                if (player.Money > Rent)
                {
                    player.Money -= Rent;
                    Owner.Money += Rent;
                    UI.WriteLine("{0} ha pagado ${1} a {2}.", player, Rent, Owner);
                }
                else
                {
                    player.Lose();
                    UI.WriteLine("{0} no tiene dinero suficiente y ha quedado fuera de juego.", player);
                }
            }
        }

        public override string ToString()
        {
            return string.Format("{0} (${1})", Name, Price);
        }
    }
}
