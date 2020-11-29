using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PhoneInit : MonoBehaviour
{
    public static int PlayerId = 1;
    public static int PlayerGender = -1;

    public Sprite AlexFemSelected;
    public Sprite AlexFemUnselected;
    public Sprite AlexFemNeutral;
    public Sprite AlexMasSelected;
    public Sprite AlexMasUnselected;
    public Sprite AlexMasNeutral;


    public Sprite JesseFemSelected;
    public Sprite JesseFemUnselected;
    public Sprite JesseFemNeutral;
    public Sprite JesseMasSelected;
    public Sprite JesseMasUnselected;
    public Sprite JesseMasNeutral;

    public GameObject MasBorder, FemBorder;

    private Dropdown _dropdownId;
    private Dropdown _dropdownGender;

    private Button _continueBtn;
    // Start is called before the first frame update
    void Start()
    {
        var dropdowns = GameObject.FindObjectsOfType<Dropdown>();
        var buttons = GameObject.FindObjectsOfType<Button>();

        MasBorder = GameObject.FindWithTag("MasBorder").gameObject;
        FemBorder = GameObject.FindWithTag("FemBorder").gameObject;

        MasBorder.SetActive(false);
        FemBorder.SetActive(false);
        
        _continueBtn = buttons.FirstOrDefault(x => x.CompareTag("Choice0"));
        IEnumerable<Button> _alexBtns = buttons.Where(x => x.CompareTag("BtnAlex"));
        IEnumerable<Button> _jesseBtns = buttons.Where(x => x.CompareTag("BtnJesse"));
        foreach (var button in _jesseBtns)
        {
            button.gameObject.SetActive(false);
        }
        _dropdownId = dropdowns.FirstOrDefault(x => x.CompareTag("DropdownId"));


        var _btnAlexMas = _alexBtns.FirstOrDefault(x => x.name.Equals("ButtonAlexMasc"));
        var _btnAlexFem = _alexBtns.FirstOrDefault(x => x.name.Equals("ButtonAlexFem"));

        var _btnJesseMas = _jesseBtns.FirstOrDefault(x => x.name.Equals("ButtonJesseMasc"));
        var _btnJesseFem = _jesseBtns.FirstOrDefault(x => x.name.Equals("ButtonJesseFem"));

        _continueBtn.onClick.AddListener((() =>
        {
            SceneManager.LoadScene("Scene1");
        }));

        _dropdownId.onValueChanged.AddListener(id =>
        {
            PlayerId = id + 1;
            PlayerGender = -1;

            _btnAlexMas.image.sprite = AlexMasNeutral;
            _btnAlexFem.image.sprite = AlexFemNeutral;

            _btnJesseMas.image.sprite = JesseMasNeutral;
            _btnJesseFem.image.sprite = JesseFemNeutral;

            MasBorder.SetActive(false);
            FemBorder.SetActive(false);

            if (id == 0)
            {
                foreach (var button in _alexBtns)
                {
                    button.gameObject.SetActive(true);
                }

                foreach (var button in _jesseBtns)
                {
                    button.gameObject.SetActive(false);

                }
            }

            else if(id == 1)
            {
                foreach (var button in _alexBtns)
                {
                    button.gameObject.SetActive(false);
                }

                foreach (var button in _jesseBtns)
                {
                    button.gameObject.SetActive(true);
                }
            }
        });


        _btnAlexMas.onClick.AddListener(() =>
        {
            PlayerGender = 1;
            _btnAlexMas.image.sprite = AlexMasSelected;
            _btnAlexFem.image.sprite = AlexFemUnselected;
            MasBorder.SetActive(true);
            FemBorder.SetActive(false);
        });

        _btnAlexFem.onClick.AddListener(() =>
        {
            PlayerGender = 2;
            _btnAlexMas.image.sprite = AlexMasUnselected;
            _btnAlexFem.image.sprite = AlexFemSelected;
            MasBorder.SetActive(false);
            FemBorder.SetActive(true);
        });

        _btnJesseMas.onClick.AddListener(() =>
        {
            PlayerGender = 1;
            _btnJesseMas.image.sprite = JesseMasSelected;
            _btnJesseFem.image.sprite = JesseFemUnselected;
            MasBorder.SetActive(true);
            FemBorder.SetActive(false);
        });

        _btnJesseFem.onClick.AddListener(() =>
        {
            PlayerGender = 2;
            _btnJesseMas.image.sprite = JesseMasUnselected;
            _btnJesseFem.image.sprite = JesseFemSelected;
            MasBorder.SetActive(false);
            FemBorder.SetActive(true);
        });


    }

    

    // Update is called once per frame
    void Update()
    {
        if (PlayerGender != -1)
        {
            _continueBtn.interactable = true;
        }

        if (PlayerGender == -1 && _continueBtn.IsInteractable())
        {
            _continueBtn.interactable = false;
        }
    }
}
