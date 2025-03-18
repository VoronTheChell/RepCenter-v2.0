using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class DatabaseLogin : MonoBehaviour
{
    public TMP_InputField loginInputField;
    public TMP_InputField passwordInputField;
    public TextMeshProUGUI statusText;

    public Canvas loginCanvas;
    public Canvas mainCanvas;

    private string loginUrl = "http://192.168.0.101:5000/login";

    void Start()
    {
        passwordInputField.contentType = TMP_InputField.ContentType.Password;
        passwordInputField.ForceLabelUpdate();

        loginCanvas.gameObject.SetActive(true);
        mainCanvas.gameObject.SetActive(false);
    }

    public void OnLoginButtonClicked()
    {
        string login = loginInputField.text.Trim();
        string password = passwordInputField.text.Trim();

        if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
        {
            statusText.text = "Введите логин и пароль!";
            return;
        }

        StartCoroutine(SendLoginRequest(login, password));
    }

    private IEnumerator SendLoginRequest(string login, string password)
    {
        var requestData = new LoginRequest { login_user = login, password_user = password };
        string jsonData = JsonUtility.ToJson(requestData);

        UnityWebRequest request = new UnityWebRequest(loginUrl, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            statusText.text = $"Ошибка подключения к серверу: {request.error}";
        }
        else
        {
            try
            {
                var response = JsonUtility.FromJson<LoginResponse>(request.downloadHandler.text);
                if (response.success)
                {
                    statusText.text = "";

                    loginInputField.text = "";
                    passwordInputField.text = "";

                    SwitchCanvas();
                }
                else
                {
                    statusText.text = response.message;
                }
            }
            catch
            {
                statusText.text = "Ошибка обработки ответа сервера.";
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
        public string login_user;
        public string password_user;
    }

    [System.Serializable]
    public class LoginResponse
    {
        public bool success;
        public string message;
        public int id_User;
        public string subject_user;
        public string status_user;
    }
}
