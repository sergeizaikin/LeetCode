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

            // Executar enquanto tem mais de 1 opção entre os indexes
            while (endIdx - startIdx > 1)
            {
                // Pega o index do meio da range
                long midIdx = startIdx + (endIdx - startIdx) / 2;

                // Se acertou, pega o index
                if(midIdx * midIdx == x)
                {
                    return (int)midIdx;
                }
                // Se for menor, então tem que procurar na parte direita, então move o start index para o index do meio
                else if(midIdx * midIdx < x)
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

            while(endIdx >= startIdx)
            {
                int midIdx = startIdx + (endIdx - startIdx) / 2;

                int tryGuess = Guess(midIdx, 2);

                if (tryGuess == 0)
                    return midIdx;
                else if (tryGuess > 0)
                    endIdx = midIdx - 1;
                else if (tryGuess < 0)
                    startIdx = midIdx + 1;
            }


            return (int)startIdx;
        }

        private static int Guess(int guessNum, int chosenNum)
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
    }
}
