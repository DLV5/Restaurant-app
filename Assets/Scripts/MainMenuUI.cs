using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private UIDocument m_UIDocument;

    [SerializeField] private VisualTreeAsset m_FoodMenuTemplate;
    [SerializeField] private VisualTreeAsset m_SettingsTemplate;

    private VisualElement m_FoodMenu;
    private VisualElement m_SettingsMenu;


    private VisualElement m_container;

    private Button m_ToFoodMenuButton;
    private Button m_ToSettingsButton;

    public void OnEnable()
    {
        var rootElement = m_UIDocument.rootVisualElement;

        m_container = m_UIDocument.rootVisualElement;

        m_ToFoodMenuButton = rootElement.Q<Button>("Order-button");
        m_ToSettingsButton = rootElement.Q<Button>("Settings-button");

        m_FoodMenu = m_FoodMenuTemplate.CloneTree();
        m_SettingsMenu = m_SettingsTemplate.CloneTree();

        // Elements with no values like Buttons can register callBacks
        // with clickable.clicked
        m_ToFoodMenuButton.clickable.clicked += OnFoodButtonClicked;
        m_ToSettingsButton.clickable.clicked += OnSettingsButtonClicked;

    }

    private void OnDisable()
    {
        m_ToFoodMenuButton.clickable.clicked -= OnFoodButtonClicked;
        m_ToSettingsButton.clickable.clicked -= OnSettingsButtonClicked;
    }

    public void OnFoodButtonClicked()
    {
        m_container.Clear();
        m_container.Add(m_FoodMenu);

        UIScriptsManager.Instance.SwitchScreen(CurrentScreen.ChooseFood);
    }
    public void OnSettingsButtonClicked()
    {
        m_container.Clear();
        m_container.Add(m_SettingsMenu);

        UIScriptsManager.Instance.SwitchScreen(CurrentScreen.ChooseLanguage);
    }

}
