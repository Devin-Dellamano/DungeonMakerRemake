using UnityEngine;

/// <summary>
/// The player's session stats.
/// </summary>
[System.Serializable]
public class ScrSessionPlayerStats
{
    #region Fields

    /// <summary>
    /// Backing field for the player's current health.
    /// </summary>
    protected int playerHealth;

    /// <summary>
    /// Backing field for the player's max health.
    /// </summary>
    protected int maxHealth;

    /// <summary>
    /// Backing field that handles storing the player's gold.
    /// </summary>
    protected uint playerGold = 0;

    /// <summary>
    /// Backing field for the player's current day.
    /// </summary>
    protected int currentDay;

    /// <summary>
    /// Backing field for the player's current level.
    /// </summary>
    protected int currentLevel;

    #endregion

    #region Properties

    /// <summary>
    /// Public accessor to the player's current health.
    /// </summary>
    public int PlayerHealth { get { return playerHealth; } }

    /// <summary>
    /// Public accessor to the player's maximum health.
    /// </summary>
    public int MaxPlayerHealth { get { return maxHealth; } }

    /// <summary>
    /// Public accessor to the player's gold.
    /// </summary>
    public uint PlayerGold { get { return playerGold; } }

    /// <summary>
    /// Public accessor to the player's current day.
    /// </summary>
    public int CurrentDay { get { return currentDay; } }

    /// <summary>
    /// Public accessor to the player's current level.
    /// </summary>
    public int CurrentLevel { get { return currentLevel; } }

    #endregion

    #region Methods

    #region Health

    /// <summary>
    /// Directly sets the health to the given value. Clamps it to 0 or max health if out of bounds.
    /// </summary>
    /// <param name="targetHealth">The target health value.</param>
    public void SetHealth(int targetHealth)
    {
        playerHealth = targetHealth;

        ClampHealth();
    }

    /// <summary>
    /// Adds an amount to the player's health. Clamps it to max health if out of bounds.
    /// </summary>
    /// <param name="healthToAdd">The amount of health to add to the player.</param>
    public void AddHealth(int healthToAdd)
    {
        playerHealth += healthToAdd;

        ClampHealth();
    }

    /// <summary>
    /// Removes an amount from the player's health. Clamps it to 0 if out of bounds.
    /// </summary>
    /// <param name="healthToRemove">The amount of health to remove from the player.</param>
    public void RemoveHealth(int healthToRemove)
    {
        playerHealth -= healthToRemove;

        ClampHealth();
    }

    /// <summary>
    /// Handles clamping the player's health to the maximum or minimum.
    /// </summary>
    protected void ClampHealth()
    {
        if (playerHealth > maxHealth)
            playerHealth = maxHealth;
        else if (playerHealth < 0)
            playerHealth = 0;
    }

    #endregion

    #region Gold

    /// <summary>
    /// Sets the player's gold directly to the target amount.
    /// </summary>
    /// <param name="targetAmount">The target amount of gold.</param>
    public void SetGold(uint targetAmount)
    {
        playerGold = targetAmount;
    }

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

    #region Day

    /// <summary>
    /// Sets the day to the target day. Day is clamped to 1 or more.
    /// </summary>
    /// <param name="targetDay">The target day.</param>
    public void SetDay(int targetDay)
    {
        currentDay = targetDay;

        if (currentDay < 1)
            currentDay = 1;
    }

    /// <summary>
    /// Increases the current day value by the given amount. Clamps to 0 or more.
    /// </summary>
    /// <param name="amountToIncrease">Number of days to increase by.</param>
    public void IncreaseDay(int amountToIncrease = 1)
    {
        if (amountToIncrease < 0)
            amountToIncrease = 0;

        currentDay += amountToIncrease;
    }

    #endregion

    #region Level

    /// <summary>
    /// Sets the current level to the target level. Clamped to 1 or more.
    /// </summary>
    /// <param name="targetLevel">The target level.</param>
    public void SetLevel(int targetLevel)
    {
        currentLevel = targetLevel;

        if (currentLevel < 1)
            currentLevel = 1;
    }

    /// <summary>
    /// Increases the current level by the given amount. Clamps to 0 or more.
    /// </summary>
    /// <param name="amountToIncrease"></param>
    public void IncreaseLevel(int amountToIncrease = 1)
    {
        if (amountToIncrease < 0)
            amountToIncrease = 0;

        currentLevel += amountToIncrease;
    }

    #endregion 

    #endregion
}
