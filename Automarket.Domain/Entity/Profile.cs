﻿namespace Automarket.Domain.Entity
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