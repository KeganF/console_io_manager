# console_io_manager

C# class library for console IO formatting and processing.

## Static Methods

| Method | Description |
| --- | --- |
| **DisplayCheckBoxes** | Displays the provied options in a check box format |
| **DisplayYesNo** | Shorthand for accessing the DisplayCheckBoxes method when using options "No" and "Yes" only. Converts int returned from DisplayCheckBoxes to bool
| **DisplayNumberedMenu** | Displays the provided options in a numbered menu format |
| **GetConvertedInput** | Uses generics to convert string returned from ReadLine() to the desired type |
| **WriteLineColored** | Writes the given line of text to the console in the given color |
| **WriteColored** | Writes the given text to the console in the given color without addding a newline character to the end |