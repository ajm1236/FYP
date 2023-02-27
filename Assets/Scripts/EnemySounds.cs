using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    AudioController controller;
    bool cooldown;
    public float cooldownTime;

    // Start is called before the first frame update
    void Start()
    {
        controller = AudioController.controller;


    }

    private void Update()
    {
        if(!cooldown)
        {
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        cooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        controller.Boombox("LepGrowl");
        cooldown = false;
    }
}
