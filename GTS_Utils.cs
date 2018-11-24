using System;

public class GTS_Utils
{
	public GTS_Utils()
	{
	}

    /**
     * Computes the Levenshtein distance (https://en.wikipedia.org/wiki/Levenshtein_distance)
     * of two strigns using a dynamic programming algorithm.
     * Essentially, the Levenshtein distance is the number of insertions, deletions, or replacements
     * needed to convert one string to another string.
     * This is O(a.length*b.length) in terms of both time and space complexity, and since valid subreddit names
     * have a maximum length of 20 characters, we can reject strings above a certain length automatically.
     * Therefore, running this algorithm will never incur a significant cost.
     */
    public static int levenshteinDistance(String a, String b)
    {
        int aLen = a.Length;
        int bLen = b.Length;
        /**
         * Start with 2d partial solution matrix
         * solutionMatrix[i,j] is the Levenshein distance for the first i characters of a
         * and the first j characters of b
         */
        int[,] solutionMatrix = new int[aLen + 1, bLen + 1];
        /**
         * Base case: If one of the strings is zero length, then the Levenshtein distance is the length of the other string,
         * i.e. you convert an empty string to a nonempty string by copying all the characters over
         * and do the opposite by deleting all the characters
         */
        for (int i = 0; i <= aLen; i++)
        {
            solutionMatrix[i, 0] = i;
        }
        for (int i = 0; i <= bLen; i++)
        {
            solutionMatrix[0, i] = i;
        }
        /**
         * The recursive case is more complicated, see the Wikipedia article.
         * The gist is that we modify 3 sub-solutions to fit a slightly longer a and/or b
         * and choose the modified solution with the lowest distance
         */
        for(int i = 1; i <= aLen; i++)
        {
            for(int j = 1; j<= bLen; j++)
            {
                int indicator = 0;
                //Since subreddit names are case insensitive we call ToLower
                if(Char.ToLower(a.ToCharArray()[i-1]).Equals(Char.ToLower(b.ToCharArray()[j - 1])))
                {
                    indicator = 0;
                }
                else
                {
                    indicator = 1;
                }
                int addToA = solutionMatrix[i - 1, j] + 1;
                int addToB = solutionMatrix[i, j - 1] + 1;
                int addToBoth = solutionMatrix[i - 1, j - 1] + indicator;
                solutionMatrix[i, j] = Math.Min(addToA, Math.Min(addToB, addToBoth));
            }
        }
        //The final solution is the solution for i = aLen and j = bLen
        return solutionMatrix[aLen, bLen];
    }

    /**
     * Returns whether the guessed subreddit name should be considered for the Levenshtein distance test.
     * The string must have 3 properties:
     * 1. It must be less than 26 characters long (as the Levenshtein distance will be > 5 regardless of the subreddit name and that's the max possible tolerance)
     * 2. It must not start with an underscore (as subreddit names cannot start with underscores)
     * 3. It must have only alphanumeric characters or underscores
     */
    public static bool ValidGuessingName(String subreddit)
    {
        //Criteria 1
        if (subreddit.Length >=26)
        {
            return false;
        }
        //Criteria 2
        if (subreddit.StartsWith("_"))
        {
            return false;
        }
        //Criteria 3
        foreach (Char c in subreddit)
        {
            if(!(Char.IsLetterOrDigit(c) || c == '_'))
            {
                return false;
            }
        }
        return true;
    }

    public static 
}
