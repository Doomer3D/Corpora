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
        /// обработчик сущности: граммема
        /// </summary>
        public event Action<Grammeme> OnGrammeme;

        /// <summary>
        /// обработчик сущности: лексема
        /// </summary>
        public event Action<Lexeme> OnLexeme;

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
                if (_reader.IsStartElement() && !_reader.IsEmptyElement)
                {
                    switch (_reader.Name)
                    {
                        case "grammeme":
                            ////////////////////////////////////////////////////////////////
                            // граммема
                            ////////////////////////////////////////////////////////////////
                            OnGrammeme?.Invoke(ReadGrammeme());
                            break;

                        case "lemma":
                            ////////////////////////////////////////////////////////////////
                            // лексема
                            ////////////////////////////////////////////////////////////////
                            OnLexeme?.Invoke(ReadLexeme());
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// прочитать граммему
        /// </summary>
        /// <returns></returns>
        protected virtual Grammeme ReadGrammeme()
        {
            string name = null;
            //string alias;
            string description = null;

            // читаем атрибуты
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

            while (_reader.Read() && !(_reader.NodeType == XmlNodeType.EndElement && _reader.Name == "grammeme"))
            {
                if (_reader.IsStartElement() && !_reader.IsEmptyElement)
                {
                    switch (_reader.Name)
                    {
                        case "name":
                            _reader.Read();
                            name = _reader.Value;
                            break;
                        case "alias":
                            _reader.Read();
                            //alias = _reader.Value;
                            break;
                        case "description":
                            _reader.Read();
                            description = _reader.Value;
                            break;
                    }
                }
            }

            if (G.TryGetByName(name, out var item))
            {
                return item;
            }
            else
            {
                throw new KeyNotFoundException($"Незарегистрированная граммема: {name} ({description})");
            }
        }

        /// <summary>
        /// прочитать лексему
        /// </summary>
        /// <returns></returns>
        protected virtual Lexeme ReadLexeme()
        {
            Lexeme item = new Lexeme();

            // читаем атрибуты
            if (_reader.HasAttributes)
            {
                while (_reader.MoveToNextAttribute())
                {
                    switch (_reader.Name)
                    {
                        case "id":
                            item.ID = int.Parse(_reader.Value);
                            break;
                        case "rev":
                            item.Revision = int.Parse(_reader.Value);
                            break;
                    }
                }
            }

            while (_reader.Read() && !(_reader.NodeType == XmlNodeType.EndElement && _reader.Name == "lemma"))
            {
                if (_reader.IsStartElement() && !_reader.IsEmptyElement)
                {
                    switch (_reader.Name)
                    {
                        case "l":
                            // лемма
                            item.Lemma = ReadForm();
                            break;
                        case "f":
                            // форма слова
                            item.AddForm(ReadForm());
                            break;
                    }
                }
            }

            return item;
        }

        /// <summary>
        /// прочитаь форму слова
        /// </summary>
        /// <returns></returns>
        protected virtual Form ReadForm()
        {
            Form item = new Form();

            var finish = _reader.Name;

            // читаем атрибуты
            if (_reader.HasAttributes)
            {
                while (_reader.MoveToNextAttribute())
                {
                    switch (_reader.Name)
                    {
                        case "t":
                            item.Text = _reader.Value;
                            break;
                    }
                }
            }

            while (_reader.Read() && !(_reader.NodeType == XmlNodeType.EndElement && _reader.Name == finish))
            {
                if (_reader.IsStartElement())
                {
                    switch (_reader.Name)
                    {
                        case "g":
                            // граммема
                            if (_reader.HasAttributes)
                            {
                                while (_reader.MoveToNextAttribute())
                                {
                                    if (_reader.Name == "v")
                                    {
                                        item.AddGrammeme(G.GetByName(_reader.Value));
                                    }
                                }
                            }
                            break;
                    }
                }
            }

            return item;
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
