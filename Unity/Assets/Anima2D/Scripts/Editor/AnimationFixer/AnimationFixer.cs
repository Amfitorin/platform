#if UNITY_5_4_OR_NEWER
using UnityEditor;
using UnityEngine;

namespace MyRI.Anima2D.Scripts.Editor.AnimationFixer
{
	[InitializeOnLoad]
	public class AnimationFixer
	{
		static AnimationFixer()
		{
			AnimationUtility.onCurveWasModified += OnCurveWasModified;
		}

		static void OnCurveWasModified(AnimationClip clip, EditorCurveBinding binding, AnimationUtility.CurveModifiedType deleted)
		{
			AnimationUtility.onCurveWasModified -= OnCurveWasModified;

			bool flag = Event.current == null || 
						(Event.current != null && Event.current.type != EventType.ExecuteCommand);

			var rootGameOject = AnimationWindowExtra.AnimationWindowExtra.rootGameObject;

			if(flag &&
			   rootGameOject &&
			   deleted == AnimationUtility.CurveModifiedType.CurveModified &&
			   binding.type == typeof(Transform) &&
			   binding.propertyName.Contains("localEulerAnglesRaw")) 
			{
				Transform transform = AnimationWindowExtra.AnimationWindowExtra.rootGameObject.transform.Find(binding.path);
				Vector3 eulerAngles = BoneUtils.GetLocalEulerAngles(transform);

				int frame = AnimationWindowExtra.AnimationWindowExtra.frame;

				AnimationCurve curve = AnimationUtility.GetEditorCurve(clip,binding);

				for (int i = 0; i < curve.length; i++)
				{
					Keyframe keyframe = curve[i];

					int keyframeFrame = (int)AnimationWindowExtra.AnimationWindowExtra.TimeToFrame(keyframe.time);

					if(frame == keyframeFrame)
					{
						if(binding.propertyName.Contains(".x"))
						{
							if(keyframe.value != eulerAngles.x)
							{
								//Debug.Log(binding.propertyName + "  " + keyframe.value + " -> " + eulerAngles.x.ToString());

								keyframe.value = eulerAngles.x;
							}
							
						}else if(binding.propertyName.Contains(".y"))
						{
							if(keyframe.value != eulerAngles.y)
							{
								//Debug.Log(binding.propertyName + "  " + keyframe.value + " -> " + eulerAngles.y.ToString());

								keyframe.value = eulerAngles.y;
							}
							
						}else if(binding.propertyName.Contains(".z"))
						{
							if(keyframe.value != eulerAngles.z)
							{
								//Debug.Log(binding.propertyName + "  " + keyframe.value + " -> " + eulerAngles.z.ToString());

								keyframe.value = eulerAngles.z;
							}
						}

						curve.MoveKey(i,keyframe);

						CurveUtility.UpdateTangentsFromModeSurrounding(curve,i);

						break;
					}
				}

				AnimationUtility.SetEditorCurve(clip,binding,curve);
			}

			AnimationUtility.onCurveWasModified += OnCurveWasModified;
		}
	}
}
#endif
