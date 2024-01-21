using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.ViewModels;

namespace ProductoMVVMSQLite.Views;

public partial class NuevoProductoPage : ContentPage
{
    Producto _producto;
	public NuevoProductoPage()
	{
		InitializeComponent();
		BindingContext = new NuevoProductoViewModel();
	}
    public NuevoProductoPage(Producto producto)
    {
        InitializeComponent();
        _producto= producto;
        BindingContext = new NuevoProductoViewModel(_producto);
        Nombre.Text = _producto.Nombre;
        Cantidad.Text = _producto.Cantidad.ToString();
        Descripcion.Text = _producto.Descripcion;
    }
}
