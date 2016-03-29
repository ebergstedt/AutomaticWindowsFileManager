# Automatic Windows File Manager
Simple windows file management program with logging and json configuration. 

# Features

It can do the following operations for your files, running automatically in the background if you set it as a background service.

* **Move files** - "Operation" : "Move" 
* **Copy files** - "Operation" : "Copy"
* **Delete files** - "Operation" : "Delete"

You idenfity files by filtering on your own **regex**.

# Regex?

Regex is used to identify text. Here's an introduction guide: [Regular Expressions - User Guide](http://www.zytrax.com/tech/web/regex.htm)

You can use for example [Regexpal](http://www.regexpal.com/) or [Regexr](http://www.regexr.com/) for testing your regex.

# Configuration

Example: 

The first operation will take all chrome downloaded files with the .mp4 extension and move to a youtube folder on google drive. (Obivously, you must change to your own directory structure.)

The second operation will empty your Trash folder.

```json
{
  "FileOperations": [
    {
      "Source": "E:\\Chrome Download",
      "Target": "E:\\Google Drive\\Youtube",
      "Regex": "*.mp4",
      "Operation": "Move"
    },
    {
      "Source": "E:\\Documents",
      "Target": "E:\\Google Drive\\Documents",
      "Regex": "*.txt",
      "Operation": "Copy"
    },
    {
      "Source": "E:\\Trash",
      "Regex": "*",
      "Operation": "Delete"
    }
  ]
}
```