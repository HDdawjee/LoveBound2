using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AminaMove : MonoBehaviour
{
    public float speed = 2f;

    public InkIntegrationScript IIScript;
    public MovementScript MScript;
    public GameObject TriggerPark, TriggerRestaurant;
    // Start is called before the first frame update
    void Start()
    {
        TriggerPark = GameObject.Find("TriggerPark");
        IIScript = GameObject.Find("AminaWalk").GetComponent<InkIntegrationScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.name);
        if (col.name == "TriggerPark")
        {
           
            MScript.sDate = "Ethan";
         //   IIScript.StartStoryEthan();
        //    LocationSceneLoad();
            
            TriggerPark.active = false; 
        }

        if (col.name == "TriggerRestaurant")
        {
         //   LocationSceneLoad();
            //   IIScript.StartStoryZack();
            MScript.sDate = "Zack";
            TriggerRestaurant.active = false;
        }
    }


    public void LocationSceneLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
