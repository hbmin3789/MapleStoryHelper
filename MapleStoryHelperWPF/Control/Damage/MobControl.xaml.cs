﻿using MapleStoryHelper.Standard.MapLib.Common;
using MapleStoryHelper.Standard.MobLib.Common;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WzComparerR2.CharaSim;

namespace MapleStoryHelperWPF.Control.Damage
{
    /// <summary>
    /// MobControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MobControl : UserControl
    {
        public MobControl()
        {
            InitializeComponent();
            Loaded += MobControl_Loaded;
        }

        private void MobControl_Loaded(object sender, RoutedEventArgs e)
        {
            InitCbWorld();
        }

        private void InitCbWorld()
        {
            List<string> source = new List<string>();
            var mapCategories = Enum.GetValues(typeof(EMapCategory));
            foreach(EMapCategory category in mapCategories)
            {
                source.Add(category.NameOf());
            }

            cbWorld.ItemsSource = source;
        }

        private void cbWorld_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbWorld.SelectedIndex != -1)
            {
                cbMonster.IsEnabled = true;

                var categories = Enum.GetValues(typeof(EMobMapCategory));
                EMobMapCategory category = (EMobMapCategory)categories.GetValue(cbWorld.SelectedIndex);
                cbMonster.ItemsSource = App.mapleWz.GetMobs(category);
            }
            else
            {
                cbMonster.IsEnabled = false;
            }
        }

        private void cbMonster_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbMonster.SelectedItem != null)
            {
                this.DataContext = cbMonster.SelectedItem;
            }
        }
    }
}
