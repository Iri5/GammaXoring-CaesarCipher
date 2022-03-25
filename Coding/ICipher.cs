namespace Coding
{
    interface ICipher
    {
        public string Encode(string openData, string key);
        public string Decode(string encryptedData, string key);
    }
}
