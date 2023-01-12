using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Automarket.Domain.Entity
{
    public class Profile
    {
        public long Id { get; set; }
        public byte Age { get; set; }
        
        public string Address { get; set; }
        
        public long UserId { get; set; }
        
        public User User { get; set; }
    }
}