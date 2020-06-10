using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameObject GameManager;
    // Update is called once per frame
    void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Player")
        {
            //Level Comlete
            GameManager.GetComponent<TestManager>().EndGame();
        }
    }
}
