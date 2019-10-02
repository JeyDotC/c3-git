using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LibGit2Sharp
{
    static class RepositoryExtensions
    {
        public const string TargetProjectKey = "c3git.c3project";

        public static FileInfo GetTargetProject(this Repository repository)
        {
            var value = repository.Config.Get<string>(TargetProjectKey, ConfigurationLevel.Local)?.Value;

            if(value == null)
            {
                throw new ArgumentException("The target project is not configured.");
            }

            return new FileInfo(value);
        }
        public static void SetTargetProject(this Repository repository, FileInfo sourceFile)
        {
            repository.Config.Set("c3git.c3project", sourceFile.FullName, ConfigurationLevel.Local);
        }
        public static void Commit(this Repository repository, string commitMessage)
        {
            Commands.Stage(repository, "*");
            var email = repository.Config.Get<string>("user.email", ConfigurationLevel.Global).Value;
            var name = repository.Config.Get<string>("user.name", ConfigurationLevel.Global).Value;
            var signature = new Signature(name, email, DateTimeOffset.Now);
            repository.Commit(commitMessage, signature, signature);
        }
    }
}
