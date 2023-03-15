using Microsoft.EntityFrameworkCore;
using Restock.Data;
using Restock.Models;

namespace Restock.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly DataContext _dataContext;

        public CartRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateCart(CartModel model)    
        {
            try
            {
                await _dataContext.Carts.AddAsync(model);
                var created = await _dataContext.SaveChangesAsync();
                
                if (created < 1)
                    return false;
                
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
            
        }

        public async Task<bool> DeleteCart(string Id)
        {
            try
            {
                var cart = await GetCartById(Id);
                
                if (cart is null)
                    return false;

                _dataContext.Carts.Remove(cart);
                var deleted = await _dataContext.SaveChangesAsync();
                
                return deleted < 1 ? false : true;

            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public async Task<CartModel?> GetCartById(string Id)
        {
            try
            {
                return await _dataContext.Carts.Include(x => x.Items).AsNoTracking().SingleOrDefaultAsync(x => x.Id == Id);
            }
            catch (Exception ex)
            {

                return null;
            }

        }

        public async Task<bool> UpdateCart(CartModel model)
        {
            try
            {
                var cart = await _dataContext.Carts.Include(x => x.Items).SingleOrDefaultAsync(x => x.Id == model.Id);
                
                if (cart is null)
                    return false;

                cart.SessionId = model.SessionId;
                cart.UserId = model.UserId;
                cart.Items = model.Items;


                var updated = await _dataContext.SaveChangesAsync();
                return updated < 1 ? false : true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool>  DeleteCartItem(string Id)       
        {
            try
            {
                var cartItem = await _dataContext.CartItems.SingleOrDefaultAsync(c => c.Id == Id);

                if (cartItem is null) 
                    return false;

                _dataContext.CartItems.Remove(cartItem);

                var deleted = await _dataContext.SaveChangesAsync();

                return deleted < 1 ? false : true;

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
