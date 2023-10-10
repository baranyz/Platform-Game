using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeVertical : MonoBehaviour
{
    float _direct;
    GameObject _player;
    Rigidbody2D _playerRgb;
    Rigidbody2D _rgb;
    bool _isTouching;

    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerRgb= _player.GetComponent<Rigidbody2D>();
        _rgb = GetComponent<Rigidbody2D>();
        _direct = 1;
    }
    private void FixedUpdate() {
        transform.Translate(0,_direct * Time.fixedDeltaTime,0);

        if(_isTouching){
            _player.transform.Translate(0,_direct*Time.fixedDeltaTime,0);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "ChangeDirect"){
            _direct = _direct * -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject == _player){
            _isTouching = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject == _player){
            _isTouching = false;
        }
    }

}
