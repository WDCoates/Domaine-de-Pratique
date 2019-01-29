using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ConsoleA1._22_Security
{
    public class Encryptions
    {
        internal CngKey aSigKey;
        internal byte[] aPubKey;

        internal CngKey bSigKey;
        internal byte[] bPubKey;

        public void CreateKeys()
        {
            aSigKey = CngKey.Create(CngAlgorithm.ECDiffieHellmanP256);
            bSigKey = CngKey.Create(CngAlgorithm.ECDiffieHellmanP256);

            aPubKey = aSigKey.Export(CngKeyBlobFormat.GenericPublicBlob);
            bPubKey = bSigKey.Export(CngKeyBlobFormat.GenericPublicBlob);

        }

        public byte[] CreateSignature(byte[] aData, CngKey aKey)
        {
            byte[] signature;
            using (var sigAlg = new ECDsaCng(aKey))
            {
                signature = sigAlg.SignData(aData);
                sigAlg.Clear();
            }

            return signature;
        }

        public bool VerifySignature(byte[] data, byte[] sigKey, byte[] pubKey)
        {
            bool res = false;

            try
            {
                using (CngKey k = CngKey.Import(pubKey, CngKeyBlobFormat.GenericPublicBlob))
                {
                    using (var sigAlg = new ECDsaCng(k))
                    {
                        res = sigAlg.VerifyData(data, sigKey);
                        sigAlg.Clear();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            return res;
        }

        public async void Start()
        {
            try
            {
                CreateKeys();
                byte[] eData = await ASendData("Secret message about high heeled boots.");

                BRecvData(eData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private async Task<byte[]> ASendData(string message)
        {
            Console.WriteLine($"ASendData: {message}");
            var rawData = Encoding.UTF8.GetBytes(message);
            byte[] encryptedData = null;

            using (var aAlgorithm = new ECDiffieHellmanCng(aSigKey))
                using(CngKey bPub = CngKey.Import(bPubKey, CngKeyBlobFormat.EccPublicBlob))
                {
                    byte[] symKey = aAlgorithm.DeriveKeyMaterial(bPub);
                    Console.WriteLine($"A creates this symmetric key with B Pub Key: {Convert.ToBase64String(symKey)}");

                    using (var aes = new AesCryptoServiceProvider())
                    {
                        aes.Key = symKey;
                        aes.GenerateIV();
                        using (ICryptoTransform enc = aes.CreateEncryptor())
                            using (MemoryStream ms = new MemoryStream())
                        {
                            //Create CryptoStream to encrypt data
                            var cs = new CryptoStream(ms, enc, CryptoStreamMode.Write);

                            //Write init vector not encrypted
                            await ms.WriteAsync(aes.IV, 0, aes.IV.Length);
                            cs.Write(rawData, 0, rawData.Length);
                            cs.Close();
                            encryptedData = ms.ToArray();
                        }
                    }

                    Console.WriteLine($"A: message is encrypted => {Convert.ToBase64String(encryptedData)}");
                    Console.WriteLine();                    
                }

            return encryptedData;
        }

        private void BRecvData(byte[] eData)
        {
            Console.WriteLine($"B receives encrypted data.");
            byte[] rawData = null;

            var aes = new AesCryptoServiceProvider();

            int nBytes = aes.BlockSize >> 3;
            byte[] iv = new byte[nBytes];
            for (int i = 0; i < iv.Length; i++)
            {
                iv[i] = eData[i];
            }

            using (var bAlg = new ECDiffieHellmanCng(bSigKey))
            using (CngKey aPKey = CngKey.Import(aPubKey, CngKeyBlobFormat.EccPublicBlob))
            {
                byte[] symKey = bAlg.DeriveKeyMaterial(aPKey);
                Console.WriteLine($"B symmetric key with A Pub Key:{Convert.ToBase64String(symKey)}");
                aes.Key = symKey;
                aes.IV = iv;

                using(ICryptoTransform decr = aes.CreateDecryptor())
                using (MemoryStream ms = new MemoryStream())
                {
                    var cs = new CryptoStream(ms, decr, CryptoStreamMode.Write);
                    cs.Write(eData, nBytes, eData.Length - nBytes);
                    cs.Close();

                    rawData = ms.ToArray();

                    Console.WriteLine($"B decrypts message to: {Encoding.UTF8.GetString(rawData)}");
                }

                aes.Clear();
            }         
        }
    }
}
