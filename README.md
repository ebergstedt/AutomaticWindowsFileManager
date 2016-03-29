# Automatic Windows File Manager
Simple windows file management program with logging and json configuration. 

**Automatic Windows File Manager** is a lightweight background program that will handle day to day file transfers without the need for a monolith backup service or paid equivalent.

You can either start it manually or [schedule it as a background service](http://windows.microsoft.com/en-au/windows/schedule-task#1TC=windows-7).

# Features

It can do the following operations for your files, running automatically in the background if you set it as a background service.

* **Move files** - "Operation" : "Move" 
* **Copy files** - "Operation" : "Copy"
* **Delete files** - "Operation" : "Delete"

You idenfity files by filtering on your own **regex**.

Configuration is done in a simple **Json** file.

# Regex?

Regex is used to identify text. Here's an introduction guide: [Regular Expressions - User Guide](http://www.zytrax.com/tech/web/regex.htm)

You can use for example [Regexpal](http://www.regexpal.com/) or [Regexr](http://www.regexr.com/) for testing your regex.

# Configuration

You configure the program within the **config.json** file that is in the root folder.

There are three types of operations you can apply on your files:  **Move**, **Copy** and **Delete**.

## Move

| Name                             | Type   | Required | Description                                                                      |
|----------------------------------|--------|----------|----------------------------------------------------------------------------------|
| Source                           | String | Yes      | Directory path to copy files from.                                               |
| Target                           | String | Yes      | Directory path to copy files into.                                               |
| Regex                            | String | Yes      | Regex to identify files.                                                         |
| ReplaceTargetFileIfAlreadyExists | Bool   | No       | If files that already exists should be deleted (in order to update them) or not. |
| Operation                        | String | Yes      | Must be "Move"                                                                           |

## Copy

| Name                             | Type   | Required | Description                                                                      |
|----------------------------------|--------|----------|----------------------------------------------------------------------------------|
| Source                           | String | Yes      | Directory path to copy files from.                                               |
| Target                           | String | Yes      | Directory path to copy files into.                                               |
| Regex                            | String | Yes      | Regex to identify files.                                                         |
| ReplaceTargetFileIfAlreadyExists | Bool   | No       | If files that already exists should be deleted (in order to update them) or not. |
| Operation                        | String | Yes      | Must be "Copy"                                                                           |

## Delete

Example: 

The first operation will take all chrome downloaded files with the .mp4 extension and move (cut and paste) to a youtube folder on google drive.

The second operation will copy your text files from your documents folder to a backup documents folder on google drive.

The third operation will empty your Trash folder.

**config.json**
```json
{
  "FileOperations": [
    {
      "Source": "E:\\!Chrome Download",
      "Target": "E:\\!Google Drive\\Youtube",
      "Regex": "*.mp4",
      "ReplaceTargetFileIfAlreadyExists": false,
      "Operation": "Move"
    },
    {
      "Source": "E:\\Documents",
      "Target": "E:\\Google Drive\\Documents",
      "Regex": "*.txt",
      "ReplaceTargetFileIfAlreadyExists": false,
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