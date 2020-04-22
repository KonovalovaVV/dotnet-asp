using System;

namespace CustomModelBinder
{
    public static class GuidConverter
    {
        public static Guid Base64ToGuid(string base64)
        {
            base64 = base64.Replace("-", "/").Replace("_", "+") + "==";

            Guid guid;
            try
            {
                guid = new Guid(Convert.FromBase64String(base64));
            }
            catch (Exception)
            {
                guid = Guid.NewGuid();
            }

            return guid;
        }
    }
}
