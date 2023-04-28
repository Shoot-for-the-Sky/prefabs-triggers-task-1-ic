# Alien shooter update

In this task i have added the function of player lives, every player has 3 lives at the beggining of the game and will only lose when all 3 lives are lost.
The second unique update i have updated is the player speed boost. Pick up the red orb the gain a speed boost for 5 seconds!

[Itch.io](https://shoot-for-the-sky.itch.io/alien-shooter)

The first upgrade i have made is added the lives function for the player. The code for that function can be seen in the following file:

    DestroyOnTrigger2D.cs

The unique change i have made in the game, is added Speed Upgrade powerup, similar to the shield powerup.
Upon pickup the Speed Upgrade will boost the player's speed for 5 seconds.

The on trigger enter2d function, similar to the Shield upgrade.

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

The upgrade function:

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
