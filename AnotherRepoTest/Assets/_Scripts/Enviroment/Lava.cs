using System.Collections;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public GameObject fireAnimationA;
    public GameObject fireAnimationB;
    public GameObject fireAnimationC;
    public float interval = 2f;

    private void Start()
    {
        StartCoroutine(TriggerFireAnimations());
    }

    IEnumerator TriggerFireAnimations()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);

            // Choose a random fire animation
            int randomIndex = Random.Range(0, 3);

            // Activate the chosen fire animation and deactivate the others
            fireAnimationA.SetActive(randomIndex == 0);
            fireAnimationB.SetActive(randomIndex == 1);
            fireAnimationC.SetActive(randomIndex == 2);
        }
    }
}
