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
        ArbolBinario arbolito = new ArbolBinario();
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
            nuevo = new Node(valor);
            if (arbolito.root == null)
            { 
                if (NuevoNodo.Text != "")
                {
                arbolito.addNode(valor, direccion);
                tmpParent = arbolito.root;
                LabelRecorrido.Text = tmpParent.key.ToString();
                }
            }
            else
            {
                if (direccion == "right")
                {
                    tmpParent = arbolito.root;
                    tmpChild = arbolito.root.right;
                    arbolito.move(nuevo, tmpParent, tmpChild);
                }
                else if (direccion == "left")
                {
                    tmpParent = arbolito.root;
                    tmpChild = arbolito.root.left;
                    arbolito.move(nuevo, tmpParent, tmpChild);
                }
                LabelRecorrido.Text = tmpParent.key.ToString();
                tmpParent = tmpChild;
            }
            if (NuevoNodo.Text.Equals(""))
            {
                await DisplayAlert("Error", "Debe escribir un numero", "De acuerdo!");
            }
                        
        }

        private void Derecha(object sender, EventArgs e)
        {
            direccion = "right";
            tmpParent.direction = direccion;
            tmpChild = tmpParent.right;
            tmpParent = arbolito.move(nuevo, tmpParent, tmpChild);
        }

        private void Izquierda(object sender, EventArgs e)
        {
            direccion = "left";
            tmpParent.direction = direccion;
            tmpChild = tmpParent.left;
            tmpParent = arbolito.move(nuevo, tmpParent, tmpChild);
        }
        private void Inorder(object sender, EventArgs e)
        {
            arbolito.printInorder();
            ResultadoRecorrido.Text = arbolito.order.ToString();
            arbolito.order = new StringBuilder();
        }
        private void Postorder(object sender, EventArgs e)
        {
            arbolito.printPostorder();
            ResultadoRecorrido.Text = arbolito.order.ToString();
            arbolito.order = new StringBuilder();
        }
        private void Preorder(object sender, EventArgs e)
        {
            arbolito.printPreorder();
            ResultadoRecorrido.Text = arbolito.order.ToString();
            arbolito.order = new StringBuilder();
        }
    }
    
}
