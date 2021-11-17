using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Trainings
{
    static class BinarySearch
    {
        public static int Search(int[] nums, int target, int? first = null, int? last = null)
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
                return Search(nums, target, first, middleIndex - 1);
            }
            else
            {
                return Search(nums, target, middleIndex + 1, last);
            }

            return -1;
        }

        public static int MySqrt(int x)
        {
            long startIdx = 0;
            long endIdx = x;

            if (x == 1)
                return x;

            while (endIdx - startIdx > 1)
            {
                long midIdx = startIdx + (endIdx - startIdx) / 2;

                if(midIdx * midIdx == x)
                {
                    return (int)midIdx;
                }
                else if(midIdx * midIdx < x)
                {
                    startIdx = midIdx;
                }
                else
                {
                    endIdx = midIdx;
                }
            }

            return (int)startIdx;
        }

    }
}
