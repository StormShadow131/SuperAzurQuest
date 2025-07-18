using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public TrashGaugeManager trashGaugeManager;
    public EndMessage endMessage;

    public TMP_Text killEnemyUI;

    private void Awake()
    {
        killEnemyUI = GameObject.FindGameObjectWithTag("KillEnemyUI").GetComponent<TMP_Text>();
    }

    void Start()
    {
        killEnemyUI.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (trashGaugeManager.FullGauge())
            {
                endMessage.StartEndSequence();
                Destroy(gameObject); // Pour éviter qu’on déclenche 2 fois
            }
            else
            {
                ShowKillEnemyMessage(3f);
            }
        }
    }
    private void ShowKillEnemyMessage(float duration)
    {
        killEnemyUI.enabled = true;
        StartCoroutine(HideKillEnemyMessageAfterDelay(duration));
    }

    private System.Collections.IEnumerator HideKillEnemyMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        killEnemyUI.enabled = false;
    }
}
