using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FoodMenuUI : MonoBehaviour
{
    [Serializable]
    private class FoodVisualElementData
    {
        public Texture2D dishImg;
        public string name;
        public float price;
    }

    [SerializeField] private UIDocument m_UIDocument;

    [SerializeField] private VisualTreeAsset m_backetTemplate;
    [SerializeField] private VisualTreeAsset m_proceedTemplate;
    [SerializeField] private VisualTreeAsset m_dishBoxTemplate;

    private VisualElement m_backet;
    private VisualElement m_order;
    private VisualElement m_dishBox;


    private VisualElement m_container;

    [SerializeField] private List<FoodVisualElementData> m_boxesData = new List<FoodVisualElementData>();


    public void OnEnable()
    {
        var rootElement = m_UIDocument.rootVisualElement;

        m_container = rootElement.Q<VisualElement>("list-container");

        m_backet = m_backetTemplate.CloneTree();
        m_order = m_proceedTemplate.CloneTree();
        m_dishBox = m_dishBoxTemplate.CloneTree();

        foreach(var boxData in m_boxesData)
        {
            Debug.Log("loading");
            VisualElement m_dishBox = m_dishBoxTemplate.CloneTree(); 
            m_dishBox.Q<VisualElement>("dish-image").style.backgroundImage = boxData.dishImg;
            m_dishBox.Q<Label>("dish-descrition-text").text = boxData.name;
            m_dishBox.Q<Label>("price-text").text = boxData.price + "€";
            m_container.Add(m_dishBox);
        }
        // Elements with no values like Buttons can register callBacks


    }

    private void OnDisable()
    {

    }

    public void OnAddButtonClicked()
    {
       // m_container.Add(m_backet);

       
    }
}
