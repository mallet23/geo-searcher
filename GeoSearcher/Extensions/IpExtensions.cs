﻿using System;
using System.Linq;

namespace GeoSearcher.Extensions
{
    public static class IpExtensions
    {
        public static uint ConvertIpToInt(this string ip)
        {
            var numbers = ip.Split('.')
                .Select(x => byte.TryParse(x, out var num)
                    ? num
                    : throw new ArgumentException(nameof(ip)))
                .ToArray();

            if (numbers.Length != 4)
            {
                throw new ArgumentException(nameof(ip));
            }

            return BitConverter.ToUInt32(numbers, 0);
        }
    }
}
