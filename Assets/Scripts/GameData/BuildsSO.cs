using UnityEngine;

[CreateAssetMenu(fileName = "DataBilds", menuName = "GameData/Builds")]
public class BuildsSO : ScriptableObject
{
    [SerializeField] private string _nameModel;
    [SerializeField] private Build _build;
    [SerializeField] private int _cost;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private TypeBuilds _typeBuilds;
    [SerializeField] private Resources _resources;

    public string NameModel { get => _nameModel;  }
    public Build Build { get => _build; }
    public int Cost { get => _cost; }
    public Sprite Sprite { get => _sprite;  }
    public TypeBuilds TypeBuilds { get => _typeBuilds;}
    public Resources Resources { get => _resources;  }
}