using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
public ProductController (IProductRepository repo)
	{
            repository=repo;
	}
        
        public ViewResult List()=>View(repository.Products);

    }
}