using System;
using System.IO;
using System.Security.Cryptography;

namespace RawXmlLauncherGenerator.Hash
{
    public static class FileHash
    {
        public static string CheckHashFile(string a) // Full localized
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            FileStream fileReader = File.OpenRead(a);
            byte[] md5Hash = md5.ComputeHash(fileReader);
            string Berechnet = BitConverter.ToString(md5Hash).Replace("-", "").ToLower();
            //MessageBox.Show(Berechnet);
            fileReader.Close();
            return Berechnet;
        }
    }
}
