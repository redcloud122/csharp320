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
using System.Text.RegularExpressions;

namespace ZipCode {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void uxZipCode_TextChanged(object sender, TextChangedEventArgs e)
    {
      string zipCodePattern = "^[1-9][0-9]{4}$|^[0-9]{5}-[0-9]{4}$|^([A-Za-z][0-9]){3}$";

      Match zc = Regex.Match(uxZipCode.Text, zipCodePattern);

      uxSubmit.IsEnabled = zc.Success;
    }
  }
}
