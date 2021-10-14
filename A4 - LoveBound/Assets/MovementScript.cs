using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;



public class MovementScript : MonoBehaviour


{
    [SerializeField]
    private List<CinemachineVirtualCamera> virtCameras;
    private static int CurrentCamera;
    private Text txtNPC;

    public Image Location, NPC;
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

    public void Nametag()
    {
        if (NPC.sprite == imgDate1)
        {
            txtNPC.text = "Ethan"; 
        }

        else

          if (NPC.sprite == imgFriend)
        {
            txtNPC.text = "Tina:";
        }
    }

    public void TinaDate()
    {
        NPC.sprite = imgFriend;
        Location.sprite = imgRestaurant;
        sDate = "Tina";
    }

    public void EthanDate()
    {
        NPC.sprite = imgDate1;
        Location.sprite = imgPark; 
        sDate = "Ethan";
    }

    public void ZackDate()
    {
        NPC.sprite = imgDate2;
        Location.sprite = imgRestaurant;
        sDate = "Zack";
    }
}
