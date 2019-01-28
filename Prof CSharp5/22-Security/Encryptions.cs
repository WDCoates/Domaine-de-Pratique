using System;
using System.Collections.Generic;
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
            aPubKey = aSigKey.Export(CngKeyBlobFormat.GenericPublicBlob);
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

        private async void Start()
        {
            try
            {
                CreateKeys();
                byte[] eData = await ASendsData("Secret message.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private async Task<byte[]> ASendData(string message)
        {
            Console.WriteLine
        }
    }
}
