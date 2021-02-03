using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebPortal.Database.Models;
using WebPortal.Database.Repositories.Interfaces;

namespace WebPortal.Database.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly IWebPortalContext _context;

        public ProductsRepository(IWebPortalContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Products> GetProductsByIdsAsync(List<int> ids)
        {
            return _context.Products.Where(p => ids.Contains(p.ProductId)).ToList();
        }

        public async Task<List<Products>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Products> AddProducts(Products products)
        {
            var product = await _context.Products.AddAsync(products);
            return product.Entity;
        }

        public async Task<Products> DeleteProductsById(int id)
        {
            var product = GetProductsByIdsAsync(new List<int>() {id});

            var result = _context.Products.Remove(product.FirstOrDefault());

            return result.Entity;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}