using System.Windows;
using System.Windows.Controls;
using KeycardMenagmentSystem.Model;
using KeycardMenagmentSystem.ViewModel;

namespace KeycardMenagmentSystem.View
{
    public partial class ListingCard : UserControl
    {
        public ListingCard()
        {
            InitializeComponent();
            DataContext = new KeyCardListViewModel();
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

            Keycard selectedKeycard = (Keycard)List.SelectedItem;



        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (List.SelectedItem != null)
            {
                Keycard selectedKeycard = (Keycard)List.SelectedItem;

                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete the keycard with ID {selectedKeycard.KeycardID}?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    ((KeyCardListViewModel)DataContext).Keycards.Remove(selectedKeycard);
                    
                   
                    
                }
            }
            else
            {
                MessageBox.Show("Please select a keycard to delete.");
            }
        }
    }
}
