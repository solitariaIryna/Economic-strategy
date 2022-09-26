using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private Transform _pointCenter;
    public Transform PointCenter { get => _pointCenter;}
    [SerializeField] private MeshRenderer meshRenderer;
    private bool _isBuild;
    public bool IsBuild { get => _isBuild; set => _isBuild = value; }

    public void Activate()
    {
        meshRenderer.materials[0].color = Color.green;
    }

    public void DisActivate()
    {
        meshRenderer.materials[0].color = Color.white;
    }

    void Start()
    {
        //Activate();
    }

}
