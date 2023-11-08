using MyRI.Configs.Collectables;

namespace MyRI.Mechanics.Effects
{
    /// <summary>
    /// Character effect for Fly buff config
    /// </summary>
    public class FlyEffect : CharacterEffect<IFlyTargetEffect, FlyBuff>
    {
        public FlyEffect(BuffData data)
            : base(data)
        {
        }
        protected override void ApplyEffectInternal()
        {

        }
        protected override void RemoveEffectInternal()
        {

        }
    }
}
