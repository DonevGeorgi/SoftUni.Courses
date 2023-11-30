using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        //Fields
        private string name;
        private int storageCapacity;
        private List<Shoe> shoes;

        //Constructor
        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;

            Shoes = new();
        }

        //Properties
        public string Name { get; set; }
        public int StorageCapacity { get; set; }
        public List<Shoe> Shoes { get; set; }

        //Methods
        public int Count()
        {
            return Shoes.Count;
        }

        public string AddShoe(Shoe shoe)
        {
            if (Shoes.Count == this.StorageCapacity)
            {
                return "No more space in the storage room.";
            }

            Shoes.Add(shoe);
            return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
        }

        public int RemoveShoes(string material)
        {
            int removedShoes = 0;

            foreach (var shoe in Shoes)
            {
                if (shoe.Material == material)
                {
                    removedShoes++;
                }
            }

            Shoes.RemoveAll(x => x.Material == material);

            return removedShoes;
        }

        public List<Shoe> GetShoesByType(string type)
        {
            List<Shoe> sortedList = new();

            foreach (var shoe in Shoes)
            {
                if (shoe.Type == type.ToLower())
                {
                    sortedList.Add(shoe);
                }
            }

            return sortedList;
        }

        public Shoe GetShoeBySize(double size)
        {
            return Shoes.First(x => x.Size == size);
        }

        public string StockList(double size, string type)
        {
            StringBuilder sb = new();

            if (Shoes.Any(x => x.Size == size) && Shoes.Any(x => x.Type == type))
            {
                sb.AppendLine($"Stock list for size {size} - {type} shoes:");

                foreach (var shoe in Shoes)
                {
                    if (shoe.Size == size && shoe.Type == type)
                    {
                        sb.AppendLine($"Stock list for size {shoe.Size} - {shoe.Type} shoes:");
                    }
                }
            }
            else
            {
                return "No matches found!";
            }

            return sb.ToString().Trim();
        }
    }
}
