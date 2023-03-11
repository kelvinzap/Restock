using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Restock.Models;

public class UserModel : IdentityUser
{
    [Key]
    public string Id { get; set; }
    public string  FirstName { get; set; }
    public string  MiddleName { get; set; }
    public string  LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string CountryOfResidence { get; set; }
    public string Nationality { get; set; }
    public DateTime DateOfRegistration { get; set; }
    public DateTime? UpdatedAt { get; set; }
}