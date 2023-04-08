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

Console.WriteLine(Candy(new int[] { 1, 6, 10, 8, 7, 3, 2 }));
static int Candy(int[] ratings)
{
    var result = 1;
    var minIndex = Array.IndexOf(ratings, ratings.Min());

    var depth = 0;
    var minIndexCopy = minIndex;
    var currentValue = 1;
    while (minIndexCopy > 0)
    {
        if (ratings[minIndexCopy - 1] > ratings[minIndexCopy])
        {
            depth++;
            currentValue++;
        }
        else if (ratings[minIndexCopy - 1] == ratings[minIndexCopy])
        {
            currentValue = Candy(ratings[0..(minIndexCopy)]);
            minIndexCopy = 1;
        }
        else
        {
            if (currentValue == 1)
            {
                var tmpIndex = minIndexCopy - 1;
                var tmpDepth = depth;
                while (ratings[tmpIndex + 1] > ratings[tmpIndex] && tmpIndex != minIndex)
                {
                    if (tmpDepth < 0)
                    {
                        tmpDepth++;
                        result++;
                    }

                    tmpIndex++;
                }
            }

            depth--;
            currentValue = 1;
        }

        result += currentValue;
        minIndexCopy--;
    }

    depth = 0;
    minIndexCopy = minIndex;
    currentValue = 1;
    while (minIndexCopy < ratings.Length - 1)
    {
        if (ratings[minIndexCopy + 1] > ratings[minIndexCopy])
        {
            depth++;
            currentValue++;
        }
        else if (ratings[minIndexCopy + 1] == ratings[minIndexCopy])
        {
            currentValue = Candy(ratings[(minIndexCopy + 1)..(ratings.Length)]);
            minIndexCopy = ratings.Length - 2;
        }
        else
        {
            if (currentValue == 1)
            {
                var tmpIndex = minIndexCopy + 1;
                var tmpDepth = depth;
                while (ratings[tmpIndex - 1] > ratings[tmpIndex] && tmpIndex != minIndex)
                {
                    if (tmpDepth < 0)
                    {
                        tmpDepth++;
                        result++;
                    }

                    tmpIndex--;
                }
            }

            if (depth > 0)
                depth--;

            currentValue = 1;
        }

        result += currentValue;
        minIndexCopy++;
    }

    return result;
}

#endregion