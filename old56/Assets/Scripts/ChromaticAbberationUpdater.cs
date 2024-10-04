using Unity.Mathematics;
using UnityEngine;

public class ChromaticAbberationUpdater : MonoBehaviour
    //������ ����� ������ ������ ��������� ������� �� chromaticAbberationShader. ������ ��� �� �������� � �������� �������� � �� ��������� 
{
    public Shader chromaticAberrationShader;
    private Material material;

    private void Start()
    {
        // Get the material with the chromatic aberration shader
        material = GetComponent<SpriteRenderer>().material;
        material.shader = chromaticAberrationShader;
    }

    private void Update()
    {
        // Calculate the object's velocity
        Vector3 velocity = transform.InverseTransformDirection(GetComponent<Rigidbody2D>().velocity);

        // Calculate the velocity magnitude
        float velocityMagnitude = velocity.magnitude / 100;

        Vector3 aberrationDirection = Vector3.Normalize(velocity);


        // Update the _Velocity and _VelocityMagnitude uniform variables
        material.SetVector("_AberrationDirection", aberrationDirection);
        material.SetFloat("_AberrationAmount", velocityMagnitude);
    }
}