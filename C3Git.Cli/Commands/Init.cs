using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace C3Git.Cli.Commands
{
    [Verb("init", HelpText = "Extracts the contents of a Construct 3 project (.c3p file) into a destination folder and then initializes as a git repository with an appropriate .gitignore file and doing an initial commit with the extracted files.")]
    class Init
    {
        [Value(0, MetaName = nameof(SourceProject), Required = true, HelpText = "Path to the Construct 3 project.")]
        public FileInfo SourceProject { get; set; }

        [Value(1, MetaName = nameof(TargetDirectory), Required =false, HelpText = "Directory to put the project into. If this parameter is omitted, the current working directory will be used.")]
        public DirectoryInfo TargetDirectory { get; set; }
    }
}
