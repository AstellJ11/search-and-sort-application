
# Algorithms and Complexity - Search and Sort Application (CMP1124M_Assessment_02)


## Overview
An application which meets and provides the following functionality to the user:
1. Select which individual Array is to be analysed.
2. Sort in ascending and descending order and display the every 10th value of the selected Array.
3. Search the selected Array for a user-defined value, if the value exists, then provide its location (if it appears more than once then provide ALL the locations) otherwise provide an error message.
4. If the value does not exist then provide the value(s) and location(s) of its nearest value.
5. Repeat Tasks 2 to 4 and display the corresponding values for all the selected arrays, for the 2048 length array display the 50th value and for the 4096 array display the 80th value.
6. Merge the Low_256.txt and High_256.txt files. Then repeat Tasks 2 to 4 and display the corresponding values.
7. Repeat task 6 using the files with length 2048 and 4096. In addition, implement and use the Binary Search Tree algorithm, for both searching and sorting.


## Dataset Information

The dataset files correspond to real temperature data taken from a weather station. The Low_*.txt, High_*.txt, and Mean_*.txt respectively correspond to the Low, High, and Mean temperatures as recorded over time. The 256, 2048 and 4096 numbers correspond to the number of temperature data stored in the files.
   
   
## Summary of Implementation
Each of the data sets in loaded directly into a string using File.ReadAllLines. Then are then converted to Arrays, using .ToArray. Once correctly formatted each individual element are added to a heap. Then a for loop is used to remove the largest value and replacing it with the rightmost value. This is repeated until the array is in the required order and can be checked by having no elements being moved around. This was a HeapSort and is used to order the values in ascending order. 

However, to sort them in descending order an InsertionSort is used. The array is initialized and a nested for loop moves the current element and inserts it into the correct position and repeats the loop until completion. Then the same process as before is performed and the values are displayed. For task 3, the application asks the user for an input. When a valid input is entered a binary search is run. Binary search compares the users input value to the middle element of the array, in the unlikely event that they are equal that value is printed, however if not the half that the value cannot be contained in is removed from the search pool and now is halved once again. This is repeated in for and if nested loops until the user’s value is found. If not found an error message is displayed. However, if the value is not in the data set the error message is presented and the neared value to the one entered is found. This number is then displayed to the user and the index value associated with it.

To input files of different lengths, new sorting methods and searching methods were created that matched the elements in those data sets. These were then called when the user requested those sets to be analysed and repeat the same steps as the previous tasks but with larger data sets.

## Algorithmic Choices
The application uses a HeapSort algorithm. This sorting method was used to sort the arrays in ascending order as it has a running time of O(n log n). HeapSort combines
the better attributes of InsertionSort and MergeSort. (Cormen, H.T et al., 2009) It has one of the better worse-case runtimes of O(n log n).

An InsertionSort is also used to sort the arrays. This sorting method is useful for a small amount of values, so was effective using the lower data sets. The input size of the algorithm affects the run time. It has a best-case performance O(n) however worse case of O(n^2) which also becomes the average of this sorting method with larger data sets. (Cormen, H.T et al., 2009)

Binary Search is the only algorithm used to search for values. Binary Search is a “remarkably efficient algorithm for searching in a sorted array” (Levitin, A, 2014) It has a very good best-case performance of O(1) and both a worst and average-case of O(log n). This search method was used as the arrays we already sorted in both circumstances and as noted before binary search is very effective in already sorted algorithms.

### References
Cormen, H.T, Leiserson, C.E, Rivest, R.L, Stein, C. (2009). Sorting and Order Statistics. In: Massachusetts Institute of Technology Introduction to Algorithms. 3rd ed. Cambridge, Massachusetts: The MIT Press. p151-160.

Cormen, H.T, Leiserson, C.E, Rivest, R.L, Stein, C. (2009). Sorting and Order Statistics. In: Massachusetts Institute of Technology Introduction to Algorithms. 3rd ed. Cambridge, Massachusetts: The MIT Press. p16-27.

Levitin, A. (2014). Decrease-by-a-Constant-Factor Algorithms. In: Hirsch, M, Goldstein, M Introduction to the design & analysis of algorithms. Essex, England: Pearson Education Limited 2012. p176-177.
