using C3Git.Cli.CommandHandlers;
using C3Git.Cli.Commands;
using CommandLine;
using System;

namespace C3Git.Cli
{
    [Verb(".")]
    public class Dummy
    {
    }

    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Init, Mount, Commit>(args)
                .MapResult(
                    (Init init) => new InitCommandHandler().Run(init),
                    (Mount mount) => new MountCommandHandler().Run(mount),
                    (Commit commit) => new CommitCommandHandler().Run(commit),
                    errs => 1);
        }
    }
}
