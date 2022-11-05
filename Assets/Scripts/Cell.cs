using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private Transform _pointCenter;
    [SerializeField] private Build _build;
    public Transform PointCenter { get => _pointCenter;}
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private bool _isBuild;
    public bool IsBuild { get => _isBuild; set => _isBuild = value; }
    public Build Build { get => _build; set => _build = value; }

    public void Activate()
    {
        meshRenderer.materials[0].color = Color.green;
    }

    public void DisActivate()
    {
        meshRenderer.materials[0].color = Color.white;
    }

    public void SetBuild(Build build){
        _build = build;
    }

}
