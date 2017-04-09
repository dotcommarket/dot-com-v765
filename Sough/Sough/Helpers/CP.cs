using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Sough.Helpers
{
    public class CP
    {
        public static byte[] Crypt(string text, byte[] key, byte[] iv)
        {
            byte[] textAsByte = Encoding.Default.GetBytes(text);

            TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();

            // Cet objet est utilisé pour chiffrer les données.
            // Il reçoit en entrée les données en clair sous la forme d'un tableau de bytes.
            // Les données chiffrées sont également retournées sous la forme d'un tableau de bytes
            var encryptor = TDES.CreateEncryptor(key, iv);

            byte[] cryptedTextAsByte = encryptor.TransformFinalBlock(textAsByte, 0, textAsByte.Length);

            return cryptedTextAsByte;
        }

        public static string Decryp(byte[] cryptedTextAsByte, byte[] key, byte[] iv)
        {
            TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();

            // Cet objet est utilisé pour déchiffrer les données.
            // Il reçoit les données chiffrées sous la forme d'un tableau de bytes.
            // Les données déchiffrées sont également retournées sous la forme d'un tableau de bytes
            var decryptor = TDES.CreateDecryptor(key, iv);

            byte[] decryptedTextAsByte = decryptor.TransformFinalBlock(cryptedTextAsByte, 0, cryptedTextAsByte.Length);

            return Encoding.Default.GetString(decryptedTextAsByte);
        }
    }
}