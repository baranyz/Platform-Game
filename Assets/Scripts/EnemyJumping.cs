using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumping : MonoBehaviour
{
    bool _isGround;
    Rigidbody2D _rgb;
    Animator _Anim;
    AudioSource _audio;
    SpriteRenderer _spr;
    Collider2D _col;

    private void Start() {
        _rgb = GetComponent<Rigidbody2D>();
        _Anim = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
        _spr = GetComponent<SpriteRenderer>();
        _col = GetComponent<Collider2D>();
    }
    private void Update() {
        Jump();
        if(_Anim.GetBool("isDeath")){
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.localScale = new Vector3(2, 2, 0);
            if(_Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >1){
                _spr.enabled = false;
                _col.enabled = false;
                Destroy(this.gameObject, _audio.clip.length);
            }
        }

    }
    private void Jump(){

        if(_isGround == true){
            _rgb.AddForce(Vector2.up /25, ForceMode2D.Impulse);
            transform.localScale -= new Vector3(0, Time.deltaTime*2, 0);
            transform.localScale += new Vector3(Time.deltaTime*2, 0, 0);
            if(transform.localScale.y < 0.75f){
                _isGround = false;
            }
        }
        else if(_isGround == false){
            if(transform.localScale.y < 1f){
                transform.localScale += new Vector3(0, Time.deltaTime, 0);
                transform.localScale -= new Vector3(Time.deltaTime, 0, 0);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D other) {

        if(other.gameObject.tag == "TrapBottom"){
            _audio.Play();
            _Anim.SetBool("isDeath", true);
        }
        else{
            _isGround = true;
        }
    }

}
