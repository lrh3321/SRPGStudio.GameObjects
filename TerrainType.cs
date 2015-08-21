/*
 * 由SharpDevelop创建。
 * 用户： LRH3321
 * 日期: 2015-5-14
 * 时间: 9:00
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace SRPGStudio.GameObjects
{
	/// <summary>地形类型</summary>
	public enum TerrainType
	{
		/// <summary>空</summary>
		Air,
		/// <summary>平原</summary>
		Plain,
		/// <summary>墙</summary>
		Wall,
		/// <summary>林</summary>
		Forest,
        /// <summary>村</summary>
        Village,
        /// <summary>城</summary>
        Town,
        /// <summary>柱</summary>
        Pillar,
        /// <summary>海</summary>
        Sea,
		/// <summary>海滩</summary>
        Beach,
        /// <summary>废墟</summary>
        Ruins,
        /// <summary>小山</summary>
        Hill,
		/// <summary>高山</summary>
		Mountain,
		/// <summary>城门</summary>
		Gate,
		/// <summary>王座</summary>
		Throne
	}
}
