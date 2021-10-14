using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;


public class InkIntegrationScript : MonoBehaviour
{
    [SerializeField]
    private TextAsset _inkJsonAsset;

    [SerializeField]
    private TextAsset DatewithEthan;

    [SerializeField]
    private TextAsset DatewithTina;



    private Story _story;
    [SerializeField]
    private Text txtNPCs, txtAmina;

    [SerializeField]
    private Text _textField;

    [SerializeField]
    private Color Normal_Color ;

    [SerializeField]
    private Button _choiceButtonPrefab;

    [SerializeField]
    private GameObject _choiceButtonContainer;
    
    public LoveBoundScript LBScript;
    public GameObject vfx;
    public MovementScript MScript; 
    
    // Start is called before the first frame update

    private void Start()
    {
       
        //RefreshChoiceView();
         Debug.Log("Integration Script loaded");
        LBScript = GameObject.Find("GameManager").GetComponent<LoveBoundScript>();
        MScript = GameObject.Find("GameManager").GetComponent<MovementScript>();
        txtNPCs = GameObject.Find("txtNPC").GetComponent<Text>();
        txtAmina = GameObject.Find("txtCharacter").GetComponent<Text>();

        StartStoryTina();
    }
    public void StartStoryTina()
    {
        _story = new Story(DatewithTina.text); 
        DisplayNextLine();
    }

    public void StartStoryEthan()
    {
        _story = new Story(DatewithEthan.text); 
        DisplayNextLine();
        MScript.EthanDate(); 
    }



    // Update is called once per frame
    void Update()
    {
  
    }

    public void DisplayNextLine()
    {
        Debug.Log("Next Line");
        if (_story.canContinue)
        {
            
            string text = _story.Continue(); // gets next line
            ApplyStyling();
            text = text?.Trim(); // removes white space from text
            _textField.text = text; // displays new text


        }
        else if (_story.currentChoices.Count > 0)
        {
            DisplayChoices();
        }
        else if (_story.canContinue == false)
        {
            Debug.Log("Story has ended!");
            LBScript.bPhoneicon = true;

            if (vfx != null)
                Instantiate(vfx, LBScript.btnPhone.transform.position, Quaternion.identity);
        }


    }
    private void DisplayChoices()
    {
        // checks if choices are already being displaye
        if (_choiceButtonContainer.GetComponentsInChildren<Button>().Length > 0) return;
        _textField.enabled = false;
        for (int i = 0; i < _story.currentChoices.Count; i++) // iterates through all choices
        {

            var choice = _story.currentChoices[i];
            var button = CreateChoiceButton(choice.text); // creates a choice button
          //  _textField.text = choice.text; 
            button.onClick.AddListener(() => OnClickChoiceButton(choice));
        }
    }

    Button CreateChoiceButton(string text)
    {
        // creates the button from a prefab
       // _choiceButtonContainer.transform.position = new Vector3(-146, 1500, 976);
       // Debug.Log(_choiceButtonContainer.transform.position.y);

        var choiceButton = Instantiate(_choiceButtonPrefab);
        choiceButton.transform.SetParent(_choiceButtonContainer.transform, true);

      //  sets text on the button
       var buttonText = choiceButton.GetComponentInChildren<Text>();
        buttonText.text = text;

        return choiceButton;

    }

    void OnClickChoiceButton(Choice choice)
    {
        _story.ChooseChoiceIndex(choice.index); // tells ink which choice was selected
        RefreshChoiceView(); // removes choices from the screen
        _textField.enabled = true;
        DisplayNextLine();

    }

    void RefreshChoiceView()
    {
        if (_choiceButtonContainer != null)
        {
            foreach (var button in _choiceButtonContainer.GetComponentsInChildren<Button>())
            {
                Destroy(button.gameObject);
            }
        }
    }

    private void ApplyStyling()
    {
        if (_story.currentTags.Contains("Amina"))
        {
            txtAmina.text = "Amina:";
            txtNPCs.text = "";
            txtAmina.fontStyle = FontStyle.Normal;

           

        }
        else if (_story.currentTags.Contains("Tina"))
        {
           txtNPCs.text = "Tina:";
            txtAmina.text = "";
            txtNPCs.fontStyle = FontStyle.Normal;

            
        }
        else if (_story.currentTags.Contains("Ethan"))
        {
            txtNPCs.text = "Ethan:";
            txtAmina.text = "";
            txtNPCs.fontStyle = FontStyle.Normal;

            
        }
        else if (_story.currentTags.Contains("Zack"))
        {
            txtNPCs.text = "Zack:";
            txtAmina.text = "";
            txtNPCs.fontStyle = FontStyle.Normal;
        }
        else if (_story.currentTags.Contains("Description"))
        {
            txtAmina.text = "";
            txtNPCs.text = "";
            _textField.fontStyle = FontStyle.Bold;
        }
        else if (_story.currentTags.Contains("thought"))
        {
            txtAmina.text = "Amina:";
            txtNPCs.text = "";
            _textField.fontStyle = FontStyle.Italic;
        }
        else if (_story.currentTags.Contains("Blank"))
        {
            txtAmina.text = "";
            txtNPCs.text = "";
            _textField.fontStyle = FontStyle.Bold;
            MScript.Location.sprite = MScript.imgBlank;
            MScript.NPC.enabled = false; 
            
        }
        else if (_story.currentTags.Contains("Park"))
        {
            txtAmina.text = "";
            txtNPCs.text = "";
            _textField.fontStyle = FontStyle.Bold;
            MScript.Location.sprite = MScript.imgPark;
            MScript.NPC.enabled = false;
            MScript.NPC.enabled = true;
        }
    }








}





