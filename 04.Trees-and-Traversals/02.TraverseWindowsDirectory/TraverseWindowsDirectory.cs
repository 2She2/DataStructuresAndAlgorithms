﻿// 02.Write a program to traverse the directory C:\WINDOWS and all its subdirectories recursively and
//    to display all files matching the mask *.exe. Use the class System.IO.Directory.

namespace _02.TraverseWindowsDirectory
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class TraverseWindowsDirectory
    {
        public static void Main()
        {
            // this is slow - many files
            var startDir = new DirectoryInfo("C:\\Windows");

            TraverseDirectory(startDir);
        }
        public static void TraverseDirectory(DirectoryInfo dir)
        {
            try
            {
                var exeFiles = dir.GetFiles().Where(x => x.Extension == ".exe");
                foreach (var file in exeFiles)
                {
                    Console.WriteLine(file.FullName);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Access to folder {0} is denied", dir.FullName);
                return;
            }

            foreach (var subDir in dir.GetDirectories())
            {
                TraverseDirectory(subDir);
            }
        }
    }
}
