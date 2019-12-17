using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

class Program
{
	static void Main()
	{
		var path = Path.GetDirectoryName(typeof(Program).Assembly.Location);
		var folder = Path.Combine(path, "..", "..", "..", "..", "RJavaIOException.Android");

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