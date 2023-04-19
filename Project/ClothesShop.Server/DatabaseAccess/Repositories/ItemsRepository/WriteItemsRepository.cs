using ClothesShop.DatabaseAccess.Entities.CartEntity;
using ClothesShop.DatabaseAccess.Entities.ItemsEntity;
using ClothesShop.DatabaseAccess.Interfaces.ItemsRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.DatabaseAccess.Repositories.Items
{
    public class WriteItemsRepository : IWriteItemsRepository
    {
        private ClothesShopDbContext _context;
        private IReadItemsRepository _readItemsRepository;
        public WriteItemsRepository(ClothesShopDbContext context, IReadItemsRepository readItemsRepository)
        {
            _context = context;
            _readItemsRepository = readItemsRepository;
        }

        public async Task<Entities.ItemsEntity.Items> AddNewItem(Entities.ItemsEntity.Items items)
        {
            items.IsDeactivated = false;
            var domainAdvert = await _context.Items.AddAsync(items);

            await _context.SaveChangesAsync();

            return await _readItemsRepository.GetItemById(domainAdvert.Entity.Id);
        }

        public async Task<Entities.ItemsEntity.Items> AddCartItem(int itemId, string userId)
        {
            var findedItem = await _context.Items.FindAsync(itemId);
            if(findedItem == null) 
            {
                return null;
            }
            //var countCartItems = await _context.CartItems.Count;
            var cartItem = new CartItems {ItemId = findedItem.Id,  Name = findedItem.Name, UserId = Guid.Parse(userId) };
            
            var addItemToCart = await _context.CartItems.AddAsync(cartItem);

            await _context.SaveChangesAsync();

            return await _readItemsRepository.GetItemById(findedItem.Id);
        }

        public async Task<Entities.ItemsEntity.Items> UpdateItem(Entities.ItemsEntity.Items item, int itemId)
        {
            _context.Entry(item).CurrentValues.SetValues(item);

            await _context.SaveChangesAsync();

            return await _readItemsRepository.GetItemById(item.Id);
        }

        public async Task<Entities.ItemsEntity.Items> DeactivateItem(int itemId)
        {
            var findedItem = await _readItemsRepository.GetItemById(itemId);
            if (findedItem == null)
            {
                return null;
            }
            findedItem.IsDeactivated = true;

            await _context.SaveChangesAsync();

            return findedItem;
        }

        public async Task<Entities.CartEntity.CartItems> DeleteCartItem(int itemId)
        {
            var findedItem = await _context.CartItems.FirstOrDefaultAsync(x => x.Id == itemId);

            _context.Entry(findedItem).State = EntityState.Deleted;

            await _context.SaveChangesAsync();

            return findedItem;
        }
    }
}
