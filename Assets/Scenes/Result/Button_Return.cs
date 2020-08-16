using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button_Return : MonoBehaviour
{
    public Button button_return;

    void Start()
    {
        button_return.onClick.AddListener(Button_return_Click);
    }

    void Button_return_Click()
    {
        SceneManager.LoadScene("Title");
    }
}
