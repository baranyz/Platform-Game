using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            GameManager._lifesCount ++;
            GameManager._lifesMinusEffect = true;
        }
        
    }

}
