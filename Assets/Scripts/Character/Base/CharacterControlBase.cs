using UnityEngine;
using Zenject;

public abstract class CharacterControlBase : MonoBehaviour
{
    protected CharacterModelBase model = null;
    protected CharacterViewBase  view  = null;

    
    [Inject]
    private void Construct(CharacterModelBase model, CharacterViewBase view)
    {
        this.model = model;
        this.view  = view;
    }
}