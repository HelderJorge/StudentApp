using System;
using System.Collections.Generic;
using System.ComponentModel;
using MySql.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Alunos_mySQL
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txbPass.Text=="E+" && txbUti.Text == "Helder")
            {
                MessageBox.Show("Login Efetuado");
                btnInsert.Visible = true;
                menuStrip1.Visible = true;

            }
            //procurar a informação em ficheiro
            else if(txbPass.Text == "" && txbUti.Text == "")
            {
                menuStrip1.Visible = true;
            }
            else
            {
                MessageBox.Show("Verifique os dados");
                txbUti.Clear();
                txbPass.Clear();
            }
        }

        //falta fazer a escrita em ficheiro
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            { 
                MessageBox.Show("Dados registados com sucesso!");
                txbUti.Clear();
                txbPass.Clear();   
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            btnInsert.Visible = false;
            menuStrip1.Visible = false;
        }

        private void notasDosTesteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            TesteAluno nt = new TesteAluno();
            nt.Show();
        }

        private void notasDosAlunosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            NotasAlunos na = new NotasAlunos();
            na.Show();
        }

        private void alunosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Alunos al = new Alunos();
            al.Show();
        }

        private void testesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Testes te = new Testes();
            te.Show();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
                Application.Exit();
        }
    }
}
