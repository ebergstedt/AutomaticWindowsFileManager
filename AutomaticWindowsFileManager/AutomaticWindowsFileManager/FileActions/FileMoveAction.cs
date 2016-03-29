using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomaticWindowsFileManager.Infrastructure;
using JetBrains.Annotations;
using NLog;

namespace AutomaticWindowsFileManager.FileActions
{
    public class FileMoveAction : Interfaces.IFileAction
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly string _sourceFilePath;
        private readonly string _targetFilePath;

        public FileMoveAction(
                              [NotNull] string sourceFilePath,
                              [NotNull] string targetFilePath)
        {
            _sourceFilePath = sourceFilePath;
            _targetFilePath = targetFilePath;
        }

        public void Act()
        {
            FileCopyAction fileCopyAction = new FileCopyAction(_sourceFilePath, _targetFilePath);
            FileDeleteAction fileDeleteAction = new FileDeleteAction(_sourceFilePath);

            fileCopyAction.Act();
            fileDeleteAction.Act();
        }
    }
}
