using System;
using System.IO;
using System.Security.Cryptography;
using static RawXmlLauncherGenerator.Hash.FileHash;

namespace RawXmlLauncherGenerator.Hash
{
    public static class FolderHash
    {
        public static string CheckHashDir(string a) // Full localized
        {
            if (!Directory.Exists(a))
                throw new DirectoryNotFoundException(nameof(a));

            if (Directory.GetFiles(a).Length == 0)
                return "noHash";

            var dir = new DirectoryInfo(a);
            var files = dir.GetFiles();
            var mRipemd160 = MD5.Create();

            foreach (FileInfo fileInfo in files)
            {
                FileStream fileStream = fileInfo.Open(FileMode.Open);
                fileStream.Position = 0;
                byte[] hashValue = mRipemd160.ComputeHash(fileStream);

                StreamWriter sw;
                using (sw = File.AppendText(a + @"\tempHash.txt"))
                {
                    sw.WriteLine(BitConverter.ToString(hashValue).Replace("-", "").ToLower());
                    fileStream.Close();
                }
                sw.Close();
            }
            File.Copy(a + @"\tempHash.txt", a + @"\Hash.txt", true);
            File.Delete(a + @"\tempHash.txt");
            var hash =  CheckHashFile(a + @"\Hash.txt");
            File.Delete(a + @"\Hash.txt");
            return hash;
        }
    }
}
