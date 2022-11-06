using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMarket : MonoBehaviour{
    [SerializeField] private RectTransform _panel;
    [SerializeField] private Image _imageSellItem;
    [SerializeField] private Slider _sliderSell;
    [SerializeField] private Text _countSell;
    [SerializeField] private Text _earnedCoin;
    private bool _isOpen;
    private Item _selectedItem;
    private void Update(){
        UpdateUI();
    }

    private void Awake(){
        EventManager.OnChooseItem += SetChooseItem;
    }

    private void OnDisable(){
        EventManager.OnChooseItem -= SetChooseItem;
    }

    public void CloseWindow(){
        _panel.localScale = Vector3.zero;
        _isOpen = false;
    }
    public void OpenWindow(){
        _panel.localScale = Vector3.one;
        _isOpen = true;
    }
    private void SetChooseItem(Item item){
        OpenWindow();
        SettingUI(item);
    }
    private void SettingUI(Item item){
        _selectedItem = item;
        _imageSellItem.sprite = _selectedItem.Icon;
    }
    private void UpdateUI(){
        if (_isOpen){
            _sliderSell.maxValue = Storage.instance.GetCountResource(_selectedItem.TypeItem);
            _countSell.text = _sliderSell.value.ToString();
            _earnedCoin.text = (_sliderSell.value * _selectedItem.Price).ToString();
        }
    }  
    public void SellResource(){
        Storage.instance.AddResource(Resources.Gold, (int)_sliderSell.value * _selectedItem.Price);
        Storage.instance.TakeResource(_selectedItem.TypeItem, (int)_sliderSell.value);
        EventManager.SellResource(_selectedItem, (int)_sliderSell.value);
    } 
}
