﻿namespace ITLab2.DTO
{
    public class DatabaseDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class CreateDatabaseDTO
    {
        public string? Name { get; set; }
    }
}