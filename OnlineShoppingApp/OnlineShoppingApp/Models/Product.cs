using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required(ErrorMessage = "Product Name Requried")]
        [StringLength(20, ErrorMessage = "Product Name Cannot be longer than 20 character")]
        [BsonElement("ProductName")]
        public string ProductName { get; set; }

        [BsonElement("ProductDesription")]
        [StringLength(50, ErrorMessage = "Product Desription Cannot be longer than 50 character")]
        public string ProductDesription { get; set; }

        [BsonElement("Price")]
        [Required(ErrorMessage = "Product Price Requried")]
        public int Price { get; set; }


        [BsonElement("Features")]
        public string Features { get; set; }

        [BsonElement("ProductStatus")]
        public string ProductStatus { get; set; }

        [BsonElement("ProductId")]
        public int ProductId { get; set; }

    }
}