
//using System;
//using System.Collections.Generic;

//public static class HashKeyList
//{
    
//    private static List<string> validHashKeys = new List<string>
//    {
//        "12345",    
//        "abcde",    
//        "67890"     
//    };

   
//    public static List<string> GetHashKeys()
//    {
//        return new List<string>(validHashKeys); 
//    }

    
//    public static bool ValidateAndRemoveHashKey(string hashKey)
//    {
//        if (validHashKeys.Contains(hashKey))
//        {
//            validHashKeys.Remove(hashKey);  
//            return true;
//        }
//        return false;
//    }

    
//    public static int GetRemainingHashKeyCount()
//    {
//        return validHashKeys.Count;
//    }
//}
