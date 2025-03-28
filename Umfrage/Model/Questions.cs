﻿using System.Text.Json.Serialization;

namespace Umfrage.Model
{
    public class Questions
    {
        public int Id { get; set; }
        public string? Question { get; set; }
        public string? AnswerOne { get; set; }
        public string? AnswerTwo { get; set; }
        public string? AnswerThree { get; set; }
        public string? AnswerFour { get; set; }
        public string? SelectedClass { get; set; }
        [JsonIgnore]

        public ICollection<UserQuestions>? UserQuestions{ get; set; }
    }
}
