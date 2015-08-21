/*
 * 由SharpDevelop创建。
 * 用户： LRH3321
 * 日期: 2015-5-6
 * 时间: 11:05
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Xml.Serialization;
using SSEditor;

namespace SRPGStudio.GameObjects
{
    /// <summary>
    /// Description of Class.
    /// </summary>
    [XmlRoot("Class")]
    public class Class
    {
        public Class() : this("新建职业")
        {
        }

        public Class(string name)
        {
            Name = name;
            this.propertyBasic = new int[Utility. PROPERTY_COUNT];
            this.propertyLimit = new int[Utility.PROPERTY_COUNT];
            for (int i = 0; i < Utility.PROPERTY_COUNT; i++)
            {
                propertyLimit[i] = 20;
            }
            this.propertyLimit[(int)PropertyType.Lucky] = 40;
            this.growRate = new int[Utility.PROPERTY_COUNT];

            this.Proficiencies = new int[Utility.PROFICIENCY_COUNT];
            this.Type = ClassTypes.Infantry;
            //this.growRate[(int)PropertyType.Lucky] = 0;
            //this.growRate[(int)PropertyType.Lucky] = 0;
        }

        //public const int PROPERTY_COUNT = 9;
        public string ID { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }
        
        [XmlArray("Basic"),XmlArrayItem("item",typeof(int))]
        public int[] propertyBasic;
        
        [XmlArray("Limit"),XmlArrayItem("item",typeof(int))]
        public int[] propertyLimit;
       
        [XmlArray("Rate"),XmlArrayItem("item",typeof(int))]
        public int[] growRate;

        [XmlArray("Proficiencie"),XmlArrayItem("item",typeof(int))]
        public int[] Proficiencies { get; set; }

        [XmlElement("ClassTypes",typeof(ClassTypes))]
        public ClassTypes Type { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }

}
