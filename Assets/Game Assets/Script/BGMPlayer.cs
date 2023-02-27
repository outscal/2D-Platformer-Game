using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour {

    private static BGMPlayer _instance;

    [SerializeField] private AudioSource buttonSound;

    public static BGMPlayer GetInstance() {
        return _instance;
    }

    public int i;

    private void Awake() {
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(gameObject);

        } else {
            Destroy(gameObject);
        }
    }

    public void ButtonSound() {
        buttonSound.Play();
    }

}
