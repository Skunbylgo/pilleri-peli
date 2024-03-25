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
        public bool gameOver = false;
        public GameObject gameOverUI;
        public GameObject scoreText;
        private float timeSurvived = 0.0f;
        public String getScore() { 
            return TimeSpan.FromSeconds(timeSurvived).ToString("g", new CultureInfo("En-Us"));
        }
        // Start is called before the first frame update

        // Update is called once per frame
        void FixedUpdate()
        {
            if(!gameOver)
                timeSurvived += Time.deltaTime;
        }
        public void GameOver()
        {
            gameOver = true;
            Debug.Log("Showing GameOver screen.");
            gameOverUI.SetActive(true);
            //scoreText.GetComponent<TextMeshProUGUI>().text = TimeSpan.FromSeconds(timeSurvived).ToString("mm:ss");
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
