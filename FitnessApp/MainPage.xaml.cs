using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FitnessApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        internal async static void ShowMessage(string strTitle, string Msg)
        {
            ContentDialog diag = new ContentDialog()
            {
                Title = strTitle,
                Content = Msg,
                PrimaryButtonText = "Ok"
            };
            await diag.ShowAsync();
        }

        private bool isValid()
        {

            bool validData = true;
            //Check Height in Feet
            string errMessage = "Please check the Error list" + Environment.NewLine;
            if (String.IsNullOrEmpty(txtAge.Text) || Convert.ToDouble(txtAge.Text) == 0
                || String.IsNullOrEmpty(txtHeight.Text) || Convert.ToDouble(txtHeight.Text) == 0
                || String.IsNullOrEmpty(txtWeight.Text) || Convert.ToDouble(txtWeight.Text) == 0)
            {

                validData = false;
                errMessage += "Please enter the valid Age, Weight and Height!" + Environment.NewLine;
            }
            else if (Convert.ToDouble(txtAge.Text) < 0 || Convert.ToDouble(txtHeight.Text) <0 || Convert.ToDouble(txtWeight.Text)<0)
            {
                validData = false;
                errMessage += "If any of your weight, height and age is less than 0, you are not part of this universe according to physics. Basically you are an ALIEN, this application is only for Humans!!" + Environment.NewLine;
            }

            if (!validData)
                MainPage.ShowMessage("Invalid Data", errMessage);
            return validData;

        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isValid())
                {
                    Calculator c = new Calculator(Convert.ToDouble(txtWeight.Text), Convert.ToDouble(txtHeight.Text), Convert.ToDouble(txtAge.Text));
                    lblCaloryValue.Text = "Calories:" + " " + c.Calory ;
                    lblProteinValue.Text = "Protein:" + " " + c.Proteins + " " + "grams";
                    lblCarbohydrateValue.Text = "Carbs:" + " " + c.Carbohydrate + " " + "grams";
                    lblFatValue.Text =  "Fat:" + " " + c.Fat +" " + "grams";
                    lblSugarValue.Text = "Sugar:" + " " + c.Sugar+" " + "grams" ;
                    lblSodiumValue.Text = "Sodium:" + " " + "1500 mgs to 2500 mgs";
                    lblCholesterolValue.Text = "Cholesterol:" + "\n" + "300 mgs - 500 mgs" + "\n" + "For people with heart disease problem : less than 200 mgs";

                }
            }
            catch (ArgumentOutOfRangeException ax)
            {
                MainPage.ShowMessage("Calculation Error", ax.ParamName);
            }
            catch (Exception ex)
            {
                MainPage.ShowMessage("Calculation Error", ex.Message);
            }

        }
        

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtAge.Text = "";
            txtHeight.Text = "";
            txtWeight.Text = "";
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

       

        private void ArticleButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ArticlePage));
        }
    }
}
