﻿using Umfrage.Model;

namespace Umfrage.DTO
{
    public class UserDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Schoolclass { get; set; }
        public Role role{ get; set; }
    }
}
