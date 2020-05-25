using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Player
    {
        private int position;
        private int money;

        public Player(string name, Board board)
        {
            Name = name;
            Board = board;

            Position = 0;
            Money = 1500;
        }

        public string Name { get; }
        public Board Board { get; }
        public bool Playing { get; private set; } = true;

        public int Position
        {
            get { return position; }
            private set
            {
                position = value % Board.Size;
            }
        }

        public int Money
        {
            get { return money; }
            set { money = value; }
        }

        public List<Property> Properties { get; } = new List<Property>();
        public List<Railroad> Railroads { get; } = new List<Railroad>();

        public void Play()
        {
            if (!Playing) { return; }

            UI.Clear();
            UI.WriteLine("Turno: {0}", this);
            UI.WriteLine("Propiedades: {0}", string.Join(", ", Properties));
            UI.WriteLine("Ferrocarriles: {0}", string.Join(", ", Railroads));
            UI.WriteLine();
            Move();
            Space space = Board.GetSpaceAt(Position);
            UI.WriteLine("{0} cayó en {1}.", this, space);
            UI.WriteLine();
            space.ReceivePlayer(this);

            UI.ReadLine();
        }

        public void Move()
        {
            int die1 = Program.RNG.Next(1, 7);
            int die2 = Program.RNG.Next(1, 7);
            UI.WriteLine("Dados: {0}", die1 + die2);
            UI.WriteLine("Posición anterior: {0}", Position);
            Position += die1 + die2;
            UI.WriteLine("Posición nueva: {0}", Position);
        }

        public void Lose()
        {
            Properties.ForEach(p => p.Owner = null);
            Railroads.ForEach(r => r.Owner = null);
            Playing = false;
        }

        public void BuyProperty(Property property)
        {
            Money -= property.Price;
            property.Owner = this;
            Properties.Add(property);
        }

        public void BuyRailroad(Railroad railroad)
        {
            Money -= railroad.Price;
            railroad.Owner = this;
            Railroads.Add(railroad);
        }

        public override string ToString()
        {
            return string.Format("{0} (${1})", Name, Money);
        }
    }
}
