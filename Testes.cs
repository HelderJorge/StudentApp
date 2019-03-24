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
    public partial class Testes : Form
    {
        public Testes()
        {
            InitializeComponent();
        }

        private void Testes_FormClosed(object sender, FormClosedEventArgs e)
        {
                Application.Exit();
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

        private void entradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lo = new Login();
            lo.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
                TxBLoadDate.Text = dateTimePicker1.Value.ToShortDateString();
        }

        private void Testes_Load(object sender, EventArgs e)
        {
            DBTConnectMySQL ligacao = new DBTConnectMySQL();
            LblMsg.Text = "Existem registos de " + ligacao.Count().ToString() + " testes. ";
        }

        protected void BtnLoadDate_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateTime = Convert.ToDateTime(TxBLoadDate.Text);
                dateTimePicker1.Value = dateTime;
                if (rBData1.Checked)
                {
                    txBData1.Text = dateTimePicker1.Value.ToShortDateString();
                    rBData2.Checked = true;
                }
                else
                {
                    txBData2.Text = dateTimePicker1.Value.ToShortDateString();
                    rBData1.Checked = true;
                }
            }
            catch
            {
                TxBLoadDate.Text = "Data Incorreta!";
            }
           
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            DBTConnectMySQL ligacao = new DBTConnectMySQL();
            if (ligacao.Insert(txBData1.Text, txBDisc.Text, txBAno.Text, txBTurma.Text, txBEscola.Text))
            {
                LblMsg.Text = ligacao.Bind(ref dataGridView1, txBAno.Text, txBTurma.Text, txBEscola.Text, txBData1.Text, txBData2.Text);
                LblMsg.Text += "Existem registos de " + ligacao.Count().ToString() + " testes. ";
            }
            else
            {
                LblMsg.Text = "Erro na inserção! ";
            }
        }

        private void btnSelectTurma_Click(object sender, EventArgs e)
        {
            DBTConnectMySQL ligacao = new DBTConnectMySQL();
            LblMsg.Text = ligacao.Bind(ref dataGridView1, txBAno.Text, txBTurma.Text, txBEscola.Text, txBData1.Text, txBData2.Text);
        }

        private void btnSelectDisc_Click(object sender, EventArgs e)
        {
            DBTConnectMySQL ligacao = new DBTConnectMySQL();
            LblMsg.Text = ligacao.Bind(ref dataGridView1, txBDisc.Text, txBData1.Text, txBData2.Text);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DBTConnectMySQL ligacao = new DBTConnectMySQL();
            if (ligacao.Update(txBID.Text, txBData1.Text, txBDisc.Text, txBAno.Text, txBTurma.Text, txBEscola.Text))
            {
                LblMsg.Text = ligacao.Bind(ref dataGridView1, txBAno.Text, txBTurma.Text, txBEscola.Text, txBData1.Text, txBData2.Text);
                LblMsg.Text = "Existem registos de " + ligacao.Count().ToString() + " testes. ";
            }
            else
            {
                LblMsg.Text = "Erro na Atualização! ";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DBTConnectMySQL ligacao = new DBTConnectMySQL();
            if (ligacao.Delete(txBID.Text))
            {
                LblMsg.Text = ligacao.Bind(ref dataGridView1, txBAno.Text, txBTurma.Text, txBEscola.Text, txBData1.Text, txBData2.Text);
                LblMsg.Text = "Existem registos de " + ligacao.Count().ToString() + " testes. ";
            }
            else
            {
                LblMsg.Text = "Erro a Apagar! ";
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txBID.Text = dataGridView1.SelectedCells[0].Value.ToString();
            DBTConnectMySQL ligacao = new DBTConnectMySQL();
            txBID.Text.Trim();
            if (ligacao.DevolverTeste(txBID.Text, ref txBData1, ref txBAno, ref txBTurma, ref txBEscola, ref txBDisc))
            {
                LblMsg.Text = "Seleção completada! ";
            }
            else LblMsg.Text = "Erro a Seleccionar! ";
        }
    }
}
