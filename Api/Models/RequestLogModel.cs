using System;
namespace Api.Models
{
	public class RequestLogModel
	{
		public string? Ip { get; set; }
		public DateTime Timestamp { get; set; }
		public string? Method { get; set; }
		public string? Path { get; set; }
		public int? StatusCode { get; set; }
    }
}

