using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GTI_2A_EnglishProyect
{
    class Product
    {
        //===============================================================================================================================================
        // Atributos de la clase
        //===============================================================================================================================================
        // Auto generado
        private string id;
        private string name;
        private string platform;
        private string manufacturer;
        private string description;
        private string price;
        private string stock;
        private string[] availablePlatforms = { "xbox", "playstation", "nintendo", "pc" };
        //===============================================================================================================================================
        //Propiedades de la clase
        //===============================================================================================================================================
        public string ID
        //===============================================================================================================================================
        {
            get { return id; }
            set
            {
                Console.WriteLine(value);

                if (!Tools.emptyText(id))
                {
                    id = value;
                }
                else
                {
                    throw new ArgumentException("ID can not be empty");
                }
            }
        }
        //===============================================================================================================================================
        public string NAME
        //===============================================================================================================================================
        {
            get { return name; }

            // No puede ser texto vacío y se va a normalizar "TeXto" a " texto "

            set
            {
                Console.WriteLine(value);

                if (!Tools.emptyText(value))
                {
                    name = Tools.offCapitalsLetters(value);
                }
                else
                {
                    throw new ArgumentException("Name can not be empty");
                }

            }
        }
        //===============================================================================================================================================
        public string PLATFORM
        //===============================================================================================================================================
        {
            get { return platform; }

            // Solo se pueden tomar los valores de "Xbox", "Playstation","Nintendo","PC" y se normalizarán

            set
            {
                Console.WriteLine(value);

                if (validPlatfom(value))
                {
                    platform = value.ToLower();
                }
                else
                {
                    throw new ArgumentException("Invalid type of product");

                }

            }
        }
        //===============================================================================================================================================
        public string MANUFACTURER
        //===============================================================================================================================================
        {
            get { return manufacturer; }

            // No puede ser texto vacío y se va a normalizar "TeXto" a " texto "

            set
            {
                Console.WriteLine(value);

                if (!Tools.emptyText(value))
                {
                    manufacturer = Tools.offCapitalsLetters(value);
                }
                else
                {
                    throw new ArgumentException("Manufacturer can not be empty");
                }

            }
        }
        //===============================================================================================================================================
        public string DESCRIPTION
        //===============================================================================================================================================
        {
            get { return description; }

            // No puede ser texto vacío y se va a normalizar "TeXto" a " texto "

            set
            {
                Console.WriteLine(value);
                description = Tools.offCapitalsLetters(value);
            }
        }
        //===============================================================================================================================================
        public string PRICE
        //===============================================================================================================================================
        {
            get { return price; }

            // Intenta convertir a doble y no negativo

            set
            {
                Console.WriteLine(value);

                if (inpuntPositiveDecimal(value))
                {
                    price = value;
                }
                else
                {
                    throw new ArgumentException("Price should be a positive number");
                }
            }
        }
        //===============================================================================================================================================
        public string STOCK
        //===============================================================================================================================================
        {
            get { return stock; }
            set
            {
                Console.WriteLine(value);

                // solo números enteros positivos

                if (inputPositiveInteger(value))
                {
                    stock = value;
                }
                else
                {
                    throw new ArgumentException("Stock should be a positive integer number");
                }
            }
        }
        //===============================================================================================================================================
        // Metodos de ayuda
        //===============================================================================================================================================
        private bool validPlatfom(string type)
        {
            return availablePlatforms.Contains(type.ToLower());
        }
        //===============================================================================================================================================
        // Se debe usar esto: ^[0-9]\d*$ el $ indica que es solo una unica cadena, sin puntos ni espacios permitidos
        // ponemos el ^ delante para solo pillar numeros, de otra forma si se pone un espacio lo pilla o un punto
        //===============================================================================================================================================
        private bool inputPositiveInteger(string number)
        {

            Match match = Regex.Match(number, @"^[0-9]\d*$");

            return match.Success;

        }
        //===============================================================================================================================================
        // regex = ^[0-9]\d*.\d*$ -> lo mismo que antes pero el valor es solo si son digitos positvios separados por un punto
        //===============================================================================================================================================
        private bool inpuntPositiveDecimal(string number)
        {

            Match matchInteger = Regex.Match(number, @"^[0-9]\d*$");
            // poner 12 de precio tambien es valido
            if (matchInteger.Success)
            {
                return true;
            }
            Match matchDecimal = Regex.Match(number, @"^[0-9]\d*.\d*$");
            if (matchDecimal.Success)
            {
                return true;
            }

            return false;

        }
        //===============================================================================================================================================
        // Esta forma permite poner objetos directamente en el list box, como intente hacer el to string, saldra solo el nombre
        //===============================================================================================================================================
        public override string ToString()
        {
            return NAME;
        }
        //===============================================================================================================================================
        // Esto es util para cuendo creamos un producto nuevo
        //===============================================================================================================================================
        public Product()
        {
            ID = Tools.generateNewID();

        }
        //===============================================================================================================================================
        // Constructor
        //===============================================================================================================================================
        public Product(string name, string platform, string manufacturer, string description, string price, string stock)
        {
            ID = Tools.generateNewID();
            NAME = name;
            PLATFORM = platform;
            MANUFACTURER = manufacturer;
            DESCRIPTION = description;
            PRICE = price;
            STOCK = stock;
        }
    }
}
