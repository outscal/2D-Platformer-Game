using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMap3D : MonoBehaviour {

    TilemapCollider2D tilemapCollider;

    //List<Vector3> verticesList = new List<Vector3>(vertices3D);

    private void Awake() {
        tilemapCollider = GetComponent<TilemapCollider2D>();
    }

    private void Start() {
        // get all the physics shapes into a group
        PhysicsShapeGroup2D group = new PhysicsShapeGroup2D();
        int n_shapes = tilemapCollider.GetShapes(group);

        // iterate through every shape in the group
        List<Vector3> vertices3d = new List<Vector3>();
        List<int> indices = new List<int>();
        for (int i = 0; i < n_shapes; i++) {

            List<Vector2> vertices = new List<Vector2>();
            group.GetShapeVertices(i, vertices);

            // We make 3D version of the vertices from each shape
            for (int ii = 0; ii < vertices.Count; ii++) {
                int N = vertices.Count;
                int firstIndex = vertices3d.Count;

                int i1 = firstIndex + ii;
                int i2 = firstIndex + ((i1 + 1) % N);
                int i3 = i1 + N;
                int i4 = i2 + N;

                indices.Add(i1);
                indices.Add(i3);
                indices.Add(i4);

                indices.Add(i1);
                indices.Add(i4);
                indices.Add(i2);
            }
            for (int ii = 0; ii < vertices.Count; ii++) {
                vertices3d.Add(new Vector3(vertices[ii].x, vertices[ii].y, 1));
            }
            for (int ii = 0; ii < vertices.Count; ii++) {
                vertices3d.Add(new Vector3(vertices[ii].x, vertices[ii].y, -1));
            }
        }

        Mesh mesh = new Mesh();
        mesh.vertices = vertices3d.ToArray();
        mesh.triangles = indices.ToArray();

        /*mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.Optimize();*/

        DestroyImmediate(tilemapCollider);
        MeshCollider meshCollider = gameObject.AddComponent<MeshCollider>();
        //meshCollider.convex = true;
        meshCollider.sharedMesh = mesh;

    }
}