using System.Collections.Generic;
using System.Linq;

/// <summary>
/// The player's session inventory.
/// </summary>
[System.Serializable]
public class ScrPlayerInventory
{
    #region Fields

    /// <summary>
    /// Backing field that handles storing the player's gold. Only use modifier functions.
    /// </summary>
    protected uint playerGold = 0;

    /// <summary>
    /// Backing field that handles storing the player's monsters. Only use modifier functions.
    /// </summary>
    protected List<DummyMonster> monsters;

    /// <summary>
    /// Backing field that handles storing the player's relics. Only use modifier functions.
    /// </summary>
    protected List<DummyRelic> relics;

    #endregion

    #region Properties

    /// <summary>
    /// Public accessor to the player's gold.
    /// </summary>
    public uint PlayerGold { get => playerGold; }

    #endregion

    #region Methods

    #region Gold

    /// <summary>
    /// Adds to the player's gold count.
    /// </summary>
    /// <param name="valueToAdd">The amount of gold to add.</param>
    public void AddGold(uint amountToAdd)
    {
        playerGold += amountToAdd;
    }

    /// <summary>
    /// Removes an amount of gold from the player's gold.
    /// </summary>
    /// <param name="amountToRemove">The amount to remove.</param>
    /// <returns>Returns false if the amount to remove is higher than the current amount of gold.</returns>
    public bool RemoveGold(uint amountToRemove)
    {
        if (!HasGold(amountToRemove))
        {
            return false;
        }

        playerGold -= amountToRemove;
        return true;
    }

    /// <summary>
    /// Checks whether or not the player has the given amount of gold.
    /// </summary>
    /// <param name="amountToCheck">The amount of gold to check for.</param>
    /// <returns>True if the player's gold amounts to the same or higher.</returns>
    public bool HasGold(uint amountToCheck)
    {
        return playerGold >= amountToCheck;
    }

    #endregion

    #region Monsters

    /// <summary>
    /// Adds a monster to the player's monsters. Initializes the list if it has not been already.
    /// </summary>
    /// <param name="monsterToAdd">The monster to add.</param>
    public void AddMonster(DummyMonster monsterToAdd)
    {
        if (monsters == null)
        {
            monsters = new List<DummyMonster>();
        }

        monsters.Add(monsterToAdd);
    }

    /// <summary>
    /// Removes a monster from the player's monsters.
    /// </summary>
    /// <param name="monsterToRemove">The monster to remove.</param>
    /// <returns>Whether or not the given monster was able to be removed.</returns>
    public bool RemoveMonster(DummyMonster monsterToRemove)
    {
        // Monster list has not been initialized. Silently handle this.
        if (monsters == null)
        {
            return false;
        }

        return monsters.Remove(monsterToRemove);
    }

    /// <summary>
    /// Removes a monster at the given index from the player's monsters.
    /// </summary>
    /// <param name="index">The index of the monster to remove.</param>
    /// <returns>Whether or not the given monster was able to be removed.</returns>
    public bool RemoveMonster(int index)
    {
        // Monster list has not been initialized or index is out of range. Silently handle this.
        if (monsters == null || monsters.Count >= index || index < 0)
        {
            return false;
        }

        monsters.RemoveAt(index);
        return true;
    }

    /// <summary>
    /// Retrieves a monster from the player by index.
    /// </summary>
    /// <param name="index">The index of the monster to retrieve.</param>
    /// <returns>Returns a monster at the given index.</returns>
    public DummyMonster GetMonsterByIndex(int index)
    {
        if (monsters == null)
        {
            throw new System.NullReferenceException("Player's monster list has not been initialized. Cannot get a monster from a null list.");
        }
        else if (monsters.Count >= index || index < 0)
        {
            throw new System.IndexOutOfRangeException("Attempted to get a monster from the player with an out of range index.");
        }

        return monsters[index];
    }

    /// <summary>
    /// Retrieves a monster from the player by name.
    /// </summary>
    /// <param name="monsterName">The name of the monster to retrieve.</param>
    /// <returns>Returns a monster if it exists. Returns null if it doesn't.</returns>
    public DummyMonster GetMonsterByName(string monsterName)
    {
        if (monsters == null)
        {
            throw new System.NullReferenceException("Player's monster list has not been initialized. Cannot get a monster from a null list.");
        }

        return monsters.FirstOrDefault(m => m.name == monsterName);
    }

    /// <summary>
    /// Gets the number of monsters the player currently has.
    /// </summary>
    /// <returns>The number of monsters the player has.</returns>
    public int GetNumberOfMonsters()
    {
        if (monsters == null)
        {
            return 0;
        }

        return monsters.Count;
    }

    #endregion

    #region Relics

    /// <summary>
    /// Adds a relic to the player's relics. Initializes the list if it has not been already.
    /// </summary>
    /// <param name="relicToAdd">The relic to add.</param>
    public void AddRelic(DummyRelic relicToAdd)
    {
        if (relics == null)
        {
            relics = new List<DummyRelic>();
        }

        relics.Add(relicToAdd);
    }

    /// <summary>
    /// Removes a relic from the player's relics.
    /// </summary>
    /// <param name="relicToRemove">The relic to remove.</param>
    /// <returns>Whether or not the given relic was able to be removed.</returns>
    public bool RemoveRelic(DummyRelic relicToRemove)
    {
        // relic list has not been initialized. Silently handle this.
        if (relics == null)
        {
            return false;
        }

        return relics.Remove(relicToRemove);
    }

    /// <summary>
    /// Removes a relic at the given index from the player's relics.
    /// </summary>
    /// <param name="index">The index of the relic to remove.</param>
    /// <returns>Whether or not the given relic was able to be removed.</returns>
    public bool RemoveRelic(int index)
    {
        // relic list has not been initialized or index is out of range. Silently handle this.
        if (relics == null || relics.Count >= index || index < 0)
        {
            return false;
        }

        relics.RemoveAt(index);
        return true;
    }

    /// <summary>
    /// Retrieves a relic from the player by index.
    /// </summary>
    /// <param name="index">The index of the relic to retrieve.</param>
    /// <returns>Returns a relic at the given index.</returns>
    public DummyRelic GetRelicByIndex(int index)
    {
        if (relics == null)
        {
            throw new System.NullReferenceException("Player's relic list has not been initialized. Cannot get a relic from a null list.");
        }
        else if (relics.Count >= index || index < 0)
        {
            throw new System.IndexOutOfRangeException("Attempted to get a relic from the player with an out of range index.");
        }

        return relics[index];
    }

    /// <summary>
    /// Retrieves a relic from the player by name.
    /// </summary>
    /// <param name="relicName">The name of the relic to retrieve.</param>
    /// <returns>Returns a relic if it exists. Returns null if it doesn't.</returns>
    public DummyRelic GetRelicByName(string relicName)
    {
        if (relics == null)
        {
            throw new System.NullReferenceException("Player's relic list has not been initialized. Cannot get a relic from a null list.");
        }

        return relics.FirstOrDefault(m => m.name == relicName);
    }

    /// <summary>
    /// Gets the number of relics the player currently has.
    /// </summary>
    /// <returns>The number of relics the player has.</returns>
    public int GetNumberOfRelics()
    {
        if (relics == null)
        {
            return 0;
        }

        return relics.Count;
    }

    #endregion

    #endregion

    public class DummyMonster
    {
        public string name;
    }

    public class DummyRelic
    {
        public string name;
    }
}
