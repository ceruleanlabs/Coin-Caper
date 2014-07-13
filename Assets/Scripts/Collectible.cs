using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {
    public GameObject destroyParticles;

    public void pickup()
    {
        if (destroyParticles != null)
        {
            Instantiate(destroyParticles, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
