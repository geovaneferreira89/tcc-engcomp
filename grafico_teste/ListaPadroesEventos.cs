using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmbienteRPB
{
    public class ListaPadroesEventos
    {
        public int[] ListaDeEventos; //ex inicio é posicao [0] e fim pos [1] para o evento 01... inicio é posicao [2] e fim pos [3] para o evento 02... 
        public int[] ListaNumeroEventos;
        public string[] ListaPadroes;
        public int NumDePadroes;
        //-------------------------------------------------
        public void CriarLista(int tamaListaEvent, int tamListaNumEvent, int tamListaPadros, int _NumDePadroes)
        {
            ListaDeEventos = new int[tamaListaEvent];
            ListaNumeroEventos = new int[tamListaNumEvent];
            ListaPadroes = new string[tamListaPadros];
            NumDePadroes = _NumDePadroes;
        }
        //Sets------------------------------------------------
        public void SetListaDeEnvetos(int[] _ListaDeEventos)
        {
            ListaDeEventos = _ListaDeEventos;
        }
        public void SetListaNumeroDeEnvetos(int[] _ListaNumeroEventos)
        {
            ListaNumeroEventos = _ListaNumeroEventos;
        }
        public void SetListaDePadroes(string[] _ListaPadroes)
        {
            ListaPadroes = _ListaPadroes;
        }
        public void SetNumDePadroes(int _NumDePadroes)
        {
            NumDePadroes = _NumDePadroes;
        }
        //-----------
        public void SetListaDeEnvetosPOS(int pos, int valor)
        {
            ListaDeEventos[pos] = valor;
        }
        public void SetListaNumeroDeEnvetosPOS(int pos, int valor)
        {
            ListaNumeroEventos[pos] = valor;
        }
        public void SetListaDePadroesPOS(int pos, string nome)
        {
            ListaPadroes[pos] = nome;
        }
        //Gets------------------------------------------------
        public int[] GetListaDeEnvetos()
        {
            return ListaDeEventos;
        }
        public int[] GetListaNumeroDeEnvetos()
        {
            return ListaNumeroEventos;
        }
        public string[] GetListaDePadroes()
        {
            return ListaPadroes;
        }
        public int GetNumDePadroes()
        {
            return NumDePadroes;
        }
        //----------
        public int GetListaDeEnvetosPOS(int pos)
        {
            return ListaDeEventos[pos];
        }
        public int GetListaNumeroDeEnvetosPOS(int pos)
        {
            return ListaNumeroEventos[pos];
        }
        public string GetListaDePadroesPOS(int pos)
        {
            return ListaPadroes[pos];
        }
        //----------------------------------------------------
    }
}
