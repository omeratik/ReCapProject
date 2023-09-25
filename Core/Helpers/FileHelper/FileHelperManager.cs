using System.Runtime.CompilerServices;
using Core.Helpers.GuideHelper;
using Microsoft.AspNetCore.Http;

namespace Core.Helpers.FileHelper;

public class FileHelperManager : IFileHelper
{
	public void Delete(string filePath)
	{
		if (File.Exists(filePath))
		{
			File.Delete(filePath);
		}
	}

	public string Update(IFormFile file, string filePath, string root)
	{
		if (File.Exists(filePath))
		{
			File.Delete(filePath);
		}

		return Upload(file, root);
	}

	public string Upload(IFormFile file, string root)
	{
		if (file.Length > 0)
		{
			if (!Directory.Exists(root))
			{
				Directory.CreateDirectory(root);
			}

			string uzantı = Path.GetExtension(file.FileName);
			string guid = GuidHelper.CreateGuid();
			string filePath = guid + uzantı;

			using (FileStream fileStream = File.Create(root +filePath))
			{
				file.CopyTo(fileStream);
				fileStream.Flush();
				return filePath;
			}
		}

		return null;
	}
}