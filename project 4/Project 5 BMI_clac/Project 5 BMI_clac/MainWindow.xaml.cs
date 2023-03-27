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

namespace Project_5_BMI_clac
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      

        public object txtheight { get; private set; }
        public object txtweight { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double weight = Convert.ToDouble(txtweight.Text);
            double height = Convert.ToDouble(txtheight.Text);
            double result = 0.0;

            if(pound.Checked)
            {
                weight = weight / 2.205;
                result = weight / (height * height);
            }
            if(result > 18.5)
            {
                string show = " hou are underweight ";
            }
            else if(result < 25)
            {
               string Show = "you are normal weight";
            }
            else if(result < 30)
            {
                string show = " you are obese";
            }
            txtresult.Text = "your " + result.ToString("#.#") + "\r\n" + Show;
        }



        private void reset_Click(object sender, RoutedEventArgs e)
        {
            txtweight.Text = "";
            txtheight.Text = "";
            txtresult.Text = "";
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

      
    }
}
