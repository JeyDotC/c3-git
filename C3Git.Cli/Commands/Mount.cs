using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace C3Git.Cli.Commands
{
    [Verb("mount", HelpText = "Mounts the contents of a construct 3 directory project into a .c3p file so it can be opened from Construct 3. This command will create a backup of the original file if it already exists. All git-related folders will be ignored.")]
    class Mount
    {
        [Value(0, MetaName = nameof(SourceDirectory), Required = false, HelpText = "The directory to mount the project from. If this parameter is omitted, the current working directory will be used.")]
        public DirectoryInfo SourceDirectory { get; set; }

        [Value(1, MetaName = nameof(TargetProject), Required = false, HelpText = "Path to the destination Construct 3 project. If this parameter is omitted, this command will attempt to use the configured project file in the .git/config file.")]
        public FileInfo TargetProject { get; set; }
    }
}
