using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.IO
{
    static class IOExtensions
    {
        public static DirectoryInfo GetOrPwd(this DirectoryInfo directory)
        {
            if (directory == null)
            {
                return new DirectoryInfo(Directory.GetCurrentDirectory());
            }

            return directory;
        }

        public static DirectoryInfo Ensure(this DirectoryInfo directory)
        {
            if (directory == null)
            {
                return new DirectoryInfo(Directory.GetCurrentDirectory());
            }

            if (!directory.Exists)
            {
                directory.Create();
            }

            return directory;
        }

        public static DirectoryInfo EnforcingValidRepository(this DirectoryInfo directory)
        {
            if(!directory.EnumerateDirectories().Any(d => d.Name == ".git"))
            {
                throw new ArgumentException("The directory is not a valid git repository.");
            }

            return directory;
        }

        public static FileInfo GetOrConfiguredProjectFile(this FileInfo file, DirectoryInfo directory)
        {
            if(file == null)
            {
                var dir = directory.EnforcingValidRepository();

                using(var repo = new Repository(dir.FullName))
                {
                    return repo.GetTargetProject();
                }
            }

            return file;
        }
    }
}
