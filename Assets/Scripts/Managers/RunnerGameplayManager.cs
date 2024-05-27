using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class RunnerGameplayManager : MonoBehaviour
{
    private bool                        isMoving        = false;
    private SignalBus                   signalBus       = null;
    private ScreensManager              screensManager  = null;
    private GameSavesManager            savesManager    = null;
    private RunnerProgressManager       progressManager = null;
    private CameraSettingsConfig        cameraSettings  = null;
    private CameraManager               cameraManager   = null;
    private RunnerGameplayManagerConfig managerConfig   = null;
    private CharacterModelBase          characterModel  = null;
    private EnvironmentTreadmillBase    treadmill       = null;


    [Inject]
    private void Construct(SignalBus signalBus, CharacterModelBase characterModel, EnvironmentTreadmillBase treadmill, CameraManager cameraManager, CameraSettingsConfig cameraSettings,
        ScreensManager screensManager, GameSavesManager savesManager, RunnerProgressManager progressManager, RunnerGameplayManagerConfig managerConfig)
    {
        this.signalBus       = signalBus;
        this.treadmill       = treadmill;
        this.characterModel  = characterModel;
        this.cameraManager   = cameraManager;
        this.cameraSettings  = cameraSettings;
        this.screensManager  = screensManager;
        this.savesManager    = savesManager;
        this.progressManager = progressManager;
        this.managerConfig   = managerConfig;
    }

    private void OnEnable()
    {
        signalBus.Subscribe<InteractedWithCollectableSignal>(HandleInteractionWIthAward);
        signalBus.Subscribe<InteractedWithObstacleSignal>(HandleInteractionWithBarrier);
    }

    private void OnDisable()
    {
        signalBus.Unsubscribe<InteractedWithCollectableSignal>(HandleInteractionWIthAward);
        signalBus.Unsubscribe<InteractedWithObstacleSignal>(HandleInteractionWithBarrier);
    }

    private IEnumerator Start()
    {
        isMoving = false;
        cameraManager.InitCameraSettings(cameraSettings);
        screensManager.OpenScreen(typeof(HUDScreenUIModel));

        characterModel.InitState(CharacterAvailableStates.IDLE);
        treadmill.Init(managerConfig.firstEmptyBlocksCount);

        yield return new WaitForSeconds(managerConfig.waitSecondsBeforeStart);

        characterModel.InitState(CharacterAvailableStates.RUNNING);
        isMoving = true;
    }

    private void Update()
    {
        if (!isMoving)
            return;

        treadmill.UpdateTreadmill(managerConfig.movementSpeed);
        characterModel.UpdateMovementSpeedState(managerConfig.movementSpeed);
    }

    public void SaveCurrentAttemptProgress()
    {
        savesManager.SaveNewAttempt(DateTime.Now, progressManager.GetTotalPrice());
    }

    private void HandleInteractionWIthAward(InteractedWithCollectableSignal signal)
    {
        progressManager.IncrementCount(signal.collectableType);
    }

    private void HandleInteractionWithBarrier()
    {
        SetGameOverState();
    }

    private void SetGameOverState()
    {
        isMoving = false;
        characterModel.InitState(CharacterAvailableStates.DEAD);
        screensManager.OpenScreen(typeof(GameOverScreenUIModel));
    }
}