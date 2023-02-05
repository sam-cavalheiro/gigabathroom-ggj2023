using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLevelTrigger : MonoBehaviour
{
    [SerializeField] int switchLevelId;

    void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Player"))
            UnityEngine.SceneManagement.SceneManager.LoadScene(switchLevelId);
    }
}
