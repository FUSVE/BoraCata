using TMPro;
using UnityEngine;

public class Quantidade : MonoBehaviour
{
    public Global global;
    private TMP_Text quantidadeTexto; // referência ao componente de texto
    
    void Start()
    {
        // Obtenha a referência ao componente de texto
        quantidadeTexto = GetComponent<TMP_Text>();
    }

    void Update()
    {
        // Atualiza o contador de texto
        quantidadeTexto.text = "Faltam " + global.quantidade.ToString();
    }
}
