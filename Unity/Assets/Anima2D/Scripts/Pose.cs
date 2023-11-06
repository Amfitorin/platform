using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyRI.Anima2D.Scripts
{
	public class Pose : ScriptableObject
	{
		[Serializable]
		public class PoseEntry
		{
			public string path;
			public Vector3 localPosition;
			public Quaternion localRotation;
			public Vector3 localScale;
		}

		[SerializeField]
		List<PoseEntry> m_PoseEntries;
	}
}
