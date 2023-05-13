using System;
using System.IO;
using System.Xml.Linq;

namespace Academits.Karetskas.Minesweeper.Logic.FileManagement
{
    public abstract class XmlFileManagement
    {
        private readonly string? _fileName;
        protected XDocument? _document;

        protected XmlFileManagement(string fileName)
        {
            CheckForNull(fileName);

            _fileName = fileName;

            if (!File.Exists(fileName))
            {
                CreateDefaultFile();

                return;
            }

            try
            {
                _document = XDocument.Load(fileName);
            }
            catch (Exception)
            {
                CreateDefaultFile();
            }
        }

        private void CreateDefaultFile()
        {
            CreateDefaultXmlDocument();
            SaveToXmlFile();
        }

        private static void CheckForNull(object? obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj), $"The argument {nameof(obj)} is null.");
            }
        }

        protected abstract void CreateDefaultXmlDocument();

        public void SaveToXmlFile()
        {
            try
            {
                if (_fileName is not null)
                {
                    _document?.Save(_fileName);
                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Failed to save file.", e);
            }
        }
    }
}
