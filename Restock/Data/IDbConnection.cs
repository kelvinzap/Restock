using MongoDB.Driver;
using Restock.Models;

namespace Restock.Data;

public interface IDbConnection
{
    string DbName { get; }
    string CartCollectionName { get; }
    string ProductCollectionName { get; }
    string CategoryCollectionName { get; }
    string SessionCollectionName { get; }
    string UserCollectionName { get; }
    MongoClient Client { get; }
    IMongoCollection<CartModel> CartCollection { get; }
    IMongoCollection<ProductModel> ProductCollection { get; }
    IMongoCollection<CategoryModel> CategoryCollection { get; }
    IMongoCollection<SessionModel> SessionCollection { get; }
    IMongoCollection<UserModel> UserCollection { get; }
    IMongoCollection<ReviewModel> ReviewCollection { get; }
}