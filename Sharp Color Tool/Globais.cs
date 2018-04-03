using System;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                }
            }
            finally
            {
                //fecha a conexao
                conn.Close();
            }
        }
    }
}
