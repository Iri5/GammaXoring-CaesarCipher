namespace Coding
{
    interface ICipher
    {
        public string Encode(string openData, string key);
        public string Decode(string encryptedData, string key);
        public bool DecodeString(string text);
        public bool EncodeString(string text);
        public bool Key(string key);

    }
}
