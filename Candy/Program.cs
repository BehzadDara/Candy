#region Problem
/*
There are n children standing in a line. Each child is assigned a rating value given in the integer array ratings.

You are giving candies to these children subjected to the following requirements:

Each child must have at least one candy.
Children with a higher rating get more candies than their neighbors.

Return the minimum number of candies you need to have to distribute the candies to the children.

Example 1:
Input: ratings = [1,0,2]
Output: 5
Explanation: You can allocate to the first, second and third child with 2, 1, 2 candies respectively.

Example 2:
Input: ratings = [1,2,2]
Output: 4
Explanation: You can allocate to the first, second and third child with 1, 2, 1 candies respectively.
The third child gets 1 candy because it satisfies the above two conditions.

LeetCode link: https://leetcode.com/problems/candy/
*/
#endregion

#region Solution

Console.WriteLine(Candy(new int[] { 1, 0, 2 }));
static int Candy(int[] ratings)
{
    var result = new int[ratings.Length];
    var value = 1;

    for (int i = 0; i < ratings.Length - 1; i++)
    {
        result[i] = value;
        if (ratings[i] < ratings[i + 1])
        {
            value++;
        }
        else if (ratings[i] == ratings[i + 1])
        {
            value = 1;
        }
        else
        {
            value = 1;

            var j = i;
            var tmpValue = 1;
            while (j >= 0 && ratings[j] > ratings[j + 1] && result[j] == tmpValue)
            {
                result[j]++;
                tmpValue++;
                j--;
            }
        }
    }
    result[ratings.Length - 1] = value;

    return result.Sum();
}

#endregion