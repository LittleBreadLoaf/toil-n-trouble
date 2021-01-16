using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public Image[] hearts;
    public FloatValue heartContainers;
    public Sprite fullHeart;
    public Sprite threeQuarterHeart;
    public Sprite halfHeart;
    public Sprite quarterHeart;
    public Sprite emptyHeart;
    public FloatValue playerCurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        InitHearts();
    }

    public void InitHearts()
    {
        for(int i = 0; i < heartContainers.value; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        }
    }

    public void UpdateHearts()
    {
        int heartSelect = (int)playerCurrentHealth.value / 4;
        int sprite = (int)playerCurrentHealth.value % 4;

        for(int i = 0; i < heartContainers.value; i++)
        {
            if(i < heartSelect)
            {
                hearts[i].sprite = fullHeart;
            } else if(i > heartSelect)
            {
                hearts[i].sprite = emptyHeart;
            }
            else
            {
                switch (sprite)
                {
                    case 0:
                        hearts[i].sprite = emptyHeart;
                        break;
                    case 1:
                        hearts[i].sprite = quarterHeart;
                        break;
                    case 2:
                        hearts[i].sprite = halfHeart;
                        break;
                    case 3:
                        hearts[i].sprite = threeQuarterHeart;
                        break;
                }
            }
        }
    }
}
