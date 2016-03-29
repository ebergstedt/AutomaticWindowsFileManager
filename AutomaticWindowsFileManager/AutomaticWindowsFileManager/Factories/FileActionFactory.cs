using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomaticWindowsFileManager.FileActions;
using AutomaticWindowsFileManager.Infrastructure;

namespace AutomaticWindowsFileManager.Factories
{
    public static class FileActionFactory
    {
        public static Interfaces.IFileAction GetFileAction(Enums.Operation operation, string sourceFilePath, string targetFilePath)
        {
            switch (operation)
            {
                case Enums.Operation.Copy:
                    return new FileCopyAction(sourceFilePath, targetFilePath);
                case Enums.Operation.Move:
                    return new FileMoveAction(sourceFilePath, targetFilePath);
                case Enums.Operation.Delete:
                    return new FileDeleteAction(sourceFilePath);
            }

            return null;
        }
    }
}
