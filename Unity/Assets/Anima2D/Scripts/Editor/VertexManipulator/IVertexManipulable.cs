using UnityEngine;

namespace MyRI.Anima2D.Scripts.Editor.VertexManipulator
{
	public interface IVertexManipulable
	{
		int GetManipulableVertexCount();
		Vector3 GetManipulableVertex(int index);
		void SetManipulatedVertex(int index, Vector3 vertex);
	}
}
