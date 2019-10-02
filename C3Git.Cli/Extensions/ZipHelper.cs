using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace C3Git.Cli.Extensions
{
    public static class ZipHelper
    {
        public static void Zip(
            this DirectoryInfo sourceDirectory,
            FileInfo destinationArchiveFile
        )
            => Zip(sourceDirectory, destinationArchiveFile, f => true, default);

        public static void Zip(
            this DirectoryInfo sourceDirectory,
            FileInfo destinationArchiveFile,
            Predicate<FileInfo> include // Add this parameter
        )
            => Zip(sourceDirectory, destinationArchiveFile, include, default);

        public static void Zip(
            this DirectoryInfo sourceDirectory,
            FileInfo destinationArchiveFilE,
            Predicate<FileInfo> include,
            CompressionLevel compressionLevel
        )
        {
            var filesToAdd = sourceDirectory.EnumerateFiles("*", SearchOption.AllDirectories);

            using (var zipFileStream = new FileStream(destinationArchiveFilE.FullName, FileMode.Create))
            {
                using (var archive = new ZipArchive(zipFileStream, ZipArchiveMode.Create))
                {
                    foreach (var fileInfo in filesToAdd)
                    {
                        // Add the following condition to do filtering:
                        if (!include(fileInfo))
                        {
                            continue;
                        }
                        var entryName = fileInfo.FullName.Substring(sourceDirectory.FullName.Length).Trim('/').Trim('\\');
                        archive.CreateEntryFromFile(fileInfo.FullName, entryName, compressionLevel);
                    }
                }
            }
        }

        public static void UnZip(this FileInfo zippedfile, DirectoryInfo destination)
        {
            using (var zipFileStream = new FileStream(zippedfile.FullName, FileMode.Open))
            {
                using (var archive = new ZipArchive(zipFileStream, ZipArchiveMode.Read)) {

                    foreach (var item in archive.Entries)
                    {
                        var relativePath = item.FullName.Replace('\\', Path.DirectorySeparatorChar);
                        var fullPath = Path.Combine(destination.FullName, relativePath);
                        var destinationFileInfo = new FileInfo(fullPath);

                        if (!destinationFileInfo.Directory.Exists)
                        {
                            destinationFileInfo.Directory.Create();
                        }

                        item.ExtractToFile(fullPath);
                    }
                }
            }
        }
    }
}
