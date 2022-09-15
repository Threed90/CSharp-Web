namespace _02.MergeSort
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            //List<int> nums = Console.ReadLine()
            //    .Split(", ")
            //    .Select(int.Parse)
            //    .ToList();

            var nums = File.ReadAllText("../../../numbers.txt").Split(", ").Select(int.Parse).ToList();

            var list = await Merge(nums);
            Console.WriteLine(new String('=', 50));
            Console.WriteLine(String.Join(", ", list));
        }

        public static async Task<List<int>> Merge(List<int> nums)
        {
            if(nums.Count == 1)
            {
                return nums;
            }

            int midPoint = nums.Count / 2;

            var subArrOne = nums.Take(midPoint).ToList();
            var subArrTwo = nums.Skip(midPoint).ToList();

            var currentArrOne = await Merge(subArrOne);
            var currentArrTwo = await Merge(subArrTwo);

            List<int> result = await SubMerger(currentArrOne, currentArrTwo);

            return result;
        }

        private static async Task<List<int>> SubMerger(List<int> currentArrOne, List<int> currentArrTwo)
        {
            List<int> result = new List<int>();

            while (currentArrOne.Count > 0 && currentArrTwo.Count > 0)
            {
                if(currentArrOne[0] < currentArrTwo[0])
                {
                    result.Add(currentArrOne[0]);
                    currentArrOne.RemoveAt(0);
                }
                else
                {
                    result.Add(currentArrTwo[0]);
                    currentArrTwo.RemoveAt(0);
                }
            }

            result.AddRange(currentArrOne);
            result.AddRange(currentArrTwo);

            return result;
        }
    }
}