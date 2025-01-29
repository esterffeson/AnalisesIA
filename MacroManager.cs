using MacroR6_WindowsForm;
using System;
using System.Security.Cryptography.X509Certificates;

namespace MacroR6_WindowsForm
{
    //internal class macroManager(buscaValoresControles buscaValoresControles)
    internal class macroManager(Boolean armaSelecionada)
    {
      // private buscaValoresControles buscaValoresControles = buscaValoresControles;
        //private bool armaAK12Checked;

        public int AcessandoRBarmaAK12()
        {
            bool vlbArmaAK12 = armaSelecionada;
            if (vlbArmaAK12) return 40;
            return 0;
        }
    }
}