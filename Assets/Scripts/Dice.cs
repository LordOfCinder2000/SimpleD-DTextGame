
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Dice : MonoBehaviour ,IPointerClickHandler
{
    [SerializeField] NhanVat[] nhanVats;
    [SerializeField] Text Loai;
    [SerializeField] Text HP;
    [SerializeField] Text Damage;
    [SerializeField] Image mainImage;
    // Array of dice sides sprites to load from Resources folder
    private Sprite[] diceSides;
    public bool hasClass = false;
    // Reference to sprite renderer to change sprites
    private Image rend;

    AudioSource aSrc;

    // Use this for initialization
    private void Start () {

        // Assign Renderer component
        rend = GetComponent<Image>();
        aSrc = GetComponent<AudioSource>();
        // Load dice sides sprites to array from DiceSides subfolder of Resources folder
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        //NhanVat ChienBinh = new NhanVat("Chiến binh", 100, 80);
        //NhanVat Tien = new NhanVat("Tiên", 50, 100);
        //NhanVat Quy = new NhanVat("Quỷ", 200, 20);
        //NhanVat NguoiLun = new NhanVat("Người lùn", 180, 60);
        //NhanVat NguoiLai = new NhanVat("Người lai", 120, 90);
        //NhanVat NguoiThuong = new NhanVat("Người thường", 50, 30);
        //NhanVat Rong = new NhanVat("Rồng", 500, 10);
        //NhanVat Sauron = new NhanVat("Chúa tể bóng đêm", 1000, 50);
        //nhanVats.Add(ChienBinh);
        //nhanVats.Add(Tien);
        //nhanVats.Add(Quy);
        //nhanVats.Add(NguoiLun);
        //nhanVats.Add(NguoiLai);
        //nhanVats.Add(NguoiThuong);
        //nhanVats.Add(Rong);
        //nhanVats.Add(Sauron);
    }

    // If you left click over the dice then RollTheDice coroutine is started
    
    public void OnPointerClick(PointerEventData eventData)
    {
        aSrc.PlayOneShot(aSrc.clip);
        StartCoroutine("RollTheDice");
        
    }
    [SerializeField] int SoDienDeGayDamage = 2;
    [SerializeField] Text LoaiEnemy;
    [SerializeField] Image enemyImage;
    [SerializeField] public Text HPEnemy;
    [SerializeField] public Text DamageEnemy;

    private NhanVat nowNV;
    // Coroutine that rolls the dice
    private IEnumerator RollTheDice()
    {
        //Debug.Log("state " + AdventureGame.state.GetTitleStory());
           
        // Variable to contain random dice side number.
        // It needs to be assigned. Let it be 0 initially
        int randomDiceSide = 0;

        // Final side or value that dice reads in the end of coroutine
        int finalSide = 0;

        // Loop to switch dice sides ramdomly
        // before final side appears. 20 itterations here.
        for (int i = 0; i <= 20; i++)
        {
            // Pick up random value from 0 to 5 (All inclusive)
            randomDiceSide = Random.Range(0, 5);

            // Set sprite to upper face of dice from array according to random value
            rend.sprite = diceSides[randomDiceSide];

            // Pause before next itteration
            yield return new WaitForSeconds(0.05f);
        }

        // Assigning final side so you can use this value later in your game
        // for player movement for example
        finalSide = randomDiceSide + 1;

        if (AdventureGame.state.GetTitleStory() == "Tay sai của Sauron" || AdventureGame.state.GetTitleStory() == "Trận chiến cuối cùng")
        {
            if (finalSide >= SoDienDeGayDamage)
            {
                int hp = (int.Parse(HPEnemy.text) - int.Parse(nowNV.GetDamage().ToString()));
                HPEnemy.text = hp.ToString();
                
                //Debug.Log(AdventureGame.state.text);
                if(HPEnemy.text == "0")
                {
                    var nextStates = AdventureGame.state.GetNextStates();
                    AdventureGame.state = nextStates[0];
                    HPEnemy.text = "0";
                    DamageEnemy.text = "0";
                    LoaiEnemy.text = "Quái vật";
                    enemyImage.sprite = null;
                }
            }
            else
            {
                //if(AdventureGame.state.GetTitleStory() == "Tay sai của Sauron")
                //{
                    int hp = (int.Parse(HP.text.ToString()) - int.Parse(DamageEnemy.text));
                    HP.text = hp.ToString();
                    if (HP.text == "0")
                    {
                    Debug.Log("ban chet");
                    var nextStates = AdventureGame.state.GetNextStates();
                        AdventureGame.state = nextStates[1];
                    }
                //}
                
            }
        }
        else
        {
            HP.text = nhanVats[finalSide].GetHP().ToString();
            Damage.text = nhanVats[finalSide].GetDamage().ToString();
            Loai.text = "Class: " + nhanVats[finalSide].GetLoai();
            mainImage.sprite = nhanVats[finalSide].GetImage();
            hasClass = true;
            nowNV = nhanVats[finalSide];
        }
        
        // Show final dice value in Console

        //Debug.Log(nhanVats[finalSide].GetLoai());
    }

    
}
