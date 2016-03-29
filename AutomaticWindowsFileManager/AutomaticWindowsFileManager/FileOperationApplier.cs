using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomaticWindowsFileManager.Containers;
using AutomaticWindowsFileManager.Factories;
using JetBrains.Annotations;
using NLog;

namespace AutomaticWindowsFileManager
{

    public class FileOperationApplier
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private FileOperation _fileOperation;

        public void Apply([NotNull] FileOperation fileOperation)
        {
            if (fileOperation == null)
                throw new ArgumentNullException(nameof(fileOperation));

            _fileOperation = fileOperation;

            if (string.IsNullOrEmpty(_fileOperation.Regex)) 
                throw new ArgumentException("Regex is missing");

            IEnumerable<string> files = GetFilesWithAllowedAccess(_fileOperation.Source, _fileOperation.Regex);

            ApplyActionToFiles(files);
        }

        private List<string> GetFilesWithAllowedAccess(string path, string pattern)
        {
            var files = new List<string>();

            try
            {
                files.AddRange(Directory.GetFiles(path, pattern, SearchOption.TopDirectoryOnly));
                foreach (var directory in Directory.GetDirectories(path))
                    files.AddRange(GetFilesWithAllowedAccess(directory, pattern));
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

            return files;
        }


        private void ApplyActionToFiles(IEnumerable<string> filePaths)
        {
            foreach (var sourceFilePath in filePaths)
            {
                string targetFilePath = string.Empty;

                if (!string.IsNullOrEmpty(_fileOperation.Target))
                    targetFilePath = Path.Combine(
                                                  _fileOperation.Target, 
                                                  Path.GetFileName(sourceFilePath));

                var fileAction = FileActionFactory.GetFileAction(
                                                                 _fileOperation, 
                                                                 sourceFilePath, 
                                                                 targetFilePath);

                fileAction.Act();
            }
        }
    }
}
