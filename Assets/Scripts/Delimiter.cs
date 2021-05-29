using UnityEngine;

public class Delimiter : MonoBehaviour
{
    [SerializeField] private GameObject _template;

    private int _maxCreateCount = 3;
    private int _minCreateCount = 2;

    public void Multiply()
    {
        int createCount = Random.Range(_minCreateCount, _maxCreateCount + 1);
        for (int i = 0; i < createCount; i++)
        {
            var template = Instantiate(_template, transform.position, transform.rotation);
            template.transform.localScale /= createCount;
        }
    }
}
