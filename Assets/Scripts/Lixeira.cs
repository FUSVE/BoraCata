using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lixeira : MonoBehaviour
{
    [SerializeField] Animator animator;
    public Global global;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   void OnTriggerEnter(Collider other)
{
    if (other.gameObject.layer == 6)
    {
        global.isCarrying = false;
        other.transform.parent = null; // "other" perde o "parent"
        global.quantidade = global.quantidade - 1;
        this.animator.SetTrigger("jogouFora");

        if (other.CompareTag(gameObject.tag))
        {
            global.Acertou();
        }
        else
        {
            global.Errou(); 
        }

        Debug.Log(global.contador);
        StartCoroutine(DestroyAfterDelay(other.gameObject)); // inicia Coroutine
    }
}

IEnumerator DestroyAfterDelay(GameObject objectToDestroy)
{
    yield return new WaitForSeconds(0.1f); // espera por 0.1f
    Destroy(objectToDestroy); // destrói o objeto
    global.isCarrying = false;
}

}

