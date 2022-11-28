using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Canvas yellowReticleCanvas;
    [SerializeField] Canvas blueReticleCanvas;
    [SerializeField] Canvas redReticleCanvas;

    private void Start()
    {
        gameOverCanvas.enabled = false; // disables game over canvas during startup
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true; // enables game over canvas after death
        yellowReticleCanvas.enabled = false;
        redReticleCanvas.enabled = false;
        blueReticleCanvas.enabled = false;
        Time.timeScale = 0; // stopping time prevents clashing between game mode and cursor mode
        FindObjectOfType<WeaponSwitcher>().enabled = false; // stops ability to scroll weapons during death
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; // makes cursor visible to player
    }
}
