using C3Git.Cli.Commands;
using C3Git.Cli.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace C3Git.Cli.CommandHandlers
{
    class MountCommandHandler
    {
        public int Run(Mount mount)
        {
            var directory = mount.SourceDirectory.GetOrPwd();
            var targetProject = mount.TargetProject.GetOrConfiguredProjectFile(directory);
            var temporaryFile = new FileInfo($"{targetProject.FullName}.temp");

            if (temporaryFile.Exists)
            {
                temporaryFile.Delete();
            }

            Console.WriteLine("Mounting project...");
            directory.Zip(temporaryFile, file => !file.FullName.Contains(".git"));

            if (targetProject.Exists)
            {
                temporaryFile.Replace(targetProject.FullName, $"{targetProject.FullName}.backup-{DateTime.Now:yyyy-MM-dd-HHmmss}.c3p");
                temporaryFile.Delete();
            }
            else
            {
                File.Move(temporaryFile.FullName, targetProject.FullName);
            }
            Console.WriteLine("Project mounted.");

            return 0;
        }
    }
}
