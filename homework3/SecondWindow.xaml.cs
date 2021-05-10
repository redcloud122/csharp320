using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;


namespace homework3 {
  /// <summary>
  /// Interaction logic for SecondWindow.xaml
  /// </summary>
  public partial class SecondWindow : Window {
    public SecondWindow()
    {
      InitializeComponent();

      var users = new List<Models.User>();

      users.Add(new Models.User { Name = "Dave", Password = "1DavePwd" });
      users.Add(new Models.User { Name = "Steve", Password = "2StevePwd" });
      users.Add(new Models.User { Name = "Lisa", Password = "3LisaPwd" });

      uxList.ItemsSource = users;
    }

    private void OnColumnHeaderName_Click(object sender, RoutedEventArgs e)
    {
      _sortColumnPerColumnHeader("Name");
    }

    private void OnColumnHeaderPassword_Click(object sender, RoutedEventArgs e)
    {
      _sortColumnPerColumnHeader("Password");
    }
    
    private void _sortColumnPerColumnHeader(string headerName)
    {
      CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);

      view.SortDescriptions.Clear();

      view.SortDescriptions.Add(new SortDescription(headerName, ListSortDirection.Ascending));
    }
  }
}
