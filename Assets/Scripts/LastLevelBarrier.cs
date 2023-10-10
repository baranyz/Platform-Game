using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastLevelBarrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            GameManager._lifesMinusEffect = true;
            GameManager._lifesCount ++;
        }

    }
}
