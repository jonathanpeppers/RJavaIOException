using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

class Program
{
	static void Main(string[] args)
	{
		var path = Path.GetDirectoryName(typeof(Program).Assembly.Location);
		var folder = args.Length == 0 ? Path.Combine(path, "..", "..", "..", "..", "RJavaIOException.Android") : args[0];

		var packages = new List<string>();
		foreach (var file in Directory.EnumerateFiles(Path.GetFullPath(folder), "AndroidManifest.xml", SearchOption.AllDirectories))
		{
			var dir = Path.GetFileName(Path.GetDirectoryName(file));
			if (dir == "bin" || dir == "manifest" || dir == "Properties")
			{
				continue;
			}
			var xml = XDocument.Load(file);
			string packageName = xml.Element("manifest").Attribute("package").Value;
			Console.WriteLine(file);
			Console.WriteLine(packageName + ", dup=" + packages.Contains (packageName));
			packages.Add(packageName);
		}
	}
}