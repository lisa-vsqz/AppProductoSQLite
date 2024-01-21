using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.Utils;
using ProductoMVVMSQLite.Views;
using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace ProductoMVVMSQLite.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ProductoViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Producto> _listaProductos;

        public ObservableCollection<Producto> ListaProductos
        {
            get { return _listaProductos; }
            set
            {
                if (_listaProductos != value)
                {
                    _listaProductos = value;
                    OnPropertyChanged(nameof(ListaProductos));
                }
            }
        }

        public ProductoViewModel()
        {
            Util.ListaProductos = App.productoRepository.GetAll();
            ListaProductos = new ObservableCollection<Producto>(Util.ListaProductos);
        }

        public ICommand CrearProducto =>
            new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new NuevoProductoPage());
            });

        public ICommand VerProducto =>
            new Command<Producto>(async (producto) =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new DetalleProductoPage(producto));
            });

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}