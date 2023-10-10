using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gem : MonoBehaviour
{
    Animator _anim;
    AudioSource _audio;
    bool _isDestroy;
    float _animTime;
    SpriteRenderer _spr;
    Collider2D _col;

    private void Start() {
        
        _anim = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
        _spr = GetComponent<SpriteRenderer>();
        _col = GetComponent<Collider2D>();
    }
    private void Update() {
        if(_isDestroy){
            GameManager._diamondEffect = true;
            _animTime += Time.deltaTime;
            _anim.SetBool("isGem", true);
            if(_animTime > 0.2f){
                _spr.enabled = false;
                Destroy(this.gameObject, _audio.clip.length);
                _anim.SetBool("isGem", false);
                _animTime = 0;
                _isDestroy = false;
            }
        }
        
        float _time = Mathf.PingPong(Time.time, 1);

        transform.position = Vector2.Lerp(new Vector2(transform.position.x, transform.position.y + Time.deltaTime), new Vector2(transform.position.x, transform.position.y - Time.deltaTime), _time);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            _audio.Play();
            _col.enabled = false;
            _isDestroy = true;
            GameManager._diamondCount ++;
        }
    }

}
