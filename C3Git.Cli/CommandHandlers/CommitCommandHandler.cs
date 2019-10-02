using C3Git.Cli.Commands;
using C3Git.Cli.Extensions;
using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace C3Git.Cli.CommandHandlers
{
    class CommitCommandHandler
    {
        public int Run(Commands.Commit commit)
        {
            var targetDirectory = commit.TargetDirectory.GetOrPwd();
            var sourceProject = commit.SourceProject.GetOrConfiguredProjectFile(targetDirectory);

            var allFiles = targetDirectory.EnumerateFiles("*", SearchOption.AllDirectories)
                .Where(f => !f.FullName.Contains(".git"));

            Console.WriteLine("Cleaning working directory. If anything goes wrong, you can run 'git reset --hard HEAD'...");
            foreach (var file in allFiles)
            {
                file.Delete();
            }
            Console.WriteLine("Outdated files deleted.");

            Console.WriteLine("Pulling files from the project...");
            sourceProject.UnZip(targetDirectory);
            Console.WriteLine("Project extracted.");

            Console.WriteLine("Commiting changes...");
            using(var repo = new Repository(targetDirectory.FullName))
            {
                repo.Commit(commit.Message);
            }
            Console.WriteLine("Changes commited.");

            return 0;
        }
    }
}
