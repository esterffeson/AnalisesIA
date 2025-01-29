using MacroR6_WindowsForm;
using System;

public class buscaValoresControles
{
    public void ObterValoresArma(string armaSelecionada, out int valorMacroX,out int valorMacroY)
    {
        switch (armaSelecionada)
        {
            case "armaAK12":
                valorMacroX = 0;
                valorMacroY = 15;
                break;

            case "armaG36C":
                valorMacroX = 0;
                valorMacroY = 15;
                break;

            case "armaF2Famas":
                valorMacroX = 0;
                valorMacroY = 21;
                break;

            case "armaR4C":
                valorMacroX = 0;
                valorMacroY = 18;
                break;

            case "armaSpear308":
                valorMacroX = 0;
                valorMacroY = 15;
                break;

            case "armaSMG11":
                valorMacroX = 0;
                valorMacroY = 18;
                break;

            case "armaSMG12":
                valorMacroX = 0;
                valorMacroY = 25;
                break;

            default:
                valorMacroX = 0;
                valorMacroY = 25;
                break;
        }
    }
}
