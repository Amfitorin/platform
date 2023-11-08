using MyRI.Configs.Collectables;

namespace MyRI.Mechanics.Effects
{
    /// <summary>
    /// Effect modified character speed for SpeedBuff config
    /// </summary>
    public class ChangeSpeedEffect : CharacterEffect<ISpeedTargetEffect, SpeedBuff>
    {
        public ChangeSpeedEffect(BuffData data)
            : base(data)
        {
        }

        protected override void ApplyEffectInternal()
        {
            var mover = Target.Mover;
            mover.ApplySpeedModifier(Config.StaticSpeed);
        }

        protected override void RemoveEffectInternal()
        {
            var mover = Target.Mover;
            mover.ApplySpeedModifier(-Config.StaticSpeed);
        }
    }
}
