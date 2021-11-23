using LeetCode.Trainings;
using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { 3, 1 ,2 };
            var target = 1;

            //var index = BinarySearch.Search(nums, target);
            //var sqrt = BinarySearch.MySqrt(17);
            //var guessedNum = BinarySearch.GuessGame(2);
            //Console.WriteLine($"Your number is {guessedNum}");

            //var idx = BinarySearch.SearchInRotatedSortedArray(nums, target);

            //var firstBadVersion = BinarySearch.VersionControl(2, 2);

            var firstBadVersion = BinarySearch.PeakElement(nums);



        }
    }
}
