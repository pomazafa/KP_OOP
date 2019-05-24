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
using System.Windows.Shapes;

namespace MyProject
{
    /// <summary>
    /// Логика взаимодействия для NewRecipe.xaml
    /// </summary>
    public partial class NewRecipe : Window
    {
        PATIENT currentPat;
        USERS user;
        public NewRecipe(PATIENT pat, USERS user)
        {
            InitializeComponent();
            currentPat = pat;
            this.user = user;
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            DateTime d;
            if (Med.Text != "" && Quant.Text != "" && DateBlock.Text != "" && DateTime.TryParse(DateBlock.Text, out d) && d > DateTime.Now)
            {
                RECIPE recipe = new RECIPE();
                UnitOfWork u = new UnitOfWork();

                recipe.MEDICAMENT = Med.Text;
                recipe.QUANTITY = Quant.Text;
                recipe.EXPIRATION_DATE = d;
                recipe.PATIENT_ID = currentPat.PATIENT_ID;
                u.Recipes.Create(recipe);
                u.Save();
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    Run run = new Run("                                  Рецепт\n");
                    run.FontSize = 28;

                    Run run2 = new Run("\t\tФ.И.О. пациента " + currentPat.SURNAME + " " + currentPat.FIRSTNAME + " " +
                        currentPat.FATHERSNAME + "\n\t\tМедикамент " + Med.Text + "\n\t\tВ количестве " + Quant.Text + "\n\t\tРецепт действенен по " + DateBlock.Text + "\n\n\t\tВрач " + user.SURNAME + " " + user.NAME + " " + user.FATHERSNAME + "\n\t\tПодпись   ____________________\n");
                    StackPanel stack = new StackPanel();
                    TextBlock visual = new TextBlock();
                    visual.Inlines.Add(run);
                    TextBlock visual2 = new TextBlock();
                    visual.Inlines.Add(run2);

                    visual.Margin = new Thickness(100);
                    visual.HorizontalAlignment = HorizontalAlignment.Stretch;

                    visual.TextWrapping = TextWrapping.Wrap;

                    stack.Children.Add(visual);
                    stack.Children.Add(visual2);
                    Size pageSize = new Size(printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight);
                    visual.Measure(pageSize);
                    visual.Arrange(new Rect(0, 0, pageSize.Width, pageSize.Height));
                    stack.Orientation = Orientation.Vertical;
                    printDialog.PrintVisual(stack, "Печать рецепта");

                    Close();
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля! \nПроверьте дату на корректность!");
            }
        }
    }
}
