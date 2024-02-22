using KeycardMenagmentSystem.Services;
using KeycardMenagmentSystem.ViewModel;
using System.Windows.Controls;
using System.Windows;

namespace KeycardMenagmentSystem.View
{
    public partial class Logs : UserControl
    {
        public Logs()
        {
            InitializeComponent();
            this.DataContext = new LogsViewModel(new GetLogsService());

            // Ensure that column adjustment is done after the control is fully loaded
            this.Loaded += Logs_Loaded;
        }

        private void Logs_Loaded(object sender, RoutedEventArgs e)
        {
            AdjustListViewColumns(LogList);
            LogList.SizeChanged += (s, e) => AdjustListViewColumns(LogList);
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

