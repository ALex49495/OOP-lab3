using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ArrayProcessor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Console.OutputEncoding = Encoding.UTF8;
        }

        private void ProcessArrayButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(TextBoxN.Text, out int n) || n <= 0)
            {
                MessageBox.Show("Будь ласка, введіть коректне число для кількості елементів масиву.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Random random = new Random();
            double[] array = new double[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = Math.Round(-110.34 + random.NextDouble() * (110.35 - (-110.34)), 2);
            }

            InitialArrayTextBlock.Text = "Початковий масив: " + string.Join(" ", array);

            double sumNegativeEvenIndex = 0;
            for (int i = 0; i < array.Length; i += 2)
            {
                if (array[i] < 0)
                {
                    sumNegativeEvenIndex += array[i];
                }
            }

            SumNegativeEvenIndexTextBlock.Text = $"Сума від’ємних елементів з парними індексами: {sumNegativeEvenIndex}";

            double[] oddIndexedElements = array.Where((value, index) => index % 2 != 0).ToArray();
            Array.Sort(oddIndexedElements);
            Array.Reverse(oddIndexedElements);

            for (int i = 1, j = 0; i < array.Length; i += 2, j++)
            {
                array[i] = oddIndexedElements[j];
            }

            ProcessedArrayTextBlock.Text = "Масив після впорядкування елементів з непарними індексами: " + string.Join(" ", array);
        }
    }
}
