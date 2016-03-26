# TransferWindowsFiles
Simple windows transfer program with logging and json configuration.

This could likely have been done in PowerShell, but with this project you get some nice logging with NLOG and a clean json file for your configuration.

Just add entries to your config.json and fire away.

**config.json**
```json
{
  "FileTransfer": [
    {
      "Source": "E:\\!Chrome Download",
      "Target": "E:\\!Google Drive\\Youtube",
      "Extension": "mp4",
      "Regex": ""
    }
  ]
}
```

# Todo

Regex