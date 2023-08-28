using UnityEngine.UIElements;
using UnityEngine;
using System.Xml;
using UnityEngine.SceneManagement;

public class FirstSceneUI : MonoBehaviour
{
    [SerializeField]
    private UIDocument m_UIDocument;

    [SerializeField] private VisualTreeAsset m_FirstScreen;
    [SerializeField] private VisualTreeAsset m_MainMenuTemplate;

    private VisualElement m_MainMenu;

    private VisualElement m_container;

    private Button m_Button;

    public void Start()
    {
        var rootElement = m_UIDocument.rootVisualElement;

        m_container = rootElement.Q<VisualElement>("background");
        
        m_Button = rootElement.Q<Button>("FinnishLanguageButton");

        m_MainMenu = m_MainMenuTemplate.CloneTree();

        // Elements with no values like Buttons can register callBacks
        // with clickable.clicked
        m_Button.clickable.clicked += OnButtonClicked;

    }

    private void OnDestroy()
    {
        m_Button.clickable.clicked -= OnButtonClicked;
    }

    public void OnButtonClicked()
    {
       m_container.Clear();
        m_container.Add(m_MainMenu);
    }
}