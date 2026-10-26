using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// Produces an array of the requested length, starting with number
    /// followed by its multiples.
    /// </summary>
    /// <returns>An array of doubles containing the multiples.</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // 1. Create an array of doubles with the requested length.
        // 2. Loop through each index of the array.
        // 3. Calculate the multiple for the current index.
        // 4. Store the calculated multiple at that index.
        // 5. Return the completed array.

        // Create an array of doubles with the requested length.
        double[] result = new double[length];

        // Loop through each index of the array.
        for (int i = 0; i < length; i++)
        {
            // Calculate and store the multiple for the current index.
            result[i] = number * (i + 1);
        }

        // Return the completed array.
        return result;
    }

    /// <summary>
    /// Rotates the existing list to the right by the specified amount.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan:
        // 1. Calculate the starting index of the final amount of elements.
        // 2. Copy those elements into a temporary list.
        // 3. Remove those elements from the original list.
        // 4. Insert the saved elements at the beginning of the original list.
        // 5. Leave the rotated list in data.

        if (data == null || data.Count <= 1 || amount <= 0)
            return;

        amount %= data.Count;
        if (amount == 0)
            return;

        // Calculate the starting index of the final amount of elements.
        int startIndex = data.Count - amount;

        // Copy those final elements into a temporary list using GetRange.
        List<int> temp = data.GetRange(startIndex, amount);

        // Remove those elements from the original list using RemoveRange.
        data.RemoveRange(startIndex, amount);

        // Insert the saved temporary elements at the beginning of the original list using InsertRange.
        data.InsertRange(0, temp);
    }
}