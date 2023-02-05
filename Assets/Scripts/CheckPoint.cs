using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    public GameObject checkPoint;
    Vector3 spawnPoint;

   void Start()
   {
        spawnPoint = gameObject.transform.position;
   }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < -20f)
        {
            gameObject.transform.position = spawnPoint;
        }
    }

    private void OnTriggerEnter(Collider Other)
    {
        if(Other.gameObject.CompareTag("CheckPoint"))
        {
            spawnPoint = checkPoint.transform.position;
            Destroy(checkPoint);
        }
    }
}
