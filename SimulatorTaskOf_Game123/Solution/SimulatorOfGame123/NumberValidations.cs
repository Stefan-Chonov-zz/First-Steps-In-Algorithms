class NumberValidations
{
    /// <summary>
    /// Compare is two numbers are equal
    /// </summary>
    /// <param name="firstNumber"></param>
    /// <param name="secondNumber"></param>
    /// <returns></returns>
    public static bool CompareTwoNummbersIsEqual(int firstNumber, int secondNumber)
    {
        bool isNumbersAreEqual = false;

        if (firstNumber == secondNumber)
        {
            isNumbersAreEqual = true;
        }

        return isNumbersAreEqual;
    }
        
    /// <summary>
    /// Is 'number' greater or equal of 'minBound' and 'number' is least or eauql of 'maxBound'.
    /// </summary>
    /// <param name="m"></param>
    /// <param name="minBound"></param>
    /// <param name="maxBound"></param>
    /// <returns></returns>
    public static bool IsNumberInBounds(uint number, uint minBound, uint maxBound)
    {
        bool isMInBounds = false;

        if ((minBound <= number) && (number <= maxBound))
        {
            isMInBounds = true;
        }

        return isMInBounds;
    }
}