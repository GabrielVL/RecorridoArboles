using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RecorridoArboles
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        BinaryTree arbolito = new BinaryTree();
        Node tmpParent = new Node(15);
        Node tmpChild = null;
        Node nuevo = null;
        
        int valor = 0;
        string direccion = "left";

        public MainPage()
        {
            InitializeComponent();
        }
        async void Agregar(object sender, EventArgs e)
        {

            valor = Convert.ToInt32(NuevoNodo.Text);
            arbolito.insert(valor);
            NuevoNodo.Text = "";
        }
        private void Inorder(object sender, EventArgs e)
        {
            arbolito.printInorder();
            ResultadoRecorrido.Text = arbolito.orderValue.ToString();
            arbolito.orderValue = new StringBuilder();
        }
        private void Postorder(object sender, EventArgs e)
        {
            arbolito.printPostorder();
            ResultadoRecorrido.Text = arbolito.orderValue.ToString();
            arbolito.orderValue = new StringBuilder();
        }
        private void Preorder(object sender, EventArgs e)
        {
            arbolito.printPreorder();
            ResultadoRecorrido.Text = arbolito.orderValue.ToString();
            arbolito.orderValue = new StringBuilder();
        }
    }
    
}
