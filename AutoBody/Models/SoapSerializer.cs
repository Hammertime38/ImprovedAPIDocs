using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AutoBody.Models
{
    public class SoapSerializer
    {
        public static string SerializeToSoap<T>(object source)
        {
            var type = typeof (T).Name;
            var typeEnd = type.Contains("Request") ? "Request" : "Result";
            var rootName = type.Substring(0, type.IndexOf(typeEnd, System.StringComparison.Ordinal));

            XNamespace _5 = "http://clients.mindbodyonline.com/api/0_5";
            XNamespace soapenv = "http://schemas.xmlsoap.org/soap/envelope/";
            var envelope = new XElement(soapenv + "Envelope",
                                         new XAttribute(XNamespace.Xmlns + "soapenv",
                                                        soapenv),
                                         new XAttribute(XNamespace.Xmlns + "_5", _5),
                                         new XElement(soapenv + "Header"),
                                         new XElement(soapenv + "Body",
                                                      new XElement(_5 + rootName,
                                                                   new XElement(_5 + typeEnd))
                                             )
                );

            var child = envelope.Descendants().Elements(_5 + typeEnd).ElementAt(0);
            child.Add(ToXElement<T>(source, type));

            var stringWriter = new StringWriter();

            envelope.Save(stringWriter);
            var soapSerialized = stringWriter.GetStringBuilder().ToString();
            stringWriter.Flush();

            return soapSerialized;
        }

        public static IEnumerable<XElement> ToXElement<T>(object obj, string typeName)
        {
            var memoryStream = new MemoryStream();
            TextWriter streamWriter = new StreamWriter(memoryStream);

            var xmlSerializer = new XmlSerializer(typeof (T));
            xmlSerializer.Serialize(streamWriter, obj);

            var xElements = XElement.Parse(Encoding.ASCII.GetString(memoryStream.ToArray())).Elements();
            var elements = xElements as XElement[] ?? xElements.ToArray();

            foreach (var xElement in elements)
            {
                if(xElement.Attributes().Any())
                    xElement.Attributes().Remove();

                foreach (var descendent in xElement.Descendants())
                {
                    if (descendent.Attributes().Any())
                        descendent.Attributes().Remove();
                }
            }

            return elements;
        }
    }
}