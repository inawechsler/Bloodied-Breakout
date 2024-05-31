 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health;

    private PlayerMovement player;

    [SerializeField] private Music music;

    [SerializeField] private float tiempoPerdidaControl;

    private Animator animator;

    private void Start()
    {
        player = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        music = GetComponent<Music>();
    }

    public void RestartScene()
    {
        int actualScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(actualScene);
    }

    public void TakeDamage(int damage)
    {
        
        health -= damage;

        //animator.SetTrigger("Golpe");

        StartCoroutine(afterLoose());

        //movimientoJugador.Rebote(posicion);

        if (health <= 0)
        {
            OnPlayerDeath();
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            TakeDamage(100);
        }
    }

    private IEnumerator afterLoose()
    {
        player.canMove = false;
        yield return new WaitForSeconds(tiempoPerdidaControl);
        player.canMove = true;
    }
    public void OnPlayerDeath()
    {
        GameManager.Instance.PlayerDied();
    }
}
