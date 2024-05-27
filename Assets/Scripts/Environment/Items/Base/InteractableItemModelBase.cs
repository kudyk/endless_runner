using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public abstract class InteractableItemModelBase : MonoBehaviour
{
    [SerializeField] protected InteractableItemViewBase[] availableViews = null;

    protected bool                     haveInteracted = false;
    protected SignalBus                signalBus      = null;
    protected InteractableItemViewBase currentView    = null;


    [Inject]
    private void Construct(SignalBus signalBus)
    {
        this.signalBus = signalBus;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (!haveInteracted && !other.CompareTag("Player"))
            return;

        haveInteracted = true;
        ProcessInteraction();
    }

    protected abstract void ProcessInteraction();

    protected virtual void Init()
    {
        if (availableViews == null || availableViews.Length == 0)
            throw new Exception($"{nameof(InteractableItemModelBase)} {gameObject.name} doesn't have any view!");

        currentView = availableViews[Random.Range(0, availableViews.Length)];
        currentView?.Init();
        haveInteracted = false;
    }

    protected virtual void Deinit()
    {
        currentView.Deinit();
        haveInteracted = false;
    }
}