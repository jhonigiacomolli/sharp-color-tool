using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Sharp_Color_Tool
{
    class Sugestao_Cliente
    {
        public string Sugestao_Valor(string Cliente, string Cor, string SP)
        {
            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            conn.Open();


            string VALOR = "";

            try
            {
                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();

                //define o tipo do comando como texto 
                cmd.CommandText = "Select * from Sugestao where Cliente like '" + Cliente + "'";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();
               
                
                //inicia leitura do datareader
                while (dr.Read())
                {
                    //Sugestão Valores BRANCO PU
                    if (Cor.Equals("BRANCO") && SP.Equals("ACS EVOLUTION® PU"))
                    {
                        VALOR = dr["BrancoLisoPU"].ToString();
                    }
                    if (Cor.Equals("BRANCO") && SP.Equals("CPU BASECOAT® POLIURETANO"))
                    {
                        VALOR = dr["BrancoLisoPU"].ToString();
                    }
                    if (Cor.Equals("BRANCO") && SP.Equals("DELFLEET® PU 280"))
                    {
                        VALOR = dr["BrancoLisoPU"].ToString();
                    }
                    if (Cor.Equals("BRANCO") && SP.Equals("DELFLEET® PU 290"))
                    {
                        VALOR = dr["BrancoLisoPU"].ToString();
                    }
                    if (Cor.Equals("BRANCO") && SP.Equals("DELFLEET® PU 350"))
                    {
                        VALOR = dr["BrancoLisoPU"].ToString();
                    }
                    if (Cor.Equals("BRANCO") && SP.Equals("DELFLEET® PU FOSCO"))
                    {
                        VALOR = dr["BrancoLisoPU"].ToString();
                    }
                    if (Cor.Equals("BRANCO") && SP.Equals("DELFLEET® PU SEMI-BRILHO"))
                    {
                        VALOR = dr["BrancoLisoPU"].ToString();
                    }
                    if (Cor.Equals("BRANCO") && SP.Equals("DELTRON® DG"))
                    {
                        VALOR = dr["BrancoLisoPU"].ToString();
                    }
                    if (Cor.Equals("BRANCO") && SP.Equals("INDUSTRAN® PU"))
                    {
                        VALOR = dr["BrancoLisoPU"].ToString();
                    }
                    if (Cor.Equals("BRANCO") && SP.Equals("INDUSTRAN® PU FOSCO"))
                    {
                        VALOR = dr["BrancoLisoPU"].ToString();
                    }

                    //Sugestão de Valores BRANCO POLIESTER
                    if (Cor.Equals("BRANCO") && SP.Equals("ACS EVOLUTION® POLIÉSTER"))
                    {
                        VALOR = dr["BrancoLisoPoliester"].ToString();
                    }
                    if (Cor.Equals("BRANCO") && SP.Equals("CPP BASECOAT® POLIÉSTER"))
                    {
                        VALOR = dr["BrancoLisoPoliester"].ToString();
                    }
                    if (Cor.Equals("BRANCO") && SP.Equals("DULON® POLIÉSTER"))
                    {
                        VALOR = dr["BrancoLisoPoliester"].ToString();
                    }

                    //Sugestão de Valores BRANCO TRICOAT BASE
                    if (Cor.Equals("BRANCO") && SP.Equals("DELTRON® TRICAOT (BASE)"))
                    {
                        VALOR = dr["BrancoTricoatBase"].ToString();
                    }

                    //Sugestão de Valores BRANCO TRICOAT EFEITO
                    if (Cor.Equals("BRANCO") && SP.Equals("DELTRON® TRICAOT (EFEITO)"))
                    {
                        VALOR = dr["BrancoTricoatEfeito"].ToString();
                    }

                    //Sugestão de Valores PRETO LISO PU
                    if (Cor.Equals("PRETO") && SP.Equals("ACS EVOLUTION® PU"))
                    {
                        VALOR = dr["PretoLisoPU"].ToString();
                    }
                    if (Cor.Equals("PRETO") && SP.Equals("CPU BASECOAT® POLIURETANO"))
                    {
                        VALOR = dr["PretoLisoPU"].ToString();
                    }
                    if (Cor.Equals("PRETO") && SP.Equals("DELFLEET® PU 280"))
                    {
                        VALOR = dr["PretoLisoPU"].ToString();
                    }
                    if (Cor.Equals("PRETO") && SP.Equals("DELFLEET® PU 290"))
                    {
                        VALOR = dr["PretoLisoPU"].ToString();
                    }
                    if (Cor.Equals("PRETO") && SP.Equals("DELFLEET® PU 350"))
                    {
                        VALOR = dr["PretoLisoPU"].ToString();
                    }
                    if (Cor.Equals("PRETO") && SP.Equals("Delfleet® PU FOSCO"))
                    {
                        VALOR = dr["PretoLisoPU"].ToString();
                    }
                    if (Cor.Equals("PRETO") && SP.Equals("DELFLEET® PU SEMI-BRILHO"))
                    {
                        VALOR = dr["PretoLisoPU"].ToString();
                    }
                    if (Cor.Equals("PRETO") && SP.Equals("DELTRON® DG"))
                    {
                        VALOR = dr["PretoLisoPU"].ToString();
                    }
                    if (Cor.Equals("PRETO") && SP.Equals("INDUSTRAN® PU"))
                    {
                        VALOR = dr["PretoLisoPU"].ToString();
                    }
                    if (Cor.Equals("PRETO") && SP.Equals("INDUSTRAN® PU Fosco"))
                    {
                        VALOR = dr["PretoLisoPU"].ToString();
                    }

                    //Sugestão de Valores PRETO POLIESTER
                    if (Cor.Equals("PRETO") && SP.Equals("ACS EVOLUTION® POLIÉSTER"))
                    {
                        VALOR = dr["PretoLisoPoliester"].ToString();
                    }
                    if (Cor.Equals("PRETO") && SP.Equals("CPP Basecoat® POLIÉSTER"))
                    {
                        VALOR = dr["PretoLisoPoliester"].ToString();
                    }
                    if (Cor.Equals("PRETO") && SP.Equals("DULON® POLIÉSTER"))
                    {
                        VALOR = dr["PretoLisoPoliester"].ToString();
                    }

                    //Sugestão de Valores PRETO PEROLIZADO
                    if (Cor.Equals("PRETO PEROLIZADO") && SP.Equals("ACS EVOLUTION® POLIÉSTER"))
                    {
                        VALOR = dr["PretoPerolizado"].ToString();
                    }
                    if (Cor.Equals("PRETO PEROLIZADO") && SP.Equals("CPP BASECOAT® POLIÉSTER"))
                    {
                        VALOR = dr["PretoPerolizado"].ToString();
                    }
                    if (Cor.Equals("PRETO PEROLIZADO") && SP.Equals("DULON® POLIÉSTER"))
                    {
                        VALOR = dr["PretoPerolizado"].ToString();
                    }

                    //Sugestão de Valores PRATA
                    if (Cor.Equals("PRATA") && SP.Equals("ACS EVOLUTION® POLIÉSTER"))
                    {
                        VALOR = dr["Prata"].ToString();
                    }
                    if (Cor.Equals("PRATA") && SP.Equals("CPP BASECOAT® POLIÉSTER"))
                    {
                        VALOR = dr["Prata"].ToString();
                    }
                    if (Cor.Equals("PRATA") && SP.Equals("DULON® POLIÉSTER"))
                    {
                        VALOR = dr["Prata"].ToString();
                    }

                    //Sugestão de Valores PRATA PU
                    if (Cor.Equals("PRATA") && SP.Equals("DELFLEET® PU 350"))
                    {
                        VALOR = dr["PrataPU"].ToString();
                    }

                    //Sugestão Valores AZUL PU
                    if (Cor.Equals("AZUL LISO") && SP.Equals("ACS EVOLUTION® PU"))
                    {
                        VALOR = dr["AzulLisoPU"].ToString();
                    }
                    if (Cor.Equals("AZUL LISO") && SP.Equals("CPU BASECOAT® POLIURETANO"))
                    {
                        VALOR = dr["AzulLisoPU"].ToString();
                    }
                    if (Cor.Equals("AZUL LISO") && SP.Equals("DELFLEET® PU 280"))
                    {
                        VALOR = dr["AzulLisoPU"].ToString();
                    }
                    if (Cor.Equals("AZUL LISO") && SP.Equals("DELFLEET® PU 290"))
                    {
                        VALOR = dr["AzulLisoPU"].ToString();
                    }
                    if (Cor.Equals("AZUL LISO") && SP.Equals("DELFLEET® PU 350"))
                    {
                        VALOR = dr["AzulLisoPU"].ToString();
                    }
                    if (Cor.Equals("AZUL LISO") && SP.Equals("DELFLEET® PU FOSCO"))
                    {
                        VALOR = dr["AzulLisoPU"].ToString();
                    }
                    if (Cor.Equals("AZUL LISO") && SP.Equals("DELFLEET® PU SEMI-BRILHO"))
                    {
                        VALOR = dr["AzulLisoPU"].ToString();
                    }
                    if (Cor.Equals("AZUL LISO") && SP.Equals("DELTRON® DG"))
                    {
                        VALOR = dr["AzulLisoPU"].ToString();
                    }
                    if (Cor.Equals("AZUL LISO") && SP.Equals("INDUSTRAN® PU"))
                    {
                        VALOR = dr["AzulLisoPU"].ToString();
                    }
                    if (Cor.Equals("AZUL LISO") && SP.Equals("INDUSTRAN® PU FOSCO"))
                    {
                        VALOR = dr["AzulLisoPU"].ToString();
                    }

                    //Sugestão de Valores AZUL LISO POLIESTER
                    if (Cor.Equals("AZUL LISO") && SP.Equals("ACS EVOLUTION® POLIÉSTER"))
                    {
                        VALOR = dr["AzulLisoPoliester"].ToString();
                    }
                    if (Cor.Equals("AZUL LISO") && SP.Equals("CPP BASECOAT® POLIÉSTER"))
                    {
                        VALOR = dr["AzulLisoPoliester"].ToString();
                    }
                    if (Cor.Equals("AZUL LISO") && SP.Equals("DULON® POLIÉSTER"))
                    {
                        VALOR = dr["AzulLisoPoliester"].ToString();
                    }

                    //Sugestão de Valores AZUL PEROLIZADO
                    if (Cor.Equals("AZUL PEROLIZADO") && SP.Equals("ACS EVOLUTION® POLIÉSTER"))
                    {
                        VALOR = dr["AzulPerozliado"].ToString();
                    }
                    if (Cor.Equals("AZUL PEROLIZADO") && SP.Equals("CPP BASECOAT® POLIÉSTER"))
                    {
                        VALOR = dr["AzulPerozliado"].ToString();
                    }
                    if (Cor.Equals("AZUL PEROLIZADO") && SP.Equals("DULON® POLIÉSTER"))
                    {
                        VALOR = dr["AzulPerozliado"].ToString();
                    }

                    //Sugestão Valores VERMELHO PU
                    if (Cor.Equals("VERMELHO LISO") && SP.Equals("ACS EVOLUTION® PU"))
                    {
                        VALOR = dr["VermelhoLisoPU"].ToString();
                    }
                    if (Cor.Equals("VERMELHO LISO") && SP.Equals("CPU BASECOAT® POLIURETANO"))
                    {
                        VALOR = dr["VermelhoLisoPU"].ToString();
                    }
                    if (Cor.Equals("VERMELHO LISO") && SP.Equals("DELFLEET® PU 280"))
                    {
                        VALOR = dr["VermelhoLisoPU"].ToString();
                    }
                    if (Cor.Equals("VERMELHO LISO") && SP.Equals("DELFLEET® PU 290"))
                    {
                        VALOR = dr["VermelhoLisoPU"].ToString();
                    }
                    if (Cor.Equals("VERMELHO LISO") && SP.Equals("DELFLEET® PU 350"))
                    {
                        VALOR = dr["VermelhoLisoPU"].ToString();
                    }
                    if (Cor.Equals("VERMELHO LISO") && SP.Equals("DELFLEET® PU FOSCO"))
                    {
                        VALOR = dr["VermelhoLisoPU"].ToString();
                    }
                    if (Cor.Equals("VERMELHO LISO") && SP.Equals("DELFLEET® PU SEMI-BRILHO"))
                    {
                        VALOR = dr["VermelhoLisoPU"].ToString();
                    }
                    if (Cor.Equals("VERMELHO LISO") && SP.Equals("DELTRON® DG"))
                    {
                        VALOR = dr["VermelhoLisoPU"].ToString();
                    }
                    if (Cor.Equals("VERMELHO LISO") && SP.Equals("INDUSTRAN® PU"))
                    {
                        VALOR = dr["VermelhoLisoPU"].ToString();
                    }
                    if (Cor.Equals("VERMELHO LISO") && SP.Equals("INDUSTRAN® PU FOSCO"))
                    {
                        VALOR = dr["VermelhoLisoPU"].ToString();
                    }

                    //Sugestão de Valores VERMELHO LISO POLIESTER
                    if (Cor.Equals("VERMELHO LISO") && SP.Equals("ACS EVOLUTION® POLIÉSTER"))
                    {
                        VALOR = dr["VermelhoLisoPoliester"].ToString();
                    }
                    if (Cor.Equals("VERMELHO LISO") && SP.Equals("CPP BASECOAT® POLIÉSTER"))
                    {
                        VALOR = dr["VermelhoLisoPoliester"].ToString();
                    }
                    if (Cor.Equals("VERMELHO LISO") && SP.Equals("DULON® POLIÉSTER"))
                    {
                        VALOR = dr["VermelhoLisoPoliester"].ToString();
                    }

                    //Sugestão de Valores VERMELHO PEROLIZADO
                    if (Cor.Equals("VERMELHO PEROLIZADO") && SP.Equals("ACS EVOLUTION® POLIÉSTER"))
                    {
                        VALOR = dr["VermelhoPerolizado"].ToString();
                    }
                    if (Cor.Equals("VERMELHO PEROLIZADO") && SP.Equals("CPP BASECOAT® POLIÉSTER"))
                    {
                        VALOR = dr["VermelhoPerolizado"].ToString();
                    }
                    if (Cor.Equals("VERMELHO PEROLIZADO") && SP.Equals("DULON® POLIÉSTER"))
                    {
                        VALOR = dr["VermelhoPerolizado"].ToString();
                    }

                    //Sugestão Valores VERDE PU
                    if (Cor.Equals("VERDE LISO") && SP.Equals("ACS EVOLUTION® PU"))
                    {
                        VALOR = dr["VerdeLisoPU"].ToString();
                    }
                    if (Cor.Equals("VERDE LISO") && SP.Equals("CPU BASECOAT® POLIURETANO"))
                    {
                        VALOR = dr["VerdeLisoPU"].ToString();
                    }
                    if (Cor.Equals("VERDE LISO") && SP.Equals("DELFLEET® PU 280"))
                    {
                        VALOR = dr["VerdeLisoPU"].ToString();
                    }
                    if (Cor.Equals("VERDE LISO") && SP.Equals("DELFLEET® PU 290"))
                    {
                        VALOR = dr["VerdeLisoPU"].ToString();
                    }
                    if (Cor.Equals("VERDE LISO") && SP.Equals("DELFLEET® PU 350"))
                    {
                        VALOR = dr["VerdeLisoPU"].ToString();
                    }
                    if (Cor.Equals("VERDE LISO") && SP.Equals("DELFLEET® PU FOSCO"))
                    {
                        VALOR = dr["VerdeLisoPU"].ToString();
                    }
                    if (Cor.Equals("VERDE LISO") && SP.Equals("DELFLEET® PU SEMI-BRILHO"))
                    {
                        VALOR = dr["VerdeLisoPU"].ToString();
                    }
                    if (Cor.Equals("VERDE LISO") && SP.Equals("DELTRON® DG"))
                    {
                        VALOR = dr["VerdeLisoPU"].ToString();
                    }
                    if (Cor.Equals("VERDE LISO") && SP.Equals("INDUSTRAN® PU"))
                    {
                        VALOR = dr["VerdeLisoPU"].ToString();
                    }
                    if (Cor.Equals("VERDE LISO") && SP.Equals("INDUSTRAN® PU FOSCO"))
                    {
                        VALOR = dr["VerdeLisoPU"].ToString();
                    }

                    //Sugestão de Valores VERDE LISO POLIESTER
                    if (Cor.Equals("VERDE LISO") && SP.Equals("ACS EVOLUTION® POLIÉSTER"))
                    {
                        VALOR = dr["VerdeLisoPoliester"].ToString();
                    }
                    if (Cor.Equals("VERDE LISO") && SP.Equals("CPP BASECOAT® POLIÉSTER"))
                    {
                        VALOR = dr["VerdeLisoPoliester"].ToString();
                    }
                    if (Cor.Equals("VERDE LISO") && SP.Equals("DULON® POLIÉSTER"))
                    {
                        VALOR = dr["VerdeLisoPoliester"].ToString();
                    }

                    //Sugestão de Valores VERDE PEROLIZADO
                    if (Cor.Equals("VERDE PEROLIZADO") && SP.Equals("ACS EVOLUTION® POLIÉSTER"))
                    {
                        VALOR = dr["VerdePerolizado"].ToString();
                    }
                    if (Cor.Equals("VERDE PEROLIZADO") && SP.Equals("CPP BASECOAT® POLIÉSTER"))
                    {
                        VALOR = dr["VerdePerolizado"].ToString();
                    }
                    if (Cor.Equals("VERDE PEROLIZADO") && SP.Equals("DULON® POLIÉSTER"))
                    {
                        VALOR = dr["VerdePerolizado"].ToString();
                    }

                    //Sugestão Valores AMARELO PU
                    if (Cor.Equals("AMARELO LISO") && SP.Equals("ACS EVOLUTION® PU"))
                    {
                        VALOR = dr["AmareloLisoPU"].ToString();
                    }
                    if (Cor.Equals("AMARELO LISO") && SP.Equals("CPU BASECOAT® POLIURETANO"))
                    {
                        VALOR = dr["AmareloLisoPU"].ToString();
                    }
                    if (Cor.Equals("AMARELO LISO") && SP.Equals("DELFLEET® PU 280"))
                    {
                        VALOR = dr["AmareloLisoPU"].ToString();
                    }
                    if (Cor.Equals("AMARELO LISO") && SP.Equals("DELFLEET® PU 290"))
                    {
                        VALOR = dr["AmareloLisoPU"].ToString();
                    }
                    if (Cor.Equals("AMARELO LISO") && SP.Equals("DELFLEET® PU 350"))
                    {
                        VALOR = dr["AmareloLisoPU"].ToString();
                    }
                    if (Cor.Equals("AMARELO LISO") && SP.Equals("DELFLEET® PU FOSCO"))
                    {
                        VALOR = dr["AmareloLisoPU"].ToString();
                    }
                    if (Cor.Equals("AMARELO LISO") && SP.Equals("DELFLEET® PU SEMI-BRILHO"))
                    {
                        VALOR = dr["AmareloLisoPU"].ToString();
                    }
                    if (Cor.Equals("AMARELO LISO") && SP.Equals("DELTRON® DG"))
                    {
                        VALOR = dr["AmareloLisoPU"].ToString();
                    }
                    if (Cor.Equals("AMARELO LISO") && SP.Equals("INDUSTRAN® PU"))
                    {
                        VALOR = dr["AmareloLisoPU"].ToString();
                    }
                    if (Cor.Equals("AMARELO LISO") && SP.Equals("INDUSTRAN® PU FOSCO"))
                    {
                        VALOR = dr["AmareloLisoPU"].ToString();
                    }

                    //Sugestão de Valores AMARELO LISO POLIESTER
                    if (Cor.Equals("AMARELO LISO") && SP.Equals("ACS EVOLUTION® POLIÉSTER"))
                    {
                        VALOR = dr["AmareloLisoPoliester"].ToString();
                    }
                    if (Cor.Equals("AMARELO LISO") && SP.Equals("CPP BASECOAT® POLIÉSTER"))
                    {
                        VALOR = dr["AmareloLisoPoliester"].ToString();
                    }
                    if (Cor.Equals("AMARELO LISO") && SP.Equals("DULON® POLIÉSTER"))
                    {
                        VALOR = dr["AmareloLisoPoliester"].ToString();
                    }

                    //Sugestão de Valores AMARELO PEROLIZADO
                    if (Cor.Equals("AMARELO PEROLIZADO") && SP.Equals("ACS EVOLUTION® POLIÉSTER"))
                    {
                        VALOR = dr["AmareloPerolizado"].ToString();
                    }
                    if (Cor.Equals("AMARELO PEROLIZADO") && SP.Equals("CPP BASECOAT® POLIÉSTER"))
                    {
                        VALOR = dr["AmareloPerolizado"].ToString();
                    }
                    if (Cor.Equals("AMARELO PEROLIZADO") && SP.Equals("DULON® POLIÉSTER"))
                    {
                        VALOR = dr["AmareloPerolizado"].ToString();
                    }


                    //Sugestão Valores CINZA PU
                    if (Cor.Equals("CINZA LISO") && SP.Equals("ACS EVOLUTION® PU"))
                    {
                        VALOR = dr["CinzaLisoPU"].ToString();
                    }
                    if (Cor.Equals("CINZA LISO") && SP.Equals("CPU BASECOAT® POLIURETANO"))
                    {
                        VALOR = dr["CinzaLisoPU"].ToString();
                    }
                    if (Cor.Equals("CINZA LISO") && SP.Equals("DELFLEET® PU 280"))
                    {
                        VALOR = dr["CinzaLisoPU"].ToString();
                    }
                    if (Cor.Equals("CINZA LISO") && SP.Equals("DELFLEET® PU 290"))
                    {
                        VALOR = dr["CinzaLisoPU"].ToString();
                    }
                    if (Cor.Equals("CINZA LISO") && SP.Equals("DELFLEET® PU 350"))
                    {
                        VALOR = dr["CinzaLisoPU"].ToString();
                    }
                    if (Cor.Equals("CINZA LISO") && SP.Equals("DELFLEET® PU FOSCO"))
                    {
                        VALOR = dr["CinzaLisoPU"].ToString();
                    }
                    if (Cor.Equals("CINZA LISO") && SP.Equals("DELFLEET® PU SEMI-BRILHO"))
                    {
                        VALOR = dr["CinzaLisoPU"].ToString();
                    }
                    if (Cor.Equals("CINZA LISO") && SP.Equals("DELTRON® DG"))
                    {
                        VALOR = dr["CinzaLisoPU"].ToString();
                    }
                    if (Cor.Equals("CINZA LISO") && SP.Equals("INDUSTRAN® PU"))
                    {
                        VALOR = dr["CinzaLisoPU"].ToString();
                    }
                    if (Cor.Equals("CINZA LISO") && SP.Equals("INDUSTRAN® PU FOSCO"))
                    {
                        VALOR = dr["CinzaLisoPU"].ToString();
                    }

                    //Sugestão de Valores CINZA LISO POLIESTER
                    if (Cor.Equals("CINZA LISO") && SP.Equals("ACS EVOLUTION® POLIÉSTER"))
                    {
                        VALOR = dr["CinzaLisoPoliester"].ToString();
                    }
                    if (Cor.Equals("CINZA LISO") && SP.Equals("CPP BASECOAT® POLIÉSTER"))
                    {
                        VALOR = dr["CinzaLisoPoliester"].ToString();
                    }
                    if (Cor.Equals("CINZA LISO") && SP.Equals("DULON® POLIÉSTER"))
                    {
                        VALOR = dr["CinzaLisoPoliester"].ToString();
                    }

                    //Sugestão de Valores CINZA PEROLIZADO
                    if (Cor.Equals("CINZA PEROLIZADO") && SP.Equals("ACS EVOLUTION® POLIÉSTER"))
                    {
                        VALOR = dr["CinzaPerolizado"].ToString();
                    }
                    if (Cor.Equals("CINZA PEROLIZADO") && SP.Equals("CPP BASECOAT® POLIÉSTER"))
                    {
                        VALOR = dr["CinzaPerolizado"].ToString();
                    }
                    if (Cor.Equals("CINZA PEROLIZADO") && SP.Equals("DULON® POLIÉSTER"))
                    {
                        VALOR = dr["CinzaPerolizado"].ToString();
                    }


                    //Sugestão Valores MARROM/BEGE PU
                    if (Cor.Equals("MARROM/BEGE LISO") && SP.Equals("ACS EVOLUTION® PU"))
                    {
                        VALOR = dr["MarromLisoPU"].ToString();
                    }
                    if (Cor.Equals("MARROM/BEGE LISO") && SP.Equals("CPU BASECOAT® POLIURETANO"))
                    {
                        VALOR = dr["MarromLisoPU"].ToString();
                    }
                    if (Cor.Equals("MARROM/BEGE LISO") && SP.Equals("DELFLEET® PU 280"))
                    {
                        VALOR = dr["MarromLisoPU"].ToString();
                    }
                    if (Cor.Equals("MARROM/BEGE LISO") && SP.Equals("DELFLEET® PU 290"))
                    {
                        VALOR = dr["MarromLisoPU"].ToString();
                    }
                    if (Cor.Equals("MARROM/BEGE LISO") && SP.Equals("DELFLEET® PU 350"))
                    {
                        VALOR = dr["MarromLisoPU"].ToString();
                    }
                    if (Cor.Equals("MARROM/BEGE LISO") && SP.Equals("DELFLEET® PU FOSCO"))
                    {
                        VALOR = dr["MarromLisoPU"].ToString();
                    }
                    if (Cor.Equals("MARROM/BEGE LISO") && SP.Equals("DELFLEET® PU SEMI-BRILHO"))
                    {
                        VALOR = dr["MarromLisoPU"].ToString();
                    }
                    if (Cor.Equals("MARROM/BEGE LISO") && SP.Equals("DELTRON® DG"))
                    {
                        VALOR = dr["MarromLisoPU"].ToString();
                    }
                    if (Cor.Equals("MARROM/BEGE LISO") && SP.Equals("INDUSTRAN® PU"))
                    {
                        VALOR = dr["MarromLisoPU"].ToString();
                    }
                    if (Cor.Equals("MARROM/BEGE LISO") && SP.Equals("INDUSTRAN® PU FOSCO"))
                    {
                        VALOR = dr["MarromLisoPU"].ToString();
                    }

                    //Sugestão de Valores MARROM/BEGE LISO POLIESTER
                    if (Cor.Equals("MARROM/BEGE LISO") && SP.Equals("ACS EVOLUTION® POLIÉSTER"))
                    {
                        VALOR = dr["MarromLisoPoliester"].ToString();
                    }
                    if (Cor.Equals("MARROM/BEGE LISO") && SP.Equals("CPP BASECOAT® POLIÉSTER"))
                    {
                        VALOR = dr["MarromLisoPoliester"].ToString();
                    }
                    if (Cor.Equals("MARROM/BEGE LISO") && SP.Equals("DULON® POLIÉSTER"))
                    {
                        VALOR = dr["MarromLisoPoliester"].ToString();
                    }

                    //Sugestão de Valores MARROM/BEGE PEROLIZADO
                    if (Cor.Equals("MARROM/BEGE PEROLIZADO") && SP.Equals("ACS EVOLUTION® POLIÉSTER"))
                    {
                        VALOR = dr["MarromPerolizado"].ToString();
                    }
                    if (Cor.Equals("MARROM/BEGE PEROLIZADO") && SP.Equals("CPP BASECOAT® POLIÉSTER"))
                    {
                        VALOR = dr["MarromPerolizado"].ToString();
                    }
                    if (Cor.Equals("MARROM/BEGE PEROLIZADO") && SP.Equals("DULON® POLIÉSTER"))
                    {
                        VALOR = dr["MarromPerolizado"].ToString();
                    }
                }                
            }
            catch
            {
            }
            return VALOR;
        }

    }
}
