# Sorts
### This program realize two sort algorithms:
1. *Quick(Hoar) Sort*:
```c#
// Check if parametrs are correct   
static bool QuickSort(int[] array, int start, int end)
{
    if (array == null)
    {
        throw new NullReferenceException();
    }
    if (start < 0 || start > end || end >= array.Length)
    {
        return false;
    }
    else
    {
        QSort(array, start, end);
    }
    return true;
}

// Sort input array
static void QSort(int[] array, int start, int end)
{
    if (start >= end)
    {
        return;
    }
    int wall = Division(array, start, end);
    QSort(array, start, wall - 1);
    QSort(array, wall + 1, end);
}

// Find a pivot index
static int Division(int[] array, int start, int end)
{
    int ptr = start;
    for (int i = start; i <= end; i++)
    {
        if (array[i] <= array[end])
        {
            int temp = array[ptr];
            array[ptr] = array[i];
            array[i] = temp;
            ptr++;
        }
    }
    return ptr - 1;
}
```
2. *Merge Sort*:
```c#
// Check if parametrs are correct
static bool MergeSort(int[] array, int start, int end)
{
    if (array == null)
    {
        throw new NullReferenceException();
    }
    if (start < 0 || start > end || end >= array.Length)
    {
        return false;
    }
    else
    {
        MSort(array, start, end);
    }
    return true;
}
    
// Sort input array
static void MSort(int[] array, int start, int end)
{
    if (start < end)
    {
        int middleIndex = (start + end) / 2;
        MSort(array, start, middleIndex);
        MSort(array, middleIndex + 1, end);
        Merge(array, start, middleIndex, end);
    }
}
    
// Separate input array on two parts and sort them
static void Merge(int[] array, int start, int middleIndex, int end)
{
    int left = start;
    int right = middleIndex + 1;
    while ((left <= middleIndex) && (right <= end))
    {
        if (array[left] > array[right])
        {
            int temp = array[left];
            array[left] = array[right];
            array[right] = temp;
            left++;
        }
        else
        {
            left++;
        }
    }
}
```
---
