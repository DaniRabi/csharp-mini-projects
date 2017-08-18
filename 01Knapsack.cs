using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Knapsack
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int W = int.Parse(Console.ReadLine());
            string valueInput = Console.ReadLine();
            string weightInput = Console.ReadLine();

            string[] values = valueInput.Split(' ');
            string[] weights = weightInput.Split(' ');

            /**********SOLUTION********** 
            List<Item> items = new List<Item>();
            for (int j = 0; j < n; j++)
            {
                int value = int.Parse(values[j]);
                int weight = int.Parse(weights[j]);
                items.Add(new Item(value, weight));
            }

            items.OrderByDescending(it => it.Value);
            items.Reverse();

            ItemCollection knapsack = new ItemCollection(W);
            items.ForEach(item => knapsack.AddItem(item));
            Console.WriteLine(knapsack.ValueSum());
            *******************************/


            /**********IMPROVED SOLUTION**********
            List<Item> items = new List<Item>();
            for (int j = 0; j < n; j++)
            {
                int value = int.Parse(values[j]);
                int weight = int.Parse(weights[j]);
                items.Add(new Item(value, weight));
            }

            items.OrderByDescending(it => it.Value);
            items.Reverse();

            List<ItemCollection> options = new List<ItemCollection>();
            foreach (Item item in items)
            {
                ItemCollection option = new ItemCollection(W);
                option.AddItem(item);
                foreach (Item item2 in items)
                    if (!item2.Equals(item))
                        option.AddItem(item2);
                options.Add(option);
            }
            Console.WriteLine(options.Max(knap => knap.ValueSum()));
            ******************************/

            /**********OPTIMAL SOLUTION**********
            int[] v = new int[values.Length];
            int[] w = new int[weights.Length];
            for (int i = 0; i < values.Length; i++)
            {
                v[i] = int.Parse(values[i]);
                w[i] = int.Parse(weights[i]);
            }

            int[,] m = new int[n + 1, W + 1];

            for (int j = 0; j <= W; j++)
                m[0, j] = 0;
            for (int i=1; i < n; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    if (w[i] > j)
                        m[i, j] = m[i - 1, j];
                    else
                        m[i, j] = Math.Max(m[i - 1, j], m[i - 1, j - w[i]] + v[i]);
                }
            }

            int max = 0;
            for (int i = 0; i <= n; i++)
                for (int j = 0; j <= W; j++)
                    max = Math.Max(max, m[i, j]);

            Console.WriteLine(max);
            ******************************/

            Console.ReadLine();
        }
    }
    public class Item
    {
        private int value;
        private int weight;

        public int Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }
        public int Weight
        {
            get
            {
                return weight;
            }

            set
            {
                weight = value;
            }
        }

        public Item(int value, int weight)
        {
            this.value = value;
            this.weight = weight;
        }

        public bool IsTooHeavy(int W)
        {
            return weight > W;
        }
    }
    public class ItemCollection : List<Item>
    {
        private int capacity;

        public int Capacity1
        {
            get
            {
                return capacity;
            }

            set
            {
                capacity = value;
            }
        }

        public ItemCollection(int W) : base()
        {
            capacity = W;
        }

        public int ValueSum()
        {
            return this.Sum(item => item.Value);
        }

        public void AddItem(Item item)
        {
            if (!item.IsTooHeavy(capacity))
            {
                Add(item);
                capacity -= item.Weight;
            }
        }
    }
}
