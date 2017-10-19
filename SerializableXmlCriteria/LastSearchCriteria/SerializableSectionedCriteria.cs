using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LastSearchCriteria
{
    public abstract class SerializableSectionedCriteria
    {
        protected SectionedCriteriaSerializer criteriaSerializer;
        public SerializableSectionedCriteria(SectionedCriteriaSerializer criteriaSerializer)
        {
            if (criteriaSerializer == null)
                throw new ArgumentNullException("Serializer must be provided.");

            this.criteriaSerializer = criteriaSerializer;
        }

        public SerializableSectionedCriteria(string xml, SectionedCriteriaSerializer criteriaSerializer) : this(criteriaSerializer)
        {
            XElement element = XElement.Parse(xml);
            DeserializeCriteriaSection(element);
        }

        protected T DeserializeSection<T>(XElement rootElement) where T : class
        {
            return criteriaSerializer.Deserialize<T>(rootElement);
        }

        protected void SerializeSection<T>(T section, XElement rootElement) where T : class
        {
            rootElement.Add(criteriaSerializer.Serialize(section));
        }

        protected abstract void DeserializeCriteriaSection(XElement rootElement);
        protected abstract void SerializeCriteriaSections(XElement rootElement);

        public string Serialize()
        {
            XElement element = new XElement(this.GetType().Name);
            SerializeCriteriaSections(element);

            return element.ToString();
        }

    }
}
