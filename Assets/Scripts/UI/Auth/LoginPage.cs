using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.Auth
{
    public class LoginPage : MonoBehaviour
    {
        public event Action RegButtonClicked;

        [SerializeField] private TMP_InputField _emailInputField;
        [SerializeField] private TMP_InputField _passwordInputField;
        [Space]
        [SerializeField] private Button _loginButton;
        [SerializeField] private Button _regButton;
        [Space]
        [SerializeField] private GameObject _loadingScreen;
        [Space]
        [SerializeField] private Toggle _enableDevLogin;

        private void Start()
        {
            _loadingScreen.SetActive(false);
            _regButton.onClick.AddListener(() => RegButtonClicked?.Invoke());
            _loginButton.onClick.AddListener(() => StartCoroutine(_enableDevLogin.isOn ? DevLogin() : Login()));
        }

        private IEnumerator Login()
        {
            WWWForm form = new WWWForm();
            form.AddField("username", _emailInputField.text);
            form.AddField("password", _passwordInputField.text);
            
            _loadingScreen.SetActive(true);
            
            UnityWebRequest uwr = UnityWebRequest.Post(Constants.ServerAddress + "/Auth", form);
            yield return uwr.SendWebRequest();

            if (uwr.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("Error While Sending: " + uwr.error);
                _loadingScreen.SetActive(false);
            }
            else
            {
                Debug.Log("Received: " + uwr.downloadHandler.text);
                if (uwr.responseCode == 200)
                {
                    SceneManager.LoadSceneAsync("Room");
                }
            }
        }

        private IEnumerator DevLogin()
        {
            _loadingScreen.SetActive(true);

            yield return new WaitForSeconds(3);
            
            SceneManager.LoadSceneAsync("Room");
        }
    }
}