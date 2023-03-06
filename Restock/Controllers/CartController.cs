using Microsoft.AspNetCore.Mvc;
using Restock.Repositories;
using Restock.Services;

namespace Restock.Controllers;

public class CartController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly ICartService _cartService;

    public CartController(IProductRepository productRepository, ICartService cartService)
    {
        _productRepository = productRepository;
        _cartService = cartService;
    }
}