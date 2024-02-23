using KeycardMenagmentSystem.Services;
using KeycardMenagmentSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Controls;
using System.Windows;

namespace KeycardMenagmentSystem.View
{
    /// <summary>
    /// Interaction logic for KeycardsView.xaml
    /// </summary>
    public partial class KeycardsView : UserControl
    {
        public KeycardsView()
        {
            InitializeComponent();
            // Assume GetKeycardsService implements IGetKeycardsService and is properly instantiated before being passed here.
            this.DataContext = new KeycardsViewModel(new GetKeycardsService()); // Adjusted to pass a new GetKeycardsService instance.

            // Ensure that column adjustment is done after the control is fully loaded
            this.Loaded += Logs_Loaded;
        }
        private void Logs_Loaded(object sender, RoutedEventArgs e)
        {
            AdjustListViewColumns(Keycards);
            Keycards.SizeChanged += (s, e) => AdjustListViewColumns(Keycards);
        }

        private void AdjustListViewColumns(ListView listView)
        {
            if (listView.View is GridView gridView && gridView.Columns.Count > 0)
            {
                // Calculate the total width available for all columns. Subtract SystemParameters.VerticalScrollBarWidth to accommodate the scrollbar
                var totalWidth = listView.ActualWidth - SystemParameters.VerticalScrollBarWidth - 4; // Subtract a few pixels to prevent triggering horizontal scrollbar

                // Distribute the width equally among columns
                var equalWidth = totalWidth / gridView.Columns.Count;

                foreach (var column in gridView.Columns)
                {
                    column.Width = equalWidth;
                }
            }
        }
    }
}
