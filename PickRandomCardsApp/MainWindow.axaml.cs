using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace PickRandomCardsApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void PickCards_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(CardCountInput.Text, out int numberOfCards))
            {
                var pickedCards = CardPicker.PickSomeCards(numberOfCards);
                DisplayText.Text = string.Join(", ", pickedCards);
            }
            else
            {
                DisplayText.Text = "Please enter a valid number.";
            }
        }
    }
}