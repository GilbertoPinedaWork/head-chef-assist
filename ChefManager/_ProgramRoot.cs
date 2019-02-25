using System;
using System.IO;

namespace ChefManager
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            int input;
            do
            {
                input = GM_PublicInterface.ManagerSelection();
                switch (input)
                {
                    case 1:
                    {
                        GM_Main.IM_Main();
                        break;
                    }
                    case 2:
                    {
                        break;
                    }
                }
            } while (input !=0);
        }
    }
}