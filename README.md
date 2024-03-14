# Paster
Simple app that allows you to copy preset phrases.

## Usage
Application stays in tray, unless opened.  
LMB tray icon or use hotkey Ctrl+Shift+A to pop the menu up  
RMB tray icon to exit the app completely.  
Menu disappears on loosing focus/Phrase copied


## Installation
Grab one of the releases, unarchive into folder and run the .exe  
Note: Resources folder is required for application to run. It should alway be in the same directory as .exe  
### Buildding
This project was not meant with building in mind, therefore some manual actions will be required  

run:  
`dotnet build paster.sln`  
in the project directory.  

Then manually add  
`Resources/Phrases.xml`  
`Resources/TrayIcon.ico`  
into your building directory

## Xml Editing
Adding or removing new phrases can be done via UI.  

Make sure app is not running, otherwise you changes will not be parsed, and will be overriden (lost) upon app closing. 
### Xml Format
` <Phrases/> ` serves as a root element
Each phrase is saved as `<Phrase/>` with `name` and `text` attributes. Both are required for phrase to be valid.  
Example of valid `Phrases.xml` file:  
```xml
<?xml version="1.0" encoding="utf-8"?>
<Phrases>
  <Phrase name="GitHub" text="https://github.com/GalteXx/Paster" />
</Phrases>
```
