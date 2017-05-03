using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category,int page = 1)
            => View(new ProductListViewModel
            {
                Products = repository.Products.OrderBy(p => p.ProductID)
                .Where(p=>p.Category==null||p.Category==category)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems =category==null? repository.Products.Count(): repository.Products.Where(e =>
 e.Category == category).Count()
                },
                CurrentCategory=category
            }
        );

    }
}