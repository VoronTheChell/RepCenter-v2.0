using UnityEngine;

public class BackButton : MonoBehaviour
{
    public Canvas loginCanvas;
    public Canvas mainCanvas;

    public void SwitchCanvas()
    {
        loginCanvas.gameObject.SetActive(true);
        mainCanvas.gameObject.SetActive(false);
    }
}
