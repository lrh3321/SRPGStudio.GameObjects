using System;
using System.Collections.Generic;

namespace SRPGStudio.GameObjects
{
	public struct Point2D: IEquatable<Point2D>
	{
		public int X;
		
		public int Y;
		
		public Point2D(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}
		
		public static readonly Point2D Empty=new Point2D(0,0);
		
		#region Equals and GetHashCode implementation

		public override bool Equals(object obj)
		{
			if (obj is Point2D)
				return Equals((Point2D)obj); // use Equals method below
			else
				return false;
		}
		
		public bool Equals(Point2D other)
		{
			return (this.X == other.X)&&(this.Y == other.Y);
		}
		
		
		public override int GetHashCode()
		{
			return this.X.GetHashCode() ^ this.Y.GetHashCode();
		}
		
		public static bool operator ==(Point2D left, Point2D right)
		{
			return left.Equals(right);
		}
		
		public static bool operator !=(Point2D left, Point2D right)
		{
			return !left.Equals(right);
		}
		
		#endregion
	}
	/// <summary>
	/// Description of MovePointList.
	/// </summary>
	public class WayFinder
	{
		Dictionary<Point2D,MovePoint> _arrayList;
		public WayFinder(Point2D start, int mov):this(new MovePoint(start),mov){}
		
		public WayFinder(MovePoint start, int mov)
		{
			this.Start = start;
			this.Mov = mov;
			_arrayList=new Dictionary<Point2D,MovePoint>(1+2*mov*(mov+1));
			//_arrayList.Add(start.Location,start);
		}
		
		public ICollection<MovePoint> Area{get{return this._arrayList.Values;}}
		
		public IEnumerable<MovePoint> RouteTo(Point2D p){
			if (!_arrayList.ContainsKey(p)) {
				return null;
			}
			Stack<MovePoint> temp=new Stack<MovePoint>();
			MovePoint mp=_arrayList[p];
			temp.Push(mp);
			while (mp.Parent!=null) {
				temp.Push(mp.Parent);
				mp=mp.Parent;
			}
			return temp;
		}
		
		public void Move(){
			if (Map!=null) {
				_arrayList.Clear();
				_arrayList.Add(Start.Location,Start);
				Queue<MovePoint> temp=new Queue<MovePoint>();
				for (int i = 0; i < Mov; i++) {
					foreach (var element in _arrayList.Values) {
						if (element.Move==i) {
							foreach (var item in element.MoveAround) {
								if (item.Location.X<0||item.Location.Y<0
								    ||item.Location.X>=this.Width||item.Location.Y>=this.Height)
								{
									continue;
								}
								
								item.Move+=m_map[item.Location];
								if ((item.Move<=this.Mov)&&(!temp.Contains(item))) {
									temp.Enqueue(item);
								}
							}
						}
					}
					this.AddRange(temp);
					temp.Clear();
				}
			}
		}
		public void Add(MovePoint mp){
			if (this._arrayList.ContainsKey(mp.Location)) {
				if (this._arrayList[mp.Location].CompareTo(mp)>0) {
					this._arrayList[mp.Location]=mp;
				}
			}else{
				this._arrayList.Add(mp.Location,mp);
			}
		}
		
		public void AddRange(IEnumerable<MovePoint> mps){
			foreach (var element in mps) {
				this.Add(element);
			}
		}
		
		public IMapProvid m_map;
		public IMapProvid Map{
			get{
				return m_map;
			}
			set{
				m_map=value;
				if (value!=null) {
					Width=value.Width;
					Height=value.Height;
				};
			}
		}
		
		public int Width;
		public int Height;
		
		public MovePoint Start;
		public int Mov;
	}
}
