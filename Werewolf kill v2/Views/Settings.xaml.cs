using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Werewolf_kill_v2;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Werewolf_kill_v2.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Settings : Page
    {
        public Settings()
        {
            this.InitializeComponent();
        }

        private void ExplosionRadioButton_Checked(object sender, RoutedEventArgs e)
        {
           
        }
        private void KillRadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void selfexplosioncheckbox_Checked(object sender, RoutedEventArgs e)
        {
            singleexplosionStackPanel.Visibility = Visibility.Visible;
        }

        private void selfexplosioncheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            singleexplosionStackPanel.Visibility = Visibility.Collapsed;
        }

        private void selfsavecheckbox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void controlernumSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            (Application.Current as App).controlernum = (int)e.NewValue;
        }

        private void gameStart_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame != null)
            {
                this.Frame.Navigate(typeof(gaming));
            }
        }

        private void lastwordSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

        }

        private void speaktimeSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

        }

        private void sheriffspeaktimeSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

        }

        private void playernumSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            (Application.Current as App).playernum = (int)e.NewValue;
        }

        private void PKSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

        }
    }
}
