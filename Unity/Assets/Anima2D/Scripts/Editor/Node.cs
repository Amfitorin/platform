using System;
using UnityEngine;

namespace MyRI.Anima2D.Scripts.Editor 
{
	[Serializable]
	public class Node : ScriptableObject
	{
		public int index = -1;

		public static Node Create(int index)
		{
			Node node = ScriptableObject.CreateInstance<Node>();
			node.hideFlags = HideFlags.DontSave;
			node.index = index;
			return node;
		}
	}
}
