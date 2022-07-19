﻿using UnityEngine;
using UnityEngine.UI;

public class HeartsController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite HudHeadEmpty;
    [SerializeField] private Sprite HudHeadFull;
    [SerializeField] private Sprite HudKeyEmpty;
    [SerializeField] private Sprite HudKeyFull;

    [SerializeField] private GameObject Heart1;
    [SerializeField] private GameObject Heart2;
    [SerializeField] private GameObject Heart3;
    [SerializeField] private GameObject Key;

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        //Debug.Log(player);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.playerHealth == 2)
        {
            Heart3.GetComponent<Image>().sprite = HudHeadEmpty;
        }
        if (player.playerHealth == 1)
        {
            Heart2.GetComponent<Image>().sprite = HudHeadEmpty;
        }
        if (player.playerHealth == 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        if(player.keyCount == 1)
        {
            Key.GetComponent<Image>().sprite = HudKeyFull;
        }


    }
}
