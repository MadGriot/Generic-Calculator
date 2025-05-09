using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GenericCalculator;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    double lastNumber, result;
    public MainWindow()
    {
        InitializeComponent();

        ACButton.Click += ACButton_Click;
        NegativeButton.Click += NegativeButton_Click;
        PercentangeButton.Click += PercentangeButton_Click;
        EqualButton.Click += EqualButton_Click;
    }

    private void EqualButton_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void PercentangeButton_Click(object sender, RoutedEventArgs e)
    {
        if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
        {
            lastNumber = lastNumber / 100;
            resultLabel.Content = lastNumber.ToString();
        }
    }

    private void NegativeButton_Click(object sender, RoutedEventArgs e)
    {
        if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
        {
            lastNumber = lastNumber * -1;
            resultLabel.Content = lastNumber.ToString();
        }
    }

    private void ACButton_Click(object sender, RoutedEventArgs e)
    {
        resultLabel.Content = "0";
    }

    private void OperationButton_Click(object sender, RoutedEventArgs e)
    {
        if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
        {
            resultLabel.Content = "0";
        }
    }

    private void NumberButton_Click(object sender, RoutedEventArgs e)
    {
        int selectedValue = 0;
        if (sender == ZeroButton)
            selectedValue = 0;
        if (sender == OneButton)
            selectedValue = 1;
        if (sender == TwoButton)
            selectedValue = 2;
        if (sender == ThreeButton)
            selectedValue = 3;
        if (sender == FourButton)
            selectedValue = 4;
        if (sender == FiveButton)
            selectedValue = 5;
        if (sender == SixButton)
            selectedValue = 6;
        if (sender == SevenButton)
            selectedValue = 7;
        if (sender == EightButton)
            selectedValue = 8;
        if (sender == NineButton)
            selectedValue = 9;
        if (resultLabel.Content.ToString() == "0")
        {
            resultLabel.Content = $"{selectedValue}";
        }
        else
        {
            resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
        }
    }
}