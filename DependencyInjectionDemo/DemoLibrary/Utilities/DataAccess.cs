using System;

namespace DemoLibrary.Utilities
{
  public class DataAccess : IDataAccess
  {
    private ILogger _logger;

    public DataAccess(ILogger logger)
    {
      _logger = logger;
    }

    public void LoadData()
    {
      Console.WriteLine("Loading Data");
      _logger.Log("Loading Data!!!");
    }

    public void SaveData(string name)
    {
      Console.WriteLine($"Saving {name}");
      _logger.Log("Saving Data!!!");
    }

  }
}
