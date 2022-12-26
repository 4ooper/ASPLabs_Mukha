﻿using BuildingContractor.Application.Interfaces;
using BuildingContractor.Persistence;
using System.Text;
using System.Text.Json;
using MediatR;
using Microsoft.EntityFrameworkCore;
using BuildingContractor.Domain.JWT;

namespace BuildingContractor.WebAPI.Midlewares
{
    public class AuthMidleware
    {
        private readonly RequestDelegate _next;

        public AuthMidleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IHost host, AppDbContext appDbContext)
        {
            context.Request.Headers.TryGetValue("authorization", out var tokenValues);
            var token = tokenValues.ToString();

            if (token.Length != 0)
            {
                string[] tokenParts = token.Split(".");
                var header = JsonSerializer.Deserialize<Header>(Encoding.UTF8.GetString(Convert.FromBase64String(tokenParts[0])));
                var payload = JsonSerializer.Deserialize<Payload>(Encoding.UTF8.GetString(Convert.FromBase64String(tokenParts[1])));
                var signature = JsonSerializer.Deserialize<Signature>(Encoding.UTF8.GetString(Convert.FromBase64String(tokenParts[2])));
                if (signature.key != "I love C Sharp" || ConvertInt32ToDateTime(payload.exp) < DateTime.Now || signature == null || payload == null)
                {
                    context.Items["User"] = null;
                }
                else
                {
                    context.Items["User"] = appDbContext.Users.Include(user => user.Role).FirstOrDefault(user => user.id == payload.id);
                }
            }
            await _next.Invoke(context);
        }

        private DateTime ConvertInt32ToDateTime(int i)
        {
            return new DateTime(2017, 1, 1).AddSeconds(i);
        }
    }
}