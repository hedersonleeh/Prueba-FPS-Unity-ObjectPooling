using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField, Range(0, 1f)] private float fireRate;
    [SerializeField]private  FixedButton ShootButton;

    [SerializeField] Animator animator;
    [SerializeField] AudioSource source;
    [SerializeField] ParticleSystem particles;
    private bool canShoot = true;

   
    private void Update()
    {
        
      /* if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && canShoot)
                StartCoroutine(Fire());
        }*/
        if (ShootButton.Pressed)
        {
            if (canShoot)
                StartCoroutine(Fire());
        }
    }
    private IEnumerator Fire()
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        animator.SetTrigger("Shoot");
        source.Play();
        var shot = ShotPool.Instance.Get();
        particles.Emit(1);
        shot.transform.position = transform.position;
        shot.transform.rotation = transform.rotation;
        shot.gameObject.SetActive(true);
        canShoot = true;


    }
}