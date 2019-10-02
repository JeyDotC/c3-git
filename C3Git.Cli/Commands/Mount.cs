using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace C3Git.Cli.Commands
{
    [Verb("mount")]
    class Mount
    {
        [Value(0, MetaName = nameof(SourceDirectory), Required = false, HelpText = "Directory to create the project from.")]
        public DirectoryInfo SourceDirectory { get; set; }

        [Value(1, MetaName = nameof(TargetProject), HelpText = "Path to the Construct 3 project.")]
        public FileInfo TargetProject { get; set; }
    }
}
