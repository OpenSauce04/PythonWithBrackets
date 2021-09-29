﻿using System;
using System.IO;

namespace PythonWithBrackets
{
    class DirectoryCopy
    {

        public static void Copy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            try
            {
                // Delete existing files in destination directory
                DirectoryInfo di = new DirectoryInfo(destDirName);
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
            } catch (DirectoryNotFoundException) {}

            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.       
            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    if (subdir.Name != destDirName)
                    {
                        string tempPath = Path.Combine(destDirName, subdir.Name);
                        DirectoryCopy.Copy(subdir.FullName, tempPath, copySubDirs);
                    }
                }
            }
        }
    }
}