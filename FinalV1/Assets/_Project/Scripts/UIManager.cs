using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject colorPanel;

    private bool isMainOpen = true;

    public void ToggleMain()
    {
        isMainOpen = !isMainOpen;

        mainPanel.SetActive(isMainOpen);
        colorPanel.SetActive(!isMainOpen);
    }
}
