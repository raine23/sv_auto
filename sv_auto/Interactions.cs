using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sv_auto
{
    class Interactions
    {
        PrintService PrintService = new PrintService();


        public int InsertCoin(MachineStash MachineStash, int  pocketMoney)
        {

            PrintService.PrintInsertMenu(pocketMoney, MachineStash);

            char selectedMenu = 'a';
            while (selectedMenu != '0')
            {
                //Read key for menu
                selectedMenu = Console.ReadKey().KeyChar;

                //Return key symbol as index number - 1
                var idx = (int)selectedMenu - 49;
                
                if (idx>=0 && idx < MachineStash.coins.Count)
                {

                    if (pocketMoney >= MachineStash.coins.Keys.ElementAt(idx))
                    {
                        MachineStash.IncertCoin(MachineStash.coins.Keys.ElementAt(idx));
                        pocketMoney -= MachineStash.coins.Keys.ElementAt(idx);
                        PrintService.PrintInsertMenu(pocketMoney, MachineStash);
                    }
                    else
                    {
                        PrintService.PrintInsertMenu(pocketMoney, MachineStash);
                        PrintService.PrintError("Недостаточно денег");
                    }
                }
                else
                {
                    break;
                }
            }
            return pocketMoney;
        }


        /// <summary>
        /// Show menu of product selection
        /// </summary>
        /// <param name="MachineStash"></param>
        public void ChooseMenuItem (MachineStash MachineStash)
        {
            PrintService.PrintItemMenu(MachineStash);

            char selectedMenu = 'a';
            while (selectedMenu != '4')
            {
                //Read key for menu
                selectedMenu = Console.ReadKey().KeyChar;
                //Return key symbol as index number - 1
                var idx = (int)selectedMenu - 49;

                if (idx >= 0 && idx < MachineStash.items.Count)
                {
                    var selectedItem = MachineStash.items[MachineStash.items.Keys.ElementAt(idx)];
                    if (MachineStash.balance < selectedItem.price)
                    {
                        PrintService.PrintItemMenu(MachineStash);
                        PrintService.PrintError("Недостаточно денег");
                        continue;
                    }

                    if (MachineStash.stock[selectedItem.name] <= 0)
                    {
                        PrintService.PrintItemMenu(MachineStash);
                        PrintService.PrintError("Недостаточно товара");
                        continue;
                    }

                    //Correct your pocket and machine balance after buing
                    MachineStash.balance -= selectedItem.price;
                    --MachineStash.stock[selectedItem.name];
                    PrintService.PrintItemMenu(MachineStash);
                }
                else
                {
                    break;
                }
            }
        }

        
        public int ReceiveMoney(int pocketMoney, MachineStash MachineStash)
        {
            var coin = new int[4];
            int returnMoney = 0,
                balance = MachineStash.balance;

            if (MachineStash.balance == 0)
            {
                PrintService.PrintError("Нечего возвращать");
                return returnMoney;
            }

            //Begin from 10 coin
            for (int idx = 3; idx >= 0; idx--)
            {
                //How many max value coins can you receive
                coin[idx] = balance / MachineStash.coins.Keys.ElementAt(idx);
                //If machine has, it give all max value coin
                if (MachineStash.coins[MachineStash.coins.Keys.ElementAt(idx)] >= coin[idx])
                {
                    balance -= coin[idx] * MachineStash.coins.Keys.ElementAt(idx);
                    returnMoney += coin[idx] * MachineStash.coins.Keys.ElementAt(idx);
                    MachineStash.coins[MachineStash.coins.Keys.ElementAt(idx)] -= coin[idx];
                }
                //Give how many coins (max value) it has. (If 0 - give 0)
                else
                {
                    coin[idx] = MachineStash.coins[MachineStash.coins.Keys.ElementAt(idx)];
                    balance -= coin[idx] * MachineStash.coins.Keys.ElementAt(idx);
                    returnMoney += coin[idx] * MachineStash.coins.Keys.ElementAt(idx);
                    MachineStash.coins[MachineStash.coins.Keys.ElementAt(idx)] -= coin[idx];
                }
            }

            if (balance > 0)
            {
                PrintService.PrintError("Отсутствует сдача");
                return 0;
            }

            MachineStash.balance = balance;
            //Print refresh info
            PrintService.PrintMainMenu(pocketMoney + returnMoney, MachineStash);
            PrintService.ShowCoinsReceived(coin[0], coin[1], coin[2], coin[3]);
            return returnMoney;
        }

    }
}
