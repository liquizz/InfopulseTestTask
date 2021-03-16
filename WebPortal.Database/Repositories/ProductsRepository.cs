using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public async Task<ProductCategories> GetProductCategoryByIdAsync(int id)
        {
            return await _context.ProductCategories.FirstOrDefaultAsync(_ => _.CategoryId == id);
        }

        public async Task<ProductSizes> GetProductSizeByIdAsync(int id)
        {
            return await _context.ProductSizes.FirstOrDefaultAsync(_ => _.SizeId == id);
        }

        public async Task<ProductDescriptions> GetProductDescriptionsByIdAsync(int id)
        {
            return await _context.ProductDescriptions.FirstOrDefaultAsync(_ => _.ProductDescriptionId == id);
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

        public async Task<OrdersProducts> AddOrderProduct(OrdersProducts ordersProduct)
        {
            var newOrdersProducts = await _context.OrdersProducts.AddAsync(ordersProduct);
            return newOrdersProducts.Entity;
        }

        public ProductDescriptions UpdateDescription(ProductDescriptions descriptions)
        {
            var description = _context.ProductDescriptions.Update(descriptions).Entity;
            return description;
        }
        public Products UpdateProduct(Products products)
        {
            var product = _context.Products.Update(products).Entity;
            return product;
        }

        public async Task<Products> DeleteProductsById(int id)
        {
            var product = GetProductsByIdsAsync(new List<int> { id } );
            var ordersProducts = _context.OrdersProducts.Where(_ => _.Product == product.FirstOrDefault())
                .ToList();

            _context.OrdersProducts.RemoveRange(ordersProducts);
            // await _context.SaveChangesAsync();
            
            var result = _context.Products.Remove(product.FirstOrDefault()).Entity;

            return result;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}