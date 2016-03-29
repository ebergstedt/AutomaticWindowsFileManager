using System;
using System.Collections.Generic;
using System.IO;
using AutomaticWindowsFileManager.Containers;
using AutomaticWindowsFileManager.Factories;
using AutomaticWindowsFileManager.Infrastructure;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NLog;

namespace AutomaticWindowsFileManager
{
    public class Program
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            _logger.Info("Start");

            var readAllText = File.ReadAllText("config.json");

            var jsonConfig = JsonConvert.DeserializeObject<JsonConfig>(readAllText);

            foreach (var fileOperation in jsonConfig.FileOperations)
            {
                _logger.Info($"FileOperation {JsonConvert.SerializeObject(fileOperation)}");

                FileOperationApplier fileOperationApplier = new FileOperationApplier();
                fileOperationApplier.Apply(fileOperation);
            }

            _logger.Info("End");
        }
    }
}
