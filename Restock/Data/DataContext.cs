using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restock.Models;

namespace Restock.Data;

public class DataContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<CartModel> Carts { get; set; }
    public DbSet<ProductModel> Products { get; set; }
    public DbSet<CategoryModel> Categories { get; set; }
    public DbSet<ReviewModel> Reviews { get; set; }
    public DbSet<SessionModel> Sessions { get; set; }
    public DbSet<UserModel> Users { get; set; }
    public DbSet<CartItemModel> CartItems { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; } 

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
    }
}