namespace ActionCode.Characters
{
    /// <summary>
    /// Interface used on objects able to be a Character.
    /// </summary>
    public interface ICharacter 
    {
        CharacterMotor Motor { get; }
        CharacterAnimator Animator { get; }
        CharacterLimbManager LimbManager { get; }
    }
}