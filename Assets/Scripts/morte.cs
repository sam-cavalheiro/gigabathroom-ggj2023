using UnityEngine;

public class morte : MonoBehaviour
{
<<<<<<< Updated upstream
  private void OnTriggerEnter(Collider other)
  {
    Debug.Log(other.gameObject.name);
    var Player = other.gameObject.GetComponent<Player>();
=======
  private void OnCollisionEnter(Collision other)
  {
    Debug.Log(other.gameObject.name);
    var Player = other.collider.GetComponent<Player>();
>>>>>>> Stashed changes
    if (Player != null)
    {
        Player.Die();
    }
  }
}
