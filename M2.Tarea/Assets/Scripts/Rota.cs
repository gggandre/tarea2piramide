using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*# ----------------------------------------------------------
# M2. Tarea
#  Implementa la solución de la pregunta 2
#
# Date: 15-Nov-2022
# Authors:
#           A01745446 Sergio Manuel Gonzalez Vargas
#           A01753176 Gilberto André García Gaytán
#           A01379299 Ricardo Ramírez Condado
# ----------------------------------------------------------*/

/* It creates a mesh, defines its topology, and rotates it around the y axis */
public class Rota : MonoBehaviour
{
    public static Vector4 Vector3To4(Vector3 inVec)
    {
        /* Converting a Vector3 to a Vector4. */
        Vector4 Vector = new Vector4(inVec.x, inVec.y, inVec.z, 1);
        return Vector;
    }
    public static Vector3 Vector4To3(Vector4 inVec)
    {
        /* Converting a Vector4 to a Vector3. */
        Vector3 Vector = new Vector3(inVec.x, inVec.y, inVec.z);
        return Vector;
    }
    /* Creating an array of vertices. */
    Vector3[] vertice;
    /* Defining the topology of the mesh. */
    private int[] topology;
    /* Converting degrees to radians. */
    private float rota = Mathf.PI / 180f;
    void Start()
    {
        /* Creating a new mesh and assigning it to the mesh filter component of the game object. */
        Mesh mesh = new Mesh()                ;
        GetComponent<MeshFilter>().mesh = mesh;
        /* Creating a new array of vertices and assigning the vertices of the mesh to the array. */
        vertice = new Vector3[4]              ;
        // cálculos de los vertices están en el pdf
        vertice[0] = new Vector3(-3.05f, -6.824f, 3.799f) ;
        vertice[1] = new Vector3(-2.446f, -6.824f, 7.043f);
        vertice[2] = new Vector3(-0.060f, -6.824f, 4.897f);
        vertice[3] = new Vector3(-1.812f, -4.129f, 5.247f);
        /* Defining the topology of the mesh. */
        topology = new int[12]   ;
        topology[0] =  1         ;
        topology[1] =  3         ;
        topology[2] =  2         ;
        topology[3] =  1         ;
        topology[4] =  2         ;
        topology[5] =  0         ;
        topology[6] =  1         ;
        topology[7] =  0         ;
        topology[8] =  3         ;
        topology[9] =  2         ;
        topology[10] = 3         ;
        topology[11] = 0         ;
        /* Updating the mesh vertices. */
        mesh.vertices = vertice  ;
        /* Defining the topology of the mesh. */
        mesh.triangles = topology;
        /* Calculating the normals of the mesh. */
        mesh.RecalculateNormals();
    }
    void Update()
    {
        /* Creating a transformation matrix that is the result of the multiplication of three matrices.
        The first one is a translation matrix that moves the object to the origin. The second one is
        a rotation matrix that rotates the object around the y axis. The third one is a translation
        matrix that moves the object back to its original position. */
        Matrix4x4 transformar = Transformacion.Trasladar_matriz(-1.81f, -6.1475f, 5.2925f) * Transformacion.RotarMatriz(-15*rota, Transformacion.Ejes.ejey) * Transformacion.Trasladar_matriz(1.81f, 6.1475f, -5.2925f);
        /* Multiplying the vertices by the transformation matrix. */
        vertice[0] = transformar * Vector3To4(vertice[0]);
        vertice[1] = transformar * Vector3To4(vertice[1]);
        vertice[2] = transformar * Vector3To4(vertice[2]);
        vertice[3] = transformar * Vector3To4(vertice[3]);
        /* Updating the mesh vertices. */
        GetComponent<MeshFilter>().mesh.vertices = vertice;
    }
}
