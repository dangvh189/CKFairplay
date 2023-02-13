# Apple Arcade - Fair Play

## Installation Instructions

## Usage

### Requirements
You must define `FAIR_PLAY_ENABLED` in your Player Settings in order for the `FairPlay.Register()` invocation to function. If you have not done so, but are calling the method, you will see a warning message logged as a reminder.

### Enable for Editor
By default, the plugin will not run in the editor. If you wish to test this in the editor, you need to add the define `FAIR_PLAY_IN_EDITOR`.

### Specific Notes
The build must be located in the /Applications folder in order to launch.

### Register() Invocation
You need to handle what happens if the FairPlay fails to register. The standard approach is to log the exception and exit the application.
```csharp
try
{
    FairPlay.Register();
}
catch(Exception exception)
{
    // App failed to register with FairPlay...
    Debug.LogException(exception);
    Application.Quit();
}
```
