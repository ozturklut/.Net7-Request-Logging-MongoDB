using System;
using Api.Models.Abstraction;

namespace Api.Models
{
    public class LogDatabaseSettings : ILogDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get ; set ; } = null!;
        public string CollectionName { get ; set ; } = null!;
    }
}

