using System;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Mobiiliesimerkki
{
    public static class LevelLoader
    {
        public enum LoadingState
        {
            None = 0,
            Begin,
            FadeToBlack,
            UnloadingPrevious,
            LoadingNext,
            FadeToClear,
            Finish
        }

        private const string LoadingSceneName = "LoaderScene";
        private static string s_nextSceneName;
        private static Scene s_originalScene;
        private static LoadingState s_loadingState;
        private static Fader s_fader;


        // 1. Ladataan loader-scene additiivisesti ja asynkronisesti
        // 2. Häivytetään näyttö mustaksi
        // 3. Kun näyttö on musta => poistetaan nykyinen scene muistista
        // 4. Aloitetaan uuden scene lataus additiivisesti ja asynkronisesti
        // 5. Kun uusi scene on ladattu => häivytetään näyttö läpinäkyväski
        // 6. Poistetaan loader-scene muistista

        //lataa uusi taso
        public static bool LoadLevel(string levelName)
        {
            // Jos lataus on jo käynnissä, ei tehdä mitään
            if (s_loadingState != LoadingState.None)
            {
                return false;
            }
            // Uuden ladattavan scenen nimi
            s_nextSceneName = levelName;

            // Tallenetaan viittaus nykyiseen sceneen
            s_originalScene = SceneManager.GetActiveScene();

            // Aloitetaan scenen latausprosessi
            s_loadingState = LoadingState.Begin;

            // Aloittaa sceneLoaded eventin kuuntelun välittämällä OnSceneLoaded metodin viittaus kyseiselle eventille
            SceneManager.sceneLoaded += OnSceneLoaded;

            // Aloittaa loader-scenen latauksen
            // LoadMode.Additive lataa scenen additiivisesti, jolloin se ei korvaa nykyistä sceneä
            SceneManager.LoadSceneAsync(LoadingSceneName, LoadSceneMode.Additive);

            return true;
        }

        private static void OnSceneLoaded(Scene loadedScene, LoadSceneMode loadMode)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            switch (s_loadingState)
            {
                case LoadingState.Begin:
                s_fader = GameObject.FindObjectOfType<Fader>();

                Fader.FadeComplete += OnFadeComplete;

                s_fader.StartFade(Fader.State.FadingIn);

                s_loadingState = LoadingState.FadeToBlack;
                break;

                case LoadingState.LoadingNext:

                Fader.FadeComplete += OnFadeComplete;

                s_fader.StartFade(Fader.State.FadingOut);

                break;

            }
        }

        private static void OnFadeComplete()
        {
            Fader.FadeComplete -= OnFadeComplete;

            switch (s_loadingState)
            {
                case LoadingState.FadeToBlack:

                SceneManager.sceneUnloaded += OnSceneUnloaded;
                SceneManager.UnloadSceneAsync(s_originalScene);
                s_loadingState = LoadingState.UnloadingPrevious;
                break;

                case LoadingState.FadeToClear:
                SceneManager.sceneUnloaded += OnSceneUnloaded;
                SceneManager.UnloadSceneAsync(LoadingSceneName);
                s_loadingState = LoadingState.Finish;
                break;
            }
        }

        private static void OnSceneUnloaded(Scene scene)
        {
            SceneManager.sceneUnloaded -= OnSceneUnloaded;

            switch (s_loadingState)
            {
                case LoadingState.UnloadingPrevious:
                SceneManager.sceneLoaded += OnSceneLoaded;
                SceneManager.LoadSceneAsync(s_nextSceneName, LoadSceneMode.Additive);
                s_loadingState = LoadingState.LoadingNext;
                break;

                case LoadingState.Finish:
                s_fader = null;
                s_loadingState = LoadingState.None;
                break;
            }
        }
    }
}
