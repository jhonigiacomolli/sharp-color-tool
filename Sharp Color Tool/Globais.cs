using System;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Sharp_Color_Tool
{
    class Globais
    {
        public static decimal Default_Heigth = 900; //Define a Altura na resolução onde foi criado
        public static decimal Default_Width = 1600; //Define a Largura na resolução onde foi criado

        public static decimal Atual_Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
        public static decimal Atual_Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;

        public static decimal Fator_Altura =Atual_Height / Default_Heigth;
        public static decimal Fator_Largura =Atual_Width / Default_Width;

        public static Int32 Altura_Botoes =Convert.ToInt32(45 * Fator_Altura);
        public static Int32 Largura_Botoes = Convert.ToInt32(80 * Fator_Largura);
        public static string ModeloOS = "";
        public static string PastaBackupOS = "";
        public static string TempoRepesagemAuto = "";
        public static string Numero_OSFim = "";

        public static Int32 LstTIntas_Coluna_NumeroOS =0;
        public static Int32 LstTIntas_Coluna_DataCadastro = 0;
        public static Int32 LstTIntas_Coluna_TipoOS = 0;
        public static Int32 LstTIntas_Coluna_Cliente = 0;
        public static Int32 LstTIntas_Coluna_Veiculo = 0;
        public static Int32 LstTIntas_Coluna_Placa = 0;
        public static Int32 LstTIntas_Coluna_GrupoCores = 0;
        public static Int32 LstTIntas_Coluna_Montadora = 0;
        public static Int32 LstTIntas_Coluna_CodigoCor = 0;
        public static Int32 LstTIntas_Coluna_Quantidade = 0;
        public static Int32 LstTIntas_Coluna_Pintura = 0;
        public static Int32 LstTIntas_Coluna_Colorista = 0;
        public static Int32 LstTIntas_Coluna_Cor = 0;
        public static Int32 LstTIntas_Coluna_CorpoProva = 0;
        public static Int32 LstTIntas_Coluna_Prioridade = 0;
        public static Int32 LstTIntas_Coluna_StatusOperacao = 0;
        public static Int32 LstTIntas_Coluna_Inicio = 0;
        public static Int32 LstTIntas_Coluna_Fim = 0;
        public static Int32 LstTIntas_Coluna_Tempo = 0;
        public static Int32 LstTIntas_Coluna_Entrega = 0;
        public static Int32 LstTIntas_Coluna_DataFaturamento = 0;
        public static Int32 LstTIntas_Coluna_ValorCusto = 0;
        public static Int32 LstTIntas_Coluna_ValorVenda = 0;
        public static Int32 LstTIntas_Coluna_Markup = 0;
        public static Int32 LstTIntas_Coluna_Chapinhas = 0;
        public static Int32 LstTIntas_Coluna_Previsao = 0;
        public static double Margen_Sugerida;
        public static Int32 ZoomRelatorio;


        public static void Config()
        {
            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            try
            {
                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();
                //define o tipo do comando como texto 
                cmd.CommandText = "Select * from Config";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                //inicia leitura do datareader
                while (dr.Read())
                {
                    ModeloOS=dr["Endereco_OSModelo"].ToString();
                    PastaBackupOS = dr["Pasta_BackupOS"].ToString();
                    TempoRepesagemAuto = dr["Tempo_Repesagem"].ToString();
                    Numero_OSFim = dr["Numero_OSFim"].ToString();

                    LstTIntas_Coluna_NumeroOS =Convert.ToInt32(dr["LstTIntas_Coluna_NumeroOS"].ToString());
                    LstTIntas_Coluna_DataCadastro = Convert.ToInt32(dr["LstTIntas_Coluna_DataCadastro"].ToString());
                    LstTIntas_Coluna_TipoOS = Convert.ToInt32(dr["LstTIntas_Coluna_TipoOS"].ToString());
                    LstTIntas_Coluna_Cliente = Convert.ToInt32(dr["LstTIntas_Coluna_Cliente"].ToString());
                    LstTIntas_Coluna_Veiculo = Convert.ToInt32(dr["LstTIntas_Coluna_Veiculo"].ToString());
                    LstTIntas_Coluna_Placa = Convert.ToInt32(dr["LstTIntas_Coluna_Placa"].ToString());
                    LstTIntas_Coluna_GrupoCores = Convert.ToInt32(dr["LstTIntas_Coluna_GrupoCores"].ToString());
                    LstTIntas_Coluna_Montadora = Convert.ToInt32(dr["LstTIntas_Coluna_Montadora"].ToString());
                    LstTIntas_Coluna_CodigoCor = Convert.ToInt32(dr["LstTIntas_Coluna_CodigoCor"].ToString());
                    LstTIntas_Coluna_Quantidade = Convert.ToInt32(dr["LstTIntas_Coluna_Quantidade"].ToString());
                    LstTIntas_Coluna_Pintura = Convert.ToInt32(dr["LstTIntas_Coluna_Pintura"].ToString());
                    LstTIntas_Coluna_Colorista = Convert.ToInt32(dr["LstTIntas_Coluna_Colorista"].ToString());
                    LstTIntas_Coluna_Cor = Convert.ToInt32(dr["LstTIntas_Coluna_Cor"].ToString());
                    LstTIntas_Coluna_CorpoProva = Convert.ToInt32(dr["LstTIntas_Coluna_CorpoProva"].ToString());
                    LstTIntas_Coluna_Prioridade = Convert.ToInt32(dr["LstTIntas_Coluna_Prioridade"].ToString());
                    LstTIntas_Coluna_StatusOperacao = Convert.ToInt32(dr["LstTIntas_Coluna_StatusOperacao"].ToString());
                    LstTIntas_Coluna_Inicio = Convert.ToInt32(dr["LstTIntas_Coluna_Inicio"].ToString());
                    LstTIntas_Coluna_Fim = Convert.ToInt32(dr["LstTIntas_Coluna_Fim"].ToString());
                    LstTIntas_Coluna_Tempo = Convert.ToInt32(dr["LstTIntas_Coluna_Tempo"].ToString());
                    LstTIntas_Coluna_Entrega = Convert.ToInt32(dr["LstTIntas_Coluna_Entrega"].ToString());
                    LstTIntas_Coluna_DataFaturamento = Convert.ToInt32(dr["LstTIntas_Coluna_DataFaturamento"].ToString());
                    LstTIntas_Coluna_ValorCusto = Convert.ToInt32(dr["LstTIntas_Coluna_ValorCusto"].ToString());
                    LstTIntas_Coluna_ValorVenda = Convert.ToInt32(dr["LstTIntas_Coluna_ValorVenda"].ToString());
                    LstTIntas_Coluna_Markup = Convert.ToInt32(dr["LstTIntas_Coluna_Markup"].ToString());
                    LstTIntas_Coluna_Chapinhas = Convert.ToInt32(dr["LstTIntas_Coluna_Chapinhas"].ToString());
                    LstTIntas_Coluna_Previsao = Convert.ToInt32(dr["LstTIntas_Coluna_Previsao"].ToString());
                    Margen_Sugerida= Convert.ToDouble(dr["Margem_Sugerida"].ToString());
                    ZoomRelatorio = Convert.ToInt32(dr["ZoomRelatorio"].ToString());
                }
            }
            finally
            {
                //fecha a conexao
                conn.Close();
            }
        }

        public void Preenche_PainelConfig(frmConfig configuracoes)
        {
            configuracoes.txtCaminhoModelo.Text = ModeloOS;
            configuracoes.txtCaminhoBackup.Text = PastaBackupOS;
            configuracoes.txtTempoRepesagem.Value =int.Parse(TempoRepesagemAuto);
            configuracoes.txtNumeroOSFim.Text = Numero_OSFim;
            configuracoes.txtMargemSugerida.Value =(Int32)Margen_Sugerida;
            configuracoes.txtCL_NOS.Value =LstTIntas_Coluna_NumeroOS;
            configuracoes.txtCL_DataCadastro.Value = LstTIntas_Coluna_DataCadastro;
            configuracoes.txtCL_TipoOS.Value = LstTIntas_Coluna_TipoOS;
            configuracoes.txtCL_Cliente.Value = LstTIntas_Coluna_Cliente;
            configuracoes.txtCL_Veiculo.Value = LstTIntas_Coluna_Veiculo;
            configuracoes.txtCL_Placa.Value = LstTIntas_Coluna_Placa;
            configuracoes.txtCL_GrupoCores.Value = LstTIntas_Coluna_GrupoCores;
            configuracoes.txtCL_Montadora.Value = LstTIntas_Coluna_Montadora;
            configuracoes.txtCL_CodigoCor.Value = LstTIntas_Coluna_CodigoCor;
            configuracoes.txtCL_Quantidade.Value = LstTIntas_Coluna_Quantidade;
            configuracoes.txtCL_SP.Value = LstTIntas_Coluna_Pintura;
            configuracoes.txtCL_Colorista.Value = LstTIntas_Coluna_Colorista;
            configuracoes.txtCL_Cor.Value = LstTIntas_Coluna_Cor;
            configuracoes.txtCL_CorpoProva.Value = LstTIntas_Coluna_CorpoProva;
            configuracoes.txtCL_Prioridade.Value = LstTIntas_Coluna_Prioridade;
            configuracoes.txtCL_Status.Value = LstTIntas_Coluna_StatusOperacao;
            configuracoes.txtCL_Inicio.Value = LstTIntas_Coluna_Inicio;
            configuracoes.txtCL_Fim.Value = LstTIntas_Coluna_Fim;
            configuracoes.txtCL_Tempo.Value = LstTIntas_Coluna_Tempo;
            configuracoes.txtCL_Entrega.Value = LstTIntas_Coluna_Entrega;
            configuracoes.txtCL_DataFaturamento.Value = LstTIntas_Coluna_DataFaturamento;
            configuracoes.txtCL_ValorCusto.Value = LstTIntas_Coluna_ValorCusto;
            configuracoes.txtCL_ValorVenda.Value = LstTIntas_Coluna_ValorVenda;
            configuracoes.txtCL_Markup.Value = LstTIntas_Coluna_Markup;
            configuracoes.txtCL_Chapinhas.Value = LstTIntas_Coluna_Chapinhas;
            configuracoes.txtCL_Previsao.Value = LstTIntas_Coluna_Previsao;
            configuracoes.txtZoomRelatorio.Value = ZoomRelatorio;
        }

        public void Atualizar_Configuracoes(string EnderecoOS,string Backup, int TempoRepesagem, int NumeroOSFim, int CL_Nos,int CL_DataCadastro,int CL_TipoOS,int CL_Cliente, int CL_Veiculo,int CL_Placa,int CL_GrupoCores, int CL_Montadora, int CL_COdCOr, int CL_Qnt, int CL_SP, int CL_Colorista,int CL_Cor, int CL_CorpoProva, int CL_Prioridade, int CL_Status, int CL_Inicio, int CL_Fim, int CL_Tempo, int CL_Entrega, int CL_DataFat, int CL_ValorCusto, int CL_ValorVenda, int CL_MArkup, int CL_Chapinhas, int CL_Previsao, int MargemSugerida, int ZoomRelatorio)
        {
            int ID = 1;

            try
            {                
                OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();

                //define o tipo do comando como texto 
                cmd.CommandText = "UPDATE Config SET Endereco_OSModelo='" + ModeloOS.Replace("'", "''") + "', Pasta_BackupOS='" + Backup + "', Tempo_Repesagem='" + TempoRepesagem + "', Numero_OSFim='" + NumeroOSFim + "', LstTIntas_Coluna_NumeroOS='" + CL_Nos + "', LstTIntas_Coluna_DataCadastro='" + CL_DataCadastro + "', LstTIntas_Coluna_TipoOS='" + CL_TipoOS + "', LstTIntas_Coluna_Cliente='" + CL_Cliente + "', LstTIntas_Coluna_Veiculo='" + CL_Veiculo + "', LstTIntas_Coluna_Placa='" + CL_Placa + "', LstTIntas_Coluna_GrupoCores='" + CL_GrupoCores + "', LstTIntas_Coluna_Montadora='" + CL_Montadora + "', LstTIntas_Coluna_CodigoCor='" + CL_COdCOr + "', LstTIntas_Coluna_Quantidade='" + CL_Qnt + "', LstTIntas_Coluna_Pintura='" + CL_SP + "', LstTIntas_Coluna_Colorista='" + CL_Colorista + "', LstTIntas_Coluna_Cor='" + CL_Cor + "', LstTIntas_Coluna_CorpoProva='" + CL_CorpoProva + "', LstTIntas_Coluna_Prioridade='" + CL_Prioridade + "', LstTIntas_Coluna_StatusOperacao='" + CL_Status + "', LstTIntas_Coluna_Inicio='" + CL_Inicio + "', LstTIntas_Coluna_Fim='" + CL_Fim + "', LstTIntas_Coluna_Tempo='" + CL_Tempo + "', LstTIntas_Coluna_Entrega='" + CL_Entrega + "', LstTIntas_Coluna_DataFaturamento='" + CL_DataFat + "', LstTIntas_Coluna_ValorCusto='" + CL_ValorCusto + "', LstTIntas_Coluna_ValorVenda='" + CL_ValorVenda + "', LstTIntas_Coluna_Markup='" + CL_MArkup + "', LstTIntas_Coluna_Chapinhas='" + CL_Chapinhas + "', LstTIntas_Coluna_Previsao='" + CL_Previsao + "', Margem_Sugerida='" + MargemSugerida + "', ZoomRelatorio='" + ZoomRelatorio + "' WHERE Código=" + ID + "";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                dr.Close();
                conn.Close();

                Form messagebox = new frmMensagemPersonalizada("Alerta", "Erro", "Configurações alteradas com sucesso!");
                messagebox.ShowDialog();
            }
            catch (OleDbException ex)
            {
                Form messagebox = new frmMensagemPersonalizada("Critico", "Erro", "Error: " + ex.Message);
                messagebox.ShowDialog();
            }
        }


    }
}
