using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace C3Git.Cli.Commands
{
    [Verb("commit", HelpText = "Extracts the content from the given Construct 3 Project file to the directory and creates a commit with the given message.")]
    class Commit
    {
        [Value(0, MetaName = nameof(SourceProject), Required = false, HelpText = "Path to the Construct 3 project file.")]
        public FileInfo SourceProject { get; set; }

        [Value(1, MetaName = nameof(TargetDirectory), Required = false, HelpText = "Directory to put the project into.")]
        public DirectoryInfo TargetDirectory { get; set; }

        [Option('m', "message", Required = true, HelpText = "Message for the commit.")]
        public string Message { get; set; }
    }
}
