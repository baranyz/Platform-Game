using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapFireSpawn : MonoBehaviour
{
    [SerializeField] GameObject _trapFire;

    private void Start() {
        InvokeRepeating("Spawn", Random.Range(0.5f, 2f), Random.Range(2f, 4f));
    }

    private void Spawn(){

        GameObject _clone = Instantiate(_trapFire, transform.position, Quaternion.Euler(0,0,90));

        _clone.transform.position = new Vector3(_clone.transform.position.x, _clone.transform.position.y, 1);
    }

}
