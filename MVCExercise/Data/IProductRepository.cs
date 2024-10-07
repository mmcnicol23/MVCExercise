using MVCExercise.Models;

namespace MVCExercise.Data;

public interface IProductRepository
{
    public IEnumerable<Product> GetAllProducts();
    public Product GetProduct(int id);
}