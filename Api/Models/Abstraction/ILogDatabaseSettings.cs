using System;
namespace Api.Models.Abstraction
{
	public interface ILogDatabaseSettings
	{
        string ConnectionString { get; set; }

        string DatabaseName { get; set; }

        string CollectionName { get; set; }
    }
}

