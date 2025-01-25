using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

public static class PathExtensions
{
	public static string CanonicalCombine(string basePath, string path)
	{
		if (String.IsNullOrEmpty(basePath) || string.IsNullOrEmpty(path))
			throw new ArgumentNullException();

		// let's decode paramters
		basePath = HttpUtility.UrlDecode(basePath);
		path = HttpUtility.UrlDecode(path);

		if (path.IndexOfAny(Path.GetInvalidFileNameChars()) > -1)
			throw new FileNotFoundException("FileName not valid");

		string filePath = Path.Combine(basePath, path);
		if (!filePath.StartsWith(basePath))
			throw new FileNotFoundException("Path not valid");

		return filePath;
	}
}

PathExtensions.CanonicalCombine(basePath, PathValue.Text)