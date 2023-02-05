using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    PlayerInput playerInput;
    [SerializeField] GameObject pauseUiRootGo;

    void Awake()
    {
        playerInput = new PlayerInput();
    }

    void Update()
    {
        if (playerInput.Player.PauseGame.triggered)
            PauseOrUnpause();
    }

    public void PauseOrUnpause()
    {
        pauseUiRootGo.SetActive(!pauseUiRootGo.activeSelf);
        Time.timeScale = pauseUiRootGo.activeSelf ? 0f : 1f;
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }
}
