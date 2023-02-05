using System.Collections;
using System.Collections.Generic;
<<<<<<< Updated upstream
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class footsteps : MonoBehaviour
{
    
    public AudioSource footstepsSound;


=======
using UnityEngine;

public class footsteps : MonoBehaviour
{
    public AudioSource footstepsSound;



    private void Update()
    {
>>>>>>> Stashed changes
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 direcao = new Vector3(horizontal, 0f, vertical);
        if (direcao.magnitude > 0)
        {
            footstepsSound.enabled = true;
        }
        else
        {
            footstepsSound.enabled = false;
        }
    }
}