using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // Importe o namespace TMPro

public class GameControl : MonoBehaviour
{
    public GameObject sobre;
    public GameObject textofinal;
    public GameObject selecao;  

    // Este é o componente TextMeshPro
    private TextMeshProUGUI textoFinalTextMeshPro;

    private void Awake()
    {
        // Obtenha o componente TextMeshPro
        textoFinalTextMeshPro = textofinal.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        // Atualize o texto do componente TextMeshPro para exibir pontuacaofinal
        textoFinalTextMeshPro.text = Global.pontuacaofinal.ToString();
    }

    public void ComecaMenino()
    {
        Global.indexChar = 0;
        LoadNextScene();
    }

    public void ComecaMenina()
    {
        Global.indexChar = 1;
        LoadNextScene();
    }

    public void MostraSobre()
    {
        sobre.SetActive(!sobre.activeSelf);
    }

    public void Selecao()
    {
        selecao.SetActive(true);
        sobre.SetActive(false);
    }

    private void LoadNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(1);
    }

    public void LoadFirstScene()
    {
        Global.pontuacaofinal = 0;
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
