﻿using Class;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Master_Streaming
{
    /// <summary>
    /// Logique d'interaction pour UC_listeSeries.xaml
    /// </summary>
    public partial class UC_listeSeries : UserControl
    {
        public ProfilManager manager => (App.Current as App).Mmanager.ProfilCourant;
        public UC_listeSeries()
        {
            InitializeComponent();
            filtrage.SelectedItem = "Toutes dates";
            trie.SelectedItem = "Alphabétique";
            DataContext = manager;
        }

        private void filtrage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(filtrage.SelectedItem != null)
            {
                ContentControlDetail.Visibility = Visibility.Hidden;
                manager.Filtrage(filtrage.SelectedItem.ToString());
                if(trie.SelectedItem != null)
                    manager.tri(trie.SelectedItem.ToString()); //pour relancer le trie à chaque filtrage (qui est alphabétique par défaut). trie.SelectedItem est null a la première ouverture des données d'un profil utilisateur
            }
                
        }

        private void trie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (trie.SelectedItem != null)
            {
                ContentControlDetail.Visibility = Visibility.Hidden;
                manager.tri(trie.SelectedItem.ToString());
            }

        }

        private void MylisteSerie_MouseSimpleClick(object sender, MouseButtonEventArgs e)
        {
            if(manager.OeuvreSélectionnée != null)
            {
                ContentControlDetail.Visibility = Visibility.Visible;
                ContentControlDetail.Content = new UC_Detail();
            }
        }
    }
}
