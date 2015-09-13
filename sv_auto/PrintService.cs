using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sv_auto
{
    class PrintService
    {
        public void PrintMainMenu(int pocketMoney, MachineStash MachineStash)
        {
            Console.Clear();

            Console.WriteLine("Автомат печенек      " + "Балланс: " + MachineStash.balance + "\n");

            Console.WriteLine("Выберите номер пункта:");
            Console.WriteLine("  1. Внести деньги");
            Console.WriteLine("  2. Выбрать позицию");
            Console.WriteLine("  3. Вернуть сдачу");
            Console.WriteLine("  0. Выход\n");

            Console.WriteLine("В кошельке: " + pocketMoney + " руб\n");
            PrintAllCoinsInside(MachineStash);
        }


        public void PrintInsertMenu(int pocketMoney, MachineStash MachineStash)
        {
            Console.Clear();

            Console.WriteLine("Положить монетку:    " + "Балланс: " + MachineStash.balance + "\n");
            Console.WriteLine("  1. - 1  руб");
            Console.WriteLine("  2. - 2  руб");
            Console.WriteLine("  3. - 5  руб");
            Console.WriteLine("  4. - 10 руб");
            Console.WriteLine("  Любая клавиша — отмена\n");

            Console.WriteLine("В кошельке: " + pocketMoney + " руб\n");
        }


        public void PrintItemMenu(MachineStash MachineStash)
        {
            Console.Clear();

            Console.WriteLine("Выбрать позицию:    " + "Балланс: " + MachineStash.balance + "\n");
            var idx = 1;
            foreach (Item item in MachineStash.items.Values)
            {
                Console.WriteLine("  " + idx + ". " + item.title + " - " + item.price + " руб  —  "+ MachineStash.stock[MachineStash.stock.Keys.ElementAt(idx - 1)] + " шт.");
                idx++;
            }
            Console.WriteLine("  Любая клавиша —  Отмена\n");
        }


        public void ShowCoinsReceived(int coin1, int coin2, int coin5, int coin10)
        {
            Console.WriteLine("Получено:");

            string s = "";
            
            s += coin10 != 0 ? ("  " + coin10 + " x 10 руб"): "";
            s += coin5 != 0 ? ("  " + coin5 + " x 5 руб") : "";
            s += coin2 != 0 ? ("  " + coin2 + " x 2 руб") : "";
            s += coin1 != 0 ? ("  " + coin1 + " x 1 руб\n") : "";

            Console.WriteLine(s);
        }


        public void PrintError(string error)
        {
            Console.WriteLine(error);
        }


        public void PrintAllCoinsInside(MachineStash MachineStash)
        {
            Console.WriteLine("В автомате:");
            foreach (KeyValuePair<int, int> coin in MachineStash.coins)
            {
                Console.WriteLine("  " + coin.Value + " x "+ coin.Key + " руб");
            }

            Console.WriteLine("Всего: " + MachineStash.GiveAllMoneyInside() + " руб\n");
        }

    }
}
