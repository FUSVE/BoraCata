using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class Lixos : MonoBehaviour
{
    public Global global;
    
    [SerializeField] 
    private Rig rig;

    private GameObject player;
    
    [SerializeField] 
    private float x, y, z, ajusteY, ajusteX, rotateX;

    private GameObject child;

    // Start is called before the first frame update
    void Start()
    {
        rig.weight = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (global.isCarrying == false)
            {
                rig.weight = 0;  
            }
    }

    void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Player"))
        {  
            if (global.isCarrying == false)
            {  
                global.isCarrying = true;
                global.rightHandTarget.transform.localPosition = new Vector3(x, y + ajusteY, z + ajusteX);
                global.leftHandTarget.transform.localPosition = new Vector3(-x, y + ajusteY, z + ajusteX);
                rig.weight = 1;
                transform.SetParent(other.transform, false);
                transform.localPosition = new Vector3(0, y, z);

                // Aplique a rotação desejada depois de mudar o parent do objeto
                transform.localRotation = Quaternion.Euler(rotateX, 0, 0);
            }
        }
    }

}
