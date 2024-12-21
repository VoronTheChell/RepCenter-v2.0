using UnityEngine;

public class BackButton : MonoBehaviour
{
    public Canvas loginCanvas;  // Canvas входа
    public Canvas mainCanvas;   // Canvas для отображения после успешного входа

    public void SwitchCanvas()
    {
        loginCanvas.gameObject.SetActive(true);
        mainCanvas.gameObject.SetActive(false);
    }
}
