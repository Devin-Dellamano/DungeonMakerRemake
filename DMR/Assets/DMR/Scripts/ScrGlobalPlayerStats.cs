using System.Collections.Generic;

/// <summary>
/// The global stats for the player. 
/// This includes the player's characters and global currency.
/// </summary>
[System.Serializable]
public class ScrGlobalPlayerStats
{
    // TODO: Include high scores etc.

    #region Fields

    /// <summary>
    /// Backing field for the player's characters.
    /// </summary>
    protected List<DummyCharacter> characters;

    /// <summary>
    /// Backing field for the player's global currency.
    /// </summary>
    public uint globalCurrency = 0;

    #endregion

    #region Properties

    /// <summary>
    /// Public accessor to the player's current global currency.
    /// </summary>
    public uint GlobalCurrency { get { return globalCurrency; } }

    #endregion

    #region Methods

    #region Currency

    /// <summary>
    /// Sets the player's global currency directly to the given amount.
    /// </summary>
    /// <param name="targetAmount">The target currency amount.</param>
    public void SetCurrency(uint targetAmount)
    {
        globalCurrency = targetAmount;
    }

    /// <summary>
    /// Adds an amount to the player's currency.
    /// </summary>
    /// <param name="amountToAdd">The amount to add to the player's currency.</param>
    public void AddCurrency(uint amountToAdd)
    {
        globalCurrency += amountToAdd;
    }

    /// <summary>
    /// Removes the given amount of currency if it is available.
    /// </summary>
    /// <param name="amountToRemove">The amount to remove.</param>
    /// <returns>True if the amount was successfully removed. False if the amount could not be met.</returns>
    public bool RemoveCurrency(uint amountToRemove)
    {
        if (!HasCurrency(amountToRemove))
        {
            return false;
        }

        globalCurrency -= amountToRemove;
        return true;
    }

    /// <summary>
    /// Whether or not the global currency is greater than or equal to the given amount.
    /// </summary>
    /// <param name="amountToCheck">The amount to check for.</param>
    /// <returns>True if global currency is greater than or equal to the given amount. False otherwise.</returns>
    public bool HasCurrency(uint amountToCheck)
    {
        return globalCurrency >= amountToCheck;
    }

    #endregion

    #region Characters

    /// <summary>
    /// Gets the total number of characters.
    /// </summary>
    /// <returns>The total number of characters. 0 if the list has not been initialized.</returns>
    public int GetNumberOfCharacters()
    {
        if (characters == null)
        {
            return 0;
        }

        return characters.Count;
    }

    /// <summary>
    /// Adds a character to the player's list of characters. Characters are unique and duplicates are not allowed.
    /// </summary>
    /// <param name="characterToAdd">The character to add to the player's list of characters.</param>
    /// <returns>True if the character was successfully added to the list.</returns>
    public bool AddCharacter(DummyCharacter characterToAdd)
    {
        if (characters == null)
        {
            characters = new List<DummyCharacter>();
        }

        if (characters.Contains(characterToAdd))
        {
            return false;
        }

        characters.Add(characterToAdd);
        return true;
    }

    /// <summary>
    /// Gets a character with the given index.
    /// </summary>
    /// <param name="index">Index of the character to access.</param>
    /// <returns>Returns the character at the given index. Returns null if character could not be retrieved.</returns>
    public DummyCharacter GetCharacterByIndex(int index)
    {
        if (characters == null || index >= characters.Count || index < 0)
        {
            UnityEngine.Debug.LogWarning("Global Character List has not been initialized, or index was out of bounds.");
            return null;
        }

        return characters[index];
    }

    #endregion

    #endregion

    public class DummyCharacter
    {
        public bool unlocked;
        public int level;
        public string name;
    }

}
