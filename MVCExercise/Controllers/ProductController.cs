using Microsoft.AspNetCore.Mvc;
using MVCExercise.Data;
using MVCExercise.Models;

namespace MVCExercise.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        _repository = repository;
    }
    // GET
    public IActionResult Index()
    {
        var products = _repository.GetAllProducts();
        return View(products);
    }

    public IActionResult ViewProduct(int id)
    {
        var product = _repository.GetProduct(id);
        return View(product);
    }

    public IActionResult UpdateProduct(int id)
    {
        var product = _repository.GetProduct(id);
        if (product == null)
        {
            return View("ProductNotFound");
        }

        return View(product);
    }
    public IActionResult UpdateProductToDatabase(Product product)
    {
        _repository.UpdateProduct(product);

        return RedirectToAction("ViewProduct", new { id = product.ProductID });
    }
    public IActionResult InsertProduct()
    {
        var prod = _repository.AssignCategory();
        return View(prod);
    }
    
    public IActionResult InsertProductToDatabase(Product productToInsert)
    {
        _repository.InsertProduct(productToInsert);
        return RedirectToAction("Index");
    }
}