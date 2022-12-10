using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] Canvas winCanvas;
    [SerializeField] Canvas yellowReticleCanvas;
    [SerializeField] Canvas blueReticleCanvas;
    [SerializeField] Canvas redReticleCanvas;
    [SerializeField] TextMeshProUGUI enemiesLeft;

    public int enemyCounter = 30;

    // variable array (for enemies)

    void Start()
    {
        winCanvas.enabled = false;

        // at start, store enemies into array
    }

    void Update()
    {
        DecreaseEnemyCounter();
        DisplayEnemyCounter();
    }

    void DecreaseEnemyCounter() // counts the number of killed enemies until you win
    {
        if (enemyCounter <= 0) // when enemy counter reaches 0, player wins
        {
            HandleWin();
        }
    }

    void DisplayEnemyCounter()
    {
        enemiesLeft.text = "Kill " + enemyCounter.ToString() + " Enemies";
    }

    public void HandleWin()
    {
        winCanvas.enabled = true; // enables win canvas after enough enemies are defeated
        yellowReticleCanvas.enabled = false;
        redReticleCanvas.enabled = false;
        blueReticleCanvas.enabled = false;
        Time.timeScale = 0; // stopping time prevents clashing between game mode and cursor mode
        FindObjectOfType<WeaponSwitcher>().enabled = false; // stops ability to scroll weapons during win
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; // makes cursor visible to player
    }
}
