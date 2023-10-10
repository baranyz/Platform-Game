using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDeathEnemy : MonoBehaviour
{
    [SerializeField] GameObject _enemyBall, _enemyBallKit;
    Animator _enemyBallAnim;
    AudioSource _audio;
    public bool _isDeath;
    SpriteRenderer _enemyBallSpr;
    Collider2D _enemyBallCol;

    private void Start() {
        
        _enemyBallAnim = _enemyBall.GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
        _enemyBallSpr = _enemyBall.GetComponent<SpriteRenderer>();
        _enemyBallCol = _enemyBall.GetComponent<Collider2D>();
    
    }
    private void Update() {
        
        transform.position = new Vector3(_enemyBall.transform.position.x, transform.position.y, transform.position.z);

        if(_isDeath){       
            _enemyBallAnim.SetBool("isDeath", true);
            
        }
        if(_enemyBallAnim.GetCurrentAnimatorStateInfo(0).IsName("EnemyBall") && _enemyBallAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1){
            _enemyBallAnim.SetBool("isDeath", false);
            _isDeath = false;
            _enemyBallCol.enabled = false;
            _enemyBallSpr.enabled = false;
            Destroy(_enemyBallKit, _audio.clip.length);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            _audio.Play();
            _isDeath = true;
        }
    }
}
