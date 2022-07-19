using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDLoader : MonoBehaviour
{
      private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite HudHeartEmpty;
    [SerializeField] private Sprite HudHeartFull;
    [SerializeField] private Sprite HudKeyEmpty;
    [SerializeField] private Sprite HudKeyFull;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("HUDLoader:Start");
        SceneManager.LoadScene("HUD", LoadSceneMode.Additive);
        
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var player = collision.gameObject.GetComponent<PlayerController>();

            if (player.hasKey == true)
            {
                spriteRenderer.sprite = HudKeyFull;
                //var collider = GetComponent<BoxCollider2D>();
                //collider.enabled = false;
                //Debug.Log("open");
            }
        }
    }
}
