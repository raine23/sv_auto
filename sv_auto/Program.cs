using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace sv_auto
{
    class Program
    {
        static void Main(string[] args)
        {
            var Interactions = new Interactions();
            var PrintService = new PrintService();
            var MashineStash = new MachineStash();

            int pocketMoney = 150;

            Console.CursorVisible = false;

            PrintService.PrintMainMenu(pocketMoney, MashineStash);
            char selectedMenu = 'a';
            while (selectedMenu != '0')
            {
                //Read key for menu
                selectedMenu = Console.ReadKey().KeyChar;
                
                switch (selectedMenu)
                {
                    case ('1'):
                        {
                            //Insert money and repaint screen after
                            pocketMoney = Interactions.InsertCoin(MashineStash, pocketMoney);
                            PrintService.PrintMainMenu(pocketMoney, MashineStash);
                            break;
                        }
                    case ('2'):
                        {
                            //Buy items and repaint screen after
                            Interactions.ChooseMenuItem(MashineStash);
                            PrintService.PrintMainMenu(pocketMoney, MashineStash);
                            break;
                        }
                    case ('3'):
                        {
                            //Receive money and show what
                            PrintService.PrintMainMenu(pocketMoney, MashineStash);
                            pocketMoney += Interactions.ReceiveMoney(pocketMoney, MashineStash);
                            break;
                        }
                    default:
                        {
                            //Don't show press key
                            PrintService.PrintMainMenu(pocketMoney, MashineStash);
                            break;
                        }
                }
            }
            
        }
    }
}
