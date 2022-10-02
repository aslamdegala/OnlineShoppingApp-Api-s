using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }

        [Required(ErrorMessage = "First Name Requried")]
        [BsonElement("FirstName")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Last Name Requried")]
        [BsonElement("LastName")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Email Address Requried")]
        [BsonElement("Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "UserName Requried")]
        [BsonElement("UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Requried")]
        [BsonElement("Password")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Contact Number Requried")]
        [StringLength(10)]
        [BsonElement("ContactNo")]
        public string ContactNo { get; set; }
    }
}