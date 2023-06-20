
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        switch (collision.gameObject.tag) {
            case "Friendly":
                Debug.Log("friendly");
                break;
            case "Finish":
                Debug.Log("yee");
                break;
            default:
                Debug.Log("other");
                break;
        }
    }
}
