using System;
using System.Drawing;
using System.IO;

using Svg;

namespace ConsoleApp5
{
  class Program
  {
    private static void ProcessSvg(string path)
    {
      Console.WriteLine("Opening: {0}", Path.GetFileName(path));
      SvgDocument svg = SvgDocument.Open(path);
      Bitmap bmp = svg.Draw();

      string dirPath = Path.Combine(Path.GetDirectoryName(path), "Preview");
      Directory.CreateDirectory(dirPath);

      path = Path.ChangeExtension(Path.GetFileName(path), ".png");
      Console.WriteLine("Writing: {0}", path);

      bmp.Save(Path.Combine(dirPath, path));
    }

    static void Main(string[] args)
    {
      string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.svg");

      foreach (string file in files)
        ProcessSvg(file);

      Console.ReadLine();
    }
  }
}
