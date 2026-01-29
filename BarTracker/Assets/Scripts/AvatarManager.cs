using System.Collections.Generic;
using UnityEngine;

public class AvatarManager : MonoBehaviour
{
    public GameObject avatarPrefab; // Arrastra aquí tu modelo 3D
    public float smoothing = 10f;    // Para que no se mueva a saltos
    
    // Diccionario para rastrear quién es quién
    private Dictionary<int, GameObject> activeAvatars = new Dictionary<int, GameObject>();


    public void Update ()
    {
        if (activeAvatars.ContainsKey(1))
        {
            // Suavizar movimiento de Avatar 1 y hacer que camine hacia adelante
            GameObject avatar1 = activeAvatars[1];
            avatar1.transform.position += avatar1.transform.right * Time.deltaTime * 1.5f; // Velocidad de caminata
            avatar1.transform.position = Vector3.Lerp(avatar1.transform.position, avatar1.transform.position, Time.deltaTime * smoothing);
        }
        if (activeAvatars.ContainsKey(2))
        {
            // Suavizar movimiento de Avatar 2 y hacer que camine hacia adelante
            GameObject avatar2 = activeAvatars[2];
            avatar2.transform.position += -avatar2.transform.right * Time.deltaTime * 1.5f; // Velocidad de caminata
            avatar2.transform.position = Vector3.Lerp(avatar2.transform.position, avatar2.transform.position, Time.deltaTime * smoothing);
        }
    }

    // Esta función la llamaremos cuando llegue un dato de la cámara
    public void UpdateAvatar(int id, Vector3 targetPosition)
    {
        if (activeAvatars.ContainsKey(id))
        {
            // Si ya existe, actualizamos su posición objetivo
            // (Podemos usar un script en el propio avatar para que se mueva suavemente)
            activeAvatars[id].transform.position = Vector3.Lerp(activeAvatars[id].transform.position, targetPosition, Time.deltaTime * smoothing);
        }
        else
        {
            // Si es nuevo, lo creamos
            GameObject newAvatar = Instantiate(avatarPrefab, targetPosition, Quaternion.identity);
            newAvatar.name = "Avatar_" + id;
            activeAvatars.Add(id, newAvatar);
        }
    }

    // Para eliminar a alguien que salió de la barra
    public void RemoveAvatar(int id)
    {
        if (activeAvatars.ContainsKey(id))
        {
            Destroy(activeAvatars[id]);
            activeAvatars.Remove(id);
        }
    }
}