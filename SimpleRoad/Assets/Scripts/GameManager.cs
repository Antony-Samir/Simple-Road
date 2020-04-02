using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Get current scene name
            string scene = SceneManager.GetActiveScene().name;
            //Load it
            SceneManager.LoadScene(scene, LoadSceneMode.Single);

            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            //Get current scene name
            string scene = SceneManager.GetActiveScene().name;
            //Load it
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }

    }


}