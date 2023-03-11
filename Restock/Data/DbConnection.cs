using MongoDB.Driver;
using Restock.Models;

namespace Restock.Data;

public class DbConnection : IDbConnection
{
    private readonly IConfiguration _config;
    private readonly IMongoDatabase _mongoDatabase;
    private readonly string connectionId = "MongoDb";
    public string DbName { get; private set; }
    public string CartCollectionName { get; } = "carts";
    public string ProductCollectionName { get; } = "products";
    public string CategoryCollectionName { get; } = "categories";
    public string SessionCollectionName { get; } = "sessions";
    public string UserCollectionName { get; } = "users";
    public string ReviewCollectionName { get; } = "reviews";
    
    public MongoClient Client { get; }
    public IMongoCollection<CartModel> CartCollection { get; }
    public IMongoCollection<ProductModel> ProductCollection { get; }
    public IMongoCollection<CategoryModel> CategoryCollection { get; }
    public IMongoCollection<SessionModel> SessionCollection { get; }
    public IMongoCollection<UserModel> UserCollection { get; }
    public IMongoCollection<ReviewModel> ReviewCollection { get; }

    public DbConnection(IConfiguration config)
    {
        _config = config;
        var connect = _config.GetConnectionString(connectionId);
        Client = new MongoClient(connect);
        DbName = _config["DatabaseName"];
        _mongoDatabase = Client.GetDatabase(DbName);

        CartCollection = _mongoDatabase.GetCollection<CartModel>(CartCollectionName);
        ProductCollection = _mongoDatabase.GetCollection<ProductModel>(ProductCollectionName);
        CategoryCollection = _mongoDatabase.GetCollection<CategoryModel>(CategoryCollectionName);
        SessionCollection = _mongoDatabase.GetCollection<SessionModel>(SessionCollectionName);
        UserCollection = _mongoDatabase.GetCollection<UserModel>(UserCollectionName);
        ReviewCollection = _mongoDatabase.GetCollection<ReviewModel>(ReviewCollectionName);
    }
}