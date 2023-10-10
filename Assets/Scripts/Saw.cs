using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    Rigidbody2D _rgb;
    bool _isSawForce;

    private void Start() {
        _rgb = GetComponent<Rigidbody2D>();
        _isSawForce = true;
        StartCoroutine(SawForce());
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            GameManager._lifesCount ++;
            GameManager._lifesMinusEffect = true;
        }
    }
    IEnumerator SawForce(){
        while(_isSawForce){
            yield return new WaitForSeconds(1);
            _rgb.AddForce(_rgb.velocity *5, ForceMode2D.Force);
        }
        
    }
}
