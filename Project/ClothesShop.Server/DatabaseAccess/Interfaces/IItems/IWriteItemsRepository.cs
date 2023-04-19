using ClothesShop.DatabaseAccess.Entities.CartEntity;
using ClothesShop.DatabaseAccess.Entities.ItemsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.DatabaseAccess.Interfaces.ItemsRepository
{
    public interface IWriteItemsRepository
    {
        public Task<Items> AddCartItem(int itemId, string userId);
        public Task<Items> AddNewItem(Items items);
        public Task<Items> UpdateItem(Items items, int itemId);
        public Task<Items> DeactivateItem(int itemId);
        public Task<CartItems> DeleteCartItem(int itemId);
    }
}
