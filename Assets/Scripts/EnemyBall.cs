using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBall : MonoBehaviour
{
    Rigidbody2D _rgb;
    Vector2 _direct;
    Animator _anim;
    TriggerDeathEnemy isdeath;
    [SerializeField] GameObject _triggerDeath;

    private void Start() {
        _rgb = GetComponent<Rigidbody2D>();
        _direct = Vector2.right;
        _anim = GetComponent<Animator>();

        isdeath = _triggerDeath.GetComponent<TriggerDeathEnemy>();

    }
    private void Update() {

        _rgb.velocity = _direct;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        try
        {
            if(_rgb.velocity.x >0){
            _direct = Vector2.left;
            }
            else if(_rgb.velocity.x <0){
                _direct = Vector2.right;
            }
        }
        catch{}
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(_rgb.velocity.x >0){
            _direct = Vector2.left;
        }
        else if(_rgb.velocity.x <0){
            _direct = Vector2.right;
        }

        if(other.gameObject.tag == "Player"){
            if(isdeath._isDeath == false){
                GameManager._lifesCount ++;
                GameManager._lifesMinusEffect = true;
            }
            
        }
    }
}
