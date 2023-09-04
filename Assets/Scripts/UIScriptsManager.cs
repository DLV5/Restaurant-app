using UnityEngine;

public enum CurrentScreen
{
    ChooseLanguage,
    MainMenu,
    ChooseFood,
    Order
}

public class UIScriptsManager : MonoBehaviour
{
    public static UIScriptsManager Instance;

    [SerializeField] private ChooseLanguageUI _chooseLanguageUI;
    [SerializeField] private MainMenuUI _mainMenuUI;
    [SerializeField] private FoodMenuUI _foodMenuUI;

    private CurrentScreen _currentScreen = CurrentScreen.ChooseLanguage;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        SwitchScreen(CurrentScreen.ChooseLanguage);
    }
    public void SwitchScreen(CurrentScreen newScreen)
    {
        _currentScreen = newScreen;

        DisableAllScripts();

        switch (newScreen)
        {
            case CurrentScreen.ChooseLanguage:
                _chooseLanguageUI.enabled = true;
                break;
            case CurrentScreen.MainMenu:
                _mainMenuUI.enabled = true;
                break;
            case CurrentScreen.ChooseFood:
                _foodMenuUI.enabled = true;
                break;
            case CurrentScreen.Order: 
                break;
            default:
                break;
        }
    }

    private void DisableAllScripts()
    {
        _chooseLanguageUI.enabled = false;
        _mainMenuUI.enabled = false;
        _foodMenuUI.enabled = false;
    }
}