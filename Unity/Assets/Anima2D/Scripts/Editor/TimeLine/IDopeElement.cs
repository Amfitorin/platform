namespace MyRI.Anima2D.Scripts.Editor.TimeLine
{
	public interface IDopeElement
	{
		float time { get; set; }

		void Flush();
	}
}
