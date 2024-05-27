using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private RectTransform                       screensContainer      = null;
    [SerializeField] private GameObject                          cameraObject          = null;
    [SerializeField] private CollectableItemsConfig              collectablesConfig    = null;
    [SerializeField] private EnvironmentItemsRandomizationConfig randomizationConfig   = null;
    [SerializeField] private RunnerCharacterConfig               characterConfig       = null;
    [SerializeField] private RunnerEnvironmentTreadmillConfig    treadmillConfig       = null;
    [SerializeField] private RunnerGameplayManagerConfig         gameplayManagerConfig = null;
    [SerializeField] private CameraSettingsConfig                cameraSettingsConfig  = null;
    [SerializeField] private GameplayPrefabsPathsConfig          gameplayPathsConfig   = null;

    private const string SCREENS_MODEL_GROUP         = "ScreensModelGroup";
    private const string ENVIRONMENT_TREADMILL_GROUP = "TreadmillContainer";
    private const string OBSTACLES_GROUP             = "ObstaclesGroup";
    private const string COLLECTABLES_GROUP          = "CollectablesGroup";

    private const string HUD_SCREEN_PATH       = "GameScene/HUDScreen";
    private const string GAME_OVER_SCREEN_PATH = "GameScene/GameOverScreen";


    public override void InstallBindings()
    {
        InstallSignals();

        InstallConfigs();
        InstallGameplayDependencies();

        InstallHUDScreen();
        InstallGameOverScreen();
    }

    private void InstallSignals()
    {
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<InteractedWithCollectableSignal>();
        Container.DeclareSignal<InteractedWithObstacleSignal>();
    }

    private void InstallConfigs()
    {
        Container.Bind<EnvironmentItemsRandomizationConfig>().FromScriptableObject(randomizationConfig).AsSingle().NonLazy();
        Container.Bind<CollectableItemsConfig>().FromScriptableObject(collectablesConfig).AsSingle().NonLazy();
        Container.Bind<RunnerCharacterConfig>().FromScriptableObject(characterConfig).AsSingle().NonLazy();
        Container.Bind<RunnerEnvironmentTreadmillConfig>().FromScriptableObject(treadmillConfig).AsSingle().NonLazy();
        Container.Bind<RunnerGameplayManagerConfig>().FromScriptableObject(gameplayManagerConfig).AsSingle().NonLazy();
        Container.Bind<CameraSettingsConfig>().FromScriptableObject(cameraSettingsConfig).AsSingle().NonLazy();
    }

    private void InstallGameplayDependencies()
    {
        Container.Bind<RunnerProgressManager>().AsSingle().NonLazy();
        Container.Bind<RunnerGameplayManager>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        Container.Bind<CameraManager>().FromNewComponentOn(cameraObject).AsSingle().NonLazy();
        Container.Bind<Camera>().FromComponentOn(cameraObject).AsSingle().NonLazy();

        Container.Bind<EnvironmentTreadmillBase>().To<RunnerEnvironmentTreadmill>().AsSingle().NonLazy();

        Container.Bind<CharacterControlBase>().To<CharacterButtonsInputControl>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        Container.Bind<CharacterModelBase>().To<CharacterModel>().FromComponentInNewPrefabResource(gameplayPathsConfig.characterModelDirectory).AsSingle().NonLazy();
        Container.Bind<CharacterViewBase>().To<CharacterView>()
            .FromComponentInNewPrefabResource(gameplayPathsConfig.characterViewDirectory)
            .UnderTransform(GetCharacterViewParentTransform)
            .AsCached().NonLazy();

        Container.BindMemoryPool<EnvironmentBlockModelBase, EnvironmentBlocksPool>()
            .WithInitialSize(3).To<RunnerEnvironmentBlockModel>()
            .FromComponentInNewPrefabResource(gameplayPathsConfig.environmentBlockDirectory)
            .UnderTransformGroup(ENVIRONMENT_TREADMILL_GROUP)
            .NonLazy();

        Container.BindMemoryPool<ObstacleItemModel, ObstacleItemModel.Pool>()
            .WithInitialSize(10)
            .FromComponentInNewPrefabResource(gameplayPathsConfig.obstacleDirectory)
            .UnderTransformGroup(OBSTACLES_GROUP)
            .NonLazy();

        Container.BindMemoryPool<CollectableItemModel, CollectableItemModel.Pool>()
            .WithInitialSize(10)
            .FromComponentInNewPrefabResource(gameplayPathsConfig.collectableDirectory)
            .UnderTransformGroup(COLLECTABLES_GROUP)
            .NonLazy();
    }

    private void InstallHUDScreen()
    {
        Container.Bind<UIModelBase>().To<HUDScreenUIModelBase>().FromResolve().NonLazy();
        Container.Bind<HUDScreenUIModelBase>().To<HUDScreenUIModel>().FromNewComponentOnNewGameObject().UnderTransformGroup(SCREENS_MODEL_GROUP).AsSingle().NonLazy();
        Container.Bind<HUDScreenUIPresenterBase>().To<HUDScreenUIPresenter>().AsSingle().NonLazy();

        Container.Bind<HUDScreenUIViewBase>().To<HUDScreenUIView>()
            .FromComponentInNewPrefabResource(HUD_SCREEN_PATH)
            .UnderTransform(screensContainer)
            .AsSingle().NonLazy();
    }

    private void InstallGameOverScreen()
    {
        Container.Bind<UIModelBase>().To<GameOverScreenUIModelBase>().FromResolve().NonLazy();
        Container.Bind<GameOverScreenUIModelBase>().To<GameOverScreenUIModel>().FromNewComponentOnNewGameObject().UnderTransformGroup(SCREENS_MODEL_GROUP).AsSingle().NonLazy();
        Container.Bind<GameOverScreenUIPresenterBase>().To<GameOverScreenUIPresenter>().AsSingle().NonLazy();

        Container.Bind<GameOverScreenUIViewBase>().To<GameOverScreenUIView>()
            .FromComponentInNewPrefabResource(GAME_OVER_SCREEN_PATH)
            .UnderTransform(screensContainer)
            .AsSingle().NonLazy();
    }


    private Transform GetCharacterViewParentTransform(InjectContext context)
    {
        if (context.ObjectInstance is Component component)
            return component.transform;

        Debug.LogError("Character view cannot be injected under model transform!");
        return null;
    }
}