using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Global : MonoBehaviour
{
    public bool isCarrying = false;
    public bool isFinished = false;
    public GameObject player;
    public int contador;
    public int quantidade = 15;
    public Rig rig;
    public GameObject rightHandTarget;
    public GameObject leftHandTarget;
    public GameObject botaoPulo;
    public bool isPaused = true; // Jogo começa pausado
    public GameObject uiPause;
    public GameObject uiTempo;
    public GameObject uiContador;
    public GameObject uiWinning;
    public GameObject SegundaEstrela;
    public GameObject TerceiraEstrela;
    public GameObject uiControles;
    public GameObject uiBotaoPause;
    public GameObject uiExplica1;
    public GameObject hairBoy;
    public GameObject bodyBoy;
    public GameObject hairGirl;
    public GameObject bodyGirl;
    public static int indexChar;
    public Temporizador temporizador;
    public Animator animponto;
    public static int pontuacaofinal;
    public static int tempofinal;
  //  public GameObject pontos;


    private InputAction startGameAction;

    void Awake()
    {
        // Crie uma nova ação de input
        startGameAction = new InputAction("StartGame", InputActionType.Button, "<Keyboard>/enter");

        // Adicione um listener que será chamado quando a ação for acionada
        startGameAction.performed += context => StartGame();

        // Ative a ação
        startGameAction.Enable();
    }

    void Start()
    {
        isPaused = true;
        Time.timeScale = 0f;


        if(indexChar == 0)
        {
            hairBoy.SetActive(true);
            bodyBoy.SetActive(true);
            hairGirl.SetActive(false);
            bodyGirl.SetActive(false);
        }
        else if(indexChar == 1)
        {
            hairBoy.SetActive(false);
            bodyBoy.SetActive(false);
            hairGirl.SetActive(true);
            bodyGirl.SetActive(true);
        }
    }

    void Update()
    {
        if (quantidade == 0)
        {
            temporizador.tempoAtual = 0.2f;
        }
    }


    public void StartGame()
    {
        isPaused = false;
        uiExplica1.SetActive(false);
    }

    public void AnimaSolta()
    {
        rig.weight = 0;
    }

    public void Restart()
    {
        // Recarrega a cena atual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextScene()
    {
        pontuacaofinal = pontuacaofinal+contador;
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }


    // Certifique-se de desabilitar a ação de input quando o objeto for destruído
    void OnDestroy()
    {
        startGameAction.Disable();
    }

    public void Acertou()
    {
        animponto.SetTrigger("acertou");
        contador += 30;
    }

    public void Errou()
    {
        animponto.SetTrigger("errou");
        contador -= 10;
    }
}
