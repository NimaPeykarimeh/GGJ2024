using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSkip: MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("OutdoorsScene");
        }
    }
}
