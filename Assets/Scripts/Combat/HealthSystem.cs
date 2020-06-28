using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public float StartingHealth = 75;
    public float HealthMaxLimit = 100;
    public float HealthMinLimit = 0;
    //
    public Image healthFillImage;
    //
    private float currentHealth;

    private void Start() 
    {
        // reset Health
        currentHealth = StartingHealth;
        UpdateHealtBarImage(currentHealth);
    }

    public void SubtractHealth(float amount)
    {
        currentHealth -= amount;
        UpdateHealtBarImage(currentHealth);
        if (currentHealth <= HealthMinLimit)
        {
            HandleDie();
        }
    }

    private void UpdateHealtBarImage(float amount)
    {
        healthFillImage.fillAmount = amount /(float)StartingHealth;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            float damage = other.GetComponent<BulletController>().Damage;
            SubtractHealth(damage);
        }
    }

    private void HandleDie()
    {
        // TODO Die Effect here
        // Alert GameManager by send the parent game object
        GameManager.Instance.EntityDie(transform.parent.gameObject);
    }
    public void RestartHealtSystem()
    {
        currentHealth = StartingHealth;
        UpdateHealtBarImage(currentHealth);
    }


    public void AddHealth(float amount)
    {
        //Not implimented
    }



    // IEnumerator Explode(Transform chiledPos, Vector3 target, float duration)
    // {
    //     float startTime = Time.time;
    //     while (Time.time < startTime + duration)
    //     {
    //         chiledPos.position += Time.deltaTime * target;
    //         yield return null;
    //     }
    // }
}
