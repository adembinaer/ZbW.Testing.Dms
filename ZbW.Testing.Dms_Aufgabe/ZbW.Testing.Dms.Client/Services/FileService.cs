﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.Testing.Dms.Client.Services {
	internal class FileService {

		// Property ist von aussen nicht lesbar
		internal FileTestable FileTestable { private get; set; }

		public void CreateValutaFolderIfNotExists(string path) {
			Directory.CreateDirectory(path);
		}

		// Ein Standard für Property Injection wird im Konstruktor gesetzt
		public FileService()
		{
			FileTestable = new FileTestable();
		}

		public void RemoveDocumentOnSource(string path) {
			File.Delete(path);
		}

		public void CopyDocumentToTarge(String sourcePath, String targetPath) {
			try
			{
				FileTestable.Copy(sourcePath, targetPath, true);
			}
			catch (Exception e)
			{
				throw new CouldNotCopyFileException("File konnte nicht kopiert werden", e);
			}
		}

		public String GetNewFileName(String typeName, String fileName, Guid guid) {
			var fileExtension = this.GetFileExtension(fileName);
			return $"{guid}_{typeName}.{fileExtension}";
		}

		public String GetFileExtension(String fileName) {
			var splittedByPoint = fileName.Split('.');
			return splittedByPoint[splittedByPoint.Length - 1];
		}
	}
}
