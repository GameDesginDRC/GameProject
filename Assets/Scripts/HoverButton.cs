using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverButton : MonoBehaviour
{
    private Button _button;
    void Start()
    {
        _button = GetComponent<Button>();
    }
    void Update()
    {

    }
    public void Hoveringon() {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Time.timeScale = 1f;
            _button.onClick.Invoke();
        }
    }
}

