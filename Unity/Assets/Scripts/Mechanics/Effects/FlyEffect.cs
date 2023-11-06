using MyRI.Configs.Collectables;

namespace MyRI.Mechanics.Effects
{
    public class FlyEffect : CharacterEffect<IFlyTargetEffect, FlyBuff>
    {
        protected override void ApplyEffectInternal()
        {

        }
        protected override void RemoveEffectInternal()
        {
            
        }
        public FlyEffect(BuffData data)
            : base(data)
        {
        }
    }
}
