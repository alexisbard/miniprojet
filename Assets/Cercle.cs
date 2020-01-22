using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cercle : MonoBehaviour
{
    private Transform SphereHolder;
    private float t;
    [SerializeField] private int nbObjects = 20;
    [SerializeField] private int radius = 2;
    [SerializeField] private GameObject Prefab = default;
    [SerializeField] private int ellipseFactorA = 2;
    [SerializeField] private int ellipseFactorB = 4;
    // Start is called before the first frame update
    void Start()
    {
        SphereHolder = transform;
    }

    // Update is called once per frame
    void Update()
    {
        //yield return new WaitForSeconds(0.1f);
        List<Vector3> circlePoints = new List<Vector3>();
        for (int i = 0; i < nbObjects; i++)
        {
            t = 2 * Mathf.PI*i / nbObjects;
            circlePoints.Add(new Vector3(radius  *2*  ellipseFactorA*((1 - Mathf.Pow(Mathf.Tan(t), 2)) / (1 + Mathf.Pow(Mathf.Tan(t), 2))), radius  *ellipseFactorB * (Mathf.Tan(t)) / (1 + Mathf.Pow(Mathf.Tan(t), 2)), 0));
        }
        foreach (Transform child in SphereHolder) Destroy(child.gameObject);
        foreach (Vector3 middle in circlePoints) Instantiate(Prefab, middle, Quaternion.identity, SphereHolder);

    }
}