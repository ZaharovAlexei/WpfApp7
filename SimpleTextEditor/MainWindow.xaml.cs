using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleTextEditor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = (sender as ComboBox).SelectedItem as string;
            if (myTextBox != null)
            {
                myTextBox.FontFamily = new FontFamily(fontName);
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            double fontSize = Convert.ToDouble((sender as ComboBox).SelectedItem as string);
            if (myTextBox != null)
            {
                myTextBox.FontSize = fontSize;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (myTextBox.FontWeight != FontWeights.Bold)
            {
                myTextBox.FontWeight = FontWeights.Bold;
            }
            else
            {
                myTextBox.FontWeight = FontWeights.Normal;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (myTextBox.FontStyle != FontStyles.Italic)
            {
                myTextBox.FontStyle = FontStyles.Italic;
            }
            else
            {
                myTextBox.FontStyle = FontStyles.Normal;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (myTextBox.TextDecorations != TextDecorations.Underline)
            {
                myTextBox.TextDecorations = TextDecorations.Underline;
            }
            else
            {
                myTextBox.TextDecorations = null;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (myTextBox != null)
            {
                myTextBox.Foreground = Brushes.Red;
            }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (myTextBox != null)
            {
                if (myTextBox.Background == Brushes.Black)
                {
                    myTextBox.Foreground = Brushes.White;
                }
                else
                {
                    myTextBox.Foreground = Brushes.Black;
                }
            }
        }

        private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                myTextBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, myTextBox.Text);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Light.xaml", UriKind.Relative);
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
            if (myTextBox.Foreground == Brushes.White)
            {
                myTextBox.Foreground = Brushes.Black;
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Dark.xaml", UriKind.Relative);
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
            if (myTextBox.Foreground == Brushes.Black)
            {
                myTextBox.Foreground = Brushes.White;
            }

        }
    }
}
