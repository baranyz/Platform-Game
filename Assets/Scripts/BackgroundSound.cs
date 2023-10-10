using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSound : MonoBehaviour
{
    public static BackgroundSound Instance { get; set; }
    AudioSource _audio;
    private void Awake() {
        _audio = GetComponent<AudioSource>();
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else{
            Destroy(this.gameObject);
        }
    }


}
