public interface IInteractable
{
    //cualquier item o NPC con el que se pueda interactuar va a heredar de aquí

    void Interact();
    bool CanInteract();

}

