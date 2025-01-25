using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using Dapper;
using Microsoft.Data.Sqlite;
using SqlKata;
using WingtipToys.Builder.Extension;
using WingtipToys.Builder.Services;
using WingtipToys.Models;

namespace WingtipToys.Repository
{
    public interface IProductRepository
    {
        Task AddProduct(Product product);
        Task DeleteProduct(int id);
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> GetProducts();
        Task UpdateProduct(Product product);
    }

    public class ProductRepository : IProductRepository
    {
        private ISqliteConnectionProvider _conn { get; set; }

        private async Task _createConnection(Func<SqliteConnection, Task> connection)
        {
            using (var conn = _conn.CreateConnection())
            {
                await connection(conn);
            }
        }

        public ProductRepository()
        {
            _conn =
                Global._containerProvider.ApplicationContainer.Resolve<ISqliteConnectionProvider>();
        }

        public async Task AddProduct(Product product)
        {
            await _createConnection(async conn =>
            {
                await conn.InsertToDatabase(product, true);
            });
        }

        public async Task DeleteProduct(int id)
        {
            var DeleteProduct_Query = new Query(nameof(Product))
                .Where(nameof(Product.Id), id)
                .AsDelete();

            await _createConnection(async conn =>
            {
                await conn.ExecuteSqlKataAsync(DeleteProduct_Query);
            });
        }

        public async Task<Product> GetProductById(int id)
        {
            Product product = null;
            var GetProductById_Query = new Query(nameof(Product)).Where(nameof(Product.Id), id);
            await _createConnection(async conn =>
            {
                product = await conn.QuerySingleSqlKataAsync<Product>(GetProductById_Query);
            });

            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            IEnumerable<Product> products = null;
            var GetProducts_Query = new Query(nameof(Product));

            await _createConnection(async conn =>
            {
                products = (await conn.QuerySqlKataAsync<Product>(GetProducts_Query));
            });
            return products;
        }

        public async Task UpdateProduct(Product product)
        {
            var UpdateProduct_Query = new Query(nameof(Product))
                .Where(nameof(Product.Id), product.Id)
                .AsUpdate(product);

            await _createConnection(async conn =>
            {
                await conn.ExecuteSqlKataAsync(UpdateProduct_Query);
            });
        }
    }
}
