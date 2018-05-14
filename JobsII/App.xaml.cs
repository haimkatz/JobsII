﻿using GalaSoft.MvvmLight.Threading;
using JobsII.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using JobsII.Views;


namespace JobsII
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
          
    {
        static App()
        {
            DispatcherHelper.Initialize();
            //Database.SetInitializer(new mySeed());
          
        }
    }
}
