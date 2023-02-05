using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLifeTestTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider c)
    {
        PlayerLife playerLife = c.GetComponent<PlayerLife>();
        if (playerLife != null)
            playerLife.ChangeOneLife(false);
    }
}
