﻿using UnityEditor;
using UnityEngine;

namespace MyRI.Anima2D.Scripts.Editor.AnimationWindowExtra
{
	public interface IAnimationWindowImpl
	{
		EditorWindow animationWindow { get; }
		int frame { get; set; }
		bool recording { get; set; }
		AnimationClip activeAnimationClip { get; }
		GameObject activeGameObject { get; }
		GameObject rootGameObject { get; }
		int refresh { get; }
		float currentTime { get; }
		bool playing { get; }

		void InitializeReflection();
		float FrameToTime(int frame);
		float TimeToFrame(float time);
	}
}
