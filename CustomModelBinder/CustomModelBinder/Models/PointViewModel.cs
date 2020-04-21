using CustomModelBinder.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CustomModelBinder.Models
{
    [ModelBinder(typeof(PointViewModelBinder))]
    public class PointViewModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public PointViewModel(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        
        public static PointViewModel Parse(string input)
        {
            var coordinates = GetIntValues(input);
            if(coordinates.Length != 3)
            {
                throw new ArgumentException("Invalid coordinate values");
            }

            return new PointViewModel(coordinates[0], coordinates[1], coordinates[2]);
        }

        private static int[] GetIntValues(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return new int[] { };
            }

            return input
                .Split(',')
                .Select(part => int.TryParse(part, out int IntValue) ? IntValue : (int?)null)
                .Where(intValue => intValue.HasValue)
                .Select(intValue => intValue.Value)
                .ToArray();
        }
    }
}
