using System;
using System.Xml.Linq;

namespace Academits.Karetskas.Minesweeper.Logic.FileManagement
{
    public sealed class OptionsManagement : XmlFileManagement
    {
        private const string FileName = "Options.xml";

        public int MaxFieldSize => 17;

        public int MinFieldSize => 9;

        public int MaxMinesCount => Convert.ToInt32(0.8 * FieldWidth * FieldHeight);

        public int MinMinesCount => 10;

        public int FieldWidth
        {
            get => GetOptionFromXml(_document?.Root?.Element("field")?.Element("width"), MaxFieldSize, MinFieldSize);

            set => ChangeElementValue(_document?.Root?.Element("field")?.Element("width"), value, MaxFieldSize, MinFieldSize);
        }

        public int FieldHeight
        {
            get => GetOptionFromXml(_document?.Root?.Element("field")?.Element("height"), MaxFieldSize, MinFieldSize);

            set => ChangeElementValue(_document?.Root?.Element("field")?.Element("height"), value, MaxFieldSize, MinFieldSize);
        }

        public int MinesCount
        {
            get => GetOptionFromXml(_document?.Root?.Element("minesCount"), MaxMinesCount, MinMinesCount);

            set => ChangeElementValue(_document?.Root?.Element("minesCount"), value, MaxMinesCount, MinMinesCount);
        }

        public OptionsManagement() : base(FileName) { }

        protected override void CreateDefaultXmlDocument()
        {
            _document = new XDocument(new XElement("options",
                new XElement("field",
                    new XElement("width", FieldWidth),
                    new XElement("height", FieldHeight)),
                new XElement("minesCount", MinesCount)));
        }

        private static int GetOptionFromXml(XElement? element, int maxValue, int minValue)
        {
            _ = int.TryParse(element?.Value, out var option);

            return !IsValidValueOption(option, maxValue, minValue) ? minValue : option;
        }

        private static bool IsValidValueOption(int option, int maxValue, int minValue)
        {
            return option >= minValue && option <= maxValue;
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
