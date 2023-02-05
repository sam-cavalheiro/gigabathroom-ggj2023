using UnityEngine;

public class morte : MonoBehaviour
{
  private void OnCollissionEnter(Collision other)
  {
    var Player = other.collider.GetComponent<Player>();
    if (Player != null)
    {
        Player.Die();
    }
  }
}
