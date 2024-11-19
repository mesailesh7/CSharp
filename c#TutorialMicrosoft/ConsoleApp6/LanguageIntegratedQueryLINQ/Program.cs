// See https://aka.ms/new-console-template for more information

// int[] array of integers [] 

List<int> scores = [4,3,100,97, 92, 81, 60];

// for (int i = 0; i < scores.Count; i++)
// {
//     if (scores[i] > 80)
//     {
//         Console.WriteLine($"found a score over 80 {scores[i]}");
//     }
// }




//DECLERATABE PROGRAMMING
// Define the query expression( it is just the question the answer can be get by another function like forEach
// IEnumerable<int> scoreQuery = 
//     from score in scores
//     where score > 80
//     orderby score
//     select score;

// IEnumerable<string> scoreQuery = 
//     from score in scores
//     where score > 80
//     orderby score
//     select $"the score is {score}";
//

// Console.WriteLine(scoreQuery.Count());

IEnumerable<int> scoreQuery = 
    from score in scores
    where score > 80
    orderby score
    select score;

List<int> myScores = scoreQuery.ToList();

foreach (var score in myScores)
{
    Console.WriteLine(score);
}



//Execute the query
// foreach (int i in scoreQuery)
// {
//     Console.WriteLine(i + " ");
// }

// foreach (string i in scoreQuery)
// {
//     Console.WriteLine(i + " ");
// }

var scoreQuery2 = scores.Where(s => s > 80).OrderByDescending(s => s)