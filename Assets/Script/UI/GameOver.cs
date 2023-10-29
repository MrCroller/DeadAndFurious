using DF.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOverPanel = default;

    public void ShowPanel()
    {
        Time.timeScale = 0;
        _gameOverPanel.SetActive(true);
    }
}
