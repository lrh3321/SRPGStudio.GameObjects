using System;
using System.Collections.Generic;

namespace SRPGStudio.GameObjects
{
	/// <summary>
	/// Description of MovePoint.
	/// </summary>
	public class MovePoint : IEquatable<MovePoint>,IComparable<MovePoint>//,IEnumerable<MovePoint>
	{
		public class MovePointEmumer:IEnumerable<MovePoint>{
			private MovePoint Parent;
			
			public MovePointEmumer(MovePoint parent)
			{
				this.Parent = parent;
			}
			
			private IEnumerator<MovePoint> _GetEnumerator()
			{
				yield return new MovePoint(Parent.Location.X+1,Parent.Location.Y,Parent.Move){Parent=Parent};
				yield return new MovePoint(Parent.Location.X,Parent.Location.Y+1,Parent.Move){Parent=Parent};
				yield return new MovePoint(Parent.Location.X-1,Parent.Location.Y,Parent.Move){Parent=Parent};
				yield return new MovePoint(Parent.Location.X,Parent.Location.Y-1,Parent.Move){Parent=Parent};
			}
			
			public IEnumerator<MovePoint> GetEnumerator()
			{
				return this._GetEnumerator();
			}
			
			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			{
				return this._GetEnumerator();
			}
		}
		public MovePointEmumer MoveAround{get{return new MovePointEmumer(this);}}
		
		public MovePoint(int x,int y,int move):this(new Point2D(x,y),move){}
		
		public Point2D Location{get;set;}
		
		public int Move{get;set;}
		
		public List<MovePoint> Points{get;private set;}
		
		public MovePoint Parent{get;set;}

		public MovePoint():this( Point2D.Empty, 0)
		{
		}
		
		public MovePoint(Point2D location, int move)
		{
			this.Location = location;
			this.Move = move;
		}
		
		public MovePoint(Point2D location):this(location,0){}
		
		#region Equals and GetHashCode implementation

		public override bool Equals(object obj)
		{
			if (obj is MovePoint)
				return Equals((MovePoint)obj); // use Equals method below
			else
				return false;
		}
		
		public bool Equals(MovePoint other)
		{
			if (other==null) {
				return false;
			}
			return (this.Location == other.Location)&&(this.Move == other.Move);
		}
		
		public bool PointEquals(MovePoint other)
		{
			return (this.Location == other.Location);
		}
		
		public override int GetHashCode()
		{
			return this.Location.GetHashCode()^ this.Move.GetHashCode();
		}
				
		public int CompareTo(MovePoint other){
			return this.Move.CompareTo(other.Move);
		}
		
		#endregion
	}
}