using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class FileSystemUtils
{
    public static void CopyFile(string sourceFile, string destinationFile)
    {
        File.Copy(sourceFile, destinationFile, true);
    }

    public static void CopyDirectory(string sourceDir, string destDir)
    {
        Directory.CreateDirectory(destDir);
        foreach (var filePath in Directory.GetFiles(sourceDir))
        {
            CopyFile(filePath, Path.Combine(destDir, Path.GetFileName(filePath)));
        }
        foreach (var directoryPath in Directory.GetDirectories(sourceDir))
        {
            CopyDirectory(directoryPath, Path.Combine(destDir, Path.GetFileName(directoryPath)));
        }
    }

    public static void DeleteFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }
    }

    public static void DeleteFiles(string[] fileNames)
    {
        foreach (var fileName in fileNames)
        {
            DeleteFile(fileName);
        }
    }

    public static void DeleteFilesByMask(string mask)
    {
        var files = Directory.GetFiles(Directory.GetCurrentDirectory(), mask);
        foreach (var file in files)
        {
            DeleteFile(file);
        }
    }

    public static void MoveFile(string sourceFile, string destinationFile)
    {
        File.Move(sourceFile, destinationFile);
    }

    public static void SearchWordInFile(string filePath, string word)
    {
        var lines = File.ReadAllLines(filePath);
        var occurrences = lines.Select((line, index) => new { Line = line, LineNumber = index + 1 })
                        .Where(l => l.Line.Contains(word))
                        .ToList();

        File.WriteAllLines("report.txt", occurrences.Select(o => $"Line {o.LineNumber}: {o.Line}").ToArray());
    }

    public static void SearchWordInDirectory(string dirPath, string word)
    {
        var files = Directory.GetFiles(dirPath, "*.*", SearchOption.AllDirectories);
        var reportLines = files.SelectMany(file =>
        {
            var lines = File.ReadAllLines(file);
            return lines.Select((line, index) => new { Line = line, LineNumber = index + 1, FileName = file })
                        .Where(l => l.Line.Contains(word))
                        .Select(l => $"File: {l.FileName}, Line {l.LineNumber}: {l.Line}");
        });

        File.WriteAllLines("directory_report.txt", reportLines.ToArray());
    }
}
