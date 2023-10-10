using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] GameObject _box, _boxCrash, _boxBreak1, _boxBreak2, _boxBreak3, _boxBreak4;
    GameObject _player;
    [SerializeField] GameObject _fruitApple;
    Animator _playerAnim;
    SpriteRenderer _playerSpr;
    bool _isTouched;

    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerAnim = _player.GetComponent<Animator>();
        _playerSpr = _player.GetComponent<SpriteRenderer>();
    }

    private void Update() {
        
        try{

            if(_isTouched){
            if(_playerAnim.GetBool("isHit")){
                if(_player.transform.position.x > _box.transform.position.x){
                    if(_playerSpr.flipX == true) Break();
                }
                if(_player.transform.position.x < _box.transform.position.x){
                    if(_playerSpr.flipX == false) Break();
                }
            }
            }

            if(_boxBreak1.transform.position.y > transform.position.y + 20){
                Destroy(_boxCrash);
            }
        }
        catch{}

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            _isTouched = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            _isTouched = false;
        }
    }

    private void Break(){
        Destroy(_box);
        _boxCrash.SetActive(true);
        _boxBreak1.GetComponent<Collider2D>().isTrigger = true;
        _boxBreak2.GetComponent<Collider2D>().isTrigger = true;
        _boxBreak3.GetComponent<Collider2D>().isTrigger = true;
        _boxBreak4.GetComponent<Collider2D>().isTrigger = true;
        _boxBreak1.GetComponent<Rigidbody2D>().AddForce(new Vector2(-5,5), ForceMode2D.Impulse);
        _boxBreak2.GetComponent<Rigidbody2D>().AddForce(new Vector2(5,5), ForceMode2D.Impulse);
        _boxBreak3.GetComponent<Rigidbody2D>().AddForce(new Vector2(-5,1), ForceMode2D.Impulse);
        _boxBreak4.GetComponent<Rigidbody2D>().AddForce(new Vector2(5,1), ForceMode2D.Impulse);
        _fruitApple.SetActive(true);
    }

}

