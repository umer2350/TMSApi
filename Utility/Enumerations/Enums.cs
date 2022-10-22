using System;

namespace Utility.Enumerations
{
    public static class Enums
    {
        public static string GetFolderNameByModule(int docType)
        {
            if (docType == Convert.ToInt32(Module.Users))
                return "Users";
            else
            if (docType == Convert.ToInt32(Module.Task))
                return "Task";
            else
                return "";
        }
    }

    public enum Module
    {
        Users = 1,
        Task=2
    }


}
