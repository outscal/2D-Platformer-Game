using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    [SerializeField] GameObject mainmenu_screen;
    [SerializeField] GameObject lobby_screen;
    public void LoadLobbyPanel()
    {
        SoundManager.Instance.ButtonSound(Sounds.SoundEffect);
        mainmenu_screen.SetActive(false);
        lobby_screen.SetActive(true);
    }
}
