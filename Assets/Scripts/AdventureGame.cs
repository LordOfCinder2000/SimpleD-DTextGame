using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] GameObject dice;
    [SerializeField] Text textComponent;
    [SerializeField] Text textComponent2;
    [SerializeField] Image imageComponent;
    [SerializeField] State startingState;
    [SerializeField] GameObject inputField;
    [SerializeField] Text nameMain;
    [SerializeField] Text nameEnemy;
    public Button btnClick;
    public InputField inputField2;
    
    public static State state;

	// Use this for initialization
	void Start()
    {
        state = startingState;
        textComponent.text = state.GetStateStory();
        textComponent2.text = state.GetTitleStory();
        imageComponent.sprite = state.GetStateImage();
        btnClick.onClick.AddListener(GetInputOnClickHandler);

        
    }

    private bool hasName = false;
    public void GetInputOnClickHandler()
    {
        nameMain.text =  "Tên nhân vật: " + inputField2.text;
        hasName = true;
    }
        
    // Update is called once per frame
    void Update()
    {
        ManageState();
        if(state.GetTitleStory() == "EndGame")
        {
            Debug.Log("nghi");
            UnityEditor.EditorApplication.isPlaying = false;
        }    
	}

    [SerializeField] NhanVat[] nhanVats;
    [SerializeField] Text Loai;
    [SerializeField] public Text HP;
    [SerializeField] public Text Damage;
    [SerializeField] Image enemyImage;
    private int count, count1 = 0;
    private void ManageState()
    {
        var nextStates = state.GetNextStates();
        for (int index = 0; index < nextStates.Length; index++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + index) && state.GetTitleStory() != "Tạo nhân vật" && state.GetTitleStory() != "Tay sai của Sauron" && state.GetTitleStory() != "Trận chiến cuối cùng")
            {
                state = nextStates[index];
            }
        }
        if (state.GetTitleStory() != "Tay sai của Sauron" && state.GetTitleStory() != "Trận chiến cuối cùng" && state.GetTitleStory() != "Tạo nhân vật")
        {
            
            dice.SetActive(false);
        }
        else 
        {
            dice.SetActive(true);
            if (state.GetTitleStory() == "Tay sai của Sauron" && count ==0)
            {
                count++;
                Debug.Log("quai "+nhanVats[0].GetLoai());
                Loai.text = nhanVats[0].GetLoai().ToString();
                HP.text = nhanVats[0].GetHP().ToString();
                Damage.text = nhanVats[0].GetDamage().ToString();
                enemyImage.sprite = nhanVats[0].GetImage();
            }
            if (state.GetTitleStory() == "Trận chiến cuối cùng" && count1 == 0)
            {
                count1++;
                Debug.Log(nhanVats[1].GetLoai());
                Loai.text = nhanVats[1].GetLoai().ToString();
                HP.text = nhanVats[1].GetHP().ToString();
                Damage.text = nhanVats[1].GetDamage().ToString();
                enemyImage.sprite = nhanVats[1].GetImage();
            }
        }
        if (state.GetTitleStory() != "Tạo nhân vật")
        {
            inputField.SetActive(false);
            btnClick.gameObject.SetActive(false);
        }
        else
        {
            inputField.SetActive(true);
            btnClick.gameObject.SetActive(true);
            Dice diceClass = dice.GetComponent<Dice>();
            if (hasName && diceClass.hasClass)
            {
                state = nextStates[0];
            }
            
        }
            
            
        
        textComponent.text = state.GetStateStory();
        textComponent2.text = state.GetTitleStory();
        imageComponent.sprite = state.GetStateImage();
    }

    
}

