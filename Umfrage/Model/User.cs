﻿using System.Text.Json.Serialization;

namespace Umfrage.Model
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Schoolclass { get; set; }
        public Role role{ get; set; }
        [JsonIgnore]
        public ICollection<UserQuestions>? UserQuestions{ get; set; }
    }
}
