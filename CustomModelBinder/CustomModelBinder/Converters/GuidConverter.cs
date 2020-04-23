using System;

namespace CustomModelBinder.Converters
{
    public static class GuidConverter
    {
        public static bool TryConvertBase64ToGuid(string base64, out Guid guid)
        {
            try
            {
                var normalizedBase64 = base64
                    .Replace("-", "/")
                    .Replace("_", "+");

                guid = new Guid(Convert.FromBase64String(normalizedBase64 + "=="));

                return true;
            }
            catch (Exception)
            {
                guid = Guid.Empty;

                return false;
            }
        }
    }
}
