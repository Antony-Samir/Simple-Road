using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUP : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movment();
    }
    private void Movment()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y <= -6f)
        {
            transform.position = new Vector3(transform.position.x, 8f, 1);
            transform.Translate(Vector3.down * _speed * Time.deltaTime);
        }
       
    }

}
