using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace pilleripeli
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        protected GameObject coffeeScreen;
        private GameObject coffeeClone;
        public float coffeeMax;
        [SerializeField]
        private float coffee;
        [SerializeField]
        private float coffeePerSip;
        [SerializeField]
        private GameObject coffeeMeter;
        [SerializeField]
        private float coffeeDegradationMult;
        public string lang { get; private set; }
        public bool gameOver = false;
        public GameObject gameOverUI;
        public GameObject scoreText;
        private float timeSurvived = 0.0f;
        public string gameOverType { get; private set; }

        void Start()
        {
            lang = PlayerPrefs.GetString("Lang") != null ? PlayerPrefs.GetString("Lang") : "Eng";
            coffee = coffeeMax;
        }
        public String getScore() { 
            return TimeSpan.FromSeconds(timeSurvived).ToString("g", new CultureInfo("En-Us"));
        }
        void FixedUpdate()
        {
            coffee = Math.Clamp(coffee, 0.0f, coffeeMax);
            if(!gameOver)
            {
                coffeeMeter.GetComponent<RectTransform>().sizeDelta = new Vector2(coffee,98);
                timeSurvived += Time.deltaTime;
                coffee -= Time.deltaTime * coffeeDegradationMult;
            }
            if(coffee <= 0.1f)
            {
                GameOver("Coffee");
            }
        }
        public void DrinkCoffee()
        {
            coffee += coffeePerSip;
        }
        public void LoadCoffee()
        {
            coffeeScreen.SetActive(true);
            //coffeeClone = Instantiate(coffeeScreen,Vector3.zero,Quaternion.identity);
        }
        public void UnloadCoffee()
        {
            coffeeScreen.SetActive(false);
            //Destroy(coffeeClone);
        }
        public void GameOver(string gameOverType)
        {
            this.gameOverType = gameOverType;
            gameOver = true;
            Debug.Log("Showing GameOver screen.");
            gameOverUI.SetActive(true);
            GameObject.Find("CoffeeMeter").SetActive(false);
            //scoreText.GetComponent<TextMeshProUGUI>().text = TimeSpan.FromSeconds(timeSurvived).ToString("mm:ss");
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        public void MainMenu()
        {
            if(lang == "Eng")
                SceneManager.LoadScene("MainMenu");
            else if(lang == "Fin")
                SceneManager.LoadScene("MainMenuFi");
        }
    }
}
