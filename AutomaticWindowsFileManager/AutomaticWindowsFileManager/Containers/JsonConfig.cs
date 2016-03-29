using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomaticWindowsFileManager.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AutomaticWindowsFileManager.Containers
{

    public class FileOperation
    {
        public bool ReplaceTargetFileIfAlreadyExists { get; set; }

        public string Source { get; set; }

        public string Target { get; set; }

        public string Extension { get; set; }

        public string Regex { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.Operation Operation { get; set; }
    }

    public class JsonConfig
    {
        public List<FileOperation> FileOperations { get; set; }
    }
}
