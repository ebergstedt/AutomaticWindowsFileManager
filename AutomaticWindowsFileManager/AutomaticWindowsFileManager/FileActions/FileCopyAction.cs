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
    public class FileCopyAction : Interfaces.IFileAction
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly string _sourceFilePath;
        private readonly string _targetFilePath;

        public FileCopyAction(
                              [NotNull] string sourceFilePath,
                              [NotNull] string targetFilePath)
        {
            if (sourceFilePath == null) throw new ArgumentNullException(nameof(sourceFilePath));
            if (targetFilePath == null) throw new ArgumentNullException(nameof(targetFilePath));

            _sourceFilePath = sourceFilePath;
            _targetFilePath = targetFilePath;
        }

        public void Act()
        {
            if (!File.Exists(_sourceFilePath))
                throw new FileNotFoundException(nameof(_sourceFilePath));

            if (File.Exists(_targetFilePath))
            {
                _logger.Info($"Target file already exists. Deleting.");
                try
                {
                    File.Delete(_sourceFilePath);
                }
                catch (Exception ex)
                {
                    _logger.Info(ex);
                }
            }                

            _logger.Info($"Copy Source: {_sourceFilePath} Target: {_targetFilePath}");

            try
            {
                File.Copy(_sourceFilePath, _targetFilePath);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }            
        }
    }
}
