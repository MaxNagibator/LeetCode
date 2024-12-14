// See https://aka.ms/new-console-template for more information
using LeetCode;

var sln = new Solution2762();
//Console.WriteLine(sln.FindScore([2, 1, 3, 4, 5, 2]));

var asd = File.ReadAllText("Solution2762.txt");
var values = asd.Trim('[').Trim(']').Split(",").Select(x=> Int32.Parse(x)).ToArray();
Console.WriteLine(sln.ContinuousSubarrays([65, 66, 67, 66, 66, 65, 64, 65, 65, 64]));
Console.WriteLine(sln.ContinuousSubarrays([5,4,2,4]));
Console.WriteLine(sln.ContinuousSubarrays(values));
