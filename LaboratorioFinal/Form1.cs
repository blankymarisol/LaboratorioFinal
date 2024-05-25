using LaboratorioFinal.DATA.DataAccess;
using LaboratorioFinal.DATA.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace LaboratorioFinal
{
    public partial class Form1 : Form
    {
        ConsolasBD Clscone = new ConsolasBD();
        Catologo usr = new Catologo();
        List<Catologo> todos;
        ClsCursor cursor1 = new ClsCursor();
        private ConsolasBD consola;

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeComponent();
        }

        private void buttonInsertar_Click(object sender, EventArgs e)
        {
            Clscone.Insertar(textBoxNombre.Text, textBoxCompania.Text, dateTimePickerFechaLanzamiento.Value, textBoxGeneracion.Text);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            //Clscone.Actualizar(textBoxNombre.Text, textBoxCompania.Text, dateTimePickerFechaLanzamiento.Value, textBoxGeneracion.Text);
        }
    }    
}
