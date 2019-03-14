using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Corpora.Formats.Xml
{
    /// <summary>
    /// читатель словаря OpenCorpora
    /// </summary>
    public class OpenCorporaDictionaryReader : IDisposable
    {
        /// <summary>
        /// читатель XML
        /// </summary>
        protected XmlReader _reader;

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="inputUri"> URI </param>
        public OpenCorporaDictionaryReader(string inputUri)
        {
            _reader = XmlReader.Create(inputUri);
        }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="inputUri"> URI </param>
        /// <param name="settings"> настройки </param>
        public OpenCorporaDictionaryReader(string inputUri, XmlReaderSettings settings)
        {
            _reader = XmlReader.Create(inputUri, settings);
        }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="reader"> текстовый парсер </param>
        public OpenCorporaDictionaryReader(TextReader reader)
        {
            _reader = XmlReader.Create(reader);
        }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="reader"> текстовый парсер </param>
        /// <param name="settings"> настройки </param>
        public OpenCorporaDictionaryReader(TextReader reader, XmlReaderSettings settings)
        {
            _reader = XmlReader.Create(reader, settings);
        }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="input"> поток </param>
        public OpenCorporaDictionaryReader(Stream input)
        {
            _reader = XmlReader.Create(input);
        }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="input"> поток </param>
        /// <param name="settings"> настройки </param>
        public OpenCorporaDictionaryReader(Stream input, XmlReaderSettings settings)
        {
            _reader = XmlReader.Create(input, settings);
        }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="reader"> читатель XML </param>
        /// <param name="settings"> настройки </param>
        public OpenCorporaDictionaryReader(XmlReader reader, XmlReaderSettings settings)
        {
            _reader = XmlReader.Create(reader, settings);
        }

        /// <summary>
        /// прочитать документ
        /// </summary>
        public virtual void ReadAll()
        {
            while (_reader.Read())
            {
                if (_reader.NodeType == XmlNodeType.Element)
                {
                    switch (_reader.Name)
                    {
                        case "grammeme":
                            // граммема
                            {
                                Grammeme item = new Grammeme();

                                //byte id, string name, string alias, string description, Grammeme parent = null;

                                if (_reader.HasAttributes)
                                {
                                    while (_reader.MoveToNextAttribute())
                                    {
                                        switch (_reader.Name)
                                        {
                                            case "parent":
                                                break;
                                        }
                                    }
                                }
                                while (_reader.NodeType != XmlNodeType.EndElement)
                                {
                                    while (_reader.Read())
                                    {
                                        if (_reader.NodeType == XmlNodeType.Element)
                                        {
                                            switch (_reader.Name)
                                            {
                                                case "name":
                                                    //item.Name = _reader.ReadContentAsString();
                                                    break;
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// высвободить ресурсы
        /// </summary>
        public void Dispose()
        {
            if (_reader != null)
            {
                _reader.Dispose();
            }
        }
    }
}
