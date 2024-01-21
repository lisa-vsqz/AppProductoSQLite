using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.ViewModels;

namespace ProductoMVVMSQLite.Views;

public partial class DetalleProductoPage : ContentPage
{
    private Producto _producto;
    public DetalleProductoPage(Producto producto)
	{
		InitializeComponent();
		_producto = producto;
		BindingContext = new DetalleProductoViewModel(_producto);
		Nombre.Text=_producto.Nombre;
		Cantidad.Text = _producto.Cantidad.ToString();
		Descripcion.Text = _producto.Descripcion;
	}
    private async void OnClickEditarProducto(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NuevoProductoPage(_producto));
    }
}