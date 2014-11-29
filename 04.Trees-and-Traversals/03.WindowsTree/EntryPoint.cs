// 03.Define classes File { string name, int size } and
//    Folder { string name, File[] files, Folder[] childFolders } and using them build a tree
//    keeping all files and folders on the hard drive starting from C:\WINDOWS.
//    Implement a method that calculates the sum of the file sizes in given subtree of the tree and
//    test it accordingly. Use recursive DFS traversal.

namespace _02.TraverseWindowsDirectory
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class EntryPoint
    {
        public static void Main()
        {
            // otherwise its slow
            const string StartFolder = @"C:\Windows\Help";

            var root = new SysFolder(StartFolder);

            FillFolderWithFiles(new DirectoryInfo(StartFolder), root);

            PrintFromFolder(root, 0);

            Console.WriteLine("Total size is {0} bytes", root.GetSizeFromHere());
        }

        public static void FillFolderWithFiles(DirectoryInfo dir, SysFolder folder)
        {
            foreach (FileInfo file in dir.GetFiles())
            {
                folder.Files.Add(new SysFile(file.Name, file.Length));
            }

            foreach (var subDir in dir.GetDirectories())
            {
                var subFolder = new SysFolder(subDir.Name);
                folder.SubFolders.Add(subFolder);
                FillFolderWithFiles(subDir, subFolder);
            }
        }

        private static void PrintFromFolder(SysFolder folder, int offset)
        {
            Console.Write(new string('-', offset) + folder.Name);

            if (offset == 0)
            {
                Console.Write(" <- (root)");
            }

            Console.WriteLine();

            foreach (var subfolder in folder.SubFolders)
            {
                PrintFromFolder(subfolder, offset + 2);
            }

            foreach (var file in folder.Files)
            {
                Console.WriteLine(new string('-', offset) + file.Name);
            }
        }
    }
}
