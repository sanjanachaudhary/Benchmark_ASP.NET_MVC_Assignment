using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using layoutView.Models;

namespace layoutView.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = new List<Product>()
            {
                new Product(){ productid=101,productname="AC",rate=45000},
                new Product(){ productid=102,productname="moblie",rate=25000},
                new Product(){ productid=103,productname="laptop",rate=75000},
                new Product(){ productid=104,productname="bike",rate=195000}
            };
            
            return View(products);
        }

        public ActionResult Details(int id)
        {
            List<Product> products = new List<Product>()
            {
                new Product(){ productid=101,productname="AC",rate=45000},
                new Product(){ productid=102,productname="moblie",rate=25000},
                new Product(){ productid=103,productname="laptop",rate=75000},
                new Product(){ productid=104,productname="bike",rate=195000}
            };
            Product matchingProduct=null;
            foreach(var item in products)
            {
                if(item.productid == id)
                {
                    matchingProduct = item;
                }
            }
            
            return View(matchingProduct);  
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include="productid,productname")]Product d)
        {
            return View();
        }
    }
}