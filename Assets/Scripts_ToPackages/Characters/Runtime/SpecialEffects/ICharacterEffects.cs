namespace ActionCode.Characters
{
    /// <summary>
    /// Interface used on objects able to have Character Effects.
    /// </summary>
    public interface ICharacterEffects 
    {
        /// <summary>
        /// Plays the left footstep effect.
        /// </summary>
        void PlayLeftFootstep();
        
        /// <summary>
        /// Plays the right footstep effect.
        /// </summary>
        void PlayRightFootstep();
        
        /// <summary>
        /// Plays the jump effect.
        /// </summary>
        void PlayJump();
        
        /// <summary>
        /// Plays the land effect.
        /// </summary>
        void PlayLand();
        
        /// <summary>
        /// Plays the given effect.
        /// </summary>
        /// <param name="effect">A effect name to play.</param>
        void PlayCustom(string effect);
    }
}