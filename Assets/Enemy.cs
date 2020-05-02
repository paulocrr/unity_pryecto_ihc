using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    private Vector3 originalPos;
    public bool walk = false;
    public string type;
    public int life = 3;
    public string markerId;
    public GameObject lifeBar;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("battle", 1);
        animator.SetInteger("moving", 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (walk) {
            transform.Translate((Vector3.forward * Time.deltaTime) / 3);
        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        Debug.Log(obj.tag);
        if (obj.CompareTag("Power"))
        {
            Debug.Log("Entro20");
            life--;
            Destroy(obj);

            if (life <= 0)
            {
                Destroy(this.gameObject);
            }
            else {
                lifeBar.transform.localScale = new Vector3(lifeBar.transform.localScale.x - 0.9f, lifeBar.transform.localScale.y, lifeBar.transform.localScale.z);
                StartCoroutine(playHitAnimation());
            }

        }

       

    }

    IEnumerator playHitAnimation()
    {
        animator.SetInteger("moving", 11);

        yield return new WaitForSeconds(0.1f);
        animator.SetInteger("battle", 1);
        animator.SetInteger("moving", 2);
       
    }

}
