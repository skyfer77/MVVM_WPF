using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Data;
using CompareDirectory.Models;
using System.Windows.Input;

namespace CompareDirectory.ViewModels
{
    class FilesViewModel : DependencyObject
    {

        private FileList _model;
        private DelegateCommand _selectDirCommand;
        private DelegateCommand _selectDirCommand2;

        public string SelectedPath
        {
            get { return (string)GetValue(SelectedPathProperty); }
            set { SetValue(SelectedPathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedPathProperty =
            DependencyProperty.Register("SelectedPath", typeof(string), typeof(FilesViewModel), new PropertyMetadata(string.Empty));

        public string SelectedPath2
        {
            get { return (string)GetValue(SelectedPath2Property); }
            set { SetValue(SelectedPath2Property, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedPath2Property =
            DependencyProperty.Register("SelectedPath2", typeof(string), typeof(FilesViewModel), new PropertyMetadata(string.Empty));


        public ICommand SelectDirCommand
        {
            get
            {
                return _selectDirCommand ?? (_selectDirCommand = new DelegateCommand(ShowDialog));
            }
        }

        public ICommand SelectDirCommand2
        {
            get
            {
                return _selectDirCommand2 ?? (_selectDirCommand2 = new DelegateCommand(ShowDialog2));
            }
        }

        private void ShowDialog()
        {
            var path = _model.ShowDialog();
            if (!string.IsNullOrEmpty(path))
            {
                SelectedPath = path;
            }
            RefreshData();
        }
        private void ShowDialog2()
        {
            var path = _model.ShowDialog2();
            if (!string.IsNullOrEmpty(path))
            {
                SelectedPath2 = path;
            }
            RefreshData();
        }


        public ICollectionView Items
        {
            get { return (ICollectionView)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ICollectionView), typeof(FilesViewModel), new PropertyMetadata(null));

        public FilesViewModel()
        {
            RefreshData();
            _model = new FileList();
        }

        public void RefreshData()
        {
            Items = CollectionViewSource.GetDefaultView(FileList.GenerateList());
        }

    }
}
