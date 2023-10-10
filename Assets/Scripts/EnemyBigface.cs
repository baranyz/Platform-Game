using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBigface : MonoBehaviour
{
    Rigidbody2D _rgb;
    Animator _ani;
    AudioSource _audio;
    SpriteRenderer _spr;
    Collider2D _col;

    float _direction = 1f;
    float _firstPos;
    bool _isTrigger;

    private void Start() {
        _rgb = GetComponent<Rigidbody2D>();
        _ani = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
        _spr = GetComponent<SpriteRenderer>();
        _col = GetComponent<Collider2D>();

        _firstPos = transform.position.x;

    }

    private void Update() {
        if(Mathf.Approximately(_rgb.velocity.y, 0)){
            
            _ani.SetBool("isDown", true);
            _rgb.AddForce(new Vector2(_direction, 5), ForceMode2D.Impulse);
          
        }
        else{
            _ani.SetBool("isDown", false);
        }

        if(_ani.GetCurrentAnimatorStateInfo(0).IsName("BigFaceAnim") && _ani.GetCurrentAnimatorStateInfo(0).normalizedTime>1){
            _spr.enabled = false;
            _col.enabled = false;
            _ani.SetBool("isBigfaceDeath", false);
            
            _isTrigger = false;
            
        }
        if(_ani.GetBool("isBigfaceDeath")){
            Destroy(this.gameObject, _audio.clip.length);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {

    if(other.gameObject.tag == "ChangeDirect"){
        _direction = _direction * -1;
    }

    if(other.gameObject.tag == "Player"){
        _audio.Play();
        _ani.SetBool("isBigfaceDeath", true);
        _rgb.constraints = RigidbodyConstraints2D.FreezeAll;
        _isTrigger = true;
    }

    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(_isTrigger == false){
            if(other.gameObject.tag == "Player"){
            GameManager._lifesCount ++;
            GameManager._lifesMinusEffect = true;
        }

        if(other.gameObject.name != "Terrain"){
            _direction = _direction * -1;
        }
        }
        
    }

  
}
