using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coding;
using System;

namespace CodingTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GammaXoringEncodingTest()
        {
            string openText = "It is dencoding string! GammaXoring!";

            string expectedEncriptedText = "1F-3F-56-5A-2A-16-1E-38-29-09-33-56-2F-26-5A" +
                                    "-46-3E-05-15-50-40-15-41-1C-7B-26-25-2D-40-30-47-29-11-0B-5A-7C";

            string key = "VKv3Y6z]Gj\\2FH=fMqg9.r`<<GH@!h([xe=]";

            GammaXoring gammaXoring = new GammaXoring();
            string resultEncriptedText = gammaXoring.Encode(openText, key);

            Assert.AreEqual(expectedEncriptedText, resultEncriptedText);
        }

        [TestMethod]
        public void GammaXoringDecodingTest()
        {
            string expectedOpenText = "It is decoding string! GammaXoring!";

            string encriptedText = "2D-1A-01-24-03-4A-17-38-31-23-50-1E-24-1D-4D-" +
                                    "32-51-30-46-1E-0D-03-54-1C-5C-42-16-42-3D-41-12-55-0A-09-00";

            string key = "dn!Mpjs]RL4wJzmA%B/pj\"t[=/{#e.`<";

            GammaXoring gammaXoring = new GammaXoring();
            string resultDecriptedText = gammaXoring.Decode(encriptedText, key);

            Assert.AreEqual(expectedOpenText, resultDecriptedText);
        }

        [TestMethod]
        public void CaesarCipherCodingTest()
        {
            string openText = "It is decoding string! Ceaser Cipher!";

            string expectedEncriptedText = "4E-79-25-6E-78-25-69-6A-68-74-69-6E-73-6C-25-78-79-77-6E-73-" +
                                    "6C-26-25-48-6A-66-78-6A-77-25-48-6E-75-6D-6A-77-26";

            string key = "5";

            ÑaesarsÑipher caesarsÑipher = new ÑaesarsÑipher();
            string resultDecriptedText = caesarsÑipher.Encode(openText, key);

            Assert.AreEqual(expectedEncriptedText, resultDecriptedText);
        }
        [TestMethod]
        public void CaesarCipherDecodingTest()
        {
            string expectedOpenText = "It is decoding string! Ceaser Cipher!";

            string encriptedText = "4E-79-25-6E-78-25-69-6A-68-74-69-6E-73-6C-25-78-" +
                                    "79-77-6E-73-6C-26-25-48-6A-66-78-6A-77-25-48-6E-75-6D-6A-77-26";

            string key = "5";

            ÑaesarsÑipher caesarsÑipher = new ÑaesarsÑipher();
            string resultDecriptedText = caesarsÑipher.Decode(encriptedText, key);

            Assert.AreEqual(expectedOpenText, resultDecriptedText);
        }
    }
}

