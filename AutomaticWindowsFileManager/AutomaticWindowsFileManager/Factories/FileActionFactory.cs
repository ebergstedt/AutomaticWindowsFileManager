using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomaticWindowsFileManager.Containers;
using AutomaticWindowsFileManager.FileActions;
using AutomaticWindowsFileManager.Infrastructure;

namespace AutomaticWindowsFileManager.Factories
{
    public static class FileActionFactory
    {
        public static Interfaces.IFileAction GetFileAction(FileOperation fileOperation, string sourceFilePath, string targetFilePath)
        {
            switch (fileOperation.Operation)
            {
                case Enums.Operation.Copy:
                    return new FileCopyAction(sourceFilePath, targetFilePath, fileOperation.ReplaceTargetFileIfAlreadyExists);
                case Enums.Operation.Move:
                    return new FileMoveAction(sourceFilePath, targetFilePath);
                case Enums.Operation.Delete:
                    return new FileDeleteAction(sourceFilePath);
            }

            return null;
        }
    }
}
