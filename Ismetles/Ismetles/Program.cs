using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ismetles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(10, 7, 1);
            Enemy enemy = new Enemy(2, 1, "Erasmus kapitány");
            int tuleltNapok = 0;

            while(player.HP > 0)
            {
                Console.Clear();
                Console.WriteLine("Az adott gombok a következő akciókat hajtják végre: \n" +
                    "\t 1-es gomb: Elmegyünk az erdőbe (Tipp: Fa lelőhely!)" + 
                    "\n \t 2-es gomb: Hazavisz (Biztonságos zóna)" +
                    "\n \t 3-as gomb: A rétre visz (Élelem szerzési lehetőség)" +
                    "\n \t 4-es gomb: A sivatagba visz (Esély piramist nézni)" +
                    "\n \t 5-ös gomb: A tóhoz visz (Tipp: Víz)");
                Console.WriteLine("\nMit szeretnél csinálni: ");
                int opcio = Convert.ToInt16(Console.ReadLine());

                while (!int.TryParse(Console.ReadLine(), out opcio) || opcio < 1 || opcio > 5)
                {
                    Console.WriteLine("Érvénytelen bemenet! Adj meg egy számot 1 és 5 között:");
                }
                player.Mozgas(opcio);


                Console.ReadKey();
                
                
            }

            // kellenek napok --> nem fix medddig éli túl --> akkor van vége a játéknak ha elfogy az életereje
            // Inventory rendszer
            // Hp
            // Éhség
            // Tevékenységek --> miket tudunk csinálni? 1, 2, 3, 4, 5, 6, 7, 8, 9
            // Minden tevékenység után történik valami random dolog 1, 2, 3, 4, 5, 6, 7, 8, 9

        }
    }
}
