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

    private Button m_ProceedOrderButton;

    private VisualElement m_container;

    [SerializeField] private List<FoodVisualElementData> m_boxesData = new List<FoodVisualElementData>();


    public void OnEnable()
    {
        var rootElement = m_UIDocument.rootVisualElement;

        m_container = rootElement.Q<VisualElement>("list-container");

        m_backet = m_backetTemplate.CloneTree();
        m_order = m_proceedTemplate.CloneTree();
        m_dishBox = m_dishBoxTemplate.CloneTree();

        m_ProceedOrderButton = m_backet.Q<Button>("proceed-order");

        foreach (var boxData in m_boxesData)
        {
            VisualElement m_dishBox = m_dishBoxTemplate.CloneTree(); 
            m_dishBox.Q<VisualElement>("dish-image").style.backgroundImage = boxData.dishImg;
            m_dishBox.Q<Label>("dish-descrition-text").text = boxData.name;
            m_dishBox.Q<Label>("price-text").text = boxData.price + "€";
            m_dishBox.Q<Button>("add-dish-button").RegisterCallback<ClickEvent>(ev => AddDish(boxData.name, boxData.price));
            m_dishBox.Q<Button>("remove-dish-button").RegisterCallback<ClickEvent>(ev => RemoveDish(boxData.name, boxData.price));
            m_container.Add(m_dishBox);
        }
        // Elements with no values like Buttons can register callBacks
        m_container = rootElement;

        m_container.Add(m_backet);


        m_ProceedOrderButton.clickable.clicked += ProceedOrder;
    }

    private void AddDish(string name, float price)
    {
        Order.Instance.AddDishInOrder(name, price);
        RefreshTotalCost();
    }
    private void RemoveDish(string name, float price)
    {
        Order.Instance.RemoveDishfromOrder(name, price);
        RefreshTotalCost();
    }

    private void RefreshTotalCost()
    {
        Label totalPrice = m_backet.Q<Label>("total-price-label");
        totalPrice.text = "Total price: " + Order.Instance.GetTotalPrice() + "€";
    }
    public void OnAddButtonClicked()
    {
       // m_container.Add(m_backet);

       
    }

    private void ProceedOrder()
    {
        Debug.Log("clicked");
        Order.Instance.SaveOrder();
    }
}
