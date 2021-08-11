using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Media;
using Excel = Microsoft.Office.Interop.Excel;



namespace Sharp_Color_Tool
{
    public partial class frmPrincipal : Form
    {
        public ListViewColumnSorter lvwColumnSorter;
        public ListViewColumnSorter lvwColumnSorter2;

        public string RespostaMSG;
        public frmPrincipal()
        {

            InitializeComponent();



            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.lstTintas.ListViewItemSorter = lvwColumnSorter;

            lvwColumnSorter2 = new ListViewColumnSorter();
            this.lstTintasFinalizadas.ListViewItemSorter = lvwColumnSorter2;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

            Height = Convert.ToInt32(580 * Globais.Fator_Altura);
            Width = Convert.ToInt32(950 * Globais.Fator_Largura);
            BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
            txtData.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
            txtRelogio.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
            txtRelogio.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            txtData.ForeColor = System.Drawing.Color.Gray;

            cmdAtualizar.Width = Convert.ToInt32(Globais.Largura_Botoes);
            cmdAtualizar.Height = Convert.ToInt32(Globais.Altura_Botoes);
            cmdAtualizar.Left = Convert.ToInt32(12 * Globais.Fator_Largura);
            cmdAtualizar.BackColor = System.Drawing.Color.Transparent;
            cmdAtualizar.Enabled = true;

            cmdNew.Width = Convert.ToInt32(Globais.Largura_Botoes);
            cmdNew.Height = Convert.ToInt32(Globais.Altura_Botoes);
            cmdNew.Left = Convert.ToInt32((29 * Globais.Fator_Largura) + Globais.Largura_Botoes);
            cmdNew.Enabled = true;

            cmdEdit.Width = Convert.ToInt32(Globais.Largura_Botoes);
            cmdEdit.Height = Convert.ToInt32(Globais.Altura_Botoes);
            cmdEdit.Left = Convert.ToInt32(((29 * Globais.Fator_Largura) + (Globais.Largura_Botoes) * 2));
            cmdEdit.Enabled = false;

            cmdExluir.Width = Convert.ToInt32(Globais.Largura_Botoes);
            cmdExluir.Height = Convert.ToInt32(Globais.Altura_Botoes);
            cmdExluir.Left = Convert.ToInt32(((29 * Globais.Fator_Largura) + (Globais.Largura_Botoes) * 3));
            cmdExluir.Enabled = false;

            cmdIniciar.Width = Convert.ToInt32(Globais.Largura_Botoes);
            cmdIniciar.Height = Convert.ToInt32(Globais.Altura_Botoes);
            cmdIniciar.Left = Convert.ToInt32(((29 * Globais.Fator_Largura) + (Globais.Largura_Botoes) * 4));
            cmdIniciar.Enabled = false;

            cmdPausar.Width = Convert.ToInt32(Globais.Largura_Botoes);
            cmdPausar.Height = Convert.ToInt32(Globais.Altura_Botoes);
            cmdPausar.Left = Convert.ToInt32(((29 * Globais.Fator_Largura) + (Globais.Largura_Botoes) * 5));
            cmdPausar.Enabled = false;

            cmdFinalizar.Width = Convert.ToInt32(Globais.Largura_Botoes);
            cmdFinalizar.Height = Convert.ToInt32(Globais.Altura_Botoes);
            cmdFinalizar.Left = Convert.ToInt32(((29 * Globais.Fator_Largura) + (Globais.Largura_Botoes) * 6));
            cmdFinalizar.Enabled = false;

            cmdReabrir.Width = Convert.ToInt32(Globais.Largura_Botoes);
            cmdReabrir.Height = Convert.ToInt32(Globais.Altura_Botoes);
            cmdReabrir.Left = Convert.ToInt32(((29 * Globais.Fator_Largura) + (Globais.Largura_Botoes) * 7));
            cmdReabrir.Enabled = false;

            cmdFaturar.Width = Convert.ToInt32(Globais.Largura_Botoes);
            cmdFaturar.Height = Convert.ToInt32(Globais.Altura_Botoes);
            cmdFaturar.Left = Convert.ToInt32(((29 * Globais.Fator_Largura) + (Globais.Largura_Botoes) * 8));
            cmdFaturar.Enabled = false;

            cmdSair.Width = Convert.ToInt32(Globais.Largura_Botoes);
            cmdSair.Height = Convert.ToInt32(Globais.Altura_Botoes);


            Painel_Opcoes.Width = 32;
            //Configurações da ListView Passsagens
            lstTintas.GridLines = true;
            lstTintas.View = View.Details;
            lstTintas.FullRowSelect = true;
            lstTintas.AllowColumnReorder = true;

            Globais.Config();

            //Criação das Colunas da ListView
            lstTintas.Columns.Add("Nº OS", Globais.LstTIntas_Coluna_NumeroOS);
            lstTintas.Columns.Add("Data Cadastro", Globais.LstTIntas_Coluna_DataCadastro, HorizontalAlignment.Right);
            lstTintas.Columns.Add("Tipo de OS", Globais.LstTIntas_Coluna_TipoOS, HorizontalAlignment.Center);
            lstTintas.Columns.Add("Cliente", Globais.LstTIntas_Coluna_Cliente, HorizontalAlignment.Right);
            lstTintas.Columns.Add("Veículo", Globais.LstTIntas_Coluna_Veiculo, HorizontalAlignment.Left);
            lstTintas.Columns.Add("Placa", Globais.LstTIntas_Coluna_Placa, HorizontalAlignment.Center);
            lstTintas.Columns.Add("Grupo de Cores", Globais.LstTIntas_Coluna_GrupoCores, HorizontalAlignment.Center);
            lstTintas.Columns.Add("Cor", Globais.LstTIntas_Coluna_Cor, HorizontalAlignment.Center);
            lstTintas.Columns.Add("Montadora", Globais.LstTIntas_Coluna_Montadora, HorizontalAlignment.Center);
            lstTintas.Columns.Add("Código", Globais.LstTIntas_Coluna_CodigoCor, HorizontalAlignment.Center);
            lstTintas.Columns.Add("Quantidade", Globais.LstTIntas_Coluna_Quantidade, HorizontalAlignment.Center);
            lstTintas.Columns.Add("Tipo Pintura", Globais.LstTIntas_Coluna_Pintura, HorizontalAlignment.Center);
            lstTintas.Columns.Add("Corpo de Prova", Globais.LstTIntas_Coluna_CorpoProva, HorizontalAlignment.Center);
            lstTintas.Columns.Add("Previsão de Entrega", Globais.LstTIntas_Coluna_Previsao, HorizontalAlignment.Right);
            lstTintas.Columns.Add("Status", Globais.LstTIntas_Coluna_StatusOperacao, HorizontalAlignment.Center);
            lstTintas.Columns.Add("Inicio", Globais.LstTIntas_Coluna_Inicio, HorizontalAlignment.Center);
            lstTintas.Columns.Add("Fim", Globais.LstTIntas_Coluna_Fim, HorizontalAlignment.Center);
            lstTintas.Columns.Add("Tempo", Globais.LstTIntas_Coluna_Tempo, HorizontalAlignment.Center);
            lstTintas.Columns.Add("Entrega", Globais.LstTIntas_Coluna_Entrega, HorizontalAlignment.Center);
            lstTintas.Columns.Add("Prioridade", Globais.LstTIntas_Coluna_Prioridade, HorizontalAlignment.Center);
            lstTintas.Columns.Add("Colorista", Globais.LstTIntas_Coluna_Colorista, HorizontalAlignment.Center);
            lstTintas.Columns.Add("Data Faturamento", Globais.LstTIntas_Coluna_DataFaturamento, HorizontalAlignment.Center);
            lstTintas.Columns.Add("Valor de Custo", Globais.LstTIntas_Coluna_ValorCusto, HorizontalAlignment.Right);
            lstTintas.Columns.Add("Valor de Venda", Globais.LstTIntas_Coluna_ValorVenda, HorizontalAlignment.Right);
            lstTintas.Columns.Add("Markup", Globais.LstTIntas_Coluna_Markup, HorizontalAlignment.Right);
            lstTintas.Columns.Add("Chapinhas", Globais.LstTIntas_Coluna_Chapinhas, HorizontalAlignment.Center);
            lstTintas.Columns.Add("Existente", 0);
            lstTintas.Columns.Add("Carga", 0);
            lstTintas.Columns.Add("NumeroPedido", 0);

            Int32 Posicao1 = Globais.LstTIntas_Coluna_NumeroOS;
            Int32 Posicao2 = Posicao1 + Globais.LstTIntas_Coluna_DataCadastro;
            Int32 Posicao3 = Posicao2 + Globais.LstTIntas_Coluna_TipoOS;
            Int32 Posicao4 = Posicao3 + Globais.LstTIntas_Coluna_Cliente;
            Int32 Posicao5 = Posicao4 + Globais.LstTIntas_Coluna_Veiculo;
            Int32 Posicao6 = Posicao5 + Globais.LstTIntas_Coluna_Placa;
            Int32 Posicao7 = Posicao6 + Globais.LstTIntas_Coluna_GrupoCores;
            Int32 Posicao8 = Posicao7 + Globais.LstTIntas_Coluna_Cor;
            Int32 Posicao9 = Posicao8 + Globais.LstTIntas_Coluna_Montadora;
            Int32 Posicao10 = Posicao9 + Globais.LstTIntas_Coluna_CodigoCor;
            Int32 Posicao11 = Posicao10 + Globais.LstTIntas_Coluna_Quantidade;
            Int32 Posicao12 = Posicao11 + Globais.LstTIntas_Coluna_Pintura;
            Int32 Posicao13 = Posicao12 + Globais.LstTIntas_Coluna_CorpoProva;
            Int32 Posicao14 = Posicao13 + Globais.LstTIntas_Coluna_Previsao;
            Int32 Posicao15 = Posicao14 + Globais.LstTIntas_Coluna_StatusOperacao;
            Int32 Posicao16 = Posicao15 + Globais.LstTIntas_Coluna_Inicio;
            Int32 Posicao17 = Posicao16 + Globais.LstTIntas_Coluna_Fim;
            Int32 Posicao18 = Posicao17 + Globais.LstTIntas_Coluna_Tempo;
            Int32 Posicao19 = Posicao18 + Globais.LstTIntas_Coluna_Entrega;
            Int32 Posicao20 = Posicao19 + Globais.LstTIntas_Coluna_Prioridade;
            Int32 Posicao21 = Posicao20 + Globais.LstTIntas_Coluna_Colorista;
            Int32 Posicao22 = Posicao21 + Globais.LstTIntas_Coluna_DataFaturamento;
            Int32 Posicao23 = Posicao22 + Globais.LstTIntas_Coluna_ValorCusto;
            Int32 Posicao24 = Posicao23 + Globais.LstTIntas_Coluna_ValorVenda;
            Int32 Posicao25 = Posicao24 + Globais.LstTIntas_Coluna_Markup;
            Int32 Posicao26 = Posicao25 + Globais.LstTIntas_Coluna_Chapinhas;

            cmdLSTColumn1.Location = new Point(0, 16);
            cmdLSTColumn1.Size = new Size((Globais.LstTIntas_Coluna_NumeroOS + 2), 20);
            cmdLSTColumn1.Text = lstTintas.Columns[0].Text;

            cmdLSTColumn2.Location = new Point(Posicao1, 16);
            cmdLSTColumn2.Size = new Size(Globais.LstTIntas_Coluna_DataCadastro, 20);
            cmdLSTColumn2.Text = lstTintas.Columns[1].Text;

            cmdLSTColumn3.Location = new Point(Posicao2, 16);
            cmdLSTColumn3.Size = new Size(Globais.LstTIntas_Coluna_TipoOS, 20);
            cmdLSTColumn3.Text = lstTintas.Columns[2].Text;

            cmdLSTColumn4.Location = new Point(Posicao3, 16);
            cmdLSTColumn4.Size = new Size(Globais.LstTIntas_Coluna_Cliente, 20);
            cmdLSTColumn4.Text = lstTintas.Columns[3].Text;

            cmdLSTColumn5.Location = new Point(Posicao4, 16);
            cmdLSTColumn5.Size = new Size(Globais.LstTIntas_Coluna_Veiculo, 20);
            cmdLSTColumn5.Text = lstTintas.Columns[4].Text;

            cmdLSTColumn6.Location = new Point(Posicao5, 16);
            cmdLSTColumn6.Size = new Size(Globais.LstTIntas_Coluna_Placa, 20);
            cmdLSTColumn6.Text = lstTintas.Columns[5].Text;

            cmdLSTColumn7.Location = new Point(Posicao6, 16);
            cmdLSTColumn7.Size = new Size(Globais.LstTIntas_Coluna_GrupoCores, 20);
            cmdLSTColumn7.Text = lstTintas.Columns[6].Text;

            cmdLSTColumn8.Location = new Point(Posicao7, 16);
            cmdLSTColumn8.Size = new Size(Globais.LstTIntas_Coluna_Cor, 20);
            cmdLSTColumn8.Text = lstTintas.Columns[7].Text;

            cmdLSTColumn9.Location = new Point(Posicao8, 16);
            cmdLSTColumn9.Size = new Size(Globais.LstTIntas_Coluna_Montadora, 20);
            cmdLSTColumn9.Text = lstTintas.Columns[8].Text;

            cmdLSTColumn10.Location = new Point(Posicao9, 16);
            cmdLSTColumn10.Size = new Size(Globais.LstTIntas_Coluna_CodigoCor, 20);
            cmdLSTColumn10.Text = lstTintas.Columns[9].Text;

            cmdLSTColumn11.Location = new Point(Posicao10, 16);
            cmdLSTColumn11.Size = new Size(Globais.LstTIntas_Coluna_Quantidade, 20);
            cmdLSTColumn11.Text = lstTintas.Columns[10].Text;

            cmdLSTColumn12.Location = new Point(Posicao11, 16);
            cmdLSTColumn12.Size = new Size(Globais.LstTIntas_Coluna_Pintura, 20);
            cmdLSTColumn12.Text = lstTintas.Columns[11].Text;

            cmdLSTColumn13.Location = new Point(Posicao12, 16);
            cmdLSTColumn13.Size = new Size(Globais.LstTIntas_Coluna_CorpoProva, 20);
            cmdLSTColumn13.Text = lstTintas.Columns[12].Text;

            cmdLSTColumn14.Location = new Point(Posicao13, 16);
            cmdLSTColumn14.Size = new Size(Globais.LstTIntas_Coluna_Previsao, 20);
            cmdLSTColumn14.Text = lstTintas.Columns[13].Text;

            cmdLSTColumn15.Location = new Point(Posicao14, 16);
            cmdLSTColumn15.Size = new Size(Globais.LstTIntas_Coluna_StatusOperacao, 20);
            cmdLSTColumn15.Text = lstTintas.Columns[14].Text;

            cmdLSTColumn16.Location = new Point(Posicao15, 16);
            cmdLSTColumn16.Size = new Size(Globais.LstTIntas_Coluna_Inicio, 20);
            cmdLSTColumn16.Text = lstTintas.Columns[15].Text;

            cmdLSTColumn17.Location = new Point(Posicao16, 16);
            cmdLSTColumn17.Size = new Size(Globais.LstTIntas_Coluna_Fim, 20);
            cmdLSTColumn17.Text = lstTintas.Columns[16].Text;

            cmdLSTColumn18.Location = new Point(Posicao17, 16);
            cmdLSTColumn18.Size = new Size(Globais.LstTIntas_Coluna_Tempo, 20);
            cmdLSTColumn18.Text = lstTintas.Columns[17].Text;

            cmdLSTColumn19.Location = new Point(Posicao18, 16);
            cmdLSTColumn19.Size = new Size(Globais.LstTIntas_Coluna_Entrega, 20);
            cmdLSTColumn19.Text = lstTintas.Columns[18].Text;

            cmdLSTColumn20.Location = new Point(Posicao19, 16);
            cmdLSTColumn20.Size = new Size(Globais.LstTIntas_Coluna_Prioridade, 20);
            cmdLSTColumn20.Text = lstTintas.Columns[19].Text;

            cmdLSTColumn21.Location = new Point(Posicao20, 16);
            cmdLSTColumn21.Size = new Size(Globais.LstTIntas_Coluna_Colorista, 20);
            cmdLSTColumn21.Text = lstTintas.Columns[20].Text;

            cmdLSTColumn22.Location = new Point(Posicao21, 16);
            cmdLSTColumn22.Size = new Size(Globais.LstTIntas_Coluna_DataFaturamento, 20);
            cmdLSTColumn22.Text = lstTintas.Columns[21].Text;

            cmdLSTColumn23.Location = new Point(Posicao22, 16);
            cmdLSTColumn23.Size = new Size(Globais.LstTIntas_Coluna_ValorCusto, 20);
            cmdLSTColumn23.Text = lstTintas.Columns[22].Text;

            cmdLSTColumn24.Location = new Point(Posicao23, 16);
            cmdLSTColumn24.Size = new Size(Globais.LstTIntas_Coluna_ValorVenda, 20);
            cmdLSTColumn24.Text = lstTintas.Columns[23].Text;

            cmdLSTColumn25.Location = new Point(Posicao24, 16);
            cmdLSTColumn25.Size = new Size(Globais.LstTIntas_Coluna_Markup, 20);
            cmdLSTColumn25.Text = lstTintas.Columns[24].Text;

            cmdLSTColumn26.Location = new Point(Posicao25, 16);
            cmdLSTColumn26.Size = new Size(Globais.LstTIntas_Coluna_Chapinhas, 20);
            cmdLSTColumn26.Text = lstTintas.Columns[25].Text;

            cmdLSTColumn27.Location = new Point(Posicao26, 16);
            cmdLSTColumn27.Size = new Size((lstTintas.Width - Posicao26), 20);
            cmdLSTColumn27.Text = string.Empty;


            //Configurações da ListView Passsagens
            lstTintasFinalizadas.GridLines = true;
            lstTintasFinalizadas.View = View.Details;
            lstTintasFinalizadas.FullRowSelect = true;
            lstTintasFinalizadas.AllowColumnReorder = true;

            //Criação das Colunas da ListView
            lstTintasFinalizadas.Columns.Add("Nº OS", Globais.LstTIntas_Coluna_NumeroOS);
            lstTintasFinalizadas.Columns.Add("Data Cadastro", Globais.LstTIntas_Coluna_DataCadastro, HorizontalAlignment.Right);
            lstTintasFinalizadas.Columns.Add("Tipo de OS", Globais.LstTIntas_Coluna_TipoOS, HorizontalAlignment.Center);
            lstTintasFinalizadas.Columns.Add("Cliente", Globais.LstTIntas_Coluna_Cliente, HorizontalAlignment.Right);
            lstTintasFinalizadas.Columns.Add("Veículo", Globais.LstTIntas_Coluna_Veiculo, HorizontalAlignment.Left);
            lstTintasFinalizadas.Columns.Add("Placa", Globais.LstTIntas_Coluna_Placa, HorizontalAlignment.Center);
            lstTintasFinalizadas.Columns.Add("Grupo de Cores", Globais.LstTIntas_Coluna_GrupoCores, HorizontalAlignment.Center);
            lstTintasFinalizadas.Columns.Add("Cor", Globais.LstTIntas_Coluna_Cor, HorizontalAlignment.Center);
            lstTintasFinalizadas.Columns.Add("Montadora", Globais.LstTIntas_Coluna_Montadora, HorizontalAlignment.Center);
            lstTintasFinalizadas.Columns.Add("Código", Globais.LstTIntas_Coluna_CodigoCor, HorizontalAlignment.Center);
            lstTintasFinalizadas.Columns.Add("Quantidade", Globais.LstTIntas_Coluna_Quantidade, HorizontalAlignment.Center);
            lstTintasFinalizadas.Columns.Add("Tipo Pintura", Globais.LstTIntas_Coluna_Pintura, HorizontalAlignment.Center);
            lstTintasFinalizadas.Columns.Add("Corpo de Prova", Globais.LstTIntas_Coluna_CorpoProva, HorizontalAlignment.Center);
            lstTintasFinalizadas.Columns.Add("Previsão de Entrega", Globais.LstTIntas_Coluna_Previsao, HorizontalAlignment.Right);
            lstTintasFinalizadas.Columns.Add("Status", Globais.LstTIntas_Coluna_StatusOperacao, HorizontalAlignment.Center);
            lstTintasFinalizadas.Columns.Add("Inicio", Globais.LstTIntas_Coluna_Inicio, HorizontalAlignment.Center);
            lstTintasFinalizadas.Columns.Add("Fim", Globais.LstTIntas_Coluna_Fim, HorizontalAlignment.Center);
            lstTintasFinalizadas.Columns.Add("Tempo", Globais.LstTIntas_Coluna_Tempo, HorizontalAlignment.Center);
            lstTintasFinalizadas.Columns.Add("Entrega", Globais.LstTIntas_Coluna_Entrega, HorizontalAlignment.Center);
            lstTintasFinalizadas.Columns.Add("Prioridade", Globais.LstTIntas_Coluna_Prioridade, HorizontalAlignment.Center);
            lstTintasFinalizadas.Columns.Add("Colorista", Globais.LstTIntas_Coluna_Colorista, HorizontalAlignment.Center);
            lstTintasFinalizadas.Columns.Add("Data Faturamento", Globais.LstTIntas_Coluna_DataFaturamento, HorizontalAlignment.Center);
            lstTintasFinalizadas.Columns.Add("Valor de Custo", Globais.LstTIntas_Coluna_ValorCusto, HorizontalAlignment.Right);
            lstTintasFinalizadas.Columns.Add("Valor de Venda", Globais.LstTIntas_Coluna_ValorVenda, HorizontalAlignment.Right);
            lstTintasFinalizadas.Columns.Add("Markup", Globais.LstTIntas_Coluna_Markup, HorizontalAlignment.Right);
            lstTintasFinalizadas.Columns.Add("Chapinhas", Globais.LstTIntas_Coluna_Chapinhas, HorizontalAlignment.Center);
            lstTintasFinalizadas.Columns.Add("Existente", 0);
            lstTintasFinalizadas.Columns.Add("Carga", 0);
            lstTintasFinalizadas.Columns.Add("NumeroPedido", 0);
            lstTintasFinalizadas.Columns.Add("Operador", 50);

            menuStrip1.Renderer = new MyRenderer();
            lstTintasFinalizadas.Scrollable = true;
            carrega_LST_tintas();
            AtualizaLSTOSAberta();
            Globais.Config();


        }


        public void AtualizaLSTOSAberta()
        {
            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);

            try
            {

                string _aguardando = "Aguardando";
                string _Pausado = "PAUSADO";
                string _EmProducao = "EM PRODUÇÃO";

                //limpa o listview
                lstTintas.Items.Clear();

                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();
                //define o tipo do comando como texto 
                cmd.CommandText = "Select * from Agendamentos where Status_Operacao = '" + _aguardando + "' or Status_Operacao = '" + _Pausado + "' OR Status_Operacao = '" + _EmProducao + "' order by Prioridade asc";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                //define um item listview
                ListViewItem item;

                //inicia leitura do datareader
                while (dr.Read())
                {
                    item = new ListViewItem();
                    item.Text = dr["Código"].ToString();

                    //preenche o listview com itens
                    for (int i = 1; i < dr.FieldCount; i++)
                    {
                        DateTime Data_Cadastro = Convert.ToDateTime(dr["Data_Cadastro"]);
                        DateTime Previsao = Convert.ToDateTime(dr["Previsao_Entrega"]);
                        string inicio = dr["Inicio"].ToString().ToUpper();
                        string final = dr["Fim"].ToString().ToUpper();
                        string Tempo = dr["Tempo"].ToString().ToUpper();

                        item.SubItems.Add(Data_Cadastro.ToShortDateString());
                        item.SubItems.Add(dr["Tipo_OS"].ToString());
                        item.SubItems.Add(dr["Cliente"].ToString().ToUpper());
                        item.SubItems.Add(dr["Veiculo"].ToString().ToUpper());
                        item.SubItems.Add(dr["Placa"].ToString().ToUpper());
                        item.SubItems.Add(dr["Grupo_Cores"].ToString().ToUpper());
                        item.SubItems.Add(dr["Cor"].ToString().ToUpper());
                        item.SubItems.Add(dr["Montadora"].ToString().ToUpper());
                        item.SubItems.Add(dr["Cod_Cor"].ToString().ToUpper());
                        item.SubItems.Add(dr["Quantidade"].ToString().ToUpper());
                        item.SubItems.Add(dr["Pintura"].ToString().ToUpper());
                        item.SubItems.Add(dr["Corpo_Prova"].ToString().ToUpper());
                        item.SubItems.Add(string.Concat(Previsao.ToString("dd/MM/yyyy HH:mm:ss")));
                        item.SubItems.Add(dr["Status_Operacao"].ToString().ToUpper());
                        if (inicio != String.Empty)
                        {
                            DateTime Inicio = Convert.ToDateTime(dr["Inicio"]);
                            item.SubItems.Add(string.Concat(Inicio.ToShortDateString(), " ", Inicio.ToLongTimeString()));
                        }
                        else
                        {
                            item.SubItems.Add(string.Empty);
                        }

                        if (final != string.Empty)
                        {
                            DateTime Final = Convert.ToDateTime(dr["Fim"]);
                            item.SubItems.Add(Final.ToShortTimeString());
                        }
                        else
                        {
                            item.SubItems.Add(string.Empty);
                        }

                        if (Tempo != string.Empty)
                        {
                            DateTime _Tempo = Convert.ToDateTime(dr["Tempo"]);
                            item.SubItems.Add(_Tempo.ToLongTimeString());
                        }
                        else
                        {
                            item.SubItems.Add(string.Empty);
                        }

                        item.SubItems.Add(dr["Entrega"].ToString().ToUpper());
                        item.SubItems.Add(dr["Prioridade"].ToString().ToUpper());
                        item.SubItems.Add(dr["Colorista"].ToString().ToUpper());
                        item.SubItems.Add(dr["Data_Faturamento"].ToString().ToUpper());

                        if (dr["Valor_Custo"] is DBNull)
                        {
                            double Custo = 0;
                            item.SubItems.Add(string.Format("{0:N2}", Custo));
                        }
                        else
                        {
                            double Custo = Convert.ToDouble(dr["Valor_Custo"]);
                            item.SubItems.Add(string.Format("{0:N2}", Custo));
                        }

                        if (dr["Valor_Venda"] is DBNull)
                        {
                            double Venda = 0;
                            item.SubItems.Add(string.Format("{0:N2}", Venda));
                        }
                        else
                        {
                            double Venda = Convert.ToDouble(dr["Valor_Venda"]);
                            item.SubItems.Add(string.Format("{0:N2}", Venda));
                        }

                        item.SubItems.Add(dr["Markup"].ToString().ToUpper());
                        item.SubItems.Add(dr["Contador_Chapinhas"].ToString().ToUpper());
                        item.SubItems.Add(dr["Existente"].ToString().ToUpper());
                        item.SubItems.Add(dr["Carga"].ToString().ToUpper());
                        item.SubItems.Add(dr["NumeroPedido"].ToString().ToUpper());
                        item.SubItems.Add(dr["Operador"].ToString().ToUpper());
                    }

                    lstTintas.Items.Add(item);

                    lvwColumnSorter.Order = SortOrder.Ascending;
                    lvwColumnSorter.SortColumn = 19;
                    lstTintas.Sort();

                }
                //fecha o datareader
                dr.Close();
                ColorirLinhas();
            }

            catch (System.Data.OleDb.OleDbException ex)
            {
                MessageBox.Show("Ocorreu um erro durante a execução da instrução SQL." +
                        "Erro : " + ex.Message, "SQL");
            }
            finally
            {
                //fecha a conexao
                conn.Close();
            }

        }


        public void carrega_LST_tintas()
        {
            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            try
            {
                string _Finalizado = "FINALIZADO";
                string _Num_OSFim = Globais.Numero_OSFim;


                //abre a conexao
                conn.Open();


                //limpa o listview
                this.lstTintasFinalizadas.Items.Clear();


                //cria um comando oledb
                OleDbCommand cmd2 = conn.CreateCommand();
                //define o tipo do comando como texto 
                cmd2.CommandText = "Select top " + _Num_OSFim + " * from Agendamentos where Status_Operacao = '" + _Finalizado + "' order by Fim desc";

                //executa o comando e gera um datareader
                OleDbDataReader dr2 = cmd2.ExecuteReader();

                //define um item listview
                ListViewItem item2;

                //inicia leitura do datareader
                while (dr2.Read())
                {
                    item2 = new ListViewItem();
                    item2.Text = dr2["Código"].ToString();

                    //preenche o listview com itens
                    for (int i = 1; i < dr2.FieldCount; i++)
                    {
                        DateTime Data_Cadastro = Convert.ToDateTime(dr2["Data_Cadastro"]);
                        DateTime Previsao = Convert.ToDateTime(dr2["Previsao_Entrega"]);
                        string inicio = dr2["Inicio"].ToString().ToUpper();
                        string final = dr2["Fim"].ToString().ToUpper();
                        string Tempo = dr2["Tempo"].ToString().ToUpper();

                        item2.SubItems.Add(Data_Cadastro.ToShortDateString());
                        item2.SubItems.Add(dr2["Tipo_OS"].ToString());
                        item2.SubItems.Add(dr2["Cliente"].ToString().ToUpper());
                        item2.SubItems.Add(dr2["Veiculo"].ToString().ToUpper());
                        item2.SubItems.Add(dr2["Placa"].ToString().ToUpper());
                        item2.SubItems.Add(dr2["Grupo_Cores"].ToString().ToUpper());
                        item2.SubItems.Add(dr2["Cor"].ToString().ToUpper());
                        item2.SubItems.Add(dr2["Montadora"].ToString().ToUpper());
                        item2.SubItems.Add(dr2["Cod_Cor"].ToString().ToUpper());
                        item2.SubItems.Add(dr2["Quantidade"].ToString().ToUpper());
                        item2.SubItems.Add(dr2["Pintura"].ToString().ToUpper());
                        item2.SubItems.Add(dr2["Corpo_Prova"].ToString().ToUpper());
                        item2.SubItems.Add(string.Concat(Previsao.ToString("dd/MM/yyyy HH:mm:ss")));
                        item2.SubItems.Add(dr2["Status_Operacao"].ToString().ToUpper());
                        if (inicio != string.Empty)
                        {
                            DateTime Inicio = Convert.ToDateTime(dr2["Inicio"]);
                            item2.SubItems.Add(string.Concat(Inicio.ToShortDateString(), " ", Inicio.ToLongTimeString()));
                        }
                        else
                        {
                            item2.SubItems.Add(string.Empty);
                        }

                        if (final != string.Empty)
                        {
                            DateTime Final = Convert.ToDateTime(dr2["Fim"]);
                            item2.SubItems.Add(Final.ToString("yyyy/MM/dd HH:mm:ss"));
                        }
                        else
                        {
                            item2.SubItems.Add(string.Empty);
                        }

                        if (Tempo != string.Empty)
                        {
                            DateTime _Tempo = Convert.ToDateTime(dr2["Tempo"]);
                            item2.SubItems.Add(_Tempo.ToLongTimeString());
                        }
                        else
                        {
                            item2.SubItems.Add(string.Empty);
                        }

                        item2.SubItems.Add(dr2["Entrega"].ToString().ToUpper());
                        item2.SubItems.Add(dr2["Prioridade"].ToString().ToUpper());
                        item2.SubItems.Add(dr2["Colorista"].ToString().ToUpper());
                        item2.SubItems.Add(dr2["Data_Faturamento"].ToString().ToUpper());

                        double Custo = Convert.ToDouble(dr2["Valor_Custo"]);
                        item2.SubItems.Add(string.Format("{0:N2}", Custo));

                        double Venda = Convert.ToDouble(dr2["Valor_Venda"]);
                        item2.SubItems.Add(string.Format("{0:N2}", Venda));

                        item2.SubItems.Add(dr2["Markup"].ToString().ToUpper());
                        item2.SubItems.Add(dr2["Contador_Chapinhas"].ToString().ToUpper());
                        item2.SubItems.Add(dr2["Existente"].ToString().ToUpper());
                        item2.SubItems.Add(dr2["Carga"].ToString().ToUpper());
                        item2.SubItems.Add(dr2["NumeroPedido"].ToString().ToUpper());
                        item2.SubItems.Add(dr2["Operador"].ToString().ToUpper());
                    }

                    lstTintasFinalizadas.Items.Add(item2);

                    lvwColumnSorter2.Order = SortOrder.Descending;
                    lvwColumnSorter2.SortColumn = 16;
                    lstTintasFinalizadas.Sort();
                }
                //fecha o datareader
                dr2.Close();
            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                MessageBox.Show("Ocorreu um erro durante a execução da instrução SQL." +
                        "Erro : " + ex.Message, "SQL");
            }
            finally
            {
                //fecha a conexao
                conn.Close();
                this.ColorirLinhasFinalizadas();
            }
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            frmIncluir frmincluir = new frmIncluir(this);
            frmincluir.lblTitulo.Text = "SHARP - Inclusão de item";
            frmincluir.txtTipo.Text = "Cadastro";
            frmincluir.Preenche_CBO_Operador();
            frmincluir.cboOperador.SelectedIndex = 0;
            frmincluir.Preenche_CBO_Clientes();
            frmincluir.Preenche_CBO_SP();
            frmincluir.Preenche_CBO_Cores();
            frmincluir.Preenche_CBO_TipoOS();
            frmincluir.ObterPrioridade();
            frmincluir.ShowDialog();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (check_Multi_Selecao.Checked == true && lstTintas.CheckedItems.Count > 1)
            {
                Form messagebox = new frmMensagemPersonalizada("Critico", "Ação não autorizada", "Não é possivel fazer multiplas edições!");
                messagebox.ShowDialog();
                return;
            }
            if (check_Multi_Selecao.Checked == true && lstTintas.CheckedItems.Count == 1)
            {

                foreach (ListViewItem ItemSelecionado in lstTintas.Items) ;

                frmIncluir frmincluir = new frmIncluir(this);
                List<Itens_Lista> Lista = new List<Itens_Lista>();

                for (int i = 0; i < lstTintas.Items.Count; i++)
                {

                    if (lstTintas.Items[i].Checked == true)
                    {
                        Lista.Add(new Itens_Lista()
                        {
                            NOS = lstTintas.Items[i].Text,
                            TipoOS = lstTintas.Items[i].SubItems[2].Text,
                            Cliente = lstTintas.Items[i].SubItems[3].Text,
                            Veiculo = lstTintas.Items[i].SubItems[4].Text,
                            Placa = lstTintas.Items[i].SubItems[5].Text,
                            GrupoCores = lstTintas.Items[i].SubItems[6].Text,
                            Cor = lstTintas.Items[i].SubItems[7].Text,
                            Montadora = lstTintas.Items[i].SubItems[8].Text,
                            Codigo = lstTintas.Items[i].SubItems[9].Text,
                            Quantidade = lstTintas.Items[i].SubItems[10].Text,
                            TipoPintura = lstTintas.Items[i].SubItems[11].Text,
                            CorpoProva = lstTintas.Items[i].SubItems[12].Text,
                            Previsao = DateTime.Parse(lstTintas.Items[i].SubItems[13].Text),
                            Status = lstTintas.Items[i].SubItems[14].Text,
                            Operador = lstTintas.Items[i].SubItems[29].Text,
                        });
                    }

                }
                frmincluir.Preenche_CBO_Operador();
                frmincluir.Preenche_CBO_TipoOS();
                frmincluir.Preenche_CBO_Clientes();
                frmincluir.Preenche_CBO_Cores();
                frmincluir.Preenche_CBO_SP();
                frmincluir.ObterPrioridade();

                //Preenche os Campos no Formulario 
                frmincluir.txtID.Text = Lista[0].NOS;
                frmincluir.txtTipoOS.Text = Lista[0].TipoOS;
                frmincluir.txtCliente.Text = Lista[0].Cliente;
                frmincluir.txtVeiculo.Text = Lista[0].Veiculo;
                frmincluir.txtPlaca.Text = Lista[0].Placa;
                frmincluir.txtGrupoCor.Text = Lista[0].GrupoCores;
                frmincluir.txtCor.Text = Lista[0].Cor;
                frmincluir.txtMontadora.Text = Lista[0].Montadora;
                frmincluir.txtCodCor.Text = Lista[0].Codigo;
                frmincluir.txtQuantidade.Text = Lista[0].Quantidade;
                frmincluir.txtPintura.Text = Lista[0].TipoPintura;
                frmincluir.txtCorpo_Prova.Text = Lista[0].CorpoProva;
                frmincluir.txtPrevisao.Text = Lista[0].Previsao.ToString();
                frmincluir.txtHorario.Text = Lista[0].Previsao.ToShortTimeString();
                frmincluir.txtStatus.Text = Lista[0].Status;
                frmincluir.cboOperador.Text = Lista[0].Operador;

                //Modifica a cor dos campos, para mostrar a edição
                frmincluir.txtID.BackColor = System.Drawing.Color.BlanchedAlmond;
                frmincluir.txtTipoOS.BackColor = System.Drawing.Color.BlanchedAlmond;
                frmincluir.txtCliente.BackColor = System.Drawing.Color.BlanchedAlmond;
                frmincluir.txtVeiculo.BackColor = System.Drawing.Color.BlanchedAlmond;
                frmincluir.txtPlaca.BackColor = System.Drawing.Color.BlanchedAlmond;
                frmincluir.txtGrupoCor.BackColor = System.Drawing.Color.BlanchedAlmond;
                frmincluir.txtCor.BackColor = System.Drawing.Color.BlanchedAlmond;
                frmincluir.txtMontadora.BackColor = System.Drawing.Color.BlanchedAlmond;
                frmincluir.txtCodCor.BackColor = System.Drawing.Color.BlanchedAlmond;
                frmincluir.txtQuantidade.BackColor = System.Drawing.Color.BlanchedAlmond;
                frmincluir.txtPintura.BackColor = System.Drawing.Color.BlanchedAlmond;
                frmincluir.txtCorpo_Prova.BackColor = System.Drawing.Color.BlanchedAlmond;
                frmincluir.txtPrevisao.BackColor = System.Drawing.Color.BlanchedAlmond;
                frmincluir.txtHorario.BackColor = System.Drawing.Color.BlanchedAlmond;
                frmincluir.cboOperador.BackColor = System.Drawing.Color.BlanchedAlmond;

                //Muda o caption para Editar
                frmincluir.lblTitulo.Text = "SHARP - Edição de Item";
                frmincluir.txtTipo.Text = "Editar";
                frmincluir.txtTipo.Text = "Atualizar";

                //Inicializa o Formulario
                frmincluir.StartPosition = FormStartPosition.CenterParent;
                frmincluir.ShowDialog();
            }
            if (check_Multi_Selecao.Checked == false)
            {

                foreach (ListViewItem ItemSelecionado in lstTintas.Items) ;

                frmIncluir frmincluir = new frmIncluir(this);

                if (lstTintas.SelectedItems.Count > 0)
                {
                    frmincluir.Preenche_CBO_TipoOS();
                    frmincluir.Preenche_CBO_Clientes();
                    frmincluir.Preenche_CBO_Cores();
                    frmincluir.Preenche_CBO_SP();
                    frmincluir.ObterPrioridade();

                    //Preenche os Campos no Formulario 
                    frmincluir.txtID.Text = lstTintas.FocusedItem.SubItems[0].Text;
                    frmincluir.txtTipoOS.Text = lstTintas.FocusedItem.SubItems[2].Text;
                    frmincluir.txtCliente.Text = lstTintas.FocusedItem.SubItems[3].Text;
                    frmincluir.txtVeiculo.Text = lstTintas.FocusedItem.SubItems[4].Text;
                    frmincluir.txtPlaca.Text = lstTintas.FocusedItem.SubItems[5].Text;
                    frmincluir.txtGrupoCor.Text = lstTintas.FocusedItem.SubItems[6].Text;
                    frmincluir.txtCor.Text = lstTintas.FocusedItem.SubItems[7].Text;
                    frmincluir.txtMontadora.Text = lstTintas.FocusedItem.SubItems[8].Text;
                    frmincluir.txtCodCor.Text = lstTintas.FocusedItem.SubItems[9].Text;
                    frmincluir.txtQuantidade.Text = lstTintas.FocusedItem.SubItems[10].Text;
                    frmincluir.txtPintura.Text = lstTintas.FocusedItem.SubItems[11].Text;
                    frmincluir.txtCorpo_Prova.Text = lstTintas.FocusedItem.SubItems[12].Text;
                    frmincluir.txtPrevisao.Text = lstTintas.FocusedItem.SubItems[13].Text;
                    frmincluir.txtHorario.Text = Convert.ToDateTime(lstTintas.FocusedItem.SubItems[13].Text).ToShortTimeString();
                    frmincluir.txtStatus.Text = lstTintas.FocusedItem.SubItems[14].Text;

                    //Modifica a cor dos campos, para mostrar a edição
                    frmincluir.txtID.BackColor = System.Drawing.Color.BlanchedAlmond;
                    frmincluir.txtTipoOS.BackColor = System.Drawing.Color.BlanchedAlmond;
                    frmincluir.txtCliente.BackColor = System.Drawing.Color.BlanchedAlmond;
                    frmincluir.txtVeiculo.BackColor = System.Drawing.Color.BlanchedAlmond;
                    frmincluir.txtPlaca.BackColor = System.Drawing.Color.BlanchedAlmond;
                    frmincluir.txtGrupoCor.BackColor = System.Drawing.Color.BlanchedAlmond;
                    frmincluir.txtCor.BackColor = System.Drawing.Color.BlanchedAlmond;
                    frmincluir.txtMontadora.BackColor = System.Drawing.Color.BlanchedAlmond;
                    frmincluir.txtCodCor.BackColor = System.Drawing.Color.BlanchedAlmond;
                    frmincluir.txtQuantidade.BackColor = System.Drawing.Color.BlanchedAlmond;
                    frmincluir.txtPintura.BackColor = System.Drawing.Color.BlanchedAlmond;
                    frmincluir.txtCorpo_Prova.BackColor = System.Drawing.Color.BlanchedAlmond;
                    frmincluir.txtPrevisao.BackColor = System.Drawing.Color.BlanchedAlmond;
                    frmincluir.txtHorario.BackColor = System.Drawing.Color.BlanchedAlmond;

                    //Muda o caption para Editar
                    frmincluir.lblTitulo.Text = "SHARP - Edição de Item";
                    frmincluir.txtTipo.Text = "Editar";
                    frmincluir.txtTipo.Text = "Atualizar";

                    //Inicializa o Formulario
                    frmincluir.StartPosition = FormStartPosition.CenterParent;
                    frmincluir.ShowDialog();
                }
                else
                {
                    Form messagebox = new frmMensagemPersonalizada("Critico", "Nenhum item selecionado", "Nenhum item selecionado, Favor selecionar um item!");
                    messagebox.ShowDialog();
                }
            }
        }

        private void cmdExluir_Click(object sender, EventArgs e)
        {
            if (check_Multi_Selecao.Checked == true)
            {
                DialogResult Resultado = new DialogResult();
                Form messagebox = new frmMensagemPersonalizada("Questao", "Exclusão", "Esta ação inutilizará os Veículos permanentemente, Deseja realmente excluir as OS's selecionadas?");
                Resultado = messagebox.ShowDialog();

                if (Resultado == DialogResult.OK)
                {
                    List<Itens_Lista> Lista = new List<Itens_Lista>();

                    for (int i = 0; i < lstTintas.Items.Count; i++)
                    {
                        if (lstTintas.Items[i].Checked)
                        {
                            Lista.Add(new Itens_Lista()
                            {
                                NOS = lstTintas.Items[i].Text,
                            });
                        }
                    }
                    for (int S = 0; S < Lista.Count; S++)
                    {


                        OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);

                        string comandoSQL = "DELETE * FROM Agendamentos WHERE Código=" + int.Parse(Lista[S].NOS) + "";

                        //cria um comando oledb
                        OleDbCommand cmd = new OleDbCommand(comandoSQL, conn);

                        try
                        {
                            //abre a conexao
                            conn.Open();

                            //executa o comando e gera um datareader
                            cmd.ExecuteNonQuery();

                            conn.Close();
                        }

                        catch (OleDbException ex)
                        {
                            Form messagebox2 = new frmMensagemPersonalizada("Critico", "Erro", "Error: " + ex.Message);
                            messagebox2.ShowDialog();
                        }


                        finally
                        {
                        }
                    }
                    Form messagebox3 = new frmMensagemPersonalizada("Alerta", "Exclusão", "Itens excluidos com sucesso!");
                    messagebox3.ShowDialog();

                    AtualizaLSTOSAberta();
                }
            }

            if (check_Multi_Selecao.Checked == false)
            {
                DialogResult Resultado = new DialogResult();
                Form messagebox = new frmMensagemPersonalizada("Questao", "Exclusão", "Esta ação inutilizará o Veículo permanentemente, Deseja realmente excluir a OS selecionada?");
                Resultado = messagebox.ShowDialog();

                if (Resultado == DialogResult.OK)
                {
                    string ID = lstTintas.FocusedItem.SubItems[0].Text;

                    OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);

                    string comandoSQL = "DELETE * FROM Agendamentos WHERE Código=" + int.Parse(ID) + "";

                    //cria um comando oledb
                    OleDbCommand cmd = new OleDbCommand(comandoSQL, conn);

                    try
                    {
                        //abre a conexao
                        conn.Open();

                        //executa o comando e gera um datareader
                        cmd.ExecuteNonQuery();

                        Form messagebox2 = new frmMensagemPersonalizada("Alerta", "Exclusão", "Ordem de Serviço Nº " + ID + " excluido com sucesso!");
                        messagebox2.ShowDialog();

                        conn.Close();



                    }

                    catch (OleDbException)
                    {
                        Form messagebox3 = new frmMensagemPersonalizada("Alerta", "Exclusão", "Itens excluidos com sucesso!");
                        messagebox3.ShowDialog();
                    }


                    finally
                    {
                    }
                    AtualizaLSTOSAberta();
                }
            }
        }

        private void cmdAtualizar_Click(object sender, EventArgs e)
        {
            txtCliente.Clear();
            txtVeiculo.Clear();
            txtPlaca.Clear();
            txtCor.Clear();
            txtSP.Clear();

            AtualizaLSTOSAberta();
            this.carrega_LST_tintas();

        }

        private void cmdSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void cmdIniciar_Click(object sender, EventArgs e)
        {
            if (check_Multi_Selecao.Checked == true)
            {
                List<Itens_Lista> Lista = new List<Itens_Lista>();
                Prioridade_Cliente p = new Prioridade_Cliente();

                for (int i = 0; i < lstTintas.Items.Count; i++)
                {
                    if (lstTintas.Items[i].Checked == true)
                    {
                        p.ObterPrioridade(lstTintas.Items[i].SubItems[3].Text);

                        Lista.Add(new Itens_Lista()
                        {
                            NOS = lstTintas.Items[i].Text,
                            TipoOS = lstTintas.Items[i].SubItems[2].Text,
                            Cliente = lstTintas.Items[i].SubItems[3].Text,
                            Veiculo = lstTintas.Items[i].SubItems[4].Text,
                            Placa = lstTintas.Items[i].SubItems[5].Text,
                            GrupoCores = lstTintas.Items[i].SubItems[6].Text,
                            Cor = lstTintas.Items[i].SubItems[7].Text,
                            Montadora = lstTintas.Items[i].SubItems[8].Text,
                            Codigo = lstTintas.Items[i].SubItems[9].Text,
                            Quantidade = lstTintas.Items[i].SubItems[10].Text,
                            TipoPintura = lstTintas.Items[i].SubItems[11].Text,
                            CorpoProva = lstTintas.Items[i].SubItems[12].Text,
                            Previsao = DateTime.Parse(lstTintas.Items[i].SubItems[13].Text),
                            Status = lstTintas.Items[i].SubItems[14].Text,
                            Prioridade = p.Prioridade
                        });
                    }
                }

                for (int S = 0; S < Lista.Count; S++)
                {
                    frmIncluir frmincluir = new frmIncluir(this);

                    DateTime _Inicio = DateTime.Now;
                    DateTime _ReInicio = DateTime.Now;

                    string Previsao_Prioridade = Lista[S].Previsao.ToString("yyyy/MM/dd hh:mm:ss");
                    string _Status_Prioridade = "0";

                    if (Lista[S].TipoOS == "AJUSTE EXTERNO")
                    {
                        Prioridade_Cliente Pr = new Prioridade_Cliente();
                        Pr.ObterPrioridade(Lista[S].Cliente);


                        OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);

                        string comandoSQL = "UPDATE Agendamentos SET Status_Operacao='" + "EM PRODUÇÃO".Replace("'", "''") + "', Inicio='" + _Inicio + "', Existente='" + null + "', Tempo='" + "00:00:00" + "', Prioridade='" + string.Concat(_Status_Prioridade, " ", Previsao_Prioridade, " ", Pr.Prioridade) + "' WHERE Código=" + int.Parse(Lista[S].NOS) + "";

                        //cria um comando oledb
                        OleDbCommand cmd = new OleDbCommand(comandoSQL, conn);

                        try
                        {
                            //abre a conexao
                            conn.Open();

                            //executa o comando e gera um datareader
                            cmd.ExecuteNonQuery();

                            Form messagebox = new frmMensagemPersonalizada("Alerta", "Ordem de Serviço Iniciada", "OS Nº " + Lista[S].NOS + " - Processo de confecção de tinta iniciado!");
                            messagebox.ShowDialog();

                            conn.Close();
                        }
                        catch (OleDbException ex)
                        {
                            Form messagebox2 = new frmMensagemPersonalizada("Ciritico", "Erro", "Error: " + ex.Message);
                            messagebox2.ShowDialog();
                        }
                        AtualizaLSTOSAberta();
                    }

                    if (Lista[S].TipoOS == "AJUSTE" || Lista[S].TipoOS == "REPESAGEM")
                    {
                        if (Lista[S].Status == "AGUARDANDO")
                        {
                            IniciarOS("EM PRODUÇÃO", Lista[S].NOS, Lista[S].TipoOS, Lista[S].Cliente, Lista[S].Veiculo, Lista[S].Placa, Lista[S].GrupoCores, Lista[S].Cor, Lista[S].Montadora, Lista[S].Codigo, Lista[S].Quantidade, Lista[S].TipoPintura, Lista[S].CorpoProva, Lista[S].Previsao);
                        }

                        if (Lista[S].Status == "PAUSADO")
                        {
                            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);

                            string comandoSQL = "UPDATE Agendamentos SET Status_Operacao='" + "EM PRODUÇÃO".Replace("'", "''") + "', Inicio='" + _ReInicio + "', Fim='" + DateTime.MinValue + "', Prioridade='" + string.Concat(_Status_Prioridade, " ", Previsao_Prioridade, " ", Lista[S].Prioridade) + "' WHERE Código=" + int.Parse(Lista[S].NOS) + "";

                            //cria um comando oledb
                            OleDbCommand cmd = new OleDbCommand(comandoSQL, conn);

                            try
                            {
                                //abre a conexao
                                conn.Open();

                                //executa o comando e gera um datareader
                                cmd.ExecuteNonQuery();

                                Form messagebox = new frmMensagemPersonalizada("Alerta", "Ordem de Serviço Iniciada", "OS Nº " + Lista[S].NOS + " - Processo de confecção de tinta retomado!");
                                messagebox.ShowDialog();

                                conn.Close();

                            }

                            catch (OleDbException ex)
                            {
                                Form messagebox = new frmMensagemPersonalizada("Critica", "Erro", "Error: " + ex.Message);
                                messagebox.ShowDialog();
                            }


                            finally
                            {
                                AtualizaLSTOSAberta();
                            }

                        }
                    }
                }

            }

            if (check_Multi_Selecao.Checked == false)
            {

                frmIncluir frmincluir = new frmIncluir(this);

                string _Status = lstTintas.FocusedItem.SubItems[14].Text;
                string _NovoStatus = "EM PRODUÇÃO";
                string _ID = lstTintas.FocusedItem.SubItems[0].Text;
                DateTime _Inicio = DateTime.Now;
                DateTime _ReInicio = DateTime.Now;
                string _TipoOS = lstTintas.FocusedItem.SubItems[2].Text;
                string _Cliente = lstTintas.FocusedItem.SubItems[3].Text;
                string _Veiculo = lstTintas.FocusedItem.SubItems[4].Text;
                string _Placa = lstTintas.FocusedItem.SubItems[5].Text;
                string _GrupoCOr = lstTintas.FocusedItem.SubItems[6].Text;
                string _Cor = lstTintas.FocusedItem.SubItems[7].Text;
                string _Montadora = lstTintas.FocusedItem.SubItems[8].Text;
                string _CODcor = lstTintas.FocusedItem.SubItems[9].Text;
                string _QNT = lstTintas.FocusedItem.SubItems[10].Text;
                string _SP = lstTintas.FocusedItem.SubItems[11].Text;
                string _CorpoProva = lstTintas.FocusedItem.SubItems[12].Text;

                DateTime _Previsao = Convert.ToDateTime(lstTintas.FocusedItem.SubItems[13].Text);
                string Previsao_Prioridade = _Previsao.ToString("yyyy/MM/dd hh:mm:ss");
                string _Prioridade = txtPrioridade.Text;
                string _Status_Prioridade = "0";

                if (_TipoOS == "AJUSTE EXTERNO")
                {
                    Prioridade_Cliente Pr = new Prioridade_Cliente();
                    Pr.ObterPrioridade(_Cliente);


                    OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);

                    string comandoSQL = "UPDATE Agendamentos SET Status_Operacao='" + "EM PRODUÇÃO".Replace("'", "''") + "', Inicio='" + _Inicio + "', Existente='" + null + "', Tempo='" + "00:00:00" + "', Prioridade='" + string.Concat(_Status_Prioridade, " ", Previsao_Prioridade, " ", Pr.Prioridade) + "' WHERE Código=" + int.Parse(_ID) + "";

                    //cria um comando oledb
                    OleDbCommand cmd = new OleDbCommand(comandoSQL, conn);

                    try
                    {
                        //abre a conexao
                        conn.Open();

                        //executa o comando e gera um datareader
                        cmd.ExecuteNonQuery();

                        Form messagebox = new frmMensagemPersonalizada("Alerta", "Ordem de Serviço Iniciada", "OS Nº " + _ID + " - Processo de confecção de tinta iniciado!");
                        messagebox.ShowDialog();

                        conn.Close();
                    }
                    catch (OleDbException ex)
                    {
                        Form messagebox2 = new frmMensagemPersonalizada("Ciritico", "Erro", "Error: " + ex.Message);
                        messagebox2.ShowDialog();
                    }
                    AtualizaLSTOSAberta();
                }
                if (_TipoOS == "AJUSTE" || _TipoOS == "REPESAGEM")
                {

                    if (_Status == "AGUARDANDO")
                    {
                        var T = new Thread(() => IniciarOS(_Status, _ID, _TipoOS, _Cliente, _Veiculo, _Placa, _GrupoCOr, _Cor, _Montadora, _CODcor, _QNT, _SP, _CorpoProva, _Previsao));
                        T.Start();
                    }

                    if (_Status == "PAUSADO")
                    {
                        OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);

                        string comandoSQL = "UPDATE Agendamentos SET Status_Operacao='" + _NovoStatus.Replace("'", "''") + "', Inicio='" + _ReInicio + "', Fim='" + DateTime.MinValue + "', Prioridade='" + string.Concat(_Status_Prioridade, " ", Previsao_Prioridade, " ", _Prioridade) + "' WHERE Código=" + int.Parse(_ID) + "";

                        //cria um comando oledb
                        OleDbCommand cmd = new OleDbCommand(comandoSQL, conn);

                        try
                        {
                            //abre a conexao
                            conn.Open();

                            //executa o comando e gera um datareader
                            cmd.ExecuteNonQuery();

                            Form messagebox = new frmMensagemPersonalizada("Alerta", "Ordem de Serviço Iniciado", "Ordem de Serviço Nº " + _ID + " retomado!");
                            messagebox.ShowDialog();

                            conn.Close();

                        }

                        catch (OleDbException ex)
                        {
                            Form messagebox = new frmMensagemPersonalizada("Critica", "Erro", "Error: " + ex.Message);
                            messagebox.ShowDialog();
                        }


                        finally
                        {
                            AtualizaLSTOSAberta();
                        }

                    }
                }
            }
        }




        private void lstTintas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (check_Multi_Selecao.Checked == false)
            {
                this.ObterPrioridade();

                this.Painel_Opcoes.Width = 20;
                this.cmdClose_Options.Visible = false;
                this.cmdOpen_Options.Visible = true;

                string _Status = lstTintas.FocusedItem.SubItems[14].Text;

                if (_Status == "PAUSADO")
                {
                    cmdIniciar.Enabled = true;
                    cmdPausar.Enabled = false;
                    cmdFinalizar.Enabled = false;
                    cmdEdit.Enabled = true;
                    cmdExluir.Enabled = true;
                    cmdNew.Enabled = false;
                    cmdReabrir.Enabled = false;
                    cmdFaturar.Enabled = false;
                }

                if (_Status == "AGUARDANDO")
                {
                    cmdIniciar.Enabled = true;
                    cmdPausar.Enabled = false;
                    cmdFinalizar.Enabled = false;
                    cmdEdit.Enabled = true;
                    cmdExluir.Enabled = true;
                    cmdNew.Enabled = false;
                    cmdReabrir.Enabled = false;
                    cmdFaturar.Enabled = false;
                }

                if (_Status == "EM PRODUÇÃO")
                {
                    cmdIniciar.Enabled = false;
                    cmdPausar.Enabled = true;
                    cmdFinalizar.Enabled = true;
                    cmdEdit.Enabled = false;
                    cmdExluir.Enabled = false;
                    cmdNew.Enabled = false;
                    cmdReabrir.Enabled = false;
                    cmdFaturar.Enabled = false;
                }

                if (_Status == "FINALIZADO")
                {
                    cmdIniciar.Enabled = true;
                    cmdPausar.Enabled = false;
                    cmdFinalizar.Enabled = false;
                    cmdNew.Enabled = false;
                    cmdEdit.Enabled = true;
                    cmdExluir.Enabled = true;
                    cmdReabrir.Enabled = false;
                    cmdFaturar.Enabled = false;
                }

                if (lstTintas.SelectedItems.Count == 0)
                {
                    cmdNew.Enabled = true;
                    cmdEdit.Enabled = false;
                    cmdExluir.Enabled = false;
                    cmdIniciar.Enabled = false;
                    cmdPausar.Enabled = false;
                    cmdFinalizar.Enabled = false;
                    cmdReabrir.Enabled = false;
                    cmdFaturar.Enabled = false;
                    txtPrioridade.Text = string.Empty;
                }
            }
        }

        private void frmPrincipal_Click(object sender, EventArgs e)
        {
            cmdNew.Enabled = true;
            cmdEdit.Enabled = false;
            cmdExluir.Enabled = false;
            cmdIniciar.Enabled = false;
            cmdPausar.Enabled = false;
            cmdFinalizar.Enabled = false;
            cmdReabrir.Enabled = false;
            cmdFaturar.Enabled = false;
            txtPrioridade.Text = string.Empty;

            this.Painel_Opcoes.Width = 32;
            this.cmdClose_Options.Visible = false;
            this.cmdOpen_Options.Visible = true;

            panel2.Visible = false;
            btnExibirContador.Visible = true;
        }

        private void cmdPausar_Click(object sender, EventArgs e)
        {
            if (check_Multi_Selecao.Checked == true && lstTintas.CheckedItems.Count > 0)
            {
                List<Itens_Lista> Lista = new List<Itens_Lista>();


                for (int i = 0; i < lstTintas.Items.Count; i++)
                {
                    if (lstTintas.Items[i].Checked)
                    {
                        Lista.Add(new Itens_Lista()
                        {
                            NOS = lstTintas.Items[i].Text,
                            Previsao = DateTime.Parse(lstTintas.Items[i].SubItems[13].Text),
                            Inicio = lstTintas.Items[i].SubItems[15].Text,
                            Tempo = lstTintas.Items[i].SubItems[17].Text
                        });
                    }
                }

                for (int S = 0; S < Lista.Count; S++)
                {

                    DateTime _TempoFim = DateTime.Now;
                    DateTime _TempoInicio = DateTime.Parse(Lista[S].Inicio.ToString());
                    TimeSpan _TempoCorrido = _TempoFim.Subtract(_TempoInicio);
                    DateTime _Tempo = DateTime.Parse(Lista[S].Tempo.ToString());
                    DateTime _NovoTempo = _Tempo.Add(_TempoCorrido);

                    DateTime _Previsao = Convert.ToDateTime(Lista[S].Previsao.ToString());
                    string PrevisaoPrioridade = _Previsao.ToString("yyyy/MM/dd hh:mm:ss");
                    string _Prioridade = txtPrioridade.Text;
                    string _Status_Prioridade = "1";



                    OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);

                    string comandoSQL = "UPDATE Agendamentos SET Status_Operacao='" + "PAUSADO".Replace("'", "''") + "', Fim='" + _TempoFim + "', Tempo='" + _NovoTempo + "', Prioridade='" + string.Concat(_Status_Prioridade, " ", PrevisaoPrioridade, " ", _Prioridade) + "' WHERE Código=" + int.Parse(Lista[S].NOS.ToString()) + "";

                    //cria um comando oledb
                    OleDbCommand cmd = new OleDbCommand(comandoSQL, conn);

                    try
                    {
                        //abre a conexao
                        conn.Open();

                        //executa o comando e gera um datareader
                        cmd.ExecuteNonQuery();

                        conn.Close();


                    }

                    catch (OleDbException ex)
                    {
                        Form messagebox = new frmMensagemPersonalizada("Critico", "Erro", "Error: " + ex.Message);
                        messagebox.ShowDialog();
                    }


                    finally
                    {

                    }
                }
                Form messagebox2 = new frmMensagemPersonalizada("Alerta", "Pausa", "Ordens de Serviço selecionadas pausadas!");
                messagebox2.ShowDialog();

                AtualizaLSTOSAberta();
            }


            if (check_Multi_Selecao.Checked == false)
            {
                string _ID = lstTintas.FocusedItem.SubItems[0].Text;
                string _NovoStatus = "PAUSADO";
                DateTime _TempoInicio = DateTime.Parse(lstTintas.FocusedItem.SubItems[15].Text);
                DateTime _TempoFim = DateTime.Now;
                DateTime _Tempo = DateTime.Parse(lstTintas.FocusedItem.SubItems[17].Text);
                TimeSpan _TempoCorrido = _TempoFim.Subtract(_TempoInicio);
                DateTime _Previsao = Convert.ToDateTime(lstTintas.FocusedItem.SubItems[13].Text);
                string PrevisaoPrioridade = _Previsao.ToString("yyyy/MM/dd hh:mm:ss");
                string _Prioridade = txtPrioridade.Text;
                string _Status_Prioridade = "1";

                DateTime _NovoTempo = _Tempo.Add(_TempoCorrido);

                OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);

                string comandoSQL = "UPDATE Agendamentos SET Status_Operacao='" + _NovoStatus.Replace("'", "''") + "', Fim='" + _TempoFim + "', Tempo='" + _NovoTempo + "', Prioridade='" + string.Concat(_Status_Prioridade, " ", PrevisaoPrioridade, " ", _Prioridade) + "' WHERE Código=" + int.Parse(_ID) + "";

                //cria um comando oledb
                OleDbCommand cmd = new OleDbCommand(comandoSQL, conn);

                try
                {
                    //abre a conexao
                    conn.Open();

                    //executa o comando e gera um datareader
                    cmd.ExecuteNonQuery();

                    Form messagebox2 = new frmMensagemPersonalizada("Alerta", "Pausa", "Ordens de Serviço Nº " + _ID + " pausada!");
                    messagebox2.ShowDialog();

                    conn.Close();


                }

                catch (OleDbException ex)
                {
                    Form messagebox = new frmMensagemPersonalizada("Critico", "Erro", "Error: " + ex.Message);
                    messagebox.ShowDialog();
                }


                finally
                {
                    AtualizaLSTOSAberta();
                }
            }

        }

        private void cmdFinalizar_Click(object sender, EventArgs e)
        {
            if (check_Multi_Selecao.Checked == true && lstTintas.CheckedItems.Count > 0)
            {
                List<Itens_Lista> Lista = new List<Itens_Lista>();

                for (int i = 0; i < lstTintas.Items.Count; i++)
                {
                    if (lstTintas.Items[i].Checked == true)
                    {
                        Lista.Add(new Itens_Lista()
                        {
                            NOS = lstTintas.Items[i].Text,
                            TipoOS = lstTintas.Items[i].SubItems[2].Text,
                            Cliente = lstTintas.Items[i].SubItems[3].Text,
                            Veiculo = lstTintas.Items[i].SubItems[4].Text,
                            Placa = lstTintas.Items[i].SubItems[5].Text,
                            Cor = lstTintas.Items[i].SubItems[7].Text,
                            TipoPintura = lstTintas.Items[i].SubItems[11].Text,
                            Previsao = DateTime.Parse(lstTintas.Items[i].SubItems[13].Text),
                            Inicio = lstTintas.Items[i].SubItems[15].Text,
                            Tempo = lstTintas.Items[i].SubItems[17].Text,

                        });
                    }
                }

                for (int S = 0; S < Lista.Count; S++)
                {

                    string _NovoStatus = "FINALIZADO";

                    DateTime _TempoFim = DateTime.Now;

                    string previsaoPrioridade = string.Format("yyyy/MM/dd hh:mm:ss", Lista[S].Prioridade);
                    string _Entrega = string.Empty;
                    string _Prioridade = txtPrioridade.Text;
                    string _Status_Prioridade = "3";
                    string _Existente = "SIM";

                    TimeSpan _TempoCorrido = _TempoFim.Subtract(DateTime.Parse(Lista[S].Inicio));
                    DateTime _NovoTempo = DateTime.Parse(Lista[S].Tempo).Add(_TempoCorrido);

                    if (Lista[S].Previsao >= _TempoFim)
                    {
                        _Entrega = "NO PRAZO";
                    }
                    if (Lista[S].Previsao < _TempoFim)
                    {
                        _Entrega = "ATRASADO";
                    }

                    Excel.Application excelApp = new Excel.Application();
                    excelApp.Visible = false;
                    try
                    {

                        string Origem = "";

                        if (Lista[S].TipoOS.Equals("AJUSTE"))
                        {
                            Origem = string.Concat(Globais.CaminhoTintas, Lista[S].Cliente, " - ", Lista[S].Veiculo, " - ", Lista[S].Placa, " - ", Lista[S].Cor, " - ", Lista[S].TipoPintura, ".xlsm");
                        }
                        if (Lista[S].TipoOS.Equals("REPESAGEM"))
                        {
                            Origem = string.Concat(Globais.CaminhoTintas, Lista[S].TipoOS, " - ", Lista[S].Cliente, " - ", Lista[S].Veiculo, " - ", Lista[S].Placa, " - ", Lista[S].Cor, " - ", Lista[S].TipoPintura, ".xlsm");
                        }
                        if (Lista[S].TipoOS.Equals("ERRADA"))
                        {
                            Origem = string.Concat(Globais.CaminhoTintas, Lista[S].TipoOS, " - ", Lista[S].Cliente, " - ", Lista[S].Veiculo, " - ", Lista[S].Placa, " - ", Lista[S].Cor, " - ", Lista[S].TipoPintura, ".xlsm");
                        }

                        //string myPath = string.Concat(Origem);
                        //Excel.Workbook wbExcel = excelApp.Workbooks.Open(myPath);
                        //Excel.Worksheet wsPlanilha = (Excel.Worksheet)wbExcel.Worksheets.get_Item("Ordem de Serviço");

                        //string TipoOS = wsPlanilha.get_Range("F5").Text;
                        //string Veiculo = wsPlanilha.get_Range("C6").Text;
                        //string Placa = wsPlanilha.get_Range("C7").Text;
                        //string Cliente = wsPlanilha.get_Range("C8").Text;
                        //string GrupoCor = wsPlanilha.get_Range("C9").Text;
                        //string Cor = wsPlanilha.get_Range("C10").Text;
                        //string Montadora = wsPlanilha.get_Range("C11").Text;
                        //string Codigo = wsPlanilha.get_Range("C12").Text;
                        //string SP = wsPlanilha.get_Range("C13").Text;
                        //string Quantidade = wsPlanilha.get_Range("C14").Text;
                        //string Corpo_Prova = wsPlanilha.get_Range("C15").Text;
                        //string Colorista = wsPlanilha.get_Range("C4").Text;
                        //string Valor_Custo = wsPlanilha.get_Range("H4").Text;
                        //string Contador_Chapinhas = wsPlanilha.get_Range("I5").Text;
                        //string Carga = wsPlanilha.get_Range("H11").Text;

                        //string Valor_Venda;
                        //if (wsPlanilha.get_Range("H3").Text == string.Empty)
                        //{
                        //    Valor_Venda = "0,00";
                        //}
                        //else
                        //{
                        //    Valor_Venda = wsPlanilha.get_Range("H3").Text;
                        //}


                        OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
                        //string comandoSQL = "UPDATE Agendamentos SET Status_Operacao='" + _NovoStatus.Replace("'", "''") + "', Pintura='" + SP + "', Corpo_Prova='" + Corpo_Prova + "', Contador_Chapinhas='" + Contador_Chapinhas + "', Valor_Custo='" + Valor_Custo + "', Valor_Venda='" + Valor_Venda + "', Colorista='" + Colorista + "', Quantidade='" + Quantidade + "', Cod_Cor='" + Codigo + "', Montadora='" + Montadora + "', Cor='" + Cor + "', Grupo_Cores='" + GrupoCor + "', Tipo_OS='" + TipoOS + "', Cliente='" + Cliente + "', Placa='" + Placa + "', Veiculo='" + Veiculo + "', Fim='" + _TempoFim + "', Tempo='" + _NovoTempo + "', Entrega='" + _Entrega + "', Existente='" + _Existente + "', Carga='" + Carga + "', Prioridade='" + string.Concat(_Status_Prioridade, " ", _TempoFim.ToString("yyyy/MM/dd hh:mm:ss"), " ", _Prioridade) + "' WHERE Código=" + int.Parse(Lista[S].NOS) + "";

                        string comandoSQL = "UPDATE Agendamentos SET Status_Operacao='" + _NovoStatus.Replace("'", "''") + "', Fim='" + _TempoFim + "', Tempo='" + _NovoTempo + "', Entrega='" + _Entrega + "', Existente='" + _Existente + "', Prioridade='" + string.Concat(_Status_Prioridade, " ", _TempoFim.ToString("yyyy/MM/dd hh:mm:ss"), " ", _Prioridade) + "' WHERE Código=" + int.Parse(Lista[S].NOS) + "";

                        //cria um comando oledb
                        OleDbCommand cmd = new OleDbCommand(comandoSQL, conn);

                        try
                        {
                            //abre a conexao
                            conn.Open();

                            //executa o comando e gera um datareader
                            cmd.ExecuteNonQuery();

                            Form messagebox = new frmMensagemPersonalizada("Alerta", "Ordem de serviço finalizada", "Ordem de serviço Nº " + Lista[S].NOS + " finalizada!");
                            messagebox.ShowDialog();

                            conn.Close();


                        }

                        catch (OleDbException ex)
                        {
                            Form messagebox = new frmMensagemPersonalizada("Critico", "Erro", "Error? " + ex.Message);
                            messagebox.ShowDialog();
                        }


                        finally
                        {
                            AtualizaLSTOSAberta();
                            carrega_LST_tintas();

                            //wbExcel.Close(true);
                            //excelApp.Workbooks.Close();
                            //excelApp.Quit();

                            ////Mata os objetos COM da memória
                            //System.Runtime.InteropServices.Marshal.ReleaseComObject(wbExcel);
                            //System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                        }
                    }
                    catch (Exception)
                    {
                        Form Messagebox = new frmMensagemPersonalizada("Alerta", "Erro de importação", "Alguns dados não foram importados da OS Nº " + Lista[S].NOS);
                        Messagebox.ShowDialog();


                        OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);

                        string comandoSQL = "UPDATE Agendamentos SET Status_Operacao='" + _NovoStatus.Replace("'", "''") + "', Fim='" + _TempoFim + "', Tempo='" + _NovoTempo + "', Entrega='" + _Entrega + "', Existente='" + _Existente + "', Prioridade='" + string.Concat(_Status_Prioridade, " ", previsaoPrioridade, " ", _Prioridade) + "' WHERE Código=" + int.Parse(Lista[S].NOS) + "";

                        //cria um comando oledb
                        OleDbCommand cmd = new OleDbCommand(comandoSQL, conn);

                        try
                        {
                            //abre a conexao
                            conn.Open();

                            //executa o comando e gera um datareader
                            cmd.ExecuteNonQuery();

                            Form messagebox = new frmMensagemPersonalizada("Alerta", "Ordem de serviço finalizada", "Ordem de serviço Nº " + Lista[S].NOS + " finalizada!");
                            messagebox.ShowDialog();

                            conn.Close();
                        }

                        catch (OleDbException ex)
                        {
                            Form messagebox = new frmMensagemPersonalizada("Critico", "Erro", "Error? " + ex.Message);
                            messagebox.ShowDialog();
                        }


                        finally
                        {
                            carrega_LST_tintas();
                            AtualizaLSTOSAberta();
                        }
                    }
                }
            }

            if (check_Multi_Selecao.Checked == false)
            {

                string _ID = lstTintas.FocusedItem.SubItems[0].Text;
                string _NovoStatus = "FINALIZADO";
                DateTime _TempoInicio = DateTime.Parse(lstTintas.FocusedItem.SubItems[15].Text);
                DateTime _TempoFim = DateTime.Now;
                DateTime _Tempo = DateTime.Parse(lstTintas.FocusedItem.SubItems[17].Text);
                DateTime _Previsao = DateTime.Parse(lstTintas.FocusedItem.SubItems[13].Text);
                string previsaoPrioridade = _Previsao.ToString("yyyy/MM/dd hh:mm:ss");
                string _Entrega = string.Empty;
                string _Prioridade = txtPrioridade.Text;
                string _Status_Prioridade = "3";
                string _Existente = "SIM";

                TimeSpan _TempoCorrido = _TempoFim.Subtract(_TempoInicio);
                DateTime _NovoTempo = _Tempo.Add(_TempoCorrido);

                if (_Previsao >= _TempoFim)
                {
                    _Entrega = "NO PRAZO";
                }
                if (_Previsao < _TempoFim)
                {
                    _Entrega = "ATRASADO";
                }

                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = false;
                try
                {
                    string _NOS = lstTintas.FocusedItem.Text;
                    string _TipoOS = lstTintas.FocusedItem.SubItems[2].Text;
                    string _Cliente = lstTintas.FocusedItem.SubItems[3].Text;
                    string _Veiculo = lstTintas.FocusedItem.SubItems[4].Text;
                    string _Placa = lstTintas.FocusedItem.SubItems[5].Text;
                    string _Cor = lstTintas.FocusedItem.SubItems[7].Text;
                    string _TipoPintura = lstTintas.FocusedItem.SubItems[11].Text;


                    string Origem = "";

                    if (_TipoOS.Equals("AJUSTE"))
                    {
                        Origem = string.Concat(Globais.CaminhoTintas, _Cliente, " - ", _Veiculo, " - ", _Placa, " - ", _Cor, " - ", _TipoPintura, ".xlsm");
                    }
                    if (_TipoOS.Equals("REPESAGEM"))
                    {
                        Origem = string.Concat(Globais.CaminhoTintas, _TipoOS, " - ", _Cliente, " - ", _Veiculo, " - ", _Placa, " - ", _Cor, " - ", _TipoPintura, ".xlsm");
                    }
                    if (_TipoOS.Equals("ERRADA"))
                    {
                        Origem = string.Concat(Globais.CaminhoTintas, _TipoOS, " - ", _Cliente, " - ", _Veiculo, " - ", _Placa, " - ", _Cor, " - ", _TipoPintura, ".xlsm");
                    }

                    //Excel.Workbook wbExcel = excelApp.Workbooks.Open(Origem);
                    //Excel.Worksheet wsPlanilha = (Excel.Worksheet)wbExcel.Worksheets.get_Item("Ordem de Serviço");

                    //string TipoOS = wsPlanilha.get_Range("F5").Text;
                    //string Veiculo = wsPlanilha.get_Range("C6").Text;
                    //string Placa = wsPlanilha.get_Range("C7").Text;
                    //string Cliente = wsPlanilha.get_Range("C8").Text;
                    //string GrupoCor = wsPlanilha.get_Range("C9").Text;
                    //string Cor = wsPlanilha.get_Range("C10").Text;
                    //string Montadora = wsPlanilha.get_Range("C11").Text;
                    //string Codigo = wsPlanilha.get_Range("C12").Text;
                    //string SP = wsPlanilha.get_Range("C13").Text;
                    //string Quantidade = wsPlanilha.get_Range("C14").Text;
                    //string Corpo_Prova = wsPlanilha.get_Range("C15").Text;
                    //string Colorista = wsPlanilha.get_Range("C4").Text;
                    //string Valor_Custo = wsPlanilha.get_Range("H4").Text;
                    //string Contador_Chapinhas = wsPlanilha.get_Range("I5").Text;
                    //string Carga = wsPlanilha.get_Range("H11").Text;

                    //string Valor_Venda;
                    //if (wsPlanilha.get_Range("H3").Text == string.Empty)
                    //{
                    //    Valor_Venda = "0,00";
                    //}
                    //else
                    //{
                    //    Valor_Venda = wsPlanilha.get_Range("H3").Text;
                    //}

                    OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
                    //string comandoSQL = "UPDATE Agendamentos SET Status_Operacao='" + _NovoStatus.Replace("'", "''") + "', Pintura='" + SP + "', Corpo_Prova='" + Corpo_Prova + "', Contador_Chapinhas='" + Contador_Chapinhas + "', Valor_Custo='" + Valor_Custo + "', Valor_Venda='" + Valor_Venda + "', Colorista='" + Colorista + "', Quantidade='" + Quantidade + "', Cod_Cor='" + Codigo + "', Montadora='" + Montadora + "', Cor='" + Cor + "', Grupo_Cores='" + GrupoCor + "', Tipo_OS='" + TipoOS + "', Cliente='" + Cliente + "', Placa='" + Placa + "', Veiculo='" + Veiculo + "', Fim='" + _TempoFim + "', Tempo='" + _NovoTempo + "', Entrega='" + _Entrega + "', Existente='" + _Existente + "', Carga='" + Carga + "', Prioridade='" + string.Concat(_Status_Prioridade, " ", _TempoFim.ToString("yyyy/MM/dd hh:mm:ss"), " ", _Prioridade) + "' WHERE Código=" + int.Parse(_ID) + "";
                    string comandoSQL = "UPDATE Agendamentos SET Status_Operacao='" + _NovoStatus.Replace("'", "''") + "', Fim='" + _TempoFim + "', Tempo='" + _NovoTempo + "', Entrega='" + _Entrega + "', Existente='" + _Existente + "', Prioridade='" + string.Concat(_Status_Prioridade, " ", _TempoFim.ToString("yyyy/MM/dd hh:mm:ss"), " ", _Prioridade) + "' WHERE Código=" + int.Parse(_ID) + "";

                    //cria um comando oledb
                    OleDbCommand cmd = new OleDbCommand(comandoSQL, conn);

                    try
                    {
                        //abre a conexao
                        conn.Open();

                        //executa o comando e gera um datareader
                        cmd.ExecuteNonQuery();

                        Form messagebox = new frmMensagemPersonalizada("Alerta", "Ordem de serviço finalizada", "Ordem de serviço Nº " + _ID + " finalizada!");
                        messagebox.ShowDialog();

                        conn.Close();


                    }

                    catch (OleDbException ex)
                    {
                        Form messagebox = new frmMensagemPersonalizada("Critico", "Erro", "Error? " + ex.Message);
                        messagebox.ShowDialog();
                    }


                    finally
                    {
                        AtualizaLSTOSAberta();
                        carrega_LST_tintas();

                        //wbExcel.Close(true);
                        //excelApp.Workbooks.Close();
                        //excelApp.Quit();

                        ////Mata os objetos COM da memória
                        //System.Runtime.InteropServices.Marshal.ReleaseComObject(wbExcel);
                        //System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                    }
                }
                catch (Exception)
                {
                    Form Messagebox = new frmMensagemPersonalizada("Alerta", "Erro de importação", "Alguns dados não foram importados da OS Nº " + _ID);
                    Messagebox.ShowDialog();


                    OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);

                    string comandoSQL = "UPDATE Agendamentos SET Status_Operacao='" + _NovoStatus.Replace("'", "''") + "', Fim='" + _TempoFim + "', Tempo='" + _NovoTempo + "', Entrega='" + _Entrega + "', Existente='" + _Existente + "', Prioridade='" + string.Concat(_Status_Prioridade, " ", previsaoPrioridade, " ", _Prioridade) + "' WHERE Código=" + int.Parse(_ID) + "";

                    //cria um comando oledb
                    OleDbCommand cmd = new OleDbCommand(comandoSQL, conn);

                    try
                    {
                        //abre a conexao
                        conn.Open();

                        //executa o comando e gera um datareader
                        cmd.ExecuteNonQuery();

                        Form messagebox = new frmMensagemPersonalizada("Alerta", "Ordem de serviço finalizada", "Ordem de serviço Nº " + _ID + " finalizada!");
                        messagebox.ShowDialog();

                        conn.Close();
                    }

                    catch (OleDbException ex)
                    {
                        Form messagebox = new frmMensagemPersonalizada("Critico", "Erro", "Error? " + ex.Message);
                        messagebox.ShowDialog();
                    }


                    finally
                    {
                        carrega_LST_tintas();
                        AtualizaLSTOSAberta();
                    }
                }
            }
        }

        private void lstTintas_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lstTintas.Sort();
        }

        private void frmPrincipal_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void lstTintas_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    cmdNew_Click(sender, e);
                    break;

                case Keys.F2:
                    cmdEdit_Click(sender, e);
                    break;

                case Keys.F3:
                    cmdExluir_Click(sender, e);
                    break;

                case Keys.F5:
                    cmdAtualizar_Click(sender, e);
                    break;

                case Keys.F4:
                    cmdIniciar_Click(sender, e);
                    break;

                case Keys.F6:
                    cmdPausar_Click(sender, e);
                    break;

                case Keys.F7:
                    cmdFinalizar_Click(sender, e);
                    break;
            }

        }

        private void cmdAtualizar_KeyDown(object sender, KeyEventArgs e)
        {
        }
        private void cmdNew_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void cmdEdit_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmdExluir_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmdIniciar_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void cmdPausar_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void cmdFinalizar_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void cmdSair_KeyDown(object sender, KeyEventArgs e)
        {
        }

        public void ObterPrioridade()
        {
            foreach (ListViewItem ItemSelecionado in lstTintas.Items) ;

            frmIncluir frmincluir = new frmIncluir(this);

            if (lstTintas.SelectedItems.Count > 0)
            {

                OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
                try
                {
                    //abre a conexao
                    conn.Open();

                    //cria um comando oledb
                    OleDbCommand cmd = conn.CreateCommand();

                    string Cliente = lstTintas.FocusedItem.SubItems[2].Text;
                    //define o tipo do comando como texto 
                    cmd.CommandText = "Select * from Clientes WHERE Cliente like '" + Cliente + "'";

                    //executa o comando e gera um datareader
                    OleDbDataReader dr = cmd.ExecuteReader();

                    //inicia leitura do datareader
                    while (dr.Read())
                    {
                        txtPrioridade.Text = dr.GetValue(3).ToString();
                    }
                    //fecha o datareader
                    dr.Close();

                }
                catch (System.Data.OleDb.OleDbException ex)
                {
                    Form messagebox = new frmMensagemPersonalizada("Critico", "Erro", "Ocorreu um erro durante a execução da instrução SQL." + "Erro : " + ex.Message);
                    messagebox.ShowDialog();
                }
                finally
                {
                    //fecha a conexao
                    conn.Close();
                }
            }

            if (txtPrioridade.Text == string.Empty)
            {
                txtPrioridade.Text = "2";
            }

            if (lstTintas.SelectedItems.Count == 0)
            {
                txtPrioridade.Text = string.Empty;
            }
        }

        public void ColorirLinhasFinalizadas()
        {
            foreach (ListViewItem Item2 in lstTintasFinalizadas.Items)
            {
                if (Item2.SubItems[26].Text == "SIM")
                {
                    Item2.ForeColor = Color.Green;
                }
                else
                {
                    Item2.ForeColor = Color.Black;
                }
            }
        }


        public void ColorirLinhas()
        {
            foreach (ListViewItem Item in lstTintas.Items)
            {


                if (Item.SubItems[18].Text == "NO PRAZO")
                {

                    if (Item.SubItems[14].Text == "EM PRODUÇÃO")
                    {
                        Item.ForeColor = System.Drawing.Color.Green;
                        Item.Font = new System.Drawing.Font("Calibri", 9, System.Drawing.FontStyle.Bold);
                    }

                    if (Item.SubItems[14].Text == "AGUARDANDO")
                    {
                        if (Item.SubItems[26].Text == "SIM")
                        {
                            Item.ForeColor = System.Drawing.Color.Blue;
                            Item.Font = new System.Drawing.Font("Calibri", 9, System.Drawing.FontStyle.Bold);
                        }
                        else
                        {
                            Item.ForeColor = System.Drawing.Color.Black;
                            Item.Font = new System.Drawing.Font("Calibri", 9);
                        }
                    }

                    if (Item.SubItems[14].Text == "PAUSADO")
                    {
                        Item.ForeColor = System.Drawing.Color.DarkOrange;
                        Item.Font = new System.Drawing.Font("Calibri", 9, System.Drawing.FontStyle.Bold);
                    }
                }
                if (Item.SubItems[18].Text == "ATRASADO")
                {
                    if (Item.SubItems[14].Text == "EM PRODUÇÃO")
                    {
                        Item.BackColor = System.Drawing.Color.Red;
                        Item.ForeColor = System.Drawing.Color.White;
                        Item.Font = new System.Drawing.Font("Calibri", 9, System.Drawing.FontStyle.Bold);
                    }
                    if (Item.SubItems[14].Text == "AGUARDANDO")
                    {
                        Item.BackColor = System.Drawing.Color.Red;
                        Item.ForeColor = System.Drawing.Color.Black;
                        Item.Font = new System.Drawing.Font("Calibri", 9, System.Drawing.FontStyle.Bold);
                    }
                    if (Item.SubItems[14].Text == "PAUSADO")
                    {
                        Item.BackColor = System.Drawing.Color.Red;
                        Item.ForeColor = System.Drawing.Color.LightGray;
                        Item.Font = new System.Drawing.Font("Calibri", 9, System.Drawing.FontStyle.Bold);
                    }
                }


            }
        }

        private void cmdPesquisar_Click(object sender, EventArgs e)
        {
            this.PEsquisarLST();
            this.PEsquisarLSTFinalizadas();
        }

        public void PEsquisarLSTFinalizadas()
        {
            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            try
            {
                string Cliente = txtCliente.Text;
                string Veiculo = txtVeiculo.Text;
                string Placa = txtPlaca.Text;
                string Cor = txtCor.Text;
                string SP = txtSP.Text;
                string _Finalizado = "FINALIZADO";

                if (txtPlaca.MaskFull == true)
                {
                    txtPlaca.TextMaskFormat = MaskFormat.IncludeLiterals;
                }
                if (txtPlaca.MaskFull == false)
                {
                    txtPlaca.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                }

                //limpa o listview
                this.lstTintasFinalizadas.Items.Clear();

                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();

                //define o tipo do comando como texto 
                //pesquisa com campos vazios
                if (Cliente == "" && Veiculo == "" && Placa == "" && Cor == "" && SP == "")
                {
                    carrega_LST_tintas();
                    return;

                }

                //Pesquisa apenas com Clientes
                if (Cliente != "" && Veiculo == "" && Placa == "" && Cor == "" && SP == "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cliente like '%" + Cliente + "%' AND Status_Operacao = '" + _Finalizado + "'";
                }

                //Pesquisa com Clientes e Veiculo
                if (Cliente != "" && Veiculo != "" && Placa == "" && Cor == "" && SP == "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cliente like '%" + Cliente + "%' and Veiculo Like'%" + Veiculo + "%' AND Status_Operacao = '" + _Finalizado + "'";
                }

                //Pesquisa com Clientes, Veiculo e Placa
                if (Cliente != "" && Veiculo != "" && Placa != "" && Cor == "" && SP == "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cliente like '%" + Cliente + "%' and Veiculo Like'%" + Veiculo + "%' and Placa Like'%" + Placa + "%' AND Status_Operacao = '" + _Finalizado + "'";
                }

                //Pesquisa com Clientes, Veiculo, Placa e Cor
                if (Cliente != "" && Veiculo != "" && Placa != "" && Cor != "" && SP == "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cliente like '%" + Cliente + "%' and Veiculo Like'%" + Veiculo + "%' and Placa Like'%" + Placa + "%' and Cor Like'%" + Cor + "%' AND Status_Operacao = '" + _Finalizado + "'";
                }

                //Pesquisa com Clientes, Veiculo, Placa, Cor e SP
                if (Cliente != "" && Veiculo != "" && Placa != "" && Cor != "" && SP != "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cliente like '%" + Cliente + "%' and Veiculo Like'%" + Veiculo + "%' and Placa Like'%" + Placa + "%' and Cor Like'%" + Cor + "%' and Pintura Like'%" + SP + "%' AND Status_Operacao = '" + _Finalizado + "'";
                }

                //Pesquisa com Veiculo
                if (Cliente == "" && Veiculo != "" && Placa == "" && Cor == "" && SP == "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Veiculo like '%" + Veiculo + "%' AND Status_Operacao = '" + _Finalizado + "'";
                }

                //Pesquisa com Veiculo e Placa
                if (Cliente == "" && Veiculo != "" && Placa != "" && Cor == "" && SP == "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Veiculo like '%" + Veiculo + "%' and Placa like '%" + Placa + "%' AND Status_Operacao = '" + _Finalizado + "'";
                }

                //Pesquisa com Veiculo, Placa e Cor
                if (Cliente == "" && Veiculo != "" && Placa != "" && Cor != "" && SP == "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Veiculo like '%" + Veiculo + "%' and Placa like '%" + Placa + "%' and Cor like '%" + Cor + "%' AND Status_Operacao = '" + _Finalizado + "'";
                }

                //Pesquisa com Veiculo, Placa, Cor e SP
                if (Cliente == "" && Veiculo != "" && Placa != "" && Cor != "" && SP != "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Veiculo like '%" + Veiculo + "%' and Placa like '%" + Placa + "%' and Cor like '%" + Cor + "%' and Pintura like '%" + SP + "%' AND Status_Operacao = '" + _Finalizado + "'";
                }

                //Pesquisa com Placa
                if (Cliente == "" && Veiculo == "" && Placa != "" && Cor == "" && SP == "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Placa like '%" + Placa + "%' AND Status_Operacao = '" + _Finalizado + "'";
                }

                //Pesquisa com Placa e Cor
                if (Cliente == "" && Veiculo == "" && Placa != "" && Cor != "" && SP == "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Placa like '%" + Placa + "%' and Cor like '%" + Cor + "%' AND Status_Operacao = '" + _Finalizado + "'";
                }

                //Pesquisa com Placa, Cor e SP
                if (Cliente == "" && Veiculo == "" && Placa != "" && Cor != "" && SP != "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Placa like '%" + Placa + "%' and Cor like '%" + Cor + "%' and Pintura like '%" + SP + "%' AND Status_Operacao = '" + _Finalizado + "'";
                }

                //Pesquisa com Cor
                if (Cliente == "" && Veiculo == "" && Placa == "" && Cor != "" && SP == "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cor like '%" + Cor + "%' AND Status_Operacao = '" + _Finalizado + "'";
                }

                //Pesquisa com Cor e SP
                if (Cliente == "" && Veiculo == "" && Placa == "" && Cor != "" && SP != "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cor like '%" + Cor + "%' and Pintura like '%" + SP + "%' AND Status_Operacao = '" + _Finalizado + "'";
                }

                //Pesquisa com SP
                if (Cliente == "" && Veiculo == "" && Placa == "" && Cor == "" && SP != "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Pintura like '%" + SP + "%' AND Status_Operacao = '" + _Finalizado + "'";
                }

                //Pesquisa com Cliente e Placa
                if (Cliente != "" && Veiculo == "" && Placa != "" && Cor == "" && SP == "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cliente like '%" + Cliente + "%' and Placa Like'%" + Placa + "%' AND Status_Operacao = '" + _Finalizado + "'";
                }

                //Pesquisa com Cliente, Placa e Cor
                if (Cliente != "" && Veiculo == "" && Placa != "" && Cor != "" && SP == "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cliente like '%" + Cliente + "%' and Placa Like'%" + Placa + "%' and Cor Like'%" + Cor + "%' AND Status_Operacao = '" + _Finalizado + "'";
                }

                //Pesquisa com Cliente, Placa, Cor e SP
                if (Cliente != "" && Veiculo == "" && Placa != "" && Cor != "" && SP != "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cliente like '%" + Cliente + "%' and Placa Like'%" + Placa + "%' and Cor Like'%" + Cor + "%' and Pintura Like'%" + SP + "%' AND Status_Operacao = '" + _Finalizado + "'";
                }

                //Pesquisa com Cliente e Cor
                if (Cliente != "" && Veiculo == "" && Placa == "" && Cor != "" && SP == "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cliente like '%" + Cliente + "%' and Cor Like'%" + Cor + "%' AND Status_Operacao = '" + _Finalizado + "'";
                }

                //Pesquisa com Cliente, Cor e SP
                if (Cliente != "" && Veiculo == "" && Placa == "" && Cor != "" && SP != "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cliente like '%" + Cliente + "%' and Pintura Like'%" + SP + "%' and Cor Like'%" + Cor + "%' AND Status_Operacao = '" + _Finalizado + "'";
                }

                //Pesquisa com Cliente e SP
                if (Cliente != "" && Veiculo == "" && Placa == "" && Cor == "" && SP != "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cliente like '%" + Cliente + "%' and Pintura Like'%" + SP + "%' AND Status_Operacao = '" + _Finalizado + "'";
                }

                //Pesquisa com Veiculo, Cor
                if (Cliente == "" && Veiculo != "" && Placa == "" && Cor != "" && SP == "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Veiculo like '%" + Veiculo + "%' and Cor Like'%" + Cor + "%' and Cor Like'%" + Cor + "%' AND Status_Operacao = '" + _Finalizado + "'";
                }

                //Pesquisa com Veiculo, Cor e SP
                if (Cliente == "" && Veiculo != "" && Placa == "" && Cor != "" && SP != "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Veiculo like '%" + Veiculo + "%' and Pintura Like'%" + SP + "%' and Cor Like'%" + Cor + "%' AND Status_Operacao = '" + _Finalizado + "'";
                }

                //Pesquisa com Veiculo e SP
                if (Cliente == "" && Veiculo != "" && Placa == "" && Cor == "" && SP != "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Veiculo like '%" + Veiculo + "%' and Pintura Like'%" + SP + "%' AND Status_Operacao = '" + _Finalizado + "'";
                }

                //Pesquisa com Placa e SP
                if (Cliente == "" && Veiculo == "" && Placa != "" && Cor == "" && SP != "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Placa like '%" + Placa + "%' and Pintura Like'%" + SP + "%' AND Status_Operacao = '" + _Finalizado + "'";
                }

                //Pesquisa com Cor e SP
                if (Cliente == "" && Veiculo == "" && Placa == "" && Cor != "" && SP != "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cor like '%" + Cor + "%' and Pintura Like'%" + SP + "%' AND Status_Operacao = '" + _Finalizado + "'";
                }

                //Pesquisa com Cliente, Veiculo, Placa e SP
                if (Cliente != "" && Veiculo != "" && Placa != "" && Cor == "" && SP != "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cliente like '%" + Cliente + "%' and Veiculo Like'%" + Veiculo + "%' and Placa Like'%" + Placa + "%' and Pintura Like'%" + SP + "%' AND Status_Operacao = '" + _Finalizado + "'";
                }

                //Pesquisa com Cliente, Veiculo, Cor e SP
                if (Cliente != "" && Veiculo != "" && Placa == "" && Cor != "" && SP != "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cliente like '%" + Cliente + "%' and Veiculo Like'%" + Veiculo + "%' and Cor Like'%" + Cor + "%' and Pintura Like'%" + SP + "%' AND Status_Operacao = '" + _Finalizado + "'";
                }


                OleDbDataReader dr = cmd.ExecuteReader();

                //define um item listview
                ListViewItem item;

                //inicia leitura do datareader
                while (dr.Read())
                {
                    item = new ListViewItem();
                    item.Text = dr.GetValue(0).ToString();

                    //preenche o listview com itens
                    for (int i = 1; i < dr.FieldCount; i++)
                    {
                        DateTime Data_Cadastro = Convert.ToDateTime(dr["Data_Cadastro"]);
                        DateTime Previsao = Convert.ToDateTime(dr["Previsao_Entrega"]);
                        string inicio = dr["Inicio"].ToString().ToUpper();
                        string final = dr["Fim"].ToString().ToUpper();
                        string Tempo = dr["Tempo"].ToString().ToUpper();

                        item.SubItems.Add(Data_Cadastro.ToShortDateString());
                        item.SubItems.Add(dr["Tipo_OS"].ToString());
                        item.SubItems.Add(dr["Cliente"].ToString().ToUpper());
                        item.SubItems.Add(dr["Veiculo"].ToString().ToUpper());
                        item.SubItems.Add(dr["Placa"].ToString().ToUpper());
                        item.SubItems.Add(dr["Grupo_Cores"].ToString().ToUpper());
                        item.SubItems.Add(dr["Cor"].ToString().ToUpper());
                        item.SubItems.Add(dr["Montadora"].ToString().ToUpper());
                        item.SubItems.Add(dr["Cod_Cor"].ToString().ToUpper());
                        item.SubItems.Add(dr["Quantidade"].ToString().ToUpper());
                        item.SubItems.Add(dr["Pintura"].ToString().ToUpper());
                        item.SubItems.Add(dr["Corpo_Prova"].ToString().ToUpper());
                        item.SubItems.Add(string.Concat(Previsao.ToString("dd/MM/yyyy HH:mm:ss")));
                        item.SubItems.Add(dr["Status_Operacao"].ToString().ToUpper());
                        if (inicio != String.Empty)
                        {
                            DateTime Inicio = Convert.ToDateTime(dr["Inicio"]);
                            item.SubItems.Add(string.Concat(Inicio.ToShortDateString(), " ", Inicio.ToLongTimeString()));
                        }
                        else
                        {
                            item.SubItems.Add(string.Empty);
                        }

                        if (final != string.Empty)
                        {
                            DateTime Final = Convert.ToDateTime(dr["Fim"]);
                            item.SubItems.Add(Final.ToShortTimeString());
                        }
                        else
                        {
                            item.SubItems.Add(string.Empty);
                        }

                        if (Tempo != string.Empty)
                        {
                            DateTime _Tempo = Convert.ToDateTime(dr["Tempo"]);
                            item.SubItems.Add(_Tempo.ToLongTimeString());
                        }
                        else
                        {
                            item.SubItems.Add(string.Empty);
                        }

                        item.SubItems.Add(dr["Entrega"].ToString().ToUpper());
                        item.SubItems.Add(dr["Prioridade"].ToString().ToUpper());
                        item.SubItems.Add(dr["Colorista"].ToString().ToUpper());
                        item.SubItems.Add(dr["Data_Faturamento"].ToString().ToUpper());
                        item.SubItems.Add(dr["Valor_Custo"].ToString().ToUpper());
                        item.SubItems.Add(dr["Valor_Venda"].ToString().ToUpper());
                        item.SubItems.Add(dr["Markup"].ToString().ToUpper());
                        item.SubItems.Add(dr["Contador_Chapinhas"].ToString().ToUpper());
                    }

                    lstTintasFinalizadas.Items.Add(item);

                    lvwColumnSorter.SortColumn = 19;
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                //fecha o datareader
                dr.Close();


                this.ColorirLinhas();
            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                Form messagebox = new frmMensagemPersonalizada("Critico", "Erro", "Ocorreu um erro durante a execução da instrução SQL." + "Erro : " + ex.Message);
                messagebox.ShowDialog();
            }
            finally
            {
                //fecha a conexao
                conn.Close();
            }
            ColorirLinhas();
        }

        public void PEsquisarLST()
        {
            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            try
            {
                string Cliente = txtCliente.Text;
                string Veiculo = txtVeiculo.Text;
                string Placa = txtPlaca.Text;
                string Cor = txtCor.Text;
                string SP = txtSP.Text;
                string _aguardando = "Aguardando";
                string _Pausado = "PAUSADO";
                string _EmProducao = "EM PRODUÇÃO";

                if (txtPlaca.MaskFull == true)
                {
                    txtPlaca.TextMaskFormat = MaskFormat.IncludeLiterals;
                }
                if (txtPlaca.MaskFull == false)
                {
                    txtPlaca.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                }

                //limpa o listview
                this.lstTintas.Items.Clear();

                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();

                //define o tipo do comando como texto 
                //pesquisa com campos vazios
                if (Cliente == "" && Veiculo == "" && Placa == "" && Cor == "" && SP == "")
                {
                    cmd.CommandText = "Select * from Agendamentos WHERE Status_Operacao like '%" + _EmProducao + "%' OR Status_Operacao like '%" + _Pausado + "%' OR Status_Operacao like '%" + _aguardando + "%'";
                }

                //Pesquisa apenas com Clientes
                if (Cliente != "" && Veiculo == "" && Placa == "" && Cor == "" && SP == "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cliente like '%" + Cliente + "%' and (Status_Operacao like '%" + _EmProducao + "%' or Status_Operacao like '%" + _Pausado + "%' or Status_Operacao like '%" + _aguardando + "%')";
                }

                //Pesquisa com Clientes e Veiculo
                if (Cliente != "" && Veiculo != "" && Placa == "" && Cor == "" && SP == "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cliente like '%" + Cliente + "%' and Veiculo Like'%" + Veiculo + "%' AND (Status_Operacao like '%" + _EmProducao + "%' OR Status_Operacao like '%" + _Pausado + "%' OR Status_Operacao like '%" + _aguardando + "%')";
                }

                //Pesquisa com Clientes, Veiculo e Placa
                if (Cliente != "" && Veiculo != "" && Placa != "" && Cor == "" && SP == "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cliente like '%" + Cliente + "%' and Veiculo Like'%" + Veiculo + "%' and Placa Like'%" + Placa + "%' AND (Status_Operacao like '%" + _EmProducao + "%' OR Status_Operacao like '%" + _Pausado + "%' OR Status_Operacao like '%" + _aguardando + "%')";
                }

                //Pesquisa com Clientes, Veiculo, Placa e Cor
                if (Cliente != "" && Veiculo != "" && Placa != "" && Cor != "" && SP == "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cliente like '%" + Cliente + "%' and Veiculo Like'%" + Veiculo + "%' and Placa Like'%" + Placa + "%' and Cor Like'%" + Cor + "%' AND (Status_Operacao like '%" + _EmProducao + "%' OR Status_Operacao like '%" + _Pausado + "%' OR Status_Operacao like '%" + _aguardando + "%')";
                }

                //Pesquisa com Clientes, Veiculo, Placa, Cor e SP
                if (Cliente != "" && Veiculo != "" && Placa != "" && Cor != "" && SP != "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cliente like '%" + Cliente + "%' and Veiculo Like'%" + Veiculo + "%' and Placa Like'%" + Placa + "%' and Cor Like'%" + Cor + "%' and Pintura Like'%" + SP + "%' AND (Status_Operacao like '%" + _EmProducao + "%' OR Status_Operacao like '%" + _Pausado + "%' OR Status_Operacao like '%" + _aguardando + "%')";
                }

                //Pesquisa com Veiculo
                if (Cliente == "" && Veiculo != "" && Placa == "" && Cor == "" && SP == "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Veiculo like '%" + Veiculo + "%' AND (Status_Operacao like '%" + _EmProducao + "%' OR Status_Operacao like '%" + _Pausado + "%' OR Status_Operacao like '%" + _aguardando + "%')";
                }

                //Pesquisa com Veiculo e Placa
                if (Cliente == "" && Veiculo != "" && Placa != "" && Cor == "" && SP == "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Veiculo like '%" + Veiculo + "%' and Placa like '%" + Placa + "%' AND (Status_Operacao like '%" + _EmProducao + "%' OR Status_Operacao like '%" + _Pausado + "%' OR Status_Operacao like '%" + _aguardando + "%')";
                }

                //Pesquisa com Veiculo, Placa e Cor
                if (Cliente == "" && Veiculo != "" && Placa != "" && Cor != "" && SP == "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Veiculo like '%" + Veiculo + "%' and Placa like '%" + Placa + "%' and Cor like '%" + Cor + "%' AND (Status_Operacao like '%" + _EmProducao + "%' OR Status_Operacao like '%" + _Pausado + "%' OR Status_Operacao like '%" + _aguardando + "%')";
                }

                //Pesquisa com Veiculo, Placa, Cor e SP
                if (Cliente == "" && Veiculo != "" && Placa != "" && Cor != "" && SP != "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Veiculo like '%" + Veiculo + "%' and Placa like '%" + Placa + "%' and Cor like '%" + Cor + "%' and Pintura like '%" + SP + "%' AND (Status_Operacao like '%" + _EmProducao + "%' OR Status_Operacao like '%" + _Pausado + "%' OR Status_Operacao like '%" + _aguardando + "%')";
                }

                //Pesquisa com Placa
                if (Cliente == "" && Veiculo == "" && Placa != "" && Cor == "" && SP == "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Placa like '%" + Placa + "%' AND (Status_Operacao like '%" + _EmProducao + "%' OR Status_Operacao like '%" + _Pausado + "%' OR Status_Operacao like '%" + _aguardando + "%')";
                }

                //Pesquisa com Placa e Cor
                if (Cliente == "" && Veiculo == "" && Placa != "" && Cor != "" && SP == "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Placa like '%" + Placa + "%' and Cor like '%" + Cor + "%' AND (Status_Operacao like '%" + _EmProducao + "%' OR Status_Operacao like '%" + _Pausado + "%' OR Status_Operacao like '%" + _aguardando + "%')";
                }

                //Pesquisa com Placa, Cor e SP
                if (Cliente == "" && Veiculo == "" && Placa != "" && Cor != "" && SP != "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Placa like '%" + Placa + "%' and Cor like '%" + Cor + "%' and Pintura like '%" + SP + "%' AND (Status_Operacao like '%" + _EmProducao + "%' OR Status_Operacao like '%" + _Pausado + "%' OR Status_Operacao like '%" + _aguardando + "%')";
                }

                //Pesquisa com Cor
                if (Cliente == "" && Veiculo == "" && Placa == "" && Cor != "" && SP == "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cor like '%" + Cor + "%' AND (Status_Operacao like '%" + _EmProducao + "%' OR Status_Operacao like '%" + _Pausado + "%' OR Status_Operacao like '%" + _aguardando + "%')";
                }

                //Pesquisa com Cor e SP
                if (Cliente == "" && Veiculo == "" && Placa == "" && Cor != "" && SP != "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cor like '%" + Cor + "%' and Pintura like '%" + SP + "%' AND (Status_Operacao like '%" + _EmProducao + "%' OR Status_Operacao like '%" + _Pausado + "%' OR Status_Operacao like '%" + _aguardando + "%')";
                }

                //Pesquisa com SP
                if (Cliente == "" && Veiculo == "" && Placa == "" && Cor == "" && SP != "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Pintura like '%" + SP + "%' AND (Status_Operacao like '%" + _EmProducao + "%' OR Status_Operacao like '%" + _Pausado + "%' OR Status_Operacao like '%" + _aguardando + "%')";
                }

                //Pesquisa com Cliente e Placa
                if (Cliente != "" && Veiculo == "" && Placa != "" && Cor == "" && SP == "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cliente like '%" + Cliente + "%' and Placa Like'%" + Placa + "%' AND (Status_Operacao like '%" + _EmProducao + "%' OR Status_Operacao like '%" + _Pausado + "%' OR Status_Operacao like '%" + _aguardando + "%')";
                }

                //Pesquisa com Cliente, Placa e Cor
                if (Cliente != "" && Veiculo == "" && Placa != "" && Cor != "" && SP == "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cliente like '%" + Cliente + "%' and Placa Like'%" + Placa + "%' and Cor Like'%" + Cor + "%' AND (Status_Operacao like '%" + _EmProducao + "%' OR Status_Operacao like '%" + _Pausado + "%' OR Status_Operacao like '%" + _aguardando + "%')";
                }

                //Pesquisa com Cliente, Placa, Cor e SP
                if (Cliente != "" && Veiculo == "" && Placa != "" && Cor != "" && SP != "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cliente like '%" + Cliente + "%' and Placa Like'%" + Placa + "%' and Cor Like'%" + Cor + "%' and Pintura Like'%" + SP + "%' AND (Status_Operacao like '%" + _EmProducao + "%' OR Status_Operacao like '%" + _Pausado + "%' OR Status_Operacao like '%" + _aguardando + "%')";
                }

                //Pesquisa com Cliente e Cor
                if (Cliente != "" && Veiculo == "" && Placa == "" && Cor != "" && SP == "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cliente like '%" + Cliente + "%' and Cor Like'%" + Cor + "%' AND (Status_Operacao like '%" + _EmProducao + "%' OR Status_Operacao like '%" + _Pausado + "%' OR Status_Operacao like '%" + _aguardando + "%')";
                }

                //Pesquisa com Cliente, Cor e SP
                if (Cliente != "" && Veiculo == "" && Placa == "" && Cor != "" && SP != "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cliente like '%" + Cliente + "%' and Pintura Like'%" + SP + "%' and Cor Like'%" + Cor + "%' AND (Status_Operacao like '%" + _EmProducao + "%' OR Status_Operacao like '%" + _Pausado + "%' OR Status_Operacao like '%" + _aguardando + "%')";
                }

                //Pesquisa com Cliente e SP
                if (Cliente != "" && Veiculo == "" && Placa == "" && Cor == "" && SP != "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cliente like '%" + Cliente + "%' and Pintura Like'%" + SP + "%' AND (Status_Operacao like '%" + _EmProducao + "%' OR Status_Operacao like '%" + _Pausado + "%' OR Status_Operacao like '%" + _aguardando + "%')";
                }

                //Pesquisa com Veiculo, Cor
                if (Cliente == "" && Veiculo != "" && Placa == "" && Cor != "" && SP == "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Veiculo like '%" + Veiculo + "%' and Cor Like'%" + Cor + "%' and Cor Like'%" + Cor + "%' AND (Status_Operacao like '%" + _EmProducao + "%' OR Status_Operacao like '%" + _Pausado + "%' OR Status_Operacao like '%" + _aguardando + "%')";
                }

                //Pesquisa com Veiculo, Cor e SP
                if (Cliente == "" && Veiculo != "" && Placa == "" && Cor != "" && SP != "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Veiculo like '%" + Veiculo + "%' and Pintura Like'%" + SP + "%' and Cor Like'%" + Cor + "%' AND (Status_Operacao like '%" + _EmProducao + "%' OR Status_Operacao like '%" + _Pausado + "%' OR Status_Operacao like '%" + _aguardando + "%')";
                }

                //Pesquisa com Veiculo e SP
                if (Cliente == "" && Veiculo != "" && Placa == "" && Cor == "" && SP != "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Veiculo like '%" + Veiculo + "%' and Pintura Like'%" + SP + "%' AND (Status_Operacao like '%" + _EmProducao + "%' OR Status_Operacao like '%" + _Pausado + "%' OR Status_Operacao like '%" + _aguardando + "%')";
                }

                //Pesquisa com Placa e SP
                if (Cliente == "" && Veiculo == "" && Placa != "" && Cor == "" && SP != "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Placa like '%" + Placa + "%' and Pintura Like'%" + SP + "%' AND (Status_Operacao like '%" + _EmProducao + "%' OR Status_Operacao like '%" + _Pausado + "%' OR Status_Operacao like '%" + _aguardando + "%')";
                }

                //Pesquisa com Cor e SP
                if (Cliente == "" && Veiculo == "" && Placa == "" && Cor != "" && SP != "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cor like '%" + Cor + "%' and Pintura Like'%" + SP + "%' AND (Status_Operacao like '%" + _EmProducao + "%' OR Status_Operacao like '%" + _Pausado + "%' OR Status_Operacao like '%" + _aguardando + "%')";
                }

                //Pesquisa com Cliente, Veiculo, Placa e SP
                if (Cliente != "" && Veiculo != "" && Placa != "" && Cor == "" && SP != "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cliente like '%" + Cliente + "%' and Veiculo Like'%" + Veiculo + "%' and Placa Like'%" + Placa + "%' and Pintura Like'%" + SP + "%' AND (Status_Operacao like '%" + _EmProducao + "%' OR Status_Operacao like '%" + _Pausado + "%' OR Status_Operacao like '%" + _aguardando + "%')";
                }

                //Pesquisa com Cliente, Veiculo, Cor e SP
                if (Cliente != "" && Veiculo != "" && Placa == "" && Cor != "" && SP != "")
                {
                    cmd.CommandText = "Select * from Agendamentos where Cliente like '%" + Cliente + "%' and Veiculo Like'%" + Veiculo + "%' and Cor Like'%" + Cor + "%' and Pintura Like'%" + SP + "%' AND (Status_Operacao like '%" + _EmProducao + "%' OR Status_Operacao like '%" + _Pausado + "%' OR Status_Operacao like '%" + _aguardando + "%')";
                }


                OleDbDataReader dr = cmd.ExecuteReader();

                //define um item listview
                ListViewItem item;

                //inicia leitura do datareader
                while (dr.Read())
                {
                    item = new ListViewItem();
                    item.Text = dr.GetValue(0).ToString();

                    //preenche o listview com itens
                    for (int i = 1; i < dr.FieldCount; i++)
                    {
                        DateTime Data_Cadastro = Convert.ToDateTime(dr["Data_Cadastro"]);
                        DateTime Previsao = Convert.ToDateTime(dr["Previsao_Entrega"]);
                        string inicio = dr["Inicio"].ToString().ToUpper();
                        string final = dr["Fim"].ToString().ToUpper();
                        string Tempo = dr["Tempo"].ToString().ToUpper();

                        item.SubItems.Add(Data_Cadastro.ToShortDateString());
                        item.SubItems.Add(dr["Tipo_OS"].ToString());
                        item.SubItems.Add(dr["Cliente"].ToString().ToUpper());
                        item.SubItems.Add(dr["Veiculo"].ToString().ToUpper());
                        item.SubItems.Add(dr["Placa"].ToString().ToUpper());
                        item.SubItems.Add(dr["Grupo_Cores"].ToString().ToUpper());
                        item.SubItems.Add(dr["Cor"].ToString().ToUpper());
                        item.SubItems.Add(dr["Montadora"].ToString().ToUpper());
                        item.SubItems.Add(dr["Cod_Cor"].ToString().ToUpper());
                        item.SubItems.Add(dr["Quantidade"].ToString().ToUpper());
                        item.SubItems.Add(dr["Pintura"].ToString().ToUpper());
                        item.SubItems.Add(dr["Corpo_Prova"].ToString().ToUpper());
                        item.SubItems.Add(string.Concat(Previsao.ToString("dd/MM/yyyy HH:mm:ss")));
                        item.SubItems.Add(dr["Status_Operacao"].ToString().ToUpper());
                        if (inicio != String.Empty)
                        {
                            DateTime Inicio = Convert.ToDateTime(dr["Inicio"]);
                            item.SubItems.Add(string.Concat(Inicio.ToShortDateString(), " ", Inicio.ToLongTimeString()));
                        }
                        else
                        {
                            item.SubItems.Add(string.Empty);
                        }

                        if (final != string.Empty)
                        {
                            DateTime Final = Convert.ToDateTime(dr["Fim"]);
                            item.SubItems.Add(Final.ToShortTimeString());
                        }
                        else
                        {
                            item.SubItems.Add(string.Empty);
                        }

                        if (Tempo != string.Empty)
                        {
                            DateTime _Tempo = Convert.ToDateTime(dr["Tempo"]);
                            item.SubItems.Add(_Tempo.ToLongTimeString());
                        }
                        else
                        {
                            item.SubItems.Add(string.Empty);
                        }

                        item.SubItems.Add(dr["Entrega"].ToString().ToUpper());
                        item.SubItems.Add(dr["Prioridade"].ToString().ToUpper());
                        item.SubItems.Add(dr["Colorista"].ToString().ToUpper());
                        item.SubItems.Add(dr["Data_Faturamento"].ToString().ToUpper());
                        item.SubItems.Add(dr["Valor_Custo"].ToString().ToUpper());
                        item.SubItems.Add(dr["Valor_Venda"].ToString().ToUpper());
                        item.SubItems.Add(dr["Markup"].ToString().ToUpper());
                        item.SubItems.Add(dr["Contador_Chapinhas"].ToString().ToUpper());
                    }

                    lstTintas.Items.Add(item);

                    lvwColumnSorter.SortColumn = 19;
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
                //fecha o datareader
                dr.Close();


                this.ColorirLinhas();
            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                MessageBox.Show("Ocorreu um erro durante a execução da instrução SQL." +
                        "Erro : " + ex.Message, "SQL");
            }
            finally
            {
                //fecha a conexao
                conn.Close();
            }
            ColorirLinhas();
        }

        private void timerRelolgio_Tick(object sender, EventArgs e)
        {
            txtRelogio.Text = DateTime.Now.ToLongTimeString();
            txtData.Text = DateTime.Now.ToLongDateString();

        }


        private void cmdAtualizar_MouseEnter(object sender, EventArgs e)
        {
            Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Atualizar_Sobre.png");
            cmdAtualizar.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
            cmdAtualizar.BackgroundImage = BTN;
        }

        private void cmdAtualizar_MouseLeave(object sender, EventArgs e)
        {
            Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Atualizar_Fora.png");
            cmdAtualizar.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
            cmdAtualizar.BackgroundImage = BTN;
        }

        private void cmdNew_MouseEnter(object sender, EventArgs e)
        {
            Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Novo_Sobre.png");
            cmdNew.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
            cmdNew.BackgroundImage = BTN;
        }

        private void cmdNew_MouseLeave(object sender, EventArgs e)
        {
            Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Novo_Fora.png");
            cmdNew.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
            cmdNew.BackgroundImage = BTN;
        }

        private void cmdEdit_MouseEnter(object sender, EventArgs e)
        {
            Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Editar_Sobre.png");
            cmdEdit.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
            cmdEdit.BackgroundImage = BTN;
        }

        private void cmdEdit_MouseLeave(object sender, EventArgs e)
        {
            Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Editar_Fora.png");
            cmdEdit.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
            cmdEdit.BackgroundImage = BTN;
        }

        private void cmdEdit_EnabledChanged(object sender, EventArgs e)
        {
            if (cmdEdit.Enabled == false)
            {
                Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Editar_Desabilitado.png");
                cmdEdit.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
                cmdEdit.BackgroundImage = BTN;
            }
            else
            {
                Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Editar_Fora.png");
                cmdEdit.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
                cmdEdit.BackgroundImage = BTN;
            }
        }

        private void cmdNew_EnabledChanged(object sender, EventArgs e)
        {
            if (cmdNew.Enabled == false)
            {
                Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Novo_Desabilitado.png");
                cmdNew.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
                cmdNew.BackgroundImage = BTN;
            }
            else
            {
                Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Novo_Fora.png");
                cmdNew.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
                cmdNew.BackgroundImage = BTN;
            }
        }

        private void cmdAtualizar_EnabledChanged(object sender, EventArgs e)
        {
            if (cmdEdit.Enabled == false)
            {
                Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Atualizar_Desabilitado.png");
                cmdAtualizar.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
                cmdAtualizar.BackgroundImage = BTN;
            }
            else
            {
                Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Atualizar_Fora.png");
                cmdAtualizar.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
                cmdAtualizar.BackgroundImage = BTN;
            }
        }

        private void cmdExluir_MouseEnter(object sender, EventArgs e)
        {
            Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Excluir_Sobre.png");
            cmdExluir.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
            cmdExluir.BackgroundImage = BTN;
        }

        private void cmdExluir_MouseLeave(object sender, EventArgs e)
        {
            Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Excluir_Fora.png");
            cmdExluir.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
            cmdExluir.BackgroundImage = BTN;
        }

        private void cmdExluir_EnabledChanged(object sender, EventArgs e)
        {
            if (cmdExluir.Enabled == false)
            {
                Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Excluir_Desabilitado.png");
                cmdExluir.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
                cmdExluir.BackgroundImage = BTN;
            }
            else
            {
                Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Excluir_Fora.png");
                cmdExluir.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
                cmdExluir.BackgroundImage = BTN;
            }
        }

        private void cmdIniciar_MouseEnter(object sender, EventArgs e)
        {
            Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Iniciar_Sobre.png");
            cmdIniciar.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
            cmdIniciar.BackgroundImage = BTN;
        }

        private void cmdIniciar_MouseLeave(object sender, EventArgs e)
        {
            Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Iniciar_Fora.png");
            cmdIniciar.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
            cmdIniciar.BackgroundImage = BTN;
        }

        private void cmdIniciar_EnabledChanged(object sender, EventArgs e)
        {
            if (cmdIniciar.Enabled == false)
            {
                Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Iniciar_Desabilitado.png");
                cmdIniciar.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
                cmdIniciar.BackgroundImage = BTN;
            }
            else
            {
                Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Iniciar_Fora.png");
                cmdIniciar.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
                cmdIniciar.BackgroundImage = BTN;
            }
        }

        private void cmdPausar_MouseEnter(object sender, EventArgs e)
        {
            Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Pausar_Sobre.png");
            cmdPausar.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
            cmdPausar.BackgroundImage = BTN;
        }

        private void cmdPausar_MouseLeave(object sender, EventArgs e)
        {
            Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Pausar_Fora.png");
            cmdPausar.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
            cmdPausar.BackgroundImage = BTN;
        }

        private void cmdPausar_EnabledChanged(object sender, EventArgs e)
        {
            if (cmdPausar.Enabled == false)
            {
                Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Pausar_Desabilitado.png");
                cmdPausar.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
                cmdPausar.BackgroundImage = BTN;
            }
            else
            {
                Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Pausar_Fora.png");
                cmdPausar.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
                cmdPausar.BackgroundImage = BTN;
            }
        }

        private void cmdFinalizar_MouseEnter(object sender, EventArgs e)
        {
            Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Finalizar_Sobre.png");
            cmdFinalizar.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
            cmdFinalizar.BackgroundImage = BTN;
        }

        private void cmdFinalizar_MouseLeave(object sender, EventArgs e)
        {
            Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Finalizar_Fora.png");
            cmdFinalizar.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
            cmdFinalizar.BackgroundImage = BTN;
        }

        private void cmdFinalizar_EnabledChanged(object sender, EventArgs e)
        {
            if (cmdFinalizar.Enabled == false)
            {
                Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Finalizar_Desabilitado.png");
                cmdFinalizar.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
                cmdFinalizar.BackgroundImage = BTN;
            }
            else
            {
                Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Finalizar_Fora.png");
                cmdFinalizar.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
                cmdFinalizar.BackgroundImage = BTN;
            }
        }

        private void cmdSair_MouseEnter(object sender, EventArgs e)
        {
            Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Sair_Sobre.png");
            cmdSair.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
            cmdSair.BackgroundImage = BTN;
        }

        private void cmdSair_MouseLeave(object sender, EventArgs e)
        {
            Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Sair_Fora.png");
            cmdSair.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
            cmdSair.BackgroundImage = BTN;
        }

        private void cmdSair_EnabledChanged(object sender, EventArgs e)
        {
            if (cmdSair.Enabled == false)
            {
                Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Sair_Desabilitado.png");
                cmdSair.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
                cmdSair.BackgroundImage = BTN;
            }
            else
            {
                Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Sair_Fora.png");
                cmdSair.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
                cmdSair.BackgroundImage = BTN;
            }
        }

        private void cmdPesquisar_MouseEnter(object sender, EventArgs e)
        {
            Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Pesquisar_Sobre.png");
            cmdPesquisar.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
            cmdPesquisar.BackgroundImage = BTN;
        }

        private void cmdPesquisar_MouseLeave(object sender, EventArgs e)
        {
            Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Pesquisar_Fora.png");
            cmdPesquisar.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
            cmdPesquisar.BackgroundImage = BTN;
        }

        private void cmdPesquisar_EnabledChanged(object sender, EventArgs e)
        {
            if (cmdPesquisar.Enabled == false)
            {
                Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Pesquisar_Desabilitado.png");
                cmdPesquisar.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
                cmdPesquisar.BackgroundImage = BTN;
            }
            else
            {
                Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Pesquisar_Fora.png");
                cmdPesquisar.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
                cmdPesquisar.BackgroundImage = BTN;
            }
        }

        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.Enter:
                    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    this.PEsquisarLST();
                    this.PEsquisarLSTFinalizadas();
                    e.Handled = true;
                    break;
            }
        }



        private void txtPlaca_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    if (txtPlaca.MaskFull == true)
                    {
                        txtPlaca.TextMaskFormat = MaskFormat.IncludeLiterals;
                    }
                    if (txtPlaca.MaskFull == false)
                    {
                        txtPlaca.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    }

                    this.PEsquisarLST();
                    this.PEsquisarLSTFinalizadas();

                    break;
            }
        }

        private void txtCor_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.PEsquisarLST();
                    this.PEsquisarLSTFinalizadas();

                    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    break;
            }
        }

        private void txtSP_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.PEsquisarLST();
                    this.PEsquisarLSTFinalizadas();

                    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    break;
            }
        }

        private void txtCliente_Enter(object sender, EventArgs e)
        {
            txtCliente.Text = string.Empty;
        }

        private void txtCor_Enter(object sender, EventArgs e)
        {
            txtCor.Text = string.Empty;
        }

        private void txtSP_Enter(object sender, EventArgs e)
        {
            txtSP.Text = string.Empty;
        }

        private void txtVeiculo_Enter(object sender, EventArgs e)
        {
            txtVeiculo.Text = string.Empty;
        }

        private void txtVeiculo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.PEsquisarLST();
                    this.PEsquisarLSTFinalizadas();

                    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    break;
            }
        }

        private void txtPlaca_Enter(object sender, EventArgs e)
        {
            txtPlaca.Clear();
        }

        private void frmPrincipal_Resize(object sender, EventArgs e)
        {
            if (this.Width < 770)
            {
                txtData.Visible = false;
            }
            if (this.Width > 770)
            {
                txtData.Visible = true;
            }
            if (this.Width < (850 * Globais.Fator_Largura))
            {
                cmdSair.Visible = false;
            }
            if (this.Width > (850 * Globais.Fator_Largura))
            {
                cmdSair.Visible = true;
            }

        }

        public void AlertaSonoro()
        {


        }

        private void TimerPrazo_Tick(object sender, EventArgs e)
        {

            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            try
            {
                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();
                string Status = "EM PRODUÇÃO";
                string Status2 = "AGUARDANDO";
                string Status3 = "PAUSADO";
                string StatusEntrega = "ATRASADO";
                DateTime Agora = DateTime.Now;

                //define o tipo do comando como texto 
                cmd.CommandText = "Select * from Agendamentos WHERE Status_Operacao like '" + Status + "' or Status_Operacao like '" + Status2 + "' or Status_Operacao like '" + Status3 + "'";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                //inicia leitura do datareader
                while (dr.Read())
                {
                    string id = dr["Código"].ToString();
                    string Cliente = dr["Cliente"].ToString();
                    string Veiculo = dr["Veiculo"].ToString();
                    string Placa = dr["Placa"].ToString();
                    string Entrega = dr["Entrega"].ToString();

                    DateTime _Previsao = Convert.ToDateTime(dr["Previsao_Entrega"]);
                    if (Entrega == "NO PRAZO")
                    {
                        if (_Previsao < Agora)
                        {
                            OleDbCommand cmd2 = conn.CreateCommand();
                            cmd2.CommandText = "UPDATE Agendamentos SET Entrega='" + StatusEntrega.Replace("'", "''") + "' WHERE Código=" + int.Parse(id) + "";

                            cmd2.ExecuteNonQuery();

                            Form messagebox = new frmMensagemPersonalizada("Alerta", "Ordem de Serviço", "Ordem de serviço " + Cliente + " " + Veiculo + " " + Placa + " esta em atrazo!");
                            messagebox.ShowDialog();

                            this.carrega_LST_tintas();
                            this.AtualizaLSTOSAberta();
                        }

                    }
                }
                //fecha o datareader
                dr.Close();


            }

            finally
            {
                //fecha a conexao
                conn.Close();
            }

        }

        private void lstTintasFinalizadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (check_Multi_Selecao.Checked == true)
            {
            }

            if (check_Multi_Selecao.Checked == false)
            {
                cmdNew.Enabled = true;
                cmdEdit.Enabled = false;
                cmdExluir.Enabled = false;
                cmdIniciar.Enabled = false;
                cmdPausar.Enabled = false;
                cmdFinalizar.Enabled = false;
                cmdFaturar.Enabled = true;
                cmdReabrir.Enabled = true;
                txtPrioridade.Text = string.Empty;

                this.Painel_Opcoes.Width = 20;
                this.cmdClose_Options.Visible = false;
                this.cmdOpen_Options.Visible = true;
            }
        }

        private void lstTintasFinalizadas_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter2.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter2.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter2.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter2.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter2.SortColumn = e.Column;
                lvwColumnSorter2.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lstTintasFinalizadas.Sort();
        }

        private void cmdClose_Options_Click(object sender, EventArgs e)
        {
            this.Painel_Opcoes.Width = 32;
            this.cmdClose_Options.Visible = false;
            this.cmdOpen_Options.Visible = true;
        }

        private void cmdOpen_Options_Click(object sender, EventArgs e)
        {
            this.Painel_Opcoes.Width = 440;
            this.cmdClose_Options.Visible = true;
            this.cmdOpen_Options.Visible = false;

            panel2.Visible = false;
            btnExibirContador.Visible = true;
        }


        private void checkNumero_OS_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNumero_OS.Checked == true)
            {
                lstTintas.Columns[0].Width = Globais.LstTIntas_Coluna_NumeroOS;
                lstTintasFinalizadas.Columns[0].Width = Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn1.Width = Globais.LstTIntas_Coluna_NumeroOS + 2;
                cmdLSTColumn2.Left += Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn3.Left += Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn4.Left += Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn5.Left += Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn6.Left += Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn7.Left += Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn8.Left += Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn9.Left += Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn10.Left += Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn11.Left += Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn12.Left += Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn13.Left += Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn14.Left += Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn15.Left += Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn16.Left += Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn17.Left += Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn18.Left += Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn19.Left += Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn20.Left += Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn21.Left += Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn22.Left += Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn23.Left += Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn24.Left += Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn25.Left += Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn26.Left += Globais.LstTIntas_Coluna_NumeroOS;
            }
            if (checkNumero_OS.Checked == false)
            {
                lstTintas.Columns[0].Width = 0;
                lstTintasFinalizadas.Columns[0].Width = 0;
                cmdLSTColumn1.Width = 0;
                cmdLSTColumn2.Left -= Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn3.Left -= Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn4.Left -= Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn5.Left -= Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn6.Left -= Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn7.Left -= Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn8.Left -= Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn9.Left -= Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn10.Left -= Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn11.Left -= Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn12.Left -= Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn13.Left -= Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn14.Left -= Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn15.Left -= Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn16.Left -= Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn17.Left -= Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn18.Left -= Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn19.Left -= Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn20.Left -= Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn21.Left -= Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn22.Left -= Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn23.Left -= Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn24.Left -= Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn25.Left -= Globais.LstTIntas_Coluna_NumeroOS;
                cmdLSTColumn26.Left -= Globais.LstTIntas_Coluna_NumeroOS;
            }
        }

        private void check_DataCadastro_CheckedChanged(object sender, EventArgs e)
        {
            if (check_DataCadastro.Checked == true)
            {
                lstTintas.Columns[1].Width = Globais.LstTIntas_Coluna_DataCadastro;
                lstTintasFinalizadas.Columns[1].Width = Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn2.Width = Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn3.Left += Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn4.Left += Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn5.Left += Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn6.Left += Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn7.Left += Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn8.Left += Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn9.Left += Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn10.Left += Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn11.Left += Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn12.Left += Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn13.Left += Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn14.Left += Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn15.Left += Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn16.Left += Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn17.Left += Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn18.Left += Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn19.Left += Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn20.Left += Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn21.Left += Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn22.Left += Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn23.Left += Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn24.Left += Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn25.Left += Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn26.Left += Globais.LstTIntas_Coluna_DataCadastro;
            }
            if (check_DataCadastro.Checked == false)
            {
                lstTintas.Columns[1].Width = 0;
                lstTintasFinalizadas.Columns[1].Width = 0;
                cmdLSTColumn2.Width = 0;
                cmdLSTColumn3.Left -= Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn4.Left -= Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn5.Left -= Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn6.Left -= Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn7.Left -= Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn8.Left -= Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn9.Left -= Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn10.Left -= Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn11.Left -= Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn12.Left -= Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn13.Left -= Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn14.Left -= Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn15.Left -= Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn16.Left -= Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn17.Left -= Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn18.Left -= Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn19.Left -= Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn20.Left -= Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn21.Left -= Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn22.Left -= Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn23.Left -= Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn24.Left -= Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn25.Left -= Globais.LstTIntas_Coluna_DataCadastro;
                cmdLSTColumn26.Left -= Globais.LstTIntas_Coluna_DataCadastro;
            }
        }

        private void check_Previsao_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Previsao.Checked == true)
            {
                lstTintas.Columns[13].Width = Globais.LstTIntas_Coluna_Previsao;
                lstTintasFinalizadas.Columns[13].Width = Globais.LstTIntas_Coluna_Previsao;
                cmdLSTColumn14.Width = Globais.LstTIntas_Coluna_Previsao;
                cmdLSTColumn15.Left += Globais.LstTIntas_Coluna_Previsao;
                cmdLSTColumn16.Left += Globais.LstTIntas_Coluna_Previsao;
                cmdLSTColumn17.Left += Globais.LstTIntas_Coluna_Previsao;
                cmdLSTColumn18.Left += Globais.LstTIntas_Coluna_Previsao;
                cmdLSTColumn19.Left += Globais.LstTIntas_Coluna_Previsao;
                cmdLSTColumn20.Left += Globais.LstTIntas_Coluna_Previsao;
                cmdLSTColumn21.Left += Globais.LstTIntas_Coluna_Previsao;
                cmdLSTColumn22.Left += Globais.LstTIntas_Coluna_Previsao;
                cmdLSTColumn23.Left += Globais.LstTIntas_Coluna_Previsao;
                cmdLSTColumn24.Left += Globais.LstTIntas_Coluna_Previsao;
                cmdLSTColumn25.Left += Globais.LstTIntas_Coluna_Previsao;
                cmdLSTColumn26.Left += Globais.LstTIntas_Coluna_Previsao;
            }
            if (check_Previsao.Checked == false)
            {
                lstTintas.Columns[13].Width = 0;
                lstTintasFinalizadas.Columns[13].Width = 0;
                cmdLSTColumn14.Width = 0;
                cmdLSTColumn15.Left -= Globais.LstTIntas_Coluna_Previsao;
                cmdLSTColumn16.Left -= Globais.LstTIntas_Coluna_Previsao;
                cmdLSTColumn17.Left -= Globais.LstTIntas_Coluna_Previsao;
                cmdLSTColumn18.Left -= Globais.LstTIntas_Coluna_Previsao;
                cmdLSTColumn19.Left -= Globais.LstTIntas_Coluna_Previsao;
                cmdLSTColumn20.Left -= Globais.LstTIntas_Coluna_Previsao;
                cmdLSTColumn21.Left -= Globais.LstTIntas_Coluna_Previsao;
                cmdLSTColumn22.Left -= Globais.LstTIntas_Coluna_Previsao;
                cmdLSTColumn23.Left -= Globais.LstTIntas_Coluna_Previsao;
                cmdLSTColumn24.Left -= Globais.LstTIntas_Coluna_Previsao;
                cmdLSTColumn25.Left -= Globais.LstTIntas_Coluna_Previsao;
                cmdLSTColumn26.Left -= Globais.LstTIntas_Coluna_Previsao;
            }
        }

        private void check_TipoOS_CheckedChanged(object sender, EventArgs e)
        {
            if (check_TipoOS.Checked == true)
            {
                lstTintas.Columns[2].Width = Globais.LstTIntas_Coluna_TipoOS;
                lstTintasFinalizadas.Columns[2].Width = Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn3.Width = Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn4.Left += Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn5.Left += Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn6.Left += Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn7.Left += Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn8.Left += Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn9.Left += Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn10.Left += Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn11.Left += Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn12.Left += Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn13.Left += Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn14.Left += Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn15.Left += Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn16.Left += Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn17.Left += Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn18.Left += Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn19.Left += Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn20.Left += Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn21.Left += Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn22.Left += Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn23.Left += Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn24.Left += Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn25.Left += Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn26.Left += Globais.LstTIntas_Coluna_TipoOS;
            }
            if (check_TipoOS.Checked == false)
            {
                lstTintas.Columns[2].Width = 0;
                lstTintasFinalizadas.Columns[2].Width = 0;
                cmdLSTColumn3.Width = 0;
                cmdLSTColumn4.Left -= Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn5.Left -= Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn6.Left -= Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn7.Left -= Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn8.Left -= Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn9.Left -= Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn10.Left -= Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn11.Left -= Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn12.Left -= Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn13.Left -= Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn15.Left -= Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn16.Left -= Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn17.Left -= Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn18.Left -= Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn19.Left -= Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn20.Left -= Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn21.Left -= Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn22.Left -= Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn23.Left -= Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn24.Left -= Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn25.Left -= Globais.LstTIntas_Coluna_TipoOS;
                cmdLSTColumn26.Left -= Globais.LstTIntas_Coluna_TipoOS;
            }
        }

        private void check_Cliente_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Cliente.Checked == true)
            {
                lstTintas.Columns[3].Width = Globais.LstTIntas_Coluna_Cliente;
                lstTintasFinalizadas.Columns[3].Width = Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn4.Width = Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn5.Left += Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn6.Left += Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn7.Left += Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn8.Left += Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn9.Left += Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn10.Left += Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn11.Left += Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn12.Left += Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn13.Left += Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn14.Left += Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn15.Left += Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn16.Left += Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn17.Left += Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn18.Left += Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn19.Left += Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn20.Left += Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn21.Left += Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn22.Left += Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn23.Left += Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn24.Left += Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn25.Left += Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn26.Left += Globais.LstTIntas_Coluna_Cliente;
            }
            if (check_Cliente.Checked == false)
            {
                lstTintas.Columns[3].Width = 0;
                lstTintasFinalizadas.Columns[3].Width = 0;
                cmdLSTColumn4.Width = 0;
                cmdLSTColumn5.Left -= Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn6.Left -= Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn7.Left -= Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn8.Left -= Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn9.Left -= Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn10.Left -= Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn11.Left -= Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn12.Left -= Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn13.Left -= Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn14.Left -= Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn15.Left -= Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn16.Left -= Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn17.Left -= Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn18.Left -= Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn19.Left -= Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn20.Left -= Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn21.Left -= Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn22.Left -= Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn23.Left -= Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn24.Left -= Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn25.Left -= Globais.LstTIntas_Coluna_Cliente;
                cmdLSTColumn26.Left -= Globais.LstTIntas_Coluna_Cliente;

            }
        }

        private void check_Veiculo_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Veiculo.Checked == true)
            {
                lstTintas.Columns[4].Width = Globais.LstTIntas_Coluna_Veiculo;
                lstTintasFinalizadas.Columns[4].Width = Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn5.Width = Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn6.Left += Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn7.Left += Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn8.Left += Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn9.Left += Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn10.Left += Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn11.Left += Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn12.Left += Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn13.Left += Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn14.Left += Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn15.Left += Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn16.Left += Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn17.Left += Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn18.Left += Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn19.Left += Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn20.Left += Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn21.Left += Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn22.Left += Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn23.Left += Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn24.Left += Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn25.Left += Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn26.Left += Globais.LstTIntas_Coluna_Veiculo;
            }
            if (check_Veiculo.Checked == false)
            {
                lstTintas.Columns[4].Width = 0;
                lstTintasFinalizadas.Columns[4].Width = 0;
                cmdLSTColumn5.Width = 0;
                cmdLSTColumn6.Left -= Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn7.Left -= Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn8.Left -= Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn9.Left -= Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn10.Left -= Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn11.Left -= Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn12.Left -= Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn13.Left -= Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn14.Left -= Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn15.Left -= Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn16.Left -= Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn17.Left -= Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn18.Left -= Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn19.Left -= Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn20.Left -= Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn21.Left -= Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn22.Left -= Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn23.Left -= Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn24.Left -= Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn25.Left -= Globais.LstTIntas_Coluna_Veiculo;
                cmdLSTColumn26.Left -= Globais.LstTIntas_Coluna_Veiculo;
            }
        }

        private void check_Placa_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Placa.Checked == true)
            {
                lstTintas.Columns[5].Width = Globais.LstTIntas_Coluna_Placa;
                lstTintasFinalizadas.Columns[5].Width = Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn6.Width = Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn7.Left += Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn8.Left += Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn9.Left += Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn10.Left += Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn11.Left += Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn12.Left += Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn13.Left += Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn14.Left += Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn15.Left += Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn16.Left += Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn17.Left += Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn18.Left += Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn19.Left += Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn20.Left += Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn21.Left += Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn22.Left += Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn23.Left += Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn24.Left += Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn25.Left += Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn26.Left += Globais.LstTIntas_Coluna_Placa;
            }
            if (check_Placa.Checked == false)
            {
                lstTintas.Columns[5].Width = 0;
                lstTintasFinalizadas.Columns[5].Width = 0;
                cmdLSTColumn6.Width = 0;
                cmdLSTColumn7.Left -= Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn8.Left -= Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn9.Left -= Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn10.Left -= Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn11.Left -= Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn12.Left -= Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn13.Left -= Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn14.Left -= Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn15.Left -= Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn16.Left -= Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn17.Left -= Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn18.Left -= Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn19.Left -= Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn20.Left -= Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn21.Left -= Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn22.Left -= Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn23.Left -= Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn24.Left -= Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn25.Left -= Globais.LstTIntas_Coluna_Placa;
                cmdLSTColumn26.Left -= Globais.LstTIntas_Coluna_Placa;
            }
        }

        private void check_GrupoCores_CheckedChanged(object sender, EventArgs e)
        {
            if (check_GrupoCores.Checked == true)
            {
                lstTintas.Columns[6].Width = Globais.LstTIntas_Coluna_GrupoCores;
                lstTintasFinalizadas.Columns[6].Width = Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn7.Width = Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn8.Left += Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn9.Left += Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn10.Left += Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn11.Left += Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn12.Left += Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn13.Left += Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn14.Left += Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn15.Left += Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn16.Left += Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn17.Left += Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn18.Left += Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn19.Left += Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn20.Left += Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn21.Left += Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn22.Left += Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn23.Left += Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn24.Left += Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn25.Left += Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn26.Left += Globais.LstTIntas_Coluna_GrupoCores;
            }
            if (check_GrupoCores.Checked == false)
            {
                lstTintas.Columns[6].Width = 0;
                lstTintasFinalizadas.Columns[6].Width = 0;
                cmdLSTColumn7.Width = 0;
                cmdLSTColumn8.Left -= Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn9.Left -= Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn10.Left -= Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn11.Left -= Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn12.Left -= Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn13.Left -= Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn14.Left -= Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn15.Left -= Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn16.Left -= Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn17.Left -= Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn18.Left -= Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn19.Left -= Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn20.Left -= Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn21.Left -= Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn22.Left -= Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn23.Left -= Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn24.Left -= Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn25.Left -= Globais.LstTIntas_Coluna_GrupoCores;
                cmdLSTColumn26.Left -= Globais.LstTIntas_Coluna_GrupoCores;
            }
        }

        private void check_Montadora_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Montadora.Checked == true)
            {
                lstTintas.Columns[8].Width = Globais.LstTIntas_Coluna_Montadora;
                lstTintasFinalizadas.Columns[8].Width = Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn9.Width = Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn10.Left += Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn11.Left += Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn12.Left += Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn13.Left += Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn14.Left += Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn15.Left += Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn16.Left += Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn17.Left += Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn18.Left += Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn19.Left += Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn20.Left += Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn21.Left += Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn22.Left += Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn23.Left += Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn24.Left += Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn25.Left += Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn26.Left += Globais.LstTIntas_Coluna_Montadora;
            }
            if (check_Montadora.Checked == false)
            {
                lstTintas.Columns[8].Width = 0;
                lstTintasFinalizadas.Columns[8].Width = 0;
                cmdLSTColumn9.Width = 0;
                cmdLSTColumn10.Left -= Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn11.Left -= Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn12.Left -= Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn13.Left -= Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn14.Left -= Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn15.Left -= Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn16.Left -= Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn17.Left -= Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn18.Left -= Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn19.Left -= Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn20.Left -= Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn21.Left -= Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn22.Left -= Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn23.Left -= Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn24.Left -= Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn25.Left -= Globais.LstTIntas_Coluna_Montadora;
                cmdLSTColumn26.Left -= Globais.LstTIntas_Coluna_Montadora;
            }
        }

        private void check_CodigoCor_CheckedChanged(object sender, EventArgs e)
        {
            if (check_CodigoCor.Checked == true)
            {
                lstTintas.Columns[9].Width = Globais.LstTIntas_Coluna_CodigoCor;
                lstTintasFinalizadas.Columns[9].Width = Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn10.Width = Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn11.Left += Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn12.Left += Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn13.Left += Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn14.Left += Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn15.Left += Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn16.Left += Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn17.Left += Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn18.Left += Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn19.Left += Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn20.Left += Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn21.Left += Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn22.Left += Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn23.Left += Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn24.Left += Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn25.Left += Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn26.Left += Globais.LstTIntas_Coluna_CodigoCor;
            }
            if (check_CodigoCor.Checked == false)
            {
                lstTintas.Columns[9].Width = 0;
                lstTintasFinalizadas.Columns[9].Width = 0;
                cmdLSTColumn10.Width = 0;
                cmdLSTColumn11.Left -= Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn12.Left -= Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn13.Left -= Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn14.Left -= Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn15.Left -= Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn16.Left -= Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn17.Left -= Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn18.Left -= Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn19.Left -= Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn20.Left -= Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn21.Left -= Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn22.Left -= Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn23.Left -= Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn24.Left -= Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn25.Left -= Globais.LstTIntas_Coluna_CodigoCor;
                cmdLSTColumn26.Left -= Globais.LstTIntas_Coluna_CodigoCor;
            }
        }

        private void checkQuantidade_CheckedChanged(object sender, EventArgs e)
        {
            if (checkQuantidade.Checked == true)
            {
                lstTintas.Columns[10].Width = Globais.LstTIntas_Coluna_Quantidade;
                lstTintasFinalizadas.Columns[10].Width = Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn11.Width = Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn12.Left += Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn13.Left += Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn14.Left += Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn15.Left += Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn16.Left += Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn17.Left += Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn18.Left += Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn19.Left += Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn20.Left += Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn21.Left += Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn22.Left += Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn23.Left += Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn24.Left += Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn25.Left += Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn26.Left += Globais.LstTIntas_Coluna_Quantidade;
            }
            if (checkQuantidade.Checked == false)
            {
                lstTintas.Columns[10].Width = 0;
                lstTintasFinalizadas.Columns[10].Width = 0;
                cmdLSTColumn11.Width = 0;
                cmdLSTColumn12.Left -= Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn13.Left -= Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn14.Left -= Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn15.Left -= Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn16.Left -= Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn17.Left -= Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn18.Left -= Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn19.Left -= Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn20.Left -= Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn21.Left -= Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn22.Left -= Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn23.Left -= Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn24.Left -= Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn25.Left -= Globais.LstTIntas_Coluna_Quantidade;
                cmdLSTColumn26.Left -= Globais.LstTIntas_Coluna_Quantidade;
            }
        }

        private void checkPintura_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPintura.Checked == true)
            {
                lstTintas.Columns[11].Width = Globais.LstTIntas_Coluna_Pintura;
                lstTintasFinalizadas.Columns[11].Width = Globais.LstTIntas_Coluna_Pintura;
                cmdLSTColumn12.Width = Globais.LstTIntas_Coluna_Pintura;
                cmdLSTColumn13.Left += Globais.LstTIntas_Coluna_Pintura;
                cmdLSTColumn14.Left += Globais.LstTIntas_Coluna_Pintura;
                cmdLSTColumn15.Left += Globais.LstTIntas_Coluna_Pintura;
                cmdLSTColumn16.Left += Globais.LstTIntas_Coluna_Pintura;
                cmdLSTColumn17.Left += Globais.LstTIntas_Coluna_Pintura;
                cmdLSTColumn18.Left += Globais.LstTIntas_Coluna_Pintura;
                cmdLSTColumn19.Left += Globais.LstTIntas_Coluna_Pintura;
                cmdLSTColumn20.Left += Globais.LstTIntas_Coluna_Pintura;
                cmdLSTColumn21.Left += Globais.LstTIntas_Coluna_Pintura;
                cmdLSTColumn22.Left += Globais.LstTIntas_Coluna_Pintura;
                cmdLSTColumn23.Left += Globais.LstTIntas_Coluna_Pintura;
                cmdLSTColumn24.Left += Globais.LstTIntas_Coluna_Pintura;
                cmdLSTColumn25.Left += Globais.LstTIntas_Coluna_Pintura;
                cmdLSTColumn26.Left += Globais.LstTIntas_Coluna_Pintura;
            }
            if (checkPintura.Checked == false)
            {
                lstTintas.Columns[11].Width = 0;
                lstTintasFinalizadas.Columns[11].Width = 0;
                cmdLSTColumn12.Width = 0;
                cmdLSTColumn13.Left -= Globais.LstTIntas_Coluna_Pintura;
                cmdLSTColumn14.Left -= Globais.LstTIntas_Coluna_Pintura;
                cmdLSTColumn15.Left -= Globais.LstTIntas_Coluna_Pintura;
                cmdLSTColumn16.Left -= Globais.LstTIntas_Coluna_Pintura;
                cmdLSTColumn17.Left -= Globais.LstTIntas_Coluna_Pintura;
                cmdLSTColumn18.Left -= Globais.LstTIntas_Coluna_Pintura;
                cmdLSTColumn19.Left -= Globais.LstTIntas_Coluna_Pintura;
                cmdLSTColumn20.Left -= Globais.LstTIntas_Coluna_Pintura;
                cmdLSTColumn21.Left -= Globais.LstTIntas_Coluna_Pintura;
                cmdLSTColumn22.Left -= Globais.LstTIntas_Coluna_Pintura;
                cmdLSTColumn23.Left -= Globais.LstTIntas_Coluna_Pintura;
                cmdLSTColumn24.Left -= Globais.LstTIntas_Coluna_Pintura;
                cmdLSTColumn25.Left -= Globais.LstTIntas_Coluna_Pintura;
                cmdLSTColumn26.Left -= Globais.LstTIntas_Coluna_Pintura;
            }
        }

        private void checkColorista_CheckedChanged(object sender, EventArgs e)
        {
            if (checkColorista.Checked == true)
            {
                lstTintas.Columns[20].Width = Globais.LstTIntas_Coluna_Colorista;
                lstTintasFinalizadas.Columns[20].Width = Globais.LstTIntas_Coluna_Colorista;
                cmdLSTColumn21.Width = Globais.LstTIntas_Coluna_Colorista;
                cmdLSTColumn22.Left += Globais.LstTIntas_Coluna_Colorista;
                cmdLSTColumn23.Left += Globais.LstTIntas_Coluna_Colorista;
                cmdLSTColumn24.Left += Globais.LstTIntas_Coluna_Colorista;
                cmdLSTColumn25.Left += Globais.LstTIntas_Coluna_Colorista;
                cmdLSTColumn26.Left += Globais.LstTIntas_Coluna_Colorista;
            }
            if (checkColorista.Checked == false)
            {
                lstTintas.Columns[20].Width = 0;
                lstTintasFinalizadas.Columns[20].Width = 0;
                cmdLSTColumn21.Width = 0;
                cmdLSTColumn22.Left -= Globais.LstTIntas_Coluna_Colorista;
                cmdLSTColumn23.Left -= Globais.LstTIntas_Coluna_Colorista;
                cmdLSTColumn24.Left -= Globais.LstTIntas_Coluna_Colorista;
                cmdLSTColumn25.Left -= Globais.LstTIntas_Coluna_Colorista;
                cmdLSTColumn26.Left -= Globais.LstTIntas_Coluna_Colorista;
            }
        }

        private void checkCorpoProva_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCorpoProva.Checked == true)
            {
                lstTintas.Columns[12].Width = Globais.LstTIntas_Coluna_CorpoProva;
                lstTintasFinalizadas.Columns[12].Width = Globais.LstTIntas_Coluna_CorpoProva;
                cmdLSTColumn13.Width = Globais.LstTIntas_Coluna_CorpoProva;
                cmdLSTColumn14.Left += Globais.LstTIntas_Coluna_CorpoProva;
                cmdLSTColumn15.Left += Globais.LstTIntas_Coluna_CorpoProva;
                cmdLSTColumn16.Left += Globais.LstTIntas_Coluna_CorpoProva;
                cmdLSTColumn17.Left += Globais.LstTIntas_Coluna_CorpoProva;
                cmdLSTColumn18.Left += Globais.LstTIntas_Coluna_CorpoProva;
                cmdLSTColumn19.Left += Globais.LstTIntas_Coluna_CorpoProva;
                cmdLSTColumn20.Left += Globais.LstTIntas_Coluna_CorpoProva;
                cmdLSTColumn21.Left += Globais.LstTIntas_Coluna_CorpoProva;
                cmdLSTColumn22.Left += Globais.LstTIntas_Coluna_CorpoProva;
                cmdLSTColumn23.Left += Globais.LstTIntas_Coluna_CorpoProva;
                cmdLSTColumn24.Left += Globais.LstTIntas_Coluna_CorpoProva;
                cmdLSTColumn25.Left += Globais.LstTIntas_Coluna_CorpoProva;
                cmdLSTColumn26.Left += Globais.LstTIntas_Coluna_CorpoProva;
            }
            if (checkCorpoProva.Checked == false)
            {
                lstTintas.Columns[12].Width = 0;
                lstTintasFinalizadas.Columns[12].Width = 0;
                cmdLSTColumn13.Width = 0;
                cmdLSTColumn14.Left -= Globais.LstTIntas_Coluna_CorpoProva;
                cmdLSTColumn15.Left -= Globais.LstTIntas_Coluna_CorpoProva;
                cmdLSTColumn16.Left -= Globais.LstTIntas_Coluna_CorpoProva;
                cmdLSTColumn17.Left -= Globais.LstTIntas_Coluna_CorpoProva;
                cmdLSTColumn18.Left -= Globais.LstTIntas_Coluna_CorpoProva;
                cmdLSTColumn19.Left -= Globais.LstTIntas_Coluna_CorpoProva;
                cmdLSTColumn20.Left -= Globais.LstTIntas_Coluna_CorpoProva;
                cmdLSTColumn21.Left -= Globais.LstTIntas_Coluna_CorpoProva;
                cmdLSTColumn22.Left -= Globais.LstTIntas_Coluna_CorpoProva;
                cmdLSTColumn23.Left -= Globais.LstTIntas_Coluna_CorpoProva;
                cmdLSTColumn24.Left -= Globais.LstTIntas_Coluna_CorpoProva;
                cmdLSTColumn25.Left -= Globais.LstTIntas_Coluna_CorpoProva;
                cmdLSTColumn26.Left -= Globais.LstTIntas_Coluna_CorpoProva;
            }
        }

        private void checkStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (checkStatus.Checked == true)
            {
                lstTintas.Columns[14].Width = Globais.LstTIntas_Coluna_StatusOperacao;
                lstTintasFinalizadas.Columns[14].Width = Globais.LstTIntas_Coluna_StatusOperacao;
                cmdLSTColumn15.Width = Globais.LstTIntas_Coluna_StatusOperacao;
                cmdLSTColumn16.Left += Globais.LstTIntas_Coluna_StatusOperacao;
                cmdLSTColumn17.Left += Globais.LstTIntas_Coluna_StatusOperacao;
                cmdLSTColumn18.Left += Globais.LstTIntas_Coluna_StatusOperacao;
                cmdLSTColumn19.Left += Globais.LstTIntas_Coluna_StatusOperacao;
                cmdLSTColumn20.Left += Globais.LstTIntas_Coluna_StatusOperacao;
                cmdLSTColumn21.Left += Globais.LstTIntas_Coluna_StatusOperacao;
                cmdLSTColumn22.Left += Globais.LstTIntas_Coluna_StatusOperacao;
                cmdLSTColumn23.Left += Globais.LstTIntas_Coluna_StatusOperacao;
                cmdLSTColumn24.Left += Globais.LstTIntas_Coluna_StatusOperacao;
                cmdLSTColumn25.Left += Globais.LstTIntas_Coluna_StatusOperacao;
                cmdLSTColumn26.Left += Globais.LstTIntas_Coluna_StatusOperacao;

            }
            if (checkStatus.Checked == false)
            {
                lstTintas.Columns[14].Width = 0;
                lstTintasFinalizadas.Columns[14].Width = 0;
                cmdLSTColumn15.Width = 0;
                cmdLSTColumn16.Left -= Globais.LstTIntas_Coluna_StatusOperacao;
                cmdLSTColumn17.Left -= Globais.LstTIntas_Coluna_StatusOperacao;
                cmdLSTColumn18.Left -= Globais.LstTIntas_Coluna_StatusOperacao;
                cmdLSTColumn19.Left -= Globais.LstTIntas_Coluna_StatusOperacao;
                cmdLSTColumn20.Left -= Globais.LstTIntas_Coluna_StatusOperacao;
                cmdLSTColumn21.Left -= Globais.LstTIntas_Coluna_StatusOperacao;
                cmdLSTColumn22.Left -= Globais.LstTIntas_Coluna_StatusOperacao;
                cmdLSTColumn23.Left -= Globais.LstTIntas_Coluna_StatusOperacao;
                cmdLSTColumn24.Left -= Globais.LstTIntas_Coluna_StatusOperacao;
                cmdLSTColumn25.Left -= Globais.LstTIntas_Coluna_StatusOperacao;
                cmdLSTColumn26.Left -= Globais.LstTIntas_Coluna_StatusOperacao;
            }
        }

        private void checkInicio_CheckedChanged(object sender, EventArgs e)
        {
            if (checkInicio.Checked == true)
            {
                lstTintas.Columns[15].Width = Globais.LstTIntas_Coluna_Inicio;
                lstTintasFinalizadas.Columns[15].Width = Globais.LstTIntas_Coluna_Inicio;
                cmdLSTColumn16.Width = Globais.LstTIntas_Coluna_Inicio;
                cmdLSTColumn17.Left += Globais.LstTIntas_Coluna_Inicio;
                cmdLSTColumn18.Left += Globais.LstTIntas_Coluna_Inicio;
                cmdLSTColumn19.Left += Globais.LstTIntas_Coluna_Inicio;
                cmdLSTColumn20.Left += Globais.LstTIntas_Coluna_Inicio;
                cmdLSTColumn21.Left += Globais.LstTIntas_Coluna_Inicio;
                cmdLSTColumn22.Left += Globais.LstTIntas_Coluna_Inicio;
                cmdLSTColumn23.Left += Globais.LstTIntas_Coluna_Inicio;
                cmdLSTColumn24.Left += Globais.LstTIntas_Coluna_Inicio;
                cmdLSTColumn25.Left += Globais.LstTIntas_Coluna_Inicio;
                cmdLSTColumn26.Left += Globais.LstTIntas_Coluna_Inicio;
            }
            if (checkInicio.Checked == false)
            {
                lstTintas.Columns[15].Width = 0;
                lstTintasFinalizadas.Columns[15].Width = 0;
                cmdLSTColumn16.Width = 0;
                cmdLSTColumn17.Left -= Globais.LstTIntas_Coluna_Inicio;
                cmdLSTColumn18.Left -= Globais.LstTIntas_Coluna_Inicio;
                cmdLSTColumn19.Left -= Globais.LstTIntas_Coluna_Inicio;
                cmdLSTColumn20.Left -= Globais.LstTIntas_Coluna_Inicio;
                cmdLSTColumn21.Left -= Globais.LstTIntas_Coluna_Inicio;
                cmdLSTColumn22.Left -= Globais.LstTIntas_Coluna_Inicio;
                cmdLSTColumn23.Left -= Globais.LstTIntas_Coluna_Inicio;
                cmdLSTColumn24.Left -= Globais.LstTIntas_Coluna_Inicio;
                cmdLSTColumn25.Left -= Globais.LstTIntas_Coluna_Inicio;
                cmdLSTColumn26.Left -= Globais.LstTIntas_Coluna_Inicio;
            }
        }

        private void checkFim_CheckedChanged(object sender, EventArgs e)
        {
            if (checkFim.Checked == true)
            {
                lstTintas.Columns[16].Width = Globais.LstTIntas_Coluna_Fim;
                lstTintasFinalizadas.Columns[16].Width = Globais.LstTIntas_Coluna_Fim;
                cmdLSTColumn17.Width = Globais.LstTIntas_Coluna_Fim;
                cmdLSTColumn18.Left += Globais.LstTIntas_Coluna_Fim;
                cmdLSTColumn19.Left += Globais.LstTIntas_Coluna_Fim;
                cmdLSTColumn20.Left += Globais.LstTIntas_Coluna_Fim;
                cmdLSTColumn21.Left += Globais.LstTIntas_Coluna_Fim;
                cmdLSTColumn22.Left += Globais.LstTIntas_Coluna_Fim;
                cmdLSTColumn23.Left += Globais.LstTIntas_Coluna_Fim;
                cmdLSTColumn24.Left += Globais.LstTIntas_Coluna_Fim;
                cmdLSTColumn25.Left += Globais.LstTIntas_Coluna_Fim;
                cmdLSTColumn26.Left += Globais.LstTIntas_Coluna_Fim;
            }
            if (checkFim.Checked == false)
            {
                lstTintas.Columns[16].Width = 0;
                lstTintasFinalizadas.Columns[16].Width = 0;
                cmdLSTColumn17.Width = 0;
                cmdLSTColumn18.Left -= Globais.LstTIntas_Coluna_Fim;
                cmdLSTColumn19.Left -= Globais.LstTIntas_Coluna_Fim;
                cmdLSTColumn20.Left -= Globais.LstTIntas_Coluna_Fim;
                cmdLSTColumn21.Left -= Globais.LstTIntas_Coluna_Fim;
                cmdLSTColumn22.Left -= Globais.LstTIntas_Coluna_Fim;
                cmdLSTColumn23.Left -= Globais.LstTIntas_Coluna_Fim;
                cmdLSTColumn24.Left -= Globais.LstTIntas_Coluna_Fim;
                cmdLSTColumn25.Left -= Globais.LstTIntas_Coluna_Fim;
                cmdLSTColumn26.Left -= Globais.LstTIntas_Coluna_Fim;
            }
        }

        private void checkTempo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTempo.Checked == true)
            {
                lstTintas.Columns[17].Width = Globais.LstTIntas_Coluna_Tempo;
                lstTintasFinalizadas.Columns[17].Width = Globais.LstTIntas_Coluna_Tempo;
                cmdLSTColumn18.Width = Globais.LstTIntas_Coluna_Tempo;
                cmdLSTColumn19.Left += Globais.LstTIntas_Coluna_Tempo;
                cmdLSTColumn20.Left += Globais.LstTIntas_Coluna_Tempo;
                cmdLSTColumn21.Left += Globais.LstTIntas_Coluna_Tempo;
                cmdLSTColumn22.Left += Globais.LstTIntas_Coluna_Tempo;
                cmdLSTColumn23.Left += Globais.LstTIntas_Coluna_Tempo;
                cmdLSTColumn24.Left += Globais.LstTIntas_Coluna_Tempo;
                cmdLSTColumn25.Left += Globais.LstTIntas_Coluna_Tempo;
                cmdLSTColumn26.Left += Globais.LstTIntas_Coluna_Tempo;
            }
            if (checkTempo.Checked == false)
            {
                lstTintas.Columns[17].Width = 0;
                lstTintasFinalizadas.Columns[17].Width = 0;
                cmdLSTColumn18.Width = 0;
                cmdLSTColumn19.Left -= Globais.LstTIntas_Coluna_Tempo;
                cmdLSTColumn20.Left -= Globais.LstTIntas_Coluna_Tempo;
                cmdLSTColumn21.Left -= Globais.LstTIntas_Coluna_Tempo;
                cmdLSTColumn22.Left -= Globais.LstTIntas_Coluna_Tempo;
                cmdLSTColumn23.Left -= Globais.LstTIntas_Coluna_Tempo;
                cmdLSTColumn24.Left -= Globais.LstTIntas_Coluna_Tempo;
                cmdLSTColumn25.Left -= Globais.LstTIntas_Coluna_Tempo;
                cmdLSTColumn26.Left -= Globais.LstTIntas_Coluna_Tempo;
            }
        }

        private void checkEntrega_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEntrega.Checked == true)
            {
                lstTintas.Columns[18].Width = Globais.LstTIntas_Coluna_Entrega;
                lstTintasFinalizadas.Columns[18].Width = Globais.LstTIntas_Coluna_Entrega;
                cmdLSTColumn19.Width = Globais.LstTIntas_Coluna_Entrega;
                cmdLSTColumn20.Left += Globais.LstTIntas_Coluna_Entrega;
                cmdLSTColumn21.Left += Globais.LstTIntas_Coluna_Entrega;
                cmdLSTColumn22.Left += Globais.LstTIntas_Coluna_Entrega;
                cmdLSTColumn23.Left += Globais.LstTIntas_Coluna_Entrega;
                cmdLSTColumn24.Left += Globais.LstTIntas_Coluna_Entrega;
                cmdLSTColumn25.Left += Globais.LstTIntas_Coluna_Entrega;
                cmdLSTColumn26.Left += Globais.LstTIntas_Coluna_Entrega;
            }
            if (checkEntrega.Checked == false)
            {
                lstTintas.Columns[18].Width = 0;
                lstTintasFinalizadas.Columns[18].Width = 0;
                cmdLSTColumn19.Width = 0;
                cmdLSTColumn20.Left -= Globais.LstTIntas_Coluna_Entrega;
                cmdLSTColumn21.Left -= Globais.LstTIntas_Coluna_Entrega;
                cmdLSTColumn22.Left -= Globais.LstTIntas_Coluna_Entrega;
                cmdLSTColumn23.Left -= Globais.LstTIntas_Coluna_Entrega;
                cmdLSTColumn24.Left -= Globais.LstTIntas_Coluna_Entrega;
                cmdLSTColumn25.Left -= Globais.LstTIntas_Coluna_Entrega;
                cmdLSTColumn26.Left -= Globais.LstTIntas_Coluna_Entrega;
            }
        }

        private void checkDataFaturamento_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDataFaturamento.Checked == true)
            {
                lstTintas.Columns[21].Width = Globais.LstTIntas_Coluna_DataFaturamento;
                lstTintasFinalizadas.Columns[21].Width = Globais.LstTIntas_Coluna_DataFaturamento;
                cmdLSTColumn22.Width = Globais.LstTIntas_Coluna_DataFaturamento;
                cmdLSTColumn23.Left += Globais.LstTIntas_Coluna_DataFaturamento;
                cmdLSTColumn24.Left += Globais.LstTIntas_Coluna_DataFaturamento;
                cmdLSTColumn25.Left += Globais.LstTIntas_Coluna_DataFaturamento;
                cmdLSTColumn26.Left += Globais.LstTIntas_Coluna_DataFaturamento;
            }
            if (checkDataFaturamento.Checked == false)
            {
                lstTintas.Columns[21].Width = 0;
                lstTintasFinalizadas.Columns[21].Width = 0;
                cmdLSTColumn22.Width = 0;
                cmdLSTColumn23.Left -= Globais.LstTIntas_Coluna_DataFaturamento;
                cmdLSTColumn24.Left -= Globais.LstTIntas_Coluna_DataFaturamento;
                cmdLSTColumn25.Left -= Globais.LstTIntas_Coluna_DataFaturamento;
                cmdLSTColumn26.Left -= Globais.LstTIntas_Coluna_DataFaturamento;
            }
        }

        private void checkValorCusto_CheckedChanged(object sender, EventArgs e)
        {
            if (checkValorCusto.Checked == true)
            {
                lstTintas.Columns[22].Width = Globais.LstTIntas_Coluna_ValorCusto;
                lstTintasFinalizadas.Columns[22].Width = Globais.LstTIntas_Coluna_ValorCusto;
                cmdLSTColumn23.Width = Globais.LstTIntas_Coluna_ValorCusto;
                cmdLSTColumn24.Left += Globais.LstTIntas_Coluna_ValorCusto;
                cmdLSTColumn25.Left += Globais.LstTIntas_Coluna_ValorCusto;
                cmdLSTColumn26.Left += Globais.LstTIntas_Coluna_ValorCusto;
            }
            if (checkValorCusto.Checked == false)
            {
                lstTintas.Columns[22].Width = 0;
                lstTintasFinalizadas.Columns[22].Width = 0;
                cmdLSTColumn23.Width = 0;
                cmdLSTColumn24.Left -= Globais.LstTIntas_Coluna_ValorCusto;
                cmdLSTColumn25.Left -= Globais.LstTIntas_Coluna_ValorCusto;
                cmdLSTColumn26.Left -= Globais.LstTIntas_Coluna_ValorCusto;
            }
        }

        private void checkValorVenda_CheckedChanged(object sender, EventArgs e)
        {
            if (checkValorVenda.Checked == true)
            {
                lstTintas.Columns[23].Width = Globais.LstTIntas_Coluna_ValorVenda;
                lstTintasFinalizadas.Columns[23].Width = Globais.LstTIntas_Coluna_ValorVenda;
                cmdLSTColumn24.Width = Globais.LstTIntas_Coluna_ValorVenda;
                cmdLSTColumn25.Left += Globais.LstTIntas_Coluna_ValorVenda;
                cmdLSTColumn26.Left += Globais.LstTIntas_Coluna_ValorVenda;
            }
            if (checkValorVenda.Checked == false)
            {
                lstTintas.Columns[23].Width = 0;
                lstTintasFinalizadas.Columns[23].Width = 0;
                cmdLSTColumn24.Width = 0;
                cmdLSTColumn25.Left -= Globais.LstTIntas_Coluna_ValorVenda;
                cmdLSTColumn26.Left -= Globais.LstTIntas_Coluna_ValorVenda;
            }
        }

        private void checkMarkup_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMarkup.Checked == true)
            {
                lstTintas.Columns[24].Width = Globais.LstTIntas_Coluna_Markup;
                lstTintasFinalizadas.Columns[24].Width = Globais.LstTIntas_Coluna_Markup;
                cmdLSTColumn25.Width = Globais.LstTIntas_Coluna_Markup;
                cmdLSTColumn26.Left += Globais.LstTIntas_Coluna_Markup;

            }
            if (checkMarkup.Checked == false)
            {
                lstTintas.Columns[24].Width = 0;
                lstTintasFinalizadas.Columns[24].Width = 0;
                cmdLSTColumn25.Width = 0;
                cmdLSTColumn26.Left -= Globais.LstTIntas_Coluna_Markup;
            }
        }

        private void checkChapinhas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkChapinhas.Checked == true)
            {
                lstTintas.Columns[25].Width = Globais.LstTIntas_Coluna_Chapinhas;
                lstTintasFinalizadas.Columns[25].Width = Globais.LstTIntas_Coluna_Chapinhas;
                cmdLSTColumn26.Width = Globais.LstTIntas_Coluna_Chapinhas;

            }
            if (checkChapinhas.Checked == false)
            {
                lstTintas.Columns[25].Width = 0;
                lstTintasFinalizadas.Columns[25].Width = 0;
                cmdLSTColumn26.Width = 0;
            }
        }

        private void checkCor_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCor.Checked == true)
            {
                lstTintas.Columns[7].Width = Globais.LstTIntas_Coluna_Cor;
                lstTintasFinalizadas.Columns[7].Width = Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn8.Width = Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn9.Left += Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn10.Left += Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn11.Left += Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn12.Left += Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn13.Left += Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn14.Left += Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn15.Left += Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn16.Left += Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn17.Left += Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn18.Left += Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn19.Left += Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn20.Left += Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn21.Left += Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn22.Left += Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn23.Left += Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn24.Left += Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn25.Left += Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn26.Left += Globais.LstTIntas_Coluna_Cor;
            }
            if (checkCor.Checked == false)
            {
                lstTintas.Columns[7].Width = 0;
                lstTintasFinalizadas.Columns[7].Width = 0;
                cmdLSTColumn8.Width = 0;
                cmdLSTColumn9.Left -= Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn10.Left -= Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn11.Left -= Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn12.Left -= Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn13.Left -= Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn14.Left -= Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn15.Left -= Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn16.Left -= Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn17.Left -= Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn18.Left -= Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn19.Left -= Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn20.Left -= Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn21.Left -= Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn22.Left -= Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn23.Left -= Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn24.Left -= Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn25.Left -= Globais.LstTIntas_Coluna_Cor;
                cmdLSTColumn26.Left -= Globais.LstTIntas_Coluna_Cor;
            }
        }

        private void cmdLSTColumn1_Click(object sender, ColumnClickEventArgs e)
        {

            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lstTintas.Sort();
        }

        private void TimerAtualizaLST_Tick(object sender, EventArgs e)
        {
            if (lstTintas.CheckedItems.Count == 0 || lstTintas.SelectedItems.Count == 0)
            {
                AtualizaLSTOSAberta();
            }
        }

        private void cmdLSTColumn1_Click(object sender, EventArgs e)
        {
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            if (lvwColumnSorter2.Order == SortOrder.Ascending)
            {
                lvwColumnSorter2.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter2.Order = SortOrder.Ascending;
            }
            lvwColumnSorter.SortColumn = 0;
            lvwColumnSorter2.SortColumn = 0;
            lstTintas.Sort();
            lstTintasFinalizadas.Sort();
        }

        private void cmdLSTColumn2_Click(object sender, EventArgs e)
        {
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            if (lvwColumnSorter2.Order == SortOrder.Ascending)
            {
                lvwColumnSorter2.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter2.Order = SortOrder.Ascending;
            }
            lvwColumnSorter.SortColumn = 1;
            lvwColumnSorter2.SortColumn = 1;
            lstTintas.Sort();
            lstTintasFinalizadas.Sort();
        }

        private void cmdLSTColumn3_Click(object sender, EventArgs e)
        {
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            if (lvwColumnSorter2.Order == SortOrder.Ascending)
            {
                lvwColumnSorter2.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter2.Order = SortOrder.Ascending;
            }
            lvwColumnSorter.SortColumn = 2;
            lvwColumnSorter2.SortColumn = 2;
            lstTintas.Sort();
            lstTintasFinalizadas.Sort();
        }

        private void cmdLSTColumn4_Click(object sender, EventArgs e)
        {
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            if (lvwColumnSorter2.Order == SortOrder.Ascending)
            {
                lvwColumnSorter2.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter2.Order = SortOrder.Ascending;
            }
            lvwColumnSorter.SortColumn = 3;
            lvwColumnSorter2.SortColumn = 3;
            lstTintas.Sort();
            lstTintasFinalizadas.Sort();
        }

        private void cmdLSTColumn5_Click(object sender, EventArgs e)
        {
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            if (lvwColumnSorter2.Order == SortOrder.Ascending)
            {
                lvwColumnSorter2.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter2.Order = SortOrder.Ascending;
            }
            lvwColumnSorter.SortColumn = 4;
            lvwColumnSorter2.SortColumn = 4;
            lstTintas.Sort();
            lstTintasFinalizadas.Sort();
        }

        private void cmdLSTColumn6_Click(object sender, EventArgs e)
        {
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            if (lvwColumnSorter2.Order == SortOrder.Ascending)
            {
                lvwColumnSorter2.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter2.Order = SortOrder.Ascending;
            }
            lvwColumnSorter.SortColumn = 5;
            lvwColumnSorter2.SortColumn = 5;
            lstTintas.Sort();
            lstTintasFinalizadas.Sort();
        }

        private void cmdLSTColumn7_Click(object sender, EventArgs e)
        {
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            if (lvwColumnSorter2.Order == SortOrder.Ascending)
            {
                lvwColumnSorter2.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter2.Order = SortOrder.Ascending;
            }
            lvwColumnSorter.SortColumn = 6;
            lvwColumnSorter2.SortColumn = 6;
            lstTintas.Sort();
            lstTintasFinalizadas.Sort();
        }

        private void cmdLSTColumn8_Click(object sender, EventArgs e)
        {
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            if (lvwColumnSorter2.Order == SortOrder.Ascending)
            {
                lvwColumnSorter2.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter2.Order = SortOrder.Ascending;
            }
            lvwColumnSorter.SortColumn = 7;
            lvwColumnSorter2.SortColumn = 7;
            lstTintas.Sort();
            lstTintasFinalizadas.Sort();
        }

        private void cmdLSTColumn9_Click(object sender, EventArgs e)
        {
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            if (lvwColumnSorter2.Order == SortOrder.Ascending)
            {
                lvwColumnSorter2.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter2.Order = SortOrder.Ascending;
            }
            lvwColumnSorter.SortColumn = 8;
            lvwColumnSorter2.SortColumn = 8;
            lstTintas.Sort();
            lstTintasFinalizadas.Sort();
        }

        private void cmdLSTColumn10_Click(object sender, EventArgs e)
        {
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            if (lvwColumnSorter2.Order == SortOrder.Ascending)
            {
                lvwColumnSorter2.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter2.Order = SortOrder.Ascending;
            }
            lvwColumnSorter.SortColumn = 9;
            lvwColumnSorter2.SortColumn = 9;
            lstTintas.Sort();
            lstTintasFinalizadas.Sort();
        }

        private void cmdLSTColumn11_Click(object sender, EventArgs e)
        {
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            if (lvwColumnSorter2.Order == SortOrder.Ascending)
            {
                lvwColumnSorter2.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter2.Order = SortOrder.Ascending;
            }
            lvwColumnSorter.SortColumn = 10;
            lvwColumnSorter2.SortColumn = 10;
            lstTintas.Sort();
            lstTintasFinalizadas.Sort();
        }

        private void cmdLSTColumn12_Click(object sender, EventArgs e)
        {
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            if (lvwColumnSorter2.Order == SortOrder.Ascending)
            {
                lvwColumnSorter2.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter2.Order = SortOrder.Ascending;
            }
            lvwColumnSorter.SortColumn = 11;
            lvwColumnSorter2.SortColumn = 11;
            lstTintas.Sort();
            lstTintasFinalizadas.Sort();
        }

        private void cmdLSTColumn13_Click(object sender, EventArgs e)
        {
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            if (lvwColumnSorter2.Order == SortOrder.Ascending)
            {
                lvwColumnSorter2.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter2.Order = SortOrder.Ascending;
            }
            lvwColumnSorter.SortColumn = 12;
            lvwColumnSorter2.SortColumn = 12;
            lstTintas.Sort();
            lstTintasFinalizadas.Sort();
        }

        private void cmdLSTColumn14_Click(object sender, EventArgs e)
        {
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            if (lvwColumnSorter2.Order == SortOrder.Ascending)
            {
                lvwColumnSorter2.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter2.Order = SortOrder.Ascending;
            }
            lvwColumnSorter.SortColumn = 13;
            lvwColumnSorter2.SortColumn = 13;
            lstTintas.Sort();
            lstTintasFinalizadas.Sort();
        }

        private void cmdLSTColumn15_Click(object sender, EventArgs e)
        {
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            if (lvwColumnSorter2.Order == SortOrder.Ascending)
            {
                lvwColumnSorter2.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter2.Order = SortOrder.Ascending;
            }
            lvwColumnSorter.SortColumn = 14;
            lvwColumnSorter2.SortColumn = 14;
            lstTintas.Sort();
            lstTintasFinalizadas.Sort();
        }

        private void cmdLSTColumn16_Click(object sender, EventArgs e)
        {
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            if (lvwColumnSorter2.Order == SortOrder.Ascending)
            {
                lvwColumnSorter2.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter2.Order = SortOrder.Ascending;
            }
            lvwColumnSorter.SortColumn = 15;
            lvwColumnSorter2.SortColumn = 15;
            lstTintas.Sort();
            lstTintasFinalizadas.Sort();
        }

        private void cmdLSTColumn17_Click(object sender, EventArgs e)
        {
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            if (lvwColumnSorter2.Order == SortOrder.Ascending)
            {
                lvwColumnSorter2.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter2.Order = SortOrder.Ascending;
            }
            lvwColumnSorter.SortColumn = 16;
            lvwColumnSorter2.SortColumn = 16;
            lstTintas.Sort();
            lstTintasFinalizadas.Sort();
        }

        private void cmdLSTColumn18_Click(object sender, EventArgs e)
        {
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            if (lvwColumnSorter2.Order == SortOrder.Ascending)
            {
                lvwColumnSorter2.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter2.Order = SortOrder.Ascending;
            }
            lvwColumnSorter.SortColumn = 17;
            lvwColumnSorter2.SortColumn = 17;
            lstTintas.Sort();
            lstTintasFinalizadas.Sort();
        }

        private void cmdLSTColumn19_Click(object sender, EventArgs e)
        {
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            if (lvwColumnSorter2.Order == SortOrder.Ascending)
            {
                lvwColumnSorter2.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter2.Order = SortOrder.Ascending;
            }
            lvwColumnSorter.SortColumn = 18;
            lvwColumnSorter2.SortColumn = 18;
            lstTintas.Sort();
            lstTintasFinalizadas.Sort();
        }

        private void cmdLSTColumn20_Click(object sender, EventArgs e)
        {
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            if (lvwColumnSorter2.Order == SortOrder.Ascending)
            {
                lvwColumnSorter2.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter2.Order = SortOrder.Ascending;
            }
            lvwColumnSorter.SortColumn = 19;
            lvwColumnSorter2.SortColumn = 19;
            lstTintas.Sort();
            lstTintasFinalizadas.Sort();
        }

        private void cmdLSTColumn21_Click(object sender, EventArgs e)
        {
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            if (lvwColumnSorter2.Order == SortOrder.Ascending)
            {
                lvwColumnSorter2.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter2.Order = SortOrder.Ascending;
            }
            lvwColumnSorter.SortColumn = 20;
            lvwColumnSorter2.SortColumn = 20;
            lstTintas.Sort();
            lstTintasFinalizadas.Sort();
        }

        private void cmdLSTColumn22_Click(object sender, EventArgs e)
        {
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            if (lvwColumnSorter2.Order == SortOrder.Ascending)
            {
                lvwColumnSorter2.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter2.Order = SortOrder.Ascending;
            }
            lvwColumnSorter.SortColumn = 21;
            lvwColumnSorter2.SortColumn = 21;
            lstTintas.Sort();
            lstTintasFinalizadas.Sort();
        }

        private void cmdLSTColumn23_Click(object sender, EventArgs e)
        {
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            if (lvwColumnSorter2.Order == SortOrder.Ascending)
            {
                lvwColumnSorter2.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter2.Order = SortOrder.Ascending;
            }
            lvwColumnSorter.SortColumn = 22;
            lvwColumnSorter2.SortColumn = 22;
            lstTintas.Sort();
            lstTintasFinalizadas.Sort();
        }

        private void cmdLSTColumn24_Click(object sender, EventArgs e)
        {
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            if (lvwColumnSorter2.Order == SortOrder.Ascending)
            {
                lvwColumnSorter2.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter2.Order = SortOrder.Ascending;
            }
            lvwColumnSorter.SortColumn = 23;
            lvwColumnSorter2.SortColumn = 23;
            lstTintas.Sort();
            lstTintasFinalizadas.Sort();
        }

        private void cmdLSTColumn25_Click(object sender, EventArgs e)
        {
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            if (lvwColumnSorter2.Order == SortOrder.Ascending)
            {
                lvwColumnSorter2.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter2.Order = SortOrder.Ascending;
            }
            lvwColumnSorter.SortColumn = 24;
            lvwColumnSorter2.SortColumn = 24;
            lstTintas.Sort();
            lstTintasFinalizadas.Sort();
        }

        private void cmdLSTColumn26_Click(object sender, EventArgs e)
        {
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            if (lvwColumnSorter2.Order == SortOrder.Ascending)
            {
                lvwColumnSorter2.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter2.Order = SortOrder.Ascending;
            }
            lvwColumnSorter.SortColumn = 25;
            lvwColumnSorter2.SortColumn = 25;
            lstTintas.Sort();
            lstTintasFinalizadas.Sort();
        }

        private void cmdLSTColumn27_Click(object sender, EventArgs e)
        {
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            if (lvwColumnSorter2.Order == SortOrder.Ascending)
            {
                lvwColumnSorter2.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter2.Order = SortOrder.Ascending;
            }
            lvwColumnSorter.SortColumn = 26;
            lvwColumnSorter2.SortColumn = 26;
            lstTintas.Sort();
            lstTintasFinalizadas.Sort();
        }

        private void check_Multi_Selecao_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Multi_Selecao.Checked == true)
            {
                check_Multi_Selecao.Text = "HABILITADO";
                lstTintas.CheckBoxes = true;
                lstTintasFinalizadas.CheckBoxes = true;
            }
            if (check_Multi_Selecao.Checked == false)
            {
                check_Multi_Selecao.Text = "DESABILITADO";
                lstTintas.CheckBoxes = false;
                lstTintasFinalizadas.CheckBoxes = false;
            }
        }

        private void cmdReabrir_MouseEnter(object sender, EventArgs e)
        {
            Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Reabrir_Sobre.png");
            cmdReabrir.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
            cmdReabrir.BackgroundImage = BTN;
        }

        private void cmdReabrir_EnabledChanged(object sender, EventArgs e)
        {
            if (cmdReabrir.Enabled == false)
            {
                Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Reabrir_Desabilitado.png");
                cmdReabrir.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
                cmdReabrir.BackgroundImage = BTN;
            }
            else
            {
                Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Reabrir_Fora.png");
                cmdReabrir.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
                cmdReabrir.BackgroundImage = BTN;
            }
        }

        private void cmdReabrir_MouseLeave(object sender, EventArgs e)
        {
            Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Reabrir_Fora.png");
            cmdReabrir.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
            cmdReabrir.BackgroundImage = BTN;
        }

        private void cmdFaturar_MouseEnter(object sender, EventArgs e)
        {
            Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Faturar_Sobre.png");
            cmdFaturar.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
            cmdFaturar.BackgroundImage = BTN;
        }

        private void cmdFaturar_MouseLeave(object sender, EventArgs e)
        {
            Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Faturar_Fora.png");
            cmdFaturar.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
            cmdFaturar.BackgroundImage = BTN;
        }

        private void cmdFaturar_EnabledChanged(object sender, EventArgs e)
        {
            if (cmdFaturar.Enabled == false)
            {
                Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Faturar_Desabilitado.png");
                cmdFaturar.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
                cmdFaturar.BackgroundImage = BTN;
            }
            else
            {
                Image BTN = Image.FromFile(Application.StartupPath.ToString() + @"\BTN\BTN_Faturar_Fora.png");
                cmdFaturar.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
                cmdFaturar.BackgroundImage = BTN;
            }
        }

        private void txtRelogio_Click(object sender, EventArgs e)
        {
            cmdNew.Enabled = true;
            cmdEdit.Enabled = false;
            cmdExluir.Enabled = false;
            cmdIniciar.Enabled = false;
            cmdPausar.Enabled = false;
            cmdFinalizar.Enabled = false;
            cmdReabrir.Enabled = false;
            cmdFaturar.Enabled = false;
            txtPrioridade.Text = string.Empty;

            this.Painel_Opcoes.Width = 32;
            this.cmdClose_Options.Visible = false;
            this.cmdOpen_Options.Visible = true;

            panel2.Visible = false;
            btnExibirContador.Visible = true;
        }

        private void picSharp_Click(object sender, EventArgs e)
        {
            cmdNew.Enabled = true;
            cmdEdit.Enabled = false;
            cmdExluir.Enabled = false;
            cmdIniciar.Enabled = false;
            cmdPausar.Enabled = false;
            cmdFinalizar.Enabled = false;
            cmdReabrir.Enabled = false;
            cmdFaturar.Enabled = false;
            txtPrioridade.Text = string.Empty;

            this.Painel_Opcoes.Width = 32;
            this.cmdClose_Options.Visible = false;
            this.cmdOpen_Options.Visible = true;

            panel2.Visible = false;
            btnExibirContador.Visible = true;
        }

        private void cmdReabrir_Click(object sender, EventArgs e)
        {


            if (check_Multi_Selecao.Checked == true && lstTintasFinalizadas.CheckedItems.Count > 0)
            {

                List<Itens_Lista> Lista = new List<Itens_Lista>();

                for (int i = 0; i < lstTintasFinalizadas.Items.Count; i++)
                {
                    if (lstTintasFinalizadas.Items[i].Checked == true)
                    {
                        DialogResult Resultado = new DialogResult();
                        Form Messagebox = new frmMensagemPersonalizada("Questao", "Abertura de Item", "Deseja Reabrir Ordem de Serviço Nº " + lstTintasFinalizadas.Items[i].SubItems[0].Text + " ? A mesma encontra-se finalizada");

                        Resultado = Messagebox.ShowDialog();

                        if (Resultado == DialogResult.OK)
                        {
                            Lista.Add(new Itens_Lista()
                            {
                                NOS = lstTintasFinalizadas.Items[i].Text,
                                Previsao = DateTime.Parse(lstTintasFinalizadas.Items[i].SubItems[13].Text),
                            });
                        }
                    }
                }


                for (int S = 0; S < Lista.Count; S++)
                {
                    DateTime Previsao = Lista[S].Previsao;
                    string Previsao_prioridade = Previsao.ToString("yyyy/MM/dd HH:mm:ss");

                    OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
                    string comandoSQL = "";

                    comandoSQL = "UPDATE Agendamentos SET Status_Operacao='EM PRODUÇÃO', Existente='" + null + "', Prioridade='" + string.Concat('0', " ", Previsao_prioridade, " ", txtPrioridade.Text) + "' WHERE Código=" + int.Parse(Lista[S].NOS) + "";

                    OleDbCommand cmd = new OleDbCommand(comandoSQL, conn);

                    try
                    {
                        //abre a conexao
                        conn.Open();

                        //executa o comando e gera um datareader
                        cmd.ExecuteNonQuery();

                        conn.Close();

                    }

                    catch (OleDbException ex)
                    {
                        Form messagebox = new frmMensagemPersonalizada("Critico", "Erro", "Error: " + ex.Message);
                        messagebox.ShowDialog();
                    }


                    finally
                    {

                    }

                }
                AtualizaLSTOSAberta();
                carrega_LST_tintas();


            }

            if (check_Multi_Selecao.Checked == false)
            {
                DialogResult Resultado = new DialogResult();
                Form Messagebox = new frmMensagemPersonalizada("Questao", "Abertura de Item", "Deseja Reabrir Ordem de Serviço Nº " + lstTintasFinalizadas.FocusedItem.SubItems[0].Text + " ? A mesma encontra-se finalizada");

                Resultado = Messagebox.ShowDialog();

                if (Resultado == DialogResult.OK)
                {

                    string ID = lstTintasFinalizadas.FocusedItem.SubItems[0].Text;
                    string Prev = lstTintasFinalizadas.FocusedItem.SubItems[13].Text;
                    DateTime Previsao = DateTime.Parse(Prev);
                    string Previsao_prioridade = Previsao.ToString("yyyy/MM/dd HH:mm:ss");

                    OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
                    string comandoSQL = "";

                    comandoSQL = "UPDATE Agendamentos SET Status_Operacao='EM PRODUÇÃO', Existente='" + null + "', Prioridade='" + string.Concat('0', " ", Previsao_prioridade, " ", txtPrioridade.Text) + "' WHERE Código=" + int.Parse(ID) + "";

                    OleDbCommand cmd = new OleDbCommand(comandoSQL, conn);

                    try
                    {
                        //abre a conexao
                        conn.Open();

                        //executa o comando e gera um datareader
                        cmd.ExecuteNonQuery();

                        conn.Close();

                    }

                    catch (OleDbException ex)
                    {
                        Form messagebox2 = new frmMensagemPersonalizada("Critico", "Erro", "Error: " + ex.Message);
                        messagebox2.Show();
                    }


                    finally
                    {
                        AtualizaLSTOSAberta();
                        carrega_LST_tintas();
                    }
                }
            }
        }

        private void BW_PreencheOSExcel_DoWork(object sender, DoWorkEventArgs e)
        {
            Itens_Lista OS = e.Argument as Itens_Lista;

            Thread T2 = new Thread(() => Preenche_OS(OS.Status, OS.NOS, OS.TipoOS, OS.Cliente, OS.Veiculo, OS.Placa, OS.GrupoCores, OS.Cor, OS.Montadora, OS.Codigo, OS.Quantidade,
                 OS.TipoPintura, OS.CorpoProva, OS.Previsao));
            T2.Start();
        }


        public void Preenche_OS(string Status, string ID, string TipoOS, string Cliente, string Veiculo, string Placa, string GrupoCor, string Cor, string Montadora, string CodCor, string QNT, string SP, string corpoProva, DateTime Previsao)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                app.Visible = true;
                Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Open(Globais.ModeloOS);

                Microsoft.Office.Interop.Excel.Worksheet wsOrdemServico = wb.Worksheets[1];

                app.DisplayAlerts = false;

                wsOrdemServico.Unprotect("++060188jhonie");

                if (ID != string.Empty)
                {
                    wb.Unprotect("++060188jhonie");
                    wsOrdemServico.Range["F4:G4"].Value = ID;
                }
                if (TipoOS != string.Empty)
                {
                    wsOrdemServico.Range["F5:G5"].Value = TipoOS;
                }
                if (Veiculo != string.Empty)
                {
                    wsOrdemServico.Range["C6:G6"].Value = Veiculo;
                }
                if (Placa != string.Empty)
                {
                    wsOrdemServico.Range["C7:G7"].Value = Placa;
                }
                if (Cliente != string.Empty)
                {
                    wsOrdemServico.Range["C8:G8"].Value = Cliente;
                }
                if (GrupoCor != string.Empty)
                {
                    wsOrdemServico.Range["C9:G9"].Value = GrupoCor;
                }
                if (Cor != string.Empty)
                {
                    wsOrdemServico.Range["C10:G10"].Value = Cor;
                }
                if (Montadora != string.Empty)
                {
                    wsOrdemServico.Range["C11:G11"].Value = Montadora;
                }
                if (CodCor != string.Empty)
                {
                    wsOrdemServico.Range["C12:G12"].Value = CodCor;
                }
                if (SP != string.Empty)
                {
                    wsOrdemServico.Range["C13:G13"].Value = SP;
                }
                if (QNT != string.Empty)
                {
                    wsOrdemServico.Range["C14:D14"].Value = QNT;
                }
                if (corpoProva != string.Empty)
                {
                    wsOrdemServico.Range["C15:G15"].Value = corpoProva;
                }
                wsOrdemServico.Protect("++060188jhonie");
                wb.Application.Run("Colorista");
                wb.Application.Run("Salvar");
            }
            catch
            {
                Form msg = new frmMensagemPersonalizada("Critico", "Erro", "Erro ao preencher a Ordem de Servico Nº " + ID);
                return;
            }
        }

        public void IniciarOS(string Status, string ID, string TipoOS, string Cliente, string Veiculo, string Placa, string GrupoCor, string Cor, string Montadora, string CodCor, string QNT, string SP, string corpoProva, DateTime Previsao)
        {
            string _NovoStatus = "EM PRODUÇÃO";
            DateTime _Inicio = DateTime.Now;
            string _Tempo = "00:00:00";
            string Previsao_Prioridade = Previsao.ToString("yyyy/MM/dd hh:mm:ss");
            string _Status_Prioridade = "0";

            Prioridade_Cliente p = new Prioridade_Cliente();
            p.ObterPrioridade(Cliente);


            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);

            string comandoSQL = "UPDATE Agendamentos SET Status_Operacao='" + _NovoStatus.Replace("'", "''") + "', Inicio='" + _Inicio + "', Tempo='" + _Tempo + "', Existente='" + null + "', Prioridade='" + string.Concat(_Status_Prioridade, " ", Previsao_Prioridade, " ", p.Prioridade) + "' WHERE Código=" + int.Parse(ID) + "";

            //cria um comando oledb
            OleDbCommand cmd = new OleDbCommand(comandoSQL, conn);

            try
            {
                //abre a conexao
                conn.Open();

                //executa o comando e gera um datareader
                cmd.ExecuteNonQuery();

                Form messagebox = new frmMensagemPersonalizada("Alerta", "Ordem de Serviço Iniciada", "OS Nº " + ID + " - Processo de confecção de tinta iniciado!");
                messagebox.ShowDialog();

                conn.Close();

                Itens_Lista OS = new Itens_Lista();

                OS.Status = Status;
                OS.NOS = ID;
                OS.TipoOS = TipoOS;
                OS.Cliente = Cliente;
                OS.Veiculo = Veiculo;
                OS.Placa = Placa;
                OS.GrupoCores = GrupoCor;
                OS.Cor = Cor;
                OS.Montadora = Montadora;
                OS.Codigo = CodCor;
                OS.Quantidade = QNT;
                OS.TipoPintura = SP;
                OS.CorpoProva = corpoProva;
                OS.Previsao = Previsao;

                BW_PreencheOSExcel.RunWorkerAsync(OS);

            }

            catch (OleDbException ex)
            {
                Form messagebox2 = new frmMensagemPersonalizada("Critico", "Erro", "Error: " + ex.Message);
                messagebox2.ShowDialog();
            }

        }

        public void Obter_Prioridade()
        {
            Itens_Lista OS = new Itens_Lista();
            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            try
            {
                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();
                //define o tipo do comando como texto 
                cmd.CommandText = "Select * from Clientes WHERE Cliente like '" + OS.Cliente + "'";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                //inicia leitura do datareader
                while (dr.Read())
                {
                    Itens_Lista os = new Itens_Lista();
                    os.Prioridade = dr["Cod_Prioridade"].ToString();
                }
                //fecha o datareader
                dr.Close();

            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                MessageBox.Show("Ocorreu um erro durante a execução da instrução SQL." +
                        "Erro : " + ex.Message, "SQL");
            }
            finally
            {
                //fecha a conexao
                conn.Close();
            }
        }

        private void BW_PreencheOSExcel_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            AtualizaLSTOSAberta();
        }



        private void lstTintas_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (lstTintas.CheckedItems.Count > 0)
            {
                List<string> ListaStatus = new List<string>();

                for (int i = 0; i < lstTintas.Items.Count; i++)
                {
                    if (lstTintas.Items[i].Checked == true)
                    {
                        ListaStatus.Add(lstTintas.Items[i].SubItems[14].Text);
                    }
                }

                bool StatusAguardando = false;

                bool StatusPausado = false;

                bool StatusEmProducao = false;

                StatusAguardando = ListaStatus.TrueForAll(a => a == "AGUARDANDO");

                StatusPausado = ListaStatus.TrueForAll(p => p == "PAUSADO");

                StatusEmProducao = ListaStatus.TrueForAll(n => n == "EM PRODUÇÃO");


                if (e.Item.Checked)
                {
                    if (StatusPausado == true)
                    {
                        cmdIniciar.Enabled = true;
                        cmdPausar.Enabled = false;
                        cmdFinalizar.Enabled = false;
                        cmdEdit.Enabled = true;
                        cmdExluir.Enabled = true;
                        cmdNew.Enabled = false;
                        cmdReabrir.Enabled = false;
                        cmdFaturar.Enabled = false;
                        return;
                    }
                    if (StatusPausado == false)
                    {
                        cmdIniciar.Enabled = false;
                        cmdPausar.Enabled = false;
                        cmdFinalizar.Enabled = false;
                        cmdEdit.Enabled = false;
                        cmdExluir.Enabled = false;
                        cmdNew.Enabled = true;
                        cmdReabrir.Enabled = false;
                        cmdFaturar.Enabled = false;
                    }


                    if (StatusEmProducao == true)
                    {
                        cmdIniciar.Enabled = false;
                        cmdPausar.Enabled = true;
                        cmdFinalizar.Enabled = true;
                        cmdEdit.Enabled = false;
                        cmdExluir.Enabled = false;
                        cmdNew.Enabled = false;
                        cmdReabrir.Enabled = false;
                        cmdFaturar.Enabled = false;
                        return;
                    }
                    if (StatusEmProducao == false)
                    {
                        cmdIniciar.Enabled = false;
                        cmdPausar.Enabled = false;
                        cmdFinalizar.Enabled = false;
                        cmdEdit.Enabled = false;
                        cmdExluir.Enabled = false;
                        cmdNew.Enabled = true;
                        cmdReabrir.Enabled = false;
                        cmdFaturar.Enabled = false;
                    }

                    if (StatusAguardando == true)
                    {
                        cmdIniciar.Enabled = true;
                        cmdPausar.Enabled = false;
                        cmdFinalizar.Enabled = false;
                        cmdEdit.Enabled = true;
                        cmdExluir.Enabled = true;
                        cmdNew.Enabled = false;
                        cmdReabrir.Enabled = false;
                        cmdFaturar.Enabled = false;
                        return;
                    }
                    if (StatusAguardando == false)
                    {
                        cmdIniciar.Enabled = false;
                        cmdPausar.Enabled = false;
                        cmdFinalizar.Enabled = false;
                        cmdEdit.Enabled = false;
                        cmdExluir.Enabled = false;
                        cmdNew.Enabled = true;
                        cmdReabrir.Enabled = false;
                        cmdFaturar.Enabled = false;
                    }
                }
                if (e.Item.Checked == false)
                {
                    if (StatusPausado == true)
                    {
                        cmdIniciar.Enabled = true;
                        cmdPausar.Enabled = false;
                        cmdFinalizar.Enabled = false;
                        cmdEdit.Enabled = true;
                        cmdExluir.Enabled = true;
                        cmdNew.Enabled = false;
                        cmdReabrir.Enabled = false;
                        cmdFaturar.Enabled = false;
                        return;
                    }
                    if (StatusPausado == false)
                    {
                        cmdIniciar.Enabled = false;
                        cmdPausar.Enabled = false;
                        cmdFinalizar.Enabled = false;
                        cmdEdit.Enabled = false;
                        cmdExluir.Enabled = false;
                        cmdNew.Enabled = true;
                        cmdReabrir.Enabled = false;
                        cmdFaturar.Enabled = false;
                    }


                    if (StatusEmProducao == true)
                    {
                        cmdIniciar.Enabled = false;
                        cmdPausar.Enabled = true;
                        cmdFinalizar.Enabled = true;
                        cmdEdit.Enabled = false;
                        cmdExluir.Enabled = false;
                        cmdNew.Enabled = false;
                        cmdReabrir.Enabled = false;
                        cmdFaturar.Enabled = false;
                        return;
                    }
                    if (StatusEmProducao == false)
                    {
                        cmdIniciar.Enabled = false;
                        cmdPausar.Enabled = false;
                        cmdFinalizar.Enabled = false;
                        cmdEdit.Enabled = false;
                        cmdExluir.Enabled = false;
                        cmdNew.Enabled = true;
                        cmdReabrir.Enabled = false;
                        cmdFaturar.Enabled = false;
                    }

                    if (StatusAguardando == true)
                    {
                        cmdIniciar.Enabled = true;
                        cmdPausar.Enabled = false;
                        cmdFinalizar.Enabled = false;
                        cmdEdit.Enabled = true;
                        cmdExluir.Enabled = true;
                        cmdNew.Enabled = false;
                        cmdReabrir.Enabled = false;
                        cmdFaturar.Enabled = false;
                        return;
                    }
                    if (StatusAguardando == false)
                    {
                        cmdIniciar.Enabled = false;
                        cmdPausar.Enabled = false;
                        cmdFinalizar.Enabled = false;
                        cmdEdit.Enabled = false;
                        cmdExluir.Enabled = false;
                        cmdNew.Enabled = true;
                        cmdReabrir.Enabled = false;
                        cmdFaturar.Enabled = false;
                    }
                }
            }
            if (lstTintas.CheckedItems.Count == 0)
            {
                cmdIniciar.Enabled = false;
                cmdPausar.Enabled = false;
                cmdFinalizar.Enabled = false;
                cmdEdit.Enabled = false;
                cmdExluir.Enabled = false;
                cmdNew.Enabled = true;
                cmdReabrir.Enabled = false;
                cmdFaturar.Enabled = false;
            }


        }

        private void lstTintasFinalizadas_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (lstTintasFinalizadas.CheckedItems.Count > 0)
            {
                cmdNew.Enabled = true;
                cmdEdit.Enabled = false;
                cmdExluir.Enabled = false;
                cmdIniciar.Enabled = false;
                cmdPausar.Enabled = false;
                cmdFinalizar.Enabled = false;
                cmdFaturar.Enabled = true;
                cmdReabrir.Enabled = true;
                txtPrioridade.Text = string.Empty;
            }
            if (lstTintasFinalizadas.CheckedItems.Count == 0)
            {
                cmdIniciar.Enabled = false;
                cmdPausar.Enabled = false;
                cmdFinalizar.Enabled = false;
                cmdEdit.Enabled = false;
                cmdExluir.Enabled = false;
                cmdNew.Enabled = true;
                cmdReabrir.Enabled = false;
                cmdFaturar.Enabled = false;
            }
        }

        private void lstTintas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue.Equals(CheckState.Unchecked))
            {
                lstTintas.Items[e.Index].BackColor = Color.DarkGray;
                lstTintas.Items[e.Index].ForeColor = Color.White;
            }

            if (e.CurrentValue.Equals(CheckState.Checked))
            {
                if (lstTintas.Items[e.Index].SubItems[18].Text == "NO PRAZO")
                {
                    if (lstTintas.Items[e.Index].SubItems[14].Text == "EM PRODUÇÃO")
                    {
                        lstTintas.Items[e.Index].BackColor = System.Drawing.Color.White;
                        lstTintas.Items[e.Index].ForeColor = System.Drawing.Color.Green;
                        lstTintas.Items[e.Index].Font = new System.Drawing.Font("Calibri", 9, System.Drawing.FontStyle.Bold);
                    }

                    if (lstTintas.Items[e.Index].SubItems[14].Text == "AGUARDANDO")
                    {
                        if (lstTintas.Items[e.Index].SubItems[26].Text == "SIM")
                        {
                            lstTintas.Items[e.Index].ForeColor = System.Drawing.Color.Blue;
                            lstTintas.Items[e.Index].Font = new System.Drawing.Font("Calibri", 9, System.Drawing.FontStyle.Bold);
                        }
                        else
                        {
                            lstTintas.Items[e.Index].BackColor = System.Drawing.Color.White;
                            lstTintas.Items[e.Index].ForeColor = System.Drawing.Color.Black;
                            lstTintas.Items[e.Index].Font = new System.Drawing.Font("Calibri", 9);
                        }
                    }

                    if (lstTintas.Items[e.Index].SubItems[14].Text == "PAUSADO")
                    {
                        lstTintas.Items[e.Index].BackColor = System.Drawing.Color.White;
                        lstTintas.Items[e.Index].ForeColor = System.Drawing.Color.DarkOrange;
                        lstTintas.Items[e.Index].Font = new System.Drawing.Font("Calibri", 9, System.Drawing.FontStyle.Bold);
                    }
                }
                if (lstTintas.Items[e.Index].SubItems[18].Text == "ATRASADO")
                {
                    if (lstTintas.Items[e.Index].SubItems[14].Text == "EM PRODUÇÃO")
                    {
                        lstTintas.Items[e.Index].BackColor = System.Drawing.Color.Red;
                        lstTintas.Items[e.Index].ForeColor = System.Drawing.Color.White;
                        lstTintas.Items[e.Index].Font = new System.Drawing.Font("Calibri", 9, System.Drawing.FontStyle.Bold);
                    }
                    if (lstTintas.Items[e.Index].SubItems[14].Text == "AGUARDANDO")
                    {
                        lstTintas.Items[e.Index].BackColor = System.Drawing.Color.Red;
                        lstTintas.Items[e.Index].ForeColor = System.Drawing.Color.Black;
                        lstTintas.Items[e.Index].Font = new System.Drawing.Font("Calibri", 9, System.Drawing.FontStyle.Bold);
                    }
                    if (lstTintas.Items[e.Index].SubItems[14].Text == "PAUSADO")
                    {
                        lstTintas.Items[e.Index].BackColor = System.Drawing.Color.Red;
                        lstTintas.Items[e.Index].ForeColor = System.Drawing.Color.LightGray;
                        lstTintas.Items[e.Index].Font = new System.Drawing.Font("Calibri", 9, System.Drawing.FontStyle.Bold);
                    }
                }

            }
        }

        private void lstTintas_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (check_Multi_Selecao.Checked == true)
            {
                lstTintas.Items[e.ItemIndex].Selected = false;
                lstTintas.Items[e.ItemIndex].Focused = false;
            }
        }

        public string ConsultaCaminhoOSFaturada(string ID)
        {
            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);

            conn.Open();

            //cria um comando oledb
            OleDbCommand cmd = conn.CreateCommand();
            //define o tipo do comando como texto 
            cmd.CommandText = "Select * from Agendamentos where Códico=" + ID + "";

            //executa o comando e gera um datareader
            OleDbDataReader dr = cmd.ExecuteReader();

            string Caminho = "";

            //inicia leitura do datareader
            while (dr.Read())
            {
                Caminho = dr["CaminhoOS"].ToString();
            }
            return Caminho;
        }
        private void cmdFaturar_Click(object sender, EventArgs e)
        {
            DialogResult Resultado;
            string Faturado;


            if (check_Multi_Selecao.Checked == true && lstTintasFinalizadas.CheckedItems.Count > 1)
            {
                Form messagebox = new frmMensagemPersonalizada("Critico", "Ação não autorizada", "Não é possivel fazer multiplos faturamentos!");
                messagebox.ShowDialog();
            }
            if (check_Multi_Selecao.Checked == true && lstTintasFinalizadas.CheckedItems.Count == 1)
            {
                double Margem;
                double ValorSugerido;

                Itens_Lista OS = new Itens_Lista();

                for (int i = 0; i < lstTintasFinalizadas.Items.Count; i++)
                {
                    if (lstTintasFinalizadas.Items[i].Checked == true)
                    {
                        OS.NOS = lstTintasFinalizadas.Items[i].SubItems[0].Text;
                        OS.TipoOS = lstTintasFinalizadas.Items[i].SubItems[2].Text;
                        OS.Cliente = lstTintasFinalizadas.Items[i].SubItems[3].Text;
                        OS.Veiculo = lstTintasFinalizadas.Items[i].SubItems[4].Text;
                        OS.Placa = lstTintasFinalizadas.Items[i].SubItems[5].Text;
                        OS.Cor = lstTintasFinalizadas.Items[i].SubItems[7].Text;
                        OS.TipoPintura = lstTintasFinalizadas.Items[i].SubItems[11].Text;
                        OS.Quantidade = lstTintasFinalizadas.Items[i].SubItems[10].Text;
                        OS.ValorCusto = decimal.Parse(lstTintasFinalizadas.Items[i].SubItems[22].Text).ToString("N2");
                        if (lstTintasFinalizadas.Items[i].SubItems[23].Text != string.Empty)
                        {
                            OS.Markup = lstTintasFinalizadas.Items[i].SubItems[24].Text;

                            OS.ValorVenda = decimal.Parse(lstTintasFinalizadas.Items[i].SubItems[23].Text).ToString("N2");
                        }
                        Margem = 1 + (Globais.Margen_Sugerida / 100);
                        ValorSugerido = double.Parse(lstTintasFinalizadas.Items[i].SubItems[22].Text) * Margem;
                        OS.Valor_Sugerido = ValorSugerido.ToString();
                        OS.Existente = lstTintasFinalizadas.Items[i].SubItems[26].Text;
                        OS.Carga = lstTintasFinalizadas.Items[i].SubItems[27].Text;
                        OS.NumeroPedido = lstTintasFinalizadas.Items[i].SubItems[28].Text;
                        OS.GrupoCores = lstTintasFinalizadas.Items[i].SubItems[6].Text;
                    }
                }
                if (OS.Existente != "SIM" || OS.Existente == string.Empty)
                {
                    Form MSG = new frmMensagemPersonalizada("Questao", "Faturamento", "A OS Nº " + OS.NOS + " ja foi faturada, deseja fazer alguma alteração?");
                    Resultado = MSG.ShowDialog();


                    if (Resultado.Equals(DialogResult.OK))
                    {
                        frmSenha senha = new frmSenha(this,OS, "FATURAMENTO");
                        senha.Show();

                    }
                }
                if (OS.Existente.Equals("SIM"))
                {
                    frmNumeroPedido frm = new frmNumeroPedido(this, OS);
                    frm.Show();
                }
            }

            if (check_Multi_Selecao.Checked == false)
            {
                string ID = lstTintasFinalizadas.FocusedItem.SubItems[0].Text;
                double Margem;
                double ValorSugerido;
                Faturado = lstTintasFinalizadas.FocusedItem.SubItems[26].Text;


                if (Faturado != "SIM" || Faturado == string.Empty)
                {

                    Form MSG = new frmMensagemPersonalizada("Questao", "Faturamento", "A OS Nº " + ID + " ja foi faturada, deseja fazer alguma alteração?");
                    Resultado = MSG.ShowDialog();

                    if (Resultado == DialogResult.OK)
                    {
                        frmFaturamento frm = new frmFaturamento(this, "NOVO");

                        frm.lblNOS.Text = ID;
                        frm.lblCliente.Text = lstTintasFinalizadas.FocusedItem.SubItems[3].Text;
                        frm.lblVeiculo.Text = lstTintasFinalizadas.FocusedItem.SubItems[4].Text;
                        frm.lblPlaca.Text = lstTintasFinalizadas.FocusedItem.SubItems[5].Text;
                        frm.lblCor.Text = lstTintasFinalizadas.FocusedItem.SubItems[7].Text;
                        frm.lblSP.Text = lstTintasFinalizadas.FocusedItem.SubItems[11].Text;
                        frm.lblQuantidade.Text = lstTintasFinalizadas.FocusedItem.SubItems[10].Text + " mls";
                        frm.lblCusto.Text = decimal.Parse(lstTintasFinalizadas.FocusedItem.SubItems[22].Text).ToString("N2");
                        if (lstTintasFinalizadas.FocusedItem.SubItems[23].Text != string.Empty)
                        {
                            string Markup = lstTintasFinalizadas.FocusedItem.SubItems[24].Text;

                            frm.txtVenda.Text = decimal.Parse(lstTintasFinalizadas.FocusedItem.SubItems[23].Text).ToString("N2");
                            frm.lblMarkup.Text = Markup;
                        }

                        Margem = 1 + (Globais.Margen_Sugerida / 100);
                        ValorSugerido = double.Parse(lstTintasFinalizadas.FocusedItem.SubItems[22].Text) * Margem;
                        frm.lblSugerido.Text = ValorSugerido.ToString("N2");
                        frm.lblCarga.Text = lstTintasFinalizadas.FocusedItem.SubItems[27].Text;
                        frm.txtNPedido.Text = lstTintasFinalizadas.FocusedItem.SubItems[28].Text;

                        frm.ShowDialog();
                    }

                }
                if (Faturado == "SIM")
                {
                    Itens_Lista OS2 = new Itens_Lista();

                    OS2.NOS = lstTintasFinalizadas.FocusedItem.SubItems[0].Text;
                    OS2.TipoOS = lstTintasFinalizadas.FocusedItem.SubItems[2].Text;
                    OS2.Cliente = lstTintasFinalizadas.FocusedItem.SubItems[3].Text;
                    OS2.Veiculo = lstTintasFinalizadas.FocusedItem.SubItems[4].Text;
                    OS2.Placa = lstTintasFinalizadas.FocusedItem.SubItems[5].Text;
                    OS2.Cor = lstTintasFinalizadas.FocusedItem.SubItems[7].Text;
                    OS2.TipoPintura = lstTintasFinalizadas.FocusedItem.SubItems[11].Text;
                    OS2.Quantidade = lstTintasFinalizadas.FocusedItem.SubItems[10].Text;
                    OS2.ValorCusto = decimal.Parse(lstTintasFinalizadas.FocusedItem.SubItems[22].Text).ToString("N2");
                    if (lstTintasFinalizadas.FocusedItem.SubItems[23].Text != string.Empty)
                    {
                        OS2.Markup = lstTintasFinalizadas.FocusedItem.SubItems[24].Text;

                        OS2.ValorVenda = decimal.Parse(lstTintasFinalizadas.FocusedItem.SubItems[23].Text).ToString("N2");
                    }
                    Margem = 1 + (Globais.Margen_Sugerida / 100);
                    ValorSugerido = double.Parse(lstTintasFinalizadas.FocusedItem.SubItems[22].Text) * Margem;
                    OS2.Valor_Sugerido = ValorSugerido.ToString();
                    OS2.Existente = lstTintasFinalizadas.FocusedItem.SubItems[26].Text;
                    OS2.Carga = lstTintasFinalizadas.FocusedItem.SubItems[27].Text;
                    OS2.NumeroPedido = lstTintasFinalizadas.FocusedItem.SubItems[28].Text;
                    OS2.GrupoCores = lstTintasFinalizadas.FocusedItem.SubItems[6].Text;

                    frmNumeroPedido frm = new frmNumeroPedido(this, OS2);
                    frm.ShowDialog();
                }
            }
        }

        private void btnOcultarContador_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            btnExibirContador.Visible = true;
        }

        private void btnExibirContador_Click(object sender, EventArgs e)
        {
            this.Painel_Opcoes.Width = 32;
            this.cmdClose_Options.Visible = false;
            this.cmdOpen_Options.Visible = true;

            btnExibirContador.Visible = false;
            panel2.Visible = true;

            LST_Tintas.Tintas_Diarias();
            lblNTotal.Text = LST_Tintas.N_Totais.ToString();
            lblNAjustes.Text = LST_Tintas.N_Ajustes.ToString();
            lblNAjustesExternos.Text = LST_Tintas.N_AjustesExt.ToString();
            lblNRepesagens.Text = LST_Tintas.N_Repesagens.ToString();

            LST_Tintas.Tintas_Mensais();
            lblTotalM.Text = LST_Tintas.N_Totais_Mensal.ToString();
            lblAjustesM.Text = LST_Tintas.N_Ajustes_Mensal.ToString();
            lblAjustesExtM.Text = LST_Tintas.N_AjustesExt_Mensal.ToString();
            lblRepesagensM.Text = LST_Tintas.N_Repesagens_Mensal.ToString();

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            btnExibirContador.Visible = true;
        }

        private void lstTintas_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            btnExibirContador.Visible = true;
        }

        private void lstTintasFinalizadas_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            btnExibirContador.Visible = true;
        }

        private void Painel_Opcoes_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            btnExibirContador.Visible = true;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                return;
            }
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        bool mouseDown;
        Point lastLocation;

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
            }



        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void lblTitulo_MouseDown(object sender, MouseEventArgs e)
        {

            mouseDown = true;
            lastLocation = e.Location;
        }

        private void lblTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
            }
        }

        private void lblTitulo_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void pictureBox3_DoubleClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                return;
            }
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                return;
            }
        }

        private void lstTintasFinalizadas_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (check_Multi_Selecao.Checked == true)
            {
                lstTintasFinalizadas.Items[e.ItemIndex].Selected = false;
                lstTintasFinalizadas.Items[e.ItemIndex].Focused = false;
            }
        }

        private void lstTintasFinalizadas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue.Equals(CheckState.Unchecked))
            {
                lstTintasFinalizadas.Items[e.Index].BackColor = Color.DarkGray;
                lstTintasFinalizadas.Items[e.Index].ForeColor = Color.White;
            }

            if (e.CurrentValue.Equals(CheckState.Checked))
            {
                foreach (ListViewItem Item2 in lstTintasFinalizadas.Items)
                {
                    if (Item2.SubItems[26].Text == "SIM")
                    {
                        Item2.ForeColor = Color.Green;
                        Item2.BackColor = Color.White;
                    }
                    else
                    {
                        Item2.ForeColor = Color.Black;
                        Item2.BackColor = Color.White;
                    }
                }
            }
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes clientes = new frmClientes();
            clientes.Show();
        }

        private void configuraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfig config = new frmConfig();
            config.Show();
        }

        private void entregasPrazoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "Sharp_Color_Tool.rlt_TintasEntregues.rdlc";
            string TIPO = "DATAS";

            frmFiltroDatas Relatorios = new frmFiltroDatas(path, TIPO);
            Relatorios.Width = 325;
            Relatorios.Show();
        }

        private void volumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "Sharp_Color_Tool.rlt_VolumeMensal.rdlc";
            string TIPO = "DATAS";

            frmFiltroDatas Relatorio = new frmFiltroDatas(path, TIPO);
            Relatorio.Width = 325;
            Relatorio.Show();
        }

        private void EntregasClientetoolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "Sharp_Color_Tool.rlt_TintasEntregues.rdlc";
            string TIPO = "DATAS-CLIENTE";

            frmFiltroDatas Relatorios = new frmFiltroDatas(path, TIPO);
            Relatorios.Width = 525;
            Relatorios.Show();
        }

        private void volumePorClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "Sharp_Color_Tool.rlt_VolumeMensal.rdlc";
            string TIPO = "DATAS-CLIENTE";

            frmFiltroDatas Relatorio = new frmFiltroDatas(path, TIPO);
            Relatorio.Width = 525;
            Relatorio.Show();
        }

        private void volumeComCustoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "Sharp_Color_Tool.rlt_VolumeMensalCusto.rdlc";
            string TIPO = "DATAS";

            frmFiltroDatas Relatorio = new frmFiltroDatas(path, TIPO);
            Relatorio.Width = 325;
            Relatorio.Show();
        }
    }
}

