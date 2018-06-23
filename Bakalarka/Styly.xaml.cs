using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
public partial class Styly 
{
    
    private void CloseButt_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        Window window = (sender as Button).Tag as Window;
        window.Close();
    }

    private void MinimizeButt_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        Window window = (sender as Button).Tag as Window;
        window.WindowState = System.Windows.WindowState.Minimized;
    }

    private void MaximizeButt_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        Window window = (sender as Button).Tag as Window;

        if (window.WindowState != System.Windows.WindowState.Maximized)
        {
            window.WindowState = System.Windows.WindowState.Maximized;          
        }
        else
        {
            window.WindowState = System.Windows.WindowState.Normal;
        }
    }
}