using System.Collections.Generic;
using UnityEngine;

namespace MyRI.Anima2D.Scripts
{
	public class PoseManager : MonoBehaviour
	{
		[SerializeField][HideInInspector]
		List<Pose> m_Poses;
	}
}
