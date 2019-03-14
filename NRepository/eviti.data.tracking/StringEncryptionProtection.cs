using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace eviti.data.tracking
{
    public class StringEncryptionProtection
    {

        // Public Const EncryptionPassword As String = "Eviti6357Two"
        //  Public Const EncryptionPassword As String = "My Password"
        public const string DefaultEncryptionPassword = "ZYddHJykoQd1asdf85151DefaultDD88YSSssdf";


        public static string EncryptData(string ToEncrypt)
        {
            return EncryptData(ToEncrypt, DefaultEncryptionPassword);
        }


        public static string DecryptData(string ToDecrypt)
        {

            return DecryptData(ToDecrypt, DefaultEncryptionPassword);

        }

        public static string EncryptData(string plainText, string EncryptionPassword)
        {
            if (plainText == null)
            {
                throw new ArgumentNullException("plainText", "Parameter must have a value to be encrypted.");
            }

            return AesPasswordBasedEncryption.EncryptWithIVEmbeded(plainText, EncryptionPassword);
            //ITA.IQ.Common.Encryption.Symmetric sym = new ITA.IQ.Common.Encryption.Symmetric(ITA.IQ.Common.Encryption.Symmetric.Provider.Rijndael);
            //ITA.IQ.Common.Encryption.Data key = new ITA.IQ.Common.Encryption.Data(EncryptionPassword);
            //ITA.IQ.Common.Encryption.Data encryptedData;
            //encryptedData = sym.Encrypt(new ITA.IQ.Common.Encryption.Data(ToEncrypt), key);
            //string base64EncryptedString = encryptedData.ToBase64();

            //return base64EncryptedString;
        }


        public static string DecryptData(string encryptedValue, string EncryptionPassword)
        {
            if (encryptedValue == null)
            {
                throw new ArgumentNullException("encryptedValue", "Parameter must have a value to be decrypted.");
            }

            return AesPasswordBasedEncryption.DecryptWithIVEmbeded(encryptedValue, EncryptionPassword);


            //ITA.IQ.Common.Encryption.Symmetric sym = new ITA.IQ.Common.Encryption.Symmetric(ITA.IQ.Common.Encryption.Symmetric.Provider.Rijndael);
            //ITA.IQ.Common.Encryption.Data key = new ITA.IQ.Common.Encryption.Data(EncryptionPassword);
            //ITA.IQ.Common.Encryption.Data encryptedData = new ITA.IQ.Common.Encryption.Data();
            //encryptedData.Base64 = ToDecrypt;
            //ITA.IQ.Common.Encryption.Data decryptedData;
            //decryptedData = sym.Decrypt(encryptedData, key);

            //return decryptedData.ToString();
        }

    }



    /// <summary>
    /// 
    /// From what I can tell this should be fairly secure.  Search for "Password Based .net Encryption"

    ///The IV can be stored with the encrypted string safely.  It is just a random bit of info to jump start the CBC encryption chain.

    ///The key needs to be 32 bytes in length or 256 bits.In order to generate this, I am using a password hash with a salt.This is just so the password does not have to be exactly 32 characters in length and can be a random length.The GetKeyAndIVFromPasswordAndSalt just takes the first 32 characters.I am not using the IV from the method and will use the random IV generated from the AES algorithm.This will be stored with the encrypted data at the beginning of the byte array before encoding.

    ///https://gist.github.com/mark-adams/87aa34da3a5ed48ed0c7 
    ///https://stephenhaunts.com/2013/03/04/cryptography-in-net-advanced-encryption-standard-aes/
    ///https://www.troyhunt.com/owasp-top-10-for-net-developers-part-7/ 
    ///https://github.com/stanac/EasyCrypto 

    /// </summary>
    public class AesPasswordBasedEncryption
    {
        public static string original = "Here is some data to encrypt! Here is some data to encrypt! Here is some data to encrypt! Here is some data to encrypt! Here is some data to encrypt!";

        public static string Password = "xye3RasdfjJrYzz";
        public static string PasswordSalt = "SaltMustBe8Bytes";
        public static byte[] key;


        public static Dictionary<string, byte[]> keylookup = new Dictionary<string, byte[]>();
        static AesPasswordBasedEncryption()
        {

            var saltBytes = Encoding.Default.GetBytes(PasswordSalt);
            var algorithim = Aes.Create();

            var iv2 = new byte[1];
            GetKeyAndIVFromPasswordAndSalt(Password, saltBytes, algorithim, ref key, ref iv2);
        }
        public void Test()
        {
            var saltBytesold = Encoding.Default.GetBytes("MySalt");
            var saltBytes = Encoding.Default.GetBytes(PasswordSalt);

            var key = new byte[1];
            var iv = new byte[1];
            GetKeyAndIVFromPasswordAndSalt(Password, saltBytes, ref key, ref iv);

            var algorithim = Aes.Create();
            var key2 = new byte[1];
            var iv2 = new byte[1];
            GetKeyAndIVFromPasswordAndSalt(Password, saltBytes, algorithim, ref key2, ref iv2);



            string encryptedValue1 = EncryptWithIVEmbeded(original, key);
            string decryptedValue1 = DecryptWithIVEmbeded(encryptedValue1, key);

            string t = string.Empty;
        }

        public void TestOLD()
        {
            string salt = CreateSalt(16);
            string password = "MyPassword";
            var key = new byte[16];
            var iv = new byte[16];
            var saltBytes = Encoding.Default.GetBytes(salt);

            GetKeyAndIVFromPasswordAndSalt(password, saltBytes, ref key, ref iv);

            var key2 = new byte[16];
            var iv2 = new byte[16];
            GetKeyAndIVFromPasswordAndSalt(password, saltBytes, ref key2, ref iv2);

            string encryptedValue1 = EncryptWithIVEmbeded(AesPasswordBasedEncryption.original, key);
            string decryptedValue1 = DecryptWithIVEmbeded(encryptedValue1, key);
            string t = string.Empty;

        }

        // this is only needed to create a random string for the configuration. 
        public string CreateSalt(int size)
        {

            var rng = new RNGCryptoServiceProvider();

            var buff = new byte[size];

            rng.GetBytes(buff);

            return Convert.ToBase64String(buff);

        }





        public static string EncryptWithIVEmbeded(string plainText, string password)
        {
            //throw new ApplicationException("finish and test");
            byte[] myKey = GetKey(password);
            return EncryptWithIVEmbeded(plainText, myKey);
        }

        public static string DecryptWithIVEmbeded(string encryptedValue, string password)
        {
            //throw new ApplicationException("finish and test");
            byte[] myKey = GetKey(password);
            return DecryptWithIVEmbeded(encryptedValue, myKey);
        }


        public static string EncryptWithIVEmbededSelfPassword(string plainText)
        {
            return EncryptWithIVEmbeded(plainText, key);
        }

        public static string DecryptWithIVEmbededSelfPassword(string encryptedValue)
        {
            return DecryptWithIVEmbeded(encryptedValue, key);
        }
        private static string EncryptWithIVEmbeded(string plainText, byte[] Key)
        {
            byte[] encrypted;
            byte[] IV;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;

                aesAlg.GenerateIV();
                IV = aesAlg.IV;

                aesAlg.Mode = CipherMode.CBC;

                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption. 
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            // add the IV to the encrpted data, this is safe
            var combinedIvCt = new byte[IV.Length + encrypted.Length];
            Array.Copy(IV, 0, combinedIvCt, 0, IV.Length);
            Array.Copy(encrypted, 0, combinedIvCt, IV.Length, encrypted.Length);

            // Return the encrypted bytes from the memory stream as base 64 encoded.
            return Convert.ToBase64String(combinedIvCt);


        }

        private static string DecryptWithIVEmbeded(string encryptedValue, byte[] Key)
        {


            byte[] cipherTextCombined = Convert.FromBase64String(encryptedValue);

            // Declare the string used to hold 
            // the decrypted text. 
            string plaintext = null;

            // Create an Aes object 
            // with the specified key and IV. 
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;

                byte[] IV = new byte[aesAlg.BlockSize / 8];
                byte[] cipherText = new byte[cipherTextCombined.Length - IV.Length];

                Array.Copy(cipherTextCombined, IV, IV.Length);
                Array.Copy(cipherTextCombined, IV.Length, cipherText, 0, cipherText.Length);

                aesAlg.IV = IV;

                aesAlg.Mode = CipherMode.CBC;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption. 
                using (var msDecrypt = new MemoryStream(cipherText))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }



        private static byte[] GetKey(string password)
        {
            byte[] key = null;
            byte[] IVNotUsed = null;

            if (keylookup.TryGetValue(password, out key) == false)
            {
                var saltBytes = Encoding.Default.GetBytes(PasswordSalt);
                var algorithim = Aes.Create();
                GetKeyAndIVFromPasswordAndSalt(Password, saltBytes, algorithim, ref key, ref IVNotUsed);

                keylookup.Add(password, key);

            }

            return key;

        }


        private static void GetKeyAndIVFromPasswordAndSalt(string password, byte[] salt,
           ref byte[] key, ref byte[] iv)
        {
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt);
            key = rfc2898DeriveBytes.GetBytes(32);
            iv = rfc2898DeriveBytes.GetBytes(16);
        }
        private static void GetKeyAndIVFromPasswordAndSalt(string password, byte[] salt,
           SymmetricAlgorithm symmetricAlgorithm, ref byte[] key, ref byte[] iv)
        {
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt);
            key = rfc2898DeriveBytes.GetBytes(symmetricAlgorithm.KeySize / 8);
            iv = rfc2898DeriveBytes.GetBytes(symmetricAlgorithm.BlockSize / 8);

        }

    }
     
}
