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
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //#region 读取全局变量的初始配置设置并配置到UI
            //selfexplosioncheckbox.IsChecked = (Application.Current as App).isSelfExplosion;
            //if ((Application.Current as App).isSingleExplosion)
            //    explosiononceRB.IsChecked = true;
            //else
            //    explosiontwiceRB.IsChecked = true;
            //if ((Application.Current as App).isKillAll)
            //    killallRB.IsChecked = true;
            //else
            //    killsideRB.IsChecked = true;
            //selfsavecheckbox.IsChecked = (Application.Current as App).isSelfAntidote;
            //PKSlider.Value = (Application.Current as App).PKnum;
            //lastwordSlider.Value = (Application.Current as App).lastwordtime;
            //speaktimeSlider.Value = (Application.Current as App).speaktime;
            //sheriffspeaktimeSlider.Value = (Application.Current as App).sheriffspeaktime;
            //controlernumSlider.Value = (Application.Current as App).controlernum;
            //playernumSlider.Value = (Application.Current as App).playernum;
            //#endregion
        }

        private void ExplosionRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if ((string)(sender as RadioButton).Content == "单爆")
                (Application.Current as App).isSingleExplosion = true;
            if ((string)(sender as RadioButton).Content == "双爆")
                (Application.Current as App).isSingleExplosion = false;
        }
        private void KillRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if ((string)(sender as RadioButton).Content == "屠城")
                (Application.Current as App).isKillAll = true;
            if ((string)(sender as RadioButton).Content == "屠边")
                (Application.Current as App).isKillAll = false;
        }

        private void selfexplosioncheckbox_Checked(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).isSelfExplosion = true;
            explosiontimesStackPanel.Visibility = Visibility.Visible;
        }

        private void selfexplosioncheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).isSelfExplosion = false;
            explosiontimesStackPanel.Visibility = Visibility.Collapsed;
        }

        private void selfsavecheckbox_Checked(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).isSelfAntidote = true;
        }
        private void selfsavecheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).isSelfAntidote = true;
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
            (Application.Current as App).lastwordtime = (int)e.NewValue;
        }

        private void speaktimeSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            (Application.Current as App).speaktime = (int)e.NewValue;
        }

        private void sheriffspeaktimeSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            (Application.Current as App).sheriffspeaktime = (int)e.NewValue;
        }

        private void playernumSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            (Application.Current as App).playernum = (int)e.NewValue;
        }
        private void controlernumSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            (Application.Current as App).controlernum = (int)e.NewValue;
        }

        private void PKSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            (Application.Current as App).PKnum = (int)e.NewValue;
        }
    }
}
