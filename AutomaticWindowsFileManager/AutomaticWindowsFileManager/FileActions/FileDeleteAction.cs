using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomaticWindowsFileManager.Infrastructure;
using JetBrains.Annotations;
using NLog;

namespace AutomaticWindowsFileManager.FileActions
{
    public class FileDeleteAction : Interfaces.IFileAction
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly string _filePath;

        public FileDeleteAction([NotNull] string filePath)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));

            _filePath = filePath;
        }

        public void Act()
        {
            if (!File.Exists(_filePath))
                throw new FileNotFoundException(nameof(_filePath));

            _logger.Info($"Delete Path: {_filePath}");

            try
            {
                File.Delete(_filePath);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }
    }
}
