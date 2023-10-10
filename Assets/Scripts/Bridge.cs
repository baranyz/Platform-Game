using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    float _direct = 2f;
    GameObject _player;
    bool _isTouching;

    private void Start() {
        
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate() {
        transform.Translate(_direct * Time.deltaTime, 0,0);

        if(_isTouching){
            _player.transform.position += new Vector3(_direct * Time.deltaTime, 0,0);
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
