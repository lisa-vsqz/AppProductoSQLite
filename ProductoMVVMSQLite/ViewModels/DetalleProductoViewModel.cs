using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.Utils;
using ProductoMVVMSQLite.Views;
using PropertyChanged;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductoMVVMSQLite.ViewModels
{
    public class DetalleProductoViewModel
    {

        public Producto _producto { get; set; }


        public DetalleProductoViewModel(Producto producto)
        {
            _producto = producto;
        }

        public ICommand BorrarProducto =>
            new Command(async () =>
            {
                App.productoRepository.Delete(_producto);
                Util.ListaProductos = App.productoRepository.GetAll();
                await App.Current.MainPage.Navigation.PopAsync();
            });
        public ICommand EditarProducto =>
            new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new NuevoProductoPage()
                {
                    BindingContext = _producto,
                }
                );
            });
    }
}
