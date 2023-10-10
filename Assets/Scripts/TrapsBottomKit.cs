using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsBottomKit : MonoBehaviour
{
    [SerializeField] GameObject _buttonOn, _buttonOff, _trapsBottom;
    [SerializeField] AudioSource _audioClick, _audioTrap;
    bool _isPress = false;

    Vector2 _trapStartPos;

    private void Start() {
        _buttonOn.SetActive(true);
        _buttonOff.SetActive(false);

        _trapStartPos = _trapsBottom.transform.position;
    }

    private void Update() {
        
        if(_isPress == true){
            _buttonOn.SetActive(false);
            _buttonOff.SetActive(true);
            _trapsBottom.transform.Translate(0,Time.deltaTime*10, 0);

            if(_trapStartPos.y + 1f < _trapsBottom.transform.position.y){
                _isPress = false;
            }
        }
        if(_isPress == false){

            _buttonOn.SetActive(true);
            _buttonOff.SetActive(false);

            if(_trapStartPos.y < _trapsBottom.transform.position.y){
                _trapsBottom.transform.Translate(0,-Time.deltaTime*10, 0);
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            _audioClick.Play();
            _audioTrap.Play();
            _isPress = true;
        }
    }
}
