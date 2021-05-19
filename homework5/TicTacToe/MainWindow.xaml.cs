using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Collections.Generic;


namespace TicTacToe {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {

    private const string c_player1 = "X";
    private const string c_player2 = "O";
    private int glbCount = 0;

    public MainWindow()
    {
      InitializeComponent();
    }

    private void uxNewGame_Click(object sender, RoutedEventArgs e)
    {
      glbCount = 0;

      foreach (var b in uxGrid.Children.OfType<Button>()) {
        b.Content = null;
        b.IsEnabled = true;
      }

      uxGrid.IsEnabled = true;
      uxTurn.Text = "";
    }

    private void uxExit_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      Button _btn = sender as Button;

      if (_btn.Content is null) {
        glbCount++;
        _btn.IsEnabled = false;

        if (glbCount == 0) {
          _btn.Content = c_player1;
        }
        else {
          string tmp = c_player1;

          if (glbCount % 2 == 0) {
            _btn.Content = c_player2;
            tmp = c_player2;
          }
          else _btn.Content = c_player1;

          if (_Is3InARow(_btn)) {
            uxTurn.Text = "Game Over, " + tmp + " is a Winner!";
            uxGrid.IsEnabled = false;
          }
        }
      }
    }

    private bool _Is3InARow(Button btn)
    {
      string[] coords = btn.Tag.ToString().Split(',');

      Regex regex_horizontal = new Regex(coords[0] + ",");
      int _count_horizontal = _Count3(btn, regex_horizontal);

      if (_count_horizontal != 3) {
        Regex regex_vertical = new Regex("^[0-2]," + coords[1]);
        int _count_vertical = _Count3(btn, regex_vertical);

        if (_count_vertical != 3) {
          var _btnsSelectedToCheck =
            from b in uxGrid.Children.OfType<Button>()
            where b.Tag.ToString().Equals("0,0") ||
                  b.Tag.ToString().Equals("1,1") ||
                  b.Tag.ToString().Equals("2,2")
            select b;

          int _count_diagnoal_1 = _Count3(_btnsSelectedToCheck.ToList(), btn.Content.ToString());

          if (_count_diagnoal_1 != 3) {
            _btnsSelectedToCheck =
              from b in uxGrid.Children.OfType<Button>()
              where b.Tag.ToString().Equals("2,0") ||
                    b.Tag.ToString().Equals("1,1") ||
                    b.Tag.ToString().Equals("0,2")
              select b;

            int _count_diagnoal_2 = _Count3(_btnsSelectedToCheck.ToList(), btn.Content.ToString());

            if (_count_diagnoal_2 != 3)
              return false;
            else
              return true;
          }
          else
            return true;
        }
        else
          return true;
      }
      else
        return true;
    }

    private int _Count3(Button btn, Regex regex)
    {
      var _btnsSelectedToCheck =
        from b in uxGrid.Children.OfType<Button>()
        where regex.IsMatch(b.Tag.ToString())
        select b;

      int _count = _Count3(_btnsSelectedToCheck.ToList(), btn.Content.ToString());

      return _count;
    }

    private int _Count3(List<Button> _btnsSelectedToCheck, string player)
    {
      int _count = 0;

      foreach (var b in _btnsSelectedToCheck) {
        if (b.Content != null) {
          if (b.Content.Equals(player)) _count++;
        }
      }

      return _count;
    }
  }
}
