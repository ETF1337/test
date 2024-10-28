
using System.Collections.Generic;
using MySpaApp.Models;

namespace MySpaApp.Repositories
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAll();
        Item GetById(int id);
        void Create(Item item);
        void Update(Item item);
        void Delete(int id);
    }
}