using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FoodMenuUI : MonoBehaviour
{
    private class FoodVisualElementData
    {
        public string name;
        public decimal price;
    }

    [SerializeField] private UIDocument m_UIDocument;

    [SerializeField] private VisualTreeAsset m_backetTemplate;
    [SerializeField] private VisualTreeAsset m_proceedTemplate;

    private VisualElement m_backet;
    private VisualElement m_order;


    private VisualElement m_container;

    private List<FoodVisualElementData> m_boxesData = new List<FoodVisualElementData>();


    public void OnEnable()
    {
        var rootElement = m_UIDocument.rootVisualElement;

        m_container = rootElement.Q<VisualElement>("list-container");


        m_backet = m_backetTemplate.CloneTree();
        m_order = m_proceedTemplate.CloneTree();

        // Elements with no values like Buttons can register callBacks
        

    }

    private void OnDisable()
    {

    }

    public void OnAddButtonClicked()
    {
        m_container.Add(m_backet);

       
    }
}
