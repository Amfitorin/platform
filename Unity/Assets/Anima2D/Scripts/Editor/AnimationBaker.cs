using UnityEditor;

namespace MyRI.Anima2D.Scripts.Editor
{
	public class AnimationBaker
	{
		[MenuItem("Window/Anima2D/Bake Animation", true)]
		static bool BakeAnimationValidate()
		{
			return AnimationWindowExtra.AnimationWindowExtra.animationWindow &&
				AnimationWindowExtra.AnimationWindowExtra.activeAnimationClip &&
					AnimationWindowExtra.AnimationWindowExtra.rootGameObject;
		}
		
		[MenuItem("Window/Anima2D/Bake Animation", false, 10)]
		static void BakeAnimation()
		{
			if(!BakeAnimationValidate())
			{
				return;
			}
			
			int currentFrame = AnimationWindowExtra.AnimationWindowExtra.frame;
			
			AnimationWindowExtra.AnimationWindowExtra.recording = true;
			
			int numFrames = (int)(AnimationWindowExtra.AnimationWindowExtra.activeAnimationClip.length * AnimationWindowExtra.AnimationWindowExtra.activeAnimationClip.frameRate);
			
			bool cancel = false;
			
			AnimationWindowExtra.AnimationWindowExtra.frame = 1;
			EditorUpdater.Update("", false);
			
			for(int i = 0; i <= numFrames; ++i)
			{
				if(EditorUtility.DisplayCancelableProgressBar("Baking animation: " + AnimationWindowExtra.AnimationWindowExtra.activeAnimationClip.name,
				                                              "Frame " + i, (float)(i+1) / (float)(numFrames+1)))
				{
					cancel = true;
					break;
					
				}else{
					AnimationWindowExtra.AnimationWindowExtra.frame = i;
					EditorUpdater.Update("Bake animation", true);
					Undo.FlushUndoRecordObjects();
				}
			}
			
			EditorUtility.ClearProgressBar();
			
			if(cancel)
			{
				Undo.RevertAllDownToGroup(Undo.GetCurrentGroup());
			}
			
			AnimationWindowExtra.AnimationWindowExtra.frame = currentFrame;
			
			AnimationWindowExtra.AnimationWindowExtra.recording = false;
			
			EditorUpdater.Update("", false);
		}
	}
}
