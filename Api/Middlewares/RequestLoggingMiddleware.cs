using System;
using System.Net;
using Api.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Api.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMongoCollection<RequestLogModel> _collection;

        public RequestLoggingMiddleware(RequestDelegate next, IOptions<LogDatabaseSettings> logDatabaseSettings)
        {
            _next = next;

            var mongoClient = new MongoClient(logDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(logDatabaseSettings.Value.DatabaseName);
            _collection = mongoDatabase.GetCollection<RequestLogModel>(logDatabaseSettings.Value.CollectionName);
        }

        public async Task InvokeAsync(HttpContext context)
        {
            RequestLogModel requestLog = new()
            {
                Ip = context.Connection.RemoteIpAddress?.ToString(),
                Method = context.Request?.Method,
                Path = context.Request?.Path.Value,
                StatusCode = context.Response?.StatusCode,
                Timestamp = DateTime.UtcNow
            };
            
            await _collection.InsertOneAsync(requestLog);
            await _next(context);
        }
    }
}

