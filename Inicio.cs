using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alunos_mySQL
{
    public partial class Inicio : Form
    {
        private Login Login1;
        public Inicio()
        {
            InitializeComponent();
        }

        private void PicBoxHelder_MouseHover(object sender, EventArgs e)
        {
            btnInicio.Visible = true;
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login1 = new Login();
            Login1.Show();
        }
    }
}
