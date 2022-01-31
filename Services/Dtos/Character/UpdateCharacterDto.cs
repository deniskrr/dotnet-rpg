using dotnet_rpg.Models;

namespace dotnet_rpg.Services.Dtos.Character
{
  public class UpdateCharacterDto
  {
    public int Id { get; set; }
    public string Name { get; set; } = "Frodo";
    public int HitPoints { get; set; } = 100;
    public int Strength { get; set; } = 10;
    public int Defense { get; set; } = 10;
    public int Intelligence { get; set; } = 10;
    public Class Class { get; set; } = Class.Knight;
  }
}