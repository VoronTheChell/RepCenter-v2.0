using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;


public class DatabaseLogin : MonoBehaviour
{
    public TMP_InputField loginInputField;  // Поле для ввода логина
    public TMP_InputField passwordInputField;  // Поле для ввода пароля
    public Text statusText;  // Текст для отображения статуса (успех или ошибка)

    public Canvas loginCanvas;  // Canvas входа
    public Canvas mainCanvas;   // Canvas для отображения после успешного входа

    private string apiUrl = "http://192.168.0.105:5000/api/Auth/login"; // URL вашего API

    void Start()
    {
        loginCanvas.gameObject.SetActive(true);
        mainCanvas.gameObject.SetActive(false);
    }

    public void OnLoginButtonClicked()
    {
        string login = loginInputField.text;
        string password = passwordInputField.text;

        StartCoroutine(SendLoginRequest(login, password));
    }

    private IEnumerator SendLoginRequest(string login, string password)
    {
        var requestData = new LoginRequest { Login = login, Password = password };
        string jsonData = JsonUtility.ToJson(requestData);

        UnityWebRequest request = new UnityWebRequest(apiUrl, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            statusText.text = "Ошибка подключения к серверу: " + request.error;
        }
        else
        {
            var response = JsonUtility.FromJson<LoginResponse>(request.downloadHandler.text);
            if (response.success)
            {
                statusText.text = "Успешный вход!";
                SwitchCanvas();
            }
            else
            {
                statusText.text = response.message;
            }
        }
    }

    private void SwitchCanvas()
    {
        loginCanvas.gameObject.SetActive(false);
        mainCanvas.gameObject.SetActive(true);
    }

    [System.Serializable]
    public class LoginRequest
    {
        public string Login;
        public string Password;
    }

    [System.Serializable]
    public class LoginResponse
    {
        public bool success;
        public string message;
    }
}
