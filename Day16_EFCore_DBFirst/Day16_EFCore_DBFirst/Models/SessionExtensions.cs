﻿
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Day16_EFCore_DBFirst.Models
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value != null ? JsonSerializer.Deserialize<T>(value) : default(T);
        }
    }
}
