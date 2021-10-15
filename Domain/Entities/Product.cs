using System;
using Domain.Enums;

namespace Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ProductType Type { get; set; }
        public double Price { get; set; }
        public ProductColor Color { get; set; }
        
    }
}