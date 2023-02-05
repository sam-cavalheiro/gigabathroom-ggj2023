using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerLifeHUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI livesAmountText;

    // Start is called before the first frame update
    void Start()
    {
        PlayerLife playerLife = FindObjectOfType<PlayerLife>();

        if (playerLife != null)
        {
            SetLifeAtHud(playerLife.Lifes);
            playerLife.onPlayerChangeLife.AddListener(() => SetLifeAtHud(playerLife.Lifes));
        }
    }

    void SetLifeAtHud(int lives)
    {
        livesAmountText.text = lives.ToString();
    }
}
