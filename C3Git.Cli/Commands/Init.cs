using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace C3Git.Cli.Commands
{
    [Verb("init")]
    class Init
    {
        [Value(0, MetaName = nameof(SourceProject), HelpText = "Path to the Construct 3 project.")]
        public FileInfo SourceProject { get; set; }

        [Value(1, MetaName = nameof(TargetDirectory), Required =false, HelpText = "Directory to put the project into.")]
        public DirectoryInfo TargetDirectory { get; set; }
    }
}
