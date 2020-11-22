using System;
using System.Data.SqlClient;
using InterviewQuestions.DAL;
using InterviewQuestions.Model;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Collections.Generic;

namespace InterviewQuestions
{
    public class Program
    {
        public Program(){

        }
        
        static void Main(string[] args)
        {
            GetAppSettingsFile(); 
            Program prg = new Program();
            bool keepGoing = true;
            while (keepGoing){
               keepGoing = prg.DisplayMenu();                  
            }        
        } 

        private static IConfiguration _iconfiguration;

        private FooDAL FooService {get; set;}
        static void GetAppSettingsFile()  
        {  
                    var builder = new ConfigurationBuilder()  
                        .SetBasePath(Directory.GetCurrentDirectory())  
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);  
                        _iconfiguration = builder.Build();  

 
        } 

        public bool DisplayMenu()
        {
            string displayAnswer = string.Empty;

            Console.WriteLine("Select Problem Type");
            Console.WriteLine(" 1 Code Problems");
            Console.WriteLine(" 2 Terms");
            Console.WriteLine(" 3) Database Problems");
            Console.WriteLine(" X) Exit this Application");
            Console.Write("Enter selection: ");
            displayAnswer = Console.ReadLine(); 

            bool levelTwoFlag = true;               

            switch (displayAnswer)
            {
                case "1":
                    while ( levelTwoFlag == true)
                    {
                        levelTwoFlag = CodeMenu();
                    }
                    break;
                case "2":
                    break;
                case "3":
                    while(levelTwoFlag){
                        levelTwoFlag = DbMenu();
                    }
                    break;
                case "x":
                case "X":
                    return false;
                default:
                    break;
            }
            return true;     
        }

        public bool CodeMenu()
        {
            string codeAnswer = "";
            Console.Clear();
            Console.WriteLine("Enter the number for the routine to run (Ctrl-C to End):");
            Console.WriteLine(" 1) Segreate Array of 0 and 1's with 0's on left and 1's on right");
            Console.WriteLine(" 2) Find maximum consecutive repeating character in string");
            Console.WriteLine(" 3) Is Binary Tree a Binary Search Tree");
            Console.WriteLine(" 4) Check a string to see if it has all Unique Charcters");
            Console.WriteLine(" 5) Reverse the order of a string");

            Console.WriteLine(" X) Exit the Code Menu");
            Console.Write("Enter selection: ");
            codeAnswer = Console.ReadLine();                

            switch (codeAnswer) 
            {
                case "1": //Segregate a 0 and 1 array: segregate0and1
                    int []arr = new int[]{0,1, 0,0, 0, 0, 0, 1,1}; 
                    int i, arr_size = arr.Length; 
                    Console.WriteLine("Array Before segregation is "); 
                    for (i = 0; i < arr.Length; i++) 
                        Console.Write(arr[i] + " ");
                    Console.WriteLine("");

                    segregate0and1(arr, arr_size); 

                    Console.WriteLine("Array after segregation is "); 
                    for (i = 0; i < arr.Length; i++) 
                        Console.Write(arr[i] + " ");
                    Console.WriteLine("");
                    break;                        
                case "2"://Find Max repeating Character: maxRepeatingCharter()
                    var str = "aaaabbaaccde"; 
                    Console.WriteLine($"\nFind maximum consecutive repeating character in string: {str}");
                    Console.Write($"Answer is: {maxRepeatingCharacter(str)}");
                    break;
                case "3": //is Tree a Binary Search Tree: isValidBst()
                    var bfsTree = new TreeNode(1){
                        Left = new TreeNode(2){Left= new TreeNode(4), Right = new TreeNode(5)},
                        Right = new TreeNode(3)}; //answer is false

                    var bstTree = new TreeNode(4){
                        Left = new TreeNode(2){Left = new TreeNode(1), Right = new TreeNode(3)},
                        Right = new TreeNode(5) }; //answer is true DFS INORDER

                    var dfsPostOrder = new TreeNode(5){
                        Left = new TreeNode(3){ Left = new TreeNode(1), Right = new TreeNode(2)},
                        Right = new TreeNode(4)}; //amswer is false

                        var dfsPreOrder = new TreeNode(1){
                        Left = new TreeNode(2){ Left = new TreeNode(3), Right = new TreeNode(4)},
                        Right = new TreeNode(5)}; //amswer is false    

                    var bstTree2 = new TreeNode(4){
                        Left = new TreeNode(2){Left = new TreeNode(1), Right = new TreeNode(3)},
                        Right = new TreeNode(6) {Left = new TreeNode(5), Right = new TreeNode(7)} }; //answer is true DFS INORDER

                    Console.WriteLine($"\nIs bfsTree a Binary Search Tree?\nAnswer is: {isValidBst(bfsTree)}");
                    Console.WriteLine($"\nIs bfsTree a Binary Search Tree?\nAnswer is: {isValidBst(bstTree)}");
                    Console.WriteLine($"\nIs dfsPostOrder a Binary Search Tree?\nAnswer is: {isValidBst(dfsPostOrder)}\n");
                    Console.WriteLine($"\nIs dfsPreOrder a Binary Search Tree?\nAnswer is: {isValidBst(dfsPreOrder)}\n");
                    Console.WriteLine($"\nIs bstTree2 a Binary Search Tree?\nAnswer is: {isValidBst(bstTree2)}\n");

                    break;
                case "4": //check string to see if it contains all unique Characters: uniqueCharacters
                    foreach(var input in new string[]{"GeekforGeeks","NOTforGEeks"})
                    {
                        Console.WriteLine($"\nChecking the input string: {input} has all unique characters:");
                
                        if (uniqueCharacters(input)) {
                            Console.WriteLine($"Answer: \"{input}\"  has all unique characters");
                        }
                        else {
                            Console.WriteLine($"Answer: \"{input}\" has duplicate characters");
                        }
                    }

                    break;
                case "5": //Reverse a string:  ReverseString()
                    bool isRunning = true;
                    while(isRunning==true)
                    {
                        Console.Write("\nEnter text to reverse (Submit EXIT to stop): ");
                        var test = Console.ReadLine();
                        if(test == "EXIT"){
                            isRunning = false;
                            continue;
                        }
                        Console.WriteLine($"Reversed Text of \"{test}\" is \"{ReverseString(test)}\" ");
                    }
                    break;
                case "6":
                    break;

                case "x":
                case "X":
                    Console.Clear();
                    return false;
                default:
                    break;
            }
            Console.WriteLine("");
            Console.Write("Press any key to continue: ");
            Console.ReadKey();
            return true;
   
        }

        private bool DbMenu()
        {
            string dbAnswer = "";
            Console.Clear();
            Console.WriteLine("Select Problem Type");
            Console.WriteLine(" 1) Database Connection string");
            Console.WriteLine(" 2) foo table: Find all users who completed Launch, Checked, Submit events");
            Console.WriteLine(" 3) foo table: Find all users who completed only one Event and the event");
            Console.WriteLine(" X) Exit the DB Menu");
            Console.Write("Enter selection: ");
            dbAnswer = Console.ReadLine(); 

            //bool levelTwoFlag = true;               

            switch (dbAnswer)
            {
                case "1":
                    Console.WriteLine($"{GetConnectionString()}");
                    EndOfAnswer();
                    break;
                case "2":
                    var listOfUsers = RetrieveFooUsersWithAllEvents();
                    DumpQuery(1);
                    DumpTable(1);
                    if(listOfUsers.Count > 0){
                        Console.WriteLine("User that have all three Events are:");
                        foreach(var user in listOfUsers){
                            Console.WriteLine($"UserId: {user.UserId}");
                        }                        
                    }
                    else{
                        Console.WriteLine("No users have completed all three Events");
                    }
                    EndOfAnswer();
                    break;
                case "x":
                case "X":
                    Console.Clear();
                    return false;                    
                default:
                    break;
            }            
            return true;
        }

        private string GetConnectionString()
        {
            FooService = FooService ?? new FooDAL(_iconfiguration);
            return FooService.GetConnectionString();
        }
        
        private List<FooModel> RetrieveFooUsersWithAllEvents(){
            FooService = FooService ?? new FooDAL(_iconfiguration);
            return FooService.GetFooUsersWithAllEvents();
        }


        #region  Code Functions
        static void segregate0and1(int []arr, int size)  
        { 
            /* Initialize left and right indexes */
            int i, left = 0, right = size - 1; 
  
            while (left < right)  
            { 
                Console.WriteLine($"Begining of While Loop: Left is: {left} Right is: {right} ");
                /* Increment left index while 
                we see 0 at left  i.e. find next one going left while less than right*/
                while (arr[left] == 0 && left < right) 
                {
                    left++;
                    Console.WriteLine($"In Left Shift Loop. Left is: {left} Right is: {right} ");                    
                }

    
                /* Decrement right index while  
                we see 1 at right  i.e. find next zero going right while greter than left */
                while (arr[right] == 1 && left < right) 
                {
                    right--; 
                    Console.WriteLine($"In Right Shift Loop. Left is: {left} Right is: {right} ");                    


                }
    
                /* If left is smaller than right then 
                there is a 1 at left and a 0 at right.  
                Exchange arr[left] and arr[right]*/
                if (left < right)  
                {
                    arr[left] = 0; 
                    arr[right] = 1; 
                    left++; 
                    right--; 
                    Console.Write("In If statment togtle values at positions left and right. Array is: ");
                    for (i = 0; i < arr.Length; i++) 
                        Console.Write(arr[i] + " "); 
                    Console.WriteLine(""); 
                   Console.WriteLine($"In If Statement. Left is: {left} Right is: {right} ");                    
                } 
            } 
        }
    
        static char maxRepeatingCharacter(string str) 
        { 
            int len = str.Length; 
            int count = 0; 
            char res = str[0]; 
            
            // Find the maximum repeating  
            // character starting from str[i] 
            for (int i = 0; i < len; i++) 
            { 
                int cur_count = 1; 
                for (int j = i + 1; j < len; j++) 
                { 
                    if (str[i] != str[j]) 
                        break; 
                    cur_count++; 
                } 
        
                // Update result if required 
                if (cur_count > count) 
                { 
                    count = cur_count; 
                    res = str[i]; 
                } 
            } 
            return res; 
        }    

        static bool isValidBst(TreeNode root)
        {
            return bstHelper(root, null, null);
        }

        static bool bstHelper(TreeNode node, int? lower, int? upper)
        {
            if (node == null) return true;

            int val = node.Val;
            if (lower != null && val <= lower) return false;
            if (upper != null && val >= upper) return false;

            if (! bstHelper(node.Right, val, upper)) return false;
            if (! bstHelper(node.Left, lower, val)) return false;
            return true;            
        }

        static int FindFibonacci(int n)
        {
            int firstnum = 0, secondnum = 1, result =0;
            if (n == 0) return 0; //It will return the first number of the series
            if (n == 1) return 1; // it will return  the second number of the series
            for (int i = 2; i<= n; i++)  // main processing starts from here
            {
                result = firstnum + secondnum;
                firstnum = secondnum;
                secondnum = result;
            }
            return result;
        }

        static bool uniqueCharacters(string str)
        {
            // if string is limited to lower case letters an
            // integer could be used instead of an array
            // Checking values would be checkerInt & (1 << bitAtIndex)) > 0
            // Setting values would be checkerInt = checkerInt | (1 << bitAtIndex);
            int MAX_CHAR = 256;
            // If length is greater than 256,
            // some characters must have been repeated
            if (str.Length > MAX_CHAR)
                return false;
    
            bool[] chars = new bool[MAX_CHAR];
            for (int i = 0; i < MAX_CHAR; i++) {
                chars[i] = false;
            }
            for (int i = 0; i < str.Length; i++) {
                int index = (int)str[i];
    
                /* If the value is already true, string
                has duplicate characters, return false */
                if (chars[index] == true)
                    return false;
    
                chars[index] = true;
            }
    
            /* No duplicates encountered, return true */
            return true;
        }   

        public string ReverseString(string myStr)
        {
            char[] myArr = myStr.ToCharArray();
            Array.Reverse(myArr);
            return new string(myArr);
        }
#endregion
        private void EndOfAnswer(){
            Console.WriteLine("");
            Console.Write("Press any key to continue");
            Console.ReadKey();
        }

#region DB Utilities
        private void DumpQuery(int queryNumber){
            Console.WriteLine("Query Executed was:");
            Console.WriteLine("");
            switch(queryNumber){
                case 1:
                    Console.WriteLine("use MsProblems; ");
                    Console.WriteLine("select distinct a.UserId from foo a ");
                    Console.WriteLine("inner join (select count(*)cnt, UserId from foo ");
                    Console.WriteLine("where Event in ('Launch', 'Checked','Submit') ");
                    Console.WriteLine("group by UserId ");
                    Console.WriteLine("having count(*) = 3)b on a.UserId = b.UserId");
                    break;
                default:
                    Console.WriteLine("NOT FOUND in the list of Queries");
                    break;
            }
            Console.WriteLine("");
            Console.WriteLine("");
        }
        private void DumpTable(int tableNumber){
            Console.WriteLine("");
            switch (tableNumber){
                case 1:{
                    int[] fieldLengths = new int[]{20,20};
                    string[] fieldNames = new string[]{"UserId","Event"};
                    FooService = FooService ?? new FooDAL(_iconfiguration);
                    List<FooModel> list =  FooService.ListFooTable();               
                    PrintDbTableHeader(fieldLengths, fieldNames);

                    foreach(var listItem in list){

                        Console.Write($"|");
                        PrintDbFieldColumn(fieldLengths[0],listItem.UserId);
                        PrintDbFieldColumn(fieldLengths[1], listItem.Event);
                        Console.WriteLine("");                        
                        PrintDbTableBoarder(fieldLengths);
                    }

                    break;
                }
                default:
                    Console.WriteLine("NOT FOUND: The Table is not in the list of tables");
                    break;
            }
            Console.WriteLine("");
            Console.WriteLine("");
        }

        private void PrintDbTableHeader(int[] fieldLengths, string[] fieldNames)
        {
            if(fieldLengths.Length != fieldNames.Length){
                Console.WriteLine($"**** ERROR: length of FieldLengths array ({fieldLengths.Length}) not equal to length of FieldNames array ({fieldNames.Length})");
                Console.WriteLine("");
                return;
            }
            PrintDbTableBoarder(fieldLengths);
            PrintDbTableRow(fieldLengths,fieldNames,true);
            PrintDbTableBoarder(fieldLengths);
        }
        
        private void PrintDbTableBoarder(int[] fieldLengths){
            Console.Write("+");
            foreach(var len in fieldLengths){
                for(var i = 0; i < len; i++)
                    Console.Write("-");
                Console.Write("+");
            }
            Console.WriteLine("");

        }

        private void PrintDbTableRow(int[] fieldLengths, string[] fieldVals, bool isHeader = false){
            Console.Write("|");
            for( var i = 0; i < fieldLengths.Length; i++)
                PrintDbFieldColumn(fieldLengths[1],fieldVals[i],isHeader);
            Console.WriteLine("");
            
            

        }

        private void PrintDbFieldColumn(int fieldLength, string fieldValue, bool isHeader = false){

            var preFieldPadLength = isHeader ? Convert.ToInt32(Math.Floor(Convert.ToDouble((fieldLength-fieldValue.Length)/2))) : 2;
            preFieldPadLength = preFieldPadLength < 0 ? 0 : preFieldPadLength;
            for(var i = 0; i < preFieldPadLength; i++)
                Console.Write(" ");
            Console.Write(fieldValue);
            for(var i = 0; i < Convert.ToInt32((fieldLength-preFieldPadLength - fieldValue.Length)); i++)
                Console.Write(" ");
            Console.Write("|");
        }

#endregion
    } 

#region misc Classes    
    // Definition for a binary tree node.
    public class TreeNode
    {
        public int Val {get; set;}
        public TreeNode Left {get; set;}
        public TreeNode Right {get; set;}

        public TreeNode(int X)
        {
            Val = X;
        }
    }
#endregion

}
