using System.Dynamic;

namespace Hunter
{
    class Hunter
    {
        Random rand = new Random();
        public string name { get; private set; }
        private uint health;
        private uint gold;
        private uint arrow;
        public uint prey { get; private set; }

        public Hunter(string name, uint health, uint gold, uint arrow)
        {
            this.name = name;
            this.health = health;
            this.gold = gold;
            this.arrow = arrow;
        }

        public void Hunting()
        {
            if (arrow <= 5) 
            {
                Console.WriteLine("Not enough arrows for hunting!");
                return;
            }
            if (health <= 5)
            {
                Console.WriteLine("Not enough health for hunting!");
                return;
            }

            uint _arrow = Convert.ToUInt32(rand.Next(1, 5));
            uint _health = Convert.ToUInt32(rand.Next(0, 3));
            uint _prey = Convert.ToUInt32(rand.Next(0, 5));
            uint _gold = 0;
            if (_prey > 0)
            {
                _gold = _prey * 2;
            }

            Console.WriteLine("During the hunt, you lost: " + _arrow + " arrows, " + _health + " health.");
            Console.WriteLine("You gained: " + _prey + " prey, " + _gold + " gold.");

            arrow -= _arrow;
            health -= _health;
            prey += _prey;
            gold += _gold;
        }

        public void BuyArrow()
        {
            Console.WriteLine("One arrow costs 1 gold. Enter the number of arrows you wish to purchase.");
            uint buy = Convert.ToUInt32(Console.ReadLine());
            if (gold >= buy)
            {
                Console.WriteLine("You bought " + buy + " arrow.");
                arrow += buy;
            }
            else
            {
                Console.WriteLine("You do not have enough gold.");
            }
        }

        public void Info()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Gold: " + gold);
            Console.WriteLine("Arrow: " + arrow);
            Console.WriteLine("Prey: " + prey);
        }
    }
    internal class Program
    {
        static Hunter CreateHunter(int uid)
        {
            Console.WriteLine("Creating hunter #" + uid);
            Console.WriteLine("Enter the name: ");
            string name = Console.ReadLine()!;
            Console.WriteLine("Enter the amount of health: ");
            uint health = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("Enter the amount of gold: ");
            uint gold = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("Enter the amount of arrow: ");
            uint arrow = Convert.ToUInt32(Console.ReadLine());

            return new Hunter(name, health, gold, arrow);
        }

        static void Play(Hunter hunter)
        {
            hunter.Info();
            int i = 0;
            while (i == 0)
            {
                Console.WriteLine("Select an action:\n1 - Hunting;\n2 - Buy ammo;\n3 - Player information;\n 4 - Exit");
                uint action = Convert.ToUInt32(Console.ReadLine());
                switch (action)
                {
                    case 1:
                        hunter.Hunting();
                        break;
                    case 2:
                        hunter.BuyArrow();
                        break;
                    case 3:
                        hunter.Info();
                        break;
                    case 4:
                        i = 1;
                        break;

                }
            }
        }

        static void Main(string[] args)
        {
            Hunter hunter1 = CreateHunter(1);
            Hunter hunter2 = CreateHunter(2);

            Console.WriteLine("Player 1 plays");
            Play(hunter1);
            Console.WriteLine("Player 2 plays");
            Play(hunter2);

            Console.WriteLine("The game is over. Results:");
            hunter1.Info();
            hunter2.Info();

            if (hunter1.prey > hunter2.prey)
            {
                Console.WriteLine("The player " + hunter1.name + " won");
            }
            else if (hunter1.prey < hunter2.prey)
            {
                Console.WriteLine("The player " + hunter2.name + " won");
            }
            else
            {
                Console.WriteLine("Draw!");
            }

        }
    }
}
