using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class LoveBoundScript : MonoBehaviour
{

 
    [SerializeField]
    private GameObject pnlDialogue;

    public GameObject btnPhone, btnBack, btnDownload, btnDate;
    public GameObject cnvPhone, cnvLocation, cnvAnimated;
    public bool bPhoneicon = false;
    public bool bCnvsPhone = false;
    public bool bCnvsLocation = true;
    public bool bDownload = true;
    public bool bDate = false;
    public bool bCnvsAnimated = false;
    public MovementScript MScript;
    // Start is called before the first frame update
    void Awake()
    {
        pnlDialogue = GameObject.Find("pnlUI");
        cnvPhone = GameObject.Find("CnvPhone");
        cnvLocation = GameObject.Find("CnvLocation");
        cnvAnimated = GameObject.Find("CnvAnimated");
        btnPhone = GameObject.Find("btnPhone");
        btnDownload = GameObject.Find("btnDownload");
        btnDate = GameObject.Find("btnDate");
        btnBack = GameObject.Find("btnBack");

        MScript = GameObject.Find("GameManager").GetComponent<MovementScript>();

        cnvPhone.active = bCnvsPhone;
        btnPhone.active = bPhoneicon;
        cnvLocation.active = bCnvsLocation; 
    }

    // Update is called once per frame
    void Update()
    {
        cnvPhone.active = bCnvsPhone;
        cnvLocation.active = bCnvsLocation;
        cnvAnimated.active = bCnvsAnimated;

        btnDownload.active = bDownload;
        btnDate.active = bDate;
        btnPhone.active = bPhoneicon;
    }

    public void OnClickPhoneIcon()
    {
        bCnvsPhone = true;
        bCnvsLocation = false;
        bCnvsAnimated = false;

    }

    public void OnClickBack()
    {
        bCnvsPhone = false;
        bCnvsLocation = false;
        bCnvsAnimated = true;

    }
    public void OnClickDownload()
    {
        bDownload = false;
        //ProgressBar()
        MScript.Phone.sprite = MScript.ProfileAmina;
        bDate = true; 

    }

    public void OnClickGenerateMatch()
    {
        if (MScript.Phone.sprite == MScript.ProfileAmina)
        {
            MScript.Phone.sprite = MScript.ProfileEthan;
            MScript.sDate = "Ethan";
        } else if (MScript.Phone.sprite == MScript.ProfileEthan)
            {
            MScript.Phone.sprite = MScript.ProfileZack;
            MScript.sDate = "Zack";
            }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.name);   
    }



}
