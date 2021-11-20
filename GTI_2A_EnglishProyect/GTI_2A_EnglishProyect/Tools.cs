using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI_2A_EnglishProyect
{
    class Tools
    {
        //Funcion que devulve verdadero o falso si el texto de entrada esta vacio
        public static bool emptyText(string inputText)
        {

            if (inputText != null)
            {

                //Quita espacios en blanco al principio y final del texto
                inputText = inputText.Trim();

                if (inputText.Equals(""))
                {

                    return true;

                }

            }

            return false;

        }

        // Quita todas las mayusculas al texto de entrada
        public static string offCapitalsLetters(String inputText)
        {
            inputText = inputText.ToLower();
            if (inputText.Length == 0)
            {
                return "";
            }
            else
            {
                return inputText;
            }


        }

        public static string generateNewID()
        {
            return Guid.NewGuid().ToString();
        }

    }
}
