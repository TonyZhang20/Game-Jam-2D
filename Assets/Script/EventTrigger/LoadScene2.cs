using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.EventTrigger
{
    
    public class LoadScene2 : MonoBehaviour
    {
        public int index;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                var scene = SceneManager.LoadSceneAsync(index,LoadSceneMode.Additive);
                Destroy(gameObject);
                Debug.Log("RUN ONCE");
            }
        }
    }
}
