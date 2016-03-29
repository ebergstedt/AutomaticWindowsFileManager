# Automatic Windows File Manager
Simple windows file management program with logging and json configuration. 

# Features

It can do the following operations for your files, running automatically in the background if you set it as a background service.

* **Move files**
* **Delete files**
* **Copy files**

You idenfity files by filtering on **extension** or your own **regex**.

# Configuration

Example: 

The first operation will take all chrome downloaded files with the .mp4 extension and move to a youtube folder on google drive. (Obivously, you must change to your own directory structure.)

The second operation will empty your Trash folder.

```json
{
  "FileOperations": [
    {
      "Source": "E:\\!Chrome Download",
      "Target": "E:\\!Google Drive\\Youtube",
      "Extension": "mp4",
      "Regex": "",
      "Operation": "Move"
    },
    {
      "Source": "E:\\Trash",
      "Regex": "*",
      "Operation": "Delete"
    },
  ]
}


```