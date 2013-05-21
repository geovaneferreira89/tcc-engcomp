/**
 * @file ListaPadroesEventos.cs
 * 
 * \brief   Implementação dos métodos das lista de padroes
 * \details Este arquivo apresenta a implementação dos métodos da classe de lista de padroes
 * 
 * @version 1.0
 * @date    03/2013
 * @author  Geovane Vinicius Ferreira (email: geovanevinicius89@gmail.com)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;


namespace AmbienteRPB
{
    public class ListaPadroesEventos
    {
        public PointF[] ValorInicio;
        public PointF[] ValorFim;
        public PointF[] ValorMeio;
        public Color[]  CorDeFundo;
        public float[]  Width;
        public int[]    Canal;
        public string[] NomesEvento;
        public int      NumeroEventos;
        public string   NomePadrao;
        public string[] Comentario;

        //-------------------------------------------------
        public void CriarLista(int _NumeroDeEventos, string _nomePadrao, int TamanhoLista)
        {
            ValorInicio = new PointF[TamanhoLista];
            ValorMeio   = new PointF[TamanhoLista];
            ValorFim    = new PointF[TamanhoLista];
            Comentario  = new string[TamanhoLista];
            NomesEvento = new string[TamanhoLista];
            Canal       = new int[TamanhoLista];
            CorDeFundo  = new Color[TamanhoLista];
            Width       = new float[TamanhoLista];
            NumeroEventos = 0;
            NomePadrao  = _nomePadrao;

        }
        //Sets------------------------------------------------
        public void SetValorInicio(int Posicao, PointF Valor)
        {
            ValorInicio[Posicao] = new PointF();
            ValorInicio[Posicao] = Valor;
        }
        public void SetValorFim(int Posicao, PointF Valor)
        {
            ValorFim[Posicao] = new PointF();
            ValorFim[Posicao] = Valor;
        }
        public void SetValorMeio(int Posicao, PointF Valor)
        {
            ValorMeio[Posicao] = new PointF();
            ValorMeio[Posicao] = Valor;
        }
        public void SetChartDataPoint(int Posicao, int Canal_)
        {
            Canal[Posicao] = Canal_;
        }
        public void SetNomesEvento(int Posicao,string Nome)
        {
            NomesEvento[Posicao] = Nome;
        }
        public void SetComentario(int Posicao, string Coment)
        {
            Comentario[Posicao] = Coment;
        }
        public void SetNumeroEventos(int Valor)
        {
           NumeroEventos = Valor;
        }
        public void SetNomePadrao(string Nome)
        {
            NomePadrao = Nome;
        }
        public void SetCorDeFundo(int POS, Color NomeCor)
        {
            CorDeFundo[POS] = NomeCor;
        }
        public void SetWidth(int POS, float Comprimento)
        {
            Width[POS] = Comprimento;
        }
        //Gets------------------------------------------------
        public PointF GetValorInicio(int POS)
        {
            return ValorInicio[POS];
        }
        public PointF GetValorFim(int POS)
        {
            return ValorFim[POS];
        }
        public PointF GetValorMeio(int POS)
        {
            return ValorMeio[POS];
        }
        public int GetChartDataPoint(int POS)
        {
            return Canal[POS];
        }
        public string GetNomesEvento(int POS)
        {
            return NomesEvento[POS];
        }
        public string GetComentario(int POS)
        {
            return Comentario[POS];
        }
        public int GetNumeroEventos()
        {
            return NumeroEventos;
        }
        public string GetNomePadrao()
        {
            return NomePadrao;
        }
        public Color GetCorDeFundo(int POS)
        {
            return CorDeFundo[POS];
        }
        public float GetWidth(int POS)
        {
           return Width[POS];
        }
        //----------------------------------------------------
    }
}
