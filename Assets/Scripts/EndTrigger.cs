using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    GameObject _player;
    Animator _playerAnim;

    bool _isTrigger = false;

    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerAnim = _player.GetComponent<Animator>();
    }

    private void Update() {
        if(_isTrigger){

            _playerAnim.SetBool("isDesappear", true);
            if(PlayerPrefs.GetInt("Levels") < this.gameObject.scene.buildIndex + 1) 
            PlayerPrefs.SetInt("Levels",this.gameObject.scene.buildIndex + 1);
        }
        if(_playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Desappear") && _playerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1){

            _playerAnim.SetBool("isDesappear", false);
            _isTrigger = false;
            SceneManager.LoadScene(this.gameObject.scene.buildIndex + 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject == _player){
            _isTrigger = true;
        }
    }

}
