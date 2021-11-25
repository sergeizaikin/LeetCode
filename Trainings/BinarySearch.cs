using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Trainings
{
    static class BinarySearch
    {
        public static int SearchTemplateI(int[] nums, int target, int? first = null, int? last = null)
        {
            if (first == null || last == null)
            {
                first = 0;
                last = nums.Length - 1;
            }

            if (first > last)
                return -1;

            int middleIndex = (first.Value + last.Value) / 2;
            int middleValue = nums[middleIndex];

            if (middleValue == target)
                return middleIndex;

            if (target < middleValue)
            {
                return SearchTemplateI(nums, target, first, middleIndex - 1);
            }
            else
            {
                return SearchTemplateI(nums, target, middleIndex + 1, last);
            }

            return -1;
        }

        public static int MySqrt(int x)
        {
            long startIdx = 0;
            long endIdx = x;

            if (x == 1)
                return x;

            // Executar enquanto tem mais de 1 opção entre os indexes
            while (endIdx - startIdx > 1)
            {
                // Pega o index do meio da range
                long midIdx = startIdx + (endIdx - startIdx) / 2;

                // Se acertou, pega o index
                if (midIdx * midIdx == x)
                {
                    return (int)midIdx;
                }
                // Se for menor, então tem que procurar na parte direita, então move o start index para o index do meio
                else if (midIdx * midIdx < x)
                {
                    startIdx = midIdx;
                }
                // Se não, então tem que procurar na parte esquerda
                else
                {
                    endIdx = midIdx;
                }
            }

            // Se não achou o valor inteiro, então retorna o menor mais próximo
            return (int)startIdx;
        }

        public static int GuessGame(int n)
        {
            int startIdx = 0;
            int endIdx = n;

            while (endIdx >= startIdx)
            {
                int midIdx = startIdx + (endIdx - startIdx) / 2;

                int tryGuess = Guesser(midIdx, 2);

                if (tryGuess == 0)
                    return midIdx;
                else if (tryGuess > 0)
                    endIdx = midIdx - 1;
                else if (tryGuess < 0)
                    startIdx = midIdx + 1;
            }


            return (int)startIdx;
        }

        private static int Guesser(int guessNum, int chosenNum)
        {
            //Console.WriteLine($"Is number {guessNum} lower (<) greater (>) or equal (=) to your number? (Response: '>', '=', '<')");
            //var response = Console.ReadLine();

            if (guessNum < chosenNum)
                return -1;
            else if (guessNum > chosenNum)
                return 1;
            else
                return 0;
        }

        public static int SearchInRotatedSortedArray(int[] nums, int target)
        {
            if (nums.Length == 1)
                if (nums[0] == target)
                    return 0;
                else
                    return -1;

            int lastArrayIndex = nums.Length - 1;
            bool rotated = nums[lastArrayIndex] < nums[0]; // Se o último valor é menor que o primeiro, então foi girado

            if (rotated)
            {
                // Achar pivot

                int startIndex = 0;
                int endIndex = nums.Length - 1;
                int pivotIndex = 0;

                while (endIndex >= startIndex)
                {
                    int midIdx = startIndex + (endIndex - startIndex) / 2;
                    int checkValue = nums[midIdx];
                    pivotIndex = midIdx;

                    if (checkValue > nums[0])
                    {
                        startIndex = midIdx + 1;
                    }
                    else if (checkValue < nums[0])
                    {
                        endIndex = midIdx - 1;
                    }
                    else if (checkValue == target)
                        return midIdx;
                    else if (checkValue == nums[0])
                        startIndex = midIdx + 1;
                }

                startIndex = 0;
                endIndex = nums.Length - 1;

                if (target < nums[lastArrayIndex])
                    startIndex = pivotIndex;
                else if (target > nums[lastArrayIndex])
                    endIndex = pivotIndex;
                else if (target == nums[lastArrayIndex])
                    return lastArrayIndex;

                while (endIndex >= startIndex)
                {
                    int midIdx = startIndex + (endIndex - startIndex) / 2;
                    int checkValue = nums[midIdx];

                    if (checkValue < target)
                    {
                        startIndex = midIdx + 1;
                    }
                    else if (checkValue > target)
                    {
                        endIndex = midIdx - 1;
                    }
                    else if (checkValue == target)
                        return midIdx;
                }

            }
            else
            {
                int startIndex = 0;
                int endIndex = nums.Length - 1;

                while (endIndex >= startIndex)
                {
                    int midIndex = startIndex + (endIndex - startIndex) / 2;
                    int checkValue = nums[midIndex];

                    if (checkValue == target)
                        return midIndex;
                    else if (checkValue > target)
                        endIndex = midIndex - 1;
                    else
                        startIndex = midIndex + 1;
                }

                return -1; // Se chegou até aqui, então não achou
            }


            return -1;

        }

        public static int SearchTemplateII(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            int leftIdx = 0;
            int rightIdx = nums.Length;

            while (leftIdx < rightIdx)
            {
                int midIdx = leftIdx + (rightIdx - leftIdx) / 2;
                int currValue = nums[midIdx];

                if (currValue == target)
                    return midIdx;
                else if (currValue > target)
                    leftIdx = midIdx + 1;
                else
                    rightIdx = midIdx;
            }


            if (leftIdx != nums.Length && nums[leftIdx] == target)
                return leftIdx;
            return -1;
        }

        public static int VersionControl(int n, int firstBadVersion)
        {
            int left = 0;
            int right = n;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (IsBadVersion(mid, firstBadVersion) && IsBadVersion(mid - 1, firstBadVersion))
                    right = mid;
                else if (!IsBadVersion(mid, firstBadVersion) && !IsBadVersion(mid + 1, firstBadVersion))
                    left = mid + 1;
                else if (!IsBadVersion(mid, firstBadVersion) && IsBadVersion(mid + 1, firstBadVersion))
                    return mid + 1;
                else if (IsBadVersion(mid, firstBadVersion) && !IsBadVersion(mid - 1, firstBadVersion))
                    return mid;
            }

            return -1;
        }

        private static bool IsBadVersion(int version, int badVersion)
        {
            return version >= badVersion;
        }

        public static int PeakElement(int[] nums)
        {
            if (nums.Length == 1)
                return 0;

            int left = 0;
            int right = nums.Length - 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] > nums[mid + 1]) // The peak is on the left side
                    right = mid;
                else                          // The peak is on the right side
                    left = mid + 1;
            }

            return left;
        }

        public static int FindMinimumInRotatedArray(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];

            int left = 0;
            int right = nums.Length - 1;

            if (nums[0] > nums[nums.Length - 1]) // Rotated
            {
                while (left < right)
                {
                    int mid = left + (right - left) / 2;

                    if (nums[mid] > nums[nums.Length - 1])
                        left = mid + 1;
                    else
                        right = mid;
                }

                return nums[left];
            }
            else // If not rotated
            {
                return nums[0];
            }

            return -1;
        }

        public static int[] SearchRange(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return new int[] { -1, -1 };

            int left = 0;
            int right = nums.Length - 1;
            
            // Search for the start index
            while(left < right)
            {
                int mid = left + (right - left) / 2;

                if (target <= nums[mid])
                    right = mid;
                else
                    left = mid + 1;
            }

            int startIndex = nums[left] == target ? left : -1;

            left = 0;
            right = nums.Length - 1;

            // Search for the end index
            while (left < right)
            {
                int mid = (left + (right - left) / 2) + 1;

                if (target < nums[mid])
                    right = mid - 1;
                else
                    left = mid;
            }

            int endIndex = nums[right] == target ? right : -1;


            return new int[] { startIndex, endIndex };
        }
    }
}
