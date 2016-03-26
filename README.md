# TransferWindowsFiles
Simple windows file transfer program with logging and json configuration. **Currently it just moves the file.**

This could likely have been done in PowerShell, but with this project you get some nice logging with NLOG and a clean json file for your configuration.

Just add entries to your config.json and fire away.

The following will take all chrome downloaded files with the .mp4 extension and move to a youtube folder on google drive. (Obivously, you must change to your own directory structure.)

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

Just copy (and not move)