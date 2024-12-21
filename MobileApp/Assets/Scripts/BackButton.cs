using UnityEngine;

public class BackButton : MonoBehaviour
{
    public Canvas loginCanvas;  // Canvas �����
    public Canvas mainCanvas;   // Canvas ��� ����������� ����� ��������� �����

    public void SwitchCanvas()
    {
        loginCanvas.gameObject.SetActive(true);
        mainCanvas.gameObject.SetActive(false);
    }
}
