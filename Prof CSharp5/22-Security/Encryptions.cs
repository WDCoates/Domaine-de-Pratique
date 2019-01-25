using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace ConsoleA1._22_Security
{
    public class Encryptions
    {
        internal CngKey aSigKey;
        internal byte[] aPubKey;

        public void CreateKeys()
        {
            aSigKey = CngKey.Create(CngAlgorithm.ECDiffieHellmanP256);
            aPubKey = aSigKey.Export(CngKeyBlobFormat.GenericPublicBlob);
        }
    }
}
