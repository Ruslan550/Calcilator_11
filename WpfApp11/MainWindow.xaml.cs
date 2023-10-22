using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp11
{
    public partial class MainWindow : Window
    {
        private string _currentInput = string.Empty;
        private string _currentOperator = string.Empty;
        private double _result = 0.0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            if (_currentInput == "0")
                _currentInput = string.Empty;
            _currentInput += button.Content.ToString();
            UpdateScreen();
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            _currentOperator = button.Content.ToString();
            _result = double.Parse(_currentInput);
            _currentInput = string.Empty;
        }

        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            if (!_currentInput.Contains("."))
            {
                _currentInput += ".";
                UpdateScreen();
            }
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_currentInput) && !string.IsNullOrEmpty(_currentOperator))
            {
                double secondOperand = double.Parse(_currentInput);
                switch (_currentOperator)
                {
                    case "+":
                        _result += secondOperand;
                        break;
                    case "-":
                        _result -= secondOperand;
                        break;
                    case "*":
                        _result *= secondOperand;
                        break;
                    case "/":
                        if (secondOperand != 0)
                            _result /= secondOperand;
                        else
                            MessageBox.Show("Cannot divide by zero!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }

                _currentInput = _result.ToString();
                _currentOperator = string.Empty;
                UpdateScreen();
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            _currentInput = "0"; 
            _currentOperator = string.Empty;
            _result = 0.0;
            UpdateScreen();
        }

        private void UpdateScreen()
        {
            txtScreen.Text = _currentInput;
        }
    }
}
