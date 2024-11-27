using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

public static class HashKeyManager
{
    private static readonly string HashFilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\hashes.txt"; // Path to the file

    // Load all hash keys from the file
    public static List<string> LoadHashKeys()
    {
        if (!File.Exists(HashFilePath))
        {

            File.WriteAllText(HashFilePath, string.Empty); 

        }
        

        return File.ReadAllLines(HashFilePath).Where(line => !string.IsNullOrWhiteSpace(line)).ToList();
    }

    // Validate and remove a hash key
    public static bool ValidateAndRemoveHashKey(string hashKey)
    {
        var hashKeys = LoadHashKeys();
        //string a = "";
        //foreach (var key in hashKeys) { 
        //    a+= key;
        //}
        //MessageBox.Show(HashFilePath, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //Console.WriteLine(hashKeys);

        if (hashKeys.Contains(hashKey))
        {
            hashKeys.Remove(hashKey); 
            File.WriteAllLines(HashFilePath, hashKeys); 
            return true;
        }

        return false; 
    }
}
