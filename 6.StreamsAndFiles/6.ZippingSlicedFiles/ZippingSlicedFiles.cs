using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class ZippingSlicedFiles
{
    static void Main()
    {
        Slice("hud.jpg", "../../slice.jpg", 3);
        List<string> files = new List<string>()
                            {
                                "../../slicePart0.gz",
                                "../../slicePart1.gz",
                                "../../slicePart2.gz"
                            };
        Assemble(files, "../../merged.jpg");
    }
    static void Slice (string sourceFile, string destinationDirectory, int parts)
    {
        Regex rgx = new Regex(@"(\w+)\.(\w+)$");
        Match fileName = rgx.Match(destinationDirectory);
        string baseFileName = fileName.Groups[1].Value;
        string fileExtension = "gz";
        string destination = rgx.Replace(destinationDirectory, "");

        FileStream readSrc = new FileStream(sourceFile, FileMode.Open);
        using (readSrc)
        {
            byte[] buffer = new byte[readSrc.Length / parts];
            for (int i = 0; i < parts; i++)
            {
                readSrc.Read(buffer, 0, buffer.Length);
                FileStream partsMaker = new FileStream(destination + baseFileName + "Part" + i + "." + fileExtension, FileMode.Create);
                using (partsMaker)
                {
                    GZipStream compression = new GZipStream(partsMaker, CompressionMode.Compress, false);
                    using (compression)
                    {
                        compression.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
    static void Assemble(List<string> files, string destinationDirectory)
    {
        foreach (var item in files)
        {
            FileStream input = new FileStream(item, FileMode.Open);
            GZipStream compression = new GZipStream(input, CompressionMode.Decompress, false);
            FileStream output = new FileStream(destinationDirectory, FileMode.Append);
            using (input)
            {
                using (compression)
                {
                    using (output)
                    {
                        byte[] buffer = new byte[input.Length];
                        compression.Read(buffer, 0, buffer.Length);
                        output.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }  
    }
}