using Restock.Contracts.v1.Request;
using Restock.Models;

namespace Restock.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly Dictionary<string, ProductModel> _products = new();
   
    public bool CreateProduct(ProductModel model)
    {
        if (model is null)
            return false;
        
        model.Id = Guid.NewGuid().ToString();
        _products[model.Id] = model;
        return true;
    }

    public bool UpdateProduct(string id, UpdateProductRequest model)
    {
        var product = GetProduct(id);

        if (product is null)
        {
            return false;
        }
        
        if (model is null)
            return false;
        
        _products[product.Id].Category = model.Category;
        _products[product.Id].Description = model.Description;
        _products[product.Id].Name = model.Name;
        _products[product.Id].Price = model.Price;
        _products[product.Id].ImageUrl = model.ImageUrl;
        _products[product.Id].InStock = model.InStock;
        _products[product.Id].IsAvailable = model.IsAvailable;
        
        return true;
    }

    public ProductModel GetProduct(string id)
    {
        var exists = _products.TryGetValue(id, out var model);
        
        return exists ? model : null;
    }

    public bool DeleteProduct(string id)
    {
        var existing = GetProduct(id);

        if (existing is null)
        {
            return false;
        }
        
        _products.Remove(id);
        return true;
    }

    public List<ProductModel> GetAllProducts(PaginationFilter paginationFilter = null)
    {
        if (paginationFilter is null)
            return _products.Values.ToList();

        var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
        return _products.Values.Skip(skip).Take(paginationFilter.PageSize).ToList();
    }
}