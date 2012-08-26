using System;
using System.Drawing;

class Game_123_Algorithm
{
    private const char EMPTY_BOX = '-';

    public Point[] Algorithm(char[,] board, char figure)
    {
        Point[] maxSequenceOfEmptyBoxes = null;
        int numberOfEmptyBoxes = 3;

        while (numberOfEmptyBoxes >= 0)
        {
            Random randomVariantOfAlgorithm = new Random();
            bool isNumberOfEmptyBoxesValid = false;
            maxSequenceOfEmptyBoxes = null;
            int randomVariant = 0;

            switch (numberOfEmptyBoxes)
            {
                case 3:
                    // Check for three adjanced empty boxes.
                    AnalyzeBoard getThreeEmptyAdjancedBoxes = new AnalyzeBoard(board);
                                        
                    randomVariant = randomVariantOfAlgorithm.Next(0, 4);
                    if (randomVariant == 0)
                    {
                        maxSequenceOfEmptyBoxes = getThreeEmptyAdjancedBoxes.ExtractPositionsOfAdjacentElementsVariant1(EMPTY_BOX, numberOfEmptyBoxes);                        
                    }
                    else if(randomVariant == 1)
                    {
                        maxSequenceOfEmptyBoxes = getThreeEmptyAdjancedBoxes.ExtractPositionsOfAdjacentElementsVariant2(EMPTY_BOX, numberOfEmptyBoxes);
                    }
                    else if (randomVariant == 2)
                    {
                        maxSequenceOfEmptyBoxes = getThreeEmptyAdjancedBoxes.ExtractPositionsOfAdjacentElementsVariant3(EMPTY_BOX, numberOfEmptyBoxes);
                    }
                    else if (randomVariant == 3)
                    {
                        maxSequenceOfEmptyBoxes = getThreeEmptyAdjancedBoxes.ExtractPositionsOfAdjacentElementsVariant4(EMPTY_BOX, numberOfEmptyBoxes);
                    }

                    if (maxSequenceOfEmptyBoxes != null)
                    {
                        isNumberOfEmptyBoxesValid = ValidationOfNumbers.CompareTwoNummbersIsEqual(maxSequenceOfEmptyBoxes.Length, numberOfEmptyBoxes);
                    }
                    break;
                case 2:
                    // Check for two adjanced empty boxes.
                    AnalyzeBoard getTwoEmptyAdjancedBoxes = new AnalyzeBoard(board);                                        
                    randomVariant = randomVariantOfAlgorithm.Next(0, 4);
                    if (randomVariant == 0)
                    {
                        maxSequenceOfEmptyBoxes = getTwoEmptyAdjancedBoxes.ExtractPositionsOfAdjacentElementsVariant1(EMPTY_BOX, numberOfEmptyBoxes);
                    }
                    else if(randomVariant == 1)
                    {
                        maxSequenceOfEmptyBoxes = getTwoEmptyAdjancedBoxes.ExtractPositionsOfAdjacentElementsVariant2(EMPTY_BOX, numberOfEmptyBoxes);
                    }
                    else if (randomVariant == 2)
                    {
                        maxSequenceOfEmptyBoxes = getTwoEmptyAdjancedBoxes.ExtractPositionsOfAdjacentElementsVariant3(EMPTY_BOX, numberOfEmptyBoxes);
                    }
                    else if (randomVariant == 3)
                    {
                        maxSequenceOfEmptyBoxes = getTwoEmptyAdjancedBoxes.ExtractPositionsOfAdjacentElementsVariant4(EMPTY_BOX, numberOfEmptyBoxes);
                    }

                    if (maxSequenceOfEmptyBoxes != null)
                    {
                        isNumberOfEmptyBoxesValid = ValidationOfNumbers.CompareTwoNummbersIsEqual(maxSequenceOfEmptyBoxes.Length, numberOfEmptyBoxes);
                    }
                    break;
                case 1:
                    // Check for two empty boxes separated by filled box.
                    AnalyzeBoard searchTwoPlusOneEmptyBoxes = new AnalyzeBoard(board);
                    maxSequenceOfEmptyBoxes = searchTwoPlusOneEmptyBoxes.GetPositionsOfTwoElementsSplitedBySpliter(EMPTY_BOX, figure);
                    if (maxSequenceOfEmptyBoxes != null)
                    {
                        isNumberOfEmptyBoxesValid = ValidationOfNumbers.CompareTwoNummbersIsEqual(maxSequenceOfEmptyBoxes.Length, numberOfEmptyBoxes + 1);
                    }
                    break;
                case 0:
                    // Check for single empty box.                    
                    AnalyzeBoard searchSinglePosition = new AnalyzeBoard(board);
                    maxSequenceOfEmptyBoxes = new Point[1];
                    maxSequenceOfEmptyBoxes[0] = searchSinglePosition.GetPositionOfFirstAppearanceOfElement(EMPTY_BOX);

                    bool isRowValid = maxSequenceOfEmptyBoxes[0].X >= 0;
                    bool isColumnValid = maxSequenceOfEmptyBoxes[0].Y >= 0;
                    if (!isRowValid || !isColumnValid)
                    {
                        maxSequenceOfEmptyBoxes = null;
                        break;
                    }

                    isNumberOfEmptyBoxesValid = true;
                    break;
                default:
                    maxSequenceOfEmptyBoxes = null;
                    break;
            }

            if (isNumberOfEmptyBoxesValid)
            {
                break;
            }

            numberOfEmptyBoxes--;
        }

        return maxSequenceOfEmptyBoxes;
    }
}