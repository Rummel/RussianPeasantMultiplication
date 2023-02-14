using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Globalization;

//Text = "{Binding _model.Multiplier, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
// https://www.codeproject.com/Articles/683429/Guide-to-WPF-DataGrid-Formatting-Using-Bindings

namespace RussianPeasantMultiplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel _model = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();

            //this.DataContext = this;
            DC.DataContext = _model;
        }

        private void PreviewNumberInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _model.Calculate();
            MessageBox.Show("Multiplier: " + _model.Multiplier.ToString() + ",Multiplicand: " + _model.Multiplicand.ToString() + ", " + _model.Product + ", " + _model.Product2);
        }
    }
}
