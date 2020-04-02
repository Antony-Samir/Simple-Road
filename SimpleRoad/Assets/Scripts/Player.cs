using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float _speed = 5.5f;

    [SerializeField]
    private GameObject MarioWin;
    [SerializeField]
    private GameObject MarioGameOver;

    [SerializeField]
    private GameObject MarioPowerUp;

    [SerializeField]
    private AudioClip _audioClipWin;
    [SerializeField]
    private AudioClip _audioClipPowerUp;
    [SerializeField]
    private AudioClip _audioClipDie;


    void Start()
    {
        //current pos = new postion 
        transform.position = new Vector3(-17.5f, 0, 1f);
    }

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
        else if (transform.position.x <= -16.7f)
        {
            transform.position = new Vector3(-16.7f, transform.position.y, 1);
        }


        if (transform.position.x > 13f)
        {//Gate
            if ((transform.position.y >= 2.5f) || (transform.position.y <= 0f))
            {
                transform.position = new Vector3(13f, transform.position.y, 1);
            }
        }

        if (transform.position.y >= 8.7f)
        {
            transform.position = new Vector3(transform.position.x, 8.7f, 1);
        }
        else if (transform.position.y <= -6f)
        {
            transform.position = new Vector3(transform.position.x, -6f, 1);
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
        else if (other.tag == "PowerUp")
        {
            AudioSource.PlayClipAtPoint(_audioClipPowerUp, Camera.main.transform.position, 1f);
            Instantiate(MarioPowerUp, this.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
