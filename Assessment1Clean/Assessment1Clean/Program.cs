using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1Clean
{
    //use merge sort for the 128 arrays because its slow DONE 
    //Quicksort for 1024 as it takes no additional space and is fast. Also to be used before doing a binary search
    //Insertion sort for 256 because its easy to implement DONE

    public class Program
    {
        public string[] Close128S, Change128S, Open128S, High128S, Low128S, Close256S, Change256S, Open256S, High256S, Low256S, Close1024S, Change1024S, Open1024S, High1024S, Low1024S;
        public double[] Close128, Change128, Open128, High128, Low128, Close256, Change256, Open256, High256, Low256, Close1024, Change1024, Open1024, High1024, Low1024;

        public void ConvertArrayToDouble(string[] s, double[] i)
        {
            for (int n = 0; n < s.Length; n++)
            {
                i[n] = Convert.ToDouble(s[n]); //0(N)
               
            }
        }

        public class UserChoices
        {
            public string dataFile, searchOrSort, sortStyle; //file you want to use, choice to search or sort, and sort ascending or descending
            public double numSearch; //number you wish to search for

            public void Welcome()
            {
                Console.WriteLine("This program lets you search and sort bank data files of 128, 256 and 1024 size.");
                Console.WriteLine("Enter the file type (close, change, open, high, low)");
                string FileType = Console.ReadLine();

                Console.WriteLine("Enter the file size you would like to use (128, 256, 1024)");
                string FileSize = Console.ReadLine();

                dataFile = FileType + FileSize; //Concatenate the two strings. Done for usability
                Console.WriteLine("Data chosen is {0}", dataFile);

                Console.WriteLine("Enter whether you would like to search or sort. (search/sort)");
                searchOrSort = Console.ReadLine();

                if (searchOrSort == "search")
                {
                    Console.WriteLine("Choose a number to search for");
                    numSearch = Convert.ToDouble(Console.ReadLine());
                }
                else if (searchOrSort == "sort")
                {
                    Console.WriteLine("Sort in ascending or descending order? (a/d)");
                    sortStyle = (Console.ReadLine());
                }

                if (dataFile.Contains("128")) //Directs the program to the correct method depending on which file was chosen
                {
                   Data128(dataFile, searchOrSort);
                }
                
                else if (dataFile.Contains("256"))
                {
                    Data256(dataFile,searchOrSort);
                }
                else if (dataFile.Contains("1024"))
                {
                    Data1024(dataFile, searchOrSort);
                }
                
            }

            public void Data128(string dataFile, string searchOrSort)
            {
                Program p = new Program();
            
                //-----------CLOSE128---------------//
                if ((dataFile == "close128") && (searchOrSort == "search"))
                {
                    //read into array
                    p.Close128S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Close_128.txt");
                    //change into double array
                    p.Close128 = new double[p.Close128S.Length];
                    p.ConvertArrayToDouble(p.Close128S, p.Close128);
                    //sort array and search using binary search
                    Algorithms.QuickSort.QuickSortBuffer(p.Close128);
                    Console.WriteLine("Number of Steps taken by QuickSort: {0}", Algorithms.QuickSort.numOfQuickSortSteps);
                    Algorithms.BinarySearch.BinarySearchBuffer(p.Close128, numSearch);
                    Console.WriteLine("Number of Steps taken by BinarySearch: {0}", Algorithms.BinarySearch.numOfStepsBinarySearch);
                }
                else if ((dataFile == "close128") && (searchOrSort == "sort"))
                {
                    if (sortStyle == "a")
                    {
                        //read file into array 
                        p.Close128S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Close_128.txt");
                        //change into double array
                        p.Close128 = new double[p.Close128S.Length];
                        p.ConvertArrayToDouble(p.Close128S, p.Close128);
                        //Sort Close 128 ascendingly
                        Algorithms.MergeSort.MergeSortBuffer(p.Close128);
                        //Print sorted array
                        Console.WriteLine("Close128 sorted ascendingly:");
                        p.Close128.ToList().ForEach(Console.WriteLine);
                        Console.WriteLine("Number of Steps taken by MergeSort: {0}", Algorithms.MergeSort.numOfMergeSteps);
                
                    }
                    else if (sortStyle == "d")
                    {
                        
                        p.Close128S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Close_128.txt");
                        p.Close128 = new double[p.Close128S.Length];
                        p.ConvertArrayToDouble(p.Close128S, p.Close128);
                        //sort array
                        p.Close128.ToList().ForEach(Algorithms.BinaryTree.Tree.InsertBuffer);
                        //print descending array
                        Console.WriteLine("Close128 sorted decendingly:");
                        Algorithms.BinaryTree.Tree.PrintData();
                        Console.WriteLine("Number of Steps taken by BinaryTree: {0}", Algorithms.BinaryTree.numOfTreeSteps);
                    }
                }
                //---------CHANGE128---------//
                if ((dataFile == "change128") && (searchOrSort == "search"))
                {
                    p.Change128S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Change_128.txt");
                    p.Change128 = new double[p.Change128S.Length];
                    p.ConvertArrayToDouble(p.Change128S, p.Change128);
                    
                    Algorithms.QuickSort.QuickSortBuffer(p.Change128);
                    Console.WriteLine("Number of Steps taken by QuickSort: {0}", Algorithms.QuickSort.numOfQuickSortSteps);
                    Algorithms.BinarySearch.BinarySearchBuffer(p.Change128, numSearch);
                    Console.WriteLine("Number of Steps taken by Binary Search: {0}", Algorithms.BinarySearch.numOfStepsBinarySearch);
                }
                else if ((dataFile == "change128") && (searchOrSort == "sort"))
                {
                    if (sortStyle == "a")
                    {
                        
                        p.Change128S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Change_128.txt");
                        p.Change128 = new double[p.Change128S.Length];
                        p.ConvertArrayToDouble(p.Change128S, p.Change128);
      
                        Algorithms.MergeSort.MergeSortBuffer(p.Change128);
                        Console.WriteLine("Change128 sorted ascendingly:");
                        p.Change128.ToList().ForEach(Console.WriteLine);
                        Console.WriteLine("Number of Steps taken by MergeSort: {0}", Algorithms.MergeSort.numOfMergeSteps);
                    }
                    else if (sortStyle == "d")
                    {
                        p.Change128S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Change_128.txt");
                        p.Change128 = new double[p.Change128S.Length];
                        p.ConvertArrayToDouble(p.Change128S, p.Change128);

                        p.Change128.ToList().ForEach(Algorithms.BinaryTree.Tree.InsertBuffer);
                        Console.WriteLine("Change128 sorted decendingly:");
                        p.Close128.ToList().ForEach(Console.WriteLine);
                        Console.WriteLine("Number of Steps taken by BinaryTree: {0}", Algorithms.BinaryTree.numOfTreeSteps);
                    }
                }

                if ((dataFile == "open128") && (searchOrSort == "search"))
                {
                    p.Open128S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Open_128.txt");
                    p.Open128 = new double[p.Open128S.Length];
                    p.ConvertArrayToDouble(p.Open128S, p.Open128);

                    Algorithms.QuickSort.QuickSortBuffer(p.Open128);
                    Console.WriteLine("Number of Steps taken by QuickSort: {0}", Algorithms.QuickSort.numOfQuickSortSteps);
                    Algorithms.BinarySearch.BinarySearchBuffer(p.Open128, numSearch);
                    Console.WriteLine("Number of Steps taken by Binary Search: {0}", Algorithms.BinarySearch.numOfStepsBinarySearch);
                }
                else if ((dataFile == "open128") && (searchOrSort == "sort"))
                {
                    if (sortStyle == "a")
                    {
                        p.Open128S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Open_128.txt");
                        p.Open128 = new double[p.Open128S.Length];
                        p.ConvertArrayToDouble(p.Open128S, p.Open128);

                        Algorithms.MergeSort.MergeSortBuffer(p.Open128);
                        Console.WriteLine("Open128 sorted ascendingly:");
                        p.Open128.ToList().ForEach(Console.WriteLine);
                        Console.WriteLine("Number of Steps taken by MergeSort: {0}", Algorithms.MergeSort.numOfMergeSteps);
                    }
                    else if (sortStyle == "d")
                    {
                        p.Open128S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Open_128.txt");
                        p.Open128 = new double[p.Open128S.Length];
                        p.ConvertArrayToDouble(p.Open128S, p.Open128);

                        p.Open128.ToList().ForEach(Algorithms.BinaryTree.Tree.InsertBuffer);
                        Console.WriteLine("Open128 sorted decendingly:");
                        Algorithms.BinaryTree.Tree.PrintData();
                        Console.WriteLine("Number of Steps taken by BinaryTree: {0}", Algorithms.BinaryTree.numOfTreeSteps);
                    }
                }

                if ((dataFile == "high128") && (searchOrSort == "search"))
                {
                    p.High128S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\High_128.txt");
                    p.High128 = new double[p.High128S.Length];
                    p.ConvertArrayToDouble(p.High128S, p.High128);

                    Algorithms.QuickSort.QuickSortBuffer(p.High128);
                    Console.WriteLine("Number of Steps taken by QuickSort: {0}", Algorithms.QuickSort.numOfQuickSortSteps);
                    Algorithms.BinarySearch.BinarySearchBuffer(p.High128, numSearch);
                    Console.WriteLine("Number of Steps taken by Binary Search: {0}", Algorithms.BinarySearch.numOfStepsBinarySearch);
                }
                else if ((dataFile == "high128") && (searchOrSort == "sort"))
                {
                    if (sortStyle == "a")
                    {
                        p.High128S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\High_128.txt");
                        p.High128 = new double[p.High128S.Length];
                        p.ConvertArrayToDouble(p.High128S, p.High128);
                    
                        Algorithms.MergeSort.MergeSortBuffer(p.High128);
                        Console.WriteLine("High128 sorted ascendingly:");
                        p.High128.ToList().ForEach(Console.WriteLine);
                        Console.WriteLine("Number of Steps taken by MergeSort: {0}", Algorithms.MergeSort.numOfMergeSteps);
                    }
                    else if (sortStyle == "d")
                    {
                        p.High128S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\High_128.txt");
                        p.High128 = new double[p.High128S.Length];
                        p.ConvertArrayToDouble(p.High128S, p.High128);

                        p.High128.ToList().ForEach(Algorithms.BinaryTree.Tree.InsertBuffer);
                        Console.WriteLine("High128 sorted decendingly:");
                        Algorithms.BinaryTree.Tree.PrintData();
                        Console.WriteLine("Number of Steps taken by BinaryTree: {0}", Algorithms.BinaryTree.numOfTreeSteps);
                    }
                }

                if ((dataFile == "low128") && (searchOrSort == "search"))
                {
                    p.Low128S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Low_128.txt");
                    p.Low128 = new double[p.Low128S.Length];
                    p.ConvertArrayToDouble(p.Low128S, p.Low128);

                    Algorithms.QuickSort.QuickSortBuffer(p.Low128);
                    Console.WriteLine("Number of Steps taken by QuickSort: {0}", Algorithms.QuickSort.numOfQuickSortSteps);
                    Algorithms.BinarySearch.BinarySearchBuffer(p.Low128, numSearch);
                    Console.WriteLine("Number of Steps taken by Binary Search: {0}", Algorithms.BinarySearch.numOfStepsBinarySearch);
                }
                else if ((dataFile == "low128") && (searchOrSort == "sort"))
                {
                    if (sortStyle == "a")
                    {
                        p.Low128S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Low_128.txt");
                        p.Low128 = new double[p.Low128S.Length];
                        p.ConvertArrayToDouble(p.Low128S, p.Low128);
                     
                        Algorithms.MergeSort.MergeSortBuffer(p.Low128);
                        Console.WriteLine("Low128 sorted ascendingly:");
                        p.Low128.ToList().ForEach(Console.WriteLine);
                        Console.WriteLine("Number of Steps taken by MergeSort: {0}", Algorithms.MergeSort.numOfMergeSteps);
                    }
                    else if (sortStyle == "d")
                    {
                        p.Low128S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Low_128.txt");
                        p.Low128 = new double[p.Low128S.Length];
                        p.ConvertArrayToDouble(p.Low128S, p.Low128);

                        p.High128.ToList().ForEach(Algorithms.BinaryTree.Tree.InsertBuffer);
                        Console.WriteLine("Low128 sorted decendingly:");
                        Algorithms.BinaryTree.Tree.PrintData();
                        Console.WriteLine("Number of Steps taken by BinaryTree: {0}", Algorithms.BinaryTree.numOfTreeSteps);
                    }
                }
            }
            //-----DATA 256---/
            public void Data256(string dataFile, string searchOrSort)
            {
                Program p = new Program();

                if ((dataFile == "close256") && (searchOrSort == "search"))
                {
                    p.Close256S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Close_256.txt");
                    p.Close256 = new double[p.Close256S.Length];
                    p.ConvertArrayToDouble(p.Close256S, p.Close256);

                    Algorithms.QuickSort.QuickSortBuffer(p.Close256);
                    Console.WriteLine("Number of Steps taken by QuickSort: {0}", Algorithms.QuickSort.numOfQuickSortSteps);
                    Algorithms.BinarySearch.BinarySearchBuffer(p.Close256, numSearch);
                    Console.WriteLine("Number of Steps taken by Binary Search: {0}", Algorithms.BinarySearch.numOfStepsBinarySearch);
                }
                else if ((dataFile == "close256") && (searchOrSort == "sort"))
                {
                    if (sortStyle == "a")
                    {
                        p.Close256S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Close_256.txt");
                        p.Close256 = new double[p.Close256S.Length];
                        p.ConvertArrayToDouble(p.Close256S, p.Close256);

                        Algorithms.InsertionSort.Insertion_Sort(p.Close256);
                        Console.WriteLine("Close256 sorted ascendingly:");
                        p.Close256.ToList().ForEach(Console.WriteLine);
                        Console.WriteLine("Number of Steps taken by Insertion Sort: {0}", Algorithms.InsertionSort.numOfInsertionSteps);
                        
                    }
                    else if (sortStyle == "d")
                    {
                        p.Close256S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Close_256.txt");
                        p.Close256 = new double[p.Close256S.Length];
                        p.ConvertArrayToDouble(p.Close256S, p.Close256);

                        p.Close256.ToList().ForEach(Algorithms.BinaryTree.Tree.InsertBuffer);
                        Console.WriteLine("Close256 sorted decendingly:");
                        Algorithms.BinaryTree.Tree.PrintData();
                        Console.WriteLine("Number of Steps taken by BinaryTree: {0}", Algorithms.BinaryTree.numOfTreeSteps);
                    }
                }

                if ((dataFile == "change256") && (searchOrSort == "search"))
                {
                    p.Change256S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Change_256.txt");
                    p.Change256 = new double[p.Change256S.Length];
                    p.ConvertArrayToDouble(p.Change256S, p.Change256);

                    Algorithms.QuickSort.QuickSortBuffer(p.Change256);
                    Console.WriteLine("Number of Steps taken by QuickSort: {0}", Algorithms.QuickSort.numOfQuickSortSteps);
                    Algorithms.BinarySearch.BinarySearchBuffer(p.Change256, numSearch);
                    Console.WriteLine("Number of Steps taken by Binary Search: {0}", Algorithms.BinarySearch.numOfStepsBinarySearch);
                }
                else if ((dataFile == "change256") && (searchOrSort == "sort"))
                {
                    if (sortStyle == "a")
                    {
                        p.Change256S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Change_256.txt");
                        p.Change256 = new double[p.Change256S.Length];
                        p.ConvertArrayToDouble(p.Change256S, p.Change256);

                        Algorithms.InsertionSort.Insertion_Sort(p.Change256);
                        Console.WriteLine("Change256 sorted ascendingly:");
                        p.Change256.ToList().ForEach(Console.WriteLine);
                        Console.WriteLine("Number of Steps taken by Insertion Sort: {0}", Algorithms.InsertionSort.numOfInsertionSteps);

                    }
                    else if (sortStyle == "d")
                    {
                        p.Change256S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Change_256.txt");
                        p.Change256 = new double[p.Change256S.Length];
                        p.ConvertArrayToDouble(p.Change256S, p.Change256);

                        p.Change256.ToList().ForEach(Algorithms.BinaryTree.Tree.InsertBuffer);
                        Console.WriteLine("Change256 sorted decendingly:");
                        Algorithms.BinaryTree.Tree.PrintData();
                        Console.WriteLine("Number of Steps taken by BinaryTree: {0}", Algorithms.BinaryTree.numOfTreeSteps);
                    }
                }

                if ((dataFile == "open256") && (searchOrSort == "search"))
                {
                    p.Open256S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Open_256.txt");
                    p.Open256 = new double[p.Open256S.Length];
                    p.ConvertArrayToDouble(p.Open256S, p.Open256);

                    Algorithms.QuickSort.QuickSortBuffer(p.Open256);
                    Console.WriteLine("Number of Steps taken by QuickSort: {0}", Algorithms.QuickSort.numOfQuickSortSteps);
                    Algorithms.BinarySearch.BinarySearchBuffer(p.Open256, numSearch);
                    Console.WriteLine("Number of Steps taken by Binary Search: {0}", Algorithms.BinarySearch.numOfStepsBinarySearch);
                }
                else if ((dataFile == "open256") && (searchOrSort == "sort"))
                {
                    if (sortStyle == "a")
                    {
                        p.Open256S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Open_256.txt");
                        p.Open256 = new double[p.Open256S.Length];
                        p.ConvertArrayToDouble(p.Open256S, p.Open256);

                        Algorithms.InsertionSort.Insertion_Sort(p.Open256);
                        Console.WriteLine("Open256 sorted ascendingly:");
                        p.Open256.ToList().ForEach(Console.WriteLine);
                        Console.WriteLine("Number of Steps taken by Insertion Sort: {0}", Algorithms.InsertionSort.numOfInsertionSteps);

                    }
                    else if (sortStyle == "d")
                    {
                        p.Open256S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Open_256.txt");
                        p.Open256 = new double[p.Open256S.Length];
                        p.ConvertArrayToDouble(p.Open256S, p.Open256);

                        p.Open256.ToList().ForEach(Algorithms.BinaryTree.Tree.InsertBuffer);
                        Console.WriteLine("Open256 sorted decendingly:");
                        Algorithms.BinaryTree.Tree.PrintData();
                        Console.WriteLine("Number of Steps taken by BinaryTree: {0}", Algorithms.BinaryTree.numOfTreeSteps);
                    }
                }

                if ((dataFile == "high256") && (searchOrSort == "search"))
                {
                    p.High256S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\High_256.txt");
                    p.High256 = new double[p.High256S.Length];
                    p.ConvertArrayToDouble(p.High256S, p.High256);

                    Algorithms.QuickSort.QuickSortBuffer(p.High256);
                    Console.WriteLine("Number of Steps taken by QuickSort: {0}", Algorithms.QuickSort.numOfQuickSortSteps);
                    Algorithms.BinarySearch.BinarySearchBuffer(p.High256, numSearch);
                    Console.WriteLine("Number of Steps taken by Binary Search: {0}", Algorithms.BinarySearch.numOfStepsBinarySearch);
                }
                else if ((dataFile == "high256") && (searchOrSort == "sort"))
                {
                    if (sortStyle == "a")
                    {
                        p.High256S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\High_256.txt");
                        p.High256 = new double[p.High256S.Length];
                        p.ConvertArrayToDouble(p.High256S, p.High256);

                        Algorithms.InsertionSort.Insertion_Sort(p.High256);
                        Console.WriteLine("High256 sorted ascendingly:");
                        p.High256.ToList().ForEach(Console.WriteLine);
                        Console.WriteLine("Number of Steps taken by Insertion Sort: {0}", Algorithms.InsertionSort.numOfInsertionSteps);

                    }
                    else if (sortStyle == "d")
                    {
                        p.High256S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\High_256.txt");
                        p.High256 = new double[p.High256S.Length];
                        p.ConvertArrayToDouble(p.High256S, p.High256);

                        p.High256.ToList().ForEach(Algorithms.BinaryTree.Tree.InsertBuffer);
                        Console.WriteLine("High256 sorted decendingly:");
                        Algorithms.BinaryTree.Tree.PrintData();
                        Console.WriteLine("Number of Steps taken by BinaryTree: {0}", Algorithms.BinaryTree.numOfTreeSteps);
                    }
                }

                if ((dataFile == "low256") && (searchOrSort == "search"))
                {
                    p.Low256S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Low_256.txt");
                    p.Low256 = new double[p.Low256S.Length];
                    p.ConvertArrayToDouble(p.Low256S, p.Low256);

                    Algorithms.QuickSort.QuickSortBuffer(p.Low256);
                    Console.WriteLine("Number of Steps taken by QuickSort: {0}", Algorithms.QuickSort.numOfQuickSortSteps);
                    Algorithms.BinarySearch.BinarySearchBuffer(p.Low256, numSearch);
                    Console.WriteLine("Number of Steps taken by Binary Search: {0}", Algorithms.BinarySearch.numOfStepsBinarySearch);
                }
                else if ((dataFile == "low256") && (searchOrSort == "sort"))
                {
                    if (sortStyle == "a")
                    {
                        p.Low256S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Low_256.txt");
                        p.Low256 = new double[p.Low256S.Length];
                        p.ConvertArrayToDouble(p.Low256S, p.Low256);

                        Algorithms.InsertionSort.Insertion_Sort(p.Low256);
                        Console.WriteLine("Low256 sorted ascendingly:");
                        p.Low256.ToList().ForEach(Console.WriteLine);
                        Console.WriteLine("Number of Steps taken by Insertion Sort: {0}", Algorithms.InsertionSort.numOfInsertionSteps);
                    }
                    else if (sortStyle == "d")
                    {
                        p.Low256S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Low_256.txt");
                        p.Low256 = new double[p.Low256S.Length];
                        p.ConvertArrayToDouble(p.Low256S, p.Low256);

                        p.Low256.ToList().ForEach(Algorithms.BinaryTree.Tree.InsertBuffer);
                        Console.WriteLine("Low256 sorted decendingly:");
                        Algorithms.BinaryTree.Tree.PrintData();
                        Console.WriteLine("Number of Steps taken by BinaryTree: {0}", Algorithms.BinaryTree.numOfTreeSteps);
                    }
                }
            }
            //------DATA 1024---//
            public void Data1024(string dataFile, string searchOrSort)
            {
                Program p = new Program();
                Algorithms a = new Algorithms();

                if ((dataFile == "close1024") && (searchOrSort == "search"))
                {
                    p.Close1024S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Close_1024.txt");
                    p.Close1024 = new double[p.Close1024S.Length];
                    p.ConvertArrayToDouble(p.Close1024S, p.Close1024);

                    Algorithms.QuickSort.QuickSortBuffer(p.Close1024);
                    Console.WriteLine("Number of Steps taken by QuickSort: {0}", Algorithms.QuickSort.numOfQuickSortSteps);
                    Algorithms.BinarySearch.BinarySearchBuffer(p.Close1024, numSearch);
                    Console.WriteLine("Number of Steps taken by Binary Search: {0}", Algorithms.BinarySearch.numOfStepsBinarySearch);
                }
                else if ((dataFile == "close1024") && (searchOrSort == "sort"))
                {
                    if (sortStyle == "a")
                    {
                        p.Close1024S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Close_1024.txt");
                        p.Close1024 = new double[p.Close1024S.Length];
                        p.ConvertArrayToDouble(p.Close1024S, p.Close1024);

                        Algorithms.QuickSort.QuickSortBuffer(p.Close1024);
                        Console.WriteLine("Close1024 sorted ascendingly:");
                        p.Close1024.ToList().ForEach(Console.WriteLine);
                        Console.WriteLine("Number of Steps taken by QuickSort: {0}", Algorithms.QuickSort.numOfQuickSortSteps);
                        
                    }
                    else if (sortStyle == "d")
                    {
                        p.Close1024S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Close_1024.txt");
                        p.Close1024 = new double[p.Close1024S.Length];
                        p.ConvertArrayToDouble(p.Close1024S, p.Close1024);

                        p.Close1024.ToList().ForEach(Algorithms.BinaryTree.Tree.InsertBuffer);
                        Console.WriteLine("Close1024 sorted decendingly:");
                        Algorithms.BinaryTree.Tree.PrintData();
                        Console.WriteLine("Number of Steps taken by BinaryTree: {0}", Algorithms.BinaryTree.numOfTreeSteps);
                    }
                }

                if ((dataFile == "change1024") && (searchOrSort == "search"))
                {
                    p.Change1024S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Change_1024.txt");
                    p.Change1024 = new double[p.Change1024S.Length];
                    p.ConvertArrayToDouble(p.Change1024S, p.Change1024);

                    Algorithms.QuickSort.QuickSortBuffer(p.Change1024);
                    Console.WriteLine("Number of Steps taken by QuickSort: {0}", Algorithms.QuickSort.numOfQuickSortSteps);
                    Algorithms.BinarySearch.BinarySearchBuffer(p.Change1024, numSearch);
                    Console.WriteLine("Number of Steps taken by Binary Search: {0}", Algorithms.BinarySearch.numOfStepsBinarySearch);
                }
                else if ((dataFile == "change1024") && (searchOrSort == "sort"))
                {
                    if (sortStyle == "a")
                    {
                        p.Change1024S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Change_1024.txt");
                        p.Change1024 = new double[p.Change1024S.Length];
                        p.ConvertArrayToDouble(p.Change1024S, p.Change1024);
                  
                        Algorithms.QuickSort.QuickSortBuffer(p.Change1024);
                        Console.WriteLine("Change1024 sorted ascendingly:");
                        p.Change1024.ToList().ForEach(Console.WriteLine);
                        Console.WriteLine("Number of Steps taken by QuickSort: {0}", Algorithms.QuickSort.numOfQuickSortSteps);
                    }
                    else if (sortStyle == "d")
                    {
                        p.Change1024S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Change_1024.txt");
                        p.Change1024 = new double[p.Change1024S.Length];
                        p.ConvertArrayToDouble(p.Change1024S, p.Change1024);

                        p.Change1024.ToList().ForEach(Algorithms.BinaryTree.Tree.InsertBuffer);
                        Console.WriteLine("Change1024 sorted decendingly:");
                        Algorithms.BinaryTree.Tree.PrintData();
                        Console.WriteLine("Number of Steps taken by BinaryTree: {0}", Algorithms.BinaryTree.numOfTreeSteps);
                    }
                }

                if ((dataFile == "open1024") && (searchOrSort == "search"))
                {
                    p.Open1024S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Open_1024.txt");
                    p.Open1024 = new double[p.Open1024S.Length];
                    p.ConvertArrayToDouble(p.Open1024S, p.Open1024);

                    Algorithms.QuickSort.QuickSortBuffer(p.Open1024);
                    Console.WriteLine("Number of Steps taken by QuickSort: {0}", Algorithms.QuickSort.numOfQuickSortSteps);
                    Algorithms.BinarySearch.BinarySearchBuffer(p.Open1024, numSearch);
                    Console.WriteLine("Number of Steps taken by Binary Search: {0}", Algorithms.BinarySearch.numOfStepsBinarySearch);

                }
                else if ((dataFile == "open1024") && (searchOrSort == "sort"))
                {
                    if (sortStyle == "a")
                    {
                        p.Open1024S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Open_1024.txt");
                        p.Open1024 = new double[p.Open1024S.Length];
                        p.ConvertArrayToDouble(p.Open1024S, p.Open1024);

                        Algorithms.QuickSort.QuickSortBuffer(p.Open1024);
                        Console.WriteLine("Open1024 sorted ascendingly:");
                        p.Open1024.ToList().ForEach(Console.WriteLine);
                        Console.WriteLine("Number of Steps taken by QuickSort: {0}", Algorithms.QuickSort.numOfQuickSortSteps);


                    }
                    else if (sortStyle == "d")
                    {
                        p.Open1024S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Open_1024.txt");
                        p.Open1024 = new double[p.Open1024S.Length];
                        p.ConvertArrayToDouble(p.Open1024S, p.Open1024);

                        p.Open1024.ToList().ForEach(Algorithms.BinaryTree.Tree.InsertBuffer);
                        Console.WriteLine("Open1024 sorted decendingly:");
                        Algorithms.BinaryTree.Tree.PrintData();
                        Console.WriteLine("Number of Steps taken by BinaryTree: {0}", Algorithms.BinaryTree.numOfTreeSteps);
                    }
                }

                if ((dataFile == "high1024") && (searchOrSort == "search"))
                {
                    p.High1024S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\High_1024.txt");
                    p.High1024 = new double[p.High1024S.Length];
                    p.ConvertArrayToDouble(p.High1024S, p.High1024);

                    Algorithms.QuickSort.QuickSortBuffer(p.High1024);
                    Console.WriteLine("Number of Steps taken by QuickSort: {0}", Algorithms.QuickSort.numOfQuickSortSteps);
                    Algorithms.BinarySearch.BinarySearchBuffer(p.High1024, numSearch);
                    Console.WriteLine("Number of Steps taken by Binary Search: {0}", Algorithms.BinarySearch.numOfStepsBinarySearch);
                }
                else if ((dataFile == "high1024") && (searchOrSort == "sort"))
                {
                    if (sortStyle == "a")
                    {
                        p.High1024S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\High_1024.txt");
                        p.High1024 = new double[p.High1024S.Length];
                        p.ConvertArrayToDouble(p.High1024S, p.High1024);

                        Algorithms.QuickSort.QuickSortBuffer(p.High1024);
                        Console.WriteLine("High1024 sorted ascendingly:");
                        p.High1024.ToList().ForEach(Console.WriteLine);
                        Console.WriteLine("Number of Steps taken by QuickSort: {0}", Algorithms.QuickSort.numOfQuickSortSteps);

                    }
                    else if (sortStyle == "d")
                    {
                        p.High1024S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\High_1024.txt");
                        p.High1024 = new double[p.High1024S.Length];
                        p.ConvertArrayToDouble(p.High1024S, p.High1024);

                        p.High1024.ToList().ForEach(Algorithms.BinaryTree.Tree.InsertBuffer);
                        Console.WriteLine("High1024 sorted decendingly:");
                        Algorithms.BinaryTree.Tree.PrintData();
                        Console.WriteLine("Number of Steps taken by BinaryTree: {0}", Algorithms.BinaryTree.numOfTreeSteps);
                    }
                }

                if ((dataFile == "low1024") && (searchOrSort == "search"))
                {
                    p.Low1024S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Low_1024.txt");
                    p.Low1024 = new double[p.Low1024S.Length];
                    p.ConvertArrayToDouble(p.Low1024S, p.Low1024);

                    Algorithms.QuickSort.QuickSortBuffer(p.Low1024);
                    Console.WriteLine("Number of Steps taken by QuickSort: {0}", Algorithms.QuickSort.numOfQuickSortSteps);
                    Algorithms.BinarySearch.BinarySearchBuffer(p.Low1024, numSearch);
                    Console.WriteLine("Number of Steps taken by Binary Search: {0}", Algorithms.BinarySearch.numOfStepsBinarySearch);
                }
                else if ((dataFile == "low1024") && (searchOrSort == "sort"))
                {
                    if (sortStyle == "a")
                    {
                        p.Low1024S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Low_1024.txt");
                        p.Low1024 = new double[p.Low1024S.Length];
                        p.ConvertArrayToDouble(p.Low1024S, p.Low1024);

                        Algorithms.QuickSort.QuickSortBuffer(p.Low1024);
                        Console.WriteLine("Low1024 sorted ascendingly:");
                        p.Low1024.ToList().ForEach(Console.WriteLine);
                        Console.WriteLine("Number of Steps taken by QuickSort: {0}", Algorithms.QuickSort.numOfQuickSortSteps);

                    }
                    else if (sortStyle == "d")
                    {
                        p.Low1024S = File.ReadAllLines(@"C:\Users\Abbie\Desktop\Algorithms Assessment 1\Bank_Data\Low_1024.txt");
                        p.Low1024 = new double[p.Low1024S.Length];
                        p.ConvertArrayToDouble(p.Low1024S, p.Low1024);

                        p.Low1024.ToList().ForEach(Algorithms.BinaryTree.Tree.InsertBuffer);
                        Console.WriteLine("Low1024 sorted decendingly:");
                        Algorithms.BinaryTree.Tree.PrintData();
                        Console.WriteLine("Number of Steps taken by BinaryTree: {0}", Algorithms.BinaryTree.numOfTreeSteps);
                    }
                }
            }
        }
        
        public class Algorithms
        {
            
            public class QuickSort
            {
                public static int numOfQuickSortSteps = 0;
                public static void QuickSortBuffer(double[] data) 
                {
                    Quick_Sort(data, 0, data.Length - 1); 
                }
                public static void Quick_Sort(double[] data, int left, int right)
                {
                    int i, j; 
                    double temp;
                    double pivot;
                    i = left; //first element in array
                    j = right; //last element in array
                    pivot = data[(left + right) / 2]; //gets middle position
                    do
                    {
                        //numOfQuickSortSteps++;

                        while ((data[i] < pivot) && (i < right))
                        {
                            i++;
                            numOfQuickSortSteps++;
                        }

                        while ((pivot < data[j]) && (j > left))
                        {
                            j--;
                            numOfQuickSortSteps++;
                        }
                        if (i <= j) //if leftmost value is bigger then than or equal to rightmost
                        {
                            //swap values
                            temp = data[i];
                            data[i] = data[j];
                            data[j] = temp;
                            i++;
                            j--;
                            numOfQuickSortSteps++;
                        }

                    } while (i <= j); //while leftmost is bigger than or equal to rightmost 
                    if (left < j)
                    {
                        numOfQuickSortSteps++;
                        Quick_Sort(data, left, j); //recursive calls
                    }
                    if (i < right)
                    {
                        numOfQuickSortSteps++;
                        Quick_Sort(data, i, right);
                       
                    }
                }
            }
            public class InsertionSort
            {
                public static int numOfInsertionSteps = 0;
                public static void Insertion_Sort(double[] data)
                {
                    int valuesSorted = 1; //number of values in the correct place
                    int index; //index of array
                    while (valuesSorted < data.Length) //while all values arent sorted
                    {
                        numOfInsertionSteps++;

                        double temp = data[valuesSorted];

                        for (index = valuesSorted; index > 0; index--)
                        {
                            numOfInsertionSteps++;

                            if (temp < data[index - 1])
                            {
                                numOfInsertionSteps++; 
                                data[index] = data[index - 1];
                            }
                            else
                            {
                                numOfInsertionSteps++;
                                break;
                            }
                            
                        }
                        data[index] = temp;
                        valuesSorted++;
                       
                    }
                }
            }
            public class MergeSort
            {
                public static int numOfMergeSteps = 0;
                public static void Merge(double[] data, double[] temp, int low, int middle, int high)
                {
                    int ri = low; //result index
                    int ti = low; //temp index
                    int di = middle; //destination index
                    while (ti < middle && di <= high) //while lists are not empty merge smaller value
                    {
                        numOfMergeSteps++;

                        if (data[di] < temp[ti])
                        {
                            numOfMergeSteps++;
                            data[ri++] = data[di++]; //smaller data is in high data
                        }
                        else
                        {
                            numOfMergeSteps++;
                            data[ri++] = temp[ti++]; //smaller is in temp
                        }
                    }
                    while (ti < middle)
                    {
                        numOfMergeSteps++;
                        data[ri++] = temp[ti++];
                    }

                }
            
                public static void Merge_Sort(double[] data, double[] temp, int low, int high)
                {
                    int n = high - low + 1;
                    int middle = low + n / 2;
                    int i;

                    if (n < 2)
                    {
                        numOfMergeSteps++;
                        return;
                    }
                    for (i = low; i < middle; i++)
                    {
                        numOfMergeSteps++;
                        temp[i] = data[i];
                    }
                    Merge_Sort(temp,data, low, middle - 1);
                    numOfMergeSteps++;
                    Merge_Sort(data, temp, middle, high);
                    numOfMergeSteps++;
                    Merge(data, temp, low, middle, high);
                    numOfMergeSteps++;
                }
                public static void MergeSortBuffer(double[] data)
                {
                    double[] temp = new double[data.Length-1];
                    Merge_Sort(data, temp, 0, data.Length -1);

                }
            }
            public class BinarySearch
            {
                public static int numOfStepsBinarySearch = 0;
                public static void BinarySearchBuffer(double[]data, double numSearch)
                {
                    int low = 0;
                    int high = data.Length - 1;
                    double key = numSearch;
                   
                    Binary_Search(key, data, low, high);

                }

                public static int Binary_Search(double key, double[] data, int low, int high)
                {
                    if (low > high)
                    {
                        Console.WriteLine("{0} not present in data set", key);
                        numOfStepsBinarySearch++;
                        return -1;
                    }
                    int mid = (low + high) / 2;
                    if (key == data[mid])
                    {
                        numOfStepsBinarySearch++;
                        Console.WriteLine("{0} found at location {1}", key, mid);
                        Binary_Search(key, data, low, mid - 1);
                        return Binary_Search(key, data, mid + 1, high);
                    }
                    if (key < data[mid])
                    {
                        numOfStepsBinarySearch++;
                        return Binary_Search(key, data, low, mid - 1);
                    }
                    else
                    {
                        numOfStepsBinarySearch++;
                        return Binary_Search(key, data, mid + 1, high);
                    }
                }

            }

            public class BinaryTree
            {
                public static int numOfTreeSteps;
                public class BinaryNode
                {
                    //constructor
                    public BinaryNode(double data)
                    {
                        element = data;
                        left = right = null;
                    }

                    public double element; //The data
                    public BinaryNode left; //Left Child
                    public BinaryNode right; //Right Child
                }

                public class Tree
                {

                    public static BinaryNode root; //Root of tree

                    //method to insert infomation
                    public static void Insert(double data, ref BinaryNode root)
                    {
                        if (root == null)
                        {
                            numOfTreeSteps++;
                            root = new BinaryTree.BinaryNode(data);
                        }
                        else if (data.CompareTo(root.element) < 0)
                        {
                            numOfTreeSteps++;
                            Insert(data, ref root.left);
                        }
                        else if (data.CompareTo(root.element) > 0)
                        {
                            numOfTreeSteps++;
                            Insert(data, ref root.right);
                        }

                    }

                    public static void InsertBuffer(double data)
                    {
                        Insert(data, ref root);
                    }

                    public static void PrintData()
                    {
                        PrintInDescending(root);
                    }

                    public static void PrintInDescending(BinaryNode root)
                    {
                        if (root != null)
                        {
                            numOfTreeSteps++;
                            PrintInDescending(root.right);
                            numOfTreeSteps++;
                            Console.WriteLine(root.element);
                            PrintInDescending(root.left);
                            numOfTreeSteps++;
                        }
                    }


               
                }

            }
        }
        
    static void Main(string[] args)
        {
           UserChoices u = new UserChoices();
           u.Welcome();
        
          
            
            

        }
    }
}
