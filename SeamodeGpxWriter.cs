﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;

namespace SeaModeReadWrite
{
    class SeamodeGpxWriter
    {
        private XmlDocument doc;
        private XmlNode rootNode;


        public SeamodeGpxWriter()
        {
            doc = new XmlDocument();
            rootNode = doc.CreateElement("gpx");
            XmlAttribute creator = doc.CreateAttribute("creator");
            XmlAttribute xmlns = doc.CreateAttribute("xmlns");
            creator.Value = "Seamode";
            xmlns.Value = "http://www.topografix.com/GPX/1/";
            rootNode.Attributes.Append(creator);
            rootNode.Attributes.Append(xmlns);
            doc.AppendChild(rootNode);
        }
        public void writeGpx(List<GpxLine> gpxRivit)
        {
            CultureInfo cultureInfo = new CultureInfo("fi-FI");
            writeHeader();
            writeMetaData();
            // Kirjoitetaan rivit
            XmlNode trk = doc.CreateElement("trk");
            XmlNode trkseq = doc.CreateElement("trkseg");
            foreach (GpxLine gpxLine in gpxRivit)
            {
                XmlNode trkpt = doc.CreateElement("trkpt");
                XmlAttribute attrLat = doc.CreateAttribute("lat");
                XmlAttribute attrLon = doc.CreateAttribute("lon");
                attrLat.Value = gpxLine.latitude;
                attrLon.Value = gpxLine.longitude;
                trkpt.Attributes.Append(attrLat);
                trkpt.Attributes.Append(attrLon);
                XmlNode time = doc.CreateElement("time");
                // Tämä toisenlaisella muotoilulla
                time.InnerText = gpxLine.eventTime.ToString("s") + "Z";
                trkpt.AppendChild(time);
                // Ohjelma ei osannut lukea tagia
                //XmlNode speed = doc.CreateElement("speed");
                //speed.InnerText = gpxLine.speed.ToString(CultureInfo.InvariantCulture);  
                
                //trkpt.AppendChild(speed);
                trkseq.AppendChild(trkpt);
                
            }
            trk.AppendChild(trkseq);
            rootNode.AppendChild(trk);
            doc.Save(@"D:/Ohjelmointi/repos2/gpxMalli.gpx");
            Console.WriteLine("Valmis ");
        }
        private void writeHeader()
        {
            XmlDeclaration xmldecl = doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
            doc.InsertBefore(xmldecl, doc.FirstChild);
            
        }
        private void writeMetaData()
        {
            XmlNode metaData = doc.CreateElement("metadata");
            XmlNode metaDataLink = doc.CreateElement("link");
            XmlAttribute metadataLinkAttribute = doc.CreateAttribute("href");
            metadataLinkAttribute.Value = "www.baltic-instruments.com";
            metaDataLink.Attributes.Append(metadataLinkAttribute);
            XmlNode metaDataText = doc.CreateElement("text");
            XmlNode metaDataAika = doc.CreateElement("time");
            metaDataText.InnerText = "GPX model trial";
            metaDataAika.InnerText = "2019-09-28T11:30:43Z";
            metaDataLink.AppendChild(metaDataText);
            metaData.AppendChild(metaDataLink);
            metaData.AppendChild(metaDataAika);
            rootNode.AppendChild(metaData);
        }

    }
}
