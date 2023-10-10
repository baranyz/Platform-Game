using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropKit : MonoBehaviour
{
    [SerializeField] GameObject _bridgeProp, _buttonOn, _buttonOff;
    AudioSource _audio;
    bool _isOn;
    float _stopStart;

    private void Start() {
        _isOn = false;
        _audio = GetComponent<AudioSource>();
    }
    private void Update() {
        
        _bridgeProp.transform.Rotate(0,0, _stopStart * Time.deltaTime);

        if(_isOn){
            _buttonOn.SetActive(false);
            _buttonOff.SetActive(true);
            _stopStart = 0;
        }
        if(_isOn == false){
            _buttonOn.SetActive(true);
            _buttonOff.SetActive(false);
            _stopStart =30;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            _audio.Play();
            if(_isOn) _isOn = false;
            else if(_isOn == false) _isOn = true;
        }
    }
}
