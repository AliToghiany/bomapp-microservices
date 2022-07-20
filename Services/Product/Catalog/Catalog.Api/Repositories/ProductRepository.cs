using Catalog.Api.DB;
using Catalog.Api.Entities;
using Catalog.Api.Repositories.Interface;
using Catalog.Api.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _dbContext;
        public ProductRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResultDto<long>> CreateProduct(Product product,List<IFormFile> Upload)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(product.Name))
                {
                    return new ResultDto<long>
                    {
                        IsSucsses = false,
                        Message = "Plase Enter Product Name"

                    };
                }
                if (string.IsNullOrWhiteSpace(product.Description))
                {
                    return new ResultDto<long>
                    {
                        IsSucsses = false,
                        Message = "Plase Enter Product Dsecription"

                    };
                }
                await _dbContext.Products.AddAsync(product);
                await _dbContext.SaveChangesAsync();
                List<Image> image = new List<Image>();
                foreach (var item in Upload)
                {
                    //upload
                    image.Add(new Image
                    {
                        ProductId = product.Id,

                    });
                }
                await _dbContext.Images.AddRangeAsync(image);
                await _dbContext.SaveChangesAsync();
                return new ResultDto<long>
                {
                    IsSucsses = true,
                    Message = "Product has been added sucsseful",
                    Data=product.Id
                };
            }
            catch(Exception ex)
            {
                return new ResultDto<long>
                {
                    IsSucsses = false,
                    Message = $"Error:{ex}"
                };
            }
        }

        public async Task<ResultDto> DeleteProduct(long id)
        {
            try
            {
                var product = await _dbContext.Products.FindAsync(id);
                product.IsRemoved = true;
           
                await _dbContext.SaveChangesAsync();
                return new ResultDto
                {
                    IsSucsses = true,
                    Message = "Product has been deleted sucsseful",
                
                };
            }
            catch (Exception ex)
            {
                return new ResultDto
                {
                    IsSucsses = false,
                    Message = $"Error:{ex}"
                };
            }
        }

        public async Task<Product> GetProduct(long id)
        {
            return await _dbContext.Products.FindAsync(id);
        }




        public ProductListResult GetProducts(Ordering ordering, string SearchKey, int PageSize, int Page, long? Catid)
        {
            int totalRow = 0;
            var productquery = _dbContext.Products.Include(p => p.Category).AsQueryable();
            if (Catid != null)
            {
                productquery = productquery.Where(p => p.CategoryId == Catid);
            }

            if (!string.IsNullOrWhiteSpace(SearchKey))
            {
                productquery = productquery.Where(p => p.Name.Contains(SearchKey) || p.Description.Contains(SearchKey)).AsQueryable();
            }

            switch (ordering)
            {

                case Ordering.Cheapset:
                    productquery = productquery.OrderBy(p => p.Price).AsQueryable();
                    break;
                case Ordering.Expensive:
                    productquery = productquery.OrderByDescending(p => p.Price).AsQueryable();
                    break;
                case Ordering.theNewest:
                    productquery = productquery.OrderByDescending(p => p.CreatedDate).AsQueryable();
                    break;
                case Ordering.theoldest:
                    productquery = productquery.OrderBy(p => p.CreatedDate).AsQueryable();
                    break;

                case Ordering.NotOrder:
                    productquery = productquery.OrderByDescending(p => p.Id).AsQueryable();
                    break;
            }
            var products = productquery.ToPaged(Page, PageSize, out totalRow);
            return new ProductListResult
            {
                Products = products.ToList(),
                Row = totalRow
            };


        }

        public async Task<ResultDto<long>> UpdateProduct(Product product, List<IFormFile> Upload)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(product.Name))
                {
                    return new ResultDto<long>
                    {
                        IsSucsses = false,
                        Message = "Plase Enter Product Name"

                    };
                }
                if (string.IsNullOrWhiteSpace(product.Description))
                {
                    return new ResultDto<long>
                    {
                        IsSucsses = false,
                        Message = "Plase Enter Product Dsecription"

                    };
                }
                var pr = await _dbContext.Products.FindAsync(product.Id);
                pr.Name = product.Name;
                pr.Price = product.Price;
                pr.Summary = pr.Summary;
                pr.CategoryId = pr.CategoryId;
                pr.Description = pr.Description;
                List<Image> image = new List<Image>();
                foreach (var item in Upload)
                {
                    //upload
                    image.Add(new Image
                    {
                        ProductId = product.Id,

                    });
                }
                await _dbContext.Images.AddRangeAsync(image);
                await _dbContext.SaveChangesAsync();
                await _dbContext.SaveChangesAsync();
                return new ResultDto<long>
                {
                    IsSucsses = true,
                    Message = "Product has been added sucsseful",
                    Data = product.Id
                };
            }
            catch (Exception ex)
            {
                return new ResultDto<long>
                {
                    IsSucsses = false,
                    Message = $"Error:{ex}"
                };
            }
        }
    }
    public class ProductListResult
    {
        public List<Product> Products { get; set; }
        public int Row { get; set; }
    }
    public enum Ordering
    {
        NotOrder,
        Cheapset,
        Expensive,
        theNewest,
        theoldest

    }
}

