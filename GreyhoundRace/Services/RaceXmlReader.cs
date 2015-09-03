using System.Xml;
using System.Xml.Serialization;

namespace Services
{
    public class RaceXmlReader
    {
        public UpcomingEvents GetUpCommingEvents(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UpcomingEvents));
            UpcomingEvents events;
            using (XmlReader reader = XmlReader.Create(path))
            {
                events = (UpcomingEvents)serializer.Deserialize(reader);
            }

            return events;
        }
    }
}
