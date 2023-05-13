using System;
using System.Xml.Linq;

namespace Academits.Karetskas.Minesweeper.Logic.FileManagement
{
    public sealed class OptionsManagement : XmlFileManagement
    {
        private const string FileName = "Options.xml";
        private const int MaxFieldWidth = 17;
        private const int MinFieldWidth = 9;
        private const int MaxFieldHeight = 17;
        private const int MinFieldHeight = 9;
        private const int MinMinesCount = 10;

        public int FieldWidth
        {
            get => GetOptionFromXml(_document?.Root?.Element("field")?.Element("width"), MaxFieldWidth, MinFieldWidth);

            set => ChangeElementValue(_document?.Root?.Element("field")?.Element("width"), value, MaxFieldWidth, MinFieldWidth);
        }

        public int FieldHeight
        {
            get => GetOptionFromXml(_document?.Root?.Element("field")?.Element("height"), MaxFieldHeight, MinFieldHeight);

            set => ChangeElementValue(_document?.Root?.Element("field")?.Element("height"), value, MaxFieldHeight, MinFieldHeight);
        }

        public int MinesCount
        {
            get => GetOptionFromXml(_document?.Root?.Element("minesCount"), MaxMinesCount, MinMinesCount);

            set => ChangeElementValue(_document?.Root?.Element("minesCount"), value, MaxMinesCount, MinMinesCount);
        }

        public int MaxMinesCount => Convert.ToInt32(0.8 * FieldWidth * FieldHeight);

        public OptionsManagement() : base(FileName) { }

        protected override void CreateDefaultXmlDocument()
        {
            _document = new XDocument(new XElement("options",
                new XElement("field",
                    new XElement("width", FieldWidth),
                    new XElement("height", FieldHeight)),
                new XElement("minesCount", MinesCount)));
        }

        public bool IsValidFieldWidth(int fieldWidth)
        {
            return IsValidValueOption(fieldWidth, MaxFieldWidth, MinFieldWidth);
        }

        public bool IsValidFieldHeight(int fieldHeight)
        {
            return IsValidValueOption(fieldHeight, MaxFieldHeight, MinFieldHeight);
        }

        public bool IsValidMinesCount(int fieldMinesCount)
        {
            return IsValidValueOption(fieldMinesCount, MaxMinesCount, MinMinesCount);
        }

        private static int GetOptionFromXml(XElement? element, int maxValue, int minValue)
        {
            _ = int.TryParse(element?.Value, out var option);

            if (!IsValidValueOption(option, maxValue, minValue))
            {
                return minValue;
            }

            return option;
        }

        private static bool IsValidValueOption(int option, int maxValue, int minValue)
        {
            var b = option >= minValue && option <= maxValue;

            return b;
        }

        private static void ChangeElementValue(XElement? element, int option, int maxValue, int minValue)
        {
            if (element is null)
            {
                return;
            }

            if (!IsValidValueOption(option, maxValue, minValue))
            {
                element.Value = minValue.ToString();

                return;
            }

            element.Value = option.ToString();
        }
    }
}
