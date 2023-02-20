public static class SceneTransitionManager {
    public static int levelToReload = 1;
    public static int nextLevelToLoad = 1;

    public static int lastLevelUnlocked = 1;

    public static void UnlockTillLevel(int level) {
        if (level > lastLevelUnlocked) {
            lastLevelUnlocked = level;
        }
    }
}
