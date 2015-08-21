using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace SRPGStudio.GameObjects
{
    /// <summary>
    /// Description of Utilty.
    /// </summary>
    public static class Utility
    {
        static readonly Random s_rnd;
        public static readonly int PROPERTY_COUNT;
        public static readonly int PROFICIENCY_COUNT;
        public const int MaxItemConut = 6;
        public const int MaxSkillConut = 5;

        const char C_separator = ',';
        const string S_separator = ",";
        public const string CLASS_DEFINE = "ClassDefine";
        public const string UNIT_DEFINE = "UnitDefine";

        public const string NAME_DEFINE = "NameDefine";
        public const string DESCR_DEFINE = "DescrDefine";

        static Dictionary<string, string> s_nameDict;
        static Dictionary<string, string> s_descriptionDict;

        static Utility()
        {
            s_rnd = new Random();
            PROPERTY_COUNT = Enum.GetNames(typeof(PropertyType)).Length - 1;

            PROFICIENCY_COUNT = Enum.GetNames(typeof(Proficiency)).Length;
            //XmlDocument doc = new XmlDocument();

            //var e = doc.CreateElement("Root");
            //doc.AppendChild(e);
            //var f = doc.CreateElement("ClassNames");
            //f.SetAttribute("Count", "2");
            //var t = doc.CreateElement("Name");
            //var tt = doc.CreateTextNode("001");
            //t.AppendChild(tt);
            //f.AppendChild(t);
            //t = doc.CreateElement("Name");
            //tt = doc.CreateTextNode("002");
            //t.AppendChild(tt);
            //f.AppendChild(t);

            //e.AppendChild(f);
            //doc.Save("unity.xml");

            Init();
            //doc.Load("unity.xml");

            //XmlElement cn = doc.SelectSingleNode(ClassNames) as XmlElement;
            //int count = int.Parse(cn.GetAttribute("Count"));
            //s_classNames = new string[count];
        }

        static void Init()
        {
            s_nameDict = new Dictionary<string, string>();
            s_descriptionDict = new Dictionary<string, string>();
            if (!System.IO.File.Exists("unity.xml"))
            {
                return;
            }
            XmlDocument doc = new XmlDocument();
            doc.Load("unity.xml");
            var root = doc.DocumentElement;

            var temp = root.FirstChild;

            while (temp != null)
            {
                switch (temp.Name)
                {
                    case "Name":
                        s_nameDict.Add(temp.Attributes[0].Value, temp.InnerText);
                        break;
                    case "Description":
                        s_descriptionDict.Add(temp.Attributes[0].Value, temp.InnerText);
                        break;
                    default:
                        break;
                }
                temp = temp.NextSibling;
            }

            /* XmlElement cn = doc.SelectSingleNode(ClassNames) as XmlElement;
             InitArray(cn, out s_classNames);

             //#if ! DEBUG
             cn = doc.SelectSingleNode(UnitNames) as XmlElement;
             InitArray(cn, out s_unitNames);

             cn = doc.SelectSingleNode(ClassDescriptions) as XmlElement;
             InitArray(cn, out s_classDescription);

             cn = doc.SelectSingleNode(UnitDescriptions) as XmlElement;
             InitArray(cn, out s_unitDescription);
             //#endif
			 */
        }

        static void InitArray(XmlElement cn, out string[] array)
        {
            int count = int.Parse(cn.GetAttribute("Count"));
            array = new string[count];
            XmlNode t = cn.FirstChild;
            int i = 0;
            do
            {
                array[i++] = t.InnerText;

            } while ((t = t.NextSibling) != null);
        }

        public static bool IsHited(int rate)
        {
            return s_rnd.Next(100) < rate;
        }

        public static string GetName(string id)
        {
            return s_nameDict[id];
        }
        public static string GetDescription(string id)
        {
            return s_descriptionDict[id];
        }

        public static string ArrayToString(this int[] arr, string sep = S_separator)
        {
            if (arr.Length > 0)
            {
                StringBuilder builder = new StringBuilder(arr[0].ToString());

                int i = 1;
                while (i < arr.Length)
                {
                    builder.Append(sep);
                    builder.Append(arr[i++].ToString());
                }
                return builder.ToString();
            }
            return string.Empty;
        }
        public static int[] StringToArray(this string str, char spe = C_separator)
        {
            return str.StringToArray( PROPERTY_COUNT,spe);
        }

        public static int[] StringToArray(this string str, int count, char spe )
        {
            int[] val = new int[count];
            int t = 0, i = 0, j = 0, c = str.Length;
            while (j < c)
            {
                if (str[j] == spe)
                {
                    val[i++] = t;
                    t = 0;
                }
                else
                {
                    t = t * 10 + str[j] - 0x30;
                }
                j++;
            }
            val[i] = t;
            return val;
        }

        public static int[] XmlAttributeToArray(this XmlAttribute attr, int count, char spe = C_separator)
        {
            return attr.Value.StringToArray();
        }
        public static int[] GetArray(this XmlNode node, string attrName)
        {
            return node.Attributes[attrName].XmlAttributeToArray(PROPERTY_COUNT);
        }
        public static int[] GetArray(this XmlNode node, string attrName,int count, char spe = C_separator)
        {
            return node.Attributes[attrName].XmlAttributeToArray(count);
        }

        public static void UpdateDict(IEnumerable<Object.Class> clss)
        {
            int iname = 1;
            foreach (var element in clss)
            {
                //				if (string.IsNullOrEmpty(element.ID)) {
                //					if (!Utility.s_nameDict.ContainsValue(element.Name)) {
                //						
                //					}
                //				}
                element.ID = string.Format("CLS{0:000}", iname++);
                //if (s_nameDict.ContainsKey(element.ID))
                s_nameDict[element.ID] = element.Name;
                //else
                //    s_nameDict.Add(element.ID, element.Name);


                //if (s_descriptionDict.ContainsKey(element.ID))
                s_descriptionDict[element.ID] = element.Description;
                //else
                //    s_descriptionDict.Add(element.ID, element.Description);
            }
            XmlDocument doc = new XmlDocument();
            var root = doc.CreateElement("Root");
            XmlElement temp;
            foreach (var item in s_nameDict)
            {
                temp = doc.CreateElement(Utility.NAME_DEFINE);
                temp.SetAttribute("ID", item.Key);
                temp.AppendChild(doc.CreateTextNode(item.Value));
                root.AppendChild(temp);
            }
            foreach (var item in s_descriptionDict)
            {
                temp = doc.CreateElement(Utility.DESCR_DEFINE);
                temp.SetAttribute("ID", item.Key);
                temp.AppendChild(doc.CreateTextNode(item.Value));
                root.AppendChild(temp);
            }
            doc.AppendChild(root);
            doc.Save("unity.xml");

        }
        #region "Formula"



        #endregion
    }
}
