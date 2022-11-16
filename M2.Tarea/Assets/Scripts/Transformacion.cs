using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*# ----------------------------------------------------------
# Lab #4: Cyptrarithmetic Puzzle
#  Implementa la solución de la pregunta 2
#
# Date: 15-Nov-2022
# Authors:
#           A01745446 Sergio Manuel Gonzalez Vargas
#           A01753176 Gilberto André García Gaytán
#           A01379299 Ricardo Ramírez Condado
# ----------------------------------------------------------*/

/* It contains methods that create matrices for translation, rotation, and scaling */
public class Transformacion : MonoBehaviour
{
    public static Matrix4x4 Trasladar_matriz(float trasladar_x, float trasladar_y, float trasladar_z)
    {
        /* Creating a translation matrix. */
        Matrix4x4 trasladar = Matrix4x4.identity;
        /* Creating a translation matrix. */
        trasladar[0, 3] = trasladar_x;
        trasladar[1, 3] = trasladar_y;
        trasladar[2, 3] = trasladar_z;
        return trasladar;
    }
    public static Matrix4x4 EscalaMatriz(float escala_x, float escala_y, float escala_z)
    {
        /* Creating a matrix that will scale the object. */
        Matrix4x4 escala_matriz = Matrix4x4.identity;
        /* Creating a matrix that will scale the object. */
        escala_matriz[0, 0] = escala_x;
        escala_matriz[1, 1] = escala_y;
        escala_matriz[2, 2] = escala_z;
        return escala_matriz;
    }
    public static Matrix4x4 RotarMatriz(float angulo, Ejes ejes)
    {
        /* Converting the angle from degrees to radians. */
        Matrix4x4 rotar_matriz = Matrix4x4.identity;
        float radio = angulo * Mathf.Deg2Rad;
        /* Checking if the axis is the x axis. */
        if (ejes == Ejes.ejex)
        {
            /* It rotates the object around the y axis. */
            rotar_matriz[1, 1] = Mathf.Cos(radio);
            rotar_matriz[1, 2] = -Mathf.Sin(radio);
            rotar_matriz[2, 1] = Mathf.Sin(radio);
            rotar_matriz[2, 2] = Mathf.Cos(radio);
        }
        /// It rotates the object around the y axis.
        /// <param name="ejes">The axis to rotate around.</param>
        else if (ejes == Ejes.ejey)
        {
            /* It rotates the object around the y axis. */
            rotar_matriz[0, 0] = Mathf.Cos(radio);
            rotar_matriz[0, 2] = Mathf.Sin(radio);
            rotar_matriz[2, 0] = -Mathf.Sin(radio);
            rotar_matriz[2, 2] = Mathf.Cos(radio);
        }
        /// It rotates the object around the z axis.
        /// <param name="ejes">The axis to rotate around.</param>
        else if (ejes == Ejes.ejez)
        {
            /* Rotating the vector around the z axis. */
            rotar_matriz[0, 0] = Mathf.Cos(radio);
            rotar_matriz[0, 1] = -Mathf.Sin(radio);
            rotar_matriz[1, 0] = Mathf.Sin(radio);
            rotar_matriz[1, 1] = Mathf.Cos(radio);
        }
        /* Returning the matrix that was created. */
        return rotar_matriz;
    }
    public static Vector4 Trasladar(Vector4 principal, float x, float y, float z)
    {
        /* A translation matrix. */
        Matrix4x4 i = Matrix4x4.identity;
        i[0, 3] = x;
        i[1, 3] = y;
        i[2, 3] = z;
        return i * principal;
    }
    public static Vector4 Trasladar(Vector4 principal, Vector4 transferir)
    {
        /* A translation matrix. */
        Matrix4x4 trasladar = Matrix4x4.identity;
        trasladar[0, 3] = transferir.x;
        trasladar[1, 3] = transferir.y;
        trasladar[2, 3] = transferir.z;
        trasladar[3, 3] = 1;
        return trasladar * principal;
    }
    public static Vector4 Escala(Vector4 principal, float x, float y, float z)
    {
        /* A matrix multiplication. */
        Matrix4x4 escala = Matrix4x4.identity;
        escala[0, 0] = x;
        escala[1, 1] = y;
        escala[2, 2] = z;
        return escala * principal;
    }
    public static Vector4 Rotar_ejex(Vector4 principal, float grados)
    {
        /* Converting the degrees to radians. */
        float radianes = Mathf.Deg2Rad * grados;
        Matrix4x4 rotax = Matrix4x4.identity;
        float coseno = Mathf.Cos(radianes);
        float seno = Mathf.Sin(radianes);
        /* Rotating the vector around the x axis. */
        rotax[1, 1] = coseno;
        rotax[1, 2] = -seno;
        rotax[2, 1] = seno;
        rotax[2, 2] = coseno;
        return rotax * principal;
    }
    public static Vector4 Rotar_ejey(Vector4 principal, float grados)
    {
        /* Converting the degrees to radians. */
        float radianes = Mathf.Deg2Rad * grados;
        Matrix4x4 rotay = Matrix4x4.identity;
        float coseno = Mathf.Cos(radianes);
        float seno = Mathf.Sin(radianes);
        /* Rotating the vector around the y axis. */
        rotay[0, 0] = coseno;
        rotay[0, 2] = seno;
        rotay[2, 0] = -seno;
        rotay[2, 2] = coseno;
        return rotay * principal;
    }
    public static Vector4 RotateZ(Vector4 principal, float grados)
    {
        /* Converting the degrees to radians. */
        float radianes = Mathf.Deg2Rad * grados;
        Matrix4x4 rotaz = Matrix4x4.identity;
        float coseno = Mathf.Cos(radianes);
        float seno = Mathf.Sin(radianes);
        /* Rotating the vector around the z axis. */
        rotaz[0, 0] = coseno;
        rotaz[0, 1] = seno;
        rotaz[1, 0] = -seno;
        rotaz[1, 1] = coseno;
        return rotaz * principal;
    }
 public enum Ejes    // An enumeration is useful to remember names instead of numbers
    {
        /* An enumeration. It is useful to remember names instead of numbers. */
        ejex,
        ejey,
        ejez
    }
}
