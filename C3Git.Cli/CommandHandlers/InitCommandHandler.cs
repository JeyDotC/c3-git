using C3Git.Cli.Commands;
using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace C3Git.Cli.CommandHandlers
{
    class InitCommandHandler
    {
        public int Run(Init init)
        {
            var sourceFile = (init.SourceProject?.Exists).GetValueOrDefault(false) ? init.SourceProject : throw new ArgumentException();
            var targetDirectory = init.TargetDirectory.Ensure();

            Console.WriteLine("Extracting project files...");
            ZipFile.ExtractToDirectory(sourceFile.FullName, targetDirectory.FullName);
            Console.WriteLine("Project files extracted.");

            Console.WriteLine("Initializing git...");
            Repository.Init(targetDirectory.FullName);
            Console.WriteLine("Git initialized.");

            using(var repo = new Repository(targetDirectory.FullName))
            {
                Console.WriteLine("Creating gitignore...");
                File.WriteAllText(Path.Combine(targetDirectory.FullName, ".gitignore"), "*.uistate.json");
                Console.WriteLine("gitgnore created.");

                Console.WriteLine("Linking this repo to the project file...");
                repo.SetTargetProject(sourceFile);
                Console.WriteLine("Project file linked to this repo.");

                Console.WriteLine("Creating initial commit...");
                repo.Commit("Initial commit.");
                Console.WriteLine("Initial commit created.");
            }

            Console.WriteLine("DONE.");

            return 0;
        }
    }
}
