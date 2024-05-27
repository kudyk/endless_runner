using UnityEngine;
using Zenject;

public class MainMenuSceneInstaller : MonoInstaller<MainMenuSceneInstaller>
{
    [SerializeField] private RectTransform screensContainer = null;

    private const string SCREENS_MODEL_GROUP     = "ScreensModelGroup";
    private const string MAIN_SCREEN_PATH        = "MainMenuScene/MainMenuScreen";
    private const string LEADERBOARD_SCREEN_PATH = "MainMenuScene/LeaderboardScreen";
    private const string UI_SCORE_ITEM_PATH      = "UIItems/UIScoreItem";


    public override void InstallBindings()
    {
        InstallMainMenuScreen();
        InstallLeaderboardScreen();

        InstallItems();
        InstallManagers();
    }

    private void InstallItems()
    {
        Container.BindFactory<UIScoreItem, UIScoreItem.Factory>()
            .FromComponentInNewPrefabResource(UI_SCORE_ITEM_PATH)
            .AsSingle();
    }

    private void InstallManagers()
    {
        Container.Bind<MainMenuManager>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
    }

    private void InstallMainMenuScreen()
    {
        Container.Bind<UIModelBase>().To<MainScreenUIModelBase>().FromResolve();
        Container.Bind<MainScreenUIModelBase>().To<MainScreenUIModel>().FromNewComponentOnNewGameObject().UnderTransformGroup(SCREENS_MODEL_GROUP).AsSingle();
        Container.Bind<MainScreenUIPresenterBase>().To<MainScreenUIPresenter>().AsSingle();

        Container.Bind<MainScreenUIViewBase>().To<MainScreenUIView>()
            .FromComponentInNewPrefabResource(MAIN_SCREEN_PATH)
            .UnderTransform(screensContainer)
            .AsSingle().NonLazy();
    }

    private void InstallLeaderboardScreen()
    {
        Container.Bind<UIModelBase>().To<LeaderboardScreenUIModelBase>().FromResolve();
        Container.Bind<LeaderboardScreenUIModelBase>().To<LeaderboardScreenUIModel>().FromNewComponentOnNewGameObject().UnderTransformGroup(SCREENS_MODEL_GROUP).AsSingle();
        Container.Bind<LeaderboardScreenUIPresenterBase>().To<LeaderboardScreenUIPresenter>().AsSingle();

        Container.Bind<LeaderboardScreenUIViewBase>().To<LeaderboardScreenUIView>()
            .FromComponentInNewPrefabResource(LEADERBOARD_SCREEN_PATH)
            .UnderTransform(screensContainer)
            .AsSingle().NonLazy();
    }
}