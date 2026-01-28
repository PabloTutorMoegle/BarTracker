using UnityEngine;
using UnityEngine.InputSystem; // ¡Importante añadir esto!

public class MockSensor : MonoBehaviour
{
    public AvatarManager avatarManager;
    public float rangeX;
    
    void Update()
    {
        // En el nuevo sistema se accede a través de Keyboard.current
        var keyboard = Keyboard.current;
        if (keyboard == null) return; 

        // 1. Crear o Actualizar Persona #1 (Tecla 1)
        if (keyboard.digit1Key.isPressed) {
            Vector3 fakePos = new Vector3(-rangeX, 2, 1);
            avatarManager.UpdateAvatar(1, fakePos);
        }

        // 2. Eliminar Persona #1 (Tecla Q)
        if (keyboard.qKey.wasPressedThisFrame) {
            avatarManager.RemoveAvatar(1);
        }
        
        // Repite lo mismo para la tecla 2 (digit2Key) y W (wKey)
        // 3. Crear o Actualizar Persona #2 (Tecla 2)
        if (keyboard.digit2Key.isPressed) {
            Vector3 fakePos = new Vector3(rangeX, 2, 1);
            avatarManager.UpdateAvatar(2, fakePos);
        }

        // 4. Eliminar Persona #2 (Tecla W)
        if (keyboard.wKey.wasPressedThisFrame) {
            avatarManager.RemoveAvatar(2);
        }
    }
}        