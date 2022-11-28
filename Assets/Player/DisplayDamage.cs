using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas damageCanvas;
    [SerializeField] float damageTime = 0.3f;

    void Start()
    {
        damageCanvas.enabled = false;
    }

    public void ShowDamageCanvas()
    {
        StartCoroutine(Slash());
    }

    IEnumerator Slash()
    {
        damageCanvas.enabled = true;
        yield return new WaitForSeconds(damageTime);
        damageCanvas.enabled = false;
    }
}
