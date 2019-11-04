﻿namespace Shoop.Web.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;

    public class SeedDb
    {
        private readonly DataContext _context;
        private Random random;

        public SeedDb(DataContext context)
        {
            this._context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this._context.Database.EnsureCreatedAsync();

            if (!this._context.Products.Any())
            {
                this.AddProduct("iPhone X");
                this.AddProduct("Magic Mouse");
                this.AddProduct("iWatch Series 4");

                await this._context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name)
        {
            this._context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(100),
                IsAvaliable = true,
                Stock = this.random.Next(100)
            });
        }
    }
}