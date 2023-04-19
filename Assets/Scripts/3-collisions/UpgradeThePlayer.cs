using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeThePlayer : MonoBehaviour
{
    [Tooltip("The number of seconds that the upgrade remains active")] [SerializeField] float duration;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            Debug.Log("Upgrade triggered by player");
            var destroyComponent = other.GetComponent<DestroyOnTrigger2D>();
            if (destroyComponent) {
                destroyComponent.StartCoroutine(UpgradeTemporarily(destroyComponent, other));        
                Destroy(gameObject);  // Destroy the upgrade itself
            }
        } else {
            Debug.Log("Upgrade triggered by "+other.name);
            
        }
    }

    private IEnumerator UpgradeTemporarily(DestroyOnTrigger2D destroyComponent, Collider2D other) {   // co-routines
    // private async void ShieldTemporarily(DestroyOnTrigger2D destroyComponent) {      // async-await
        InputMover inputmover = other.GetComponent<InputMover>();
        
        for (float i = duration; i > 0; i--) {
            Debug.Log("Speed upgrade: " + i + " seconds remaining!");
            inputmover.SetSpeed(14f);
            
            yield return new WaitForSeconds(1);       // co-routines
            // await Task.Delay(1000);                // async-await
        }
        inputmover.SetSpeed(setSpeed: 5f);

        Debug.Log("Speed upgrade gone!");

        
        
        
        
        
    }
}
