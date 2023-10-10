using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapFire : MonoBehaviour
{
    float _timeDestroy;

    private void Start() {
        _timeDestroy = 0;

    }
    private void Update() {
        
        transform.Translate(0, 10 * Time.deltaTime, 0);

        _timeDestroy += Time.deltaTime;

        if(_timeDestroy > 1.3f){
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            GameManager._lifesCount ++;
            GameManager._lifesMinusEffect = true;
        }
    }
}
