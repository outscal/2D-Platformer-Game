using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public static class EditorPlayButton
{
    static EditorPlayButton()
    {
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }

    private static void OnPlayModeStateChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingEditMode)
        {
            // Save the current scene before entering Play mode
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();

            // Open the lobby scene
            EditorSceneManager.OpenScene("Assets/Scenes/Lobby.unity");
        }
    }
}
