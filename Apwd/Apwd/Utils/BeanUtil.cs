using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Me.Amon.Apwd.Model;
using Me.Amon.Apwd.Views;

namespace Me.Amon.Apwd.Utils
{
    public class BeanUtil
    {
        public static void ShowAlert(string alert)
        {
            new Alert(alert).Show();
        }

        public static void ShowAlert(string alert, string title)
        {
            new Alert(alert, title).Show();
        }

        public static void ShowError(Exception error)
        {
            new Error(error).Show();
        }

        public static void ShowError(Exception error, string title)
        {
            new Error(error.Message, title).Show();
        }

        public static void ShowPrompt(Exception error)
        {
            new Error(error).Show();
        }

        public static void ShowPrompt(Exception error, string title)
        {
            new Error(error.Message, title).Show();
        }

        public static void ShowLoading()
        {
            if (Loading != null)
            {
                Loading.Visibility = Visibility.Visible;
            }
        }

        public static void HideLoading()
        {
            if (Loading != null)
            {
                Loading.Visibility = Visibility.Collapsed;
            }
        }

        public static Grid Loading { get; set; }

        public static List<LibHeader> _LibHeader;
    }
}
