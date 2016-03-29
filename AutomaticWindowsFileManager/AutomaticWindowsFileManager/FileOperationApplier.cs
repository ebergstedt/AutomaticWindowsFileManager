using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomaticWindowsFileManager.Containers;
using AutomaticWindowsFileManager.Factories;
using JetBrains.Annotations;

namespace AutomaticWindowsFileManager
{

    public class FileOperationApplier
    {
        private FileOperation _fileOperation;

        public void Apply([NotNull] FileOperation fileOperation)
        {
            if (fileOperation == null) throw new ArgumentNullException(nameof(fileOperation));

            _fileOperation = fileOperation;

            if (!string.IsNullOrEmpty(_fileOperation.Extension))
                ApplyActionToFiles(GetFilesByExtension());

            if (!string.IsNullOrEmpty(_fileOperation.Regex))
                ApplyActionToFiles(GetFilesByRegex());
        }

        private string[] GetFilesByExtension()
        {
            return GetFilePaths($"*.{_fileOperation.Extension}");
        }

        private string[] GetFilesByRegex()
        {
            return GetFilePaths(_fileOperation.Regex);
        }

        private void ApplyActionToFiles(string[] filePaths)
        {
            foreach (var sourceFilePath in filePaths)
            {
                string targetFilePath = string.Empty;

                if (!string.IsNullOrEmpty(_fileOperation.Target))
                    targetFilePath = Path.Combine(_fileOperation.Target, Path.GetFileName(sourceFilePath));

                var fileAction = FileActionFactory.GetFileAction(_fileOperation.Operation, sourceFilePath, targetFilePath);

                fileAction.Act();
            }
        }

        private string[] GetFilePaths(string searchPattern)
        {
            return Directory.GetFiles(_fileOperation.Source, searchPattern, SearchOption.AllDirectories);
        }
    }
}
