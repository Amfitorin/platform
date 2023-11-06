using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace MyRI.Extensions
{
    public static class AnimationExtensions
    {
        private static AnimationAwaiter GetAwaiter(this Animation anim)
        {
            return new AnimationAwaiter(anim);
        }

        public static TweenAwaiter GetAwaiter(this Tween anim)
        {
            return new TweenAwaiter(anim);
        }

        public static TweenAwaiter GetAwaiter(this Sequence anim)
        {
            if (!anim.IsPlaying())
            {
                anim.Play();
            }
            return new TweenAwaiter(anim);
        }

        public static async Task Play(this Animation anim, string clipName)
        {
            anim.Play(clipName);
            await anim;
        }

        public static async Task Play(this Animation anim, AnimationClip clip)
        {
            anim.Play(clip.name);
            await anim;
        }
    }

    public class AnimationAwaiter : INotifyCompletion
    {
        private readonly Animation _animation;
        private Action _continuation;
        private IDisposable _timerToken;

        public bool IsCompleted => !_animation.isPlaying;
        public string GetResult() => _animation.name;

        public AnimationAwaiter(Animation animation)
        {
            _animation = animation;
            _continuation = null;
        }

        public void OnCompleted(Action continuation)
        {
            _continuation = continuation;
            _timerToken = Observable.EveryLateUpdate().Subscribe((_) => CheckAnim());
            CheckAnim();
        }
        private void CheckAnim()
        {
            if (_animation != null && _animation.isPlaying)
                return;
            _timerToken.Dispose();
            _continuation();
        }
    }

    public class TweenAwaiter : INotifyCompletion
    {
        private readonly Tween _animation;
        private Action _continuation;

        public bool IsCompleted => false;
        public string GetResult() => _animation.stringId;

        public TweenAwaiter(Tween animation)
        {
            _animation = animation;
            _continuation = null;
        }

        public void OnCompleted(Action continuation)
        {
            _continuation = continuation;
            _animation.OnComplete(() =>
            {
                _continuation();
            });
        }
    }
}
