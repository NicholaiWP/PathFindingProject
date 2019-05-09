using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorigtme_projekt_mono
{


   public class GameObject
 {

    private List<MyComponent> components = new List<MyComponent>();
    private List<MyComponent> componentsToAdd = new List<MyComponent>();
    private List<MyComponent> componentsToRemove = new List<MyComponent>();

    //Transform component is cached in a property for easy access because all GameObjects have one
    public Transform Transform { get; set; }

    /// <summary>
    /// Constructor of the gameobject
    /// </summary>
    /// <param name="position"></param>
    public GameObject(Vector2 position)
    {
        Transform = new Transform(position);
        AddComponent(Transform);
    }

    /// <summary>
    /// Method for adding components to the list
    /// </summary>
    /// <param name="component"></param>
    public void AddComponent(MyComponent component)
    {
        if (!components.Any(a => a.GetType() == component.GetType()))
        {
            componentsToAdd.Add(component);
            component.GameObject = this;       
        }
        else
        {
            throw new InvalidOperationException("The game object already contains a component of this type.");
        }
    }

    /// <summary>
    /// Method for removing a component from the list
    /// </summary>
    /// <param name="componentName"></param>
    public void RemoveComponent<T>() where T : MyComponent
    {
        componentsToRemove.Add(GetComponent<T>());
    }

    /// <summary>
    /// Method for getting a specific component by its type
    /// </summary>
    /// <param name="componentName"></param>
    /// <returns></returns>
    public T GetComponent<T>() where T : MyComponent
    {
        return components.OfType<T>().FirstOrDefault();
    }

    /// <summary>
    /// Forwards a message to all components on this game object.
    /// </summary>
    /// <typeparam name="T">Type of message (No need to type this out, it is inferred from the 'message' parameter)</typeparam>
    /// <param name="message">Message to forward</param>
    public void SendMessage<T>(T message) where T : Msg
    {
        foreach (MyComponent comp in components)
            comp.SendMessage(message);
    }

    public void ProcessComponents()
    {
        //Add components to be added
        //Step 1: Add to component list
        foreach (MyComponent comp in componentsToAdd)
            components.Add(comp);

        List<MyComponent> componentsToInitialize = new List<MyComponent>(componentsToAdd);
        //Step 2: Initialize
        foreach (MyComponent comp in componentsToInitialize)
            comp.SendMessage(new InitializeMsg());

        //Remove components to be removed
        foreach (MyComponent comp in componentsToRemove)
            components.Remove(comp);

        componentsToAdd.Clear();
        componentsToRemove.Clear();
    }
  }
}
