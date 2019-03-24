<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CalendarioTestes.aspx.cs" Inherits="CalendarioTestes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
       body{
            font-size:large; 
            text-align:center;
        }
       #Data{
            text-align:center;
            border:solid black;
            float:left;
            width:95.5%;
            padding:2%;
        }
       #DataCal{
           width:40%;
           float:left;
           margin-left:5%;
           padding:2%;
           height: 166px;
        }
       #Dataload{
           text-align:left;
           width:48%;
           float:left;
           margin-left:2%;
           margin-top:2%;
       }
       #DataSelect{
           width: 40%;
           margin-left:2%;
           margin-top: 1%;
           float: left;
           text-align:left;
       }
        #Gestao{
            clear:left;
            border:solid black;
            padding-left:5%;
        }
        #Teste{
            clear:left;
            border:solid black;
            text-align:center;
            margin-top:2%;
        }
        .auto-style1 {
            width: 83px;
        }
        .auto-style4 {
            width: 91px;
        }
        .auto-style5 {
            width: 84px;
        }
        .auto-style6 {
            height: 23px;
            width: 145px;
        }
        .auto-style10 {
            height: 26px;
            width: 172px;
        }
        .auto-style11 {
            height: 23px;
            width: 158px;
        }
        .auto-style12 {
            width: 158px;
        }
        .auto-style13 {
            height: 26px;
            width: 158px;
        }
        .auto-style14 {
            height: 23px;
            width: 266px;
        }
        .auto-style15 {
            width: 266px;
        }
        .auto-style16 {
            height: 26px;
            width: 266px;
        }
        .auto-style17 {
            height: 23px;
            width: 172px;
        }
        .auto-style18 {
            width: 172px;
        }
        .auto-style19 {
            height: 23px;
            width: 234px;
        }
        .auto-style20 {
            width: 234px;
        }
        .auto-style21 {
            height: 26px;
            width: 234px;
        }
        .auto-style22 {
            width: 145px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
            CALENDÁRIO DE TESTES<br />
            <br />
            <div id="Data">
                <br />
                SELEÇÃO DE DATAS:
                <br />
                <br />
                <div id="DataCal">
                    <asp:Calendar ID="Calendar1" runat="server" Height="190px" Width="350px" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" NextPrevFormat="FullMonth" OnSelectionChanged="Calendar_SelectionChanged">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                    </asp:Calendar>
                    <br />
                </div>
                <div id="DataSelect">
                    <asp:TextBox ID="TxBLoadDate" runat="server"></asp:TextBox>
                    <asp:Button ID="BtnLoadDate" runat="server" Text="Carregar Data" OnClick="BtnLoadDate_Click" />
                    <br />
                    <br />
                    <table style="width:42%;">
                        <tr>
                        <td class="auto-style1">Dia</td>
                        <td class="auto-style4">Mês</td>
                        <td class="auto-style5">Ano</td>
                        <td>&nbsp;</td>
                        </tr>
                        <tr>
                        <td class="auto-style1">
                        <asp:DropDownList ID="DropDownListDia" runat="server">
                        </asp:DropDownList>
                        </td>
                        <td class="auto-style4">
                        <asp:DropDownList ID="DropDownListMes" runat="server">
                        </asp:DropDownList>
                        </td>
                        <td class="auto-style5">
                        <asp:DropDownList ID="DropDownListAno" runat="server">
                        </asp:DropDownList>
                        </td>
                        <td>
                        <asp:Button ID="BtnLoadDate1" runat="server" OnClick="BtnLoadDate1_Click" Text="Carregar Data" />
                        </td>
                        </tr>
                    </table>
                </div>
                <br />
                <br />
                <div id="Dataload">
                A 1ªData serve para inserir e atualizar, acrescente a 2ªData para listar testes!
                <br />
                <br />
                <asp:RadioButton ID="RBD1" runat="server" GroupName="Data" Checked="True" />
                1ªData:
                <asp:Label ID="LblData1" runat="server">inserir/atualizar</asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:RadioButton ID="RBD2" runat="server" GroupName="Data" />
                2ªData:
                <asp:Label ID="LblData2" runat="server">pesquisar</asp:Label>
                <br />
                <br />
                </div>
            </div>
            <br />
            <div id="Teste">
                <br />
                TESTES - TURMA/DISCIPLINA<br />
                <br />
                <table style="width: 98%; margin-top: 0px; height: 80px;">
                    <tr>
                        <td class="auto-style14">Ano de Escolaridade</td>
                        <td class="auto-style11">Turma</td>
                        <td class="auto-style17">Escola</td>
                        <td class="auto-style19">Disciplina</td>
                        <td class="auto-style6">ID</td>
                    </tr>
                    <tr>
                        <td class="auto-style15" >
                            <input id="Radio10" type="radio" />10ºAno
                            <input id="Radio11" type="radio" />11ºAno
                            <input id="Radio12" type="radio" />12ºAno</td>
                        <td class="auto-style12">
                        <asp:DropDownList ID="DropDownListTurma" runat="server">
                        </asp:DropDownList>
                        </td>
                        <td class="auto-style18">
                        <asp:DropDownList ID="DropDownListEscola" runat="server">
                        </asp:DropDownList>
                        </td>
                        <td class="auto-style20">
                        <asp:DropDownList ID="DropDownListDisciplina" runat="server">
                        </asp:DropDownList>
                        </td>
                        <td class="auto-style22">
                        <asp:Button ID="BtnSelect" runat="server" Text="Selecionar" OnClick="BtnSelect_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style16">
                        <asp:TextBox ID="TxBAno" runat="server"></asp:TextBox>
                        </td>
                        <td class="auto-style13">
                        <asp:TextBox ID="TxBTurma" runat="server"></asp:TextBox>
                        </td>
                        <td class="auto-style10">
                        <asp:TextBox ID="TxBEscola" runat="server" Width="132px"></asp:TextBox>
                        </td>
                        <td class="auto-style21">
                        <asp:TextBox ID="TxBDisciplina" runat="server"></asp:TextBox>
                        </td>
                        <td class="auto-style22">
                        <asp:TextBox ID="TxBID" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
            </div>
                <br />
            <div id="Gestao">
                <br />
            MENU DE GESTÃO
            <br />
            <br />
            <asp:Button ID="BtnInsert" runat="server" Text="Inserir" OnClick="BtnInsert_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
            <asp:Button ID="BtnSelectDisc" runat="server" Text="Pesquisar Disciplina" OnClick="BtnSelectDisc_Click" />
                &nbsp;&nbsp;<asp:Button ID="BtnSelectTur" runat="server" Text="Pesquisar Turma" OnClick="BtnSelectTur_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="BtnUpdate" runat="server" Text="Atualizar" OnClick="BtnUpdate_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
            <asp:Button ID="BtnDelete" runat="server" Text="Apagar" OnClick="BtnDelete_Click" />
            &nbsp;
            <br />
            <br />
                LISTAGEM DE TESTES<br />
                <asp:Label ID="LblMsg" runat="server"></asp:Label>
                <br />
                <br />
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Width="1000px">
                            <AlternatingRowStyle BackColor="#DCDCDC" />
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" />
                                <asp:BoundField DataField="Ano" HeaderText="Ano" />
                                <asp:BoundField DataField="Turma" HeaderText="Turma" />
                                <asp:BoundField DataField="Disciplina" HeaderText="Disciplina" />
                                <asp:BoundField DataField="Data" HeaderText="Data" />
                                <asp:BoundField DataField="Escola" HeaderText="Escola" />
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#0000A9" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#000065" />
                        </asp:GridView>
                    <br />
                  </div>  
                <br />
            <br />
    </form>
</body>
</html>
