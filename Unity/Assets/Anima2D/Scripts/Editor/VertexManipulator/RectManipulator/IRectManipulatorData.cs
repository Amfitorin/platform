using System.Collections.Generic;
using UnityEngine;

namespace MyRI.Anima2D.Scripts.Editor.VertexManipulator.RectManipulator
{
	public interface IRectManipulatorData
	{
		List<Vector3> normalizedVertices { get; set; }
	}
}
