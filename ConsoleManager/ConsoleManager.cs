namespace ConsoleIOManager;
using static System.Console;

//-----------------------------V1.1-KeganF------------------------------//
// CLASS > ConsoleManager                                               //
//         Provides static methods for console applications             //
//         - Display customs prompts, menus, and options                //
//         - Handle user input                                          //
//----------------------------------------------------------------------//
public class ConsoleManager
{
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
            // TAB to select next option
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
}
