namespace ConsoleIOManager;
using static System.Console;

//-----------------------------V1.3-KeganF------------------------------//
// CLASS > ConsoleManager                                               //
//         Provides static methods for console applications             //
//         - Display customs prompts, menus, and options                //
//         - Handle user input                                          //
//----------------------------------------------------------------------//
public static class ConsoleManager
{
    //------------------------------v-Fields-v------------------------------//
    private static readonly string inputPrompt = "> ";
    
    //-----------------------------v-Methods-v------------------------------//
    //----------------------------------------------------------------------//
    // METHOD > DisplayCheckBoxes                                           //          
    //          Displays the provided options in a check box format         //
    //                                                                      //
    // PARAMS > options - string array of the options to be displayed       //
    //          prompt - optional string to be displayed above the          //
    //                   options                                            //
    //                                                                      //
    // RETURN > (int) the index of the selected option                      //
    //----------------------------------------------------------------------//
    public static int DisplayCheckBoxes(string[] options, 
        string prompt = "Select one of the following options:") 
    {
        int selectedIndex = 0;
        ConsoleKeyInfo input;

        WriteLine(prompt);
        do {
            // Display options in a "check box" format
            for (int i = 0; i < options.Length; i++)
            {
                Write("[{0}] {1}\n", 
                    i == selectedIndex ? "X" : " ", 
                    options[i]);
            }

            // Read input from user
            input = ReadKey();
            // TAB to cycle to next option
            if (input.Key == ConsoleKey.Tab)
            {
                selectedIndex++;
                if (selectedIndex == options.Length)
                {
                    selectedIndex = 0;
                }

                // Set the cursor position to rewrite the options
                SetCursorPosition(0, CursorTop - options.Length);
            }
            // TODO - Add SHIFT+TAB to cycle backwards through options?
        } while (input.Key != ConsoleKey.Enter);

        return selectedIndex;
    }

    //----------------------------------------------------------------------//
    // METHOD > DisplayYesNo                                                //          
    //          Shorthand for accessing the DisplayCheckBoxes method when   //
    //          using options "No" and "Yes" only. Converts int returned    //
    //          DisplayCheckBoxes to bool                                   //
    //                                                                      //
    // PARAMS > prompt - optional string to be displayed above the          //
    //                   options                                            //
    //                                                                      //
    // RETURN > (bool) the int returned from DisplayCheckBoxes converted to //
    //          bool                                                        //
    //----------------------------------------------------------------------//
    public static bool DisplayYesNo( 
        string prompt = "Select one of the following options:") 
    {
        int response = DisplayCheckBoxes(new string[]{"No", "Yes"}, prompt);
        return Convert.ToBoolean(response);
    }

    //----------------------------------------------------------------------//
    // METHOD > DisplayNumberedMenu                                         //          
    //          Displays the provided options in a numbered menu format     //
    //                                                                      //
    // PARAMS > options - string array of the options to be displayed       //
    //          prompt - optional string to be displayed above the          //
    //                   options                                            //
    //                                                                      //
    // RETURN > (int) the number corresponding to the listed option         //
    //----------------------------------------------------------------------//
    public static int DisplayNumberedMenu(string[] options,
        string prompt = "Select one of the following options:")
    {
        int input = 0;
        
        WriteLine(prompt);
        // Display options in a "numbered menu" format
        for (int i = 0; i < options.Length; i++)
        {
            WriteLine($"[{i+1}] - {options[i]}");
        }

        do
        {    
            // Get input from user; convert to int
            input = GetConvertedInput<int>();
            
            // Check if input is outside of valid range
            if (input < 1 || input > options.Length)
            {
                SetCursorPosition(0, CursorTop - 1);
                WriteLineColored(
                    $"{input} is outside the valid range of options.", 
                    ConsoleColor.Red);
            }

        } while (input < 1 || input > options.Length);
        
        return input;
    }

    // TODO - create method for DisplayPaginationMenu
    //        Takes string[] items and int itemsPerPage

    // TODO - create method for DisplayCustomMenu
    //        Takes a dictionary
    //        KEY   - option ID (i.e, 1, 2, Q, etc.)
    //        VALUE - option text (i.e., Add, Delete, Quit, etc.)  

    //----------------------------------------------------------------------//
    // METHOD > GetConvertedInput                                           //          
    //          Uses generics to convert string returned from ReadLine() to //
    //          the desired type                                            //
    //                                                                      //
    // PARAMS > prompt - optional string to be displayed before the input   //
    //                   prompt                                             //
    //                                                                      //
    // RETURN > (T) the value of ReadLine() converted from string -> T      //
    //----------------------------------------------------------------------//
    public static T GetConvertedInput<T>(string prompt = "")
    {
        // Prompt the user for input
        Write($"{prompt}{inputPrompt}");
        try {
            // Read input from user
            string input = ReadLine() ?? "";
            // Attempt to convert input string to desired type...
            return (T)Convert.ChangeType(input, typeof(T));
        }
        catch (Exception ex)
        {
            // ...re-prompt for input if the conversion fails
            SetCursorPosition(0, CursorTop - 1);
            WriteLineColored(ex.Message, ConsoleColor.Red);
            return GetConvertedInput<T>(prompt);
        }
    }

    //----------------------------------------------------------------------//
    // METHOD > WriteLineColored                                            //          
    //          Writes the given line of text to the console in the given   //
    //          color                                                       //
    //                                                                      //
    // PARAMS > text - the text to be written to the console                //
    //          color - the foreground color to apply to the text           //
    //                                                                      //
    // RETURN > void                                                        //
    //----------------------------------------------------------------------//
    public static void WriteLineColored(string text, ConsoleColor color)
    {
        // Store current color to revert to after writing colored line
        ConsoleColor originalColor = ForegroundColor;

        // Set new color; write to text to console
        ForegroundColor = color;
        WriteLine(text);
        
        // Revert to original foreground color
        ForegroundColor = originalColor;
    }

    //----------------------------------------------------------------------//
    // METHOD > WriteColored                                                //          
    //          Writes the given text to the console in the given color     //
    //          without addding a newline character to the end              //
    //                                                                      //
    // PARAMS > text - the text to be written to the console                //
    //          color - the foreground color to apply to the text           //
    //                                                                      //
    // RETURN > void                                                        //
    //----------------------------------------------------------------------//
    public static void WriteColored(string text, ConsoleColor color)
    {
        // Store current color to revert to after writing colored line
        ConsoleColor originalColor = ForegroundColor;

        // Set new color; write to text to console
        ForegroundColor = color;
        Write(text);
        
        // Revert to original foreground color
        ForegroundColor = originalColor;
    }
}
