namespace TicTacToe.Codebase.Infrastructure.StateMachine
{
    public class LoadLevelState : ApplicationState
    {
        private readonly SceneLoader _sceneLoader;
        //private readonly IGameFactory _gameFactory;
        //private readonly IPersistentProgressService _progressService;
        //private readonly IStaticDataService _staticData;
        //private readonly IWindowService _windowService;
        //private readonly IUIFactory _uiFactory;

        private LoadLevelStateArgs _currentArgs;

        public LoadLevelState(SceneLoader sceneLoader)
            //IGameFactory gameFactory, IPersistentProgressService progressService, IStaticDataService staticData, IWindowService windowService,
            //IUIFactory uiFactory)
        {
            _sceneLoader = sceneLoader;
            
            // _gameFactory = gameFactory;
            // _progressService = progressService;
            // _staticData = staticData;
            // _windowService = windowService;
            // _uiFactory = uiFactory;
        }

        public override void Enter(StateArgs args)
        {
            if (args != null)
            {
                _currentArgs = (LoadLevelStateArgs)args;
            }

            // _windowService.FadeIn();
            // _gameFactory.Cleanup();
            // _gameFactory.WarmUp();
            
            _sceneLoader.Load(_currentArgs.LevelSceneName, OnLoaded);
        }

        public override void Exit()
        {
            //_windowService.FadeOut();
            _currentArgs = null;
        }

        private async void OnLoaded()
        {
            // await InitUiRoot();
            // await InitGameWorld();
            // InformProgressReaders();
            
            AppStateMachine.Enter<GameLoopState>();
        }

        // private async Task InitUiRoot() =>
        //     await _uiFactory.CreateUIRoot();

        // private async Task InitGameWorld()
        // {
        //     LevelStaticData levelData = LevelStaticData();
        //     await InitHud(hero);
        // }

        // private LevelStaticData LevelStaticData()
        // {
        //     string sceneKey = SceneManager.GetActiveScene().name;
        //     LevelStaticData levelData = _staticData.ForLevel(sceneKey);
        //     return levelData;
        // }

        // private async Task InitHud(GameObject hero)
        // {
        //     GameObject hud = await _gameFactory.CreateHud();
        //
        //     hud.GetComponentInChildren<ActorUI>()
        //         .Construct(hero.GetComponent<HeroHealth>());
        // }

        // private void InformProgressReaders()
        // {
        //     foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
        //         progressReader.LoadProgress(_progressService.Progress);
        // }
    }
}