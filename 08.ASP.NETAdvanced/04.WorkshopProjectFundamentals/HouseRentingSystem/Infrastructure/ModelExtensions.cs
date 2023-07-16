﻿using HouseRentingSystem.Contracts;
using System.Text.RegularExpressions;

namespace HouseRentingSystem.Infrastructure
{
    public static class ModelExtensions
    {
        public static string Getinformation(this IHouseModel house)
        {
            return house.Title.Replace(" ", "-") + "-" + GetAddress(house.Address);
        }

        private static string GetAddress(string address)
        {
            address = string.Join("-", address.Split(" ").Take(3));
            return Regex.Replace(address, @"[^a-zA-Z0-9\-]", string.Empty);
        }
    }
}
