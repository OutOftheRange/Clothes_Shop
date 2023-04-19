using ClothesShop.DatabaseAccess.Entities.ItemsEntity;
using ClothesShop.DatabaseAccess.Interfaces.ItemsRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.DatabaseAccess.Repositories.ItemsRepository
{
    public class ReadItemsRepository : IReadItemsRepository
    {
        private ClothesShopDbContext _context;

        public ReadItemsRepository(ClothesShopDbContext context)
        {
            _context = context;
        }

        public async Task<Entities.ItemsEntity.Items> GetItemById(int itemId)
        {
            return await _context.Items
                .Include(a => a.Category)
                .Include(a => a.Color)
                .Include(a => a.Size)
                .Include(a => a.Photos)
                .FirstOrDefaultAsync(a => a.Id == itemId);
        }
        public async Task<IEnumerable<Entities.ItemsEntity.Items>> GetItemsByPage(int page, int pageSize)
        {
            return await _context.Items
                .Where(a => a.IsDeactivated == false)
                .Include(a => a.Color)
                .Include(a => a.Photos)
                .Include(a => a.Size)
                .Include(a => a.Category)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
            
    }
}
