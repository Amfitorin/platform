using MyRI.Configs.Collectables;

namespace MyRI.Mechanics.Effects
{
    
    /// <summary>
    /// factory for create buff effect for buff config
    /// </summary>
    public abstract class EffectFactory
    {
        /// <summary>
        /// method for creating effect from buff config type
        /// </summary>
        /// <param name="buff"> buff data to effect</param>
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
