using MyRI.Configs.Collectables;

namespace MyRI.Mechanics.Effects
{
    public abstract class EffectFactory
    {
        public static ICharacterEffect GetEffect(BuffData buff)
        {
            switch (buff.Config)
            {
                case FlyBuff:
                    return new FlyEffect(buff);
                case SpeedBuff:
                    return new ChangeSpeedEffect(buff);
                default:
                    return null;
            }
        }
    }
}
