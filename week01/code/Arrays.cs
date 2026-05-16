public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember:always Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN:
        // Step 1: Create a new double array of size 'length' to hold the results.
        // Step 2: Loop from index 0 up to (but not including) 'length'.
        // Step 3: At each index i, the multiple is number * (i + 1).
        //         e.g. index 0 -> number * 1 (first multiple)
        //              index 1 -> number * 2 (second multiple)
        //              index 4 -> number * 5 (fifth multiple)
        // Step 4: Store each computed multiple in the array at position i.
        // Step 5: Return the completed array.

        // Step 1: Allocate the result array
        double[] result = new double[length];

        // Step 2-4: Fill each position with the correct multiple
        for (int i = 0; i < length; i++)
        {
            // Step 3: Multiply number by (i + 1) to get the (i+1)th multiple
            result[i] = number * (i + 1);
        }

        // Step 5: Return the populated array
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN (using list slicing with GetRange):
        //
        // "Rotate right by amount" means the last 'amount' elements move to the front.
        //
        // Example: data = {1,2,3,4,5,6,7,8,9}, amount = 3
        //   - The last 3 elements are {7, 8, 9}  -> these become the new front
        //   - The first 6 elements are {1,2,3,4,5,6} -> these follow at the back
        //   - Result: {7, 8, 9, 1, 2, 3, 4, 5, 6}
        //
        // Step 1: Calculate the split index = data.Count - amount
        //         This is where the "tail" slice begins.
        //         e.g. 9 - 3 = 6, so the tail starts at index 6.
        //
        // Step 2: Extract the tail (last 'amount' elements) using GetRange(splitIndex, amount).
        //         e.g. GetRange(6, 3) -> {7, 8, 9}
        //
        // Step 3: Extract the head (first data.Count - amount elements) using GetRange(0, splitIndex).
        //         e.g. GetRange(0, 6) -> {1, 2, 3, 4, 5, 6}
        //
        // Step 4: Clear the original list (RemoveRange on all elements, or just Clear()).
        //
        // Step 5: Add the tail first, then the head, back into the (now empty) data list.
        //         data becomes {7, 8, 9} then {7, 8, 9, 1, 2, 3, 4, 5, 6}.

        // Step 1: Find the index that splits tail from head
        int splitIndex = data.Count - amount;

        // Step 2: Grab the tail (the elements that will move to the front)
        List<int> tail = data.GetRange(splitIndex, amount);

        // Step 3: Grab the head (the elements that will move to the back)
        List<int> head = data.GetRange(0, splitIndex);

        // Step 4: Clear the list so we can rebuild it in the new order
        data.Clear();

        // Step 5a: Add the tail elements first
        data.AddRange(tail);

        // Step 5b: Then append the head elements
        data.AddRange(head);
    }
}