﻿using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;

namespace RawLauncherWPF.Xml
{
    public class XmlValidator
    {
        private int _errors;

        public XmlValidator(string file)
        {
            if (!File.Exists(file))
                throw new FileNotFoundException(nameof(file));

            SchemeFileStream = new FileStream(file, FileMode.Open);
        }

        public XmlValidator(Stream schemeFileStream)
        {
            SchemeFileStream = schemeFileStream;
        }

        private Stream SchemeFileStream { get; }

        public bool Validate(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException(nameof(filePath));
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return InternalValidate(stream);
            }
        }

        public bool Validate(Stream fileStream)
        {
            return InternalValidate(fileStream);
        }

        private bool InternalValidate(Stream fileStream)
        {
            bool result;
            try
            {
                var settings = new XmlReaderSettings {ValidationType = ValidationType.Schema};
                settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation |
                                            XmlSchemaValidationFlags.ReportValidationWarnings;
                settings.ValidationEventHandler += Settings_ValidationEventHandler;
                if (SchemeFileStream != null)
                    using (var schemaReader = XmlReader.Create(SchemeFileStream))
                    {
                        settings.Schemas.Add(null, schemaReader);
                    }

                var reader = XmlReader.Create(fileStream, settings);
                while (reader.Read())
                {
                }
                reader.Close();
                if (_errors > 0)
                    throw new Exception();
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                SchemeFileStream?.Close();
                fileStream.Close();
            }
            return result;
        }

        private void Settings_ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            _errors++;
            //TODO: Remove this in final
            MessageBox.Show(e.Exception.Message + "\r\n");
        }
    }
}