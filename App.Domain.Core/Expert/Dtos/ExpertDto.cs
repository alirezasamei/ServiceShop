﻿namespace App.Domain.Core.Expert.Dtos
{
    public class ExpertDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Mobile { get; set; }
        public string Email { get; set; }
        public string? ImageName { get; set; }
        public string? Address { get; set; }
        public DateTime SubmitDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}