using App.Models;

namespace App.Services;

public class ProductService : List<ProductModel>
{
    public ProductService()
    {
        this.AddRange(new ProductModel[] {
            new ProductModel() { Id = 1, Name = "Iphone", Price = 1000},
            new ProductModel() { Id = 2, Name = "Samsung", Price = 1100},
            new ProductModel() { Id = 3, Name = "Nokia", Price = 1200}
        });
    }
}

