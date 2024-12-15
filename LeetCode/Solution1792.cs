using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.X86;

namespace LeetCode
{
    /// <summary>
    /// 1792. Maximum Average Pass Ratio
    /// https://leetcode.com/problems/maximum-average-pass-ratio
    /// </summary>
    public class Solution1792
    {
        public double MaxAverageRatio(int[][] classes, int extraStudents)
        {

            int n = classes.Length;
            double total = 0;
            // Create a heap to store the profit for each class along with the current pass and total student counts
            var heap = new (double Increment, int Passes, int Total)[n];
            int heap_size = 0;

            // Populate the heap with initial values and calculate the total pass ratio
            for (int i = 0; i < n; i++)
            {
                int pass = classes[i][0], totalStudents = classes[i][1];
                // Add the pass ratio for the current class to the total
                total += (double)pass / totalStudents;
                // Calculate the potential increment in pass ratio by adding 1 extra student
                heap[heap_size++] = (CalculateProfit(pass, totalStudents), pass, totalStudents);
            }

            //  Build the heap to prioritize the class with the highest profit
            BuildHeap(heap, heap_size);

            // Assign extra students to the classes with the highest potential profit
            while (extraStudents-- > 0)
            {
                var (maxIncrement, pass, totalStudents) = heap[0];

                // If there is no increment possible, break
                if (maxIncrement <= 0)
                    break;

                total += maxIncrement;
                pass++;
                totalStudents++;
                // Recalculate the new increment profit after adding a student
                heap[0] = (CalculateProfit(pass, totalStudents), pass, totalStudents);
                // Reheapify the heap to maintain the heap property
                HeapifyDown(heap, 0, heap_size);
            }
            // Calculate and return the average pass ratio across all classes
            return total / n;
        }

        // Calculate the profit, increase in pass ratio when adding a student to a class
        private double CalculateProfit(int pass, int total)
        {

            double current_pass = (double)pass / total;
            double new_pass = (double)(pass + 1) / (total + 1);

            return new_pass - current_pass;
        }

        // Build the max heap by reheapifying from the bottom to the top
        private void BuildHeap((double Increment, int Passes, int Total)[] heap, int size)
        {

            // Start from the last non leaf node and heapify upwards
            for (int i = size / 2 - 1; i >= 0; i--)
            {
                HeapifyDown(heap, i, size);
            }
        }

        // Heapify the heap from index i downwards to ensure the heap property is maintained
        private void HeapifyDown((double Increment, int Passes, int Total)[] heap, int i, int size)
        {

            // Repeat until the heap property is satisfied
            while (true)
            {
                int largest = i;
                int left = 2 * i + 1;
                int right = 2 * i + 2;

                // If left child exists and has larger increment
                if (left < size && heap[left].Increment > heap[largest].Increment)
                {
                    largest = left;
                }
                // If right child exists and has larger increment
                if (right < size && heap[right].Increment > heap[largest].Increment)
                {
                    largest = right;
                }
                // If the largest value is already at i, the heap property is satisfied
                if (largest == i)
                    break;

                // Swap the current node with the largest child
                (heap[i], heap[largest]) = (heap[largest], heap[i]);
                // Move to the child
                i = largest;
            }
        }

        public double MaxAverageRatioBobina(int[][] classes, int extraStudents)
        {
            var avgArray = new double[classes.Length];
            var impactArray = new double[classes.Length];

            var exams = new List<Exam>();
            for (var i = 0; i < classes.Length; i++)
            {
                var exam = new Exam
                {
                    Passed = classes[i][0],
                    Total = classes[i][1],
                };
                exam.Calc();
                exams.Add(exam);
            }

            exams = exams.OrderByDescending(x => x.Impact).ToList();

            if (exams[0].Avg == 1)
            {
                return 1;
            }
            for (var i2 = 0; i2 < extraStudents; i2++)
            {
                exams[0].Total += 1;
                exams[0].Passed += 1;
                exams[0].Calc();
                var newIndex = 0;
                for (var i = 1; i < classes.Length; i++)
                {
                    if (exams[0].Impact < exams[i].Impact)
                    {
                        newIndex = i;
                    }
                    else
                    {
                        break;
                    }
                }
                if (newIndex != 0)
                {
                    exams.Insert(newIndex + 1, exams[0]);
                    exams.RemoveAt(0);
                }
            }
            var result = exams.Sum(x => x.Avg) / exams.Count;
            return result;
        }

        private class Exam
        {
            public int Passed { get; set; }
            public int Total { get; set; }
            public double Avg { get; set; }
            public double Impact { get; set; }

            internal void Calc()
            {
                Avg = ((double)Passed) / Total;
                Impact = (((double)Passed + 1) / (Total + 1) - Avg);
            }

            public override string ToString()
            {
                return Passed + "/" + Total + " " + (Impact * 100);
            }
        }

        public double MaxAverageRatio2(int[][] classes, int extraStudents)
        {
            var avgArray = new double[classes.Length];
            var impactArray = new double[classes.Length];
            for (var i2 = 0; i2 < extraStudents; i2++)
            {
                double maxImpact = 0;
                var maxIndex = 0;
                for (var i = 0; i < classes.Length; i++)
                {
                    if (i2 == 0)
                    {
                        var avg = ((double)classes[i][0]) / classes[i][1];
                        var avgNext = ((double)classes[i][0] + 1) / (classes[i][1] + 1);
                        impactArray[i] = avgNext - avg;
                        avgArray[i] = avg;
                    }
                    if (impactArray[i] > maxImpact)
                    {
                        maxImpact = impactArray[i];
                        maxIndex = i;
                    }
                }
                classes[maxIndex][0] += 1;
                classes[maxIndex][1] += 1;
                avgArray[maxIndex] = ((double)classes[maxIndex][0]) / classes[maxIndex][1];
                var avgNext2 = ((double)classes[maxIndex][0] + 1) / (classes[maxIndex][1] + 1);
                impactArray[maxIndex] = avgNext2 - avgArray[maxIndex];
            }

            var result = avgArray.Sum() / classes.Length;
            return result;
        }
    }
}
