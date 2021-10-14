using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;



public class MovementScript : MonoBehaviour

    // This script deals with the changing of images and animations
{
    [SerializeField]
    private List<CinemachineVirtualCamera> virtCameras;
    private static int CurrentCamera;
    private Text txtNPC;
    private Button btnDate, btnDownload;

    public Image Location, NPC, Phone;
    public Sprite ProfileAmina, ProfileEthan, ProfileZack;
    public Sprite imgRestaurant,imgPark, imgBlank;
    public Sprite imgDate1, imgDate2, imgFriend;
    public string sDate = "Tina"; 


    // Start is called before the first frame update
    void Start()
    {
        Location = GameObject.Find("imglocation").GetComponent<Image>();
       // Location.sprite = imgPark;

        NPC = GameObject.Find("imgNPC").GetComponent<Image>();
        txtNPC = GameObject.Find("txtNPC").GetComponent<Text>();
      //  NPC.sprite = imgDate1; 

    }

    // Update is called once per frame
    void Update()
    {
      //  Nametag();
    }

    public void CineCameraClick()
    {
        if (CurrentCamera == 2)
        {
            virtCameras[0].Priority = 20;
            virtCameras[1].Priority = 10;

            CurrentCamera = 1;
        }
     
    }


    public void TinaDate()
    {
        NPC.sprite = imgFriend;
        Location.sprite = imgRestaurant;
      
    }

    public void EthanDate()
    {
        NPC.sprite = imgDate1;
        Location.sprite = imgPark; 
        
    }

    public void ZackDate()
    {
        NPC.sprite = imgDate2;
        Location.sprite = imgRestaurant;
      
    }

    //public void Movement()
    //{
    //    // WASD Movement 
    //    x = Input.GetAxis("Horizontal");
    //    Debug.Log("Move!");
    //    y = Input.GetAxis("Vertical");
    //    move = new Vector3(x, 0.0f, y);

    //    this.gameObject.transform.position += move * speed;
    //}
}
