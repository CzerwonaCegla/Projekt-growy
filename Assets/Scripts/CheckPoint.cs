using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] public ParticleSystem respawnParticle;
    public bool WasTriggered = false;
    public Sprite newCheckpointSprite;
    private SpriteRenderer checkpointSpriteRenderer;
    [SerializeField] private AudioSource activationSound;
    Animator anim;

    private void Start()
    {
        var em = respawnParticle.emission;
        em.rateOverTime = 0;
        checkpointSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void TriggerChange()
    {
        if (WasTriggered == false)
        {
            activationSound.Play();
        }
        checkpointSpriteRenderer.sprite = newCheckpointSprite;
        //anim.SetTrigger("activation");
        WasTriggered = true;
    }

    public IEnumerator particleKor()
    {
        yield return new WaitForSeconds(0.5f);
        var em = respawnParticle.emission;
        em.rateOverTime = 80;
        yield return new WaitForSeconds(1f);
        em.rateOverTime = 0;
    }
}
