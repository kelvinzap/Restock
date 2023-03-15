using Microsoft.EntityFrameworkCore;
using Restock.Contracts.v1.Request;
using Restock.Data;
using Restock.Models;

namespace Restock.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DataContext _dataContext;

    public ProductRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<bool> CreateProduct(ProductModel model)
    {
        try
        {
            await _dataContext.Products.AddAsync(model);
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

    public async Task<bool> DeleteProduct(string id)
    {
        try
        {
            var product = await GetProductById(id);

            if (product is null)
                return false;

            _dataContext.Products.Remove(product);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted >= 1;

        }
        catch (Exception ex)
        {

            return false;
        }
    }

    public async Task<List<ProductModel>> GetAllProducts(PaginationFilter? paginationFilter = null)
    {
        if(paginationFilter is not null)
        {
            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await _dataContext.Products.Skip(skip).Take(paginationFilter.PageSize).ToListAsync();
        }
        return await _dataContext.Products.ToListAsync();
    }

    public async Task<ProductModel?> GetProductById(string id)
    {
        try
        {
       return await _dataContext.Products.AsNoTracking().SingleOrDefaultAsync(r => r.Id == id);
            

        }
        catch (Exception ex)
        {

            return null;
        }
    }

    public async Task<bool> UpdateProduct(ProductModel model)
    {
        try
        {
            _dataContext.Products.Update(model);
            var updated = await _dataContext.SaveChangesAsync();
            return updated < 1 ? false : true;
        }
        catch (Exception ex)
        {

            return false;
        }
    }
}