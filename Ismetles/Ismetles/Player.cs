using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ismetles
{
    public enum Teruletek
    {
        Erdo,
        Otthon,
        Ret,
        Sivatag,
        To
    }

    public enum Items
    {
        Fa,
        Etel,
        Viz,
        Gyogynoveny,
        Alkohol,

    }
    public class Player
    {
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int Etel { get; set; }
        public int Viz { get; set; }
        public bool Ittas { get; set; }
        public int Sebzes { get; set; }
        public Teruletek Lokacio { get; set; }

        public List<Items> Inventory = new List<Items>();
        public Player(int maxhp, int maxEtel, int sebzes)
        {
            MaxHP = maxhp;
            HP = maxhp;
            Etel = maxEtel;
            Sebzes = sebzes;
            Lokacio = Teruletek.Otthon;
        }

        public void Ehezes()
        {
            Etel -= 1;
        }

        bool tamadas = false;

        public void Pialas()
        {
            if(Inventory.Contains(Items.Alkohol))
            {
                Ittas = true;
            }
        }

        public void Gyogyitas()
        {
            if(Inventory.Contains(Items.Gyogynoveny))
            {
                HP += 2;
            }
        }

        public void Harc(Enemy enemy)
        {
            // ki üt kit?
            if(tamadas == true)
            {
                return;
            }
            Tamadas(enemy);
            enemy.Tamadas(this);

        }

        public void Halal()
        {
            if(HP <= 0)
            {
                Console.WriteLine("Meghaltál");
            }
        }

        public void Etkezes()
        {
            bool etel = false;
            foreach (var item in Inventory)
            {
                if (item == Items.Etel)
                {
                    Etel += 1;
                    Inventory.Remove(item);
                    etel = true;
                }
            }
            if (etel == false)
            {
                Console.WriteLine("Üres a hűtő!");
            }
        }

        public void Ivas()
        {
            bool viz = false;
            foreach (var item in Inventory)
            {
                if(item == Items.Viz)
                {
                    Viz += 1;
                    Inventory.Remove(item);
                    viz = true;
                }
            }
            if(viz == false)
            {
                Console.WriteLine("Nincs víz");
            }
        }

        public void Favagas()
        {
            Inventory.Add(Items.Fa);
            Console.WriteLine("Fa kivágva! Az inventoryhoz hozzáadva!");
        }

        public void ShowInventory()
        {
            foreach (var item in Inventory)
            {
                Console.WriteLine($"\t {item}");
            }
        }

        public void Mozgas(int opcio)
        {
            if(opcio == 1)
            {
                Lokacio = Teruletek.Erdo;
                Console.WriteLine("Az erdőben vagy!");
            }
            if (opcio == 2)
            {
                Lokacio = Teruletek.Otthon;
                Console.WriteLine("Otthon vagy!");
            }
            if (opcio == 3)
            {
                Lokacio = Teruletek.Ret;
                Console.WriteLine("A réten vagy!");
            }
            if (opcio == 4)
            {
                Lokacio = Teruletek.Sivatag;
                Console.WriteLine("A sivatagban vagy!");
            }
            if (opcio == 5)
            {
                Lokacio = Teruletek.To;
                Console.WriteLine("A tónál vagy!");
            }
        }

        public void Tamadas(Enemy enemy)
        {
            tamadas = true;
            if(Ittas)
            {
                Console.WriteLine("A karakter táncolni kezdett és a levegőt püföli.");
                tamadas = false;
                return;            
            }
            enemy.Sebzodes(Sebzes, this);
                tamadas = false;
        }
        public void Sebzodes()
        {
            HP -= 1;
        }
        
        public void Alvas()
        {
            HP += 1;
            Ittas = false;
        }
    }
}
