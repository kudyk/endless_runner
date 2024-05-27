using System.Collections.Generic;
using Zenject;

public class CharacterModel : CharacterModelBase
{
    private RunnerCharacterConfig characterConfig = null;


    [Inject]
    private void Construct(RunnerCharacterConfig characterConfig)
    {
        this.characterConfig = characterConfig;
    }

    protected override Dictionary<CharacterAvailableStates, CharacterState> AvailableStates => new()
    {
        { CharacterAvailableStates.IDLE, new CharacterIdleState(this, view) },
        { CharacterAvailableStates.RUNNING, new CharacterMovingState(characterConfig, this, view) },
        { CharacterAvailableStates.DEAD, new CharacterDeadState(this, view) },
    };
}