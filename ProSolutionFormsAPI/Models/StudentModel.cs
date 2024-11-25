﻿using System.ComponentModel.DataAnnotations;

namespace ProSolutionFormsAPI.Models
{
    public class StudentModel
    {
        [Key]
        public int StudentID { get; set; }
        public int? StudentDetailID { get; set; }
        public string? StudentRef { get; set; }
        public string? Surname { get; set; }
        public string? Forename { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Guid? StudentGUID { get; set; }
    }
}
