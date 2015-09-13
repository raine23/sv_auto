using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sv_auto
{
    public class MachineStash
    {
        public int balance;

        public Dictionary<string, int> stock;
        public Dictionary<string, Item> items;
        
        //Amount of coins inside
        public Dictionary<int, int> coins;

        public MachineStash()
        {
            stock = new Dictionary<string, int>();
            stock.Add("cake", 4);
            stock.Add("cookie", 3);
            stock.Add("waffle", 10);

            items = new Dictionary<string, Item>();
            items.Add("cake", new Item() { name = "cake", price = 50, title = "кекс" });
            items.Add("cookie", new Item() { name = "cookie", price = 10, title = "печенье" });
            items.Add("waffle", new Item() { name = "waffle", price = 30, title = "вафли" });

            balance = 0;

            InitializeCoinCount();
        }

        private void InitializeCoinCount()
        {
            coins = new Dictionary<int, int>();
            var rand = new Random();
            coins.Add(1, rand.Next(10));
            coins.Add(2, rand.Next(10));
            coins.Add(5, rand.Next(10));
            coins.Add(10, 0);//rand.Next(10));
        }


        /// <summary>
        /// Return all money as sum of all coins inside
        /// </summary>
        /// <returns></returns>
        public int GiveAllMoneyInside()
        {
            var sum = 0;
            foreach (KeyValuePair<int, int> coin in coins)
            {
                sum += coin.Key * coin.Value;
            }
            return sum;
        }


        public void IncertCoin(int coinType)
        {
            if (coins.ContainsKey(coinType))
            {
                ++coins[coinType];
                balance += coinType;
            }
        }

        public void ReturnCoin(int coinType)
        {
            if (coins.ContainsKey(coinType) && coins[coinType]>0 && balance> coinType)
            {
                --coins[coinType];
                balance -= coinType;
            }
        }

    }
}
