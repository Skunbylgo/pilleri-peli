using UnityEngine;

namespace Mobiiliesimerkki
{
    public enum ItemType
    {
        None = 0,
        Coin,
        Gem,
        Key
    }

    [CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
    public class Item : ScriptableObject
    {
        [SerializeField] private ItemType _type = ItemType.None;
        [SerializeField] private int _value = 0;
        [SerializeField] private string _name = "";
        [SerializeField] private float _weight = 0;
        [SerializeField] private bool _isKeyItem = false;
        [SerializeField] private Sprite _sprite = null;

        public ItemType Type => _type;
        public int Value => _value;
        public string Name => _name;
        public float Weight => _weight;
        public bool IsKeyItem => _isKeyItem;
        public Sprite Sprite => _sprite;
    }
}