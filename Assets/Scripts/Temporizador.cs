using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Temporizador : MonoBehaviour
{
    [SerializeField]
    private float tempoInicial;
    [SerializeField]
    private GameObject jogador;
    [SerializeField]
    private Global global;
    public int duasEstrelas, tresEstrelas;

    private TMP_Text contadorTexto;
    private PlayerInput playerInput;
    private Coroutine countdownCoroutine;
    public float tempoAtual;

    private InputAction pressPAction; // Ação de input para a tecla "P"

    void Awake()
    {
        // Crie a nova ação de input para a tecla "P"
        pressPAction = new InputAction("PressP", InputActionType.Button, "<Keyboard>/p");

        // Adicione um listener que será chamado quando a ação for acionada
        pressPAction.performed += context => SetTempoAtualTo2();

        // Ative a ação
        pressPAction.Enable();
    }

    void Start()
    {
        contadorTexto = GetComponent<TMP_Text>();
        playerInput = jogador.GetComponent<PlayerInput>();
        tempoAtual = tempoInicial;
    }

    void Update()
    {
        if (global.isPaused)
        {
            Time.timeScale = 0f;
            if (countdownCoroutine != null)
            {
                StopCoroutine(countdownCoroutine);
                countdownCoroutine = null;
            }
        }
        else
        {
            Time.timeScale = 1f;
            if (countdownCoroutine == null)
            {
                countdownCoroutine = StartCoroutine(ContagemRegressiva());
            }
        }
    }

    IEnumerator ContagemRegressiva()
    {
        while (tempoAtual >= 1)
        {
            if (global.isPaused)
            {
                yield return null;
                continue;
            }

            contadorTexto.text = ((int)tempoAtual).ToString();
            yield return null;

            // Só diminui o tempoAtual se o jogo não estiver pausado
            if (!global.isPaused)
            {
                tempoAtual -= Time.deltaTime;
            }
        }

        contadorTexto.text = "ACABOU!";
        global.uiWinning.SetActive(true);
         if (global.contador < tresEstrelas)
         {
             global.TerceiraEstrela.SetActive(false);
         }
            if (global.contador < duasEstrelas)
         {
             global.SegundaEstrela.SetActive(false);
         }
        global.uiContador.SetActive(false);
        global.uiTempo.SetActive(false);
        global.uiPause.SetActive(false);
        global.uiControles.SetActive(false);
        global.uiBotaoPause.SetActive(false);
        global.isFinished = true;
        global.isPaused = true;
        Time.timeScale = 0f;
    }

    // Método que será chamado quando a tecla "P" for pressionada
    void SetTempoAtualTo2()
    {
        tempoAtual = 2f;
    }

    // Certifique-se de desabilitar a ação de input quando o objeto for destruído
    void OnDestroy()
    {
        pressPAction.Disable();
    }
}
