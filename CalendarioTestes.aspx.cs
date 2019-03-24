using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CalendarioTestes: System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Carregar datas
        if (!IsPostBack)
        {
            int i;
            for (i = 1; i <= 31; i++)
            {
                DropDownListDia.Items.Add(i.ToString());
            }
            for (i = 1; i <= 12; i++)
            {
                DropDownListMes.Items.Add(i.ToString());
            }
            for (i = DateTime.Today.Year; i >= 1900; i--)
            {
                DropDownListAno.Items.Add(i.ToString());
            }
            DropDownListAno.Items.FindByText("2000").Selected = true;
        }

        //nº de registos
        DBConnectMySQL ligacao = new DBConnectMySQL();
        LblMsg.Text = "Existem registos de "+ligacao.Count().ToString()+ " testes. ";

    }

    //selecção de data com calendário
    protected void Calendar_SelectionChanged(object sender, EventArgs e)
    {
        if (RBD1.Checked)
        {
        LblData1.Text = Calendar1.SelectedDate.ToShortDateString();
        }
        else
        {
        LblData2.Text = Calendar1.SelectedDate.ToShortDateString();
        }
        
    }

    //Carregar data a partir de caixa de texto
    protected void BtnLoadDate_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime dateTime = Convert.ToDateTime(TxBLoadDate.Text);
            Calendar1.TodaysDate = dateTime;
            Calendar1.SelectedDate = Calendar1.TodaysDate;
            if (RBD1.Checked)
            {
                LblData1.Text = Calendar1.SelectedDate.ToShortDateString();
            }
            else
            {
                LblData2.Text = Calendar1.SelectedDate.ToShortDateString();
            }
        }
        catch
        {
            if(RBD1.Checked) LblData1.Text = "Data Incorreta!";
            else LblData2.Text = "Data Incorreta!";
        }
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + TxBLoadDate.Text + "');)", true);
    }

    //Carregar data a partir de lista
    protected void BtnLoadDate1_Click(object sender, EventArgs e)
    {
        string data = DropDownListDia.SelectedValue + "/" + DropDownListMes.SelectedValue + "/" + DropDownListAno.SelectedValue;
        try
        {
            DateTime dateTime = Convert.ToDateTime(data);
            Calendar1.TodaysDate = dateTime;
            Calendar1.SelectedDate = Calendar1.TodaysDate;
            if (RBD1.Checked)
            {
                LblData1.Text = Calendar1.SelectedDate.ToShortDateString();
            }
            else
            {
                LblData2.Text = Calendar1.SelectedDate.ToShortDateString();
            }
        }
        catch
        {
            if (RBD1.Checked) LblData1.Text = "Data Incorreta!";
            else LblData2.Text = "Data Incorreta!";
        }
    }

    //insere e mostra lista de testes da turma
    protected void BtnInsert_Click(object sender, EventArgs e)
    {
        DBConnectMySQL ligacao = new DBConnectMySQL();
        if (ligacao.Insert(LblData1.Text,TxBDisciplina.Text,TxBAno.Text,TxBTurma.Text,TxBEscola.Text))
        {
            LblMsg.Text = ligacao.Bind(ref GridView1, TxBAno.Text, TxBTurma.Text, TxBEscola.Text, LblData1.Text, LblData2.Text);
            LblMsg.Text += "Existem registos de " + ligacao.Count().ToString() + " testes. ";
            GridView1.DataBind();
        }
        else
        {
            LblMsg.Text = "Erro na inserção! ";
        }
    }

    //apaga e mostra lista de testes da turma
    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        DBConnectMySQL ligacao = new DBConnectMySQL();
        if (ligacao.Delete(TxBID.Text))
        {
            LblMsg.Text = ligacao.Bind(ref GridView1, TxBAno.Text, TxBTurma.Text, TxBEscola.Text, LblData1.Text, LblData2.Text);
            LblMsg.Text = "Existem registos de " + ligacao.Count().ToString() + " testes. ";
            GridView1.DataBind();
        }
        else
        {
            LblMsg.Text = "Erro a Apagar! ";
        }
    }

    //seleciona teste por ID
    protected void BtnSelect_Click(object sender, EventArgs e)
    {
        DBConnectMySQL ligacao = new DBConnectMySQL();
        TxBID.Text.Trim();
        if (ligacao.DevolverTeste(TxBID.Text, ref LblData1, ref TxBAno, ref TxBTurma, ref TxBEscola, ref TxBDisciplina))
        {
            LblMsg.Text = "Seleção completada! ";
        }
        else LblMsg.Text = "Erro a Seleccionar! ";
    }

    //atualiza e mostra lista de testes
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        DBConnectMySQL ligacao = new DBConnectMySQL();
        if (ligacao.Update(TxBID.Text, LblData1.Text, TxBDisciplina.Text, TxBAno.Text, TxBTurma.Text, TxBEscola.Text))
        {
            LblMsg.Text = ligacao.Bind(ref GridView1, TxBAno.Text, TxBTurma.Text, TxBEscola.Text, LblData1.Text, LblData2.Text);
            LblMsg.Text = "Existem registos de " + ligacao.Count().ToString() + " testes. ";
            GridView1.DataBind();
        }
        else
        {
            LblMsg.Text = "Erro na Atualização! ";
        }
    }

    //testes por disciplina
    protected void BtnSelectDisc_Click(object sender, EventArgs e)
    {
        DBConnectMySQL ligacao = new DBConnectMySQL();
        LblMsg.Text = ligacao.Bind(ref GridView1,TxBDisciplina.Text, LblData1.Text,LblData2.Text);
        GridView1.DataBind();
    }

    //testes por turma
    protected void BtnSelectTur_Click(object sender, EventArgs e)
    {
        DBConnectMySQL ligacao = new DBConnectMySQL();
        LblMsg.Text = ligacao.Bind(ref GridView1, TxBAno.Text, TxBTurma.Text, TxBEscola.Text, LblData1.Text, LblData2.Text);
        GridView1.DataBind();
    }
}