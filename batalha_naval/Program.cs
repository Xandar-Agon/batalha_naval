using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace batalha_naval
{
    class Program
    {
        public static string GetCord()
        {
            Console.WriteLine("Introduza duas coordenadas separadas por um espaço");
            string cord = Console.ReadLine();
            return cord;
        }

        public static bool CheckCord(string cord, int diff)
        {
            if ((int)cord[0] < 97 || (int)cord[0] > 97+diff || (int)cord[2] < 48 || (int)cord[2] > 48+diff)
            {
                System.Console.WriteLine("Dados Inválidos");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static string GetName()
        {
            Console.WriteLine("Introduza o seu nome");
            string nome = Console.ReadLine();
            return nome;
        }

        public static void PlayGame(Player player1, Player player2)
        {
            Console.WriteLine(player1.GetName() + ',');
            player1.GetBoard().PlaceShips();
            Console.Clear();

            Console.WriteLine(player2.GetName() + ',');
            player2.GetBoard().PlaceShips();
            Console.Clear();

            do
            {
                Console.WriteLine(player2.GetName()+',');
                player2.GetBoard().Fire();
                player2.GetBoard().PrintBoard();

                Console.WriteLine(player1.GetName()+',');
                player1.GetBoard().Fire();
                player1.GetBoard().PrintBoard();
                
            } while (!player2.GetBoard().CheckLoss() || !player1.GetBoard().CheckLoss());
        }

        public static int GetDiff()
        {
            int diff = 7;
            Console.WriteLine("Pretende que modo de dificuldade?");
            Console.WriteLine("1-fácil");
            Console.WriteLine("2-intremédio");
            Console.WriteLine("3-difícil");
            
            switch(Console.ReadLine()){
                case "1":
                    diff = 7;
                    break;
                case "2":
                    diff = 8;
                    break;
                case "3":
                    diff = 9;
                    break;
                default:
                    GetDiff();
                    break;
                    
            }
            return diff;
        }


        static void Main(string[] args)
        {
            int diff = GetDiff();
            Player player1 = new Player(GetName(),diff);
            Player player2 = new Player(GetName(),diff);
            PlayGame(player1, player2);
        }
    }
}
