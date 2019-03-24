<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Aluno.aspx.cs" Inherits="Form1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .auto-style1 {
            width: 83px;
        }
        .auto-style4 {
            width: 91px;
        }
        .auto-style5 {
            width: 83px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 357px">
            Gestão de Alunos<br />
            <br />
            <asp:Button ID="BtnInsert" runat="server" Text="Inserir" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="BtnUpdate" runat="server" Text="Atualizar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="BtnDelete" runat="server" Text="Apagar" />
            <br />
            <br />
            Dados do Aluno:<br />
            <br />
            Nome do Aluno:&nbsp;
            <asp:TextBox ID="TxBAluno" runat="server"></asp:TextBox>
            <br />
            <br />
            Nome do Encarregado de Educação:
            <asp:TextBox ID="TxBEE" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            Data de Nascimento:<br />
        <table style="width:42%;">
            <tr>
                <td class="auto-style1">Dia</td>
                <td class="auto-style4">Mês</td>
                <td class="auto-style5">Ano</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="auto-style4">
                    <asp:DropDownList ID="DropDownList2" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="auto-style5">
                    <asp:DropDownList ID="DropDownList3" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="BtnLoadDate1" runat="server" OnClick="BtnLoadDate1_Click" Text="Carregar Data" />
                </td>
            </tr>
            
        </table>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
