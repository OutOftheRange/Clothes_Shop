using ClothesShop.DatabaseAccess.Entities.ItemsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.DatabaseAccess.Interfaces.ItemsRepository
{
    public interface IReadItemsRepository
    {
        public Task<Items> GetItemById(int itemId);
        public Task<IEnumerable<Items>> GetItemsByPage(int page, int pageSize);
    }
}
