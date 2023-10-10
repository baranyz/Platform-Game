using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPlayerImage : MonoBehaviour
{
    [SerializeField] Sprite _p1,_p2,_p3,_p4;
    Image _img;

    private void Start() {
        _img = GetComponent<Image>();
    }
    private void Update() {
        
        if(PlayerPrefs.GetInt("PlayerSpawn") == 1) _img.sprite = _p1;
        else if(PlayerPrefs.GetInt("PlayerSpawn") == 2) _img.sprite = _p2;
        else if(PlayerPrefs.GetInt("PlayerSpawn") == 3) _img.sprite = _p3;
        else if(PlayerPrefs.GetInt("PlayerSpawn") == 4) _img.sprite = _p4;
    }
}
