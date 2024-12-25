// See https://aka.ms/new-console-template for more information
using LeetCode;
using System.Diagnostics;
using System.Text.Json;

//var sln = new Solution2762();
//Console.WriteLine(sln.FindScore([2, 1, 3, 4, 5, 2]));

//var asd = File.ReadAllText("Solution2762.txt");
//var values = asd.Trim('[').Trim(']').Split(",").Select(x=> Int32.Parse(x)).ToArray();
//Console.WriteLine(sln.ContinuousSubarrays([65, 66, 67, 66, 66, 65, 64, 65, 65, 64]));
//Console.WriteLine(sln.ContinuousSubarrays([5,4,2,4]));
//Console.WriteLine(sln.ContinuousSubarrays(values));

//var sln = new Solution1792();
////Console.WriteLine(sln.MaxAverageRatio([[1, 3], [1, 3]], 2));
////Console.WriteLine(sln.MaxAverageRatio([[1, 2], [3, 5], [2, 2]], 2));
//Console.WriteLine(sln.MaxAverageRatio([[2, 4], [3, 9], [4, 5], [2, 10]], 4));

//var asd = File.ReadAllText("Solution1792.txt");
//asd = File.ReadAllText("Solution1792b.txt");
//var array = JsonSerializer.Deserialize<int[][]>(asd);
////var values = asd.Trim('[').Trim(']').Split(",").Select(x=> Int32.Parse(x)).ToArray();.
//var sw = new Stopwatch();
//sw.Start();
//Console.WriteLine(sln.MaxAverageRatio(array, 100000));
//sw.Stop();
//Console.WriteLine(sw.ElapsedMilliseconds + "ms");

//var sln = new Solution2182();
////Console.WriteLine(sln.RepeatLimitedString("cczazcc", 3));
////Console.WriteLine(sln.RepeatLimitedString("aababab", 2));
//var asd = File.ReadAllText("Solution2182.txt");
//var sw = new Stopwatch();
//sw.Start();
//sln.RepeatLimitedString(asd, 1);
//sln.RepeatLimitedString("xyutfpopdynbadwtvmxiemmusevduloxwvpkjioizvanetecnuqbqqdtrwrkgt", 1);

//sw.Stop();
//Console.WriteLine(sw.ElapsedMilliseconds + "ms");

//var sln = new Solution515();
//var sw = new Stopwatch();
//sw.Start();
//var data = sln.GetTestData([1, 3, 2, 5, 3, null, 9]);
//var result = sln.LargestValues(data);
//Console.WriteLine(string.Join(" ", result));

//sw.Stop();
//Console.WriteLine(sw.ElapsedMilliseconds + "ms");

var sln = new Solution3264();
var sw = new Stopwatch();
sw.Start();
//var result = sln.GetFinalState([2, 1, 3, 5, 6], 5, 2);
//Console.WriteLine(string.Join(" ", result));

var result = sln.GetFinalState([1, 3, 5], 5, 3);
Console.WriteLine(string.Join(" ", result));

sw.Stop();
Console.WriteLine(sw.ElapsedMilliseconds + "ms");