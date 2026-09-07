using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ismetles
{
    public class Enemy
    {
        public int HP { get; set; }
        public int Sebzes { get; set; }
        public string Nev { get; set; }

        public Enemy(int hp, int sebzes, string nev)
        {
            HP = hp;
            Sebzes = sebzes;
            Nev = nev;
        }
        public void Sebzodes( int amount, Player player)
        {
            HP -= amount;
            if(HP <= 0)
            {
                Console.WriteLine($"{Nev} meghalt.");
                player.Inventory.Add(Items.Alkohol);
            }
        }

        public void Tamadas(Player player)
        {
            player.HP -= Sebzes;
        }
    }
}
