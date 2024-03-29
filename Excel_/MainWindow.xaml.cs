﻿using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace Excel_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenExcel(object sender, RoutedEventArgs e)
        {
            FileInfo file = new FileInfo(tbxExcelPath.Text);
            if ((tbxExcelPath.Text.EndsWith(".xlsx") || tbxExcelPath.Text.EndsWith(".xls")) && file.Exists == true)
            {
                ExcelPackage package = new ExcelPackage(file);
                DataTable dt = ExcelPackageExtension.ToDataTable(package);
                dataGrid.DataContext = dt.DefaultView;
                dataGrid.Visibility = Visibility.Visible;
                Edit_Btn.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Файл не найден");
            }
        }
        private void Edit(object sender, RoutedEventArgs e)
        {
            dataGrid.IsReadOnly = false;
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            DataGrid tempDt = (DataGrid)sender;
           
        }
    }
}
