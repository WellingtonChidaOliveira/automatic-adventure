using System;

namespace Product.CRUD.API.Models;
//anemic model
public class Products
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    // EF Core requires an empty constructor
    public Products()
    {
    }
    public Products(string name, string description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
    }
}
