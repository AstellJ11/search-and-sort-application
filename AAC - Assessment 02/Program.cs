using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AAC___Assessment_02
{
    class Program
    {
        static void Main(string[] args)
        {
            //Calling the weather class
            Weather link = new Weather();

            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("CMP1124M Algorithms And Complexity : Assessment 2 - James Astell - AST17668733");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("\n\t\t\t**********************************************************");
            Console.WriteLine("\t\t\t*                                                        *");
            Console.WriteLine("\t\t\t*             Please press 'Enter' to begin!             *");
            Console.WriteLine("\t\t\t*                                                        *");
            Console.WriteLine("\t\t\t**********************************************************\n");
            Console.ReadLine();
            Console.Clear();
            link.temp();
        }
    }


    class Weather
    {
        public void temp()
        {
            //Calling the HeapSort
            HeapSort link2 = new HeapSort();

            //Asking the user to pick a data set
            bool handling = true;
            while (handling)
            {
                try
                {
                    Console.WriteLine("\n Please select a data set to be analysed: \n 1 -- Low_256 \n 2 -- Mean_256 \n 3 -- High_256 \n 4 -- Low_2048 \n 5 -- Mean_2048 \n 6 -- High_2048 \n 7 -- Low_4096 \n 8 -- Mean_4096 \n 9 -- High_4096");
                    string option = Console.ReadLine();

                    if (option == "1")
                    {
                        Console.Clear();
                        HeapSort.print_Low_256();
                    }

                    if (option == "2")
                    {
                        Console.Clear();
                        HeapSort.print_Mean_256();
                    }

                    if (option == "3")
                    {
                        Console.Clear();
                        HeapSort.print_High_256();
                    }
                    if (option == "4")
                    {
                        Console.Clear();
                        HeapSort.print_Low_2048();
                    }
                    if (option == "5")
                    {
                        Console.Clear();
                        HeapSort.print_Mean_2048();
                    }
                    if (option == "6")
                    {
                        Console.Clear();
                        HeapSort.print_High_2048();
                    }
                    if (option == "7")
                    {
                        Console.Clear();
                        HeapSort.print_Low_4096();
                    }
                    if (option == "8")
                    {
                        Console.Clear();
                        HeapSort.print_Mean_4096();
                    }
                    if (option == "9")
                    {
                        Console.Clear();
                        HeapSort.print_High_4096();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error, Please input an integer!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception caught: {0}", e);
                }
            }
        }
    }


    public class HeapSort
    {
        static void heapSort(double[] arr, int n)
        {

            //Converting the elements into a heap
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(arr, n, i);

            //A loop removing the largest value and then being replaced by the rightmost value
            for (int i = n - 1; i >= 0; i--)
            {
                double temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                heapify(arr, i, 0);
            }
        }
        static void heapify(double[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && arr[left] > arr[largest])
                largest = left;
            if (right < n && arr[right] > arr[largest])
                largest = right;
            if (largest != i)
            {
                double swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;
                heapify(arr, n, largest);
            };
        }



        static void insertionSort(double[] arr, int n)
        {
            int i, j, flag;
            double val;
            for (i = 1; i < n; i++)
            {
                val = arr[i];
                flag = 0;
                for (j = i - 1; j >= 0 && flag != 1;)
                {
                    if (val > arr[j])
                    {
                        arr[j + 1] = arr[j];
                        j--;
                        arr[j + 1] = val;
                    }
                    else flag = 1;
                }                                      
            }
        }


        public static void print_Low_256()
        {
            //Reading in the text file
            string[] Low_256 = File.ReadAllLines("Low_256.txt");

            //Removing the blank spaces that are left in the text files
            string[] result1 = Low_256.Where(item => item != string.Empty).ToArray();

            //Creating a double array
            double[] arr = new double[256];
            string temp = "0";
            double dbl = 0;

            for (int a = 0; a < result1.Length; a++)
            {
                temp = "0";
                temp = result1[a];
                dbl = Convert.ToDouble(temp);
                arr[a] = dbl;
            }

            int n = 256, i, x;

            //Calling the heapSort and sorting the array
            heapSort(arr, 256);

            Console.Write("\nSorted array in ASCENDING order is:\n");
            for (i = 0; i < n; i++)
            {
                Console.Write(i + 1 + " --- " + arr[i] + "\n");
            }

            //Displaying every 10th value in the already sorted array
            Console.Write("\n\nEvery 10th value in this array is:\n");
            for (int k = 9; k < arr.Length; k += 10)
            {
                double current = arr[k];
                Console.Write(k + 1 + " --- " + current + "\n");
            }
            Console.ReadLine();
            Console.Clear();

            insertionSort(arr, 256);

            Console.Write("\nSorted array in DESCENDING order is:\n");
            for (x = 0; x < n; x++)
            {
                Console.Write(x + 1 + " --- " + arr[x] + "\n");
            }

            Console.Write("\n\nEvery 10th value in this array is:\n");
            for (int t = 9; t < arr.Length; t += 10)
            {
                double current = arr[t];
                Console.Write(t + 1 + " --- " + current + "\n");
            }

            Console.ReadLine();
            Console.Clear();

            //Allowing the user to input a user-defined value
            bool run = true;
            while (run)
            {
                Console.WriteLine("\nCurrently selected data set : Low_256 ");
                Console.WriteLine("Please enter a value to be searched for in the selected data set: ");

                string userString = "";
                double user;

                try
                {
                    userString = Console.ReadLine();
                    user = Convert.ToDouble(userString);

                    //Calling the binary search to look for the user inputted number / closest value
                    binarySearch(arr, 0, arr.Length, user);

                }
                //Exeption handling if entering a non-valid input
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Try again and enter a number between {0} and {1}", arr[0], arr[arr.Length - 1]);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error try again. Please enter a number.");
                }
            }

        }

    
        public static void print_Mean_256()
        {
            string[] Low_256 = File.ReadAllLines("Mean_256.txt");

            string[] result1 = Low_256.Where(item => item != string.Empty).ToArray();

            double[] arr = new double[256];
            string temp = "0";
            double dbl = 0;

            for (int a = 0; a < result1.Length; a++)
            {
                temp = "0";
                temp = result1[a];
                dbl = Convert.ToDouble(temp);
                arr[a] = dbl;
            }

            int n = 256, i, x;

            heapSort(arr, 256);

            Console.Write("\nSorted array in ASCENDING order is:\n");
            for (i = 0; i < n; i++)
            {
                Console.Write(i + 1 + " --- " + arr[i] + "\n");
            }

            Console.Write("\n\nEvery 10th value in this array is:\n");
            for (int k = 9; k < arr.Length; k += 10)
            {
                double current = arr[k];
                Console.Write(k + 1 + " --- " + current + "\n");
            }
            Console.ReadLine();
            Console.Clear();

            insertionSort(arr, 256);

            Console.Write("\nSorted array in DESCENDING order is:\n");
            for (x = 0; x < n; x++)
            {
                Console.Write(x + 1 + " --- " + arr[x] + "\n");
            }

            Console.Write("\n\nEvery 10th value in this array is:\n");
            for (int t = 9; t < arr.Length; t += 10)
            {
                double current = arr[t];
                Console.Write(t + 1 + " --- " + current + "\n");
            }

            Console.ReadLine();
            Console.Clear();

            bool run = true;
            while (run)
            {
                Console.WriteLine("\nCurrently selected data set : Mean_256 ");
                Console.WriteLine("Please enter a value to be searched for in the selected data set: ");

                string userString = "";
                double user;

                try
                {
                    userString = Console.ReadLine();
                    user = Convert.ToDouble(userString);

                    binarySearch(arr, 0, arr.Length, user);

                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Try again and enter a number between {0} and {1}", arr[0], arr[arr.Length - 1]);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error try again. Please enter a number.");
                }
            }
        }


        public static void print_High_256()
        {
            string[] Low_256 = File.ReadAllLines("High_256.txt");

            string[] result1 = Low_256.Where(item => item != string.Empty).ToArray();

            double[] arr = new double[256];
            string temp = "0";
            double dbl = 0;

            for (int a = 0; a < result1.Length; a++)
            {
                temp = "0";
                temp = result1[a];
                dbl = Convert.ToDouble(temp);
                arr[a] = dbl;
            }

            int n = 256, i, x;

            heapSort(arr, 256);

            Console.Write("\nSorted array in ASCENDING order is:\n");
            for (i = 0; i < n; i++)
            {
                Console.Write(i + 1 + " --- " + arr[i] + "\n");
            }

            Console.Write("\n\nEvery 10th value in this array is:\n");
            for (int k = 9; k < arr.Length; k += 10)
            {
                double current = arr[k];
                Console.Write(k + 1 + " --- " + current + "\n");
            }
            Console.ReadLine();
            Console.Clear();

            insertionSort(arr, 256);

            Console.Write("\nSorted array in DESCENDING order is:\n");
            for (x = 0; x < n; x++)
            {
                Console.Write(x + 1 + " --- " + arr[x] + "\n");
            }

            Console.Write("\n\nEvery 10th value in this array is:\n");
            for (int t = 9; t < arr.Length; t += 10)
            {
                double current = arr[t];
                Console.Write(t + 1 + " --- " + current + "\n");
            }

            Console.ReadLine();
            Console.Clear();

            bool run = true;
            while (run)
            {
                Console.WriteLine("\nCurrently selected data set : High_256 ");
                Console.WriteLine("Please enter a value to be searched for in the selected data set: ");

                string userString = "";
                double user;

                try
                {
                    userString = Console.ReadLine();
                    user = Convert.ToDouble(userString);

                    binarySearch(arr, 0, arr.Length, user);

                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Try again and enter a number between {0} and {1}", arr[0], arr[arr.Length - 1]);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error try again. Please enter a number.");
                }
            }
        }


        public static void print_Low_2048()
        {
            string[] Low_256 = File.ReadAllLines("Low_2048.txt");

            string[] result1 = Low_256.Where(item => item != string.Empty).ToArray();

            double[] arr = new double[2048];
            string temp = "0";
            double dbl = 0;

            for (int a = 0; a < result1.Length; a++)
            {
                temp = "0";
                temp = result1[a];
                dbl = Convert.ToDouble(temp);
                arr[a] = dbl;
            }

            int n = 2048, i, x;

            heapSort(arr, 2048);

            Console.Write("\nSorted array in ASCENDING order is:\n");
            for (i = 0; i < n; i++)
            {
                Console.Write(i + 1 + " --- " + arr[i] + "\n");
            }

            Console.Write("\n\nThe 50th value in this array is:\n");
            Console.Write(arr[49]);
            Console.ReadLine(); ;
            Console.Clear();

            insertionSort(arr, 2048);

            Console.Write("\nSorted array in DESCENDING order is:\n");
            for (x = 0; x < n; x++)
            {
                Console.Write(x + 1 + " --- " + arr[x] + "\n");
            }

            Console.Write("\n\nThe 50th value in this array is:\n");
            Console.Write(arr[49]);
            Console.ReadLine();
            Console.Clear();

            bool run = true;
            while (run)
            {
                Console.WriteLine("\nCurrently selected data set : Low_2048 ");
                Console.WriteLine("Please enter a value to be searched for in the selected data set: ");

                string userString = "";
                double user;

                try
                {
                    userString = Console.ReadLine();
                    user = Convert.ToDouble(userString);

                    binarySearch2048(arr, 0, arr.Length, user);

                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Try again and enter a number between {0} and {1}", arr[0], arr[arr.Length - 1]);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error try again. Please enter a number.");
                }
            }
        }


        public static void print_Mean_2048()
        {
            string[] Low_256 = File.ReadAllLines("Mean_2048.txt");

            string[] result1 = Low_256.Where(item => item != string.Empty).ToArray();

            double[] arr = new double[2048];
            string temp = "0";
            double dbl = 0;

            for (int a = 0; a < result1.Length; a++)
            {
                temp = "0";
                temp = result1[a];
                dbl = Convert.ToDouble(temp);
                arr[a] = dbl;
            }

            int n = 2048, i, x;

            heapSort(arr, 2048);

            Console.Write("\nSorted array in ASCENDING order is:\n");
            for (i = 0; i < n; i++)
            {
                Console.Write(i + 1 + " --- " + arr[i] + "\n");
            }

            Console.Write("\n\nThe 50th value in this array is:\n");
            Console.Write(arr[49]); 
            Console.ReadLine();
            Console.Clear();

            insertionSort(arr, 2048);

            Console.Write("\nSorted array in DESCENDING order is:\n");
            for (x = 0; x < n; x++)
            {
                Console.Write(x + 1 + " --- " + arr[x] + "\n");
            }

            Console.Write("\n\nThe 50th value in this array is:\n");
            Console.Write(arr[49]);
            Console.ReadLine();
            Console.Clear();

            bool run = true;
            while (run)
            {
                Console.WriteLine("\nCurrently selected data set : Mean_2048 ");
                Console.WriteLine("Please enter a value to be searched for in the selected data set: ");

                string userString = "";
                double user;

                try
                {
                    userString = Console.ReadLine();
                    user = Convert.ToDouble(userString);

                    binarySearch2048(arr, 0, arr.Length, user);

                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Try again and enter a number between {0} and {1}", arr[0], arr[arr.Length - 1]);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error try again. Please enter a number.");
                }
            }
        }


        public static void print_High_2048()
        {
            string[] Low_256 = File.ReadAllLines("High_2048.txt");

            string[] result1 = Low_256.Where(item => item != string.Empty).ToArray();

            double[] arr = new double[2048];
            string temp = "0";
            double dbl = 0;

            for (int a = 0; a < result1.Length; a++)
            {
                temp = "0";
                temp = result1[a];
                dbl = Convert.ToDouble(temp);
                arr[a] = dbl;
            }

            int n = 2048, i, x;

            heapSort(arr, 2048);

            Console.Write("\nSorted array in ASCENDING order is:\n");
            for (i = 0; i < n; i++)
            {
                Console.Write(i + 1 + " --- " + arr[i] + "\n");
            }

            Console.Write("\n\nThe 50th value in this array is:\n");
            Console.Write(arr[49]);
            Console.ReadLine();
            Console.Clear();

            insertionSort(arr, 2048);

            Console.Write("\nSorted array in DESCENDING order is:\n");
            for (x = 0; x < n; x++)
            {
                Console.Write(x + 1 + " --- " + arr[x] + "\n");
            }

            Console.Write("\n\nThe 50th value in this array is:\n");
            Console.Write(arr[49]);
            Console.ReadLine();
            Console.Clear();

            bool run = true;
            while (run)
            {
                Console.WriteLine("\nCurrently selected data set : High_2048 ");
                Console.WriteLine("Please enter a value to be searched for in the selected data set: ");

                string userString = "";
                double user;

                try
                {
                    userString = Console.ReadLine();
                    user = Convert.ToDouble(userString);

                    binarySearch2048(arr, 0, arr.Length, user);

                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Try again and enter a number between {0} and {1}", arr[0], arr[arr.Length - 1]);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error try again. Please enter a number.");
                }
            }
        }


        public static void print_Low_4096()
        {
            string[] Low_256 = File.ReadAllLines("Low_4096.txt");

            string[] result1 = Low_256.Where(item => item != string.Empty).ToArray();

            double[] arr = new double[4096];
            string temp = "0";
            double dbl = 0;

            for (int a = 0; a < result1.Length; a++)
            {
                temp = "0";
                temp = result1[a];
                dbl = Convert.ToDouble(temp);
                arr[a] = dbl;
            }

            int n = 4096, i, x;

            heapSort(arr, 4096);

            Console.Write("\nSorted array in ASCENDING order is:\n");
            for (i = 0; i < n; i++)
            {
                Console.Write(i + 1 + " --- " + arr[i] + "\n");
            }

            Console.Write("\n\nThe 80th value in this array is:\n");
            Console.Write(arr[79]);
            Console.ReadLine();
            Console.Clear();

            insertionSort(arr, 4096);

            Console.Write("\nSorted array in DESCENDING order is:\n");
            for (x = 0; x < n; x++)
            {
                Console.Write(x + 1 + " --- " + arr[x] + "\n");
            }

            Console.Write("\n\nThe 80th value in this array is:\n");
            Console.Write(arr[79]);
            Console.ReadLine();
            Console.Clear();

            bool run = true;
            while (run)
            {
                Console.WriteLine("\nCurrently selected data set : Low_4096 ");
                Console.WriteLine("Please enter a value to be searched for in the selected data set: ");

                string userString = "";
                double user;

                try
                {
                    userString = Console.ReadLine();
                    user = Convert.ToDouble(userString);

                    binarySearch4096(arr, 0, arr.Length, user);

                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Try again and enter a number between {0} and {1}", arr[0], arr[arr.Length - 1]);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error try again. Please enter a number.");
                }
            }
        }


        public static void print_Mean_4096()
        {
            string[] Low_256 = File.ReadAllLines("Mean_4096.txt");

            string[] result1 = Low_256.Where(item => item != string.Empty).ToArray();

            double[] arr = new double[4096];
            string temp = "0";
            double dbl = 0;

            for (int a = 0; a < result1.Length; a++)
            {
                temp = "0";
                temp = result1[a];
                dbl = Convert.ToDouble(temp);
                arr[a] = dbl;
            }

            int n = 4096, i, x;

            heapSort(arr, 4096);

            Console.Write("\nSorted array in ASCENDING order is:\n");
            for (i = 0; i < n; i++)
            {
                Console.Write(i + 1 + " --- " + arr[i] + "\n");
            }

            Console.Write("\n\nThe 80th value in this array is:\n");
            Console.Write(arr[79]);
            Console.ReadLine();
            Console.Clear();

            insertionSort(arr, 4096);

            Console.Write("\nSorted array in DESCENDING order is:\n");
            for (x = 0; x < n; x++)
            {
                Console.Write(x + 1 + " --- " + arr[x] + "\n");
            }

            Console.Write("\n\nThe 80th value in this array is:\n");
            Console.Write(arr[79]);
            Console.ReadLine();
            Console.Clear();

            bool run = true;
            while (run)
            {
                Console.WriteLine("\nCurrently selected data set : Mean_4096 ");
                Console.WriteLine("Please enter a value to be searched for in the selected data set: ");

                string userString = "";
                double user;

                try
                {
                    userString = Console.ReadLine();
                    user = Convert.ToDouble(userString);

                    binarySearch4096(arr, 0, arr.Length, user);

                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Try again and enter a number between {0} and {1}", arr[0], arr[arr.Length - 1]);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error try again. Please enter a number.");
                }
            }
        }


        public static void print_High_4096()
        {
            string[] Low_256 = File.ReadAllLines("High_4096.txt");

            string[] result1 = Low_256.Where(item => item != string.Empty).ToArray();

            double[] arr = new double[4096];
            string temp = "0";
            double dbl = 0;

            for (int a = 0; a < result1.Length; a++)
            {
                temp = "0";
                temp = result1[a];
                dbl = Convert.ToDouble(temp);
                arr[a] = dbl;
            }

            int n = 4096, i, x;

            heapSort(arr, 4096);

            Console.Write("\nSorted array in ASCENDING order is:\n");
            for (i = 0; i < n; i++)
            {
                Console.Write(i + 1 + " --- " + arr[i] + "\n");
            }

            Console.Write("\n\nThe 80th value in this array is:\n");
            Console.Write(arr[79]);
            Console.ReadLine();
            Console.Clear();


            insertionSort(arr, 4096);

            Console.Write("\nSorted array in DESCENDING order is:\n");
            for (x = 0; x < n; x++)
            {
                Console.Write(x + 1 + " --- " + arr[x] + "\n");
            }

            Console.Write("\n\nThe 80th value in this array is:\n");
            Console.Write(arr[79]);
            Console.ReadLine();

            Console.ReadLine();
            Console.Clear();

            bool run = true;
            while (run)
            {
                Console.WriteLine("\nCurrently selected data set : High_4096 ");
                Console.WriteLine("Please enter a value to be searched for in the selected data set: ");

                string userString = "";
                double user;

                try
                {
                    userString = Console.ReadLine();
                    user = Convert.ToDouble(userString);

                    binarySearch4096(arr, 0, arr.Length, user);

                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Try again and enter a number between {0} and {1}", arr[0], arr[arr.Length - 1]);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error try again. Please enter a number.");
                }
            }
        }


        static int binarySearch(double[] arr, int start, int end, double user)
        {
            int step = 0;
            if (start > end)
            {
                double fromStart = Math.Abs(arr[start] - user);
                double fromEnd = Math.Abs(arr[end] - user);

                if (fromStart < fromEnd)
                {
                    Console.WriteLine("\nYour entered value was not found, however the closet value, when order in ASCENDING order is at: ");
                    Console.WriteLine("Location: {0} and was the Value: {1}", end + 2, arr[start]);
                }
                else if (fromStart > fromEnd)
                {
                    Console.WriteLine("\nYour entered value was not found, however the closet value, when order in ASCENDING order is at: ");
                    Console.WriteLine("Location: {0} and was the Value: {1}", end + 1, arr[end]);
                }
                else
                {
                    Console.WriteLine("\nYour entered value was not found, however the closet value, when order in ASCENDING order is at: ");
                    Console.WriteLine("Location: {0} and was the Value: {1}", end, arr[start]);
                    Console.WriteLine("Location: {0} and was the Value: {1}", end, arr[end]);
                }
                Console.ReadLine();
                Environment.Exit(0);
            }

            int mid = (start + end) / 2;

            heapSort(arr, 256);

            if (user == arr[mid])
            {
                int m;
                for (m = mid; m > 0; m--)
                {
                    if (arr[m] != user)
                    {
                        m++;
                        step++;
                        break;

                    }
                }
                for (;  m < arr.Length; m++)
                {
                    if (arr[m] != user)
                        break;
                    Console.WriteLine("\nThe number you entered was in this data set! \nLocation: {0} ", m + 1);
                }
                return mid;
            }
            else if (user < arr[mid])
            {
                return binarySearch(arr, start, mid - 1, user);            
            }
            else
            {
                return binarySearch(arr, mid + 1, end, user);
            }
        }


        static int binarySearch2048(double[] arr, int start, int end, double user)
        {
            if (start > end)
            {
                double fromStart = Math.Abs(arr[start] - user);
                double fromEnd = Math.Abs(arr[end] - user);

                if (fromStart < fromEnd)
                {
                    Console.WriteLine("\nYour entered value was not found, however the closet value, when order in ASCENDING order is at: ");
                    Console.WriteLine("Location: {0} and was the Value: {1}", end + 2, arr[start]);
                }
                else if (fromStart > fromEnd)
                {
                    Console.WriteLine("\nYour entered value was not found, however the closet value, when order in ASCENDING order is at: ");
                    Console.WriteLine("Location: {0} and was the Value: {1}", end + 1, arr[end]);
                }
                else
                {
                    Console.WriteLine("\nYour entered value was not found, however the closet value, when order in ASCENDING order is at: ");
                    Console.WriteLine("Location: {0} and was the Value: {1}", end, arr[start]);
                    Console.WriteLine("Location: {0} and was the Value: {1}", end, arr[end]);
                }
                Console.ReadLine();
                Environment.Exit(0);
            }

            int mid = (start + end) / 2;

            heapSort(arr, 2048);

            if (user == arr[mid])
            {
                int m;
                for (m = mid; m > 0; m--)
                {
                    if (arr[m] != user)
                    {
                        m++;
                        break;
                    }
                }
                for (; m < arr.Length; m++)
                {
                    if (arr[m] != user)
                        break;
                    Console.WriteLine("\nThe number you entered was in this data set! \nLocation: {0} ", m + 1);
                }
                return mid;
            }
            else if (user < arr[mid])
            {
                return binarySearch2048(arr, start, mid - 1, user);
            }
            else
            {
                return binarySearch2048(arr, mid + 1, end, user);
            }
        }


        static int binarySearch4096(double[] arr, int start, int end, double user)
        {
            if (start > end)
            {
                double fromStart = Math.Abs(arr[start] - user);
                double fromEnd = Math.Abs(arr[end] - user);

                if (fromStart < fromEnd)
                {
                    Console.WriteLine("\nYour entered value was not found, however the closet value, when order in ASCENDING order is at: ");
                    Console.WriteLine("Location: {0} and was the Value: {1}", end + 2, arr[start]);
                }
                else if (fromStart > fromEnd)
                {
                    Console.WriteLine("\nYour entered value was not found, however the closet value, when order in ASCENDING order is at: ");
                    Console.WriteLine("Location: {0} and was the Value: {1}", end + 1, arr[end]);
                }
                else
                {
                    Console.WriteLine("\nYour entered value was not found, however the closet value, when order in ASCENDING order is at: ");
                    Console.WriteLine("Location: {0} and was the Value: {1}", end, arr[start]);
                    Console.WriteLine("Location: {0} and was the Value: {1}", end, arr[end]);
                }
                Console.ReadLine();
                Environment.Exit(0);
            }

            int mid = (start + end) / 2;

            heapSort(arr, 4096);

            if (user == arr[mid])
            {
                int m;
                for (m = mid; m > 0; m--)
                {
                    if (arr[m] != user)
                    {
                        m++;
                        break;
                    }
                }
                for (; m < arr.Length; m++)
                {
                    if (arr[m] != user)
                        break;
                    Console.WriteLine("\nThe number you entered was in this data set! \nLocation: {0} ", m + 1);
                }
                return mid;
            }
            else if (user < arr[mid])
            {
                return binarySearch4096(arr, start, mid - 1, user);
            }
            else
            {
                return binarySearch4096(arr, mid + 1, end, user);
            }
        }
    }
}


