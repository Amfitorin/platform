using System;
using UnityEngine;

namespace MyRI.Anima2D.Scripts.Editor 
{
	[Serializable]
	public class Hole : ICloneable
	{
		public Vector2 vertex = Vector2.zero;

		public Hole(Vector2 vertex)
		{
			this.vertex = vertex;
		}

		public object Clone()
		{
			return this.MemberwiseClone();
		}

		public static implicit operator bool(Hole h)
		{
			return h != null;
		}
	}
}
