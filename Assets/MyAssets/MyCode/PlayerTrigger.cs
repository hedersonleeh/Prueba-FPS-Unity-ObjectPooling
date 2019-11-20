using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField, Range(0, 1f)] private float fireRate;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource source;
    [SerializeField] ParticleSystem particles;
    [SerializeField] Slider FireRateslider;
    private bool canShoot = true;

    public void UpdateSlide()
     {
          fireRate =FireRateslider.value;
     }
    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Mouse0))
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