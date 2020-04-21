using System;
using System.IO;
using System.Text.Json;

namespace CustomModelBinder.Models
{
    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
        
        public static Point Parse(string input)
        {
            string[] values = input.Split(',');
            Point result = new Point();
            try
            {
                result.x = int.Parse(values[0]);
            }
            catch (Exception)
            {
                result.x = 0;
            }
            try
            {
                result.y = int.Parse(values[1]);
            }
            catch (Exception)
            {
                result.y = 0;
            }
            try
            {
                result.z = int.Parse(values[2]);
            }
            catch (Exception)
            {
                result.z = 0;
            }
            return result;
        }

        public async void Serialize()
        {
            using (FileStream fs  = new FileStream("Points.json", FileMode.Append))
            {
                await JsonSerializer.SerializeAsync<Point>(fs, this);
            }
        }
    }
}
