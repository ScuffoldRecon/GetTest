using UnityEngine;

public class Potion : Item
{
    // The amount of health to restore
    public int AmountHealth = 20;

    // Reference to the sound to play (assign in the Inspector)
    public AudioClip collectSound;

    // Reference to the AudioSource component (optional if you use a helper function)
    // private AudioSource audioSource; 

    /* * If you want to use the AudioSource on the Potion object:
     
void Start() 
{
audioSource = GetComponent<AudioSource>();
}
*/

    public override void OnCollect(Player player)
    {
        // 1. Play the sound clip once using a static helper function
        // This is generally preferred for one-shot sounds on collected items 
        // as it doesn't rely on the item staying in the scene to finish playing.
        if (collectSound != null)
        {
            // Plays the sound at the potion's position and cleans up after itself
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        }

        base.OnCollect(player);
        player.Heal(AmountHealth);

        // 2. Destroy the Potion GameObject AFTER playing the sound
        // If you were using GetComponent<AudioSource>().Play(), you would 
        // need to wait for the clip to finish before destroying. 
        // PlayClipAtPoint is better for collectables!
        Destroy(gameObject);
    }
}