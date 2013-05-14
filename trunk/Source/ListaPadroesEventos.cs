using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace AmbienteRPB
{
    public class ListaPadroesEventos
    {
        public PointF[] ValorInicio;
        public PointF[] ValorFim;
        public PointF[] ValorMeio;
        public string[] NomesEvento;
        public int      NumeroEventos;
        public string   NomePadrao;
        public string[]  Comentario;

        //-------------------------------------------------
        public void CriarLista(int _NumeroDeEventos, string _nomePadrao)
        {
            ValorInicio = new PointF[600];
            ValorMeio   = new PointF[600];
            ValorFim    = new PointF[600];
            Comentario  = new string[600];
            NomesEvento = new string[600];
            NumeroEventos = 0;
            NomePadrao    = _nomePadrao;
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
        //----------------------------------------------------
    }
}
