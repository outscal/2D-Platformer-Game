public class SceneTransitionManager {

    public int levelToReload = 1;
    public int nextLevelToLoad = 1;

    public int lastLevelUnlocked = 1;

    public void UnlockTillLevel(int level) {
        if (level > lastLevelUnlocked) {
            lastLevelUnlocked = level;
        }
    }

    // Below code makes this class a SINGLETON
    private static SceneTransitionManager _instance;

    private SceneTransitionManager() { }

    public static SceneTransitionManager GetInstance() {
        if (_instance == null) { _instance = new SceneTransitionManager(); }
        return _instance;
    }
}
