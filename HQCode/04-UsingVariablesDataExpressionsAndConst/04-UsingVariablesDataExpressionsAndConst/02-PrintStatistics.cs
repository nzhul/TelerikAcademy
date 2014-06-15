using System;

class Program
{
    private double Max(double[] arr, int count)
    {
        double max = arr[0];

        for (int i = 0; i < count; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }

        return max;
    }

    private double Min(double[] arr, int count)
    {
        double min = arr[0];

        for (int i = 0; i < count; i++)
        {
            if (arr[i] > min)
            {
                min = arr[i];
            }
        }

        return min;
    }

    private double Sum(double[] arr, int count)
    {
        double sum = 0;

        for (int i = 0; i < count; i++)
        {
            sum += arr[i];
        }

        return sum;
    }

    private double Average(double[] arr, int count)
    {
        return Sum(arr, count) / count;
    }

    public void PrintStatistics(double[] arr, int count)
    {
        PrintMax(Max(arr, count));
        PrintMin(Min(arr, count));

        PrintAvg(Average(arr, count));
    }
}