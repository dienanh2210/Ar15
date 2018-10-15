using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace Com.MyCompany.MyGame
{
    public class MenuManager : MonoBehaviour {
        
        public GameObject canvasMenu;
        public GameObject PlayAi;
        public GameObject playAII;
        public GameObject playPlayer;
        public GameObject playAI;
        public GameObject playerRed;
        public GameObject playerRed1;
       
        public GameObject puckk;
        public GameObject map;
        public GameControler game;
        public GameObject AiO;
        public AiScript aio;
        public GameObject paus;
        public GameObject pausol;
        private void Start()
        {
            Screen.orientation = ScreenOrientation.Portrait;     
            Application.targetFrameRate = 60;
           
        }
        public void Update()
        {

           
        }
        string m_ReachabilityText;
        public GameObject  sectionView2, sectionView3;
        public void Mutiplayer() {
            canvasMenu.SetActive(false);
            //isBack = false;
            //  SceneManager.LoadScene("Menuphoton");

            if (Application.internetReachability == NetworkReachability.NotReachable)
            {

                m_ReachabilityText = "Not Reachable.";
                sectionView3.SetActive(true);
                sectionView2.SetActive(false);
            }

            else if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
            {
                m_ReachabilityText = "Reachable via carrier data network.";
            }

            else if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
            {
                m_ReachabilityText = "Reachable via Local Area Network.";

                sectionView2.SetActive(true);
                sectionView3.SetActive(false);
            }
        }
       
        public void PlayervsPlayer()
        {
            
            playAII.SetActive(true);
            playPlayer.SetActive(true);
            playerRed.SetActive(false);
            playerRed1.SetActive(true);
            playAI.SetActive(false);
            AiO.SetActive(false);
          
            canvasMenu.SetActive(false);
            Time.timeScale = 1;       
            setrest();
            paus.SetActive(true);
            pausol.SetActive(false);
            Invoke("setTriggerr", 1f);
            


        }

        public void PlayAI()
        {
            
            canvasMenu.SetActive(false);          
            PlayAi.SetActive(true);           
            setrest();
           
            Invoke("setTriggerr", 1f);
            
        }
        public void changMap() {
            map.SetActive(true);
            canvasMenu.SetActive(false);

        }
        public GameObject pause;
        public GameObject load;
        public GameObject pausebog;
        public GameObject batterSetting;
        public GameObject themes;
        public GameObject Skins;
        public void changBettlefields()
        {
            batterSetting.SetActive(true);
            canvasMenu.SetActive(false);

        }
        public void changThemes()
        {
            themes.SetActive(true);
            canvasMenu.SetActive(false);

        }
        public void changSkins()
        {
            Skins.SetActive(true);
            canvasMenu.SetActive(false);

        }
        public void Back()
        {
            themes.SetActive(false);
            Skins.SetActive(false);
            batterSetting.SetActive(false);
            game.RestartGame();
            canvasMenu.SetActive(true);
            PlayAi.SetActive(false);
            map.SetActive(false);
            sectionView2.SetActive(false);
            sectionView3.SetActive(false);
            pause.SetActive(false);
            load.SetActive(false);
            pausebog.SetActive(false);
            pausol.SetActive(false);
            playAII.SetActive(false);
            setrest();
           
        }
        public void PlayGame()
        {
            Time.timeScale = 1;
           
            playAII.SetActive(true);
            PlayAi.SetActive(false);
            AiO.SetActive(false);
            paus.SetActive(true);

            pausol.SetActive(false);
            playAI.SetActive(true);
            playPlayer.SetActive(false);
            playerRed.SetActive(true);
            playerRed1.SetActive(false);
            //  SceneManager.LoadScene("AI");
            //  SceneManager.LoadScene("Example", LoadSceneMode.Additive);
            setrest();
            

        }
       
        public void PlayGame0()
        {
            Time.timeScale = 1;
            
            playAII.SetActive(true);
            PlayAi.SetActive(false);
            playAI.SetActive(false);
            AiO.SetActive(true);
            paus.SetActive(false);
            pausol.SetActive(true);
            aio.MaxMovementSpeed = Random.Range(12,30);
            playPlayer.SetActive(false);
            playerRed.SetActive(true);
            playerRed1.SetActive(false);
            //  SceneManager.LoadScene("AI");
            //  SceneManager.LoadScene("Example", LoadSceneMode.Additive);
            setrest();


        }

        public void SetMultiplayer(bool isOn)
        {
            GameValues.IsMultiplayer = isOn;
        }

        #region Difficulty
        public void SetEasyDifficulty(bool isOn)
        {
            if (isOn)
                GameValues.Difficulty = GameValues.Difficulties.Easy;
        }

        public void SetMediumDifficulty(bool isOn)
        {
            if (isOn)
                GameValues.Difficulty = GameValues.Difficulties.Medium;
        }

        public void SetHardDifficulty(bool isOn)
        {
            if (isOn)
                GameValues.Difficulty = GameValues.Difficulties.Hard;
        }
        #endregion





        public void setrest() {
            puckk.GetComponent<Rigidbody2D>().transform.position = new Vector2(0, -0.6f);
            game.ResetScores();
        }

    }
}
