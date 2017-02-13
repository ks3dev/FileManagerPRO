// using System;
// using System.Threading;

// namespace ConsoleApplication
// {
//     public static class AppRunnerStatic
//     {
//         public static string menu = "Press 'M' to access the MAIN MENU.";
//         public static string quit = "Press 'Q to quit.";
//         public static string input;
        
//         public static void Menu(string[] array, string back, int menu)
//         {
//             Console.ForegroundColor = ConsoleColor.White;

//             int number = 0;

//             foreach(string item in array)
//             {
//                 number += 1;
//                 Console.WriteLine(number + ". " + item);
//             }

//             Console.WriteLine(back);
//             char response = Console.ReadKey().KeyChar;
//             Console.WriteLine();
            
//             ConsoleAnimation spin = new ConsoleAnimation();
//             bool check = true;
            
//             while(check == true)
//             {
//                 Thread.Sleep(30);
//                 check = spin.animation();
//             }

//             Console.WriteLine();

//             switch(menu)
//             {
//                 case 1:
//                 {
//                     MainMenuOptions(response);
//                     break;
//                 }
//                 case 2:
//                 {
//                     ManageFiles(response);
//                     break;
//                 }
//                 case 3:
//                 {
//                     ManageFolders(response);
//                     break;
//                 }
//             }
//         }

//         public static void MainMenuOptions(char response)
//         {
//             AppHelper app = new AppHelper();
//             string[] mainMenu = {"Get list of files in directory", "Get list of folders in directory", "Manage files", "Manage folders", "Generate index file"};
//             string[] filesMenu = { "Create file", "Delete file", "Move file", "Read text from file", "Write text to file", "Search file for text", "Generate index file"};
//             string[] foldersMenu = {"Create folder", "Delete folder"};

//             switch(response)
//             {
//                 case '1':
//                 {
//                     Console.WriteLine("Please enter a directory path: ");
//                     var input = Console.ReadLine();
                    
//                     try
//                     {
//                         var list = new ListMaker();
//                         Console.ForegroundColor = ConsoleColor.Green;
//                         string[] files = app.ListFilesInDirectory(input);
//                         list.CreateListTable(files, "file");
//                         long listSize = app.GetSizeOfFileList(input);
//                         Console.WriteLine("The total size of the files within this folder (excluding subfolders) is: " + Utilities.SelectAppropriateFileSizeFormat(listSize));
                        
//                         Console.WriteLine();
//                         Console.ForegroundColor = ConsoleColor.Yellow;
//                         Menu(mainMenu, quit, 1);
//                         break;
//                     }
//                     catch(ArgumentException)
//                     {
//                         Console.ForegroundColor = ConsoleColor.Red;
//                         Console.WriteLine("ERROR! Invalid user input!");
//                         Menu(mainMenu, quit, 1);
//                         break;
//                     }   
//                 }   
//                 case '2': 
//                 {
//                     Console.WriteLine("Please enter a directory:");
//                     input = Console.ReadLine();
//                     try
//                     {
//                         var list = new ListMaker();
//                         Console.ForegroundColor = ConsoleColor.Green;
//                         string[] folders = app.ListSubfoldersInDirectory(input);
//                         list.CreateListTable(folders, "folder");
//                         long totalSize = app.GetSizeOfDirectory(input) - app.GetSizeOfFileList(input);
//                         Console.WriteLine("The total size of the subfolders within this directory is: " + Utilities.SelectAppropriateFileSizeFormat(totalSize));

//                         Menu(mainMenu, quit, 1);
//                         break;
//                     }
//                     catch(ArgumentException)
//                     {
//                         Console.ForegroundColor = ConsoleColor.Red;
//                         Console.WriteLine("ERROR! Invalid user input!");
//                         Menu(mainMenu, quit, 1);
//                         break;
//                     }  
//                 }
//                 case '3':
//                 {
//                     Console.WriteLine("FILE MANAGER");
//                     Menu(filesMenu, menu, 2);
//                     break;
//                 }
//                 case '4':
//                 {
//                     Console.WriteLine("FOLDER MANAGER");
//                     Menu(foldersMenu, menu, 3);
//                     break;
//                 }
//                 case '5':
//                 {
//                     Console.WriteLine("This option creates a text file which compiles information on all of the files and folders in the location specified.");
//                     Console.WriteLine("To continue, please enter the directory path where you would like to create your index file:");
//                     string input = Console.ReadLine();

//                     try
//                     {
//                         app.CreateIndexFile(input);
//                         Console.ForegroundColor = ConsoleColor.Green;
//                         Console.WriteLine("SUCCESS! Your new index file has been created at " + input + "\\index.txt");
//                         Menu(mainMenu, quit, 1);
//                         break;
//                     }
//                     catch(ArgumentException)
//                     {
//                         Console.ForegroundColor = ConsoleColor.Red;
//                         Console.WriteLine("ERROR! Invalid user input!");
//                         Menu(mainMenu, quit, 1);
//                         break;
//                     }
//                 }
//                 case 'q':
//                 {
//                     Console.WriteLine();
//                     Console.WriteLine("GOODBYE!");
//                     Environment.Exit(0);
//                     break;
//                 }
//                 default:
//                 {
//                     Console.ForegroundColor = ConsoleColor.Red;
//                     Console.WriteLine("Invalid command! Please try again.");
//                     Menu(mainMenu, quit, 1);
//                     break;
//                 }
//             }
//         }
            
//         private static void ManageFiles(char response)
//         {
//             AppHelper app = new AppHelper();
//             string[] mainMenu = {"Get list of files in directory", "Get list of folders in directory", "Manage files", "Manage folders", "Generate index file"};
//             string[] filesMenu = { "Create file", "Delete file", "Move file", "Read text from file", "Write text to file", "Search file for text" };

//             switch(response)
//             {
//                 //CreateFile
//                 case '1':
//                 {
//                     Console.WriteLine("Enter the path for the file you wish to create: ");
//                     string input = Console.ReadLine();

//                     try
//                     {
//                         if(app.CheckFileExists(input) == true)
//                         {
//                             Console.ForegroundColor = ConsoleColor.Green;
//                             Console.WriteLine("SUCCESS! Your file has been created.");
//                             Menu(mainMenu, quit, 1);
                            
//                         }

//                         Console.ForegroundColor = ConsoleColor.Red;
//                         Console.WriteLine("ERROR! Could not create a file in this location!");
//                         Menu(mainMenu, quit, 1);
//                         break;
//                     }
//                     catch(ArgumentException)
//                     {
//                         Console.ForegroundColor = ConsoleColor.Red;
//                         Console.WriteLine("ERROR! Either the file already exists or you have entered an invalid file path!");
//                         Menu(mainMenu, quit, 1);
//                         break;
//                     }
//                 }
//                 //Delete File
//                 case '2':
//                 {
//                     Console.WriteLine("WARNING! This function will permenantly delete the specified file. To cancel, press 'C'.");
//                     Console.WriteLine("Enter the path for the file you wish to delete: ");
//                     string input = Console.ReadLine();

//                     if(input == "c" || input == "C")
//                     {
//                         Menu(filesMenu, menu, 1);
//                     }
                        
//                     try
//                     {
//                         app.RemoveFile(input);
//                         Console.ForegroundColor = ConsoleColor.Green;
//                         Console.WriteLine("SUCCESS! File has been removed");
//                         Menu(mainMenu, quit, 1);
//                         break;
//                     }
//                     catch(ArgumentException)
//                     {
//                         Console.ForegroundColor = ConsoleColor.Red;
//                         Console.WriteLine("ERROR! This file path does not exist!");
//                         Menu(mainMenu, quit, 1);
//                         break;
//                     }
//                 }
//                 //Move File
//                 case '3':
//                 {
//                     Console.WriteLine("Please enter the path of the file that you wish to move: ");
//                     string input1 = Console.ReadLine();
//                     Console.WriteLine();
//                     Console.WriteLine("Please enter the path you wish to move the file to: ");
//                     string input2 = Console.ReadLine();

//                     try
//                     {
//                         app.MoveFile(input1, input2);
//                         Console.ForegroundColor = ConsoleColor.Green;
//                         Console.Write("Operation successful!");
//                         Menu(mainMenu, quit, 1);
//                         break;
//                     }
//                     catch(ArgumentException)
//                     {
//                         Console.ForegroundColor = ConsoleColor.Red;
//                         Console.WriteLine("ERROR! The file you are trying to move doesn't exist!");
//                         Menu(mainMenu, quit, 1);
//                         break;
//                     } 
//                 }
//                 //Read text from file
//                 case '4':
//                 {
//                     Console.WriteLine("Select file to read: ");
//                     string input = Console.ReadLine();

//                     try
//                     {
//                         Console.ForegroundColor = ConsoleColor.Green;
//                         Console.WriteLine(app.ReadTextFromFile(input));
//                         Menu(mainMenu, quit, 1);
//                         break;
//                     }
//                     catch(ArgumentException)
//                     {
//                         Console.ForegroundColor = ConsoleColor.Red;
//                         Console.WriteLine("ERROR! The file you are trying to read doesn't exist!");
//                         Menu(mainMenu, quit, 1);
//                         break;
//                     }
                    
//                 }
//                 //Write text to file
//                 case '5':
//                 {
//                     Console.WriteLine("Select file to write to:");
//                     string input1 = Console.ReadLine();
//                     Console.WriteLine("Enter the text to write to the file:");
//                     string input2 = Console.ReadLine();

//                     try
//                     {
//                         Console.ForegroundColor = ConsoleColor.Green;
//                         app.WriteTextToFile(input1, input2);
//                         Menu(mainMenu, quit, 1);
//                         break;
//                     }
//                     catch(ArgumentException)
//                     {
//                         Console.ForegroundColor = ConsoleColor.Red;
//                         Console.WriteLine("ERROR! The file you are trying to write to doesn't exist!");
//                         Menu(mainMenu, quit, 1);
//                         break;
//                     }  
//                 }
//                 //search file for text
//                 case '6':
//                 {
//                     Console.WriteLine("Select file to search:");
//                     string input1 = Console.ReadLine();
//                     Console.WriteLine("Enter the text to search for:");
//                     string input2 = Console.ReadLine();
                    
//                     try
//                     {
//                         if(app.SearchForTextInFile(input1, input2) == true)
//                         {
//                             Console.ForegroundColor = ConsoleColor.Green;
//                             Console.WriteLine(input1 + " includes the phrase '" + input2 + "'");
//                             Menu(mainMenu, quit, 1);
//                             break;
//                         }

//                         Console.ForegroundColor = ConsoleColor.Blue;
//                         Console.WriteLine(input1 + " does NOT contain the phrase '" + input2 + "'");
//                         Menu(mainMenu, quit, 1);
//                         break;  
//                     }
//                     catch(ArgumentException)
//                     {
//                         Console.ForegroundColor = ConsoleColor.Red;
//                         Console.WriteLine("ERROR! File path cannot be found!");
//                         Menu(mainMenu, quit, 1);
//                         break;
//                     }
//                 }
//                 //Return to menu
//                 case 'm':
//                 {
//                     Menu(mainMenu, quit, 1);
//                     break;
//                 }
//                 //else
//                 default:
//                 {
//                     Console.ForegroundColor = ConsoleColor.Red;
//                     Console.WriteLine("Invalid command! Please try again.");
//                     Menu(filesMenu, menu, 2);
//                     break;
//                 }
//             }
//         }

//         private static void ManageFolders(char response)
//         {
//             AppHelper app = new AppHelper();
//             string[] mainMenu = {"Get list of files in directory", "Get list of folders in directory", "Manage files", "Manage folders", "Generate index file"};
//             string[] foldersMenu = {"Create folder", "Delete folder"};

//             switch(response)
//             {
//                 //Create Folder
//                 case '1':
//                 {
//                     Console.WriteLine("Enter the path for the folder you wish to create:");
//                     string input = Console.ReadLine();

//                     try
//                     {
//                         Console.ForegroundColor = ConsoleColor.Green;
//                         app.CreateNewFolder(input);
//                         Console.WriteLine("SUCCESS! New folder created at " + input);
//                         Menu(mainMenu, quit, 1);
//                         break;
//                     }

//                     catch(ArgumentException)
//                     {
//                         Console.ForegroundColor = ConsoleColor.Red;
//                         Console.WriteLine("ERROR! The requested directory path is invalid!");
//                         Menu(mainMenu, quit, 1);
//                         break;
//                     }
//                 }
//                 //Delete Folder
//                 case '2':
//                 {
//                     Console.WriteLine("WARNING! This function will permenantly delete the specified folder and everything contained within. To cancel, enter 'C'.");
//                     Console.WriteLine("Enter the path of the folder you wish to delete:");
//                     string input = Console.ReadLine();

//                     if(input == "c" || input == "C")
//                     {
//                         Menu(mainMenu, quit, 1);
//                     }

//                     try
//                     {
//                         app.RemoveFolder(input, true);

//                         if(app.CheckFolderExists(input) == false)
//                         {   
//                             Console.ForegroundColor = ConsoleColor.Green;
//                             Console.WriteLine("SUCCESS! The specified folder has been removed.");
//                             Menu(mainMenu, quit, 1);
//                         }

//                         Console.ForegroundColor = ConsoleColor.Red;
//                         Console.WriteLine("ERROR! The specified folder could not be removed.");
//                         Menu(mainMenu, quit, 1);
//                         break;
//                     }
//                     catch(ArgumentException)
//                     {
//                         Console.ForegroundColor = ConsoleColor.Red;
//                         Console.WriteLine("ERROR! The folder you are trying to remove does not exist");
//                         Menu(mainMenu, quit, 1);
//                         break;
//                     }
//                 }
//                 //Return to menu
//                 case 'm':
//                 {
//                     Menu(mainMenu, quit, 1);
//                     break;
//                 }
//                 //else
//                 default:
//                 {
//                     Console.WriteLine("Invalid command! Please try again.");
//                     Menu(foldersMenu, menu, 3);
//                     break;
//                 }
//             }
//         }
//     }
// }