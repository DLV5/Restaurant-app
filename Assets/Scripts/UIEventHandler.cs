using UnityEngine.UIElements;
using UnityEngine;
using System.Xml;
using UnityEngine.SceneManagement;

public class UIEventHandler : MonoBehaviour
{
    [SerializeField]
    private UIDocument m_UIDocument;

    private Button m_Button;

    public void Start()
    {
        var rootElement = m_UIDocument.rootVisualElement;

        // This searches for the VisualElement Button named “EventButton”
        // rootElement.Query<> and rootElement.Q<> can both be used
        m_Button = rootElement.Q<Button>("FinnishLanguageButton");

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
        SceneManager.LoadScene("MainMenuScreen"); // Transition to the second UXML document
    }
}