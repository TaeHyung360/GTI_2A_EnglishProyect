using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            String finalText = char.ToUpper(inputText[0]) + inputText.Substring(1);
            if (finalText.Length == 0)
            {
                return "";
            }
            else
            {
                return finalText;
            }


        }

        public static string generateNewID()
        {
            return Guid.NewGuid().ToString();
        }
        //===============================================================================================================================================
        // ReadFile
        //===============================================================================================================================================
        public static String readFile(String nameFile)
        {
            String line;// used to read from the file
            StringBuilder sb = new StringBuilder();// where the text read it are going to be stored


            using (FileStream fs = File.Open(nameFile, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("utf-8")))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        sb.AppendLine(line);
                    }
                }
            }
            return sb.ToString();
        }
        //===============================================================================================================================================
        // MessageBox
        //===============================================================================================================================================
        public static void dialogError(String title, String message)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

    }
}
