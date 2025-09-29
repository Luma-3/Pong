namespace Manager.Data
{
    public static class DataEncryptor
    {
        private const string Key = "N0Úy~:1rl[H4QGtIq<9¹[9Ëp1v±08(oz36¢R0Ov+MG70E¢~fÆ7éG_J#iKll9{á&";

        public static string Encryptor(string data)
        {
            var dataOut = "";
            
            for (var i = 0; i < data.Length; i++)
            {
                dataOut += (char)(data[i] ^ Key[i % Key.Length]);
            }
            
            return dataOut;
        }
    }
}