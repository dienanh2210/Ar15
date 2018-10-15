using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;



public class Title : MonoBehaviour {

    #region Declare
    [SerializeField]
    List<Button> lstButton;
    [SerializeField]
    Text  txtLanguage;
  //  public SpriteRenderer backgroud;
    public SpriteRenderer khung;
    public SpriteRenderer ball;
    // public SpriteRenderer ball1   ;
    // public SpriteRenderer ball2;
    // public SpriteRenderer playerball;

    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;
    public GameObject wall4;
    
    public static Title instance;
 
    #endregion

    #region Init
    void OnEnable()
    {
        switch (Application.systemLanguage.ToString())
        {
            case "Japanese":
                SelectJapanese();
                break;
            case "ChineseTraditional":
                SelectChinese1();
                break;
            case "ChineseSimplified":
                SelectChinese2();
                break;
            case "Thai":
                SelectThai();
                break;
            default:
                SelectEnglish();
                break;
        }
       // txtLanguage.text = Appli.GetLocaleText(LocaleTyp.TermLimitedYokai); //key value language
    }
    #endregion

        // Use this for initialization
        void Start() {
        
    }

    // Update is called once per frame
    void Update() {

    }
    #region Language
    void DisalbeButton(string name)
    {
        try
        {
            List<Button> lstTemp = lstButton.FindAll(x => x.name != name);
            Button bt = lstButton.Find(x => x.name == name);
           // txtLanguage.text = Appli.GetLocaleText(LocaleTyp.TermLimitedYokai); //key value language
          //  backgroud.sprite = Appli.GetLocaleImage(LocaleTyp.TermLimitedYokai);
            khung.sprite = Appli.GetLocaleImage(LocaleTyp.MiddleEnding1);
            ball.sprite = Appli.GetLocaleImage(LocaleTyp.ball);
           // ball1.sprite = Appli.GetLocaleImage(LocaleTyp.ball1);
           // ball2.sprite = Appli.GetLocaleImage(LocaleTyp.ball2);
           // playerball.sprite = Appli.GetLocaleImage(LocaleTyp.ball1);
        }
        catch (System.Exception e)
        {

            Debug.Log(e.Message);
        }
    }
  
   
    public void SelectEnglish()
    {
        Appli.SelectedLanguage = LanguageTyp.English;
     
        DisalbeButton("btEnglish");
        wall1.SetActive(true);
        wall2.SetActive(false);
        wall3.SetActive(false);
        wall4.SetActive(false);

    }
   
    public void SelectJapanese()
    {
        Appli.SelectedLanguage = LanguageTyp.Japanese;
        DisalbeButton("btJapanese");
        wall1.SetActive(false);
        wall2.SetActive(true);
        wall3.SetActive(false);
        wall4.SetActive(false);

    }
    public void SelectChinese1()
    {
        Appli.SelectedLanguage = LanguageTyp.Chinese1;
        DisalbeButton("btChinese");
        wall1.SetActive(false);
        wall2.SetActive(false);
        wall3.SetActive(true);
        wall4.SetActive(false);


    }
    public void SelectChinese2()
    {
        Appli.SelectedLanguage = LanguageTyp.Chinese2;
        DisalbeButton("btChinese2");
        wall1.SetActive(false);
        wall2.SetActive(false);
        wall3.SetActive(false);
        wall4.SetActive(true);

    }
    public void SelectThai()
    {
        Appli.SelectedLanguage = LanguageTyp.Thai;
        DisalbeButton("btThai");
       
    }
  
#endregion
}
