using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace pilleripeli
{
    public class GameManager : MonoBehaviour
    {
        public string lang { get; private set; }
        public bool gameOver = false;
        public GameObject gameOverUI;
        public GameObject scoreText;
        private float timeSurvived = 0.0f;
        public string gameOverType { get; private set; }

        void Start()
        {
            lang = "Fin";
        }
        public String getScore() { 
            return TimeSpan.FromSeconds(timeSurvived).ToString("g", new CultureInfo("En-Us"));
        }
        // Start is called before the first frame update

        // Update is called once per frame
        void FixedUpdate()
        {
            if(!gameOver)
            {
                timeSurvived += Time.deltaTime;
            }
        }
        public void GameOver()
        {
            gameOverType = "PatientDead";
            gameOver = true;
            Debug.Log("Showing GameOver screen.");
            gameOverUI.SetActive(true);
            //scoreText.GetComponent<TextMeshProUGUI>().text = TimeSpan.FromSeconds(timeSurvived).ToString("mm:ss");
        }
        public void OutOfCoffee()
        {
            gameOverType = "Coffee";
            gameOver = true;
            Debug.Log("Showing GameOver screen.");
            gameOverUI.SetActive(true);
        }
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        public void MainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
