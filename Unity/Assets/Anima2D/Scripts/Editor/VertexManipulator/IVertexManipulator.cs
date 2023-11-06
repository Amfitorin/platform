namespace MyRI.Anima2D.Scripts.Editor.VertexManipulator
{
	public interface IVertexManipulator
	{
		void AddVertexManipulable(IVertexManipulable vertexManipulable);
		void Clear();
		void DoManipulate();
	}
}
