using UnityEngine;

[CreateAssetMenu(fileName = "NewTextureData", menuName = "Custom/Texture Data")]
public class PlanetsData : ScriptableObject
{
    // Atributo para almacenar la textura
    public Texture texture;

    // Función para cambiar la textura
    public void ChangeTexture(Texture newTexture)
    {
        // Asigna la nueva textura al atributo `texture`
        texture = newTexture;
    }
}
