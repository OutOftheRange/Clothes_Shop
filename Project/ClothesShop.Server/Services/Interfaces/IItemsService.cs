using ClothesShop.Services.Models.ItemsModels;
using ClothesShopServices.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.Services.Interfaces
{
    public interface IItemsService
    {
        public Task<ItemsDetailedData> GetItemById(int itemId);
        public Task<IEnumerable<ItemsDetailedData>> GetItemsByPage(int page, int pageSize);
        public Task<ResponceData> AddNewItem(ItemsDetailedData newItemPostData);
        public Task<ResponceData> UpdateItem(ItemsDetailedData updateItemPostData, int itemId);
        public Task<ResponceData> AddCartItem(int itemId, string userId);
        public Task<ResponceData> DeactivateItem(int itemId);
        public Task<ResponceData> DeleteCartItem(int itemId);
    }
}
