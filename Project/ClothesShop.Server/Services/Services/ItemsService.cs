using AutoMapper;
using ClothesShop.DatabaseAccess.Entities.ItemsEntity;
using ClothesShop.DatabaseAccess.Interfaces.ItemsRepository;
using ClothesShop.Services.Interfaces;
using ClothesShop.Services.Models.ItemsModels;
using ClothesShopServices.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.Services.Services
{
    public class ItemsService : IItemsService
    {
        private IReadItemsRepository _readItemsRepository;
        private IWriteItemsRepository _writeItemsRepository;
        private IMapper _mapper;

        public ItemsService(IReadItemsRepository readItemsRepository, IWriteItemsRepository writeItemsRepository, IMapper mapper)
        {
            _readItemsRepository = readItemsRepository;
            _writeItemsRepository = writeItemsRepository;
            _mapper = mapper;
        }

        private ResponceData NullValidation<T>(T inputElement, string successfulMessage, string failureMessage)
        {
            var result = new ResponceData();

            if (inputElement != null)
            {
                result.Result = true;
                result.Message = successfulMessage;
            }
            else
            {
                result.Result = false;
                result.Message = failureMessage;
            }
            return result;
        }

        public async Task<ItemsDetailedData> GetItemById(int itemId)
        {
            var findedItem = await _readItemsRepository.GetItemById(itemId);

            var result = _mapper.Map<ItemsDetailedData>(findedItem);

            return result;
        }

        public async Task<IEnumerable<ItemsDetailedData>> GetItemsByPage(int page, int pageSize)
        {
            var listOfItems = await _readItemsRepository.GetItemsByPage(page, pageSize);

            var result = _mapper.Map<IEnumerable<ItemsDetailedData>>(listOfItems);

            return result.ToList();
        }

        public async Task<ResponceData> AddNewItem(ItemsDetailedData newItemPostData)
        {
            var mappedItem = _mapper.Map<Items>(newItemPostData);

            var createdItem = _writeItemsRepository.AddNewItem(mappedItem);

            return NullValidation(createdItem, "Item was added successfuly", "An error occured while adding new item");
        }

        public async Task<ResponceData> UpdateItem(ItemsDetailedData newItemPostData, int itemId)
        {
            var findedItem = await _readItemsRepository.GetItemById(itemId);

            var mappedItem = _mapper.Map(newItemPostData, findedItem);

            var updatedItem = _writeItemsRepository.UpdateItem(mappedItem, itemId);

            return NullValidation(updatedItem, "Item was updated successfully", "An error occured while updating new item");
        }

        public async Task<ResponceData> AddCartItem(int itemId, string userId)
        {         
            var addedToCartItem = _writeItemsRepository.AddCartItem(itemId, userId);

            return NullValidation(addedToCartItem, "Item was added to cart successfully", "An error occured while adding item to cart");
        }

        public async Task<ResponceData> DeactivateItem(int itemId)
        {
            var deactivatedItem = _writeItemsRepository.DeactivateItem(itemId);

            return NullValidation(deactivatedItem, "Item was deactivated successfully", "An error occured while deactivating cart");
        }

        public async Task<ResponceData> DeleteCartItem(int itemId)
        {
            var deletedCartItem = _writeItemsRepository.DeleteCartItem(itemId);

            return NullValidation(deletedCartItem, "Cart item was deleted successfully", "An error occured whiledeleting cart item");
        }
    }
}
