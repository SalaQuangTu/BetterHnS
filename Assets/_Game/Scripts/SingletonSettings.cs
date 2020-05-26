using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Fait Par Hubert Grossin et ajouté par QT
/// </summary>
/// <typeparam name="TSingletonType"></typeparam>
public class SingletonSettings<TSingletonType> : ScriptableObject
    where TSingletonType : ScriptableObject
{
    //Vraie instance du singleton
    private static TSingletonType _instance = null;

    //Accesseur a l'instance du Singleton
    public static TSingletonType Instance
    {
        get
        {
            //Si il n'y a pas encore d'instance sauvegradé dans l'asset, on en créée une
            if (_instance == null)
            {
                // On charge tout les singletons du type donné pour savoir si il y en a un existant ou non.
                TSingletonType[] settingsAsset = Resources.LoadAll<TSingletonType>("");
                //Si elle existe,  on charge celle la
                if (settingsAsset.Length == 1)
                {
                    _instance = settingsAsset[0];
                }
                //Si il en a trouvé plusieur, il charge la première mais fait signe que c'est anormal
                else if (settingsAsset.Length > 1)
                {
                    Debug.LogWarning("There's more than one asset of type " + typeof(TSingletonType).FullName);
                    _instance = settingsAsset[0];
                }
                //Sinon, on créer un nouveau scriptable et on l'associe.
                else
                {
                    Debug.LogWarning("There's no asset of type " + typeof(TSingletonType).FullName);
                    _instance = ScriptableObject.CreateInstance<TSingletonType>();
                }
            }

            // Dans tout les cas, on retourne l'instance trouvé ou créée.
            return _instance;
        }
    }
}