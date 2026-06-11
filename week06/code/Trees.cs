public static class Trees
{

    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        BinarySearchTree bst = new();

        InsertMiddle(
            sortedNumbers,
            0,
            sortedNumbers.Length - 1,
            bst
        );

        return bst;
    }



    // Problem 5
    private static void InsertMiddle(
        int[] sortedNumbers,
        int first,
        int last,
        BinarySearchTree bst)
    {
        if (first > last)
        {
            return;
        }


        int middle = (first + last) / 2;


        bst.Insert(sortedNumbers[middle]);


        // left side
        InsertMiddle(
            sortedNumbers,
            first,
            middle - 1,
            bst
        );


        // right side
        InsertMiddle(
            sortedNumbers,
            middle + 1,
            last,
            bst
        );
    }
}