using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class CopyBinaryFile
{
    static void Main()
    {
        FileStream readStream = new FileStream("hud.jpg", FileMode.Open);
        FileStream copyStream = new FileStream("copy.jpg", FileMode.Create);
        byte[] buffer = new byte[4096];
        using (readStream)
        {
            using (copyStream)
            {
                while (true)
                {
                    int readBytes = readStream.Read(buffer, 0, buffer.Length);
                    if (readBytes == 0)
                    {
                        break;
                    }
                    copyStream.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
}