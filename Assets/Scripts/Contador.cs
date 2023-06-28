using TMPro;
using UnityEngine;

public class Contador : MonoBehaviour
{
    public Global global;
    private TMP_Text contadorTexto; // referência ao componente de texto
    

    void Start()
    {
        // Obtenha a referência ao componente de texto
        contadorTexto = GetComponent<TMP_Text>();
    }

    void Update()
    {
        // Atualiza o contador de texto
        contadorTexto.text = global.contador.ToString();
    }
}
