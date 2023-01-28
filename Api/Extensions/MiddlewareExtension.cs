using System;
using Api.Middlewares;

namespace Api.Extensions
{
	public static class MiddlewareExtension
	{
		public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder applicationBuilder)
		{
			return applicationBuilder.UseMiddleware<RequestLoggingMiddleware>();
		}
	}
}

