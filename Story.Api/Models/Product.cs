using Store.Api.Models;
using System.ComponentModel;

namespace Store.Api.Models
{
    public class Product
    {
        public long Id { get; set; }   
        public string Name { get; set; }
        public string SKU { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public int StockQuantity { get; set; }
        public string Unit { get; set; } = null;  //kg,dona a
        public string? Barcode { get; set; } = null;
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public DateTime UpdatedAt { get; set; }=DateTime.Now;


        public long CategoryId { get; set; }
        public Category Category { get; set; } = null;



    }
    }

