using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    GameObject _player;
    SpriteRenderer _playerSpr;
    Rigidbody2D _rgb;
    bool _isTrigger;

    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerSpr = _player.GetComponent<SpriteRenderer>();
        _rgb = GetComponent<Rigidbody2D>();
    }
    private void Update() {

        if(_isTrigger == true){            
            if(GameManager._isHit == true){
                _rgb.bodyType = RigidbodyType2D.Dynamic;
                if(_playerSpr.flipX == true && _player.transform.position.x > transform.position.x){
                    _rgb.AddForce(Vector2.left, ForceMode2D.Impulse);
                }
                else if(_playerSpr.flipX == false && _player.transform.position.x < transform.position.x){
                    _rgb.AddForce(Vector2.right, ForceMode2D.Impulse);
                }

            }
            else if(GameManager._isHit == false && Mathf.Approximately(_rgb.velocity.x, 0)){
                _rgb.bodyType = RigidbodyType2D.Static;}
        }
        else if(_isTrigger == false && Mathf.Approximately(_rgb.velocity.x, 0)){
            _rgb.bodyType = RigidbodyType2D.Static;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject == _player){
            _isTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject == _player){
            _isTrigger = false;
        }
    }
}
