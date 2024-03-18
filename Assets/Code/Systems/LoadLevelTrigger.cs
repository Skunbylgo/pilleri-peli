using UnityEngine;

namespace Mobiiliesimerkki
{
    public class LoadLevelTrigger : MonoBehaviour
    {
        [SerializeField, Tooltip("Tason nimi, joka ladataan")]
        private string _levelName = "Level1";

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                LevelLoader.LoadLevel(_levelName);

            }
        }
    }
}
