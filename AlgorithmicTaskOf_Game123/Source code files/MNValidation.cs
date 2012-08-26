using System;

class MNValidation
{
    private const char WHITE_SPACE = ' ';

    /// <summary>
    /// Check is M and N meet of requirements.
    /// </summary>
    /// <param name="readMN"></param>
    public void MNValidationProcess(string readMN, out byte n, out byte m)
    {
        InvalidMNException invalidMNEx = null;

        bool isContainWhiteSpace = readMN.Contains(" ");
        if (!isContainWhiteSpace)
        {
            invalidMNEx = new InvalidMNException(Notifications.MISSING_DELIMITER_MESSAGE);
            throw invalidMNEx;
        }

        // Split M and N by white space.
        string[] extractMN = readMN.Split(WHITE_SPACE);

        // Check is length of 'extractMN' is equal ot 2.
        bool isLengthOfArrayOfStringsIsValid = ValidationOfNumbers.CompareTwoNummbersIsEqual(extractMN.Length, 2);
        if (!isLengthOfArrayOfStringsIsValid)
        {
            invalidMNEx = new InvalidMNException(Notifications.TO_MANY_DELIMITERS_MESSAGE);
            throw invalidMNEx;
        }

        // Check is M is number
        bool isMNumeric = byte.TryParse(extractMN[0], out m);
        if (!isMNumeric)
        {
            invalidMNEx = new InvalidMNException("'" + extractMN[0] + "' is not valid number!");
            throw invalidMNEx;
        }

        // Check is N is number
        bool isNNumeric = byte.TryParse(extractMN[1], out n);
        if (!isNNumeric)
        {
            invalidMNEx = new InvalidMNException("'" + extractMN[1] + "' is not valid number!");
            throw invalidMNEx;
        }

        // Check is M in bounds
        bool isMInBounds = ValidationOfNumbers.IsNumberInBounds(m, 3, 20);
        if (!isMInBounds)
        {
            invalidMNEx = new InvalidMNException("The number '" + m + "' is out of bounds 3 <= M <= 20!");
            throw invalidMNEx;
        }

        // Check is N in bounds
        bool isNInBounds = ValidationOfNumbers.IsNumberInBounds(n, 3, 20);
        if (!isNInBounds)
        {
            invalidMNEx = new InvalidMNException("The number '" + n + "' is out of bounds 3 <= N <= 20!");
            throw invalidMNEx;
        }
    }
}