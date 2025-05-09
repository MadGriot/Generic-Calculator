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
public enum SelectedOperator
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}

public class SimpleMath
{
    public static double Add(double num1, double num2) => num1 + num2;

    public static double Substraction(double num1, double num2) => num1 - num2;

    public static double Multiply(double num1, double num2) => num1 * num2;
    public static double Divide(double num1, double num2)
    {
        if (num2 == 0)
        {
            MessageBox.Show("Division by 0 is not supported", "Wrong operation", 
                MessageBoxButton.OK, MessageBoxImage.Error);
            return 0;
        }

        return num1 / num2;
    }
}
public partial class MainWindow : Window
{
    double lastNumber, result;
    SelectedOperator selectedOperator;
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
        double newNumber;
        if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
        {
            switch (selectedOperator)
            {
                case SelectedOperator.Addition:
                    result = SimpleMath.Add(lastNumber, newNumber);
                    break;
                case SelectedOperator.Subtraction:
                    result = SimpleMath.Substraction(lastNumber, newNumber);
                    break;
                case SelectedOperator.Multiplication:
                    result = SimpleMath.Multiply(lastNumber, newNumber);
                    break;
                case SelectedOperator.Division:
                    result = SimpleMath.Divide(lastNumber, newNumber);
                    break;
            }
        }
        resultLabel.Content = result.ToString();
    }
    private void DecimalButton_Click(object sender, RoutedEventArgs e)
    {
        if (resultLabel.Content.ToString().Contains("."))
        {

        }
        else 
            resultLabel.Content = $"{resultLabel.Content}.";
    }
    private void PercentangeButton_Click(object sender, RoutedEventArgs e)
    {
        double tempNumber;
        if (double.TryParse(resultLabel.Content.ToString(), out tempNumber))
        {
            tempNumber = tempNumber / 100;
            if (lastNumber != 0)
                tempNumber *= lastNumber;
            resultLabel.Content = tempNumber.ToString();
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
        result = 0;
        lastNumber = 0;
    }

    private void OperationButton_Click(object sender, RoutedEventArgs e)
    {
        if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
        {
            resultLabel.Content = "0";
        }

        if (sender == MultiplyButton)
            selectedOperator = SelectedOperator.Multiplication;
        if (sender == DivideButton)
            selectedOperator = SelectedOperator.Division;
        if (sender == PlusButton)
            selectedOperator = SelectedOperator.Addition;
        if (sender == MinusButton)
            selectedOperator = SelectedOperator.Subtraction;
    }

    private void NumberButton_Click(object sender, RoutedEventArgs e)
    {
        int selectedValue = int.Parse((sender as Button).Content.ToString());

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