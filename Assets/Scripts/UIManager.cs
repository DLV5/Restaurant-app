using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public VisualTreeAsset firstScreen; // Reference to your first UXML document
    public VisualTreeAsset menuScreen; // Reference to your second UXML document
    public VisualTreeAsset orderFoodScreen; // Reference to your second UXML document
    public VisualTreeAsset totalOrderScreen; // Reference to your second UXML document
    public VisualElement container; // The container element where you'll load the UXML content


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
        container = GameObject.Find("Panel").GetComponent<VisualElement>();

        //LoadUXMLDocument(uxmlDocument1); // Load the initial UXML document
    }

    public void LoadUXMLDocument(VisualTreeAsset uxml)
    {
        container.Clear(); // Clear the container before loading new content
        VisualElement uxmlContent = uxml.CloneTree();
        container.Add(uxmlContent); // Add the new UXML content to the container
    }
}