using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace Com.MyCompany.MyGame
{
    public class GameControler : MonoBehaviour
    {
          public GameObject canvasRestart;
         public GameObject Win;
         public GameObject Lose;
        public GameObject pause;
        public GameObject pauseol;
        [Header("Canvas")]
        public GameObject CanvasGame;
        public bool checkButton = true;
       
        public GameObject restart;
        // public GameObject downIntance;
        // public GameObject puckRefabs;
        public enum Score
        {
            AiScore, PlayerScore
        }
        public Text AiScoreTxt, PlayerScoreTxt;
        public int MaxScore;
        #region Scores
        private int aiScore, playerScore;
        void Start()
        {
            Screen.orientation = ScreenOrientation.Portrait;
           // Instantiate(puckRefabs,downIntance.transform.position,Quaternion.identity);
        }
        private int AiScore
        {
            get { return aiScore; }
            set
            {
                aiScore = value;
                if (checkButton)
                {
                    if (value == MaxScore)
                    {
                        Debug.Log("Ai win");
                        // uiManager.ShowRestartCanvas(true);
                        // Time.timeScale = 0;
                        canvasRestart.SetActive(true);
                        Lose.SetActive(true);
                        Win.SetActive(false);
                        Invoke("slowly", 0.5f);
                        restart.SetActive(true);
                       
                    }
                }
                else

                {
                    if (value == MaxScore)
                    {

                        canvasRestart.SetActive(true);
                        Lose.SetActive(true);
                        Win.SetActive(false);
                        restart.SetActive(false);
                       
                        Invoke("slowly", 0.5f);


                    }

                }

            }
        }
        public void slowly()
        {
            Time.timeScale = 0;
        }
        public GameObject particel;
        private int PlayerScore
        {
            get { return playerScore; }
            set
            {
                playerScore = value;
                if (checkButton)
                {
                    if (value == MaxScore)
                    {
                        //  uiManager.ShowRestartCanvas(false);
                        // Time.timeScale = 0;
                        canvasRestart.SetActive(true);
                        Lose.SetActive(false);
                        Win.SetActive(true);
                        Invoke("slowly", 0.5f);
                        particel.SetActive(true);
                        restart.SetActive(true);
                    }
                }
                else
                {
                    if (value == MaxScore)
                    {

                        canvasRestart.SetActive(true);
                        Lose.SetActive(false);
                        Win.SetActive(true);

                        Invoke("slowly", 0.5f);
                        particel.SetActive(true);
                        restart.SetActive(false);
                       
                    }
                }
            }
        }
        #endregion

        public void Increment(Score whichScore)
        {
            if (whichScore == Score.AiScore)
            {
                AiScoreTxt.text = (++AiScore).ToString();

            }

            else
            {
                PlayerScoreTxt.text = (++PlayerScore).ToString();
            }
        }

        public void paused (){
            
            pause.SetActive(true);
            Time.timeScale = 0;

        }
        public void pausedol()
        {

            pauseol.SetActive(true);
            Time.timeScale = 0;

        }
        public GameObject playerrestart;
        public GameObject Ai;
        public GameObject playerBlue;
        public void RestartGame()
        {
           
           // SceneManager.LoadScene("PlayBox");
             CanvasGame.SetActive(true);
              canvasRestart.SetActive(false);
             ResetScores();
         
        }
        public void ResetScores()
        {
            Time.timeScale = 1;
            AiScore = PlayerScore = 0;
            AiScoreTxt.text = PlayerScoreTxt.text = "0";
            playerrestart.GetComponent<Rigidbody2D>().transform.position = new Vector2(0, -3f);
            Ai.GetComponent<Rigidbody2D>().transform.position = new Vector2(0, 4f);
            playerBlue.GetComponent<Rigidbody2D>().transform.position = new Vector2(0, 4f);
        }
    }
}
