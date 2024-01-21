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

namespace ProductoMVVMSQLite.ViewModels
{
    public class NuevoProductoViewModel
    {

        public string Nombre { get; set; }
        public string Cantidad { get; set; }
        public string Descripcion { get; set; }
        public Producto _producto { get; set; }

        public NuevoProductoViewModel()
        {

        }

        public NuevoProductoViewModel(Producto producto)
        {
            _producto = producto;
        }

        public ICommand GuardarProducto =>
            new Command(async () =>
            {
                if (_producto != null)
                {
                    _producto.Nombre = Nombre;
                    _producto.Descripcion= Descripcion;
                    _producto.Cantidad = Int32.Parse(Cantidad);
                    App.productoRepository.Update(_producto);
                    Util.ListaProductos = App.productoRepository.GetAll();
                    await App.Current.MainPage.Navigation.PopAsync();
                }
                else 
                {
                    Producto producto = new Producto
                    {
                        Nombre = Nombre,
                        Descripcion = Descripcion,
                        Cantidad = Int32.Parse(Cantidad)
                    };
                    App.productoRepository.Add(producto);
                    Util.ListaProductos = App.productoRepository.GetAll();
                    await App.Current.MainPage.Navigation.PopAsync();
                }
            });

    }
}
