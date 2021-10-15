using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuScript : MonoBehaviour
{
    public InkIntegrationScript IIScript;
    public MovementScript MScript;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("MainMenu is Loaded");
        IIScript = GameObject.Find("SceneManager").GetComponent<InkIntegrationScript>();
        MScript = GameObject.Find("SceneManager").GetComponent<MovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStart()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        //IIScript.StartStoryTina();
        MScript.sDate = "Tina";

    }
}
