//this is a simple unity implementation that just create a mesh given an index from the table taken at random;


using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class marchingSquareProva : MonoBehaviour
{
    
    public bool button = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (button)
        {
            gen();
            button = false;
        }
    }


    void gen()
    {
        int[][] lookUpTable = new int[][]
        {
            new int[] {},
            new int[] {6, 5, 7},
            new int[] {4, 3, 5},
            new int[] {6, 4, 7, 7, 4, 3},
            new int[] {2, 1, 3},
            new int[] {2, 1, 3, 1, 7, 3, 3, 7, 5, 5, 7, 6},
            new int[] {2, 1, 4, 4, 1, 5},
            new int[] {6, 1, 7, 1, 6, 2, 2, 6, 4},
            new int[] {0, 7, 1},
            new int[] {0, 6, 1, 1, 6, 5},
            new int[] {0, 7, 1, 1, 7, 5, 5, 3, 1, 5, 4, 3},
            new int[] {0, 6, 4, 4, 3, 0, 0, 3, 1},
            new int[] {0, 7, 3, 3, 2, 0},
            new int[] {0, 6, 2, 2, 6, 5, 5, 3, 2},
            new int[] {2, 0, 4, 4, 0, 5, 5, 0, 7},
            new int[] {4, 2, 0, 0, 6, 4}
        };



        Vector3[] vertices = new Vector3[] {
            
            new Vector3(-1, 1, 0),
            new Vector3(0, 1, 0),
            new Vector3(1, 1, 0),
            new Vector3(1, 0, 0),
            new Vector3(1, -1, 0),
            new Vector3(0, -1, 0),
            new Vector3(-1, -1, 0),
            new Vector3(-1, 0, 0)
        };




        MeshFilter mf = GetComponent<MeshFilter>();
        MeshRenderer mr = GetComponent<MeshRenderer>();

        Mesh mesh = new Mesh();



        int idx = Random.Range(0, lookUpTable.Length);

        int[] triangles = lookUpTable[idx];

        

        mesh.vertices = vertices;
        mesh.triangles = triangles;  

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        mf.mesh = mesh;

        

        
        mr.material = new Material(Shader.Find("Sprites/Default"))
        {
            color = Color.green
        };
    }

}
