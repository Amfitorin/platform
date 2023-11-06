using System;
using UnityEngine;

namespace MyRI.Anima2D.Scripts.Editor.VertexManipulator.RectManipulator
{
	[Serializable]
	public struct RectManipulatorParams
	{
		public Vector3 position;
		public Quaternion rotation;

		public RectManipulatorParams(Vector3 _position, Quaternion _rotation)
		{
			position = _position;
			rotation = _rotation;
		}

		public RectManipulatorParams(RectManipulatorParams p)
		{
			position = p.position;
			rotation = p.rotation;
		}
	}
}
