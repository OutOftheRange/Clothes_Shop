﻿using ClothesShop.Services.Interfaces;
using ClothesShop.Services.Models.ItemsModels;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShop.WebAPI.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        IItemsService _itemsService;
        public ItemsController(IItemsService itemsService) {
            _itemsService= itemsService;
        }

        [HttpGet("get-item-by-id/{itemId}")]
        public async Task<IActionResult> GetItemById(int itemId)
        {
            var result = await _itemsService.GetItemById(itemId);

            return result != null ? Ok(result) : BadRequest(result);
        }

        [HttpGet("get-item-by-page")]
        public async Task<IActionResult> GetItemByPage(int page, int pageSize)
        {
            var result = await _itemsService.GetItemsByPage(page, pageSize);

            return result != null ? Ok(result) : BadRequest(result);
        }

        [HttpPost("add-new-item")]
        public async Task<IActionResult> AddNewItem(ItemsDetailedData newItemPostData)
        {
            var result = await _itemsService.AddNewItem(newItemPostData);

            return result.Result == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update-item/{itemId}")]
        public async Task<IActionResult> UpdateItem([FromBody]ItemsDetailedData updatedData, int itemId)
        {
            var result = await _itemsService.UpdateItem(updatedData, itemId);

            return result.Result == true ? Ok(result) : BadRequest(result);
        }

        [HttpGet("deactivate-item/{itemId}")]
        public async Task<IActionResult> DeactivateItem(int itemId)
        {
            var result = await _itemsService.DeactivateItem(itemId);

            return result.Result == true ? Ok(result) : BadRequest(result);
        }

        [HttpGet("add-cart-item/{itemId}, {userId}")]
        public async Task<IActionResult> AddCartItem(int itemId, string userId)
        {
            var result = await _itemsService.AddCartItem(itemId, userId);

            return result.Result == true ? Ok(result) : BadRequest(result);
        }


        [HttpGet("delete-cart-item/{itemId}")]
        public async Task<IActionResult> DeleteCartItem(int itemId)
        {
            var result = await _itemsService.DeleteCartItem(itemId);

            return result.Result == true ? Ok(result) : BadRequest(result);
        }
    }
}
