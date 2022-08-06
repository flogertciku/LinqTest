using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LinqTest.Models;

namespace LinqTest.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
     private MyContext _context;
     
    // here we can "inject" our context service into the constructor
    public HomeController(MyContext context)
    {
        _context = context;
    }


    public IActionResult Index()
    {

        ViewBag.marrNgaDB = _context.Products.ToList();
        return View();
    }

    public IActionResult Privacy()
    {
        
        return View();
    }
    
    Product[] myProducts = new Product[]
    {
     new Product { Name = "Jeans", Category = "Clothing", Price = 24.7 },
     new Product { Name = "Socks", Category = "Clothing", Price = 24.7 },
     new Product { Name = "scooter", Category = "Vehicle", Price = 99.99 },
     new Product { Name = "Skateboard", Category = "Vehicle", Price = 24.99 },
     new Product { Name = "Skirt", Category = "Clothing", Price = 17.5 }
    };


    [HttpGet("Add")]
    public IActionResult Add(){
        return View();
    }

    [HttpPost("Create")]
    public IActionResult Create(Product marrNgaView){

        if(ModelState.IsValid)
    {
         _context.Add(marrNgaView);
    // OR _context.Users.Add(newUser);
        _context.SaveChanges();
        // do somethng!  maybe insert into db?  then we will redirect
        return RedirectToAction("");
    }
    else
    {
        // Oh no!  We need to return a ViewResponse to preserve the ModelState, and the errors it now contains!
        return View("Add");
    }
    }


    [HttpGet("Edit/{id}")]
    public IActionResult Edit(int id){

        Product marrNgaDb = _context.Products.FirstOrDefault(p=> p.ProductId == id);
        return View("Edit",marrNgaDb);
    }

    [HttpPost("/Update/{id}")]
    public IActionResult Update(int id, Product produktiNgaView){
        // return "string;";
        Product marrNgaDb = _context.Products.FirstOrDefault(p=> p.ProductId == id);
        marrNgaDb.Name = produktiNgaView.Name;
        marrNgaDb.Price = produktiNgaView.Price;
        marrNgaDb.Category= produktiNgaView.Category;
        marrNgaDb.UpdatedAt = DateTime.Now;
        _context.SaveChanges();


        return RedirectToAction("");
    }
        
    


    [HttpGet("Show")]
    public IActionResult Show(){
        List<Product> listaIme = myProducts.ToList();
        ViewBag.list = listaIme;


        // order by cmime
        ViewBag.ListaCmimeve = myProducts.OrderBy(e => e.Price).ThenByDescending(item=> item.Name).ToList();

        ViewBag.Lista3 = myProducts.Where(e => e.Name.StartsWith('s') || e.Name.StartsWith('S')).OrderBy(item => item.Price).ThenByDescending(item=> item.Name).Take(3).ToList();

        ViewBag.Max = myProducts.OrderByDescending(y=> y.Price).FirstOrDefault();
        ViewBag.Nr = myProducts.Where(e => e.Name.StartsWith('s') || e.Name.StartsWith('S')).Count();


        
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
