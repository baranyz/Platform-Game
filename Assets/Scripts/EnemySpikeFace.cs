using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpikeFace : MonoBehaviour
{
    Rigidbody2D _rgb;
    Animator _ani;
    AudioSource _audio;
    SpriteRenderer _spr;
    Collider2D _col;

    float _direction = 1f;

    private void Start() {
        _rgb = GetComponent<Rigidbody2D>();
        _ani = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
        _spr = GetComponent<SpriteRenderer>();
        _col = GetComponent<Collider2D>();

    }

    private void Update() {

        if(Mathf.Approximately(_rgb.velocity.y, 0)){
            
            _ani.SetBool("isFall", true);
            _rgb.AddForce(new Vector2(_direction, 5), ForceMode2D.Impulse);
          
        }
        else{
            _ani.SetBool("isFall", false);
        }

        if(_ani.GetBool("isDeath") && _ani.GetCurrentAnimatorStateInfo(0).normalizedTime > 1){
            _ani.SetBool("isDeath", false);
            _spr.enabled = false;
            _col.enabled = false;
            Destroy(this.gameObject, _audio.clip.length);
        }        
    }

    private void OnTriggerEnter2D(Collider2D other) {

    if(other.gameObject.tag == "ChangeDirect"){
        _direction = _direction * -1;
    }

    }
    private void OnCollisionEnter2D(Collision2D other) {

        if(other.gameObject.name != "Terrain"){
            _direction = _direction * -1;
        }

        if(other.gameObject.name == "TrapsBottom"){
            _audio.Play();
            _ani.SetBool("isDeath", true);
        }

        if(other.gameObject.name == "Player"){
            GameManager._lifesCount ++;
            GameManager._lifesMinusEffect = true;
        }
        
    }
}
