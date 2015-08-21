/*
 * 由SharpDevelop创建。
 * 用户： LRH3321
 * 日期: 2015-8-18
 * 时间: 15:55
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace SRPGStudio.GameObjects
{
	/// <summary>
	/// Description of ClassCollection.
	/// </summary>
	[
		XmlRoot("ClassCollection")
	]
	public class ClassCollection:ObservableCollection<Class>
	{
		//XmlArray("Items",typeof(Class))
		public ClassCollection()
		{
			
		}
		
		
	}
}
