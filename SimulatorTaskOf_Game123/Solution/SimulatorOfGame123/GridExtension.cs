using System;
using System.Windows;
using System.Windows.Controls;
using SimulatorOfGame123;

public static class GridExtension
{
    public static void AddElementAtCell(this Grid grid, BasePawn pawn, int row, int col)
    {
        //RedPawn redPawn = new RedPawn();
        RowDefinition rowDef = new RowDefinition();
        rowDef.Height = new GridLength(pawn.Height);

        ColumnDefinition colDef = new ColumnDefinition();
        colDef.Width = new GridLength(pawn.Width);

        Grid.SetRow(pawn, row);
        Grid.SetColumn(pawn, col);

        grid.RowDefinitions.Add(rowDef);
        grid.ColumnDefinitions.Add(colDef);

        grid.Children.Add(pawn);
    }
}