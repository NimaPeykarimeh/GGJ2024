using UnityEngine;

public class ToEndScreen : MonoBehaviour
{
    public GameObject EndScreen;
    public GameObject HUD;

    void Start()
    {
        HUD.SetActive(true);
        EndScreen.SetActive(false);
    }
    public void ShowEndScreenPanel()
    {
        EndScreen.SetActive(true);
        HUD.SetActive(false);
    }

    public void HideEndScreenPanel()
    {
        EndScreen.SetActive(false);
        HUD.SetActive(true);
    }
}
