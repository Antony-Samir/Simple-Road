using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPowerUp : MonoBehaviour
{


    [SerializeField]
    private GameObject MarioWin;
    [SerializeField]
    private GameObject MarioGameOver;

    [SerializeField]
    private float _speed = 6f;

    [SerializeField]
    private AudioClip _audioClipWin;
    [SerializeField]
    private AudioClip _audioClipDie;

    // Start is called before the first frame update
    public void Start()
    {
        //current pos = new postion 
        transform.position = new Vector3(-12f, -6.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        Movment();
    }

    private void Movment()
    {
        float horizontalTnput = Input.GetAxis("Horizontal");
        float verticalTnput = Input.GetAxis("Vertical");


        transform.Translate(Vector3.right * _speed * horizontalTnput * Time.deltaTime);
        transform.Translate(Vector3.up * _speed * verticalTnput * Time.deltaTime);


        if (transform.position.x > 16.5f)
        {//Win
            Instantiate(MarioWin, new Vector3(0f, 0f, 10f), Quaternion.identity);

            Debug.Log("You Win");
            AudioSource.PlayClipAtPoint(_audioClipWin, Camera.main.transform.position, 1f);
            Destroy(this.gameObject);
        }
        else if (transform.position.x <= -16.8f)
        {
            transform.position = new Vector3(-16.8f, transform.position.y, 1);
        }


        if (transform.position.x > 13f)
        {//Gate
            if ((transform.position.y > 2.5f) || (transform.position.y < 0f))
            {
                transform.position = new Vector3(13f, transform.position.y, 1);
            }
        }
        if (transform.position.y >= 9.1f)
        {
            transform.position = new Vector3(transform.position.x, 9.1f, 1);
        }
        else if (transform.position.y <= -6.4f)
        {
            transform.position = new Vector3(transform.position.x, -6.4f, 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.name);

        if ((other.tag == "Enemy") || (other.tag == "MashroomUp") || (other.tag == "MashroomDown"))
        {
            AudioSource.PlayClipAtPoint(_audioClipDie, Camera.main.transform.position, 1f);
            Destroy(this.gameObject);
            //Destroy(other.gameObject);
            Instantiate(MarioGameOver, new Vector3(0f, 0f, 1f), Quaternion.identity);
        }
    }
}
