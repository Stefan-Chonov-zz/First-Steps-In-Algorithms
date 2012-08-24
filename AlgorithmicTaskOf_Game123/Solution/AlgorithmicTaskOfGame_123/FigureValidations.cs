using System;

namespace AlgorithmicTaskOfGame_123
{
    class FigureValidations 
    {
        private const char FIGURE_A = 'A';
        private const char FIGURE_B = 'B';

        /// <summary>
        /// Check is given 'newFigure' meet of requirments for valid figure turn.
        /// </summary>
        /// <param name="figure"></param>
        /// <param name="newFigure"></param>
        /// <returns></returns>
        public void FigureValidationProcess(char currentFigureTurn, char nextFigureTurn)
        {
            bool isNextFigureValid = IsFigureCharacterValid(nextFigureTurn);

            if (isNextFigureValid)
            {
                throw new InvalidBoardException("Wrong figure '" + nextFigureTurn + "' for next turn! The possible input is 'A' or 'B'!");                
            }

            if (currentFigureTurn.Equals(FIGURE_A))
            {
                if (nextFigureTurn != FIGURE_B)
                {
                    throw new InvalidBoardException(Notifications.INVALID_TURN_MESSAGE);
                }
            }
            else
            {
                if (!nextFigureTurn.Equals(FIGURE_A))
                {
                    throw new InvalidBoardException(Notifications.INVALID_TURN_MESSAGE);
                }
            }
        }

        public bool IsFigureCharacterValid(char nextFigureTurn)
        {
            bool isNextFigureEqualOfA = false;
            if (nextFigureTurn.Equals(FIGURE_A))
            {
                isNextFigureEqualOfA = true;
            }

            bool isNextFigureEqualOfB = false;
            if (nextFigureTurn == FIGURE_B)
            {
                isNextFigureEqualOfB = true;
            }

            bool isNextFigureValid = false;
            if (isNextFigureEqualOfA || isNextFigureEqualOfB)
            {
                isNextFigureValid = true;
            }

            return isNextFigureValid;
        }
                
        public bool IsFigureLengthValid(string nextFigureTurn)
        {
            bool isNextFigureValid = true;

            if (nextFigureTurn.Length != 1)
            {
                isNextFigureValid = false;
            }

            return isNextFigureValid;
        }

        //public char GetNextFigureTurn(char currentFigureTurn)
        //{
        //    char nextFigureTurn = ' ';

        //    if (currentFigureTurn.Equals(FIGURE_A))
        //    {
        //        nextFigureTurn = FIGURE_B;
        //    }
        //    else
        //    {
        //        nextFigureTurn = FIGURE_A;
        //    }

        //    return nextFigureTurn;
        //}
    }
}