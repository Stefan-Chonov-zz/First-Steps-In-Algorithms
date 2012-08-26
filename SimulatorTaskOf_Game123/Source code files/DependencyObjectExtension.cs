using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

public static class DependencyObjectExtension
{
    public static T FindChild<T>(this DependencyObject depObj, string childName)
            where T : DependencyObject
    {
        if (depObj == null)
        {
            return null;
        }

        if (depObj is T && ((FrameworkElement)depObj).Name == childName)
        {
            return depObj as T;
        }

        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(depObj, i);

            T obj = FindChild<T>(child, childName);

            if (obj != null)
            {
                return obj;
            }
        }

        return null;
    }

    public static void ClearCellAt(this Grid grid, int row, int col)
    {
        // clear desired cell
        UIElementCollection cells = grid.Children;

        foreach (UIElement cell in cells)
        {
            int curentRow = Grid.GetRow(cell);
            int curentColumn = Grid.GetColumn(cell);

            if ((curentRow == row) &&
                (curentColumn == col))
            {
                grid.Children.Remove(cell);

                return;
            }
        }
    }
}