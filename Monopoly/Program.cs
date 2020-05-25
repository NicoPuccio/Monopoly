using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Program
    {
        public static readonly Random RNG = new Random();

        static Board board = new Board(20);
        static List<Player> players = new List<Player>();

        static void Main(string[] args)
        {
            ChooseNumberOfPlayers();
            Player winner = StartGame();
            UI.WriteLine("El ganador es {0}", winner);
            UI.ReadLine();
        }

        private static void ChooseNumberOfPlayers()
        {
            int n = UI.ChooseNumber("Elija cantidad de jugadores (2 - 6):", 2, 6);
            for (int i = 1; i <= n; i++)
            {
                players.Add(new Player("J" + i, board));
            }
        }

        private static Player StartGame()
        {
            int turn = 0;
            while(true)
            {
                Player currentPlayer = players[turn];
                currentPlayer.Play();

                Player winner = CheckForWinner();
                if (winner != null)
                {
                    return winner;
                }

                // Increment turn but keep it between [0 - players.Count)
                turn = (turn + 1) % players.Count;
            }
        }

        private static Player CheckForWinner()
        {
            IEnumerable<Player> stillPlaying = players.Where(p => p.Playing);
            if (stillPlaying.Count() != 1) return null;
            return stillPlaying.First();
        }

    }
}
