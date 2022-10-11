using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UImanager : MonoBehaviour
{

    public static UImanager Instance;

    [SerializeField] private PERSONAJESTATS stats;
    [SerializeField] private GameObject panelstats;
    [SerializeField] private GameObject panelexp;
    [SerializeField] private GameObject panelMissions;
    [SerializeField] private GameObject panelKingdom;
    [SerializeField] private GameObject InventoryPanel;
    [SerializeField] private GameObject CharacterMenu;
    [SerializeField] private Image vidaplayer;
    [SerializeField] private TextMeshProUGUI nombrepersonaje;
    [SerializeField] private TextMeshProUGUI vidatmp;
    [SerializeField] private Image manaplayer;
    [SerializeField] private TextMeshProUGUI manatmp;
    [SerializeField] private Image expplayer;
    [SerializeField] private TextMeshProUGUI exptmp;
    [SerializeField] private TextMeshProUGUI niveltmp;
    
   

    [SerializeField] private TextMeshProUGUI dañostattmp;
    [SerializeField] private TextMeshProUGUI defensastattmp;
    [SerializeField] private TextMeshProUGUI criticostattmp;
    [SerializeField] private TextMeshProUGUI bloqueostattmp;
    [SerializeField] private TextMeshProUGUI velocidadstattmp;
    [SerializeField] private TextMeshProUGUI nivelstattmp;
    [SerializeField] private TextMeshProUGUI expstattmp;
    [SerializeField] private TextMeshProUGUI expreqstattmp;

    [SerializeField] private TextMeshProUGUI fuerzatmp;
    [SerializeField] private TextMeshProUGUI destrezatmp;
    [SerializeField] private TextMeshProUGUI inteligenciatmp;
    [SerializeField] private TextMeshProUGUI atributosdisponiblestmp;

    int counter;
    private float vidaactual;
    private float vidamaxima;
    private float manaactual;
    private float manamaxima;
    private float expactual;
    private float expparanuevonivel;
    public int testclicks = 0;
    // Start is called before t
    //
    //
    //
    // he first frame update

    private void Awake()
    {
        Instance = this;
    }

    void Start()

    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        Actualizaruiplayer();
        Actualizarpanelstats();
       if (Input.GetKeyDown(KeyCode.P))
        {
            ShowHidestatsPanel();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            ShowexpPanel();
        }
       
    }
    public void Actualizarvidaplayer(float pvidaactual, float pvidamaxima)
    {
        vidaactual = pvidaactual;
        vidamaxima = pvidamaxima;
    }
    public void Actualizarmanaplayer(float pmanaactual, float pmanamaxima)
    {
        manaactual = pmanaactual;
       manamaxima = pmanamaxima;
    }
    public void Actualizarexperienciaplayer(float pexpactual, float pexpparanuevonivel)
    {
       expactual = pexpactual;
        expparanuevonivel = pexpparanuevonivel;
    }
    private void ShowHidestatsPanel()
    {
        counter ++;
        if (counter % 2 == 1)
        {

            panelstats.gameObject.SetActive(false);
        }
        else
        {
            panelstats.gameObject.SetActive(true);
        }
    }
    public void HideexpPanel()
    {
       
            panelexp.gameObject.SetActive(false);
        
       
    }

    public void ShowexpPanel()
    {
       
            panelexp.gameObject.SetActive(true);
            testclicks++;
    }

    public void ShowCM()
    {

        CharacterMenu.gameObject.SetActive(true);
        testclicks++;
    }

    public void HideCM()
    {

        CharacterMenu.gameObject.SetActive(false);
        testclicks++;
    }
    public void ShowKP()
    {

        panelKingdom.gameObject.SetActive(true);
        testclicks++;
    }

    public void HideKP()
    {

        panelKingdom.gameObject.SetActive(false);
        testclicks++;
    }
    public void ShowPM()
    {

        panelMissions.gameObject.SetActive(true);
        testclicks++;
    }

    public void HidePM()
    {

        panelMissions.gameObject.SetActive(false);
        testclicks++;
    }
    public void ShowInventory()
    {

        InventoryPanel.gameObject.SetActive(true);
        testclicks++;
    }

    public void HideInventory()
    {

        InventoryPanel.gameObject.SetActive(false);
        testclicks++;
    }

    private void Actualizaruiplayer()
    {
        vidaplayer.fillAmount = Mathf.Lerp(vidaplayer.fillAmount, vidaactual / vidamaxima, 10f * Time.deltaTime);
        manaplayer.fillAmount = Mathf.Lerp(manaplayer.fillAmount, manaactual / manamaxima, 10f * Time.deltaTime);
       expplayer.fillAmount = Mathf.Lerp(expplayer.fillAmount, expactual / expparanuevonivel, 10f * Time.deltaTime);

        nombrepersonaje.text = $"{stats.name}";
        vidatmp.text = $"{vidaactual}/{vidamaxima}";
        manatmp.text = $"{manaactual}/{manamaxima}";
        exptmp.text = $"{expactual}/{expparanuevonivel}";
        niveltmp.text = $"Level {stats.Nivel}";
    }
    private void Actualizarpanelstats()
    {
if (panelstats.activeSelf == false)
        {
            return;
        }
        //nombrepersonaje.text = stats.Nombre.ToString();
        dañostattmp.text = stats.Daño.ToString();
        defensastattmp.text = stats.Defensa.ToString();
        criticostattmp.text =  $"{stats.PorcentajeCritico.ToString()}%";
        bloqueostattmp.text = $"{stats.PorcentajeBloqueo.ToString()}%";
       velocidadstattmp.text = stats.Velocidad.ToString();
        nivelstattmp.text = stats.Nivel.ToString();
        expstattmp.text = stats.Expactual.ToString();
        expreqstattmp.text = stats.Exprequerida.ToString();


        fuerzatmp.text = stats.Fuerza.ToString();
        destrezatmp.text = stats.Destreza.ToString();
        inteligenciatmp.text = stats.Inteligencia.ToString();
        atributosdisponiblestmp.text = $"Points{stats.PuntosDisponibles}";
    }
}
