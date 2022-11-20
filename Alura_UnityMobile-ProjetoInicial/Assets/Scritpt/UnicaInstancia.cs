using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnicaInstancia : MonoBehaviour
{
    [SerializeField]
    private bool sobrescreverExistente;

    // Start is called before the first frame update
    void Start()
    {
        var outrasInstancias = GameObject.FindGameObjectsWithTag(this.tag);
        foreach (var instancia in outrasInstancias)
        {
            if(instancia != this.gameObject)
            {
                if (sobrescreverExistente)
                {
                    GameObject.Destroy(instancia.gameObject);
                }
                else
                {
                    GameObject.Destroy(this.gameObject);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
