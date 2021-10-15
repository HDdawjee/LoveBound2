using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
    public InkIntegrationScript IIScript;

    [SerializeField]
    public Button buttonDate; 
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
        buttonDate = GameObject.Find("btnDate").GetComponent<Button>();

        MScript = GameObject.Find("GameManager").GetComponent<MovementScript>();
        IIScript = GameObject.Find("GameManager").GetComponent<InkIntegrationScript>();

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

        if (MScript.sDate != "Tina")
        {
            MScript.Phone.sprite = MScript.ProfileAmina;
        }


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
        if (MScript.sDate == "Tina")
        {
            MScript.Phone.sprite = MScript.ProfileEthan;
            MScript.sDate = "Ethan";
            bPhoneicon = false;
             
            StartCoroutine(WaitTimeEthan());
            

        } else if (MScript.sDate == "Ethan")
        {
            MScript.Phone.sprite = MScript.ProfileZack;
            MScript.sDate = "Zack";
            bPhoneicon = false;
            StartCoroutine(WaitTimeZack());

        }

    }

    IEnumerator WaitTimeEthan()
    {
        // bDate = false;
        buttonDate.interactable = false;
        yield return new WaitForSeconds(6.5f);
        bCnvsLocation = true;
        bCnvsPhone = false;
       // AnimationSceneLoad(); 
        IIScript.StartStoryEthan();
    }

    IEnumerator WaitTimeZack()
    {
        // bDate = false;
        buttonDate.interactable = false;
        yield return new WaitForSeconds(6.5f);
        bCnvsLocation = true;
        bCnvsPhone = false;
        // AnimationSceneLoad(); 
        IIScript.StartStoryZack();
    }

    public void AnimationSceneLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 );
    }

    
}
