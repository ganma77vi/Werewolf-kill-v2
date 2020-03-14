using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Werewolf_kill_v2.Views;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace Werewolf_kill_v2
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySpiltView.IsPaneOpen = !MySpiltView.IsPaneOpen;
        }

        private void HamburgerListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HamburgerListBox.SelectedIndex == 0)
            {
                if (this.Frame != null)
                {
                    MyFrame.Navigate(typeof(Settings));
                }
            }
            if (HamburgerListBox.SelectedIndex == 1)
            {
                if (this.Frame != null)
                {
                    MyFrame.Navigate(typeof(Fupan));
                }
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (HamburgerListBox.SelectedIndex == 0)
            {
                if (this.Frame != null)
                {
                    MyFrame.Navigate(typeof(Settings));
                }
            }
            if (HamburgerListBox.SelectedIndex == 1)
            {
                if (this.Frame != null)
                {
                    MyFrame.Navigate(typeof(Fupan));
                }
            }
        }
    }
}
