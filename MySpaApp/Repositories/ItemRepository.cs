using System.Collections.Generic;
using System.Linq;
using MySpaApp.Models;

namespace MySpaApp.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly List<Item> items = new List<Item>();
        private int currentId = 1;

        public IEnumerable<Item> GetAll() => items;

        public Item GetById(int id) => items.FirstOrDefault(i => i.Id == id);

        public void Create(Item item)
        {
            item.Id = currentId++;
            items.Add(item);
        }

        public void Update(Item item)
        {
            var index = items.FindIndex(i => i.Id == item.Id);
            if (index >= 0)
            {
                items[index] = item;
            }
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                items.Remove(item);
            }
        }
    }
}