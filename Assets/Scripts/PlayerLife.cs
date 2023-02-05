using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLife : MonoBehaviour
{
    public int Lifes { get => lives; private set => lives = value; }
    [SerializeField] int gameOverSceneId;
    [SerializeField] int lives;
    public UnityEvent onPlayerChangeLife = new UnityEvent();

    public void ChangeOneLife(bool positive)
    {
        lives += positive ? 1 : -1;
        onPlayerChangeLife.Invoke();

        if (lives < 0)
            UnityEngine.SceneManagement.SceneManager.LoadScene(gameOverSceneId);
    }
}
