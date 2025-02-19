﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Class;

namespace Master_Streaming
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public MainManager Mmanager { get; private set; }

        public App()
        {

            //reprend par défaut les données du Stub si fichier de persistance non existant
            //if (File.Exists("../../../../Master_Streaming/bin/Release/XML/Master_Streaming.xml"))
            //{
            //    Mmanager = new MainManager(new DataContractPersistance.DataContractPers());
            //    Mmanager.ChargeDonnées();
            //}

            //else
            //{
            //    Mmanager = new MainManager(new Stub.Stub());
            //    Mmanager.ChargeDonnées();
            //    Mmanager.Persistance = new DataContractPersistance.DataContractPers();
            //    Mmanager.SauvegardeDonnées();
            //}
            if (File.Exists("../../../../Master_Streaming/bin/Release/JSON/Master_Streaming.json"))
            {
                Mmanager = new MainManager(new DataContractPersistance.DataContractPersJSON());
                Mmanager.ChargeDonnées();
            }

            else
            {
                Mmanager = new MainManager(new Stub.Stub());
                Mmanager.ChargeDonnées();
                Mmanager.Persistance = new DataContractPersistance.DataContractPersJSON();
                Mmanager.SauvegardeDonnées();
            }
        }
    }
}
