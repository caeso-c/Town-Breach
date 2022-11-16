using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    private void Start()
    {
        gameOverCanvas.enabled = false; // disables game over canvas during startup
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true; // enables game over canvas after death
        Time.timeScale = 0; // stopping time prevents clashing between game mode and cursor mode
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; // makes cursor visible to player
    }
}
