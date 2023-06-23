
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float delayToReload = 2f;
    [SerializeField] private float delayToNextLevel = 2f;
    [SerializeField] private AudioClip success;
    [SerializeField] private AudioClip crash;


    private AudioSource audioSource;

    private bool isTransitioning = false;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision) {

        if (isTransitioning) {
            GetComponent<Movement>().enabled = false;
            return;
        }

        switch (collision.gameObject.tag) {
            case "Friendly":
                Debug.Log("friendly");
                break;
            case "Finish":
                NextLevelSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    private void StartCrashSequence() {
        audioSource.PlayOneShot(crash);
        audioSource.Stop();
        Invoke("ReloadLevel", delayToReload);
        isTransitioning = true;
    }
    private void NextLevelSequence() {
        audioSource.PlayOneShot(success);
        audioSource.Stop();
        Invoke("LoadNextLevel", delayToNextLevel);
        isTransitioning = true;
    }

    private void ReloadLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void LoadNextLevel() {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }



}
