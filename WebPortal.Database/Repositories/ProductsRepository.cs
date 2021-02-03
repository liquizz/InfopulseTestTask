using System;
using System.Collections.Generic;
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

        public async Task<Products> GetProductsByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(_ => _.ProductId == id);
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
            var product = await GetProductsByIdAsync(id);

            var result = _context.Products.Remove(product);

            return result.Entity;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}