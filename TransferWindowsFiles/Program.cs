using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using NLog;

namespace TransferWindowsFiles
{
    public class FileTransfer
    {
        public string Source { get; set; }
        public string Target { get; set; }
        public string Extension { get; set; }
        public string Regex { get; set; }
    }

    public class RootObject
    {
        public List<FileTransfer> FileTransfer { get; set; }
    }

    internal class Program
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private static void Main(string[] args)
        {
            _logger.Info("Start");

            var readAllText = File.ReadAllText("config.json");

            var jsonConfig = JsonConvert.DeserializeObject<RootObject>(readAllText);

            foreach (var fileTransfer in jsonConfig.FileTransfer)
            {
                if (!string.IsNullOrEmpty(fileTransfer.Extension))
                    HandleExtension(fileTransfer);

                if (!string.IsNullOrEmpty(fileTransfer.Regex))
                    HandleRegex(fileTransfer);
            }

            _logger.Info("End");
        }

        private static void HandleExtension(FileTransfer fileTransfer)
        {
            _logger.Info($"HandleExtension({JsonConvert.SerializeObject(fileTransfer)})");

            if (!Directory.Exists(fileTransfer.Target))
                return;

            var files = Directory.GetFiles(fileTransfer.Source, $"*.{fileTransfer.Extension}");
            foreach (var file in files)
            {
                _logger.Info($"HandleExtension File: {file}");

                var currentFileName = Path.GetFileName(file);
                var targetFilePath = fileTransfer.Target + $@"\{currentFileName}";

                if (File.Exists(targetFilePath))
                {
                    continue;
                }

                try
                {
                    _logger.Info($"HandleExtension File Move From {file} To {targetFilePath}");
                    File.Move(file, targetFilePath);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                }
            }
        }

        private static void HandleRegex(FileTransfer fileTransfer)
        {
            throw new NotImplementedException();
        }
    }
}