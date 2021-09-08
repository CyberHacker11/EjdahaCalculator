using System;
using System.Collections.Generic;
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

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MinHeight = MaxHeight = Height;
            MinWidth = MaxWidth = Width;
        }

        private void Proccess(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                if (Equalss) btn_Clean_Click(this, e);
                if (Operand == default)
                {
                    if (btn.Content.ToString() != "," && !lbl_Display.Content.ToString().EndsWith(","))
                        lbl_Display.Content = (LeftLiteral = decimal.Parse($"{LeftLiteral.ToString()}{btn.Content}")).ToString();
                    else
                    {
                        if (!lbl_Display.Content.ToString().Contains(",")) lbl_Display.Content += btn.Content.ToString();
                        else if (lbl_Display.Content.ToString().Contains(",") && btn.Content.ToString() != ",")
                        {
                            lbl_Display.Content += btn.Content.ToString();
                            LeftLiteral = decimal.Parse(lbl_Display.Content.ToString());
                        }
                    }
                }
                else
                {
                    if (btn.Content.ToString() != "," && !lbl_Display.Content.ToString().EndsWith(","))
                        lbl_Display.Content = (RightLiteral = decimal.Parse($"{RightLiteral.ToString()}{btn.Content}")).ToString();
                    else
                    {
                        if (!lbl_Display.Content.ToString().Contains(",")) lbl_Display.Content += btn.Content.ToString();
                        else if (lbl_Display.Content.ToString().Contains(",") && btn.Content.ToString() != ",")
                        {
                            lbl_Display.Content += btn.Content.ToString();
                            RightLiteral = decimal.Parse(lbl_Display.Content.ToString());
                        }
                    }
                }
            }
        }

        private void btn_Pluse_Click(object sender, RoutedEventArgs e)
        {
            lbl_MicroDisplay.Content = $"{LeftLiteral} {Operand = '+'}";
            if (LeftLiteral != 0 && RightLiteral != 0)
            {
                lbl_MicroDisplay.Content = $"{lbl_Display.Content = (LeftLiteral += RightLiteral).ToString()} +";
                RightLiteral = default;
            }
            else if (RightLiteral == 0)
            {
                lbl_Display.Content = $"{LeftLiteral}";
            }
        }

        private void btn_Minuse_Click(object sender, RoutedEventArgs e)
        {
            lbl_MicroDisplay.Content = $"{LeftLiteral} {Operand = '-'}";
            if (LeftLiteral != 0 && RightLiteral != 0)
            {
                lbl_MicroDisplay.Content = $"{lbl_Display.Content = (LeftLiteral -= RightLiteral).ToString()} -";
                RightLiteral = default;
            }
            else if (RightLiteral == 0)
            {
                lbl_Display.Content = $"{LeftLiteral}";
            }
        }

        private void btn_Multiply_Click(object sender, RoutedEventArgs e)
        {
            lbl_MicroDisplay.Content = $"{LeftLiteral} {Operand = 'x'}";
            if (LeftLiteral != 0 && RightLiteral != 0)
            {
                lbl_MicroDisplay.Content = $"{lbl_Display.Content = (LeftLiteral *= RightLiteral).ToString()} x";
                RightLiteral = default;
            }
        }

        private void btn_Division_Click(object sender, RoutedEventArgs e)
        {
            lbl_MicroDisplay.Content = $"{LeftLiteral} {Operand = '÷'}";
            if (LeftLiteral != 0 && RightLiteral != 0)
            {
                lbl_MicroDisplay.Content = $"{lbl_Display.Content = (LeftLiteral /= RightLiteral).ToString()} ÷";
                RightLiteral = default;
            }
        }

        private void btn_Percent_Click(object sender, RoutedEventArgs e)
        {
            if (LeftLiteral != 0 && RightLiteral != 0)
            {
                lbl_MicroDisplay.Content = $"{LeftLiteral} {Operand} {RightLiteral * RightLiteral / 100}";
                lbl_Display.Content = $"{RightLiteral * RightLiteral / 100}";
                RightLiteral = RightLiteral * RightLiteral / 100;
            }
        }

        private void btn_Equal_Click(object sender, RoutedEventArgs e)
        {
            if (RightLiteral != default)
            {
                lbl_MicroDisplay.Content = $" {LeftLiteral} {Operand} {RightLiteral} = ";
                if (Operand == '+') lbl_Display.Content = (LeftLiteral += RightLiteral).ToString();
                else if (Operand == '-') lbl_Display.Content = (LeftLiteral -= RightLiteral).ToString();
                else if (Operand == 'x') lbl_Display.Content = (LeftLiteral *= RightLiteral).ToString();
                else if (Operand == '÷') lbl_Display.Content = (LeftLiteral /= RightLiteral).ToString();
                RightLiteral = default;
                Operand = default;
                Equalss = true;
            }
        }

        private void btn_Clean_Click(object sender, RoutedEventArgs e)
        {
            lbl_Display.Content = "0";
            lbl_MicroDisplay.Content = "";
            LeftLiteral = RightLiteral = default;
            Operand = default;
            Equalss = false;
        }

        private void btn_CE_Click(object sender, RoutedEventArgs e)
        {
            if (Equalss)
            {
                lbl_Display.Content = "0";
                lbl_MicroDisplay.Content = "";
                LeftLiteral = RightLiteral = default;
                Operand = default;
                Equalss = false;
            }
            else
            {
                lbl_Display.Content = "0";
                if(lbl_MicroDisplay.Content.ToString() == "") LeftLiteral = RightLiteral = default;
                else RightLiteral = default;
            }
        }

        private void btn_Backspace_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (LeftLiteral != 0 && RightLiteral == default)
            {
                if (LeftLiteral.ToString().Length > 1)
                {
                    for (int i = 0; i < LeftLiteral.ToString().Length - 1; i++)
                    {
                        sb.Append(LeftLiteral.ToString()[i]);
                    }
                    lbl_Display.Content = (LeftLiteral = decimal.Parse(sb.ToString())).ToString();
                }
                else
                {
                    lbl_Display.Content = (LeftLiteral = 0).ToString();
                }
            }
            else if (LeftLiteral != 0 && RightLiteral != 0)
            {
                if (RightLiteral.ToString().Length > 1)
                {
                    for (int i = 0; i < RightLiteral.ToString().Length - 1; i++)
                    {
                        sb.Append(RightLiteral.ToString()[i]);
                    }
                    lbl_Display.Content = (RightLiteral = decimal.Parse(sb.ToString())).ToString();
                }
                else
                {
                    lbl_Display.Content = (RightLiteral = 0).ToString();
                }
            }
        }

        private void btn_MinPlus_Click(object sender, RoutedEventArgs e)
        {
            if (LeftLiteral != 0 && RightLiteral == default)
            {
                LeftLiteral -= (LeftLiteral * 2);
                lbl_Display.Content = LeftLiteral.ToString();
            }
            else if (LeftLiteral < 0 && RightLiteral == default)
            {
                LeftLiteral += (LeftLiteral * 2);
                lbl_Display.Content = LeftLiteral.ToString();
            }
            else if (RightLiteral != 0 && RightLiteral != default)
            {
                RightLiteral -= (RightLiteral * 2);
                lbl_Display.Content = RightLiteral.ToString();
            }
            else if (RightLiteral < 0)
            {
                RightLiteral += (RightLiteral * 2);
                lbl_Display.Content = RightLiteral.ToString();
            }
        }

        private void btn_SquareRoot3_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.Parse(lbl_Display.Content.ToString()) > 0)
            {
                lbl_MicroDisplay.Content = $"√({lbl_Display.Content})";
                lbl_Display.Content = $"{Math.Sqrt(double.Parse(lbl_Display.Content.ToString()))}";
            }
        }

        private void btn_SquareRoot2_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.Parse(lbl_Display.Content.ToString()) > 0)
            {
                lbl_MicroDisplay.Content = $"sqrt({lbl_Display.Content})";
                lbl_Display.Content = $"{double.Parse(lbl_Display.Content.ToString()) * double.Parse(lbl_Display.Content.ToString())}";
            }
        }

        private void btn_SquareRoot1_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.Parse(lbl_Display.Content.ToString()) > 0)
            {
                lbl_MicroDisplay.Content = $"1/({lbl_Display.Content})";
                lbl_Display.Content = $"{1 / double.Parse(lbl_Display.Content.ToString())}";
            }
        }

        public decimal LeftLiteral { get; set; }
        public decimal RightLiteral { get; set; }
        public char Operand { get; set; }
        public bool Equalss { get; set; }
    }
}