using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

public static class HashKeyManager
{
    ////private static readonly string HashFilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\binaries.txt"; // Path to the file
    //private static readonly string HashFilePath = Path.Combine(AppContext.BaseDirectory, "binaries.txt");

    //// Load all hash keys from the file
    //public static List<string> LoadHashKeys()
    //{
    //    if (!File.Exists(HashFilePath))
    //    {

    //        File.WriteAllText(HashFilePath, string.Empty); 

    //    }
        

    //    return File.ReadAllLines(HashFilePath).Where(line => !string.IsNullOrWhiteSpace(line)).ToList();
    //}
    //public static string UnshiftHash(string input)
    //{
    //    return new string(input.Select(c => (char)(c - 14)).ToArray());
    //}

    //// Validate and remove a hash key
    //public static bool ValidateAndRemoveHashKey(string hashKey)
    //{
    //    var hashKeys = LoadHashKeys();
    //    //string a = "";
    //    //foreach (var key in hashKeys)
    //    //{
    //    //    a += key;
    //    //}
    //    //MessageBox.Show(HashFilePath, a , MessageBoxButtons.OK, MessageBoxIcon.Information);
    //    //Console.WriteLine(hashKeys);
    //    hashKey = UnshiftHash(hashKey);
    //    if (hashKeys.Contains(hashKey))
    //    {
    //        hashKeys.Remove(hashKey); 
    //        File.WriteAllLines(HashFilePath, hashKeys); 
    //        return true;
    //    }

    //    return false; 
    //}

}
