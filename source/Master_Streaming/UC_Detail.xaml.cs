﻿using Class;
using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour UC_Detail.xaml
    /// </summary>
    public partial class UC_Detail : UserControl
    {
        ProfilManager manager => (Application.Current as App).Mmanager.ProfilCourant;
        public UC_Detail()
        {
            InitializeComponent();
            InitializeColorDetail((App.Current.MainWindow as MainWindow).header.ColorMode);
            DataContext = manager.OeuvreSélectionnée;
            Text_BtnWatch();
            if((Application.Current.MainWindow as MainWindow).contentControlMain.Content is UC_Recherche)
            {
                btn_suppr.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// initialise la couleur de l'user control s'il vient dêtre affiché
        /// </summary>
        /// <param name="MyToggleButton"></param>
        private void InitializeColorDetail(ToggleButton MyToggleButton)
        {
            if((App.Current.MainWindow as MainWindow).ColorMode == 0)
            {
                bordure.BorderBrush = Brushes.White;
            }
            else
            {
                bordure.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#232323");
            }
        }

        private void Text_BtnWatch()
        {
            btn_watch.Content = GetText();
        }

        /// <summary>
        /// permet d'avoir un texte dynamique dans le bouton d'ajout ou de suppression à la Watchlist
        /// </summary>
        /// <returns></returns>
        private string GetText()
        {
            return manager.MyWatchlist.OeuvresVisionnees.Contains(new OeuvreWatch(DateTime.Now, manager.OeuvreSélectionnée)) ? "Supprimer de la Watchlist" : "Ajouter à la Watchlist"; 
        }

        private void btn_watch_Click(object sender, RoutedEventArgs e)
        {

            if (manager.MyWatchlist.OeuvresVisionnees.Contains(new OeuvreWatch(DateTime.Now, manager.OeuvreSélectionnée)))
            {
                manager.MyWatchlist.SupprimerOeuvre(manager.OeuvreSélectionnée);
            }
            else
            {
                manager.MyWatchlist.AjouterOeuvre(manager.OeuvreSélectionnée);
            }
            (sender as Button).Content = GetText();
        }

        private void Button_Click_chevron(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void btn_modif_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).contentControlMain.Content = new UC_modifier();
        }

        private void Btn_supprimer_click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            if (manager.OeuvreIsInWatchlist(manager.OeuvreSélectionnée))
            {
                manager.MyWatchlist.SupprimerOeuvre(manager.OeuvreSélectionnée);
            }
            manager.SupprimerOeuvre(manager.OeuvreSélectionnée);
            if((App.Current.MainWindow as MainWindow).contentControlMain.Content is UC_Master MyUcMaster){
                manager.tri(MyUcMaster.uc_listSeries.trie.SelectedItem.ToString()); //pour relancer le tri car il est écrasé
            }
        }
    }
}
