/*
 * 由SharpDevelop创建。
 * 用户： LRH3321
 * 日期: 2015-5-14
 * 时间: 9:21
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace SRPGStudio.GameObjects
{
	/// <summary>
	/// Description of IMapProvid.
	/// </summary>
	public interface IMapProvid
	{
		int this[int x,int y]{get;}
		int this[Point2D p]{get;}
		
		int Width{get;set;}
		int Height{get;set;}
	}
	
	public class MapProvid:IMapProvid{
		
		public MapProvid(int width, int heigh)
		{
			this.width = width;
			this.heigh = heigh;
		}
		public int this[int x,int y]{
			get{
				if ((x==10)&&(y>8)) {
					return 2;
				}
				return 1;}}
		
		public int this[Point2D p]{get{return this[p.X,p.Y];}}
		
		protected int width,heigh;
		
		public int Width {
			get {
				return width;
			}
			set {
				width=value;
			}
		}
		
		public int Height {
			get {
				return heigh;
			}
			set {
				heigh=value;
			}
		}
	}
}
