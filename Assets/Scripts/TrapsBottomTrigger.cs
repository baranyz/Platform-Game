using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsBottomTrigger : MonoBehaviour
{
    [SerializeField] GameObject _trapsBottom;
    AudioSource _audio;
    bool _isTrigger;
    float _trapsStartPos;

    private void Start() {
        _trapsStartPos = _trapsBottom.transform.position.y;
        _audio = GetComponent<AudioSource>();
    }

    private void Update() {
        
        if(_isTrigger){
            _audio.Play();
            _trapsBottom.transform.Translate(Time.deltaTime *10, 0, 0);
            if(_trapsStartPos + 2.5f < _trapsBottom.transform.position.y) _isTrigger = false;
        }
        else if(_isTrigger == false){
            if(_trapsStartPos < _trapsBottom.transform.position.y){
                _trapsBottom.transform.Translate(-Time.deltaTime / 5, 0, 0);
                if(_trapsStartPos + 0.1f > _trapsBottom.transform.position.y){
                    _trapsBottom.transform.position = new Vector3(_trapsBottom.transform.position.x, _trapsStartPos, 0);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" && _trapsStartPos == _trapsBottom.transform.position.y) _isTrigger = true;
    }
}
